<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="WebApplication1.userlogin" %>
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
                                <img width="150" src="images/generaluser.png" />
                            </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                            <center>
                                <h3>Member Login</h3>
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
                                <!--<label>Member ID</label>-->
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textbox_userlogin_userid" runat="server" placeholder="Member ID"></asp:TextBox>
                                </div>

                                <!--<label>Password</label>-->
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textbox_userlogin_password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <asp:Button style="width:100%" class="btn btn-success btn-lg" ID="Button1" runat="server" Text="Login" OnClick="userLogin_click" />
                                </div>

                                <div class="mb-3">
                                    <asp:Button style="width:100%" class="btn btn-primary btn-lg" ID="SignUpButton" runat="server" Text="Sign Up" OnClick="UserSignUp_click" />
                                    <!--<a href="usersignup.aspx"><input class="btn btn-info btn-lg" style="width:100%" id="userlogin_SignUpButton" type="button" value="Sign Up" /></a>-->
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
