﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Return_Nrgp_Details.aspx.cs" Inherits="Modules_Stock_Return_Nrgp_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <div class="page-header">
        <div class="page-title">
            <h3>NRGP Return Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="Return_Nrgp.aspx">NRGP Return</a></li>
            <li class="active">NRGP Return Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->
    <div class="form-horizontal">

        <div class="panel panel-default">
            <div class="panel-heading">
                <h6 class="panel-title"><i class="icon-pencil"></i>NRGP Return Details</h6>
            </div>
            <div class="panel-body">

                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">NRGP Return Receipt No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtRgpreturnNo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">NRGP Return Receipt Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtRgpreturnDate" CssClass="form-control" runat="server"></asp:TextBox>
                          <asp:Image
                                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                                            TargetControlID="txtRgpreturnDate">
                                        </cc1:CalendarExtender>
                    </div>
                </div>

                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">NRGP No :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlRgpno" CssClass="select-full" Width="100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRgpno_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <label class="col-sm-2 control-label text-right">NRGP Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtRgpDate" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Receiver Name :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtrecivername" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Address :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtaddress" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>



                <div class="panel">
                    <div class="panel-body">

                        <div class="datatable">

                            <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                Width="100%" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                   <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                     <asp:BoundField DataField="Uom" HeaderText="Uom" />
                                     <asp:BoundField DataField="Length" HeaderText="Length" />
                                    <asp:BoundField DataField="Color" HeaderText="Color" />
                                     <asp:BoundField DataField="ReqQty" HeaderText="Issued Qty" />
                                     <asp:BoundField DataField="ReceivedQty" HeaderText="Received Qty" />
                                    <asp:BoundField DataField="Purpose" HeaderText="Purpose" />
                                   <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                     <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                                    <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                    <asp:TemplateField HeaderText="Receive Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRECEIVEDQTY" runat="server" Width="40px" Text='<%# Eval("ReceiveQty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Slno" HeaderText="Slno" />



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
                            <label class="col-sm-2 control-label text-right">Remarks :</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txttermscondtionscontent" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                <cc1:HtmlEditorExtender
                                    ID="HtmlEditorExtender5" TargetControlID="txttermscondtionscontent" EnableSanitization="false" DisplaySourceTab="false"
                                    runat="server" />
                            </div>
                        </div>



                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Received By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlReceivedby" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>

                            <label class="col-sm-2 control-label text-right">Status :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlstatus" CssClass="form-control" Width="100%" runat="server">
                                    <asp:ListItem>Pending</asp:ListItem>
                                    <asp:ListItem>Complete</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>


                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Prepared By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlPreparedBy" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>



                    </div>
                </div>

                <div class="form-actions text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                </div>

                
            </div>
        </div>
    </div>





</asp:Content>






