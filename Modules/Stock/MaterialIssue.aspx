<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="MaterialIssue.aspx.cs" Inherits="Modules_Stock_MaterialIssue" %>

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
            <h3>Material Issued </h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Material Issued </h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Issue_Id" HeaderText="Sl.No" SortExpression="Issue_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Issue_No" HeaderText="Issue No" SortExpression="Issue_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Issue_Date" HeaderText="Date" SortExpression="Issue_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     <asp:BoundField DataField="Req_Issue_No" HeaderText="Request_No" SortExpression="Req_Issue_No">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                       <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="For Project" SortExpression="CUST_UNIT_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                       <asp:BoundField DataField="RequestedBy" HeaderText="Requested By" SortExpression="RequestedBy">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IssuedBy" HeaderText="Issued By" SortExpression="IssuedBy">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Stock/MaterialIssue_Details.aspx?Cid=" + Eval("Issue_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        Material_Issue.Issue_Id, Material_Issue.Issue_No, Material_Issue.Issue_Date, Request_Material_Issue.Req_Issue_No, Customer_Units.CUST_UNIT_NAME, Employee_Master.EMP_FIRST_NAME as RequestedBy, 
                         Employee_Master_1.EMP_FIRST_NAME AS IssuedBy
FROM            Material_Issue INNER JOIN
                         Request_Material_Issue ON Material_Issue.Reqest_Id = Request_Material_Issue.Req_Issue_Id INNER JOIN
                         Customer_Units ON Material_Issue.Cust_Id = Customer_Units.CUST_UNIT_ID INNER JOIN
                         Employee_Master ON Material_Issue.Reqested_By = Employee_Master.EMP_ID INNER JOIN
                         Employee_Master AS Employee_Master_1 ON Material_Issue.Approved_By = Employee_Master_1.EMP_ID"></asp:SqlDataSource>
          
        </div>
    </div>





</asp:Content>

