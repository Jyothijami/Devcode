<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="MaterialReceipt_Details.aspx.cs" Inherits="Modules_Stock_MaterialReceipt_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   <%-- <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>--%>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
     <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Material Receipt Details</h3>
                </div>
            </div>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">

                    <li class="active">Material Receipt Details</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="form-horizontal">
                <div class="panel panel-default">
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Material Receipt No :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtMaterialReceiptNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Posting Date :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtPostingdate" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:Image
                                    ID="Image2" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender3" runat="server" PopupButtonID="Image2"
                                    TargetControlID="txtPostingdate">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Created By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlpreparedby" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="panel panel-default">

                            <div class="panel-heading">
                                <h5>Materials</h5>
                            </div>
                            <div class="panel-body">

                                <div class="row">

                                    <div class="col-md-3">
                                        <label>Item Code : </label>
                                        <asp:DropDownList ID="ddlitemCode" Width="100%" TabIndex="2" OnSelectedIndexChanged="ddlitemCode_SelectedIndexChanged" AutoPostBack="true" CssClass="select-full" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Color :  </label>
                                        <asp:DropDownList ID="ddlColor" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Target Warehouse :  </label>
                                        <asp:DropDownList ID="ddlTargetwarehouse" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Qty :  </label>
                                        <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-1" style="padding-top: 2px">
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
                                            <asp:BoundField DataField="Warehouse" HeaderText="Warehouse" />
                                            <asp:BoundField DataField="Qty" HeaderText="Qty" />

                                            <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                                            <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                            <asp:BoundField DataField="WarehouseId" HeaderText="WarehouseId" />
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
                    </div>
                </div>
      <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>