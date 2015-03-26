using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class Contact : System.Web.UI.Page
    {
        private readonly string smtpUsername = ConfigurationManager.AppSettings["mailUsername"].ToString();
        private readonly string smtpPassword = ConfigurationManager.AppSettings["mailPassword"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cboSubjects.Items.Add("General Query");
                cboSubjects.Items.Add("Loans");
                cboSubjects.Items.Add("Accounts and Savings");
                cboSubjects.Items.Add("Jobs and Opportunities");
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            using (MailMessage message = new MailMessage())
            {
                try
                {
                    message.From = new MailAddress(txtEmail.Text);
                    message.To.Add(new MailAddress("dbscreditunion@gmail.com"));
                    message.Subject = cboSubjects.SelectedItem.ToString() + " From: " + txtName.Text;
                    message.Body = "Message from: " + txtName.Text + Environment.NewLine +
                        "Email: " + txtEmail.Text + Environment.NewLine +
                        "Phone: " + txtPhone.Text + Environment.NewLine +
                        "Message: " + Environment.NewLine + txtMessage.Text;

                    using (SmtpClient client = new SmtpClient())
                    {
                        client.UseDefaultCredentials = false;
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                        client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                        client.EnableSsl = true;
                        try
                        {
                            client.Send(message);
                        }
                        catch (SmtpException ex)
                        {
                            FireBugWriter.Write(ex.Message);
                        }
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