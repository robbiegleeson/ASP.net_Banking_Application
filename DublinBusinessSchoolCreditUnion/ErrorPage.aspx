<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="DublinBusinessSchoolCreditUnion.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/JSONtransactions.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h2 class="panel-title">Error!</h2>
            </div><!--/panel-heading-->
            <div class="panel-body">
                <p>The webpage you requested is not available at this time, please Log in to access the requested features</p>
            </div><!--/panel-body-->
            <div class="panel-footer">
                
            </div><!--/panel-footer-->
        </div><!--/panel-->
    </div><!--/row-->
</asp:Content>
