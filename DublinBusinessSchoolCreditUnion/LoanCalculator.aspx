<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedInMaster.master" AutoEventWireup="true" CodeBehind="LoanCalculator.aspx.cs" Inherits="DublinBusinessSchoolCreditUnion.LoanCalculator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">Loan Calculator</div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">Amount to Borrow</div>
                        <div class="panel-body">
                            <ul class="LoanCalculator">
                                <li>
                                    <asp:Label ID="lblLoanType" runat="server">Type of Loan: </asp:Label></li>
                                <li>
                                    <asp:DropDownList ID="ddlLoanType" runat="server" Width="245px">
                                        <asp:ListItem Enabled="true" Text="Select Loan Type" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Student Loan (6.7% APR)" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Student Car Loan (8.19% APR)" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Secured Savings Loan (6.7% APR)" Value="3"></asp:ListItem>
                                    </asp:DropDownList></li>
                                <li>
                                    <asp:Label ID="lblLoanAmount" runat="server">Amount to Borrow: </asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtAmountToBorrow" runat="server" Columns="31" Width="245px"></asp:TextBox></li>
                                <li>
                                    <asp:Label ID="lblRepayments" runat="server">Repayment Term: </asp:Label></li>
                                <li>
                                    <asp:DropDownList ID="ddlRepaymentsTerm" runat="server" Width="245px">
                                        <asp:ListItem Enabled="true" Text="Select Repayments Term" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Weekly" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Fortnightly" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Monthly" Value="3"></asp:ListItem>
                                    </asp:DropDownList></li>
                                <li>
                                    <asp:Label ID="lblLengthOfLoan" runat="server">Length of Loan: </asp:Label></li>
                                <li>
                                    <asp:DropDownList ID="ddlLengthOfLoan" runat="server" Width="245px">
                                        <asp:ListItem Enabled="true" Text="Select Length of Loan" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="1 Year" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2 Years" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3 Years" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4 Years" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5 Years" Value="5"></asp:ListItem>
                                    </asp:DropDownList></li>
                            </ul>
                        </div>
                            </div>
                    </div>
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">Repayments</div>
                        <div class="panel-body">
                            <ul class="LoanCalculator">
                                <li>
                                    <asp:Label ID="lblRepaymentAmount" runat="server">Amount of Each Repayment:</asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtRepaymentAmount" runat="server" Enabled="false" Width="245px"></asp:TextBox></li>
                                <li>
                                    <asp:Label ID="lblTotalRepayment" runat="server">Amount of Total Repayment:</asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtTotalRepayentAmount" runat="server" Enabled="false" Width="245"></asp:TextBox></li>
                                <li>
                                    <asp:Label ID="lblTotalInterest" runat="server">Amount of Total Interest:</asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtTotalInterest" runat="server" Enabled="false" Width="245"></asp:TextBox></li>
                                <li>
                                    <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" /></li>
                            </ul>
                        </div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
