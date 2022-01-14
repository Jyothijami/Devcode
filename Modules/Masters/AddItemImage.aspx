<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="AddItemImage.aspx.cs" Inherits="Modules_Masters_AddItemImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


      <div class="page-header">
                <div class="page-title">
                    <h3>Item Details</h3>
                </div>
            </div>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="Item.aspx">Item</a></li>
                    <li class="active">Item Image</li>
                </ul>
            </div>

    <div class="panel panel-danger" >

          <div class="panel-heading">
          <h5 class="panel-title">Add Image</h5>
          </div>

          <div class="panel-body">


                <div class="form-group">
                    <div class="row">
                                <div class="col-md-6">
                     <asp:Image ID="Image" runat="server" ImageUrl="~/images/noname.jpg" Width="70px" />
                                    </div>
                        </div>
                </div>

                <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Item Code:</label>
                                    <asp:TextBox ID="txtempname" runat="server" ></asp:TextBox>
                                 </div>
                                 <div class="col-md-6" runat="server" visible="false">
                                    <label></label>
                                    <asp:TextBox ID="txtempid" runat="server" ></asp:TextBox>
                                 </div>
                                


                            </div>
                 </div>

                <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Add Image :</label>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                </div>

                                <div class="col-md-6">
                                   <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-default" OnClick="btnUpload_Click" Text="Upload" />
                                </div>


                            </div>
                 </div>










          </div>



    </div>




</asp:Content>

