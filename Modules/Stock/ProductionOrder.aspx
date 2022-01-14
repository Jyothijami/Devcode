<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ProductionOrder.aspx.cs" Inherits="Modules_Stock_ProductionOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



     <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Item Production Details</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>
        <div class="panel-body">
            <div class="datatable-tasks">

                <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="ProductionOrder_Id" HeaderText="Sl.No" SortExpression="ProductionOrder_Id"  />
                        <asp:BoundField DataField="ProductionOrder_No" HeaderText="Production No" SortExpression="ProductionOrder_No" />
                        <asp:BoundField DataField="Code" HeaderText="Item Name" SortExpression="Code" />
                        <asp:BoundField DataField="QtytoManf" HeaderText="Qty to Manf" SortExpression="QtytoManf" />
                        <asp:BoundField DataField="SalesOrder_No" HeaderText="Salesorder No" SortExpression="SalesOrder_No" />
                         <asp:BoundField DataField="CUST_NAME" HeaderText="Customer Name" SortExpression="CUST_NAME" />
                         <asp:BoundField DataField="PlannedStartDate" HeaderText="Start Date" SortExpression="PlannedStartDate" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="ExpectedDeliceryDate" HeaderText="Delivery Date" SortExpression="ExpectedDeliceryDate" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                      
                        <asp:TemplateField HeaderText="Material Transfer" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnMaterialTransfer" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Stock/MaterialTrasfer_ManufactureDetails.aspx?Cid=" + Eval("ProductionOrder_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
                                </span>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>



                      



                       
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center">
                            <span style="color: #CC0000">No Data Found</span>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select * from ProductionOrder,SalesOrder_Details,Customer_Master,Sales_Order where ProductionOrder.Item_Id = SalesOrder_Details.SalesOrderDet_Id and  ProductionOrder.SalesOrder_Id = Sales_Order.SalesOrder_Id and Sales_Order.CustId = Customer_Master.CUST_ID order by ProductionOrder.ProductionOrder_Id desc"></asp:SqlDataSource>
              
            </div>
        </div>
    </div>





</asp:Content>

