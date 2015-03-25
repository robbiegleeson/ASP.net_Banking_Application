using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace DublinBusinessSchoolCreditUnion
{
    public static class FireBugWriter
    {
        public static void Write(string message)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Debug", "<script>console.log('" + message + "');</script>");
        }
    }
}