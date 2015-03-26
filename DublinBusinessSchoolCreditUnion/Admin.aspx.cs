using DublinBusinessSchoolCreditUnion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!CustomSessionObject.Current.IsAdmin)
            {
                Response.Redirect("ErrorPage.aspx", true);
            }
            if (!IsPostBack)
            {
                ClearCustomerDropdowns();
                cboAccounts.Items.Clear();
                PrimeCustomerDropdowns();
                PrimeAccountDropDown();

                Array countyNames = Enum.GetNames(typeof(Counties));

                for (int i = 0; i < countyNames.Length; i++)
                {
                    ListItem county = new ListItem(countyNames.GetValue(i).ToString());
                    cboCounties.Items.Add(county);
                }

                cboAccounts.Visible = false;
            }
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer();
            ClearCustomerDropdowns();
            PrimeCustomerDropdowns();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveCustomer();
            ClearCustomerDropdowns();
            PrimeCustomerDropdowns();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            ViewCustomerDetails();
        }

        private void PrimeCustomerDropdowns()
        {
            using (var cxt = new CustomerContext())
            {
                try
                {
                    List<Customer> customerList = cxt.Customers.ToList();

                    foreach (Customer customer in customerList)
                    {
                        ListItem item = new ListItem(customer.FirstName + " " + customer.Surname, customer.CustomerID.ToString());
                        cboCustomerDetails.Items.Add(item);
                        cboCustomers.Items.Add(item);
                        cboViewCustomers.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    FireBugWriter.Write(ex.Message);
                    throw ex;
                }
            }
        }

        private void ClearCustomerDropdowns()
        {
            cboCustomerDetails.Items.Clear();
            cboCustomers.Items.Clear();
            cboViewCustomers.Items.Clear();
        }

        private void PrimeAccountDropDown()
        {
            int customerID = int.Parse(cboCustomerDetails.SelectedValue);

            using (var cxt = new CustomerContext())
            {
                try
                {
                    var accounts = cxt.Accounts.Where(a => a.CustomerID == customerID);

                    foreach (var account in accounts)
                    {
                        ListItem item = new ListItem(account.AccountNumber.ToString());
                        cboAccounts.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    FireBugWriter.Write(ex.Message);
                    throw ex;
                }
            }
        }

        private void AddCustomer()
        {
            Customer newCustomer = new Customer();

            newCustomer.FirstName = txtFname.Text;
            newCustomer.Surname = txtLname.Text;
            newCustomer.Email = txtEmail.Text;
            newCustomer.Phone = txtPhone.Text;
            newCustomer.AddressLine1 = txtAddress1.Text;
            newCustomer.AddressLine2 = txtAddress2.Text;
            newCustomer.City = txtCity.Text;
            newCustomer.County = cboCounties.SelectedItem.ToString();

            using (var cxt = new CustomerContext())
            {
                try
                {
                    cxt.Customers.Add(newCustomer);
                    cxt.SaveChanges();
                }
                catch (Exception ex)
                {
                    FireBugWriter.Write(ex.Message);
                    throw ex;
                }
            }
        }

        private void RemoveCustomer()
        {
            bool hasAccounts = false;

            using (var cxt = new CustomerContext())
            {
                int customerID = int.Parse(cboCustomers.SelectedValue);

                try
                {
                    var customerWithAccounts = (from c in cxt.Customers
                                                join a in cxt.Accounts
                                                on c.CustomerID equals a.CustomerID
                                                where c.CustomerID == customerID
                                                select a.AccountNumber);

                    foreach (var account in customerWithAccounts)
                    {
                        if (account == 0)
                            hasAccounts = false;
                        else
                            hasAccounts = true;
                    }

                    if (hasAccounts)
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Customer has open Accounts!')", true);
                    else
                    {
                        cxt.Customers.Remove(cxt.Customers.Where(c => c.CustomerID == customerID).First());
                        cxt.SaveChanges();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Customer Record Deleted.')", true);
                    }
                }
                catch (Exception ex)
                {
                    FireBugWriter.Write(ex.Message);
                    throw ex;
                }
            }

        }

        private void ViewCustomerDetails()
        {
            int id = int.Parse(cboViewCustomers.SelectedValue);

            using (var cxt = new CustomerContext())
            {
                try
                {
                    Customer currentCustomer = cxt.Customers.Where(c => c.CustomerID == id).First();

                    lblDisplayFname.Text = currentCustomer.FirstName;
                    lblDisplayLname.Text = currentCustomer.Surname;
                    lblDisplayEmail.Text = currentCustomer.Email;
                    lblDisplayPhone.Text = currentCustomer.Phone;
                    lblDisplayAddress1.Text = currentCustomer.AddressLine1;
                    lblDisplayAddress2.Text = currentCustomer.AddressLine2;
                    lblDisplayCity.Text = currentCustomer.City;
                    lblDisplayCounty.Text = currentCustomer.County;
                }
                catch (Exception ex)
                {
                    FireBugWriter.Write(ex.Message);
                    throw ex;
                }
            }
        }

        protected void btnCloseAccount_Click(object sender, EventArgs e)
        {
            DeleteAccount();
            cboAccounts.Items.Clear();
            PrimeAccountDropDown();
        }

        private void DeleteAccount()
        {
            int accountNumber = int.Parse(cboAccounts.SelectedItem.ToString());

            using (var cxt = new CustomerContext())
            {
                try
                {
                    cxt.Accounts.Remove(cxt.Accounts.Where(a => a.AccountNumber == accountNumber).First());
                    cxt.SaveChanges();
                    cboAccounts.Visible = false;
                }
                catch (Exception ex)
                {
                    FireBugWriter.Write(ex.Message);
                    throw ex;
                }
            }
        }

        protected void btnLoadAccounts_Click(object sender, EventArgs e)
        {
            cboAccounts.Items.Clear();
            PrimeAccountDropDown();
            cboAccounts.Visible = true;
        }

        protected void btnExportXML_Click(object sender, EventArgs e)
        {   //add tryCatch or using
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Customer" + Guid.NewGuid() + ".xml";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                try
                {
                    SerializeCustomerInfo(writer);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Customer info saved to MyDocuments!')", true);
                }
                catch (Exception ex)
                {
                    FireBugWriter.Write(ex.Message);
                    throw ex;
                }
            }
        }

        protected void btnSaveXML_Click(object sender, EventArgs e)
        {
            string filePath = "~/XMLfiles/" + Guid.NewGuid() + ".xml";

            using (StreamWriter writer = new StreamWriter(Server.MapPath(filePath)))
            {
                try
                {
                    SerializeCustomerInfo(writer);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Customer info saved to server!')", true);
                }
                catch (Exception ex)
                {
                    FireBugWriter.Write(ex.Message);
                    throw ex;
                }
            }
        }

        private void SerializeCustomerInfo(StreamWriter writer)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Customer));
            int customerId = int.Parse(cboViewCustomers.SelectedValue);

            using (var cxt = new CustomerContext())
            {
                try
                {
                    Customer customer = cxt.Customers.Where(c => c.CustomerID == customerId).First();
                    xmlSerializer.Serialize(writer, customer);
                }
                catch (Exception ex)
                {
                    FireBugWriter.Write(ex.Message);
                    throw ex;
                }
            }
        }
    }
}