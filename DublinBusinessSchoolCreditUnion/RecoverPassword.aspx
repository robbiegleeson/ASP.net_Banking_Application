<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="DublinBusinessSchoolCreditUnion.RecoverPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-3">

        </div><!--/col3-->
        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Recover Password
                </div>
                <div class="panel-body">
                    <ul>
                        <li><asp:Label ID="lblUsername" runat="server">Username: </asp:Label></li>
                        <li><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></li>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Incorrect Username Format" ControlToValidate="txtUsername" ValidationExpression="[A-Za-z0-9]{5,}" Display="Dynamic"></asp:RegularExpressionValidator>
                        <li><asp:Label ID="lblEmail" runat="server">E-Mail Address: </asp:Label></li>
                        <li><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></li>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Incorrect Email Format" ControlToValidate="txtEmail" ValidationExpression="^\S+@\S+$" Display="Dynamic"></asp:RegularExpressionValidator>
                        <li><asp:Button ID="btnRecover" runat="server" Text="Recover Password" OnClick="btnRecover_Click" /></li>
                    </ul>

                </div>
            </div>
        </div><!--/col6-->
        <div class="col-md-3">

        </div><!--/col3-->
    </div>
</asp:Content>

