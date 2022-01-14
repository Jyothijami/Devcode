<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Mrn_Details.aspx.cs" Inherits="Modules_Stock_Mrn_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



  



     <%--   <script type="text/javascript">
         function showModal() {
             $("#large_modal").modal('show');
         }

         $(function () {
             $("#LinkButton1").click(function () {
                 showModal();
             });
         });
    </script>--%>
    <%--   <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
         <ContentTemplate>--%>
    <!-- Page header -->



       <script>

           $(document).ready(function () {
               $('#<%=Books.ClientID%>').select2({ placeholder: 'Select PO' });


                    //$("#ContentPlaceHolder1_Books").select2({ placeholder: 'Find and Select Books' });


                });


                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                function EndRequestHandler(sender, args) {
                    //Binding Code Again
                    $(<%=Books.ClientID%>).select2({ placeholder: 'Select PO' });
        }




         </script>






    <div class="page-header">
        <div class="page-title">
            <h3>Purchase Goods Receipt Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="MRN.aspx">Purchase Goods Receipt</a></li>
            <li class="active">Purchase Goods Receipt Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->
    <div class="form-horizontal">

        <div class="panel panel-default">
            <div class="panel-heading">
                <h6 class="panel-title"><i class="icon-pencil"></i>Purchase Order Details</h6>
            </div>
            <div class="panel-body">

                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Purchase Receipt No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtPreceiptno" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Purchase Receipt Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtPrDate" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:Image
                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                            TargetControlID="txtPrDate">
                        </cc1:CalendarExtender>
                    </div>
                </div>


                <div class="form-group">

                      <label class="col-sm-2 control-label text-right">PO No :</label>
                    <div class="col-sm-4">
                       <asp:DropDownList ID="ddlPono" CssClass="select-full" Width="100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPono_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                       <label class="col-sm-2 control-label text-right">PO Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtPoDate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                </div>



                  <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Vendor Name :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtvendorname"  CssClass="form-control" runat="server"></asp:TextBox>
                    </div>


                      <label class="col-sm-2 control-label text-right">Vehical No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtVehicalNo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                
                  <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Invoice No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtinoviceno"  CssClass="form-control" runat="server"></asp:TextBox>
                    </div>


                      <label class="col-sm-2 control-label text-right">Invoice Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtinvoicedate" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:Image
                            ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                            TargetControlID="txtinvoicedate">
                        </cc1:CalendarExtender>
                    </div>

                   
                </div>

                  <div class="form-group">

                   <label class="col-sm-2 control-label text-right">Address :</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtVendorContactPerson" Rows="3" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                          <cc1:HtmlEditorExtender
                                    ID="HtmlEditorExtender4" TargetControlID="txtVendorContactPerson" EnableSanitization="false" DisplaySourceTab="false"
                                    runat="server" />
                    </div>
                   
                </div>




                  <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Select Multiple PO No's :</label>
                    <div class="col-sm-6">
                       


                         <select id="Books" style="width:100%" runat="server" ></select>
                                   
                              

                                           <script>
                                               $(document).ready(function () {
                                                   $("#Books").select2({ placeholder: 'Select PO' });
                                               });
                                               </script>


                            






                    </div>
                    <div class="col-md-2">
                          <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger" OnClick="Button1_Click" Text="Get Pos" />
                    </div>

                
                </div>



                  <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Selected POS :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtponos"  TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    
                 </div>
                







               



                <div class="panel">
                    <div class="panel-body">

                        <div class="datatable">

                            <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                                Width="100%" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="CodeNo" HeaderText="Item Name" />
                                    <asp:BoundField DataField="Series" ItemStyle-Wrap="true" HeaderText="Description" />
                                    <%--  <asp:BoundField DataField="Description" HeaderText="Description" />--%>
                                    <asp:BoundField DataField="Color" HeaderText="Color" />
                                    <asp:BoundField DataField="Uom" HeaderText="Uom" />
                                      <asp:BoundField DataField="Length" HeaderText="Length" />
                                    <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                    <asp:TemplateField HeaderText="Received Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRECEIVEDQTY" runat="server" Width="40px" Text='<%# Eval("ReceivedQty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Accepted Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAcceptedQTY" runat="server" Width="40px" Text='<%# Eval("AcceptedQty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Rejected Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRejectedQTY" runat="server" Width="40px" Text='<%# Eval("RejectedQty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RemainingQty" HeaderText="Remaining Qty" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                    <asp:BoundField DataField="ItemcodeId" HeaderText="ItemcodeId" />
                                    <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                    <asp:TemplateField HeaderText="Warehouse">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlPlant" Width="100%" OnSelectedIndexChanged="ddlPlant_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="StorageLoc">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlStoragelocation" Width="100%" runat="server"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="In Stock">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlInstock" Width="100%"   runat="server">

                                            <asp:ListItem Value="InStock">In Stock</asp:ListItem>
                                            <asp:ListItem Value="InTransit">In Transit</asp:ListItem>

                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="PoDetId" HeaderText="Po Det Id" />
                                         <asp:TemplateField HeaderText="BLOCK Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtblockqty" runat="server" Width="40px" Text='<%# Eval("Blockqty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemremarks" runat="server" Width="40px" Text='<%# Eval("Remarks") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                <%--    <asp:BoundField DataField="AlreadyBlocked" HeaderText="AlreadyBlocked Qty" />
                                    <asp:BoundField DataField="BlockRemarks" HeaderText="BlockRemarks" />--%>

                                     <asp:BoundField DataField="SoId" HeaderText="SoId" />

                                      <asp:BoundField DataField="POId" HeaderText="POId" />


                                      <asp:BoundField DataField="PONO" HeaderText="PONO" />

                                      <asp:BoundField DataField="CustomerNO" HeaderText="CustomerNO" />




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
                    <div class="panel-heading">
                        <h6 class="panel-title">Office Details</h6>
                    </div>

                    <div class="panel-body">
                     

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Remarks : </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtremarks" Width="100%" TextMode="MultiLine" Rows="3"  runat="server"></asp:TextBox>
                            </div>
                        </div>



                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Prepared By: </label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlpreparedby" Enabled="false" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>



                              <label class="col-sm-2 control-label text-right">Checked By: </label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlCheckedBy" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>



                        </div>

                          <div class="form-group">
                          
                        </div>


                    </div>
                </div>

                <div class="form-actions text-right">
                    <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-warning" Text="Print" />

                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                </div>

                <%--  <div id="large_modal" class="modal fade" tabindex="-1" role="dialog">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title"><i class="icon-accessibility"></i>Item Details</h4>
                            </div>

                            <div class="modal-body with-padding">
                                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h6 class="panel-title"><i class="icon-pencil"></i>Item Details</h6>
                    </div>
                    <div class="panel-body">

                        <h6 class="heading-hr text-danger">Material : <asp:Label ID="lblMaterialName" ForeColor="Black" runat="server" Text=""></asp:Label></h6>

                        <div class="form-group">

                            <label class="col-sm-2 control-label text-right">Length(MM) :</label>
                            <div class="col-sm-2">
                            <asp:TextBox Enabled="false" ID="lblMaterialLength" CssClass="disabled" runat="server" Text=""></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Description :</label>
                            <div class="col-sm-2">
                             <asp:TextBox ID="lblMaterialDescription" Width="100%" Enabled="false" TextMode="MultiLine" CssClass="disabled" runat="server" Text=""></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Color :</label>
                            <div class="col-sm-2">
                                <asp:TextBox ID="lblMaterialColor" Enabled="false" CssClass="disabled" runat="server" Text=""></asp:TextBox>
                             </div>
                        </div>

                        <h6 class="heading-hr text-danger">Quantity</h6>

                        <div class="form-group">

                            <label class="col-sm-2 control-label text-right">Quantity in Unit of Entry :</label>
                            <div class="col-sm-2">
                                <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Received Qty :</label>
                            <div class="col-sm-2">
                                <asp:TextBox ID="txtReceivedQty" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Remaining Qty :</label>
                            <div class="col-sm-2">
                                <asp:TextBox ID="txtreaminingqty" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <h6 class="heading-hr text-danger">Warehouse and Reference</h6>

                        <div class="form-group">

                            <label class="col-sm-2 control-label text-right">Plant :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlPlant" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Stock Type :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlStocktype" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">

                            <label class="col-sm-2 control-label text-right">Storage Location :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlStoragelocation" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                            </div>

                            <div class="modal-footer">
                                <button class="btn btn-warning" data-dismiss="modal">Close</button>
                                <asp:Button ID="btnadd" runat="server" OnClick="btnadd_Click" CssClass="btn btn-primary" Text="Save" />
                            </div>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>
    <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>






</asp:Content>

