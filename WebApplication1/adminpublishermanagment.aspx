<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagment.aspx.cs" Inherits="WebApplication1.adminpublishermanagment" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('#myTable').DataTable();//
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="container">
        <div class="row">
            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                            <center>
                                <h4>Publisher Details</h4>
                            </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                            <center>
                                <img width="100" src="images/publisher.png" />
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
                            <div class="col-md-4">
                                <label>Publisher ID</label>
                                <div class="mb-3">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="textBox_publisherid" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button_GO" runat="server" Text="GO" OnClick="Button_GO_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Publisher Name</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textBox_publishername" runat="server" placeholder="Publisher Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row justify-content-md-center">
                            <div class="col-4 d-grid gap-2">
                                <asp:Button class="btn btn-success btn-lg btn-block" ID="Button_Add_Publisher" runat="server" Text="Add" OnClick="Button_Add_Publisher_Click" />
                            </div>
                            <div class="col-4 d-grid gap-2">
                                <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button_Update_Publisher" runat="server" Text="Update" OnClick="Button_Update_Publisher_Click" />
                            </div>
                            <div class="col-4 d-grid gap-2">
                                <asp:Button class="btn btn-danger btn-lg btn-block" ID="Button_Delete_Publisher" runat="server" Text="Delete" OnClick="Button_Delete_Publisher_Click" />
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
                                <h4>Publisher List</h4>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView_Publisher" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>

</asp:Content>
