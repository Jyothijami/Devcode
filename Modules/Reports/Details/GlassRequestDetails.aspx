<%@ Page Title="" Language="C#" MasterPageFile="~/ModalPop.master" AutoEventWireup="true" CodeFile="GlassRequestDetails.aspx.cs" Inherits="Modules_Reports_Details_SalesOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



       <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                            Width="100%"  >
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

                                    <asp:TemplateField HeaderText="Request Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRequestqty" runat="server" Width="40px" Text='<%# Eval("Requestqty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                                                           
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="text-align: center">
                                                    <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>






</asp:Content>

