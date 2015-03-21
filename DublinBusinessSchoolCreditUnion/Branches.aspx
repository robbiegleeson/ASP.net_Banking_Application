<%@ Page Title="Find Us" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="Branches.aspx.cs" Inherits="DublinBusinessSchoolCreditUnion.Branches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://maps.googleapis.com/maps/api/js"></script>
    <script src="Scripts/branchmap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>Locations</h4>
                </div><!--/panel-heading-->
                <div class="panel-body">
                    <asp:ListView ID="branches" runat="server" DataKeyNames="BranchId" ItemType="DublinBusinessSchoolCreditUnion.Models.Branch" SelectMethod="GetBranches">
                        <ItemTemplate>
                            <table id="branchList">
                                <tr>
                                    <td><strong><%#: Item.BranchLocation %></strong></td>
                                </tr>
                                <tr>
                                    <td><%#: Item.Email %></td>
                                </tr>
                                <tr>
                                    <td><%#: Item.Phone %></td>
                                </tr>
                                
                            </table>
                        </ItemTemplate>
                    </asp:ListView>
                </div><!--/panel-body-->
                <div class="panel-footer">

                </div><!--/panel-footer-->
            </div><!--/panel-->
        </div><!--/col-md-6-->
        
        <div class="col-md-6"">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>Find Us</h4>
                </div><!--/panel-heading-->
                <div id="canvas">
                    <!--This Div will contain the map for the branch loactor (google maps API)-->
                </div><!--/canvas-->
                <div id="map-panel-footer" class="panel-footer">

                </div>
            </div><!--/panel-->
        </div><!--/col-md-6-->
    </div><!--/row-->
</asp:Content>
