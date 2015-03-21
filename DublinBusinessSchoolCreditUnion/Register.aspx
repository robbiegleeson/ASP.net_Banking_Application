<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DublinBusinessSchoolCreditUnion.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section>
        <article>
            <div class="row">
                <div class="col-md-3">
                </div>
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">REGISTER</div>
                        <div class="panel-body">
                            <ul>
                                <li>
                                    <asp:Label ID="lblAccountNumber" runat="server">Account Number</asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtAccountNumber" runat="server"></asp:TextBox></li>
                                <li>
                                    <asp:Label ID="lblEmail" runat="server">E-Mail Address</asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox></li>

                                <li>
                                    <asp:Label ID="lblUsername" runat="server">Username</asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></li>
                                <li>
                                    <asp:Label ID="lblPassword" runat="server">Password</asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></li>
                                <li>
                                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </article>
    </section>
</asp:Content>
