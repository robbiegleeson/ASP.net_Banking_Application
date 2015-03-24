using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DublinBusinessSchoolCreditUnion
{
    public partial class LoanCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            string loanType = ddlLoanType.SelectedItem.ToString();
            double amountBorrowed = int.Parse(txtAmountToBorrow.Text);
            string repayTerm = ddlRepaymentsTerm.SelectedValue.ToString();
            string loanLength = ddlLengthOfLoan.SelectedValue.ToString();
            double totalInterest, eachRepayment, totalRepayment;
            

            if (loanType == "Student Loan (6.7% APR)" || loanType == "Secured Savings Loan (6.7% APR)" && repayTerm == "1")
            {
                switch (loanLength)
                {
                    case "1":
                        totalInterest = (amountBorrowed * 6.7 / 100) * 365/ 100;
                        eachRepayment = totalInterest / 52;
                        totalRepayment = amountBorrowed + totalInterest;

                        txtTotalInterest.Text = totalInterest.ToString();
                        txtRepaymentAmount.Text = string.Format("{0}", eachRepayment.ToString());
                        txtTotalRepayentAmount.Text = totalRepayment.ToString();
                        break;

                    case "2":
                        totalInterest = (amountBorrowed * 6.7 / 100) * 730/ 100;
                        eachRepayment = totalInterest / 52;
                        totalRepayment = amountBorrowed + totalInterest;

                        txtTotalInterest.Text = totalInterest.ToString();
                        txtRepaymentAmount.Text = string.Format("{0}", eachRepayment.ToString());
                        txtTotalRepayentAmount.Text = totalRepayment.ToString();
                        break;

                    case "3":
                        totalInterest = (amountBorrowed * 6.7 / 100) * 1095 / 100;
                        eachRepayment = totalInterest / 52;
                        totalRepayment = amountBorrowed + totalInterest;

                        txtTotalInterest.Text = totalInterest.ToString();
                        txtRepaymentAmount.Text = string.Format("{0}", eachRepayment.ToString());
                        txtTotalRepayentAmount.Text = totalRepayment.ToString();
                        break;

                    case "4":
                        totalInterest = (amountBorrowed * 6.7 / 100) * 1460 / 100;
                        eachRepayment = totalInterest / 52;
                        totalRepayment = amountBorrowed + totalInterest;

                        txtTotalInterest.Text = totalInterest.ToString();
                        txtRepaymentAmount.Text = string.Format("{0}", eachRepayment.ToString());
                        txtTotalRepayentAmount.Text = totalRepayment.ToString();
                        break;

                    case "5":
                        totalInterest = (amountBorrowed * 6.7 / 100) * 1825 / 100;
                        eachRepayment = totalInterest / 52;
                        totalRepayment = amountBorrowed + totalInterest;

                        txtTotalInterest.Text = totalInterest.ToString();
                        txtRepaymentAmount.Text = string.Format("{0:C}", eachRepayment.ToString());
                        txtTotalRepayentAmount.Text = totalRepayment.ToString();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}