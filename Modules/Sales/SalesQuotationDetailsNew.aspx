<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SalesQuotationDetailsNew.aspx.cs" Inherits="Modules_Sales_SalesQuotationDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="RegUpdatePanel" runat="server">
        <ContentTemplate>

            <script type="text/javascript">
                function hi() {
                    // event.preventDefault();
                    swal({
                        title: 'System Meassage',
                        text: "Data Submitted Sucessfully",
                        type: 'success',
                        confirmButtonColor: '#3085d6',
                        confirmButtonText: 'Ok'
                    })
                    .then(function () {
                        // Set data-confirmed attribute to indicate that the action was confirmed
                        window.location = 'SalesQuotation.aspx';
                    }).catch(function (reason) {
                        // The action was canceled by the user
                    });

                }
            </script>

            <script type="text/javascript">
                function confirmDelete() {
                    if (confirm("Are you sure you want to Submit this Record?")) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            </script>

            <script type="text/javascript">

                function grosscalc() {
                    var Tax, grossamt, TOTAL, dis;
                    Tax = document.getElementById('<%=txttax.ClientID %>').value;
            dis = document.getElementById('<%=txtdiscount.ClientID %>').value;
            grossamt = parseFloat(document.getElementById('<%=txtsubtotal.ClientID %>').value);
            if (Tax == "" || Tax == "0" || isNaN(Tax)) { Tax = "0"; }
            if (dis == "" || dis == "0" || isNaN(dis)) { dis = "0"; }

            TOTAL = parseFloat(grossamt);
            TOTAL = TOTAL + ((Tax * TOTAL) / 100);
            TOTAL = TOTAL - ((dis * TOTAL) / 100);

            document.getElementById('<%=txttotal.ClientID %>').value = parseInt(TOTAL);
        }
            </script>

            <%-- Calculating Area Sq Mt --%>

            <script type="text/javascript">

                function ItemArea() {
                    var Width, Height, Qty, Area, GlassPrice;
                    Width = document.getElementById('<%=txtWidth.ClientID %>').value;
            Height = document.getElementById('<%=txtHeight.ClientID %>').value;
            Qty = parseFloat(document.getElementById('<%=txtItemQty.ClientID %>').value);
            Area = parseFloat(document.getElementById('<%=txttotalarea.ClientID %>').value);

            if (Width == "" || Width == "0" || isNaN(Width)) { Width = "0"; }
            if (Height == "" || Height == "0" || isNaN(Height)) { Height = "0"; }
            if (Qty == "" || Qty == "0" || isNaN(Qty)) { Qty = "0"; }
            if (Area == "" || Area == "0" || isNaN(Area)) { Area = "0"; }

            Area = Qty * Width * Height / 1000000;

            document.getElementById('<%=txttotalarea.ClientID %>').value = parseFloat(Area);
        }
            </script>

            <script type="text/javascript">
<!--
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
    //-->
            </script>
            <style type="text/css">
                .modalBackground {
                    background-color: Black;
                    filter: alpha(opacity=90);
                    opacity: 0.8;
                }

                .modalPopup {
                    background-color: #FFFFFF;
                    /*border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;*/
                    /*width: 300px;
            height: 140px;*/
                }
            </style>

            <%-- <script>
        $(function () {
            initdropdown();

        })

        function initdropdown() {
            $('.select-full').select2();
        }
    </script>--%>

            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Sales Quotation Details</h3>
                </div>
            </div>

            <%-- <script type="text/javascript">
                Sys.Application.add_load(initdropdown);
            </script>--%>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="SalesQuotation.aspx">Sales Quotations</a></li>
                    <li class="active">Sales Quotations Details</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Quotation Details</h6>
                </div>
                <div class="panel-body">

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Basic Details</h6>
                        </div>
                        <div class="panel-body">

                            <div class="form-horizontal">

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Quotation No:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtquatationno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Quotation Date:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtquotationdate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                                            TargetControlID="txtquotationdate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Quotation To:</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlquotationto" AutoPostBack="true" OnSelectedIndexChanged="ddlquotationto_SelectedIndexChanged" CssClass="form-control" runat="server">
                                            <asp:ListItem>Enquiry</asp:ListItem>
                                            <asp:ListItem>Customer</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Valid To:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtValidto" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="Image4" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender5" runat="server" PopupButtonID="Image4"
                                            TargetControlID="txtValidto">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-default" runat="server" visible="true" id="panelEnquirydetails">
                        <div class="panel-heading">
                            <h6 class="panel-title">Enquiry Details</h6>
                        </div>
                        <div class="panel-body">
                            <div class="form-horizontal">

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Enquiry No:</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlEnquiryNo" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlEnquiryNo_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Enquiry Date:</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtenquirydate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="Image3" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender4" runat="server" PopupButtonID="Image3"
                                            TargetControlID="txtenquirydate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-group block">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h6 class="panel-title">
                                            <a data-toggle="collapse" href="#collapse-group12">Details<b class="caret"></b></a>
                                        </h6>
                                    </div>
                                    <div id="collapse-group12" class="panel-collapse">
                                        <div class="panel-body">

                                            <div class="well block">
                                                <div class="tabbable">
                                                    <ul class="nav nav-pills nav-justified">
                                                        <li class="active"><a href="#default-pill1" data-toggle="tab">Windows & Door Schedule</a></li>
                                                        <li><a href="#default-pill2" data-toggle="tab">Window Elevation Drawings </a></li>
                                                        <li><a href="#default-pill3" data-toggle="tab">Floor Plan Drawings</a></li>
                                                    </ul>

                                                    <div class="tab-content pill-content">

                                                        <%-- Windows and DoorSchedule--%>

                                                        <div class="tab-pane fade in active" id="default-pill1">

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
                                                                            <asp:BoundField DataField="CodeNo" HeaderText="Code No" />
                                                                            <asp:BoundField DataField="Series" HeaderText="Series" />
                                                                            <asp:BoundField DataField="Description" HeaderText="Description" />
                                                                            <asp:BoundField DataField="Glass" HeaderText="Glass" />
                                                                            <asp:BoundField DataField="Location" HeaderText="Location" />
                                                                            <asp:BoundField DataField="FlyScreen" HeaderText="FlyScreen" />
                                                                            <asp:BoundField DataField="Width" HeaderText="Width" />
                                                                            <asp:BoundField DataField="height" HeaderText="height" />
                                                                            <%-- <asp:BoundField DataField="SillHeight" HeaderText="SillHeight" />--%>
                                                                            <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                                                            <asp:BoundField DataField="TotalArea" HeaderText="TotalArea" />
                                                                            <%--   <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                                                                            <asp:BoundField DataField="ProfileFinish" HeaderText="Profile Color" />
                                                                            <asp:BoundField DataField="HardwareColor" HeaderText="HardwareColor" />
                                                                            <asp:BoundField DataField="InstallationCharges" HeaderText="InstallationCharges" />
                                                                            <asp:BoundField DataField="SystemCost" HeaderText="SystemCost" />
                                                                            <asp:BoundField DataField="TotalRmt" HeaderText="TotalRmt" />
                                                                            <asp:BoundField DataField="TotalRft" HeaderText="TotalRft" />
                                                                            <asp:BoundField DataField="ElevationView" HeaderText="ElevationView" />--%>
                                                                            <asp:BoundField DataField="EnqDetId" HeaderText="EnqDetId" />
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
                                                        <%-- Windos Elevation Drawings --%>
                                                        <div class="tab-pane fade" id="default-pill2">

                                                            <div class="form-group">

                                                                <asp:GridView ID="gvElevationDrawings" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False">
                                                                    <Columns>

                                                                        <asp:BoundField DataField="ELEVATION_ENQID" HeaderText="Sl.No" SortExpression="ELEVATION_ENQID">
                                                                            <HeaderStyle Font-Size="Smaller" />
                                                                        </asp:BoundField>

                                                                        <asp:BoundField DataField="ELEVATION_RECEIVEDDATE" HeaderText="Received Date" SortExpression="ELEVATION_RECEIVEDDATE" DataFormatString="{0:dd/MM/yyyy}">
                                                                            <HeaderStyle Font-Size="Smaller" />
                                                                        </asp:BoundField>

                                                                        <asp:BoundField DataField="ELEVATION_REMARKS" HeaderText="Remarks" SortExpression="ELEVATION_REMARKS">
                                                                            <HeaderStyle Font-Size="Smaller" />
                                                                        </asp:BoundField>

                                                                        <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                                                                            <ItemTemplate>
                                                                                <span class="text-center">
                                                                                    <asp:HyperLink ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" Target="_blank" PostBackUrl='<%# "~/Content/ElevationDrawings/" + Eval("ELEVATION_DOCUMENTS") %>'><i class="icon-attachment"></i></asp:HyperLink>
                                                                                </span>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                        <%-- FloorPlan --%>
                                                        <div class="tab-pane fade" id="default-pill3">

                                                            <div class="form-group">
                                                                <asp:GridView ID="gvFloorPlan" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False">
                                                                    <Columns>

                                                                        <asp:BoundField DataField="FLOORPLAN_ENQID" HeaderText="Sl.No" SortExpression="FLOORPLAN_ENQID">
                                                                            <HeaderStyle Font-Size="Smaller" />
                                                                        </asp:BoundField>

                                                                        <asp:BoundField DataField="FLOORPLAN_RECEIVEDDATE" HeaderText="Received Date" SortExpression="FLOORPLAN_RECEIVEDDATE" DataFormatString="{0:dd/MM/yyyy}">
                                                                            <HeaderStyle Font-Size="Smaller" />
                                                                        </asp:BoundField>

                                                                        <asp:BoundField DataField="FLOORPLAN_REMARKS" HeaderText="Remarks" SortExpression="FLOORPLAN_REMARKS">
                                                                            <HeaderStyle Font-Size="Smaller" />
                                                                        </asp:BoundField>

                                                                        <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                                                                            <ItemTemplate>
                                                                                <span class="text-center">
                                                                                    <asp:HyperLink ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" Target="_blank" PostBackUrl='<%# "~/Content/FloorPlanDrawings/" + Eval("FLOORPLAN_DOCUMENTS") %>'><i class="icon-attachment"></i></asp:HyperLink>
                                                                                </span>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="CustomerPanel" runat="server" visible="true" class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Customer Details</h6>
                        </div>
                        <div class="panel-body">

                            <div class="form-horizontal">

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Customer:</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlcustomer" AutoPostBack="true" OnSelectedIndexChanged="ddlcustomer_SelectedIndexChanged" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="panel-group block">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h6 class="panel-title">
                                                <a data-toggle="collapse" href="#collapse-group1">Address and Contact <b class="caret"></b></a>
                                            </h6>
                                        </div>
                                        <div id="collapse-group1" class="panel-collapse collapse">
                                            <div class="panel-body">

                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label text-right">Customer Address :</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtCustomerAddress" CssClass="form-control" runat="server">
                                                        </asp:TextBox>
                                                    </div>
                                                    <%--  <label class="col-sm-2 control-label text-right">Shipping Address :</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtshippingaddress" CssClass="form-control" runat="server">
                                                        </asp:TextBox>
                                                    </div>--%>
                                                </div>

                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label text-right">Contact Person :</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtContactperson" CssClass="form-control" runat="server">
                                                        </asp:TextBox>
                                                    </div>
                                                    <label class="col-sm-2 control-label text-right">Mobile No :</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtContactMobileNo" CssClass="form-control" runat="server">
                                                        </asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h6 class="panel-title">
                                                <a data-toggle="collapse" href="#collapse-group2">Customer Site Information<b class="caret"></b></a>
                                            </h6>
                                        </div>
                                        <div id="collapse-group2" class="panel-collapse">
                                            <div class="panel-body">
                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label text-right">Site Name :</label>
                                                    <div class="col-sm-4">
                                                        <asp:DropDownList ID="ddlsite" AutoPostBack="true" OnSelectedIndexChanged="ddlsite_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <label class="col-sm-2 control-label text-right">Site Address :</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtsiteaddress" CssClass="form-control" runat="server">
                                                        </asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label text-right">Contact Person :</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtsiteContactperson" CssClass="form-control" runat="server">
                                                        </asp:TextBox>
                                                    </div>
                                                    <label class="col-sm-2 control-label text-right">Mobile No :</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtsiteMobileno" CssClass="form-control" runat="server">
                                                        </asp:TextBox>
                                                    </div>
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
                        <div class="form-horizontal">
                            <div class="panel-body">

                                <div class="form-group">

                                    <label class="col-sm-2 control-label text-right">Sales Person :  </label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlSalesEmployee" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Designer :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlDesigner" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">

                                    <label class="col-sm-2 control-label text-right">Aluminum Color :  </label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtaluminiumColor" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Hardware Color :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtHardwareColoritem" Width="100%" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">

                                    <label class="col-sm-2 control-label text-right">Windload :  </label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtWindload" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Add Items</h6>
                            <span class="pull-right">
                                <%--  <asp:Button ID="btnShow" runat="server" CssClass="btn btn-info" Text="Changables" />--%>

                                <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal">Changables</button>

                                <%--  <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="QPanel" TargetControlID="btnShow"
                                    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>--%>
                        </div>
                        <div class="panel-body">

                            <%--<div class="form-group">
                                <div class="row">

                                    <div class="col-md-1"></div>

                                    <div class="col-md-1">
                                        <label>Code :</label>
                                        <asp:TextBox ID="txtCode" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Width :  </label>
                                        <asp:TextBox ID="txtwidth" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Height :  </label>
                                        <asp:TextBox ID="txtheight" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Sill Height :  </label>
                                        <asp:TextBox ID="txtsillHeight" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Series :</label>
                                        <asp:TextBox ID="txtseries" CssClass="form-control" Width="100%" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Quantity :  </label>
                                        <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Glass :  </label>
                                        <asp:TextBox ID="txtGlass" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-1">
                                        <label>Flyscreen :  </label>
                                        <asp:TextBox ID="txtflyscreen" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-1">
                                        <label>Amount :  </label>
                                        <asp:TextBox ID="txtamount" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>--%>

                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h6 class="panel-title"><a data-toggle="collapse" href="#collapse-group5">Upload Quatation Item Template <b class="caret"></b></a></h6>
                                            <span class="pull-right">
                                                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-danger" NavigateUrl="~/Content/Templates/Quotation_Template.xlsx">Download Excel Template</asp:HyperLink></span>
                                        </div>
                                        <div id="collapse-group5" class="panel-collapse">
                                            <div class="panel-body">
                                                <div class="form-horizontal">

                                                    <div class="form-group">
                                                        <div class="row ">
                                                            <label class="col-sm-2 control-label text-right">Select a file :</label>
                                                            <div class="col-sm-3">
                                                                <asp:FileUpload ID="FileUpload" CssClass="styled form-control" type="file" runat="server" />
                                                            </div>

                                                            <div class="col-sm-2 text-left">
                                                                <asp:Button ID="btnUploadExcel" CssClass="btn btn-primary" OnClick="btnUploadExcel_Click" runat="server" Text="Excel Upload" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Window Code :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtCode" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <label class="col-sm-2 control-label text-right">System :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtSystem" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Description :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <label class="col-sm-2 control-label text-right">Glass :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtGlass" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Location :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <label class="col-sm-2 control-label text-right">Mesh :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtMesh" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Profile Color :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtProfileColor" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <label class="col-sm-2 control-label text-right">Hardware Color :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtHardwareColor" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Width(MM) :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtWidth" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <label class="col-sm-2 control-label text-right">Height(MM) :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtHeight" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Qty :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtItemQty" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <label class="col-sm-2 control-label text-right">Total Area(Sq mt) :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txttotalarea" Enabled="true" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Profile Cost PerUnit in Euro :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtProfileCostEuro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtProfileCostEuro_TextChanged" runat="server"></asp:TextBox>
                                        </div>

                                        <label class="col-sm-2 control-label text-right">Cost for total Qty in Euro :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtTotalProfileCostEuro" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Total Price in INR :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txttotalpriceininr" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label class="col-sm-2 control-label text-right">Glass Price :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtGlassPrice" AutoPostBack="true" OnTextChanged="txtGlassPrice_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">SS Mesh Price(Per Sqmt) :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtSsmeshPrice" AutoPostBack="true" OnTextChanged="txtSsmeshPrice_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <label class="col-sm-2 control-label text-right">Recractable Mesh Price :</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtRecractableMesh" AutoPostBack="true" OnTextChanged="txtRecractableMesh_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">MS Insert Price:(Window)</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtMSInsertPrice" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtMSInsertPrice_TextChanged" runat="server"></asp:TextBox>
                                        </div>

                                        <label class="col-sm-2 control-label text-right">Total Amount:</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtitemtotalamount" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h6 class="panel-title">
                                                <a data-toggle="collapse" href="#collapse-group4">Extra Glass Details<b class="caret"></b></a>
                                            </h6>
                                        </div>

                                        <div id="collapse-group4" class="panel">
                                            <div class="panel-body">
                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label text-right">Glass Width :</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtextraglasswidth" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <label class="col-sm-2 control-label text-right">Glass Height :</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtextraglassHeight" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label text-right">Glass Qty :</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtextraglassQty" OnTextChanged="txtextraglassQty_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>

                                                    <label class="col-sm-2 control-label text-right">Area :</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtextraglassArea" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label text-right">Extra Glass Price :</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtExtraGlassprice" CssClass="form-control" OnTextChanged="txtExtraGlassprice_TextChanged" runat="server"></asp:TextBox>
                                                    </div>

                                                    <label class="col-sm-2 control-label text-right">Extra Hardware Price :</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtExtraHardware" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtExtraHardware_TextChanged" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="row">

                                            <div class="text-center">

                                                <asp:Button ID="btnReset" CssClass="btn btn-danger " runat="server" Text="Reset" OnClick="btnReset_Click" />
                                                <asp:Button ID="btnAddItems" CssClass="btn btn-primary" runat="server" Text="Add Item" OnClick="btnAddItems_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body">
                                        <div class="datatable">

                                            <div class="row" style="padding-top: 0px">
                                                <%--<asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                            Width="100%" OnRowDataBound="gvitems_RowDataBound" OnRowDeleting="gvitems_RowDeleting">
                                            <Columns>
                                                <asp:CommandField ShowEditButton="True" />
                                                <asp:CommandField ShowDeleteButton="True" />
                                                <asp:BoundField DataField="CodeNo" HeaderText="Code No" />
                                                <asp:BoundField DataField="Width" HeaderText="Width" />
                                                <asp:BoundField DataField="height" HeaderText="height" />
                                                <asp:BoundField DataField="SillHeight" HeaderText="SillHeight" />
                                                <asp:BoundField DataField="Series" HeaderText="Series" />
                                                <asp:TemplateField HeaderText="Qty">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtitemqty" CssClass="form-control" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Glass" HeaderText="Glass" />
                                                <asp:BoundField DataField="FlyScreen" HeaderText="FlyScreen" />
                                                <asp:TemplateField HeaderText="Unit Price">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtitemamount" OnTextChanged="txtitemamount_TextChanged" CssClass="form-control" runat="server" AutoPostBack="true" Text='<%# Bind("Amount") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmount" Text='<%# Bind("TotalAmount") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="text-align: center">
                                                    <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>--%>

                                                <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                                    Width="100%" OnRowDataBound="gvitems_RowDataBound" OnRowDeleting="gvitems_RowDeleting">
                                                    <Columns>
                                                        <asp:CommandField ShowEditButton="True" />
                                                        <asp:CommandField ShowDeleteButton="True" />
                                                        <asp:BoundField DataField="CodeNo" HeaderText="Window Code" />
                                                        <asp:BoundField DataField="System" HeaderText="System" />
                                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                                        <asp:BoundField DataField="Glass" HeaderText="Glass" />
                                                        <asp:BoundField DataField="Location" HeaderText="Location" />
                                                        <asp:BoundField DataField="Mesh" HeaderText="Mesh" />
                                                        <asp:BoundField DataField="Width" HeaderText="Width(MM)" />
                                                        <asp:BoundField DataField="height" HeaderText="Height(MM)" />
                                                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                                        <asp:BoundField DataField="TotalArea" HeaderText="TotalArea" />
                                                        <asp:BoundField DataField="ProfileColor" HeaderText="ProfileColor" />
                                                        <asp:BoundField DataField="HardwareColor" HeaderText="HardwareColor" />

                                                        <asp:TemplateField HeaderText="Cost PerUnit Euro">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtItemUnitCostEuro" CssClass="form-control" runat="server" Text='<%# Bind("UnitCostEuro") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Glass Price">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtItemGlassPrice" CssClass="form-control" runat="server" Text='<%# Bind("ItemGlassPrice") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Mesh Price">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtItemMeshPrice" CssClass="form-control" runat="server" Text='<%# Bind("ItemMeshPrice") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Recractable Price">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtItemRecractablePrice" CssClass="form-control" runat="server" Text='<%# Bind("ItemRecractablePrice") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="MSInsert Price">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtItemMSInsertPrice" CssClass="form-control" runat="server" Text='<%# Bind("ItemMSInsertPrice") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Extra Glass Width">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtItemExtraGlasswidth" CssClass="form-control" runat="server" Text='<%# Bind("ItemExtraGlasswidth") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Extra Glass Height">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtItemExtraGlassheight" CssClass="form-control" runat="server" Text='<%# Bind("ItemExtraGlassheight") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Extra Glass Qty">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtItemExtraGlassQty" CssClass="form-control" runat="server" Text='<%# Bind("ItemExtraGlassQty") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Extra Glass Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtItemExtraGlassArea" CssClass="form-control" runat="server" Text='<%# Bind("ItemExtraGlassArea") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Extra Glass Price">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtItemExtraGlassPrice" CssClass="form-control" runat="server" Text='<%# Bind("ItemExtraGlassPrice") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Hardware Price">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtItemHardwarePrice" CssClass="form-control" runat="server" Text='<%# Bind("ItemHardwarePrice") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Total Amount">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txttotalAmount" Text='<%# Bind("TotalAmount") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
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

                                    <div class="form-group" id="labels" runat="server" visible="false">

                                        <div class="row">

                                            <div class="col-md-1">
                                                <asp:Label ID="lblTotalProfileCost" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Label ID="lblTotalWastageCost" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalGlasspriceCost" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalMsCost" runat="server" Text=""></asp:Label>
                                            </div>

                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalWallplugwithscrews" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalSilicon" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalmaskingtape" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalBackersRod" runat="server" Text=""></asp:Label>
                                            </div>

                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalSSmesh" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalRecractableMesh" runat="server" Text=""></asp:Label>
                                            </div>

                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalfabrication" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalinstallation" runat="server" Text=""></asp:Label>
                                            </div>

                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalCost" runat="server" Text=""></asp:Label>
                                            </div>

                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalmargin" runat="server" Text=""></asp:Label>
                                            </div>

                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalamount" runat="server" Text=""></asp:Label>
                                            </div>

                                            <div class="col-md-1">
                                                <asp:Label ID="lblct" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Label ID="lbltotalextraglassprice" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-body">
                                <div class="row invoice-payment">
                                    <div class="col-sm-4">
                                    </div>
                                    <div class="col-sm-4">
                                    </div>
                                    <div class="col-sm-4">
                                        <h6>Total:</h6>
                                        <table class="table">
                                            <tbody>
                                                <tr>
                                                    <th>Subtotal :</th>
                                                    <td class="text-right">
                                                        <asp:TextBox ID="txtsubtotal" CssClass="form-control" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <th>Discount(%) :</th>
                                                    <td class="text-right">
                                                        <asp:TextBox ID="txtdiscount" CssClass="form-control" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <th>GST(%) :</th>
                                                    <td class="text-right">
                                                        <asp:TextBox ID="txttax" CssClass="form-control" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <th>Total :</th>
                                                    <td class="text-right">
                                                        <asp:TextBox ID="txttotal" CssClass="form-control" runat="server"></asp:TextBox></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-body">
                                <div class="bg-primary with-padding block-inner">Specifications</div>
                                <div class="form-horizontal">

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Specifications :</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtSpecifications" Width="100%" CssClass="form-control" TextMode="MultiLine" Height="250px" runat="server"></asp:TextBox>

                                            <cc1:HtmlEditorExtender
                                                ID="HtmlEditorExtender5" TargetControlID="txtSpecifications" EnableSanitization="false" DisplaySourceTab="false"
                                                runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-body">
                                <div class="bg-primary with-padding block-inner">Payment Terms & Condtions</div>
                                <div class="form-horizontal">

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Payment Terms:</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlpaymentterms" OnSelectedIndexChanged="ddlpaymentterms_SelectedIndexChanged" AutoPostBack="true" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Payment Terms Details:</label>
                                        <div class="col-sm-10">
                                            <%--<asp:Literal ID="txtpaymenttermsdetails" runat="server"></asp:Literal>--%>
                                              <asp:TextBox ID="txtpaymenttermsdetails" Width="100%" CssClass="form-control" TextMode="MultiLine" Height="250px" runat="server"></asp:TextBox>
                                               <cc1:HtmlEditorExtender
                                                ID="HtmlEditorExtender1" TargetControlID="txtpaymenttermsdetails" EnableSanitization="false" DisplaySourceTab="false"
                                                runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-body">
                                <div class="bg-primary with-padding block-inner">Terms & Conditions</div>
                                <div class="form-horizontal">

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Terms & Conditions :</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddltermscondtions" OnSelectedIndexChanged="ddltermscondtions_SelectedIndexChanged" AutoPostBack="true" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Terms & Condtion Details:</label>
                                        <div class="col-sm-10">
                                            <%--<asp:Literal ID="txttermsconditions" runat="server"></asp:Literal>--%>
                                                <asp:TextBox ID="txttermsconditions" Width="100%" CssClass="form-control" TextMode="MultiLine" Height="250px" runat="server"></asp:TextBox>
                                               <cc1:HtmlEditorExtender
                                                ID="Editor1" TargetControlID="txttermsconditions" EnableSanitization="false" DisplaySourceTab="false"
                                                runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-body">
                                <div class="bg-primary with-padding block-inner">Storage Terms </div>
                                <div class="form-horizontal">

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Storage Terms :</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlStroageTerms" OnSelectedIndexChanged="ddlStroageTerms_SelectedIndexChanged" AutoPostBack="true" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Storage Terms Details:</label>
                                        <div class="col-sm-10">
                                            <%--<asp:Literal ID="txtStroagetermsdetails" runat="server"></asp:Literal>--%>
                                              <asp:TextBox ID="txtStroagetermsdetails" Width="100%" CssClass="form-control" TextMode="MultiLine" Height="250px" runat="server"></asp:TextBox>
                                            <cc1:HtmlEditorExtender ID="HtmlEditorExtender2" TargetControlID="txtStroagetermsdetails" EnableSanitization="false" DisplaySourceTab="false" runat="server" />
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-body">
                                <div class="bg-primary with-padding block-inner">Damage Terms </div>
                                <div class="form-horizontal">

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Damage Terms :</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlDamageTerms" OnSelectedIndexChanged="ddlDamageTerms_SelectedIndexChanged" AutoPostBack="true" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Damage Terms Details:</label>
                                        <div class="col-sm-10">
                                          <%--  <asp:Literal ID="txtDamageterms" runat="server"></asp:Literal>--%>
                                              <asp:TextBox ID="txtDamageterms" Width="100%" CssClass="form-control" TextMode="MultiLine" Height="250px" runat="server"></asp:TextBox>
                                             <cc1:HtmlEditorExtender ID="HtmlEditorExtender3" TargetControlID="txtDamageterms" EnableSanitization="false" DisplaySourceTab="false" runat="server" />
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-body">
                                <div class="bg-primary with-padding block-inner">Installation Terms </div>
                                <div class="form-horizontal">

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Installation Terms :</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlInstallation" OnSelectedIndexChanged="ddlInstallation_SelectedIndexChanged" AutoPostBack="true" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label text-right">Installation Terms Details:</label>
                                        <div class="col-sm-10">
                                       <%--     <asp:Literal ID="txtInstallationTerms" runat="server"></asp:Literal>--%>
                                               <asp:TextBox ID="txtInstallationTerms" Width="100%" CssClass="form-control" TextMode="MultiLine" Height="250px" runat="server"></asp:TextBox>
                                             <cc1:HtmlEditorExtender ID="HtmlEditorExtender4" TargetControlID="txtInstallationTerms" EnableSanitization="false" DisplaySourceTab="false" runat="server" />
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="bg-primary with-padding block-inner">Office Details</div>
                            <div class="form-horizontal">

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Prepared By :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlpreparedby" Enabled="false" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>

                                    <label class="col-sm-2 control-label text-right">Approved By:</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlapprovedby" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel-body">

                            <div class="form-actions text-right">
                                <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-warning" Text="Print" OnClick="btnPrint_Click" />
                                  <asp:Button ID="btnOptions" runat="server" CssClass="btn btn-info" Text="Options" OnClick="btnOptions_Click" />
                                <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-success" Text="Approve" OnClick="btnApprove_Click" />
                                <asp:Button ID="btnRevise" runat="server" CssClass="btn btn-info" Text="Revise" OnClick="btnRevise_Click" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" OnClientClick="return confirmDelete();" />


                                <asp:Label ID="lbloptions" runat="server" Text=""></asp:Label>
                                 <asp:Label ID="lblRevise" runat="server" Text=""></asp:Label>


                            </div>
                        </div>
                    </div>

                    <div id="myModal" class="modal fade" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Quatation Changables</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:Panel ID="QPanel" runat="server">

                                        <div class="form-horizontal">
                                            <div class="panel panel-default">
                                                <div class="panel-body">

                                                    <div class="form-group">
                                                        <label class="col-sm-2 control-label text-right">Euro Price(In INR) :</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtEuroPrice" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="col-sm-2 control-label text-right">Freight(%) :</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtFreight" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>

                                                        <label class="col-sm-2 control-label text-right">Customs(%) :</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtCustoms" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="col-sm-2 control-label text-right">Insurance(%) :</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtInsurance" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>

                                                        <label class="col-sm-2 control-label text-right">Clearance(%) :</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtClearance" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="col-sm-2 control-label text-right">Wastage(%) :</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtwastage" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="col-sm-2 control-label text-right">Wall Plugs(Rs) :</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtWallplugs" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>

                                                        <label class="col-sm-2 control-label text-right">Silicon(Rs) :</label>
                                                        <div class="col-sm-1">
                                                            <asp:TextBox ID="txtSilicon" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                        <label class="col-sm-1 control-label text-right">Width*Depth:</label>
                                                        <div class="col-sm-1">
                                                            <asp:TextBox ID="txtSiliconWidth" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-1">
                                                            <asp:TextBox ID="txtSiliconDepth" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="col-sm-2 control-label text-right">Masking Tape(Rs) :</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtmaskingpape" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>

                                                        <label class="col-sm-2 control-label text-right">BackorRod(Rs) :</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtbackrod" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="col-sm-2 control-label text-right">Fabrication(Per Sq ft)(Rs) :</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtFabricationPersqft" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>

                                                        <label class="col-sm-2 control-label text-right">Fabrication(Per Sq ft)(Rs) :</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtfabricationPersqmt" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="col-sm-2 control-label text-right">Installation(Per Sq Ft)(Rs) :</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtinstallationpersqft" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>

                                                        <label class="col-sm-2 control-label text-right">Installation(Per Sq Mt)(Rs):</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtInstallationpersqmt" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="col-sm-2 control-label text-right">Margin(%) :</label>
                                                        <div class="col-sm-4">
                                                            <asp:TextBox ID="txtmargin" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--  </ContentTemplate>

        <Triggers>

            <asp:PostBackTrigger ControlID="btnUploadExcel" />

            <asp:AsyncPostBackTrigger ControlID="txtGlassPrice" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtMSInsertPrice" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtSsmeshPrice" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtRecractableMesh" EventName="TextChanged" />

            <asp:AsyncPostBackTrigger ControlID="txtextraglassQty" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtExtraGlassprice" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtExtraHardware" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>--%>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUploadExcel" />
            <%--   <asp:AsyncPostBackTrigger ControlID="btSubmit" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>