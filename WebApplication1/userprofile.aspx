<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="WebApplication1.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('#myTable').DataTable();//
        });
    </script>
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
                                <asp:Label class="badge rounded-pill bg-info" ID="Label_AccountStatus" runat="server" Text="Your status"></asp:Label>
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
                                    <asp:TextBox CssClass="form-control" ID="TextBox_FullName" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox_Date" runat="server" placeholder="dd-mm-yy" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Number</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox_ContactNumber" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Email ID</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox_Email" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="mb-3">
                                    <asp:DropDownList class="form-control" ID="DropDownList_Country" runat="server">
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
                                    <asp:TextBox class="form-control" ID="TextBox_City" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Postal Code</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox_PostalCode" runat="server" placeholder="Postal Code" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-12">
                                <label>Full Adress</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox_FullAddress" runat="server" placeholder="Full Adress" TextMode="MultiLine" Rows="2"></asp:TextBox>
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
                                    <asp:TextBox class="form-control" ID="TextBox_UserId" runat="server" placeholder="User ID" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Password</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox_OldPw" runat="server" placeholder="Old password" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>New password</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox_NewPw" runat="server" placeholder="New password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row justify-content-md-center">
                            <div class="col-md-auto">
                                <asp:Button class="btn btn-primary btn-lg" ID="Button_Update" runat="server" Text="Update" OnClick="Button_Update_Click" />
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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView_Profile" runat="server" OnRowDataBound="GridView_Profile_RowDataBound"></asp:GridView>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
