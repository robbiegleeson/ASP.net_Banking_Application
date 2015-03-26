<%@ Page Title="DBSCU | Contact" MetaKeywords="Credit Union, Internet Banking, Dublin Business School, Loans, Savings" MetaDescription="Send us your question and we'll get back to you as soon as possible" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DublinBusinessSchoolCreditUnion.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-3">

        </div>
        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
            <h4 class="form-signin-heading">Contact Us</h4>
                    </div><!--/panel-heading-->
                <div class="panel-body">
            <div class="form-signin">
                <label for="txtName" class="sr-only">Name</label>
                <asp:Textbox ID="txtName" CssClass="form-control" runat="server" placeholder="Name"  />

                <label for="txtEmail" class="sr-only">Email</label>
                <asp:Textbox TextMode="Email" ID="txtEmail" CssClass="form-control" runat="server" placeholder="Email" />

                <label for="txtPhone" class="sr-only">Phone</label>
                <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" placeholder="Phone" />

                <label for="cboSubjects" class="sr-only">Subject</label>
                <asp:DropDownList ID="cboSubjects" CssClass="form-control" runat="server" placeholder="Subject" />

                <label for="txtMessage" class="sr-only">Message</label>
                <asp:TextBox ID="txtMessage" TextMode="MultiLine" runat="server" placeholder="Enter Message..." CssClass="form-control" />
        
                <asp:Button ID="btnSend" runat="server" CssClass="btn btn-lg btn-primary btn-block" Text="Send" onClick="btnSend_Click" />
            </div><!--/form-->
                    </div><!--/panel-body-->
                </div><!--/panel-primary-->
        </div><!--/col-md-6-->
        <div class="col-md-6">
            
        </div><!--/col-md-6-->
    </div><!--/row-->  
</asp:Content>
