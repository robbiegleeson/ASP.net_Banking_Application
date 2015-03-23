<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedInMaster.master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="DublinBusinessSchoolCreditUnion.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-2">
            <!--left aside-->
        </div><!--/col-md-2-->
        <div class="panel-group" id="accordion">
            <div class="col-md-4">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">Add Customer</a>
                        </h4><!--/h4-->
                    </div><!--/panel-heading-->
                    <div id="collapse1" class="panel-collapse collapse">
                        <div class="panel-body">
                            <ul>
                                <li><asp:Label ID="lblFname" runat="server">First Name</asp:Label></li>
                                <li><asp:TextBox ID="txtFname" runat="server"></asp:TextBox></li>
                                <li><asp:Label ID="lblLname" runat="server">Last Name</asp:Label></li>
                                <li><asp:TextBox ID="txtLname" runat="server"></asp:TextBox></li>
                                <li><asp:Label ID="lblEmail" runat="server">Email</asp:Label></li>
                                <li><asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox></li>
                                <li><asp:Label ID="lblPhone" runat="server">Phone</asp:Label></li>
                                <li><asp:TextBox ID="txtPhone" runat="server" ></asp:TextBox></li>
                                <li><asp:Label ID="lblAddress1" runat="server">Address Line 1</asp:Label></li>
                                <li><asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox></li>
                                <li><asp:Label ID="lblAddress2" runat="server">Address Line 2</asp:Label></li>
                                <li><asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox></li>
                                <li><asp:Label ID="lblCity" runat="server">City/Town</asp:Label></li>
                                <li><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></li>
                                <li><asp:Label ID="lblCounty" runat="server">County</asp:Label></li>
                                <li><asp:DropDownList ID="cboCounties" runat="server"></asp:DropDownList></li>
                                <li><asp:Button ID="btnAddCustomer" runat="server" Text="Add Customer" OnClick="btnAddCustomer_Click" /></li>
                            </ul>
                        </div><!--/panel-body-->
                    </div><!--/panel-collapse-->
                </div><!--/panel-primary-->
           

                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="collapse2">Delete User</a>
                        </h4>
                    </div><!--/panel-heading-->
                    <div id="collapse2" class="panel panel-collapse">
                        <div class="panel-body">
                            <ul>
                                <li><asp:DropDownList ID="cboCustomers" runat="server"></asp:DropDownList></li>
                                <li><asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /></li>
                            </ul>
                        </div><!--.panel-body-->
                    </div><!--/panel-collapse-->
                </div><!--/panel-primary-->
            </div><!--/col-md-4-->

            <div class="col-md-4">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="collapse3">View User Details</a>
                        </h4>
                    </div><!--/panel-heading-->
                    <div id="collapse3" class="panel panel-collapse">
                        <div class="panel-body">
                            <ul>
                                <li><asp:DropDownList ID="cboViewCustomers" runat="server"></asp:DropDownList></li>
                                <li><asp:Button ID="btnView" runat="server" Text="Delete" OnClick="btnView_Click" /></li>
                                <li><asp:Label ID="lblDisplayFname" runat="server"></asp:Label></li>
                                <li><asp:Label ID="lblDisplayLname" runat="server"></asp:Label></li>
                                <li><asp:Label ID="lblDisplayEmail" runat="server"></asp:Label></li>
                                <li><asp:Label ID="lblDisplayPhone" runat="server"></asp:Label></li>
                                <li><asp:Label ID="lblDisplayAddress1" runat="server"></asp:Label></li>
                                <li><asp:Label ID="lblDisplayAddress2" runat="server"></asp:Label></li>
                                <li><asp:Label ID="lblDisplayCity" runat="server"></asp:Label></li>
                                <li><asp:Label ID="lblDisplayCounty" runat="server"></asp:Label></li>
                            </ul>
                        </div><!--panel-body-->
                    </div><!--/panel-collapse-->
                </div><!--/panel-primary-->

                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="collapse4">Close Accounts</a>
                        </h4>
                    </div><!--/panel-heading-->
                    <div id="collapse4" class="panel panel-collapse">
                        <div class="panel-body">
                            <ul>
                                <li><asp:DropDownList ID="cboCustomerDetails" runat="server"></asp:DropDownList></li>
                                <li><asp:DropDownList ID="cboAccounts" runat="server"></asp:DropDownList></li>
                                <li><asp:Button ID="btnCloseAccount" runat="server" Text="Close Account" /></li>
                            </ul>
                        </div><!--/panel-body-->
                    </div><!--/panel-collapse-->
                </div><!--/panel-primary-->
            </div><!--/col-md-4-->
            </div>
        <div class="col-md-2">
            <!--right aside-->
        </div><!--/col-md-2-->
    </div>
</asp:Content>
