<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Supplier_Quotation.aspx.cs" Inherits="Modules_Purchases_Supplier_Quotation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


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
            <h3>Supplier Quotation</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Supplier Quotations</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Sup_Quo_Id" HeaderText="Sl.No" SortExpression="Sup_Quo_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Sup_Quo_No" HeaderText="Quotation No" SortExpression="Sup_Quo_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Sup_Quo_Date" HeaderText="Date" SortExpression="Sup_Quo_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="SUP_NAME" HeaderText="Supplier Name" SortExpression="SUP_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="GrandTotal" HeaderText="Grand Total" SortExpression="GrandTotal">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Preparedby" HeaderText="Prepared By" SortExpression="Preparedby">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="ApprovedBy" HeaderText="Approved By" SortExpression="ApprovedBy">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Purchases/SupplierQuotation_Details.aspx?Cid=" + Eval("Sup_Quo_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT Supplier_Quotation_Master.Sup_Quo_Id, Supplier_Quotation_Master.Sup_Quo_No, Supplier_Quotation_Master.Sup_Quo_Date, Supplier_Master.SUP_NAME, Supplier_Master.SUP_ADDRESS, Supplier_Quotation_Master.GrandTotal, Employee_Master_1.EMP_FIRST_NAME+' '+Employee_Master_1.EMP_LAST_NAME as Preparedby, Employee_Master.EMP_FIRST_NAME+' '+Employee_Master.EMP_LAST_NAME AS ApprovedBy FROM Supplier_Quotation_Master INNER JOIN Supplier_Master ON Supplier_Quotation_Master.Sup_Id = Supplier_Master.SUP_ID INNER JOIN Employee_Master AS Employee_Master_1 ON Supplier_Quotation_Master.PreparedBy = Employee_Master_1.EMP_ID INNER JOIN Employee_Master ON Supplier_Quotation_Master.ApprovedBy = Employee_Master.EMP_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>