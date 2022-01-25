<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="WebApplication1.homepage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- JAVASCRIPT HERE-->
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section>
        <img src="images/home-bg.jpg" class="img-fluid" />
    </section>

    <section>

        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Our Features</h2>
                        <p><b>Our 3 Primary Features</b></p>
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <center>
                        <img width="150" src="images/digital-inventory.png" />
                        <h4>Digital Book Inventory</h4>
                        <p class="text-justify">Description description description description description description description description description description description...</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <img width="150" src="images/search-online.png" />
                        <h4>Search Books</h4>
                        <p class="text-justify">Description description description description description description description description description description description...</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <img width="150" src="images/defaulters-list.png" />
                        <h4>Defaulter List</h4>
                        <p class="text-justify">Description description description description description description description description description description description...</p>
                    </center>
                </div>
            </div>
        </div>

    </section>

    <section>
        <img class="img-fluid" src="images/in-homepage-banner.jpg" />
    </section>

     <section>

        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Our Process</h2>
                        <p><b>We have a Simple 3 Step Process</b></p>
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <center>
                        <img width="150" src="images/sign-up.png" />
                        <h4>Sign Up</h4>
                        <p class="text-justify">Description description description description description description description description description description description...</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <img width="150" src="images/search-online.png" />
                        <h4>Search Books</h4>
                        <p class="text-justify">Description description description description description description description description description description description...</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <img width="150" src="images/library.png" />
                        <h4>Visit Us</h4>
                        <p class="text-justify">Description description description description description description description description description description description...</p>
                    </center>
                </div>
            </div>
        </div>

    </section>
</asp:Content>
