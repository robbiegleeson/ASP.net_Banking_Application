using DublinBusinessSchoolCreditUnion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class LoggedIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();

            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }


            if (!IsPostBack)
            {
                DisplaySessionValue();
                LoadAccountNumber();
                string username = Session["Username"].ToString();

                try
                {
                    var _db = new CustomerContext();
                    var match = (from c in _db.Customers
                                 join a in _db.Accounts on c.CustomerID equals a.CustomerID
                                 where c.UserName == username
                                 select new
                                 {
                                     c.FirstName,
                                     c.Surname,
                                     a.AccountNumber,
                                     c.AddressLine1,
                                     c.AddressLine2,
                                     c.City,
                                     c.County,
                                     c.CustomerID,
                                     a.AccountType,
                                     a.Balance
                                 }).FirstOrDefault();

                    lblName.Text = match.FirstName + " " + match.Surname;
                    lblAccountNumber.Text = match.AccountNumber.ToString();
                    lblAddressLine1.Text = match.AddressLine1;
                    lblAddressLine2.Text = match.AddressLine2;
                    lblCity.Text = match.City;
                    lblCounty.Text = match.County;

                    lblAccountNum.Text = match.AccountNumber.ToString();
                    lblAccountType.Text = match.AccountType;
                    lblAccountBalance.Text = match.Balance.ToString();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            bool success = false;

            int fromAccount, toAccount, amount;
            string description = txtDescription.Text;
            string transType = "Transfer";
            DateTime stamp = DateTime.Now;
            string transRef = "Online Transfer";

            fromAccount = int.Parse(txtFromAccount.Text);
            toAccount = int.Parse(txtToAccount.Text);
            amount = int.Parse(txtAmount.Text);

            try
            {
                Transaction newTransaction = new Transaction();
                newTransaction.TransactionAccountNumber = fromAccount;
                newTransaction.DestinationAccountNumber = toAccount;
                newTransaction.TransactionType = transType;
                newTransaction.TransactionReference = transRef;
                newTransaction.TransactionAmount = amount;
                newTransaction.TransactionDateTime = stamp;
                newTransaction.TransactionDescription = description;

                var _db = new CustomerContext();

                _db.Transactions.Add(newTransaction);
                success = true;
                _db.SaveChanges();

                UpdateBalance();

            }
            catch (Exception ex)
            {

                throw;
            }
            if (success)
            {
                txtFromAccount.Text = string.Empty;
                txtToAccount.Text = string.Empty;
                txtAmount.Text = string.Empty;
            }
        }

        public void LoadAccountNumber()
        {
            string username = Session["Username"].ToString();

            var _db = new CustomerContext();
            var query = (from c in _db.Customers
                         join a in _db.Accounts on c.CustomerID equals a.CustomerID
                         where c.UserName == username
                         select new { a.AccountNumber }).FirstOrDefault();

            txtFromAccount.Text = query.AccountNumber.ToString();
        }

        public void UpdateBalance()
        {
            try
            {
                var db = new CustomerContext();
                int deductAmount = int.Parse(txtAmount.Text);
                int accountNumber = int.Parse(txtFromAccount.Text);

                var query = (from a in db.Accounts
                             where a.AccountNumber == accountNumber
                             select a).First();

                int newBalance = query.Balance - deductAmount;
                query.Balance = newBalance;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            try
            {
                var db = new CustomerContext();
                int addAmount = int.Parse(txtAmount.Text);
                int destinationAccount = int.Parse(txtToAccount.Text);

                var query = (from a in db.Accounts
                             where a.AccountNumber == destinationAccount
                             select a).First();

                int newBalance = query.Balance + addAmount;
                query.Balance = newBalance;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void lblInternalTransfer_Click(object sender, EventArgs e)
        {
            Server.Transfer("Payments.aspx?txtFromAccount=" + txtFromAccount.Text);
        }

        protected void DisplaySessionValue()
        {
            if (Session["Username"] != null)
            {
                lblSessionValue.Text = Convert.ToString(Session["Username"]);
            }
        }
    }
}