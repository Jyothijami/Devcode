<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="GlassStockBySo.aspx.cs" Inherits="Modules_Stock_GlassStockBySo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


      <div class="page-header">
        <div class="page-title">
            <h3>Glass Stock By Salesorder</h3>
        </div>
    </div>
    <!-- /page header -->

    
    <div class="form-horizontal">

        <div class="panel panel-default">
            <div class="panel-heading">
                <h6 class="panel-title"><i class="icon-pencil"></i>Glass Stock Details</h6>
            </div>
            <div class="panel-body">

                <div class="form-group">

                    <label class="col-sm-2 control-label text-right">Project Code :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlPono" CssClass="select-full" Width="100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPono_SelectedIndexChanged"></asp:DropDownList>
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
                                      <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                    <asp:BoundField DataField="PoDetId" HeaderText="Po Det Id" />

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

