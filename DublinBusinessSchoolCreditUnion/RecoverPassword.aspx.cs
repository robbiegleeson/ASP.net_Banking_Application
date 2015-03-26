using DublinBusinessSchoolCreditUnion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecover_Click(object sender, EventArgs e)
        {
            var _db = new CustomerContext();

            var password = (from p in _db.Customers
                            where p.UserName == txtUsername.Text && p.Email == txtEmail.Text
                            select new {p.CustomerPassword }).First();

            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress("donotreply@dbscu.ie");
                message.To.Add(new MailAddress(txtEmail.Text));
                message.Subject = "Password Recovery";
                message.Body = "You have recieved this email because you have forgot your password." + Environment.NewLine +
                               "Your password is " + password.CustomerPassword + Environment.NewLine +
                               "Please login using this password" + Environment.NewLine + Environment.NewLine +
                               "You're Welcome";

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                //Obviously this needed to be stored in config and encrypted!
                client.Credentials = new NetworkCredential("dbscreditunion", "sqlU5er23");
                client.EnableSsl = true;
                client.Send(message);
            }
        }
    }
}