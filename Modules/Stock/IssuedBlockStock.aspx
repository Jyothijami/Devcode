<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="IssuedBlockStock.aspx.cs" Inherits="Modules_Stock_IssuedBlockStock" %>

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
            <h3>Block Stock Realase </h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Block Relase  </h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="IssueBlock_Id" HeaderText="Sl.No" SortExpression="IssueBlock_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IssueBlock_No" HeaderText="Block Issue No" SortExpression="IssueBlock_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Issue_Date" HeaderText="Date" SortExpression="Issue_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     <asp:BoundField DataField="RequestBlockRelase_No" HeaderText="Request_No" SortExpression="RequestBlockRelase_No">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                       <asp:BoundField DataField="ProjectCode" HeaderText="From Project" SortExpression="ProjectCode">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Expr1" HeaderText="To Project" SortExpression="Expr1">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                     
                    <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Issued By" SortExpression="EMP_FIRST_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Stock/IssuedBlockStockDetails.aspx?Cid=" + Eval("IssueBlock_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        IssuedBlockStock.IssueBlock_Id, IssuedBlockStock.IssueBlock_No, IssuedBlockStock.Issue_Date, Sales_Order.ProjectCode, Sales_Order_1.ProjectCode AS Expr1, Employee_Master.EMP_FIRST_NAME, 
                         RequestBlockStock_Release.RequestBlockRelase_No
FROM            IssuedBlockStock INNER JOIN
                         Sales_Order ON IssuedBlockStock.From_So_Id = Sales_Order.SalesOrder_Id INNER JOIN
                         Sales_Order AS Sales_Order_1 ON IssuedBlockStock.To_So_Id = Sales_Order_1.SalesOrder_Id INNER JOIN
                         Employee_Master ON IssuedBlockStock.Approved_By = Employee_Master.EMP_ID INNER JOIN
                         RequestBlockStock_Release ON IssuedBlockStock.ReqestBlock_Id = RequestBlockStock_Release.RequestBlockRelase_Id"></asp:SqlDataSource>
          
        </div>
    </div>





</asp:Content>

