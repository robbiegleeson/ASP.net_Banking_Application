<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DublinBusinessSchoolCreditUnion.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <article>
            <div class="row">
                <div class="col-md-3">
                </div>
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">LOGIN</div>
                        <div class="panel-body">
                            <ul>
                                <li>
                                    <asp:Label ID="lblUsername" runat="server">Username</asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></li>
                                <li>
                                    <asp:Label ID="lblPassword" runat="server">Password</asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></li>
                                <li>
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></li>
                                <li><asp:Label ID="lblNotRegistered" runat="server">Not Registered? Get Going <a href="Register.aspx">Here</a></asp:Label></li>
                                <li><asp:Label ID="lblRecoverPassword" runat="server">Forgotten Password? Click <a href="RecoverPassword.aspx">Here</a></asp:Label></li>
                                <li><asp:Label ID="lblAdminLogin" runat="server">Admin Users Login <a href="AdminLogin.aspx">Here</a></asp:Label></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                </div>
            </div>
        </article>
    </section>
</asp:Content>
