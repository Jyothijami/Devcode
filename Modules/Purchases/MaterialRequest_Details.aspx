<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="MaterialRequest_Details.aspx.cs" Inherits="Modules_Purchases_MaterialRequest_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    
   
    <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
        }     
    </style>   

     

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


      




    <%--<script type="text/javascript">
        $(document).ready(function () {
            fnPageLoad();
        });
        function fnPageLoad() {
           $('#<%=gvmatana.ClientID%>').prepend($("<thead></thead>").append($('#<%=gvmatana.ClientID%>').find("tr:first"))).DataTable({


           
           
           
          
                
            paging: false,
            ordering: false,

            bStateSave: true
          


           

        });
    }
</script>--%>






    <%-- <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>--%>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
     <asp:UpdatePanel ID="UpdatePanel134" runat="server">
        <ContentTemplate>
    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Indent Request Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="MaterialRequest.aspx">Indent</a></li>
            <li class="active">Indent Request Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Indent No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtMaterialreqestNo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Indent Date :</label>
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
                            <asp:ListItem>Purchase</asp:ListItem>
                            <asp:ListItem>Material Transfer</asp:ListItem>
                            <asp:ListItem>Manufacture</asp:ListItem>
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
                        </div>

                        <div class="form-group">

                            <asp:GridView ID="gvmatana" CssClass="table table-bordered" runat="server"  AutoGenerateColumns="False"   OnRowDataBound="gvmatana_RowDataBound">
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
                                    <asp:BoundField DataField="Item_Series" HeaderText="Series" />
                                     <asp:BoundField DataField="BARLENGTH" HeaderText="BarLength" />
                                     <asp:BoundField DataField="UNIT" HeaderText="Unit" />
                                     <asp:BoundField DataField="COLOR" HeaderText="Color" />
                                     <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                                    <asp:BoundField DataField="PU" HeaderText="PU" />
                                   
                                    <asp:BoundField DataField="REQUIRED_QTY" HeaderText="Required Qty(Actual)" />
                                    <asp:BoundField HeaderText="Available Qty" />
                                   
                                    <asp:BoundField DataField="ITEMCODE_ID" HeaderText="ItemId" />
                                    <asp:BoundField DataField="COLOR_ID" HeaderText="ColorId" />
                                   
                                    <asp:BoundField DataField="SO_ID" HeaderText="SO_ID" />
                                    <asp:BoundField DataField="SO_MATANA_ID" HeaderText="SO_MATANA_ID" />
                                      <asp:BoundField DataField="PrevBlockedStock" HeaderText="PrevBlockedStock" />
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
                                <asp:DropDownList ID="ddlColor" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>


                          <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Series :</label>
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
                               <asp:TextBox ID="txtitemtLength" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Packing Unit :</label>
                            <div class="col-sm-4">
                               <asp:TextBox ID="txtpu" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                       

                           
                        </div>

                        <div class="form-group">


                                 <label class="col-sm-2 control-label text-right">Qty :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>


                            <label class="col-sm-2 control-label text-right">Required Date :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtitemRequireddate" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:Image
                                    ID="Image2" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender3" runat="server" PopupButtonID="Image2"
                                    TargetControlID="txtitemRequireddate">
                                </cc1:CalendarExtender>
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
                                    <asp:BoundField DataField="Series" HeaderText="Series" />
                                    <asp:BoundField DataField="Length" HeaderText="Length" />
                                     <asp:BoundField DataField="Uom" HeaderText="Uom" />
                                    <asp:BoundField DataField="Color" HeaderText="Color" />
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemqty" CssClass="form-control" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Requireddate">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemrequireddate" CssClass="form-control" runat="server" Text='<%# Bind("RequiredDate") %>'></asp:TextBox>
                                            <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender4" runat="server"
                                                TargetControlID="txtitemrequireddate">
                                            </cc1:CalendarExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Requestfor" HeaderText="Request For" />
                                    <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                                    <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                    <asp:BoundField DataField="SoId" HeaderText="SoId" />
                                      <asp:BoundField DataField="SoMatId" HeaderText="SoMatId" />
                                      <asp:BoundField DataField="RequiredQty" HeaderText="RequiredQty" />
                                    <asp:BoundField DataField="PU" HeaderText="PU" />

                                  <%--  <asp:BoundField DataField="WarehouseId" HeaderText="WarehouseId" />--%>
                                    <%--   <asp:BoundField DataField="ItemCode" HeaderText="ItemCode" />
                                        <asp:BoundField DataField="Color" HeaderText="Color" />--%>
                                    <%--  <asp:BoundField DataField="Qty" HeaderText="Qty" />--%>
                                    <%--    <asp:BoundField DataField="Warehouse" HeaderText="For Warehouse" />--%>
                                    <%-- <asp:BoundField DataField="Requireddate" HeaderText="Required Date" />--%>
                                    <%--   <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                                        <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                        <asp:BoundField DataField="WarehouseId" HeaderText="WarehouseId" />--%>
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
                            <label class="col-sm-2 control-label text-right">Request For :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtrequestfor" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Status :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlstatus" CssClass="form-control" Width="100%" runat="server">
                                    <asp:ListItem>Pending</asp:ListItem>
                                    <asp:ListItem>Closed</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Remarks :</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txttermscondtionscontent" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                <cc1:HtmlEditorExtender
                                    ID="HtmlEditorExtender5" TargetControlID="txttermscondtionscontent" EnableSanitization="false" DisplaySourceTab="false"
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
                                        <asp:DropDownList ID="ddlpreparedby" Enabled="false" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                   
                                </div>
                            </div>
                <div class="form-group">

                    <div class="form-actions col-sm-offset-10">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                    </div>
                </div>
            </div>
        </div>
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
        </div>
            
            
            </ContentTemplate>
         </asp:UpdatePanel>

</asp:Content>