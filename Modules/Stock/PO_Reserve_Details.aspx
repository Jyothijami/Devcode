<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="PO_Reserve_Details.aspx.cs" Inherits="Modules_Stock_PO_Reserve_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


     


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
                window.location = 'PO_Reserve.aspx';
            }).catch(function (reason) {
                // The action was canceled by the user
            });

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

    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Reserve Stock SO Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="PO_Reserve.aspx">Reserve Stock PO</a></li>
            <li class="active">Reserve Stock PO Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="panel panel-default">

        <div class="panel-heading">
            <h6 class="panel-title">Reserve Stock SO Details</h6>
        </div>

        <div class="panel-body">

            <div class="form-horizontal">


                  <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Reserve Stock No:</label>
                    <div class="col-sm-4">
                         <asp:TextBox ID="txtrerservestockno" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <label class="col-sm-2 control-label text-right">Order Date:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtreservedate" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:Image
                                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                                            TargetControlID="txtreservedate">
                                        </cc1:CalendarExtender>
                    </div>
                </div>




                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Sales Order No:</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlsono" CssClass="select-full" width="100%" OnSelectedIndexChanged="ddlsono_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                    <label class="col-sm-2 control-label text-right">Order Date:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtSalesorderdate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Customer :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlCustomer" Width="100%" CssClass="select-full" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>

                    <label class="col-sm-2 control-label text-right">Project :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlunitid" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="datatable-tasks">

                    <div class="" style="padding-top: 30px" runat="server" >
                        <asp:GridView ID="gvQuatationItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" 
                            Width="100%" OnRowDataBound="gvQuatationItems_RowDataBound">
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
                        <%--<asp:BoundField DataField="ITEMCODE" HeaderText="Item Code" />
                        <asp:BoundField DataField="ITEMCODE" HeaderText="Item Code" />
                        <asp:BoundField DataField="QUANTITY" HeaderText="BOm Qty" />
                                   <asp:BoundField HeaderText="PU" DataField="PU" />
                                 <asp:BoundField HeaderText="Req Qty" DataField="REQUIRED_QTY" />
                        <asp:BoundField DataField="BARLENGTH" HeaderText="BarLength" />
                        <asp:BoundField DataField="UNIT" HeaderText="Unit" />
                        <asp:BoundField DataField="COLOR" HeaderText="Color" />
                        <asp:BoundField DataField="ITEMCODE_ID" HeaderText="ItemId" />
                        <asp:BoundField DataField="COLOR_ID" HeaderText="ColorId" />
                        <asp:BoundField DataField="SO_MATANA_ID" HeaderText="Bom DetId" />
                        <asp:BoundField DataField="PrevBlockedStock" HeaderText="Previously Blocked Qty" />
                        <asp:BoundField DataField="TotalStock" HeaderText="Total Stock" />
                        <asp:BoundField DataField="TotalBlockedStock" HeaderText="Total Blocked Qty" />
                        <asp:BoundField DataField="AvailableStocktoBlock" HeaderText="AvailableStocktoBlock" />
                        <asp:BoundField HeaderText="Short"  />--%>
                                  <asp:BoundField HeaderText="Item Code" DataField="Material_Code" />
                              <asp:BoundField HeaderText="Description" DataField="DESCRIPTION" />
                                 <asp:BoundField HeaderText="Color" DataField="Color_Name" />
                              <asp:BoundField HeaderText="Length" DataField="length" />
                             <asp:BoundField HeaderText="BOM Qty" DataField="BOMQty" />
                              <asp:BoundField HeaderText="PU" DataField="PU" />
                                 <asp:BoundField HeaderText="Req Qty" DataField="REQUIRED_QTY" />
                              <asp:BoundField HeaderText="Unit" DataField="UNIT" />
                               <asp:BoundField HeaderText="Blocked" DataField="Blockedstock" />

                                <asp:BoundField HeaderText="FreeStock" DataField="FreeStock" />

                                

                               <asp:BoundField HeaderText="Short"  />


                                   <asp:BoundField HeaderText="ItemCodeID" DataField="ITEMCODE_ID" />
                                   <asp:BoundField HeaderText="ColorId" DataField="COLOR_ID" />
                                   <asp:BoundField HeaderText="SoId" DataField="SO_ID" />
                                 <asp:BoundField HeaderText="SO_MATANA_ID" DataField="SO_MATANA_ID" />
                         
                                 </Columns>
                            <EmptyDataTemplate>
                                <div style="text-align: center">
                                    <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>


                                  





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
                                <asp:DropDownList ID="ddlColor" OnSelectedIndexChanged="ddlColor_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Description :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtdescription" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Uom :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtUom" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Length :</label>
                            <div class="col-sm-4">
                                 <asp:DropDownList ID="ddllength" OnSelectedIndexChanged="ddllength_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                               <%-- <asp:TextBox ID="txtitemtLength" CssClass="form-control" runat="server"></asp:TextBox>--%>
                            </div>

                            <label class="col-sm-2 control-label text-right">Total Stock :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtpu" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                        </div>



                         <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Previous Blocked Stock :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtpreviousBlockedStock" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Available Stock to Block :</label>
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
                                <asp:TextBox ID="txtblockremarks" CssClass="form-control" TextMode="MultiLine"  runat="server"></asp:TextBox>
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
                                     <asp:BoundField DataField="ITEMCODE" HeaderText="Item Code" />
                                     <asp:BoundField DataField="BARLENGTH" HeaderText="BarLength" />
                                     <asp:BoundField DataField="UNIT" HeaderText="Unit" />
                                     <asp:BoundField DataField="COLOR" HeaderText="Color" />
                                     <asp:BoundField DataField="ITEMCODE_ID" HeaderText="ItemId" />
                                     <asp:BoundField DataField="COLOR_ID" HeaderText="ColorId" />
                                     <asp:BoundField DataField="SO_MATANA_ID" HeaderText="BomDet Id" />
                                     <asp:BoundField DataField="QUANTITY" HeaderText="Quantity Required" />
                                     <asp:BoundField DataField="PrevBlockedStock" HeaderText="Already BlockedStock" />
                                     <asp:BoundField DataField="AvailableStocktoBlock" HeaderText="Available Stock" />
                                     <asp:TemplateField  HeaderText="Qty to Reserve" >
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtqtytoreserve" CssClass="form-control"  runat="server"  Text='<%# Bind("ReserveQty") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:BoundField DataField="blockremarks" HeaderText="Remarks" />



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
                                    <label class="col-sm-2 control-label text-right">Prepared By :</label>
                                    <div class="col-sm-4">
                                          <asp:DropDownList ID="ddlpreparedby" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                          </div>

                    </div>
                </div>
                    </div>




                <div class="form-actions text-right">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click"  />
                    </div>




                <div class="panel panel-default">
                    <div class="panel-heading"><h6 class="panel-title">Already Blocked Items for SO</h6></div>
                <div class="panel-body">
                   <div class="form-group">


                       <asp:GridView ID="gvalready" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" 
                                Width="100%" >
                                <Columns>
                                   
                                    <asp:BoundField DataField="BlockStock_Id" HeaderText="Sl.No" />
                                    <asp:BoundField DataField="Stock_Reserve_No" HeaderText="Reserve No" />
                                    <asp:BoundField DataField="Stock_Reserve_Date" HeaderText="Reserve Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="Color_Name" HeaderText="Color" />
                                    <asp:BoundField DataField="Qty" HeaderText="Blocked Qty" />
                                    <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="For Project" />
                                    <asp:BoundField DataField="SalesOrder_No" HeaderText="SO.No" />

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
</asp:Content>