<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="PurchaseOrder.aspx.cs" Inherits="Modules_Purchases_PurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Purchase Order</h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Purchase Order</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="PO_ID" HeaderText="Sl.No" SortExpression="PO_ID">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PO_NO" HeaderText="Indent No" SortExpression="PO_NO">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="PO_DATE" HeaderText="Date" SortExpression="PO_DATE" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     <asp:BoundField DataField="Indent_No" HeaderText="Indent No" SortExpression="Indent_No">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    <asp:BoundField DataField="SUP_NAME" HeaderText="Supplier" SortExpression="SUP_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NET_AMOUNT" HeaderText="Net Amount" SortExpression="NET_AMOUNT">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                      <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Prepared By" SortExpression="EMP_FIRST_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Purchases/PurchaseOrderDetails.aspx?Cid=" + Eval("PO_ID") %>'><i class="icon-wrench2"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT Employee_Master.EMP_FIRST_NAME, Suplier_PurchaseOrder.PO_ID, Suplier_PurchaseOrder.PO_NO, Suplier_PurchaseOrder.PO_DATE, Suplier_PurchaseOrder.IND_ID, Suplier_PurchaseOrder.SUP_ID, Suplier_PurchaseOrder.PO_STATUS, Suplier_PurchaseOrder.NET_AMOUNT, Suplier_PurchaseOrder.TERMS_COND, Suplier_PurchaseOrder.DESPM_ID, Suplier_PurchaseOrder.PAYMENTTERMS_ID, Suplier_PurchaseOrder.CURRENCY_ID, Suplier_PurchaseOrder.PO_DESTINATION, Suplier_PurchaseOrder.PO_INSURANCE, Suplier_PurchaseOrder.PO_FREIGHT, Suplier_PurchaseOrder.PO_DISCOUNT, Suplier_PurchaseOrder.PO_TAXGST, Suplier_PurchaseOrder.PREPAREDBY, Suplier_PurchaseOrder.APPROVEDBY, Suplier_PurchaseOrder.FPO_CIF, Suplier_PurchaseOrder.FPO_FOB, Suplier_PurchaseOrder.TERMS_DELIVERY, Indent_Master.Indent_No, Supplier_Master.SUP_NAME FROM Supplier_Master INNER JOIN Suplier_PurchaseOrder ON Supplier_Master.SUP_ID = Suplier_PurchaseOrder.SUP_ID INNER JOIN Indent_Master ON Suplier_PurchaseOrder.IND_ID = Indent_Master.Indent_Id INNER JOIN Employee_Master ON Suplier_PurchaseOrder.PREPAREDBY = Employee_Master.EMP_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>



</asp:Content>

