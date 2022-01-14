<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="RequestBlockStock.aspx.cs" Inherits="Modules_Stock_GlassRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-horizontal">
        <div class="page-header">
            <div class="page-title">
                <h3>Request Block Stock Transfer Details</h3>
            </div>
        </div>
        <!-- /page header -->

        <!-- Breadcrumbs line -->
        <div class="breadcrumb-line">
            <ul class="breadcrumb">
                <li><a href="RequestBlockStockL.aspx">Request Block Stock Transfer</a></li>
                <li class="active">Request Block Stock Transfer Details</li>
            </ul>
        </div>
        <!-- /breadcrumbs line -->



        <div class="panel panel-default">
            <div class="panel-heading">
                <h6 class="panel-title"><i class="icon-pencil"></i>Request Block Stock Details</h6>
            </div>
            <div class="panel-body">



                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Request No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtMaterialreqestNo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Request Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtMrdate" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:Image
                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                            TargetControlID="txtMrdate">
                        </cc1:CalendarExtender>
                    </div>
                </div>


                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Request Type :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlrequesttype" CssClass="form-control" Width="100%" runat="server">
                            <asp:ListItem>Production</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <label class="col-sm-2 control-label text-right">Required Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtrequireddate" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:Image
                            ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                            TargetControlID="txtrequireddate">
                        </cc1:CalendarExtender>
                    </div>
                </div>


                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">From Project Code :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlPono" CssClass="select-full" Width="100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPono_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <label class="col-sm-2 control-label text-right">To Project Code :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlToPono" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                    </div>
                </div>


                <div class="panel">

                    <div class="panel-heading">
                        <h6 class="panel-title"><i class="icon-loop"></i>Blocked Material of Customer</h6>
                    </div>
                    <div class="panel-body">





                        <div class="datatable">

                            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="hai_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="BlockStock_Id" HeaderText="Sl.No" SortExpression="BlockStock_Id">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ProjectCode" HeaderText="Project Code" SortExpression="ProjectCode">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" SortExpression="Material_Code">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Color_Name" HeaderText="Color" SortExpression="Color_Name">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="UOM_SHORT_DESC" HeaderText="UOM" SortExpression="UOM_SHORT_DESC">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="blocklength" HeaderText="Length" SortExpression="blocklength">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Release Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemqty" CssClass="form-control" Text="0" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Item_Code" HeaderText="ItemCode" SortExpression="Item_Code">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Color_Id" HeaderText="ColorId" SortExpression="Color_Id">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>


                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>







                <div class="panel">

                    <div class="panel-heading">
                        <h6 class="panel-title"><i class="icon-scissors"></i>Requested Material to Unblock</h6>
                    </div>
                    <div class="panel-body">

                        <div class="datatable">

                            <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="RequestBlockRelase_Det_id" HeaderText="Sl.No" SortExpression="RequestBlockRelase_Det_id">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" SortExpression="Material_Code">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Color_Name" HeaderText="Color" SortExpression="Color_Name">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="UOM_SHORT_DESC" HeaderText="UOM" SortExpression="UOM_SHORT_DESC">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ReqQty" HeaderText="Req Qty" SortExpression="ReqQty">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ProjectCode" HeaderText="From Project" SortExpression="ProjectCode">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Expr1" HeaderText="To Project" SortExpression="Expr1">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>


                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>










                <div class="panel panel-default">
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Request By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlrequestedby" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Approved By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlapprovedby" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                            </div>
                        </div>


                    </div>
                </div>

                <div class="form-group">

                    <div class="form-actions col-sm-offset-10">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-success" Text="Approve" OnClick="btnApprove_Click" />



                    </div>
                </div>





            </div>
        </div>



    </div>







</asp:Content>

