<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="BlockDelete.aspx.cs" Inherits="Modules_Stock_BlockDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Block Delete</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="PO_Reserve.aspx">Block Delete</a></li>
            <li class="active">Block Delete Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->


     <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">

                 <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Sales Order No:</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlsono" CssClass="select-full" width="100%" OnSelectedIndexChanged="ddlsono_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                    <label class="col-sm-2 control-label text-right">Order Date:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtSalesorderdate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Customer :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlCustomer" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>

                    <label class="col-sm-2 control-label text-right">Project :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlunitid" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">

                      <asp:GridView ID="gvalready" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" 
                                Width="100%" >
                                <Columns>
                                   
                                    <asp:BoundField DataField="BlockStock_Id" HeaderText="Sl.No" />
                                    <asp:BoundField DataField="Stock_Reserve_No" HeaderText="Reserve No" />
                                    <asp:BoundField DataField="Stock_Reserve_Date" HeaderText="Reserve Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="Color_Name" HeaderText="Color" />
                                    <asp:BoundField DataField="Qty" HeaderText="Blocked Qty" />
                                    <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="For Project" />
                                    <asp:BoundField DataField="SalesOrder_No" HeaderText="SO.No" />

                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="text-align: center">
                                        <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>


                </div>



                </div>
            </div>
         </div>



</asp:Content>

