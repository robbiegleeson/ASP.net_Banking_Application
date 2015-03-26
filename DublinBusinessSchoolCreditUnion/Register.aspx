<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DublinBusinessSchoolCreditUnion.Register" %>
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
                        <div class="panel-heading">REGISTER</div>
                        <div class="panel-body">
                            <ul>
                                <li>
                                    <asp:Label ID="lblAccountNumber" runat="server">Account Number</asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtAccountNumber" runat="server"></asp:TextBox></li>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please enter a 8 digit Account Number" ControlToValidate="txtAccountNumber" ValidationExpression="^(?!\s*$)[0-9\s]{8}$" Display="Dynamic"></asp:RegularExpressionValidator>
                                <li>
                                    <asp:Label ID="lblEmail" runat="server">E-Mail Address</asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox></li>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Incorrect Email Format" ControlToValidate="txtEmail" ValidationExpression="^\S+@\S+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                <li>
                                    <asp:Label ID="lblUsername" runat="server">Username</asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></li>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Incorrect Username Format" ControlToValidate="txtUsername" ValidationExpression="[A-Za-z0-9]{5,}" Display="Dynamic"></asp:RegularExpressionValidator>
                                <li>
                                    <asp:Label ID="lblPassword" runat="server">Password</asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></li>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Incorrect Password Format" ControlToValidate="txtPassword" ValidationExpression="^(?=.*\d).{4,}$" Display="Dynamic"></asp:RegularExpressionValidator>
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
