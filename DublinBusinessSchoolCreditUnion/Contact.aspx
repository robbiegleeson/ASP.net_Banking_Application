﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DublinBusinessSchoolCreditUnion.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
            <h2 class="form-signin-heading">Contact Us</h2>
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
        </div><!--/col-md-6-->
        <div class="col-md-6">
            
        </div><!--/col-md-6-->
    </div><!--/row-->  
</asp:Content>
