<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="BlukReturnRequest_Details.aspx.cs" Inherits="Modules_Stock_BlukReturnRequest_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      

    
    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Production Return Request Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="BlukReturnRequest.aspx">Production Return</a></li>
            <li class="active">Production Return Request Details</li>
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
                    <label class="col-sm-2 control-label text-right">Return Type :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlrequesttype" CssClass="form-control" Width="100%" runat="server">
                            <asp:ListItem>Production</asp:ListItem>
                         
                        </asp:DropDownList>
                    </div>
                  
                </div>

                <div class="panel panel-danger">
                    <div class="panel-heading">
                         
                        <h5 class="panel-title">Customer Sales Order </h5>

                        <div class="panel-icons-group">
		                    	<a href="#" data-panel="collapse" class="btn btn-link btn-icon"><i class="icon-arrow-up9"></i></a>
	                    </div>


                    </div>
                    
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Sales Order No :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlSono" AutoPostBack="true" OnSelectedIndexChanged="ddlSono_SelectedIndexChanged" Width="100%"  CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>


                            <label class="col-sm-2 control-label text-right">Customer/Project :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlCustomer"  Width="100%"  CssClass="select-full" runat="server"></asp:DropDownList>
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
                        
                                  <asp:DropDownList ID="ddlColor"  CssClass="select-full" Width="100%"  runat="server"></asp:DropDownList>
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
                               <asp:TextBox ID="txtitemtLength" CssClass="form-control" runat="server"></asp:TextBox>
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
                            <label class="col-sm-2 control-label text-right">Return By :</label>
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

