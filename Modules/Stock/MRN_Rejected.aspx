<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="MRN_Rejected.aspx.cs" Inherits="Modules_Stock_MRN_Rejected" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


       <script type="text/javascript">
           $(document).ready(function () {
           });
           function fnPageLoad() {
               $('#<%=hai.ClientID%>').prepend($("<thead></thead>").append($('#<%=hai.ClientID%>').find("tr:first"))).DataTable({

                   bSort: true,
                   dom: '<"html5buttons"B>lTfgitp',
                   pageLength: 10,

                   bStateSave: true,
                   order: [[0, 'desc']],




               });
           }
</script>


    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>MRN Rejected History</h6>
            <span class="pull-right">
                </span>
        </div>

       
        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>


                    <asp:BoundField DataField="MRN NO" HeaderText="MRN NO" SortExpression="MRN NO" />
                    <asp:BoundField DataField="MRN Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="MRN Date" SortExpression="MRN Date" />
                    <asp:BoundField DataField="Invoice No" HeaderText="Invoice No" SortExpression="Invoice No" />


                     <asp:BoundField DataField="Item Code" HeaderText="Item Code" SortExpression="Item Code" />
                    <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
                    <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color" />


                       <asp:BoundField DataField="Ordered Qty" HeaderText="Ordered Qty" SortExpression="Ordered Qty" />
                    <asp:BoundField DataField="Received Qty" HeaderText="Received Qty" SortExpression="Received Qty" />
                    <asp:BoundField DataField="Accepted Qty" HeaderText="Accepted Qty" SortExpression="Accepted Qty" />

                      <asp:BoundField DataField="Rejected Qty" HeaderText="Rejected Qty" SortExpression="Rejected Qty" />
                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                 
                      <asp:BoundField DataField="Project Code" HeaderText="Project Code" SortExpression="Project Code" />
                       <asp:BoundField DataField="PO NO" HeaderText="PO NO" SortExpression="PO NO" />
                    <asp:BoundField DataField="PO Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="PO Date" SortExpression="PO Date" />


                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        Supplier_PurchaseReceipt.SPR_NO as [MRN NO], Supplier_PurchaseReceipt.SPR_DATE as [MRN Date], Supplier_PurchaseReceipt.InvoiceNo as [Invoice No],  Material_Master.Material_Code as [Item Code], MRN_Rejected.length as Length, 
                         MRN_Rejected.Color, MRN_Rejected.det_qty as [Ordered Qty], MRN_Rejected.recived_Qty as [Received Qty], MRN_Rejected.accepted_qty as [Accepted Qty], MRN_Rejected.rejected_qty as [Rejected Qty], MRN_Rejected.Remarks, Supplier_Po_Master.CustomerNo as [Project Code], 
                         Supplier_Po_Master.Sup_PO_No as [PO NO], Supplier_Po_Master.Sup_PO_Date as [PO Date]
FROM            MRN_Rejected INNER JOIN
                         Supplier_PurchaseReceipt ON MRN_Rejected.MRn_Id = Supplier_PurchaseReceipt.SPR_ID INNER JOIN
                         Supplier_Po_Master ON MRN_Rejected.po_Id = Supplier_Po_Master.Sup_PO_Id INNER JOIN
                         Material_Master ON MRN_Rejected.matid = Material_Master.Material_Id"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>

        
    </div>
</asp:Content>