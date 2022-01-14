<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="ToolRequest_Details.aspx.cs" Inherits="Modules_Stock_ToolRequest_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    
    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Tools Request Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="ToolRequest.aspx">Tool Request</a></li>
            <li class="active">Tool Request Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Request No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtrequestno" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Request Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtrequestdate" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:Image
                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                            TargetControlID="txtrequestdate">
                        </cc1:CalendarExtender>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Requested By:</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlrequestedBY"  Width="100%"  CssClass="select-full" runat="server"></asp:DropDownList>
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
                        
                                  <asp:DropDownList ID="ddlColor" OnSelectedIndexChanged="ddlColor_SelectedIndexChanged"  CssClass="select-full" Width="100%"   runat="server"></asp:DropDownList>
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
                              <%-- <asp:TextBox ID="txtitemtLength" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                  <asp:DropDownList ID="ddllength" Width="100%" TabIndex="2" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddllength_SelectedIndexChanged"></asp:DropDownList>

                                                            </div>


                            <label class="col-sm-2 control-label text-right">Table :</label>
                            <div class="col-sm-4">
                        
                                  <asp:DropDownList ID="ddltable"  CssClass="select-full" Width="100%"  runat="server"></asp:DropDownList>
                                 </div>



                       
                        </div>



                       
                         <div class="form-group">


                                 <label class="col-sm-2 control-label text-right">Available Qty :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtavailableqty" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                          <label class="col-sm-2 control-label text-right">Remarks :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtremarks"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>




                        <div class="form-group">


                                 <label class="col-sm-2 control-label text-right">Qty :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                              <label class="col-sm-2 control-label text-right">Employee :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlemployee"  CssClass="select-full" Width="100%"  runat="server"></asp:DropDownList>
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
                                    <asp:BoundField DataField="Table" HeaderText="Table" />
                                     <asp:BoundField DataField="Employee" HeaderText="Employee" />
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemqty" CssClass="form-control" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                                    <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                    <asp:BoundField DataField="TableId" HeaderText="TableId" />
                                    <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" />

                                     <asp:BoundField DataField="Remarks" HeaderText="Remarks" />

                                  
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
                                <asp:DropDownList ID="ddlpreparedby" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                            </div>

                            
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
      
        </div>








</asp:Content>

