<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="ScrapGlassDetails.aspx.cs" Inherits="Modules_Stock_ScrapGlassDetails" %>

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
            <h6 class="panel-title"><i class="icon-file"></i>Rejected Glass Purchase Good Receipt</h6>
           
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="SPR_NO" HeaderText="MRN.No" SortExpression="SPR_NO" />
                    <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" SortExpression="InvoiceNo" />
                    <asp:BoundField DataField="SPR_DATE" HeaderText="Date Received" DataFormatString="{0:dd/MM/yyyy}" SortExpression="SPR_DATE" />
                     
                    
                      <asp:BoundField DataField="Sup_GPO_No" HeaderText="PO.No" SortExpression="Sup_GPO_No" />
                    

                      <asp:BoundField DataField="WindowCode" HeaderText="WindowCode" SortExpression="WindowCode" />
                      <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                      <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                      <asp:BoundField DataField="Height" HeaderText="Height" SortExpression="Height" />
                      <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" />
                      <asp:BoundField DataField="PO_REJECTED_QTY" HeaderText="Rejected Qty" SortExpression="PO_REJECTED_QTY" />
                     <asp:BoundField DataField="SUP_NAME" HeaderText="Sup Name" SortExpression="SUP_NAME" />
                     <asp:BoundField DataField="CustomerNo" HeaderText="Customer" SortExpression="CustomerNo" />
                    
                 
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                     
                    
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        Glass_PurchaseReceipt.SPR_NO, Glass_PurchaseReceipt.SPR_DATE, Glass_PurchaseReceipt.InvoiceNo, Glass_PO_Master.Sup_GPO_No, GlassPurchaseReceipt_Rejected.WindowCode, 
                         GlassPurchaseReceipt_Rejected.Description, GlassPurchaseReceipt_Rejected.Width, GlassPurchaseReceipt_Rejected.Height, GlassPurchaseReceipt_Rejected.Area, 
                         GlassPurchaseReceipt_Rejected.PO_REJECTED_QTY, Glass_PO_Master.CustomerNo, Supplier_Master.SUP_NAME
FROM            Glass_PurchaseReceipt INNER JOIN
                         GlassPurchaseReceipt_Rejected ON Glass_PurchaseReceipt.SPR_ID = GlassPurchaseReceipt_Rejected.SPR_ID INNER JOIN
                         Supplier_Master INNER JOIN
                         Glass_PO_Master ON Supplier_Master.SUP_ID = Glass_PO_Master.Sup_Id ON Glass_PurchaseReceipt.SUP_PO_ID = Glass_PO_Master.Sup_GPO_Id"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>


   








</asp:Content>

