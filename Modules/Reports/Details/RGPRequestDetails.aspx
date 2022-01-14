<%@ Page Title="" Language="C#" MasterPageFile="~/ModalPop.master" AutoEventWireup="true" CodeFile="RGPRequestDetails.aspx.cs" Inherits="Modules_Reports_Details_SalesOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



       <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                            Width="100%"  >
                                            <Columns>
                                                
                                               <asp:CommandField ShowDeleteButton="True" />
                                    <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="Uom" HeaderText="Uom" />
                                    <asp:BoundField DataField="Length" HeaderText="Length" />


                                    <asp:BoundField DataField="Color" HeaderText="Color" />
                                     <asp:BoundField DataField="ReqQty" HeaderText="Qty" />
                                    
                                    <asp:BoundField DataField="Purpose" HeaderText="Purpose" />
                                   <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                     <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                                    <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                                                                           
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="text-align: center">
                                                    <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>






</asp:Content>

