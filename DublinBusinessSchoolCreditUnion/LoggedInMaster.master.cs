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
            liAdmin.Visible = CustomSessionObject.Current.IsAdmin;
               
        }

        protected void lblLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("Username");
            Server.Transfer("Default.aspx");
        }
    }
}