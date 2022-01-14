<%@ Page Title="" Language="C#" MasterPageFile="~/ModalPop.master" AutoEventWireup="true" CodeFile="SalesOrderDetails.aspx.cs" Inherits="Modules_Reports_Details_SalesOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



       <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                            Width="100%"  >
                                            <Columns>
                                                
                                                <asp:BoundField DataField="CodeNo" HeaderText="Window Code" />
                                                  <asp:BoundField DataField="Series" HeaderText="System" />
                                                <asp:BoundField DataField="Width" HeaderText="Width" />
                                                <asp:BoundField DataField="height" HeaderText="height" />
                                                <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                                <asp:BoundField DataField="Glass" HeaderText="Glass" />
                                                <asp:BoundField DataField="Mesh" HeaderText="Mesh" />
                                                <asp:BoundField DataField="ProfileColor" HeaderText="Profile Color" />
                                                <asp:BoundField DataField="HardwareColor" HeaderText="Hardware Color" />
                                                <asp:BoundField DataField="TotalArea" HeaderText="Area" />
                                                <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                                                 <asp:BoundField DataField="ItemDeliverydate" HeaderText="Delivery Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                                                           
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="text-align: center">
                                                    <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>






</asp:Content>

