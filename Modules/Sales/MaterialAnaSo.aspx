<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="MaterialAnaSo.aspx.cs" Inherits="Modules_Sales_MaterialAnaSo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


     <asp:UpdatePanel ID="RegUpdatePanel" runat="server">
        <ContentTemplate>


    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Sales Order Material Analysis </h3>
        </div>
    </div>

    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="SalesOrder.aspx">Sales Order</a></li>
            <li class="active">Sales Order Material Analysis</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title">Basic Details</h6>
        </div>
        <div class="panel-body">

            <div class="form-horizontal">

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Sales Order No:</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlsono" CssClass="form-control" OnSelectedIndexChanged="ddlsono_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
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
                    <label class="col-sm-2 control-label text-right">Delivery Date:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtDeliveryDate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title">Upload Material Analaysis File</h6>
            <span class="pull-right">
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-warning" NavigateUrl="~/Content/Templates/SalesOrderMaterialAnalysisTemp.xlsx" Text="Download Excel Template" /></span>
        </div>
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Upload File:</label>
                    <div class="col-sm-4">
                        <asp:FileUpload ID="FileUpload1" type="file" CssClass="styled" runat="server" />
                    </div>
                    <div class="col-sm-4">
                        <asp:Button ID="btnfileUpload" Text="Upload" CssClass="btn btn-danger" OnClick="btnfileUpload_Click" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>




    <div class="panel panel-default">

                    <div class="panel-heading">
                        <h5 class="panel-title">Add Extra Items</h5>
                    </div>

                    <div class="panel-body">

                        <div class="form-horizontal">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Item Code :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlitemCode" Width="100%" TabIndex="2" AutoPostBack="true" CssClass="select-full" runat="server" OnSelectedIndexChanged="ddlitemCode_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Color :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlColor" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Description :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtdescription" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Uom :</label>
                            <div class="col-sm-4">
                               <asp:TextBox ID="txtUom" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                             <label class="col-sm-2 control-label text-right">Length :</label>
                            <div class="col-sm-4">
                               <asp:TextBox ID="txtitemtLength" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Packing Unit :</label>
                            <div class="col-sm-4">
                               <asp:TextBox ID="txtpu" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                       

                           
                        </div>

                        <div class="form-group">


                                 <label class="col-sm-2 control-label text-right">Qty :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                         
                        </div>

                        <div class="form-group">

                            <div class="form-actions col-sm-offset-6">
                                <asp:Button ID="btnadditem" CssClass="btn btn-primary" runat="server" OnClick="btnadditem_Click" Text="Add Item" />
                            </div>
                        </div>

                        <div class="" style="padding-top: 20px">
                            <asp:GridView ID="gvItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvItems_RowDataBound"
                                Width="100%" OnRowDeleting="gvItems_RowDeleting">
                                <Columns>

                                    <asp:CommandField ShowDeleteButton="True" />
                                  
                                    <asp:BoundField DataField="ITEMCODE" HeaderText="Item Code" />
                                    <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                                    <asp:BoundField DataField="PU" HeaderText="PU" />
                                    <asp:BoundField DataField="BARLENGTH" HeaderText="BarLength" />
                                    <asp:BoundField DataField="REQUIRED_QTY" HeaderText="Required Qty" />
                                    <asp:BoundField DataField="UNIT" HeaderText="Unit" />
                                    <asp:BoundField DataField="COLOR" HeaderText="Color" />
                                    <asp:BoundField DataField="ITEMCODE_ID" HeaderText="ItemId" />
                                    <asp:BoundField DataField="COLOR_ID" HeaderText="ColorId" />
                                    <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" />

                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="text-align: center">
                                        <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>


                         <div class="form-group">

                    <div class="form-actions col-sm-offset-10">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                    </div>
                </div>



                            </div>
                    </div>
                </div>










    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title">Bom Details</h6>
        </div>
        <div class="panel-body">

            <div class="datatable">

                <asp:GridView ID="gvmatana" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvmatana_RowDataBound">
                    <Columns>

                     <%--   <asp:BoundField DataField="ITEM_CATEGORY_NAME" HeaderText="Material Type" />--%>
                        <asp:BoundField DataField="ITEMCODE" HeaderText="Item Code" />
                        <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                        <asp:BoundField DataField="PU" HeaderText="PU" />
                        <asp:BoundField DataField="BARLENGTH" HeaderText="BarLength" />
                        <asp:BoundField DataField="REQUIRED_QTY" HeaderText="Required Qty" />
                        <asp:BoundField DataField="UNIT" HeaderText="Unit" />
                        <asp:BoundField DataField="COLOR" HeaderText="Color" />
                        <asp:BoundField DataField="ITEMCODE_ID" HeaderText="ItemId" />
                        <asp:BoundField DataField="COLOR_ID" HeaderText="ColorId" />
                        <asp:BoundField HeaderText="Available Qty" />

                          <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-icon btn-danger" OnClick="lbtnDelete_Click"><i class="icon-remove3"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                         <asp:BoundField DataField="SO_MATANA_ID" HeaderText="DetId" />

                        

                    </Columns>
                    <EmptyDataTemplate>
                        <span style="color: #CC0000">No Data Found</span>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>



             </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnfileUpload" />
            <%--   <asp:AsyncPostBackTrigger ControlID="btSubmit" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>