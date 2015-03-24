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
            var cxt = new CustomerContext();

            List<Customer> customerList = cxt.Customers.ToList();

            foreach (Customer customer in customerList)
            {
                ListItem item = new ListItem(customer.FirstName + " " + customer.Surname, customer.CustomerID.ToString());
                cboCustomerDetails.Items.Add(item);
                cboCustomers.Items.Add(item);
                cboViewCustomers.Items.Add(item);
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

            var cxt = new CustomerContext();
            var accounts = cxt.Accounts.Where(a => a.CustomerID == customerID);

            foreach (var account in accounts)
            {
                ListItem item = new ListItem(account.AccountNumber.ToString());
                cboAccounts.Items.Add(item);
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

            var cxt = new CustomerContext();

            cxt.Customers.Add(newCustomer);
            cxt.SaveChanges();
        }

        private void RemoveCustomer()
        {
            bool hasAccounts = false;

            var cxt = new CustomerContext();

            int customerID = int.Parse(cboCustomers.SelectedValue);

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

        private void ViewCustomerDetails()
        {
            int id = int.Parse(cboViewCustomers.SelectedValue);

            var cxt = new CustomerContext();

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

        protected void btnCloseAccount_Click(object sender, EventArgs e)
        {
            DeleteAccount();
            cboAccounts.Items.Clear();
            PrimeAccountDropDown();
        }

        private void DeleteAccount()
        {
            int accountNumber = int.Parse(cboAccounts.SelectedItem.ToString());

            var cxt = new CustomerContext();

            cxt.Accounts.Remove(cxt.Accounts.Where(a => a.AccountNumber == accountNumber).First());
            cxt.SaveChanges();
            cboAccounts.Visible = false;
        }

        protected void btnLoadAccounts_Click(object sender, EventArgs e)
        {
            cboAccounts.Items.Clear();
            PrimeAccountDropDown();
            cboAccounts.Visible = true;
        }

        protected void btnExportXML_Click(object sender, EventArgs e)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Customer" + Guid.NewGuid() + ".xml";
            string fileName = Path.GetFileName(filePath);
            Stream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
            long bytesToRead = stream.Length;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; fileName" + fileName);

            while (bytesToRead > 0)
            {
                if (Response.IsClientConnected)
                {
                    byte[] buffer = new Byte[10000];
                    int length = stream.Read(buffer, 0, 10000);
                    Response.OutputStream.Write(buffer, 0, length);
                    Response.Flush();
                    bytesToRead = bytesToRead - 1;
                }
                else
                    bytesToRead = -1;
            }

        }

        protected void btnSaveXML_Click(object sender, EventArgs e)
        {
            string filePath = "~/XMLfiles/" + Guid.NewGuid() + ".xml";
            StreamWriter writer = new StreamWriter(Server.MapPath(filePath));
            SerializeCustomerInfo(writer);
        }

        private void SerializeCustomerInfo(StreamWriter writer)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Customer));
            int customerId = int.Parse(cboViewCustomers.SelectedValue);

            var cxt = new CustomerContext();
            Customer customer = cxt.Customers.Where(c => c.CustomerID == customerId).First();

            xmlSerializer.Serialize(writer, customer);
        }
    }
}