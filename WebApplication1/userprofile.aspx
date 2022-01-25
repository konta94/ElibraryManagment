<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="WebApplication1.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">

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
                                <h4>Your Profile</h4>
                                <span>Account Status - </span>
                                <asp:Label class="badge rounded-pill bg-info" ID="Label1" runat="server" Text="Your status"></asp:Label>
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
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="dd-mm-yy" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Number</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Email ID</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="mb-3">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
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
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Postal Code</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Postal Code" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-12">
                                <label>Full Adress</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Full Adress" TextMode="MultiLine" Rows="2"></asp:TextBox>
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
                            <div class="col-md-4">
                                <label>User ID</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="User ID" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Password</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Old password" TextMode="Password" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>New password</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="New password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row justify-content-md-center">
                            <div class="col-md-auto">
                                <asp:Button class="btn btn-primary btn-lg" ID="Button1" runat="server" Text="Update" />
                            </div>
                        </div>



                    </div>
                </div>

                <a href="homepage.aspx">&lt&ltBack to Home</a><br /><br />

            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                            <center>
                                <img width="100" src="images/books1.png" />
                            </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                            <center>
                                <h4>Your Issued Books</h4>
                                <asp:Label class="badge rounded-pill bg-info" ID="Label2" runat="server" Text="Your books info"></asp:Label>
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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
