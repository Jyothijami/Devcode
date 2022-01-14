<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SalesOrder_Details.aspx.cs" Inherits="Modules_Sales_SalesOrder_Details" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
                 window.location = 'SalesOrder.aspx';
             }).catch(function (reason) {
                 // The action was canceled by the user
             });

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
    
  
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="SalesOrder.aspx">Sales Order</a></li>
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
                                         <asp:DropDownList ID="ddlCustomer" CssClass="select-full" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    </div>
                                  <label class="col-sm-2 control-label text-right">Order Type :</label>
                                    <div class="col-sm-4">
                                         <asp:DropDownList ID="ddlOrdertype" CssClass="form-control" runat="server">
                                              <asp:ListItem>Sales</asp:ListItem>
                                              <asp:ListItem>Maintance</asp:ListItem>
                                         </asp:DropDownList>
                                    </div>
                                   
                                </div>

                                <div class="form-group">
                                   
                                    <label class="col-sm-2 control-label text-right">Customer PO No:</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtCustPurchaseOrder"  CssClass="form-control" runat="server" ></asp:TextBox>
                                    </div>


                                      <label class="col-sm-2 control-label text-right">Project Code :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtProjectCode"  CssClass="form-control" runat="server" ></asp:TextBox>
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
                             <div class="panel-group block">
								<div class="panel panel-default">
									<div class="panel-heading">
										<h6 class="panel-title">
											<a data-toggle="collapse" href="#collapse-group1">Address and Contact <b class="caret"></b></a>
										</h6>
									</div>
									<div id="collapse-group1" class="panel-collapse">
										<div class="panel-body">
											
                                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Billing Address :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtCustomerAddress" CssClass="form-control" runat="server">
                                             
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
									<div id="collapse-group2" class="panel-collapse">
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



                                      <div class="bg-primary with-padding block-inner">Details</div>
                                   <div class="form-horizontal">
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
                                                 <asp:BoundField DataField="CodeNo" HeaderText="Window Code" />
                                                 <asp:BoundField DataField="Series" HeaderText="System" />
                                                 <asp:BoundField DataField="Width" HeaderText="Width" />
                                                 <asp:BoundField DataField="height" HeaderText="height" />
                                                 <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                                <asp:BoundField DataField="Glass" HeaderText="Glass" />
                                                <asp:BoundField DataField="Mesh" HeaderText="Mesh" />
                                                <asp:BoundField DataField="ProfileColor" HeaderText="Profile Color" />
                                                <asp:BoundField DataField="HardwareColor" HeaderText="Hardware Color" />
                                                <asp:BoundField DataField="TotalArea" HeaderText="Area" />
                                                <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                                                               
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
                                <div class="datatable">

                                    <div class="row" style="padding-top: 0px">
                                        <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                            Width="100%" OnRowDataBound="gvitems_RowDataBound" OnRowDeleting="gvitems_RowDeleting">
                                            <Columns>
                                                <asp:CommandField ShowEditButton="True" />
                                                <asp:CommandField ShowDeleteButton="True" />
                                                <asp:BoundField DataField="CodeNo" HeaderText="Window Code" />
                                               <%--  <asp:TemplateField  HeaderText="Item Code" >
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlitemcodes" CssClass="select-full" OnSelectedIndexChanged="ddlitemcodes_SelectedIndexChanged" AutoPostBack="true" runat="server" ></asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField  HeaderText="Color" >
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlitemColors" CssClass="form-control" runat="server"  ></asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                  <asp:BoundField DataField="Series" HeaderText="System" />
                                                <asp:BoundField DataField="Width" HeaderText="Width" />
                                                <asp:BoundField DataField="height" HeaderText="height" />
                                                <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                                <asp:BoundField DataField="Glass" HeaderText="Glass" />
                                                <asp:BoundField DataField="Mesh" HeaderText="Mesh" />
                                                <asp:BoundField DataField="ProfileColor" HeaderText="Profile Color" />
                                                <asp:BoundField DataField="HardwareColor" HeaderText="Hardware Color" />
                                                <asp:BoundField DataField="TotalArea" HeaderText="Area" />
                                                <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                                                  <asp:TemplateField  HeaderText="Delivery Date" >
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtdeliveryDate" CssClass="form-control" ClientIDMode="AutoID" runat="server"  Text='<%# Bind("ItemDeliverydate") %>'></asp:TextBox>
                                                        
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender4" runat="server" 
                                            TargetControlID="txtdeliveryDate">
                                        </cc1:CalendarExtender>

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

                            
                    </div>






                         



                    </div>

                    </div>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="form-horizontal">


                                 <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Alumil Systems :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtalumilsystem"  CssClass="form-control" runat="server" ></asp:TextBox>
                                    </div>
                                   
                                </div>


                                  <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Window Color :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtwindowcolor"  CssClass="form-control" runat="server" ></asp:TextBox>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Hardware Color :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txthardwarecolor"  CssClass="form-control" runat="server" ></asp:TextBox>
                                    </div>
                                </div>

                                  <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Total Area :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txttotalarea"  CssClass="form-control" runat="server" ></asp:TextBox>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Total Qty :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txttotalqty"  CssClass="form-control" runat="server" ></asp:TextBox>
                                    </div>
                                </div>


                                  <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Delivery Complete Date :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtDeliveryDate"  CssClass="form-control" runat="server" ></asp:TextBox>
                                    <asp:Image
                                            ID="Image3" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender3" runat="server" PopupButtonID="Image3"
                                            TargetControlID="txtDeliveryDate">
                                        </cc1:CalendarExtender>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Installation Complete Date :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtInstallationDate"  CssClass="form-control" runat="server" ></asp:TextBox>
                                    <asp:Image
                                            ID="Image2" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="Image2"
                                            TargetControlID="txtInstallationDate">
                                        </cc1:CalendarExtender>
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
                                    <label class="col-sm-2 control-label text-right">Payment Terms Details:</label>
                                    <div class="col-sm-10">
                                          <asp:TextBox ID="txtpaymenttermsdetails" Width="100%"  CssClass="editor" runat="server"></asp:TextBox>
                                              <cc1:HtmlEditorExtender
                                                ID="HtmlEditorExtender5" TargetControlID="txtpaymenttermsdetails" EnableSanitization="false" DisplaySourceTab="false"
                                                runat="server" /> 
                                    
                                    </div>
                                   </div>

                            </div>
                                </div>


                            <div class="panel-body">
                                <div class="bg-primary with-padding block-inner">Terms & Conditions</div>
                                   <div class="form-horizontal">
                                         <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Terms & Condtion Details:</label>
                                    <div class="col-sm-10">
                                          <asp:TextBox ID="txttermsconditions" Width="100%" TabIndex="2" CssClass="editor" runat="server"></asp:TextBox>
                                          <cc1:HtmlEditorExtender
                                                ID="HtmlEditorExtender1" TargetControlID="txttermsconditions" EnableSanitization="false" DisplaySourceTab="false"
                                                runat="server" /> 
                                        
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


                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Status :</label>
                                    <div class="col-sm-4">
                                          <asp:DropDownList ID="ddlstatus" Width="100%" TabIndex="2" CssClass="form-control" runat="server">
                                              <asp:ListItem>New</asp:ListItem>
                                              <asp:ListItem>Not Confirmed</asp:ListItem>
                                              <asp:ListItem>Running</asp:ListItem>
                                                <asp:ListItem>Cancelled</asp:ListItem>
                                              <asp:ListItem>Completed</asp:ListItem>
                                          </asp:DropDownList>
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
                
     
                </div>

</asp:Content>

