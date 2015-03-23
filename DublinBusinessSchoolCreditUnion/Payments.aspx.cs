using DublinBusinessSchoolCreditUnion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class Payments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();

            if (CustomSessionObject.Current.SessionUsername == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadAccountNumber();
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

            fromAccount = int.Parse(txtAccountNumber.Text);
            toAccount = int.Parse(txtToAccountNumber.Text);
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
            }
            catch(Exception ex)
            {
                throw ex;
            }

            try
            {
                var db = new CustomerContext();
                int deductAmount = int.Parse(txtAmount.Text);
                int accountNumber = int.Parse(txtAccountNumber.Text);

                var query = (from a in db.Accounts
                             where a.AccountNumber == accountNumber
                             select a).First();

                int newBalance = query.Balance - deductAmount;
                query.Balance = newBalance;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                var db = new CustomerContext();
                int addAmount = int.Parse(txtAmount.Text);
                int destinationAccount = int.Parse(txtToAccountNumber.Text);

                var query = (from a in db.Accounts
                             where a.AccountNumber == destinationAccount
                             select a).First();

                int newBalance = query.Balance + addAmount;
                query.Balance = newBalance;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (success)
            {
                txtAmount.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtReference.Text = string.Empty;
                txtToAccountNumber.Text = string.Empty;
            }
        }



        public void LoadAccountNumber()
        {
            string username = CustomSessionObject.Current.SessionUsername;

            var _db = new CustomerContext();
            var query = (from c in _db.Customers
                         join a in _db.Accounts on c.CustomerID equals a.CustomerID
                         where c.UserName == username
                         select new { a.AccountNumber }).FirstOrDefault();

            txtAccountNumber.Text = query.AccountNumber.ToString();
            txtExtAccountNumber.Text = query.AccountNumber.ToString();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Server.Transfer("LoggedIn.aspx");
        }
    }
}