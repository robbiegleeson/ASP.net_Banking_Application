<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedInMaster.master" AutoEventWireup="true" CodeBehind="Payments.aspx.cs" Inherits="DublinBusinessSchoolCreditUnion.Payments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">Internal Transfer</a>
                    </h4>
                </div>
                <div id="collapse1" class="panel-collapse collapse in">
                    <div class="panel-body">
                        <table class="table table-stripped">
                            <thead>
                                <tr>
                                    <th>My Account Number</th>
                                    <th>To Account</th>
                                    <th>Amount</th>
                                    <th>Reference</th>
                                    <th>Description</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtAccountNumber" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtToAccountNumber" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtReference" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:Button ID="btnTransfer" runat="server" Text="Transfer" OnClick="btnTransfer_Click" />
                        <asp:Button ID="btnHome" runat="server" Text="Back" OnClick="btnHome_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">External Transfer</a>
                        </h4>
                </div>
                <div id="collapse2" class="panel-collapse collapse">
                <div class="panel-body">
                    <table class="table table-stripped">
                        <thead>
                            <tr>
                                <th>My Account Number</th>
                                <th>To Account</th>
                                <th>Amount</th>
                                <th>Reference</th>
                                <th>Description</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtExtAccountNumber" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtExterToAccountNumber" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtExterAmount" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtExterReference" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtExterDescription" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:Button ID="btnExterTransfer" runat="server" Text="Transfer" />
                    <asp:Button ID="btnExterHome" runat="server" Text="Back" OnClick="btnHome_Click" />
                </div>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
