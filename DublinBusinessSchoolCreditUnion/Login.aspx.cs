using DublinBusinessSchoolCreditUnion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var _db = new CustomerContext();
            Customer currentCustomer = (from c in _db.Customers
                         where c.UserName == txtUsername.Text && c.CustomerPassword == txtPassword.Text
                         select c).First();

            if (currentCustomer.UserName == txtUsername.Text && currentCustomer.CustomerPassword == txtPassword.Text)
            {
                CustomSessionObject.Current.SessionUsername = txtUsername.Text.Trim();
                CustomSessionObject.Current.LoginStatus = true;

                if (currentCustomer.UserName.Equals("admin"))
                {
                    CustomSessionObject.Current.IsAdmin = true;
                    Server.Transfer("Admin.aspx");
                }
                else
                    Server.Transfer("LoggedIn.aspx?txtUsername=" + CustomSessionObject.Current.SessionUsername);

                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login Unsuccessful')", true);
                CustomSessionObject.Current.LoginStatus = false;
            }
        }
    }
}