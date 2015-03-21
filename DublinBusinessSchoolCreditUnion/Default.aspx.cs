using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_OnPreInit(object sender, EventArgs e)
        {
            base.OnPreInit(e);
            if (CustomSessionObject.Current.LoginStatus)
                this.MasterPageFile = "LoggedInMaster.Master";
            else
                this.MasterPageFile = "Main.Master";
        }
    }
}