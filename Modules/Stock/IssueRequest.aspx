<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="IssueRequest.aspx.cs" Inherits="Modules_Stock_IssueRequest" %>

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
            <h3>Issue Request Slip </h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Issue Request Slip </h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Req_Issue_Id" HeaderText="Sl.No" SortExpression="Req_Issue_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Req_Issue_No" HeaderText="Request Issue No" SortExpression="Req_Issue_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Req_Issue_Date" HeaderText="Date" SortExpression="Req_Issue_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                     <asp:BoundField DataField="SalesOrder_No" HeaderText="Sales Order No" SortExpression="SalesOrder_No" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                      <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" SortExpression="CUST_UNIT_NAME" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                     <asp:BoundField DataField="Req_Purpose" HeaderText="Purpose" SortExpression="Req_Purpose">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                      <asp:BoundField DataField="PreparedBy" HeaderText="Prepared By" SortExpression="PreparedBy">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                      <asp:BoundField DataField="Approvedby" HeaderText="Approved By" SortExpression="Approvedby">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                     
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
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Stock/IssueRequest_Details.aspx?Cid=" + Eval("Req_Issue_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand=" SELECT Request_Material_Issue.Req_Issue_Id, Request_Material_Issue.Req_Issue_No, Request_Material_Issue.Req_Issue_Date, Sales_Order.SalesOrder_No, Customer_Units.CUST_UNIT_NAME, 
                         Request_Material_Issue.Req_Purpose, Employee_Master_1.EMP_FIRST_NAME as PreparedBy, Employee_Master.EMP_FIRST_NAME AS Approvedby
                         FROM  Request_Material_Issue left JOIN
                         Sales_Order ON Request_Material_Issue.So_Id = Sales_Order.SalesOrder_Id INNER JOIN
                         Employee_Master AS Employee_Master_1 ON Request_Material_Issue.Reqested_By = Employee_Master_1.EMP_ID INNER JOIN
                         Employee_Master ON Request_Material_Issue.Approved_By = Employee_Master.EMP_ID left JOIN
                         Customer_Units ON Request_Material_Issue.Cust_Id = Customer_Units.CUST_UNIT_ID"></asp:SqlDataSource>
          
        </div>
    </div>





</asp:Content>

