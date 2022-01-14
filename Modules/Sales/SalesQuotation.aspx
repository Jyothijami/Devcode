<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SalesQuotation.aspx.cs" Inherits="Modules_Sales_SalesQuotation" %>

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
 <%--    <asp:UpdatePanel ID="RegUpdatePanel" runat="server">
        <ContentTemplate>--%>


    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Sales Quotation</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Open Quotations</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="Quotation_Id,Unit_Id" OnRowCommand="hai_RowCommand" OnRowDataBound="hai_RowDataBound" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Quotation_Id" HeaderText="Sl.No" SortExpression="Quotation_Id"></asp:BoundField>
                    <asp:BoundField DataField="QUOTNO" HeaderText="Quotation No" SortExpression="QUOTNO"></asp:BoundField>
                     <asp:BoundField DataField="OptionKey" HeaderText="Option" SortExpression="OptionKey"></asp:BoundField>
                    <asp:BoundField DataField="Quotation_Date" HeaderText="Date" SortExpression="Quotation_Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>

                    <asp:BoundField DataField="CUST_NAME" HeaderText="Customer" SortExpression="CUST_NAME"></asp:BoundField>

                    <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" SortExpression="CUST_UNIT_NAME"></asp:BoundField>

                   <%-- <asp:BoundField DataField="Valid_To" HeaderText="Vaild to" SortExpression="Valid_To" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>--%>
                    <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Prepared By" SortExpression="EMP_FIRST_NAME"></asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                    <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Sales/Quatation_Documents.aspx?Cid=" + Eval("Quotation_Id") %>'><i class="icon-attachment"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Images" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnimages" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Sales/QuotImage.aspx?Cid=" + Eval("Quotation_Id") %>'><i class="icon-attachment"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Sales/SalesQuotationDetails.aspx?Cid=" + Eval("Quotation_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Print">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlReports" runat="server" Width="60px" EnableViewState="true">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>Basic</asp:ListItem>
                                        <asp:ListItem>Group By Color</asp:ListItem>
                                        <asp:ListItem>With Image</asp:ListItem>
                                        <asp:ListItem>With Discount</asp:ListItem>
                                        <asp:ListItem>System &amp; Glass Price</asp:ListItem>
                                        <asp:ListItem>Summary</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="Print" runat="server"
                                        CommandArgument="<%# Container.DataItemIndex%>" CommandName="Print"
                                        Text="Print" />
                                </div>
                            </div>
                        </ItemTemplate>
                        <%-- <ItemStyle Width="15%" />--%>
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

                    <asp:BoundField DataField="Unit_Id" HeaderText="Unit Id" SortExpression="Unit_Id"></asp:BoundField>
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT Quotation_Master.Quotation_No + ' ' + Quotation_Master.RevisedKey AS QUOTNO,Quotation_Master.OptionKey , Quotation_Master.Quotation_Id, Quotation_Master.Quotation_No, Quotation_Master.Quotation_Date, Quotation_Master.Quotation_to, Quotation_Master.Valid_To, Quotation_Master.Enq_Id, Quotation_Master.Cust_ID, Quotation_Master.Unit_Id, Quotation_Master.SalesEmp_Id, Quotation_Master.PaymentTerms_Id, Quotation_Master.TermsCondtions_Id, Quotation_Master.Discount, Quotation_Master.Tax, Quotation_Master.GrandTotal, Quotation_Master.PreparedBy, Quotation_Master.ApprovedBy, Quotation_Master.RevisedKey, Quotation_Master.Status, Quotation_Master.InstallationTemp_Id, Quotation_Master.DamageTemp_Id, Quotation_Master.StorageTemp_Id, Quotation_Master.Specifications, Customer_Master.CUST_NAME, Employee_Master.EMP_FIRST_NAME, Customer_Units.CUST_UNIT_NAME FROM Customer_Master INNER JOIN Quotation_Master ON Customer_Master.CUST_ID = Quotation_Master.Cust_ID INNER JOIN Employee_Master ON Quotation_Master.PreparedBy = Employee_Master.EMP_ID INNER JOIN Customer_Units ON Quotation_Master.Unit_Id = Customer_Units.CUST_UNIT_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>


          <%--    </ContentTemplate>
    </asp:UpdatePanel>--%>

</asp:Content>