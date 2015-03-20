<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedInMaster.master" AutoEventWireup="true" CodeBehind="LoggedIn.aspx.cs" Inherits="DublinBusinessSchoolCreditUnion.LoggedIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div class="panel-group" id="accordion">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">Customer Details</a>
                        </h4>
                    </div>
                    <div id="collapse1" class="panel-collapse collapse in">
                    <div class="panel-body">
                        <ul>
                            <li>
                                <asp:Label ID="lblName" runat="server"></asp:Label></li>
                            <li>
                                <asp:Label ID="lblAccountNumber" runat="server"></asp:Label></li>
                            <li>
                                <asp:Label ID="lblAddressLine1" runat="server"></asp:Label></li>
                            <li>
                                <asp:Label ID="lblAddressLine2" runat="server"></asp:Label></li>
                            <li>
                                <asp:Label ID="lblCity" runat="server"></asp:Label></li>
                            <li>
                                <asp:Label ID="lblCounty" runat="server"></asp:Label></li>
                        </ul>
                    </div>
                    </div>
                </div>
            
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">Payments</a>
                        </h4>
                    </div>
                <div id="collapse2" class="panel-collapse collapse in">
                <div class="panel-body">
                    <ul>
                        <li>
                            <asp:LinkButton ID="lblInternalTransfer" runat="server" Text="Make Internal Transfer" OnClick="lblInternalTransfer_Click"></asp:LinkButton></li>
                        <li>
                            <asp:Label ID="lblExternalTransfer" runat="server">Make External Transfer</asp:Label></li>
                        <li>
                            <asp:Label ID="lblSessionValue" runat="server"></asp:Label></li>
                    </ul>
                </div>
                    </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">Quick Transfer</a>
                        </h4>
                    </div>
                <div id="collapse3" class="panel-collapse collapse in">
                <div class="panel-body">
                    <ul>
                        <li>
                            <asp:Label ID="lblFromAccount" runat="server">From Account:</asp:Label></li>
                        <li>
                            <asp:TextBox ID="txtFromAccount" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox></li>
                        <li>
                            <asp:Label ID="lblToAccount" runat="server">To Account</asp:Label></li>
                        <li>
                            <asp:TextBox ID="txtToAccount" runat="server"></asp:TextBox></li>
                        <li>
                            <asp:Label ID="lblAmount" runat="server">Amount</asp:Label></li>
                        <li>
                            <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></li>
                        <li>
                            <asp:Label ID="lblDescription" runat="server">Description</asp:Label></li>
                        <li>
                            <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server"></asp:TextBox></li>
                        <li>
                            <asp:Button ID="btnTransfer" runat="server" Text="Transfer" OnClick="btnTransfer_Click" /></li>
                    </ul>
                </div>
                    </div>
            </div>
        </div>
            </div>
    
    <div class="col-md-9">
        <div class="panel panel-primary">
            <div class="panel-heading">Account Details</div>
            <div class="panel-body">
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>
                                <asp:Label ID="lblAccountNumberHeader" runat="server">Account Number</asp:Label></th>
                            <th>
                                <asp:Label ID="lblAccountTypeHeader" runat="server">Account Type</asp:Label></th>
                            <th>
                                <asp:Label ID="lblAccountBalanceHeader" runat="server">Account Balance</asp:Label></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="lblAccountNum" runat="server"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblAccountType" runat="server"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblAccountBalance" runat="server"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
