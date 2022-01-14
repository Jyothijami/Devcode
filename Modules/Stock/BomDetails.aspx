<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="BomDetails.aspx.cs" Inherits="Modules_Stock_BomDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>BOM Details</h3>
                </div>
            </div>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="Bom.aspx">BOM</a></li>
                    <li class="active">BOM Details</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="form-horizontal">
                <div class="panel panel-default">
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">BOM No :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtBomNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Sales Order No :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlsalesorderno" OnSelectedIndexChanged="ddlsalesorderno_SelectedIndexChanged" AutoPostBack="true" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                            </div>
                            <label class="col-sm-2 control-label text-right">Sales Order Items:</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlsalesorderitems" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlsalesorderitems_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Width :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtwidth" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <label class="col-sm-2 control-label text-right">Height :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtHeight" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Total Area :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtStillheight" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <label class="col-sm-2 control-label text-right">Series :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtSeries" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Glass :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtGlass" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <label class="col-sm-2 control-label text-right">FlyScreen :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtflyscreen" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Quantity :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                                (Item obtained after manufacturing)
                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h6 class="panel-title">Operations Required</h6>
                    </div>
                    <div class="panel-body">

                        <label class="col-md-2 control-label text-right">Operations</label>
                        <div class="datatable">
                            <asp:CheckBoxList ID="cblPermissions" CssClass="checkbox-inline" runat="server" CellPadding="2" CellSpacing="1" DataSourceID="SqlDataSource1" DataTextField="Operation_Name" DataValueField="Operation_Id">
                            </asp:CheckBoxList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>"
                                SelectCommand="SELECT * FROM  Operation_Master"></asp:SqlDataSource>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">

                    <div class="panel-heading">
                        <h6 class="panel-title">Materials Needed</h6>
                    </div>
                    <div class="panel-body">

                        <div class="row">

                            <div class="col-md-2">
                                <label>Item Code : </label>
                                <asp:DropDownList ID="ddlitemCode" Width="100%" TabIndex="2" OnSelectedIndexChanged="ddlitemCode_SelectedIndexChanged" AutoPostBack="true" CssClass="select-full" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <label>Color :  </label>
                                <asp:DropDownList ID="ddlColor" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <%--<div class="col-md-2">
                                        <label>Qty :  </label>
                                        <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>--%>

                            <div class="col-md-2">
                                <label>BarLength :  </label>
                                <asp:TextBox ID="txtbarlength" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                <label>Required Qty:  </label>
                                <asp:TextBox ID="txtrequiredbarlength" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                <label>Unit :  </label>
                                <asp:TextBox ID="txtItemUom" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2" style="padding-top: 2px">
                                <label></label>
                                <asp:Button ID="btnadditem" CssClass="btn btn-primary" runat="server" OnClick="btnadditem_Click" Text="Add Item" />
                            </div>
                        </div>









                        <div class="dataTable" style="padding-top: 10px">
                            <asp:GridView ID="gvItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvItems_RowDataBound"
                                Width="100%" OnRowDeleting="gvItems_RowDeleting">
                                <Columns>

                                    <asp:CommandField ShowDeleteButton="True" />
                                    <asp:BoundField DataField="ItemCode" HeaderText="ItemCode" />
                                    <asp:BoundField DataField="Color" HeaderText="Color" />
                                    <%--   <asp:BoundField DataField="Qty" HeaderText="Qty" />--%>

                                    <asp:BoundField DataField="Required" HeaderText="Required" />

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
                </div>

                <div class="form-group">

                    <div class="form-actions col-sm-offset-10">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
     <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>