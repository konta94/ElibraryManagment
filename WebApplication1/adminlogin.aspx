<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="WebApplication1.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row-cols-2">
            <div class="col-md-6 mx-auto">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                            <center>
                                <img width="150" src="images/adminuser.png" />
                            </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                            <center>
                                <h3>Admin Login</h3>
                            </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                            <center>
                                <hr />
                            </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <!--<label>Admin ID</label>-->
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textbox_adminlogin_userid" runat="server" placeholder="Admin ID"></asp:TextBox>
                                </div>

                                <!--<label>Password</label>-->
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textbox_adminlogin_password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <asp:Button style="width:100%" class="btn btn-success btn-lg" ID="Button1" runat="server" Text="Login" OnClick="adminLogin_Click" />
                                </div>


                            </div>
                        </div>
                    </div>
                </div>

                <a href="homepage.aspx">&lt&ltBack to Home</a><br /><br />

            </div>
        </div>
    </div>

</asp:Content>
