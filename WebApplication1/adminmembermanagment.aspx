<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagment.aspx.cs" Inherits="WebApplication1.adminmembermanagment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('#myTable').DataTable();
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
                                <h4>Member Details</h4>
                            </center>
                            </div>
                        </div>

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
                                <hr />
                            </center>
                            </div>
                        </div>
                        <div class="row">
                        <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="mb-3">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="textBox_memberid" runat="server" placeholder="Member ID"></asp:TextBox>
                                        <asp:LinkButton class="btn btn-primary" ID="Button_GO" runat="server" OnClick="Button_GO_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ReadOnly="true" ID="textBox_fullname" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="mb-3">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control me-1" ID="textBox_accountstatus" runat="server" ReadOnly="true" placeholder="Account Status"></asp:TextBox>
                                        <asp:LinkButton class="btn btn-success me-1" ID="Button_Active" runat="server" OnClick="Button_Active_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                        <asp:LinkButton class="btn btn-warning me-1" ID="Button_Pending" runat="server" OnClick="Button_Pending_Click"><i class="far fa-pause-circle"></i></asp:LinkButton>
                                        <asp:LinkButton class="btn btn-danger" ID="Button_Deactive" runat="server" OnClick="Button_Deactive_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-3">
                                <label>DOB</label>
                                <div class="mb-3">
                                        <asp:TextBox CssClass="form-control" ID="textBox_dob" runat="server" placeholder="DOB" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                            <div class="col-md-4">
                                <label>Contact Number</label>
                                <div class="mb-3">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="textBox_contact" runat="server" placeholder="Contact Number" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-5">
                                <label>Email ID</label>
                                <div class="mb-3">
                                        <asp:TextBox CssClass="form-control" ID="textBox_email" runat="server" placeholder="Email ID" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="mb-3">
                                        <asp:TextBox CssClass="form-control" ID="textBox_state" runat="server" placeholder="State" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="mb-3">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="textBox_city" runat="server" placeholder="City" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Postal Code</label>
                                <div class="mb-3">
                                        <asp:TextBox CssClass="form-control" ID="textBox_postalcode" runat="server" placeholder="Postal Code" ReadOnly="True"></asp:TextBox>
                                    </div>
                                
                            </div>
                        </div>




                        <div class="row">
                            <div class="col-12">
                                <label>Full Postal Address</label>
                                <div class="mb-3">
                                        <asp:TextBox CssClass="form-control" ID="textBox_fulladdress" runat="server" ReadOnly="true" placeholder="Full Postal Address" Rows="2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                            </div>
                            </div>

                        <div class="row justify-content-center">
                            <div class="col-8 text-center">
                                <asp:Button class="btn btn-danger btn-lg" ID="button_DeleteUser" runat="server" Text="Delete User Permanently" OnClick="button_DeleteUser_Click" />
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
                                <h4>Members List</h4>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView_MemberList" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
