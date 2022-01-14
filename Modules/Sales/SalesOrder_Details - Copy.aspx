<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="SalesOrder_Details - Copy.aspx.cs" Inherits="Modules_Sales_SalesOrder_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <%-- <script type="text/javascript">
         //On Page Load
         $(function () {
             $(".select-full").select2();
             //$("#select-full").select2();
             //$("#tabs").tabs();
         });

         //On UpdatePanel Refresh
         var prm = Sys.WebForms.PageRequestManager.getInstance();
         if (prm != null) {
             prm.add_endRequest(function (sender, e) {
                 if (sender._postBackSettings.panelsToUpdate != null) {
                     $(".select-full").select2();
                     //$("#select-full").select2();
                     //$("#tabs").tabs();
                 }
             });
         };
            </script>--%>
     <script type="text/javascript">

         function grosscalc() {
             var Tax, grossamt, TOTAL, dis;
             Tax = document.getElementById('<%=txttax.ClientID %>').value;
            dis = document.getElementById('<%=txtdiscount.ClientID %>').value;
            grossamt = parseFloat(document.getElementById('<%=txttotal.ClientID %>').value);
            if (Tax == "" || Tax == "0" || isNaN(Tax)) { Tax = "0"; }
            if (dis == "" || dis == "0" || isNaN(dis)) { dis = "0"; }

            TOTAL = parseFloat(grossamt);
            TOTAL = TOTAL + ((Tax * TOTAL) / 100);
            TOTAL = TOTAL - ((dis * TOTAL) / 100);

            document.getElementById('<%=txttotal.ClientID %>').value = parseInt(TOTAL);
        }
    </script>
    <script type = "text/javascript">
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


            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Sales Order Details</h3>
                </div>
            </div>
    
     <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
        
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="SalesQuotation.aspx">Sales Order</a></li>
                    <li class="active">Sales Order Details</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Sales Order Details</h6>
                </div>
                <div class="panel-body">

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Basic Details</h6>
                        </div>
                        <div class="panel-body">

                            <div class="form-horizontal">


                                 <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Sales Order No:</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtsalesorderno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Order Date:</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtSalesorderdate"  CssClass="form-control" runat="server" ></asp:TextBox>
                                    <asp:Image
                                            ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                                            TargetControlID="txtSalesorderdate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Customer :</label>
                                    <div class="col-sm-4">
                                         <asp:DropDownList ID="ddlCustomer" CssClass="select-full" Width="100%" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Delivery Date:</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtDeliveryDate"  CssClass="form-control" runat="server" ></asp:TextBox>
                                    <asp:Image
                                            ID="Image3" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender3" runat="server" PopupButtonID="Image3"
                                            TargetControlID="txtSalesorderdate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Order Type :</label>
                                    <div class="col-sm-4">
                                         <asp:DropDownList ID="ddlOrdertype" CssClass="form-control" runat="server">
                                              <asp:ListItem>Sales</asp:ListItem>
                                              <asp:ListItem>Maintance</asp:ListItem>
                                         </asp:DropDownList>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Customer Purchase Order:</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtCustPurchaseOrder"  CssClass="form-control" runat="server" ></asp:TextBox>
                                    </div>
                                </div>



                            


                            </div>

                        </div>
                    </div>



                    <div class="panel panel-default" runat="server" visible="true" id="panelEnquirydetails">
                        <div class="panel-heading">
                            <h6 class="panel-title">Quotation Details</h6>
                        </div>
                        <div class="panel-body">
                              <div class="form-horizontal">

                                  <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Quotation No:</label>
                                    <div class="col-sm-4">
                                          <asp:DropDownList ID="ddlQuotationno" AutoPostBack="true" OnSelectedIndexChanged="ddlQuotationno_SelectedIndexChanged"  Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Quotation Date:</label>
                                    <div class="col-sm-4">
                                          <asp:TextBox ID="txtquotationdate"  CssClass="form-control" runat="server" ></asp:TextBox>
                                        <asp:Image
                                            ID="Image4" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender4" runat="server" PopupButtonID="Image4"
                                            TargetControlID="txtquotationdate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                            
                        </div>

                             <div class="panel-group block">
								<div class="panel panel-default">
									<div class="panel-heading">
										<h6 class="panel-title">
											<a data-toggle="collapse"  href="#collapse-group12">Details<b class="caret"></b></a>
										</h6>
									</div>
                                    <div id="collapse-group12" class="panel-collapse collapse">
                                        <div class="panel-body">

                                        <div class="well block">
                                    <div class="tabbable">
                                        <ul class="nav nav-pills nav-justified">
                                            <li class="active"><a href="#default-pill1" data-toggle="tab">Windows & Door Details</a></li>
                                            <li><a href="#default-pill2" data-toggle="tab">Documents </a></li>
                                          
                                           
                                        </ul>

                                        <div class="tab-content pill-content">

                                            <%-- Windows and DoorSchedule--%>

                                            <div class="tab-pane fade in active" id="default-pill1">

                                                <div class="form-group">

                                                    <div class="row" style="padding-top: 30px">
                                                        <asp:GridView ID="gvQuatationItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                                            Width="100%" OnRowDataBound="gvQuatation_RowDataBound">
                                                            <Columns>

                                                                    <asp:TemplateField>
        <HeaderTemplate>
            <asp:CheckBox ID="chkAll" runat="server" onclick = "checkAll(this);" 
            AutoPostBack = "true"  OnCheckedChanged = "CheckBox_CheckChanged"/>
        </HeaderTemplate> 
        <ItemTemplate>
            <asp:CheckBox ID="chk" runat="server" onclick = "Check_Click(this)" 
            AutoPostBack = "true"  OnCheckedChanged = "CheckBox_CheckChanged" />
        </ItemTemplate>
    </asp:TemplateField> 
                                                 <asp:BoundField DataField="CodeNo" HeaderText="Code No" />
                                                 <asp:BoundField DataField="Width" HeaderText="Width" />
                                                 <asp:BoundField DataField="height" HeaderText="height" />
                                                 <asp:BoundField DataField="SillHeight" HeaderText="SillHeight" />
                                                 <asp:BoundField DataField="Series" HeaderText="Series" />
                                                <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                                <asp:BoundField DataField="Glass" HeaderText="Glass" />
                                                <asp:BoundField DataField="FlyScreen" HeaderText="FlyScreen" />
                                                <asp:BoundField DataField="Amount" HeaderText="Unit Price" />
                                                <asp:BoundField DataField="TotalAmount" HeaderText="Amount" />
                                                               
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
                                            <%--Qutation Documents --%>
                                            <div class="tab-pane fade" id="default-pill2">

                                                
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
                                         <asp:DropDownList ID="ddlQuotCust" AutoPostBack="true" OnSelectedIndexChanged="ddlQuotCust_SelectedIndexChanged"  CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                                    </div>
                                  
                                </div>


                             <div class="panel-group block">
								<div class="panel panel-default">
									<div class="panel-heading">
										<h6 class="panel-title">
											<a data-toggle="collapse" href="#collapse-group1">Address and Contact <b class="caret"></b></a>
										</h6>
									</div>
									<div id="collapse-group1" class="panel-collapse collapse in">
										<div class="panel-body">
											
                                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Customer Address :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtCustomerAddress" CssClass="form-control" runat="server">
                                             
                                         </asp:TextBox>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Shipping Address :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtshippingaddress" CssClass="form-control" runat="server">
                                             
                                         </asp:TextBox>
                                    </div>
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
									<div id="collapse-group2" class="panel-collapse collapse in">
										<div class="panel-body">
										   <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Site Name :</label>
                                    <div class="col-sm-4">
                                         <asp:DropDownList ID="ddlsite" AutoPostBack="true" OnSelectedIndexChanged="ddlsite_SelectedIndexChanged"  CssClass="form-control" runat="server">
                                             
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


                    <%--<div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Customer Reference Details</h6>
                        </div>
                        <div class="panel-body">

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-3">
                                        <label>PO No:  </label>
                                        <asp:TextBox ID="txtPOno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label>PO Date:  </label>
                                        <asp:TextBox ID="txtPOdate" CssClass="form-control"  runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Req Delivery Date:  </label>
                                        <asp:TextBox ID="txtreqdeliverydate" CssClass="form-control"  runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Net Value:  </label>
                                        <asp:TextBox ID="txtNetValue" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                        <div class="row">
                            <div class="col-md-3">
                                        <label>Pricing Date:  </label>
                                        <asp:TextBox ID="txtPricingDate" CssClass="form-control" runat="server"></asp:TextBox>
                                  <asp:Image
                                            ID="Image2" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="Image2"
                                            TargetControlID="txtPricingDate">
                                        </cc1:CalendarExtender>
                                    </div>
                            <div class="col-md-3">
                                <label>Payment Terms:  </label>
                                <asp:DropDownList ID="ddlpaymentterms" TabIndex="2" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                <label>Incoterms:  </label>
                                <asp:DropDownList ID="ddlincoterms" TabIndex="2" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                             <div class="col-md-3">
                                <label>Rate Per Sq Ft:  </label>
                                  <asp:TextBox ID="txtratepersqft" CssClass="form-control" runat="server"></asp:TextBox>                            </div>
                        </div>
                    </div>

                                <div class="form-group">
                        <div class="row">
                          
                             <div class="col-md-3">
                                <label>Rate Per Sq Mt:  </label>
                                  <asp:TextBox ID="txtratepersqmt" CssClass="form-control" runat="server"></asp:TextBox>                            </div>
                       
                              <div class="col-md-3">
                                <label>Color:  </label>
                                  <asp:DropDownList ID="ddlColor" TabIndex="2" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                       <div class="col-md-3">
                                <label>Windload Considered </label>
                                <asp:TextBox ID="txtwinloadconsidered"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                
                            </div>
                            
                            
                             </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <label>Glass Specification</label>
                                <asp:TextBox ID="txtGlassspecification"  CssClass="form-control" runat="server"></asp:TextBox>
                                                 <%-- <RTE:Editor ID="txtGlassspecification" Height="100px" ToolbarItems="bold,italic,forecolor,backcolor" runat="server" />

                                             
                                                                                           </div>
                                        </div>
                                    </div>

                    </div>

                        </div>
                    </div>--%>


                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Sales Order Items</h6>
                        </div>
                        <div class="panel-body">
                            
                           


                            <div class="panel panel-default">
                        <div class="panel-heading">
                            <h6 class="panel-title">Add Items</h6>
                        </div>
                        <div class="panel-body">
                           <div class="form-group">
                                <div class="row">

                                    
                                   
                                  
                                     <div class="col-md-2">
                                        <label>Item Code :</label>
                                      <asp:DropDownList ID="ddlItemcode" CssClass="select-full" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlItemcode_SelectedIndexChanged"  runat="server"></asp:DropDownList>
                                    </div>
                                     <div class="col-md-1">
                                        <label>Color :</label>
                                      <asp:DropDownList ID="ddlColor" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
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
                                    <div class="col-md-1">
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
                                        <label>Unit Price :  </label>
                                        <asp:TextBox ID="txtamount" CssClass="form-control" runat="server"></asp:TextBox>
                                       
                                    </div>

                                   
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">

                                    <div class="text-center">

                                        <asp:Button ID="btnReset" CssClass="btn btn-danger " runat="server" Text="Reset" OnClick="btnReset_Click" />
                                        <asp:Button ID="btnAddItems" CssClass="btn btn-primary"  runat="server" Text="Add Item" OnClick="btnAddItems_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="panel-body">
                                <div class="datatable">

                                    <div class="row" style="padding-top: 0px">
                                        <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                            Width="100%" OnRowDataBound="gvitems_RowDataBound" OnRowDeleting="gvitems_RowDeleting">
                                            <Columns>
                                                <asp:CommandField ShowEditButton="True" />
                                                <asp:CommandField ShowDeleteButton="True" />
                                                <asp:BoundField DataField="CodeNo" HeaderText="Code No" />
                                                 <asp:TemplateField  HeaderText="Item Code" >
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlitemcodes" CssClass="select-full" OnSelectedIndexChanged="ddlitemcodes_SelectedIndexChanged" AutoPostBack="true" runat="server" ></asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField  HeaderText="Color" >
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlitemColors" CssClass="form-control" runat="server"  ></asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Width" HeaderText="Width" />
                                                <asp:BoundField DataField="height" HeaderText="height" />
                                                <asp:BoundField DataField="SillHeight" HeaderText="SillHeight" />
                                                <asp:BoundField DataField="Series" HeaderText="Series" />
                                                <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                                   
                                                <asp:BoundField DataField="Glass" HeaderText="Glass" />
                                                <asp:BoundField DataField="FlyScreen" HeaderText="FlyScreen" />
                                                <asp:BoundField DataField="Amount" HeaderText="Unit Price" />
                                                 <asp:BoundField DataField="TotalAmount" HeaderText="Amount" />
                                                                                           
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

                            

                            <div class="panel-body">
                                <div class="row invoice-payment">
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                                                                  </div>
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
                                                    <th>Tax(%) :</th>
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












                           



                            



                    </div>

                    </div>






                         



                    </div>

                    </div>


                    <div class="panel panel-default">

                         
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
                                          <asp:TextBox ID="txtpaymenttermsdetails" Width="100%"  CssClass="editor" runat="server"></asp:TextBox>
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
                                          <asp:TextBox ID="txttermsconditions" Width="100%" TabIndex="2" CssClass="editor" runat="server"></asp:TextBox>
                                     </div>
                                   </div>

                            </div>
                                </div>

                           
                              <div class="bg-primary with-padding block-inner">Office Details</div>
                                   <div class="form-horizontal">
                          

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Prepared By :</label>
                                    <div class="col-sm-4">
                                          <asp:DropDownList ID="ddlpreparedby" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                     </div>



                                    <label class="col-sm-2 control-label text-right">Approved By:</label>
                                    <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlapprovedby" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>

                                     </div>

                                   </div>


                                
                            </div>
                        
                                 </div>



                    </div>

                    <div class="form-actions text-right">
                        <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-warning" Text="Print" />
                          <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-success" Text="Approve" />
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click"  />
                    </div>
                
        </ContentTemplate>

        <%--<Triggers>

            <asp:PostBackTrigger ControlID="Button2" />
        </Triggers>--%>
    </asp:UpdatePanel>



</asp:Content>

