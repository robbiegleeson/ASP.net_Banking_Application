using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class LoggedInMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAdmin.Visible = CustomSessionObject.Current.IsAdmin;

            if (lblAdmin.Visible == true)
            {
                lblMyAccount.Visible = false;
            }
               
        }

        protected void lblLogout_Click(object sender, EventArgs e)
        {
            CustomSessionObject.Current.SessionUsername = null;
            CustomSessionObject.Current.LoginStatus = false;
            CustomSessionObject.Current.IsAdmin = false;
            Server.Transfer("Default.aspx");
        }
    }
}