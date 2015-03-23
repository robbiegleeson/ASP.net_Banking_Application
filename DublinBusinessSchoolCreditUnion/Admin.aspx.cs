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
            //clear lists on load
            PrimeCustomerDropdowns();
            PrimeAccountDropDown();
            cboCounties.DataSource = Enum.GetValues(typeof(Counties));
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer();
            PrimeCustomerDropdowns();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveCustomer();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {

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

    }
}