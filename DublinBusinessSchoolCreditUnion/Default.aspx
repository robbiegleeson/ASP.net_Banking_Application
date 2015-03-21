<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DublinBusinessSchoolCreditUnion.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="main_img">
        <div class="row">
            <div class="col-md-9 col-sm-9 col-xs-9">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-target="myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="myCarousel" data-slide-to="1"></li>
                        <li data-target="myCarousel" data-slide-to="2"></li>
                        <li data-target="myCarousel" data-slide-to="3"></li>
                    </ol>
                    <div class="carousel-inner" role="listbox">
                        <div class="item active">
                            <img src="Images/carLoan.jpg" alt="CarLoans" />
                        </div>
                        <div class="item">
                            <img src="Images/HolidayLoan.jpg" alt="HolidayLoans" />
                        </div>
                        <div class="item">
                            <img src="Images/HomeLoan.PNG" alt="HomeLoan" />
                        </div>
                        <div class="item">
                            <img src="Images/holidayloans kids.jpg" alt="KidsLoans" />
                        </div>
                    </div>
                    <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-3 col-xs-3">

            </div>
        </div>
    </section>
</asp:Content>
