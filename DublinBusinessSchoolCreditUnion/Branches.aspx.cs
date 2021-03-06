﻿using DublinBusinessSchoolCreditUnion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class Branches : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (CustomSessionObject.Current.LoginStatus)
                this.MasterPageFile = "LoggedInMaster.master";
            else
                this.MasterPageFile = "Main.master";
        }

        public IQueryable<Branch> GetBranches()
        {
            IQueryable<Branch> query = null;
            var cxt = new CustomerContext();
            try
            {
                query = cxt.Branches;
            }
            catch (Exception ex)
            {
                FireBugWriter.Write(ex.Message);
            }

            return query;
        }
    }
}