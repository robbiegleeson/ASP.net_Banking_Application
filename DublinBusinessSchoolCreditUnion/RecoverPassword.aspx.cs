using DublinBusinessSchoolCreditUnion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        private readonly string smtpUsername = ConfigurationManager.AppSettings["mailUsername"].ToString();
        private readonly string smtpPassword = ConfigurationManager.AppSettings["mailPassword"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecover_Click(object sender, EventArgs e)
        {
            using (var _db = new CustomerContext())
            {
                try
                {
                    var password = (from p in _db.Customers
                                    where p.UserName == txtUsername.Text && p.Email == txtEmail.Text
                                    select new { p.CustomerPassword }).First();

                    using (MailMessage message = new MailMessage())
                    {
                        message.From = new MailAddress("donotreply@dbscu.ie");
                        message.To.Add(new MailAddress(txtEmail.Text));
                        message.Subject = "Password Recovery";
                        message.Body = "You have recieved this email because you have forgot your password." + Environment.NewLine +
                                       "Your password is " + password.CustomerPassword + Environment.NewLine +
                                       "Please login using this password";
                    }

            
                    
                }
                catch (Exception ex)
                {
                    FireBugWriter.Write(ex.Message);
                }
            }
        }
    
    }
}
