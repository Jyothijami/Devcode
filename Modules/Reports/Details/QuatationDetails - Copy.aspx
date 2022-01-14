<%@ Page Title="" Language="C#" MasterPageFile="~/ModalPop.master" AutoEventWireup="true" CodeFile="QuatationDetails - Copy.aspx.cs" Inherits="Modules_Reports_Details_QuatationDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <div class="panel panel-default">


         <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Open Quotations</h6>
        </div>

        <div class="panel-body">

     


        <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                                    Width="100%"  >
                                                    <Columns>
                                                        <asp:BoundField DataField="CodeNo" HeaderText="Window Code" />
                                                        <asp:BoundField DataField="System" HeaderText="System" />
                                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                                        <asp:BoundField DataField="Glass" HeaderText="Glass" />
                                                        <asp:BoundField DataField="Location" HeaderText="Location" />
                                                        <asp:BoundField DataField="Mesh" HeaderText="Mesh" />
                                                        <asp:BoundField DataField="Width" HeaderText="Width(MM)" />
                                                        <asp:BoundField DataField="height" HeaderText="Height(MM)" />
                                                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                                        <asp:BoundField DataField="TotalArea" HeaderText="TotalArea" />
                                                        <asp:BoundField DataField="ProfileColor" HeaderText="ProfileColor" />
                                                        <asp:BoundField DataField="HardwareColor" HeaderText="HardwareColor" />



                                                         <asp:BoundField DataField="UnitCostEuro" HeaderText="UnitCostEuro" />
                                                        <asp:BoundField DataField="TotalAmount" HeaderText="TotalAmount" />
                                                      






                                                     
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <div style="text-align: center">
                                                            <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                                        </div>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>

               </div>


    </div>







</asp:Content>

