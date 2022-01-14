<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="ScarpStock.aspx.cs" Inherits="Modules_Stock_ScarpStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

         <script type="text/javascript">
             $(document).ready(function () {
                 //fnPageLoad();
             });
             function fnPageLoad() {
                 $('#<%=hai.ClientID%>').prepend($("<thead></thead>").append($('#<%=hai.ClientID%>').find("tr:first"))).DataTable({

                  bSort: true,
                  dom: '<"html5buttons"B>lTfgitp',
                  //lengthChange: false,
                  pageLength: 10,

                  bStateSave: true,
                  order: [[0, 'desc']],
              });
          }
</script>





     <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Rejected Stock Details form MRN</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" Visible="false" runat="server" Text="Rejected to Stock" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="hai_RowDataBound" >
                <Columns>

                  <%--    <asp:BoundField DataField="SPR_DET_ID" HeaderText="SPR_DET_ID" SortExpression="SPR_DET_ID" />--%>

                    <asp:BoundField DataField="ProjectCode" HeaderText="Project" SortExpression="ProjectCode" />

                    <asp:BoundField DataField="SPR_NO" HeaderText="MRN No" SortExpression="SPR_NO" />

                      <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" SortExpression="InvoiceNo" />

                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" SortExpression="Material_Code" />

                    <asp:BoundField DataField="Color_Name" HeaderText="Color" SortExpression="Color_Name" />

                     <asp:BoundField DataField="Lengthh" HeaderText="Length" SortExpression="Lengthh" />

                     <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />

                     <asp:BoundField DataField="PO_DET_QTY" HeaderText="Ordered Qty" SortExpression="PO_DET_QTY" />
                   
                     <asp:BoundField DataField="PO_RECEIVED_QTY" HeaderText="Received Qty" SortExpression="PO_RECEIVED_QTY" />

                     <asp:BoundField  HeaderText="Short(-)/Excess Qty"  />
                   
                    <asp:BoundField DataField="PO_ACCEPTED_QTY" HeaderText="Accepted Qty" SortExpression="PO_ACCEPTED_QTY" />
                   
                    <asp:BoundField DataField="PO_REJECTED_QTY" HeaderText="Rejected Qty" SortExpression="PO_REJECTED_QTY" />
                   
                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                   
                   
                    
                </Columns>
            </asp:GridView>

         <%--   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select Supplier_PurchaseReceipt_Details.Lengthh as mrnlength,* from Supplier_PurchaseReceipt_Details,Material_Master,Plant_Master,StorageLocation_Master,Color_Master where Supplier_PurchaseReceipt_Details.MAT_ID = Material_Master.Material_Id and Supplier_PurchaseReceipt_Details.COLOR_ID = Color_Master.Color_Id and Supplier_PurchaseReceipt_Details.PLANT_ID = Plant_Master.Plant_Id and Supplier_PurchaseReceipt_Details.STORAGELOC_ID = StorageLocation_Master.StorageLoacation_Id and PO_REJECTED_QTY > 0"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>--%>
        </div>
    </div>



    </asp:Content>

