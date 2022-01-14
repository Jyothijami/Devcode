<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="RequestGlassQuatation_Details.aspx.cs" Inherits="Modules_Purchases_RequestGlassQuatations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">

        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;

            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;

        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        if (row.rowIndex % 2 == 0) {
                            row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>

    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Request Glass Quotations Details</h3>
        </div>
    </div>

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="RequestGlassQuatation.aspx">Request Glass Quotations</a></li>
            <li class="active">Request Glass Quotations Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title">Request Quotation Details</h6>
        </div>
        <div class="panel-body">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Basic Details</h6>
                </div>
                <div class="panel-body">

                    <div class="form-horizontal">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Request Glass Quotation No:</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtquatationno" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <label class="col-sm-2 control-label text-right">Request Glass Quotation Date:</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtquotationdate" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:Image
                                    ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                                    TargetControlID="txtquotationdate">
                                </cc1:CalendarExtender>
                            </div>
                        </div>

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <div class="panel-title">
                                    Add Vendors for Quatations Request
                                </div>
                            </div>
                            <div class="panel-body">

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Supplier :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlSupplier" AutoPostBack="true" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Contact Person :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtsupContactPerson" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Mobile No :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtSupMobileno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Email :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtSupEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">

                                    <div class="form-actions col-sm-offset-6">
                                        <asp:Button ID="btnadditem" CssClass="btn btn-primary" runat="server" OnClick="btnadditem_Click" Text="Add Vendor" />
                                    </div>
                                </div>

                                <div class="dataTable" style="padding-top: 10px">
                                    <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                        Width="100%" OnRowDeleting="GridView1_RowDeleting">
                                        <Columns>

                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                                            <asp:BoundField DataField="ContactPerson" HeaderText="Contact Person" />
                                            <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                            <asp:BoundField DataField="VendorId" HeaderText="VendorId" />
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
                </div>
            </div>

            <div class="panel panel-default" runat="server" visible="true" id="panelEnquirydetails">
                <div class="panel-heading">
                    <h6 class="panel-title">Sales Order Details</h6>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Sales Order No :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlMaterialrequest" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlMaterialrequest_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="panel-group">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h6 class="panel-title">Glass Details
                                </h6>
                            </div>

                            <div class="panel-body">
                                <div class="form-group">

                                    <div class="row" style="padding-top: 30px">
                                        <asp:GridView ID="gvEnqItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                            Width="100%" OnRowDataBound="gvEnqItems_RowDataBound">
                                            <Columns>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);"
                                                            AutoPostBack="true" OnCheckedChanged="CheckBox_CheckChanged" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)"
                                                            AutoPostBack="true" OnCheckedChanged="CheckBox_CheckChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="WindowCode" HeaderText="WindowCode" />
                                                <asp:BoundField DataField="Thickness" HeaderText="Thickness" />
                                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                                <asp:BoundField DataField="Width" HeaderText="Width" />
                                                <asp:BoundField DataField="Height" HeaderText="Height" />
                                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                                <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                                <asp:BoundField DataField="Area" HeaderText="Area" />
                                                <asp:BoundField DataField="Weight" HeaderText="Weight" />
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
                    </div>
                </div>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                <h6 class="panel-title"></h6>
            </div>
            <div class="panel-body">

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            Add Extra Glass Items
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">

                            <div class="form-group">
                                <label class="col-sm-2 control-label text-right">Window Code :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtwindowCode" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="col-sm-2 control-label text-right">Thickness :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtThickness" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label text-right">Description :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="col-sm-2 control-label text-right">Width :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtWidth" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label text-right">Height :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtHeight" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="col-sm-2 control-label text-right">Quantity :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label text-right">Unit :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtUnit" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="col-sm-2 control-label text-right">Area :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtArea" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label text-right">Weight :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtWeight" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">

                                <div class="form-actions col-sm-offset-6">
                                    <asp:Button ID="btnAddItems" CssClass="btn btn-primary" runat="server" Text="Add Item" OnClick="btnAddItems_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            Glass for Quatations Requested
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="datatable">

                            <div class="row" style="padding-top: 0px">
                                <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                    Width="100%" OnRowDataBound="gvitems_RowDataBound" OnRowDeleting="gvitems_RowDeleting">
                                    <Columns>

                                        <asp:CommandField ShowDeleteButton="True" />
                                        <asp:BoundField DataField="WindowCode" HeaderText="WindowCode" />
                                        <asp:BoundField DataField="Thickness" HeaderText="Thickness" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                        <asp:BoundField DataField="Width" HeaderText="Width" />
                                        <asp:BoundField DataField="Height" HeaderText="Height" />
                                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                        <asp:BoundField DataField="Area" HeaderText="Area" />
                                        <asp:BoundField DataField="Weight" HeaderText="Weight" />
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

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            Additional Details
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-2 control-label text-right">Remarks :</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtRemarks" Width="100%" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                    <cc1:HtmlEditorExtender
                                        ID="HtmlEditorExtender5" TargetControlID="txtRemarks" EnableSanitization="false" DisplaySourceTab="false"
                                        runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="bg-primary with-padding block-inner">Office Details</div>
                <div class="form-horizontal">

                    <div class="form-group">
                        <label class="col-sm-2 control-label text-right">Prepared By :</label>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlpreparedby" Width="100%" TabIndex="2" Enabled="false" CssClass="select-full" runat="server"></asp:DropDownList>
                        </div>

                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlapprovedby" Width="100%" TabIndex="2" Enabled="false" Visible="false" CssClass="select-full" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel-body">
                <div class="form-actions text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>