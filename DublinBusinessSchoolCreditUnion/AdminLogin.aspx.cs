using DublinBusinessSchoolCreditUnion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var _db = new CustomerContext();

            User currentUser = (from u in _db.Users
                                where u.UserName == txtUsername.Text && u.UserPassword == txtPassword.Text
                                select u).First();

            if (currentUser.UserName == txtUsername.Text && currentUser.UserPassword == txtPassword.Text)
            {
                CustomSessionObject.Current.SessionUsername = txtUsername.Text.Trim();
                CustomSessionObject.Current.LoginStatus = true;

                if (currentUser.UserName.Equals("admin"))
                {
                    CustomSessionObject.Current.IsAdmin = true;
                    Server.Transfer("Admin.aspx");
                }
                else
                {
                    Server.Transfer("LoggedIn.aspx");
                }
            }
        }
    }
}