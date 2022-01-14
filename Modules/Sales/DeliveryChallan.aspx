<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="DeliveryChallan.aspx.cs" Inherits="Modules_Sales_DeliveryChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Delivery Challan</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Delivery Challan</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Dc_Id" HeaderText="Sl.No" SortExpression="Dc_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Dc_No" HeaderText="Delivery Challan No" SortExpression="Dc_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Dc_Date" HeaderText="Date" SortExpression="Dc_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SalesOrder_No" HeaderText="Sales Order No" SortExpression="SalesOrder_No">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CUST_NAME" HeaderText="Clinet" SortExpression="CUST_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Site" SortExpression="CUST_UNIT_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Prepared By" SortExpression="EMP_FIRST_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Sales/DeliveryChallan_Details.aspx?Cid=" + Eval("Dc_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT Customer_Master.CUST_NAME, Employee_Master.EMP_FIRST_NAME, Customer_Units.CUST_UNIT_NAME, Delivery_Challan_Master.Dc_Id, Delivery_Challan_Master.Dc_No, Delivery_Challan_Master.Dc_Date, Delivery_Challan_Master.Transport_id, Delivery_Challan_Master.Lr_No, Delivery_Challan_Master.Lr_Date, Delivery_Challan_Master.So_Id, Delivery_Challan_Master.Preparedby, Delivery_Challan_Master.ApprovedBy, Delivery_Challan_Master.Cust_Id, Delivery_Challan_Master.Unit_Id, Sales_Order.SalesOrder_No FROM Customer_Master INNER JOIN Delivery_Challan_Master ON Customer_Master.CUST_ID = Delivery_Challan_Master.Cust_Id INNER JOIN Employee_Master ON Delivery_Challan_Master.Preparedby = Employee_Master.EMP_ID INNER JOIN Customer_Units ON Delivery_Challan_Master.Unit_Id = Customer_Units.CUST_UNIT_ID INNER JOIN Sales_Order ON Delivery_Challan_Master.So_Id = Sales_Order.SalesOrder_Id"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>