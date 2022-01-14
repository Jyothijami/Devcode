<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="PurchaseGlassReceipt.aspx.cs" Inherits="Modules_Stock_PurchaseGlassReceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     <div class="page-header">
        <div class="page-title">
            <h3>Glass Recieved Notes Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="GlassPurchaseReceipt.aspx">Glass Recieved Notes</a></li>
            <li class="active">Glass Recieved Notes Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->
    <div class="form-horizontal">

        <div class="panel panel-default">
            <div class="panel-heading">
                <h6 class="panel-title"><i class="icon-pencil"></i>Glass Purchase Order Details</h6>
            </div>
            <div class="panel-body">

                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Glass Purchase Receipt No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtPreceiptno" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Glass Purchase Receipt Date :</label>
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

                    <label class="col-sm-2 control-label text-right">Glass Purchase Order No :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlPono" CssClass="select-full" Width="100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPono_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <label class="col-sm-2 control-label text-right">Glass Purchase Order Date :</label>
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

                    <label class="col-sm-2 control-label text-right">Project Code :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtproject"  CssClass="form-control" runat="server"></asp:TextBox>
                    </div>


                      <label class="col-sm-2 control-label text-right">PO No's :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtpoNos" CssClass="form-control" runat="server"></asp:TextBox>
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




                <div class="panel">
                    <div class="panel-body">

                        <div class="datatable">

                            <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                Width="100%" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="WindowCode" HeaderText="Window Code" />
                                    <asp:BoundField DataField="Thickness" HeaderText="Thickness" />
                                      <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="Width" HeaderText="Width" />
                                    <asp:BoundField DataField="Height" HeaderText="Height" />
                                      <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                    <asp:BoundField DataField="Area" HeaderText="Area" />

                                   <asp:BoundField DataField="Weight" HeaderText="Weight" />
                                      <asp:BoundField DataField="ReqQty" HeaderText="Po Qty" />



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
                                        

                                     <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemremarks" runat="server" Width="40px" Text='<%# Eval("Remarks") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                <%--    <asp:BoundField DataField="AlreadyBlocked" HeaderText="AlreadyBlocked Qty" />
                                    <asp:BoundField DataField="BlockRemarks" HeaderText="BlockRemarks" />--%>

                                     <asp:BoundField DataField="SoId" HeaderText="SoId" />

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

                
            </div>
        </div>
    </div>





</asp:Content>

