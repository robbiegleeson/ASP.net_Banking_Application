﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lblLogout_Click(object sender, EventArgs e)
        {
            CustomSessionObject.Current.IsAdmin = false;
            CustomSessionObject.Current.LoginStatus = false;
            Session.Remove("Username");
            Response.Redirect("Default.aspx");
        }
    }
}