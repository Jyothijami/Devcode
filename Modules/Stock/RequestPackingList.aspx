<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="RequestPackingList.aspx.cs" Inherits="Modules_Stock_RequestPackingList" %>

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





   <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Request Packing List</h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Request PackingList</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="RPackingList_Id" HeaderText="Sl.No" SortExpression="RPackingList_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RPackingList_No" HeaderText="Request Packing No" SortExpression="RPackingList_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="RPackingList_Date" HeaderText="Date" SortExpression="RPackingList_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     <asp:BoundField DataField="SalesOrder_No" HeaderText="Sales Order No" SortExpression="SalesOrder_No" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                      <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" SortExpression="CUST_UNIT_NAME" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Cust_Address" HeaderText="Cust Address" SortExpression="Cust_Address">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    
                    <asp:BoundField DataField="Delivery_Address" HeaderText="Delivery Address" SortExpression="Delivery_Address">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                       <asp:BoundField DataField="PreparedBy" HeaderText="Prepared By" SortExpression="PreparedBy">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                      <asp:BoundField DataField="Approvedby" HeaderText="Approved By" SortExpression="Approvedby">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>





<%--                     <asp:TemplateField HeaderText="Print" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnPrint" runat="server" CssClass="btn btn-icon btn-info" OnClick="lbtnPrint_Click"><i class="icon-print"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Stock/RequestPackingList_Details.aspx?Cid=" + Eval("RPackingList_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

<%--            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT * from Request_PackingList"></asp:SqlDataSource>
         --%> 
            
            
              <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand=" SELECT Delivery_Address,Cust_Address,RPackingList_Id,RPackingList_No,RPackingList_Date, Sales_Order.SalesOrder_No, Customer_Units.CUST_UNIT_NAME, 
                          Employee_Master_1.EMP_FIRST_NAME as PreparedBy, Employee_Master.EMP_FIRST_NAME AS Approvedby
                         FROM  Request_PackingList left JOIN
                         Sales_Order ON Request_PackingList.SO_Id = Sales_Order.SalesOrder_Id INNER JOIN
                         Employee_Master AS Employee_Master_1 ON Request_PackingList.PreparedBy = Employee_Master_1.EMP_ID INNER JOIN
                         Employee_Master ON Request_PackingList.APPROVEDBY = Employee_Master.EMP_ID left JOIN
                         Customer_Units ON Request_PackingList.Cust_Id = Customer_Units.CUST_UNIT_ID"></asp:SqlDataSource>
            
            
              <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>

