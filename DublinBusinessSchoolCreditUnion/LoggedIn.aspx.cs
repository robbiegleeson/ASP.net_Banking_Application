using DublinBusinessSchoolCreditUnion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;



namespace DublinBusinessSchoolCreditUnion
{
    public partial class LoggedIn : System.Web.UI.Page
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
                DisplaySessionValue();
                LoadAccountNumber();
                string username = CustomSessionObject.Current.SessionUsername;


                using (var _db = new CustomerContext())
                {
                    try
                    {
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
                        lblAccountBalance.Text = CurrencyFormat(match.Balance);
                    }
                    catch (Exception ex)
                    {
                        FireBugWriter.Write(ex.Message);
                        throw;
                    }
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

            
                Transaction newTransaction = new Transaction();
                newTransaction.TransactionAccountNumber = fromAccount;
                newTransaction.DestinationAccountNumber = toAccount;
                newTransaction.TransactionType = transType;
                newTransaction.TransactionReference = transRef;
                newTransaction.TransactionAmount = amount;
                newTransaction.TransactionDateTime = stamp;
                newTransaction.TransactionDescription = description;

                using (var _db = new CustomerContext())
                {
                    try
                    {
                        _db.Transactions.Add(newTransaction);
                        success = true;
                        _db.SaveChanges();
                        UpdateBalance();

                        if (success)
                        {
                            txtFromAccount.Text = string.Empty;
                            txtToAccount.Text = string.Empty;
                            txtAmount.Text = string.Empty;
                        }
                    }
                    catch (Exception ex)
                    {
                        FireBugWriter.Write(ex.Message);
                        throw ex;
                    }
                }
        }

        public void LoadAccountNumber()
        {
            string username = CustomSessionObject.Current.SessionUsername;

            using (var _db = new CustomerContext())
            {
                try
                {
                    var query = (from c in _db.Customers
                                 join a in _db.Accounts on c.CustomerID equals a.CustomerID
                                 where c.UserName == username
                                 select new { a.AccountNumber }).FirstOrDefault();
                    txtFromAccount.Text = query.AccountNumber.ToString();
                }
                catch (Exception ex)
                {
                    FireBugWriter.Write(ex.Message);
                    throw ex;
                }
            }
        }

        public void UpdateBalance()
        {
            using (var db = new CustomerContext())
            {
                try
                {
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
                    FireBugWriter.Write(ex.Message);
                    throw ex;
                }
            }

            using (var db = new CustomerContext())
            {
                int addAmount = int.Parse(txtAmount.Text);
                int destinationAccount = int.Parse(txtToAccount.Text);
                try
                {
                    var query = (from a in db.Accounts
                                 where a.AccountNumber == destinationAccount
                                 select a).First();

                    int newBalance = query.Balance + addAmount;
                    query.Balance = newBalance;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    FireBugWriter.Write(ex.Message);
                    throw ex;
                }
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void lblInternalTransfer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payments.aspx?txtFromAccount=" + txtFromAccount.Text, true);
        }

        protected void DisplaySessionValue()
        {
            if (CustomSessionObject.Current.SessionUsername != null)
            {
                lblSessionValue.Text = CustomSessionObject.Current.SessionUsername;
            }
        }

        public static List<Transaction> GetTransactions()
        {
            using (var _db = new CustomerContext())
            {
                try
                {
                    var query = (from t in _db.Transactions
                                 join a in _db.Accounts on t.TransactionAccountNumber equals a.AccountNumber
                                 join c in _db.Customers on a.CustomerID equals c.CustomerID
                                 where c.CustomerID == a.CustomerID
                                 select t).ToList();

                    return query.ToList();
                }
                catch (Exception ex)
                {
                    FireBugWriter.Write(ex.Message);
                    throw ex;
                }
            }
        }

        string CurrencyFormat(int valueInCents)
        {
            double convertedValue = (double)valueInCents / 100;
            string currencyFormat = string.Format("{0:C}", convertedValue);
            return currencyFormat;
        }

        protected void lblLoanCalculator_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoanCalculator.aspx", true);
        }
    }
}