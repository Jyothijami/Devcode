<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="IssueRequest_Details.aspx.cs" Inherits="Modules_Stock_IssueRequest_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     
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
            <h3>Material Request Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="IssueRequest.aspx">Issue</a></li>
            <li class="active">Issue Request Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Issue No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtMaterialreqestNo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Issue Date :</label>
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
                            <asp:ListItem>RGP</asp:ListItem>
                            <asp:ListItem>NRGP</asp:ListItem>
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

                <div class="panel panel-danger">
                    <div class="panel-heading">
                         
                        <h5 class="panel-title">Get Items From Sales Order </h5>

                        <div class="panel-icons-group">
		                    	<a href="#" data-panel="collapse" class="btn btn-link btn-icon"><i class="icon-arrow-up9"></i></a>
	                    </div>


                    </div>
                    
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Sales Order No :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlSono" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="ddlSono_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>


                            <label class="col-sm-2 control-label text-right">Customer/Project :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlCustomer"  Width="100%"  CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>



                        </div>

                        <div class="form-group">


                        <div class="datatable-tasks">


                            <asp:GridView ID="gvmatana" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvmatana_RowDataBound">
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




                                    <asp:BoundField DataField="ITEM_CATEGORY_NAME" HeaderText="Material Type" />
                                    <asp:BoundField DataField="ITEMCODE" HeaderText="Item Code" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                     <asp:BoundField DataField="BARLENGTH" HeaderText="BarLength" />
                                     <asp:BoundField DataField="UNIT" HeaderText="Unit" />
                                     <asp:BoundField DataField="COLOR" HeaderText="Color" />
                                    
                                    <asp:BoundField DataField="PU" HeaderText="PU" />
                                   
                                    <asp:BoundField DataField="REQUIRED_QTY" HeaderText="Required Qty(Actual)" />
                                    <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                                    <asp:BoundField  DataField="TotalStock" HeaderText ="Available Qty" />
                                   
                                    <asp:BoundField DataField="ITEMCODE_ID" HeaderText="ItemId" />
                                    <asp:BoundField DataField="COLOR_ID" HeaderText="ColorId" />
                                   
                                    <asp:BoundField DataField="SO_ID" HeaderText="SO_ID" />
                                    <asp:BoundField DataField="SO_MATANA_ID" HeaderText="SO_MATANA_ID" />

                                     <asp:BoundField DataField="PrevBlockedStock" HeaderText="Blocked Qty" />
                                     <asp:BoundField   DataField="iSSUED" HeaderText="Issued Qty" />




                                 <%--   <asp:TemplateField HeaderText="Location">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlSowaerhose" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>




                                </Columns>
                                <EmptyDataTemplate>
                                    <span style="color: #CC0000">No Data Found</span>
                                </EmptyDataTemplate>
                            </asp:GridView>

                            </div>
                        </div>
                    </div>
                    
                </div>

                <div class="panel panel-default">

                    <div class="panel-heading">
                        <h5 class="panel-title">Add Items</h5>
                    </div>

                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Item Code :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlitemCode" Width="100%" TabIndex="2" AutoPostBack="true" CssClass="select-full" runat="server" OnSelectedIndexChanged="ddlitemCode_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Color :</label>
                            <div class="col-sm-4">
                            <%--    <asp:DropDownList ID="ddlColor" CssClass="form-control" runat="server"></asp:DropDownList>
                           --%>
                                  <asp:DropDownList ID="ddlColor" OnSelectedIndexChanged="ddlColor_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                                 </div>
                        </div>


                          <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Description :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtseries" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Uom :</label>
                            <div class="col-sm-4">
                               <asp:TextBox ID="txtUom" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>






                        <div class="form-group">
                             <label class="col-sm-2 control-label text-right">Length :</label>
                            <div class="col-sm-4">
                             <%--  <asp:TextBox ID="txtitemtLength" CssClass="form-control" runat="server"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddllength" OnSelectedIndexChanged="ddllength_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                                  </div>

                            <label class="col-sm-2 control-label text-right">Total Stock :</label>
                            <div class="col-sm-4">
                               <asp:TextBox ID="txtpu" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>



                        
                           <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Blocked Stock :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtpreviousBlockedStock" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Free Stock :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtAvailableStocktoBlock" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>





                        <div class="form-group">


                                 <label class="col-sm-2 control-label text-right">Qty :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>


                            <label class="col-sm-2 control-label text-right">Remarks :</label>
                            <div class="col-sm-4">
                                   <asp:TextBox ID="txtremakrs" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">

                            <div class="form-actions col-sm-offset-6">
                                <asp:Button ID="btnadditem" CssClass="btn btn-primary" runat="server" OnClick="btnadditem_Click" Text="Add Item" />
                            </div>
                        </div>

                        <div class="" style="padding-top: 10px">
                            <asp:GridView ID="gvItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvItems_RowDataBound"
                                Width="100%" OnRowDeleting="gvItems_RowDeleting">
                                <Columns>

                                    <asp:CommandField ShowDeleteButton="True" />
                                    <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                                    <asp:BoundField DataField="Series" HeaderText="Description" />
                                    <asp:BoundField DataField="Length" HeaderText="Length" />
                                     <asp:BoundField DataField="Uom" HeaderText="Uom" />
                                    <asp:BoundField DataField="Color" HeaderText="Color" />
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemqty" CssClass="form-control" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                                    <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                    <asp:BoundField DataField="SoMatId" HeaderText="SoMatId" />
                                     <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemRemarks" CssClass="form-control" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
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
