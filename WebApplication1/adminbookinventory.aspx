<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="WebApplication1.adminbookinventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview_id').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
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
                                    <h4>Book Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview_id" height="150" width="100" src="book_inventory/books1.png" />
                                </center>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <asp:FileUpload onchange="readURL(this);" CssClass="form-control" ID="FileUpload_BookInventory" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Book ID</label>
                                <div class="mb-3">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="textBox_bookid" runat="server" placeholder="Book ID"></asp:TextBox>
                                        <asp:LinkButton class="btn btn-primary" ID="Button_GO" runat="server" OnClick="Button_GO_Click">GO</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-9">
                                <label>Book Name</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textBox_bookname" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="mb-3">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList_Language" runat="server">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="German" Value="German" />
                                        <asp:ListItem Text="Croatian" Value="Croatian" />
                                        <asp:ListItem Text="French" Value="French" />
                                    </asp:DropDownList>
                                </div>

                                <label>Publisher Name</label>
                                <div class="mb-3">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList_Publisher" runat="server">
                                        <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                                        <asp:ListItem Text="Publisher 2" Value="Publisher 2" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Author Name</label>
                                <div class="mb-3">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList_Author" runat="server">
                                        <asp:ListItem Text="A1" Value="A1" />
                                        <asp:ListItem Text="A2" Value="A2" />
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-3">
                                    <label>Publish Date</label>
                                    <asp:TextBox CssClass="form-control" ID="textBox_publishdate" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="mb-3">
                                    <asp:ListBox CssClass="form-control" Rows="5" ID="ListBox_Genre" runat="server" SelectionMode="Multiple">
                                        <asp:ListItem Text="Action" Value="Action" />
                                        <asp:ListItem Text="Adventure" Value="Adventure" />
                                        <asp:ListItem Text="Crime" Value="Crime" />
                                        <asp:ListItem Text="Comedy" Value="Comedy" />
                                        <asp:ListItem Text="Drama" Value="Drama" />
                                        <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                        <asp:ListItem Text="Horror" Value="Horror" />
                                        <asp:ListItem Text="History" Value="History" />
                                        <asp:ListItem Text="Mistery" Value="Mistery" />
                                        <asp:ListItem Text="Sci-Fi" Value="Sci-Fi" />
                                        <asp:ListItem Text="Thriller" Value="Thriller" />
                                        <asp:ListItem Text="Western" Value="Westen" />
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textBox_edition" runat="server" placeholder="Edition"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <label>Book Cost</label>
                                <div class="mb-3">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="textBox_cost" runat="server" placeholder="Book Cost" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Pages</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textBox_pages" runat="server" TextMode="Number" placeholder="Pages"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Actual Stock</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textBox_acutalstock" runat="server" TextMode="Number" placeholder="Actual Stock"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <label>Curent Stock</label>
                                <div class="mb-3">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="textBox_currentstock" runat="server" placeholder="Current Stock" ReadOnly="true" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Issued Books</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textBox_issuedbooks" runat="server" TextMode="Number" ReadOnly="true" placeholder="Issued Books"></asp:TextBox>
                                </div>

                            </div>
                        </div>


                        <div class="row">
                            <div class="col-12">
                                <label>Book Description</label>
                                <div class="mb-3">
                                    <asp:TextBox CssClass="form-control" ID="textBox_description" runat="server" placeholder="Book Description" Rows="2" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button class="btn form-control btn-success btn-lg" ID="Button_Add" runat="server" Text="Add" OnClick="Button_Add_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button class="btn form-control btn-primary btn-lg" ID="Button_Update" runat="server" Text="Update" OnClick="Button_Update_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button class="btn form-control btn-danger btn-lg" ID="Button_Delete" runat="server" Text="Delete" OnClick="Button_Delete_Click" />
                            </div>
                        </div>

                    </div>
                </div>

                <a href="homepage.aspx">&lt&ltBack to Home</a><br />
                <br />

            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">


                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Inventory List</h4>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView_BookInventory" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" ReadOnly="True" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                        <asp:BoundField DataField="genre" HeaderText="genre" SortExpression="genre" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                        <asp:BoundField DataField="publish_date" HeaderText="publish_date" SortExpression="publish_date" />
                                        <asp:BoundField DataField="language" HeaderText="language" SortExpression="language" />
                                        <asp:BoundField DataField="edition" HeaderText="edition" SortExpression="edition" />
                                        <asp:BoundField DataField="book_cost" HeaderText="book_cost" SortExpression="book_cost" />
                                        <asp:BoundField DataField="no_of_pages" HeaderText="no_of_pages" SortExpression="no_of_pages" />
                                        <asp:BoundField DataField="book_description" HeaderText="book_description" SortExpression="book_description" />
                                        <asp:BoundField DataField="actual_stock" HeaderText="actual_stock" SortExpression="actual_stock" />
                                        <asp:BoundField DataField="current_stock" HeaderText="current_stock" SortExpression="current_stock" />
                                        <asp:BoundField DataField="book_img_link" HeaderText="book_img_link" SortExpression="book_img_link" />
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
