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
            var query = (from c in _db.Customers
                         where c.UserName == txtUsername.Text && c.CustomerPassword == txtPassword.Text
                         select c);

            foreach (Customer cust in query)
            {
                if (cust.UserName == txtUsername.Text && cust.CustomerPassword == txtPassword.Text)
                {
                    CustomSessionObject.Current.SessionUsername = txtUsername.Text.Trim();
                    Server.Transfer("LoggedIn.aspx?txtUsername=" + txtUsername.Text);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login Unsuccessful')", true);
                }
            }
        }
    }
}