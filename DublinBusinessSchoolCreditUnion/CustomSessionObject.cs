using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DublinBusinessSchoolCreditUnion
{
    public class CustomSessionObject
    {
        public bool LoginStatus { get; set; }
        public int LoginID { get; set; }
        public string SessionUsername { get; set; }
        public bool IsAdmin { get; set; }

        private CustomSessionObject()
        {
            LoginStatus = false;
        }

        public static CustomSessionObject Current
        {
            get
            {
                CustomSessionObject customerSession = (CustomSessionObject)HttpContext.Current.Session["currentSession"];
                if (customerSession == null)
                {
                    customerSession = new CustomSessionObject();
                    HttpContext.Current.Session["currentSession"] = customerSession;
                }
                return customerSession;
            }
        }
    }
}