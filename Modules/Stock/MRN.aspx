<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="MRN.aspx.cs" Inherits="Modules_Stock_MRN" %>

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
            <h6 class="panel-title"><i class="icon-file"></i>Purchase Good Receipt</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="SPR_ID" HeaderText="Sl.No" SortExpression="SPR_ID" />
                    <asp:BoundField DataField="SPR_NO" HeaderText="SPR No" SortExpression="SPR_NO" />
                    <asp:BoundField DataField="SPR_DATE" HeaderText="Date Received" DataFormatString="{0:dd/MM/yyyy}" SortExpression="SPR_DATE" />
                     
                    
                      <asp:BoundField DataField="Sup_PO_No" HeaderText="PO.No" SortExpression="Sup_PO_No" />
                    <asp:BoundField DataField="SPR_NO" HeaderText="PO Date" SortExpression="SPR_NO" />
                    <asp:BoundField DataField="Sup_PO_Date" HeaderText="PO Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Sup_PO_Date" />
                    
                    
                     <asp:BoundField DataField="SUP_NAME" HeaderText="Sup Name" SortExpression="SUP_NAME" />
                     <asp:BoundField DataField="InvoiceNo" HeaderText="Inovice No" SortExpression="InvoiceNo" />
                    
                 
                    
                    
                    
                    
                    
                    
                    
                     <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Stock/SupPO_Documents.aspx?Cid=" + Eval("SPR_ID") %>'><i class="icon-attachment"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Print" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnPrint" runat="server" CssClass="btn btn-icon btn-info" OnClick="lbtnPrint_Click"><i class="icon-print"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Stock/PurchaseGoodsReceipt_Details.aspx?Cid=" + Eval("SPR_ID") %>'><i class="icon-wrench2"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-icon btn-danger" OnClick="lbtnDelete_Click"><i class="icon-remove3"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        Supplier_PurchaseReceipt.SPR_ID,InvoiceNo,
 Supplier_PurchaseReceipt.SPR_NO,
  Supplier_PurchaseReceipt.SPR_DATE, 
  Supplier_Po_Master.Sup_PO_No,
   Supplier_Po_Master.Sup_PO_Date, 
                         Supplier_Master.SUP_NAME, 
						 Supplier_PurchaseReceipt.Vehical_No
FROM            Supplier_PurchaseReceipt INNER JOIN
                         Supplier_Po_Master ON Supplier_PurchaseReceipt.SUP_PO_ID = Supplier_Po_Master.Sup_PO_Id INNER JOIN
                         Supplier_Master ON Supplier_Po_Master.Sup_Id = Supplier_Master.SUP_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>

</asp:Content>

