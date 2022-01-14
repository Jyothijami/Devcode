<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="PurchaseGoodsReceipt_Details - Copy.aspx.cs" Inherits="Modules_Stock_GoodsReceipt_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--   <script type="text/javascript">
         function showModal() {
             $("#large_modal").modal('show');
         }

         $(function () {
             $("#LinkButton1").click(function () {
                 showModal();
             });
         });
    </script>--%>
    <%--   <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
         <ContentTemplate>--%>
    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Purchase Goods Receipt Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="PurchaseGoodsReceipt.aspx">Purchase Goods Receipt</a></li>
            <li class="active">Purchase Goods Receipt Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->
    <div class="form-horizontal">

        <div class="panel panel-default">
            <div class="panel-heading">
                <h6 class="panel-title"><i class="icon-pencil"></i>Purchase Order Details</h6>
            </div>
            <div class="panel-body">

                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Purchase Receipt No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtPreceiptno" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Purchase Receipt Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtPrDate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Purchase Order No :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlPono" CssClass="select-full" Width="100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPono_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <label class="col-sm-2 control-label text-right">Purchase Order Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtPoDate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Vendor Name :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtvendorname" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Contact Person :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtVendorContactPerson" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="panel">
                    <div class="panel-body">

                        <div class="datatable">

                            <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                Width="100%" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="CodeNo" HeaderText="Item Name" />
                                    <asp:BoundField DataField="Series" HeaderText="Series" />
                                    <%--  <asp:BoundField DataField="Description" HeaderText="Description" />--%>
                                    <asp:BoundField DataField="Color" HeaderText="Color" />
                                    <asp:BoundField DataField="Uom" HeaderText="Uom" />
                                    <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                    <asp:TemplateField HeaderText="Received Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRECEIVEDQTY" runat="server" Width="40px" Text='<%# Eval("ReceivedQty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>






                                    <asp:BoundField DataField="RemainingQty" HeaderText="Remaining Qty" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                    <asp:BoundField DataField="ItemcodeId" HeaderText="ItemcodeId" />
                                    <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                    <asp:TemplateField HeaderText="Warehouse">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlPlant" Width="100%" OnSelectedIndexChanged="ddlPlant_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="StorageLoc">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlStoragelocation" Width="100%" runat="server"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PoDetId" HeaderText="Po Det Id" />
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

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h6 class="panel-title">Office Details</h6>
                    </div>

                    <div class="panel-body">
                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Prepared By: </label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlpreparedby" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-actions text-right">
                    <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-warning" Text="Print" />

                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                </div>

                <%--  <div id="large_modal" class="modal fade" tabindex="-1" role="dialog">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title"><i class="icon-accessibility"></i>Item Details</h4>
                            </div>

                            <div class="modal-body with-padding">
                                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h6 class="panel-title"><i class="icon-pencil"></i>Item Details</h6>
                    </div>
                    <div class="panel-body">

                        <h6 class="heading-hr text-danger">Material : <asp:Label ID="lblMaterialName" ForeColor="Black" runat="server" Text=""></asp:Label></h6>

                        <div class="form-group">

                            <label class="col-sm-2 control-label text-right">Length(MM) :</label>
                            <div class="col-sm-2">
                            <asp:TextBox Enabled="false" ID="lblMaterialLength" CssClass="disabled" runat="server" Text=""></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Description :</label>
                            <div class="col-sm-2">
                             <asp:TextBox ID="lblMaterialDescription" Width="100%" Enabled="false" TextMode="MultiLine" CssClass="disabled" runat="server" Text=""></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Color :</label>
                            <div class="col-sm-2">
                                <asp:TextBox ID="lblMaterialColor" Enabled="false" CssClass="disabled" runat="server" Text=""></asp:TextBox>
                             </div>
                        </div>

                        <h6 class="heading-hr text-danger">Quantity</h6>

                        <div class="form-group">

                            <label class="col-sm-2 control-label text-right">Quantity in Unit of Entry :</label>
                            <div class="col-sm-2">
                                <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Received Qty :</label>
                            <div class="col-sm-2">
                                <asp:TextBox ID="txtReceivedQty" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Remaining Qty :</label>
                            <div class="col-sm-2">
                                <asp:TextBox ID="txtreaminingqty" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <h6 class="heading-hr text-danger">Warehouse and Reference</h6>

                        <div class="form-group">

                            <label class="col-sm-2 control-label text-right">Plant :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlPlant" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Stock Type :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlStocktype" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">

                            <label class="col-sm-2 control-label text-right">Storage Location :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlStoragelocation" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                            </div>

                            <div class="modal-footer">
                                <button class="btn btn-warning" data-dismiss="modal">Close</button>
                                <asp:Button ID="btnadd" runat="server" OnClick="btnadd_Click" CssClass="btn btn-primary" Text="Save" />
                            </div>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>
    <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>