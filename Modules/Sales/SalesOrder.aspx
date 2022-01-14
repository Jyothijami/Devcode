<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SalesOrder.aspx.cs" Inherits="Modules_Sales_SalesOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    
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


     <%--  <asp:UpdatePanel ID="RegUpdatePanel" runat="server">
        <ContentTemplate>--%>






       <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Sales Orders</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Sales Order</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="SalesOrder_Id" HeaderText="Sl.No" SortExpression="SalesOrder_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SalesOrder_No" HeaderText="Sales Order No" SortExpression="SalesOrder_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>


                      <asp:BoundField DataField="ProjectCode" HeaderText="Project Code" SortExpression="ProjectCode">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>



                    <asp:BoundField DataField="SalesOrder_Date" HeaderText="Date" SortExpression="SalesOrder_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="CUST_NAME" HeaderText="Customer" SortExpression="CUST_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                           <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" SortExpression="CUST_UNIT_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Delivery_Date" HeaderText="Delivery Date" SortExpression="Delivery_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                 
                    <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Prepared By" SortExpression="EMP_FIRST_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                      <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    <asp:TemplateField HeaderText="Material Analaysis" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Sales/MaterialAnaSo.aspx?Cid=" + Eval("SalesOrder_Id") %>'><i class="icon-stack"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>



                     <asp:TemplateField HeaderText="Glass Requirement" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnglassRequirement" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Sales/SoGlassAnalaysis.aspx?Cid=" + Eval("SalesOrder_Id") %>'><i class="icon-stack"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>





                      <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Sales/SalesOrderDocs.aspx?Cid=" + Eval("SalesOrder_Id") %>'><i class="icon-attachment"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>





                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Sales/SalesOrder_Details.aspx?Cid=" + Eval("SalesOrder_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT Sales_Order.Status,Sales_Order.SalesOrder_Id,Sales_Order.ProjectCode, Sales_Order.SalesOrder_No, Sales_Order.SalesOrder_Date, Sales_Order.Delivery_Date, Sales_Order.PreparedBy, Sales_Order.Status, Employee_Master.EMP_FIRST_NAME, Customer_Master.CUST_NAME, Customer_Units.CUST_UNIT_NAME FROM Sales_Order INNER JOIN Employee_Master ON Sales_Order.PreparedBy = Employee_Master.EMP_ID INNER JOIN Customer_Master ON Sales_Order.CustId = Customer_Master.CUST_ID INNER JOIN Customer_Units ON Sales_Order.CustSiteId = Customer_Units.CUST_UNIT_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>

             <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>

</asp:Content>

