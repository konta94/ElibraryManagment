<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="WebApplication1.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row-cols-2">
            <div class="col-md-8 mx-auto">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                            <center>
                                <img width="100" src="images/generaluser.png" />
                            </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                            <center>
                                <h4>User Registration</h4>
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
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textbox_full_name" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textbox_dob" runat="server" placeholder="dd-mm-yy" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Number</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textbox_contact_no" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Email ID</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textbox_email" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="mb-3">
                                    <asp:DropDownList class="form-control" ID="dropdown_state" runat="server">
                                        <asp:ListItem Text="Select" Value="Select" />
                                        <asp:ListItem Text="Croatia" Value="Croatia" />
                                        <asp:ListItem Text="Bosnia and Herzegovina" Value="Bosnia and Herzegovina" />
                                        <asp:ListItem Text="Germany" Value="Germany" />
                                        <asp:ListItem Text="Switzerland" Value="Switzerland" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="textbox_city" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Postal Code</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="textbox_postal" runat="server" placeholder="Postal Code" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-12">
                                <label>Full Adress</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textbox_full_address" runat="server" placeholder="Full Adress" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <center>
                            <div class="col">
                                <span class="badge rounded-pill bg-info mx-auto">Login Credentials</span>
                            </div>
                            </center>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="textbox_memberid" runat="server" placeholder="Member ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Password</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="textbox_password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="mb-3">
                                    <asp:Button style="width:100%" class="btn btn-success btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="click_SignUp" />
                                </div>
                        </div>


                    </div>
                </div>

                <a href="homepage.aspx">&lt&ltBack to Home</a><br /><br />

            </div>
        </div>
    </div>

</asp:Content>
