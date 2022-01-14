﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SupplierQuotation_Details.aspx.cs" Inherits="Modules_Purchases_SupplierQuotation_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script type="text/javascript">

         function grosscalc() {
             var Tax, grossamt, TOTAL, dis;
             Tax = document.getElementById('<%=txttax.ClientID %>').value;
            dis = document.getElementById('<%=txtdiscount.ClientID %>').value;
            grossamt = parseFloat(document.getElementById('<%=txtsubtotal.ClientID %>').value);
            if (Tax == "" || Tax == "0" || isNaN(Tax)) { Tax = "0"; }
            if (dis == "" || dis == "0" || isNaN(dis)) { dis = "0"; }

            TOTAL = parseFloat(grossamt);
            TOTAL = TOTAL - ((dis * TOTAL) / 100);
            TOTAL = TOTAL + ((Tax * TOTAL) / 100);

            document.getElementById('<%=txttotal.ClientID %>').value = parseInt(TOTAL);
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

    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Supplier Quotation Details</h3>
        </div>
    </div>
   
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="Supplier_Quotation.aspx">Supplier Quotations</a></li>
                    <li class="active">Supplier Quotations Details</li>
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
                                    <label class="col-sm-2 control-label text-right">Supplier :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlSupplier" AutoPostBack="true" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged" CssClass="select-full" Width="100%" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div id="CustomerPanel" runat="server" visible="true" class="panel panel-default">
                    <div class="panel-heading">
                        <h6 class="panel-title"><a data-toggle="collapse" href="#collapse-group1">Supplier Details<b class="caret"></b></a></h6>
                    </div>

                         <div id="collapse-group1" class="panel-collapse">
                    <div class="panel-body">

                        <div class="form-horizontal">

                            <div class="panel-group block">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h6 class="panel-title">
                                            Address and Contact 
                                        </h6>
                                    </div>
                                   
                                        <div class="panel-body">

                                            <div class="form-group">
                                                <label class="col-sm-2 control-label text-right">Supplier Address :</label>
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtsupaddress" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server">
                                                    </asp:TextBox>  
                                                      <cc1:HtmlEditorExtender
                                                ID="HtmlEditorExtender3" TargetControlID="txtsupaddress" EnableSanitization="false" DisplaySourceTab="false"
                                                runat="server" />
                                                </div>
                                               
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-2 control-label text-right">Contact Person :</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtSupContactperson" CssClass="form-control" runat="server">
                                                    </asp:TextBox>
                                                </div>
                                                <label class="col-sm-2 control-label text-right">Mobile No :</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtSupContactMobileNo" CssClass="form-control" runat="server">
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
                            <h6 class="panel-title">Indent Request Details</h6>
                        </div>
                        <div class="panel-body">
                            <div class="form-horizontal">

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Indent Request :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlMaterialrequest" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlMaterialrequest_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                         
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h6 class="panel-title">
                                          Requested Details
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
                                                        <asp:BoundField DataField="ItemCode" HeaderText="Code No" />
                                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                                        <asp:BoundField DataField="Color" HeaderText="Color" />
                                                        <asp:BoundField DataField="Uom" HeaderText="UOM" />
                                                        <asp:BoundField DataField="qtyorder" HeaderText="Req Qty" />
                                                      <%--  <asp:BoundField DataField="Price" HeaderText="Rate" />--%>
                                                        <asp:BoundField DataField="Length" HeaderText="Length" />
                                                        <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                                                        <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                                        <asp:BoundField DataField="SoId" HeaderText="SoId" />
                                                        <asp:BoundField DataField="SoMatId" HeaderText="SoMatId" />
                                                        <asp:BoundField DataField="Requestfor" HeaderText="Requestfor" />
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
                    <div class="panel-heading">
                        <h6 class="panel-title">Add Items</h6>
                    </div>
                    <div class="panel-body">

                        <%--<div class="form-group">
                            <div class="row">

                               

                                <div class="col-md-2">
                                    <label>Item Code :</label>
                                    <asp:DropDownList ID="ddlItemCode" AutoPostBack="true" OnSelectedIndexChanged="ddlItemCode_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <label>Series :  </label>
                                    <asp:TextBox ID="txtitemSeries" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                               
                                <div class="col-md-2">
                                    <label>Stock Uom :  </label>
                                    <asp:TextBox ID="txtUOm" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label>Color :  </label>
                                    <asp:DropDownList ID="ddlItemColor" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                 <div class="col-md-2">
                                    <label>Quantity :  </label>
                                    <asp:TextBox ID="txtitemQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label>Rate :  </label>
                                    <asp:TextBox ID="txtamount" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>



                        <div class="form-horizontal">

                            <div class="form-group">
                                <label class="col-sm-2 control-label text-right">Item Code :</label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlItemCode" Width="100%"  CssClass="select-full" OnSelectedIndexChanged="ddlItemCode_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                </div>
                                <label class="col-sm-2 control-label text-right">Description :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtitemSeries" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label text-right">Quantity :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtitemQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="col-sm-2 control-label text-right">Uom :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtUOm" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label text-right">Color :</label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlItemColor"  Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                                </div>

                                
                                    <label class="col-sm-2 control-label text-right">Length For :</label>
                                <div class="col-sm-4">
                                      <asp:TextBox ID="txtlength" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                              
                            </div>
                              <div class="form-group">
                                <label class="col-sm-2 control-label text-right">Rate :</label>
                                <div class="col-sm-4">
                                     <asp:TextBox ID="txtamount" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>



                                    <label class="col-sm-2 control-label text-right">Required For :</label>
                                <div class="col-sm-4">
                                      <asp:TextBox ID="txtrequiredfor" CssClass="form-control" runat="server"></asp:TextBox>
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
                            <div class="">

                                <div class="row" style="padding-top: 0px">
                                    <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                        Width="100%" OnRowDataBound="gvitems_RowDataBound" OnRowDeleting="gvitems_RowDeleting">
                                        <Columns>
                                            <asp:CommandField ShowEditButton="True" />
                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:BoundField DataField="CodeNo" HeaderText="Code No" />
                                            <asp:BoundField DataField="Series" HeaderText="Description" />
                                            <asp:BoundField DataField="Color" HeaderText="Color" />
                                            <asp:BoundField DataField="Uom" HeaderText="Uom" />
                                             <asp:BoundField DataField="Length" HeaderText="Length" />
                                            <asp:TemplateField HeaderText="Qty">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtitemqty" CssClass="form-control" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit Price">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtitemamount" OnTextChanged="txtitemamount_TextChanged" CssClass="form-control" runat="server" AutoPostBack="true" Text='<%# Bind("Rate") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" Text='<%# Bind("Amount") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ItemcodeId" HeaderText="ItemcodeId" />
                                            <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                            <asp:BoundField DataField="SoId" HeaderText="SoId" />
                                            <asp:BoundField DataField="SoMatId" HeaderText="SoMatId" />
                                            <asp:BoundField DataField="Requestfor" HeaderText="Requestfor" />

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
                                                <th>Grand Total :</th>
                                                <td class="text-right">
                                                    <asp:TextBox ID="txttotal" CssClass="form-control" runat="server"></asp:TextBox></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>

                        <div class="panel-body">
                            <div class="bg-primary with-padding block-inner">Payment Terms & Condtions</div>
                            <div class="form-horizontal">


                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Payment Terms Details:</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtpaymenttermsdetails"  CssClass="form-control" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                                    
                                    <cc1:HtmlEditorExtender
                                                ID="HtmlEditorExtender5" TargetControlID="txtpaymenttermsdetails"  EnableSanitization="false" DisplaySourceTab="false"
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
                                        <asp:TextBox ID="txttermsconditions"  TextMode="MultiLine" Rows="5" CssClass="form-control" runat="server"></asp:TextBox>
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
                                    <asp:DropDownList ID="ddlpreparedby" Width="100%" TabIndex="2" Enabled="false" CssClass="select-full" runat="server"></asp:DropDownList>
                                </div>

                                <label class="col-sm-2 control-label text-right">Approved By:</label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlapprovedby" Width="100%" TabIndex="2" Enabled="false" CssClass="select-full" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel-body">

                        <div class="form-actions text-right">
                            <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-warning" Text="Print" />
                            <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-success" Text="Approve" OnClick="btnApprove_Click" />
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>



                </div>

                

                
            </div>
      
</asp:Content>