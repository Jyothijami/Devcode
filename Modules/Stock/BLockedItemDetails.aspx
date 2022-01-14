<%@ Page Title="" Language="C#" MasterPageFile="~/ModalPop.master" AutoEventWireup="true" CodeFile="BLockedItemDetails.aspx.cs" Inherits="Modules_Stock_BLockedItemDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="panel panel-default">


        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Item Blocked Details</h6>
        </div>

        <div class="panel-body">



            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="BlockStock_Id" HeaderText="Sl.No" SortExpression="BlockStock_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="CUST_NAME" HeaderText="Cust Name" SortExpression="CUST_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="ProjectCode" HeaderText="Project Code" SortExpression="ProjectCode">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" SortExpression="Material_Code">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Color_Name" HeaderText="Color" SortExpression="Color_Name">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="UOM_SHORT_DESC" HeaderText="UOM" SortExpression="UOM_SHORT_DESC">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="blocklength" HeaderText="Length" SortExpression="blocklength">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>



        </div>


    </div>




    <div class="panel panel-default">

        <div class="panel-heading">
             <h6 class="panel-title"><i class="icon-file"></i>Material Received Notes</h6>
        </div>


        <div class="panel-body">

            <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="SPR_NO" HeaderText="MRN No" />
                    <asp:BoundField DataField="SPR_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date Received" />
                    <asp:BoundField DataField="ProjectCode" HeaderText="Project" />
                     <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Color_Name" HeaderText="Color" />
                    <asp:BoundField DataField="Lengthh" HeaderText="Length" />
                    <asp:BoundField DataField="PO_RECEIVED_QTY" HeaderText="Received Qty" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>


        </div>
    </div>

















</asp:Content>

