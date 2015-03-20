using DublinBusinessSchoolCreditUnion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            int accNum = int.Parse(txtAccountNumber.Text);

            var _db = new CustomerContext();
            var query = (from c in _db.Customers
                         join a in _db.Accounts
                         on c.CustomerID equals a.CustomerID
                         where a.AccountNumber == accNum && c.Email == txtEmail.Text
                         select c);

            foreach (Customer cust in query)
            {
                if (cust.OnlineCustomer == false)
                {
                    cust.OnlineCustomer = true;
                    cust.UserName = txtUserName.Text;
                    cust.CustomerPassword = txtPassword.Text;

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Unsuccessfully')", true);
                }
            }

            _db.SaveChanges();
        }
    }
}