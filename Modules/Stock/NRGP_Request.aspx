<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="NRGP_Request.aspx.cs" Inherits="Modules_Stock_NRGP_Request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
            <h3>Request NRGP</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Request NRGP</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="NRGP_Request_Id" HeaderText="Sl.No" SortExpression="NRGP_Request_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NRgp_Request_No" HeaderText="NRGP Request No" SortExpression="NRgp_Request_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="NRgp_Request_Date" HeaderText="Date" SortExpression="NRgp_Request_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Receiver_Name" HeaderText="Receiver Name" SortExpression="Receiver_Name">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Preparedb" HeaderText="Prepared By" SortExpression="Preparedb">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Approvedby" HeaderText="Approved By" SortExpression="Approvedby">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Stock/NRGP_Request_Details.aspx?Cid=" + Eval("NRGP_Request_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        Employee_Master.EMP_FIRST_NAME AS Preparedb, Employee_Master_1.EMP_FIRST_NAME AS Approvedby, NRGP_Request.*
FROM            Employee_Master INNER JOIN
                         NRGP_Request ON Employee_Master.EMP_ID = NRGP_Request.PreparedBy INNER JOIN
                         Employee_Master AS Employee_Master_1 ON NRGP_Request.RequestedBy = Employee_Master_1.EMP_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>