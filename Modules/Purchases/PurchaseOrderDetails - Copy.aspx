<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="PurchaseOrderDetails - Copy.aspx.cs" Inherits="Modules_Purchases_PurchaseOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function netamtcalc() {
            var disc, subtot, tax, cif, fob;
            try { tax = document.getElementById('<%=txtgst.ClientID %>').value; } catch (e) { tax = "0"; }
        try { cif = document.getElementById('<%=txtCif.ClientID %>').value; } catch (e) { cif = "0"; }
        try { fob = document.getElementById('<%=txtFob.ClientID %>').value; } catch (e) { fob = "0"; }
        disc = document.getElementById('<%=txtdiscount.ClientID %>').value;
        subtot = document.getElementById('<%=txttotalExworks.ClientID %>').value;
        if (disc == "" || disc == "0" || isNaN(disc)) { disc = "0"; }
        if (tax == "" || tax == "0" || isNaN(tax)) { tax = "0"; }
        if (subtot > 0) {
            document.getElementById('<%=txtnetamount.ClientID %>').value = parseFloat(subtot) + parseFloat(tax * subtot / 100) - parseFloat(disc * subtot / 100) + parseFloat(cif) + parseFloat(fob);
    }
}
    </script>

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

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Purchase Order Details</h3>
                </div>
            </div>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="PurchaseOrder.aspx">Purchase Order</a></li>
                    <li class="active">Purchase Order Details</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title"><i class="icon-pencil"></i>Purchase Order Details</h6>
                </div>
                <div class="panel-body">

                    <%-- Basic Details --%>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Basic Details</h6>
                        </div>
                        <div class="panel-body">

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>PurchaseOrder No:  </label>
                                        <asp:TextBox ID="txtPONo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label>PurchaseOrder Date:  </label>
                                        <asp:TextBox ID="txtPOdate" name="trigger" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                                            TargetControlID="txtPOdate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-3">
                                        <label>Supplier :  </label>
                                        <asp:DropDownList ID="ddlsupplier" Width="100%" TabIndex="2" CssClass="select-full" OnSelectedIndexChanged="ddlsupplier_SelectedIndexChanged" runat="server" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Contact Person :  </label>
                                        <asp:TextBox ID="txtContactPerson" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Contact No :  </label>
                                        <asp:TextBox ID="txtContactNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Country :  </label>
                                        <asp:TextBox ID="txtCountry" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">

                                <div class="row">
                                    <div class="col-md-3">
                                        <label>IndentOrder No:  </label>
                                        <asp:DropDownList ID="ddlIndent" Width="100%" TabIndex="2" CssClass="select-full" runat="server" OnSelectedIndexChanged="ddlIndent_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <label>IndentOrder Date:  </label>
                                        <asp:TextBox ID="txtIndentdate" name="trigger" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                                            TargetControlID="txtIndentdate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>

                                <div class="row" style="padding-top: 30px">
                                    <asp:GridView ID="gvIndentItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvIndentItems_RowDataBound"
                                        Width="100%">
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
                                            <asp:BoundField DataField="Series" HeaderText="Series" />
                                            <asp:BoundField DataField="Length" HeaderText="Length" />
                                            <asp:BoundField DataField="Description" HeaderText="Description" />
                                            <asp:BoundField DataField="Color" HeaderText="Color" />
                                            <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                            <asp:BoundField DataField="Kgpermtr" HeaderText="Kg/Mtr" />
                                            <asp:BoundField DataField="TotalWeight" HeaderText="Total Weight" />
                                            <asp:BoundField DataField="AlumiumCoating" HeaderText="Aluminum + Coating" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                                            <asp:BoundField DataField="CustId" HeaderText="CustId" />
                                            <asp:BoundField DataField="SeriesId" HeaderText="SeriesId" />

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
                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Add Items</h6>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-2">
                                        <label>Material Code : </label>
                                        <asp:DropDownList ID="ddlMaterial" Width="100%" TabIndex="2" OnSelectedIndexChanged="ddlMaterial_SelectedIndexChanged" AutoPostBack="true" CssClass="select-full" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Length(MM) :  </label>
                                        <asp:TextBox ID="txtlength" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Color :  </label>
                                        <asp:DropDownList ID="txtColor" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Qty :  </label>
                                        <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Kg/Mtr :  </label>
                                        <asp:TextBox ID="txtkgpermtr" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Total Weight :  </label>
                                        <asp:TextBox ID="txttotalweight" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-3">
                                        <label>Customer Name :  </label>
                                        <asp:DropDownList ID="ddlCustomerName" TabIndex="2" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-5">
                                        <label>Descripiton :  </label>
                                        <asp:TextBox ID="txtDescription" Rows="2" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Aluminium + Coating :  </label>
                                        <asp:TextBox ID="txtaluminumcoating" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Amount :  </label>
                                        <asp:TextBox ID="txtamount" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">

                                    <div class="text-center">

                                        <asp:Button ID="btnReset" CssClass="btn btn-danger" runat="server" Text="Reset" />
                                        <asp:Button ID="btnadditem" CssClass="btn btn-primary" runat="server" OnClick="btnadditem_Click" Text="Add Item" />
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="padding-top: 30px">
                                <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvitems_RowDataBound"
                                    Width="100%" OnRowDeleting="gvitems_RowDeleting">
                                    <Columns>

                                        <asp:CommandField ShowDeleteButton="True" />
                                        <asp:BoundField DataField="Series" HeaderText="Series" />
                                        <asp:BoundField DataField="Length" HeaderText="Length" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                        <asp:BoundField DataField="Color" HeaderText="Color" />
                                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                        <asp:BoundField DataField="Kgpermtr" HeaderText="Kg/Mtr" />
                                        <asp:BoundField DataField="TotalWeight" HeaderText="Total Weight" />
                                        <asp:BoundField DataField="AlumiumCoating" HeaderText="Aluminum + Coating" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                                        <asp:BoundField DataField="CustId" HeaderText="CustId" />
                                        <asp:BoundField DataField="SeriesId" HeaderText="SeriesId" />
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

                    <div class="panel panel-default">
                        <div class="panel-heading"><span class="panel-title">Terms & Conditions</span></div>
                        <div class="panel-body">

                            <div class="form-group">

                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Terms & Condtions: </label>
                                        <asp:TextBox ID="txttermscondtions" TextMode="MultiLine" Rows="3" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Terms Of Delivery: </label>
                                        <asp:TextBox ID="txttermsofdelivery" TextMode="MultiLine" Rows="3" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-3">
                                        <label>Destination : </label>
                                        <asp:TextBox ID="txtDestination" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Insurance : </label>
                                        <asp:TextBox ID="txtInsurance" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Freight : </label>
                                        <asp:TextBox ID="txtFreight" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Payment Terms : </label>
                                        <asp:DropDownList ID="ddlPaymentterms" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-3">
                                        <label>Dispatch Mode : </label>
                                        <asp:DropDownList ID="ddldispatch" Width="100%" runat="server" CssClass="select-full"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading"><span class="panel-title">Payments</span></div>
                        <div class="panel-body">

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Total Ex-Works : </label>
                                        <asp:TextBox ID="txttotalExworks" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label>Discount : </label>
                                        <asp:TextBox ID="txtdiscount" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>FOB Charges : </label>
                                        <asp:TextBox ID="txtFob" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label>CIF Charges : </label>
                                        <asp:TextBox ID="txtCif" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>GST : </label>
                                        <asp:TextBox ID="txtgst" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label>Net Amount : </label>
                                        <asp:TextBox ID="txtnetamount" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Currency : </label>
                                        <asp:TextBox ID="txtCurrency" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Office Details</h6>
                        </div>

                        <div class="panel-body">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-4">
                                        <label>Prepared By:  </label>
                                        <asp:DropDownList ID="ddlpreparedby" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-4">
                                        <label>Approved By:  </label>
                                        <asp:DropDownList ID="ddlapprovedby" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-actions text-right">
                        <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-warning" Text="Print" />
                        <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-success" Text="Approve" />
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>