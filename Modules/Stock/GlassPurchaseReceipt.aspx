<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="GlassPurchaseReceipt.aspx.cs" Inherits="Modules_Stock_GlassPurchaseReceipt" %>

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
            <h6 class="panel-title"><i class="icon-file"></i>Purchase Glass Receipt</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="SPR_ID" HeaderText="Sl.No" SortExpression="SPR_ID" />
                    <asp:BoundField DataField="SPR_NO" HeaderText="SPR No" SortExpression="SPR_NO" />
                    <asp:BoundField DataField="SPR_DATE" HeaderText="Date Received" DataFormatString="{0:dd/MM/yyyy}" SortExpression="SPR_DATE" />
                      <asp:BoundField DataField="Sup_GPO_No" HeaderText="PO.No" SortExpression="Sup_GPO_No" />
                    <asp:BoundField DataField="Sup_GPO_Date" HeaderText="PO Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Sup_GPO_Date" />
                     <asp:BoundField DataField="SUP_NAME" HeaderText="Sup Name" SortExpression="SUP_NAME" />
                     <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" SortExpression="InvoiceNo" />
                    
                        <asp:BoundField DataField="CustomerNo" HeaderText="Project" SortExpression="CustomerNo" />
                     <asp:BoundField DataField="IndentNo" HeaderText="PO No" SortExpression="IndentNo" />
                 
                     <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Stock/PurchaseGlassReceipt.aspx?Cid=" + Eval("SPR_ID") %>'><i class="icon-wrench2"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        Glass_PurchaseReceipt.SPR_ID, Glass_PurchaseReceipt.SPR_NO, Glass_PurchaseReceipt.SPR_DATE, Glass_PO_Master.Sup_GPO_No, Glass_PO_Master.Sup_GPO_Date, Glass_PurchaseReceipt.InvoiceNo, 
                         Supplier_Master.SUP_NAME, Glass_PO_Master.CustomerNo, Glass_PO_Master.IndentNo
FROM            Glass_PurchaseReceipt INNER JOIN
                         Glass_PO_Master ON Glass_PurchaseReceipt.SUP_PO_ID = Glass_PO_Master.Sup_GPO_Id INNER JOIN
                         Supplier_Master ON Glass_PO_Master.Sup_Id = Supplier_Master.SUP_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>





</asp:Content>

