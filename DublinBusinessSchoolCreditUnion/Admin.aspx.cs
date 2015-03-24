using DublinBusinessSchoolCreditUnion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            var cxt = new CustomerContext();

            int customerID = int.Parse(cboCustomers.SelectedValue);

            var customerWithAccounts = (from c in cxt.Customers
                                        join a in cxt.Accounts
                                        on c.CustomerID equals a.CustomerID
                                        where c.CustomerID == customerID
                                        select a.AccountNumber);

            if (customerWithAccounts != null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Customer has open Accounts!')", true);
            }
            else
            {
                cxt.Customers.Remove(cxt.Customers.Where(c => c.CustomerID == customerID).First());
                cxt.SaveChanges();
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
            lblCity.Text = currentCustomer.City;
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
    }
}