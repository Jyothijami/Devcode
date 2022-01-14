<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="ProductionOrder_Details - Copy - Copy.aspx.cs" Inherits="Modules_Stock_ProductionOrder_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Production Order Details</h3>
                </div>
            </div>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="ProductionOrder.aspx">Production Order</a></li>
                    <li class="active">Production Order Details</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="form-horizontal">
                <div class="panel panel-default">
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Production Order No :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtProductionOrderno" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Items to Manufacture :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlItems" CssClass="select-full" AutoPostBack="true" OnSelectedIndexChanged="ddlItems_SelectedIndexChanged" Width="100%" runat="server"></asp:DropDownList>
                            </div>
                            <%--   <label class="col-sm-2 control-label text-right">Qty to Manufacture :</label>
                            <div class="col-sm-4">
                                   <asp:TextBox ID="txtQtytoManufacture" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>--%>
                            <label class="col-sm-2 control-label text-right">Sales Order No :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlSono" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Item Description:</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtitemDescription" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <label class="col-sm-2 control-label text-right">UOM :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtUOM" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Bom No :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlBomno" OnSelectedIndexChanged="ddlBomno_SelectedIndexChanged" AutoPostBack="true" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Qty to Manufacture :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtQtytoManufacture" OnTextChanged="txtQtytoManufacture_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="block-inner">
                            <h6 class="heading-hr">
                                <i class="icon-accessibility"></i>Warehouse:
                            </h6>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Work in Progress Warehouse :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlworkinprogress" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                            </div>
                            <label class="col-sm-2 control-label text-right">Scarp Warehouse :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlScarpwarehouse" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Target Warehouse :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlTargetWarehouse" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="block-inner">
                            <h6 class="heading-hr">
                                <i class="icon-accessibility"></i>Required Items:
                            </h6>
                        </div>

                      <%--  <div class="form-group">
                            <label class="col-sm-1 control-label text-right">Item Code :</label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlItemCode" CssClass="form-control" Width="100%" runat="server"></asp:DropDownList>
                            </div>
                            <label class="col-sm-2 control-label text-right">Source Warehouse:</label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlsourcewarehouse" OnSelectedIndexChanged="ddlsourcewarehouse_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <label class="col-sm-1 control-label text-right">Required Qty:</label>
                            <div class="col-sm-1">
                                <asp:TextBox ID="txtRequiredQty" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-1">
                                <asp:Button ID="btnAddnew" runat="server" OnClick="btnAddnew_Click" CssClass="btn btn-danger" Text="Add New" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label text-right">Available Qty at Source Warehouse :</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtavailableqtysource" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>--%>
                     
                        
                        
                           <div class="form-group">
                            <%--<asp:GridView ID="gvItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvItems_RowDeleting"
                                Width="100%">
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" />
                                    <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                                    <asp:BoundField DataField="SourceWarehouse" HeaderText="Source Warehouse" />
                                    <asp:BoundField DataField="ReqQty" HeaderText="Req Qty" />
                                    <asp:BoundField DataField="Transferqty" HeaderText="Transfer Qty" />
                                    <asp:BoundField DataField="ItemcodeId" HeaderText="ItemcodeId" />
                                    <asp:BoundField DataField="Sourcewarehouseid" HeaderText="Sourcewarehouseid" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="text-align: center">
                                        <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>--%>

                               <div class="dataTable" style="padding-top: 10px">
                                <asp:GridView ID="gvItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvItems_RowDataBound"
                                    Width="100%" OnRowDeleting="gvItems_RowDeleting">
                                    <Columns>

                                        <asp:CommandField ShowDeleteButton="True" />
                                        <asp:BoundField DataField="ItemCode" HeaderText="ItemCode" />
                                        <asp:BoundField DataField="Color" HeaderText="Color" />
                                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                          <asp:BoundField DataField="Barlength" HeaderText="Barlength" />
                                        <asp:BoundField DataField="Required" HeaderText="Required(Barlength)" />
                                        <asp:BoundField DataField="Transferqty" HeaderText="Transfered qty" />
                                        <asp:BoundField DataField="UOM" HeaderText="UOM" />

                                        <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                                        <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div style="text-align: center">
                                            <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>



                        </div>

                        <div class="block-inner">
                            <h6 class="heading-hr">
                                <i class="icon-accessibility"></i>Time:
                            </h6>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Planned Start Date:</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtplannedstartdate" CssClass="form-control" runat="server"></asp:TextBox>
                                 <asp:Image
                                    ID="Image3" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender3" runat="server" PopupButtonID="Image3"
                                    TargetControlID="txtplannedstartdate">
                                </cc1:CalendarExtender>
                            </div>
                            <label class="col-sm-2 control-label text-right">Expected Delivery Date :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtexpectedDeliverydate" CssClass="form-control" runat="server"></asp:TextBox>
                                 <asp:Image
                                    ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                                    TargetControlID="txtexpectedDeliverydate">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                    </div>

                    <div class="form-actions col-sm-offset-2">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>