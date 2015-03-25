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

            liAdmin.Visible = CustomSessionObject.Current.IsAdmin;

        }

        protected void lblLogout_Click(object sender, EventArgs e)
        {
            
        }

        protected void LOGOUT_Click(object sender, EventArgs e)
        {
            MsgBox("You Have Logged Out", this.Page, this);
            CustomSessionObject.Current.SessionUsername = null;
            CustomSessionObject.Current.LoginStatus = false;
            CustomSessionObject.Current.IsAdmin = false;
            Server.Transfer("Default.aspx");
            
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}