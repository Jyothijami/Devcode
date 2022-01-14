<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="SalesInvoice.aspx.cs" Inherits="Modules_Sales_SalesInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Sales Invoice</h3>
        </div>
    </div>
    <!-- /page header -->

      <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Sales Invoice</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Invoice_Id" HeaderText="Sl.No" SortExpression="Invoice_Id">
                        <HeaderStyle Font-Size="X-Small" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Invoice_No" HeaderText="Invoice No" SortExpression="Invoice_No">
                        <HeaderStyle Font-Size="X-Small" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Invoice_Date" HeaderText="Date" SortExpression="Invoice_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="X-Small" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SalesOrder_No" HeaderText="Sales Order No" SortExpression="SalesOrder_No">
                        <HeaderStyle Font-Size="X-Small" />
                    </asp:BoundField>
                     <asp:BoundField DataField="GrandTotal" HeaderText="Total Amount" SortExpression="GrandTotal">
                        <HeaderStyle Font-Size="X-Small" />
                    </asp:BoundField>
                     <asp:BoundField DataField="BalanceDue" HeaderText="Due Amount" SortExpression="BalanceDue">
                        <HeaderStyle Font-Size="X-Small" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CUST_NAME" HeaderText="Clinet" SortExpression="CUST_NAME">
                        <HeaderStyle Font-Size="X-Small" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Site" SortExpression="CUST_UNIT_NAME">
                        <HeaderStyle Font-Size="X-Small" />
                    </asp:BoundField>

                    <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Prepared By" SortExpression="EMP_FIRST_NAME">
                        <HeaderStyle Font-Size="X-Small" />
                    </asp:BoundField>


                    <asp:TemplateField HeaderText="Payment Received" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnPaymentReceived" runat="server" CssClass="btn btn-icon btn-danger" PostBackUrl='<%# "~/Modules/Sales/PaymentReceived.aspx?Cid=" + Eval("Invoice_Id") %>'><i class="icon-archive"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="X-Small" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>




                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Sales/SalesInvoiceDetails.aspx?Cid=" + Eval("Invoice_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="X-Small" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-icon btn-danger" OnClick="lbtnDelete_Click"><i class="icon-remove3"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="X-Small"/>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT Customer_Master.CUST_NAME, Employee_Master.EMP_FIRST_NAME, Customer_Units.CUST_UNIT_NAME, Sales_Order.SalesOrder_No, Sales_Invoice.* FROM Customer_Master INNER JOIN Sales_Invoice INNER JOIN Sales_Order ON Sales_Invoice.So_Id = Sales_Order.SalesOrder_Id INNER JOIN Employee_Master ON Sales_Invoice.PreparedBy = Employee_Master.EMP_ID INNER JOIN Customer_Units ON Sales_Invoice.UnitId = Customer_Units.CUST_UNIT_ID ON Customer_Master.CUST_ID = Sales_Invoice.CustId"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>

</asp:Content>

