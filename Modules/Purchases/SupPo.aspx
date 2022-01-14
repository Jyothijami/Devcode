<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SupPo.aspx.cs" Inherits="Modules_Purchases_SupPo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script type="text/javascript">
        $(document).ready(function () {
            //fnPageLoad();
        });
        function fnPageLoad() {
            $('#<%=hai.ClientID%>').prepend($("<thead></thead>").append($('#<%=hai.ClientID%>').find("tr:first"))).DataTable({

                bSort: true,
                dom: '<"html5buttons"B>lTfgitp',
                lengthChange: false,
                pageLength: 10,

                bStateSave: true,
                order: [[0, 'desc']],


                fixedHeader: {
                    header: true,
                    footer: true
                }

            });
        }
    </script>










    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Supplier Purchase Order</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Purchase Order</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <%-- <div class="datatable-tasks">--%>

        <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="hai_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Sup_PO_Id" HeaderText="Sl.No" SortExpression="Sup_PO_Id">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>
                <asp:BoundField DataField="Sup_PO_No" HeaderText="Sup PO No" SortExpression="Sup_PO_No">
                    <HeaderStyle Font-Size="Smaller" />
                    <ItemStyle Font-Size="Smaller" />
                </asp:BoundField>

                <asp:BoundField DataField="Sup_PO_Date" HeaderText="Date" SortExpression="Sup_PO_Date" DataFormatString="{0:dd/MM/yyyy}">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>


                <%--    <asp:BoundField DataField="Sup_Quo_Date" HeaderText="Quot Date" SortExpression="Sup_Quo_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>--%>

                <asp:BoundField DataField="SUP_NAME" HeaderText="Supplier Name" SortExpression="SUP_NAME">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>

                <asp:BoundField DataField="SUP_MOBILE" HeaderText="Mobile No" SortExpression="SUP_MOBILE">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>

                <asp:BoundField DataField="GrandTotal" HeaderText="Grand Total" SortExpression="GrandTotal">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>

                <asp:BoundField DataField="preparedby" HeaderText="Prepared By" SortExpression="preparedby">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>




                <asp:BoundField DataField="CustomerNo" HeaderText="CustomerNo" SortExpression="CustomerNo">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>





                <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                    <ItemTemplate>
                        <span class="text-center">
                            <asp:LinkButton ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Purchases/SupPODocs.aspx?Cid=" + Eval("Sup_PO_Id") %>'><i class="icon-attachment"></i></asp:LinkButton>
                        </span>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="GST Print" HeaderStyle-CssClass="text-center">
                    <ItemTemplate>
                        <span class="text-center">
                            <asp:LinkButton ID="lbtnPrint" runat="server" CssClass="btn btn-icon btn-info" OnClick="lbtnPrint_Click"><i class="icon-print"></i></asp:LinkButton>
                        </span>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="GIT Print" HeaderStyle-CssClass="text-center">
                    <ItemTemplate>
                        <span class="text-center">
                            <asp:LinkButton ID="lbtnPrint1" runat="server" CssClass="btn btn-icon btn-info" OnClick="lbtnPrint1_Click"><i class="icon-print"></i></asp:LinkButton>
                        </span>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Glass Print" HeaderStyle-CssClass="text-center">
                    <ItemTemplate>
                        <span class="text-center">
                            <asp:LinkButton ID="lbtnPrint2" runat="server" CssClass="btn btn-icon btn-info" OnClick="lbtnPrint2_Click"><i class="icon-print"></i></asp:LinkButton>
                        </span>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Annexure" HeaderStyle-CssClass="text-center">
                    <ItemTemplate>
                        <span class="text-center">
                            <asp:LinkButton ID="lbtnAnnexure" runat="server" CssClass="btn btn-icon btn-info" OnClick="lbtnAnnexure_Click"><i class="icon-print"></i></asp:LinkButton>
                        </span>
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                    <ItemTemplate>
                        <span class="text-center">
                            <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Purchases/SupplierPo_Details.aspx?Cid=" + Eval("Sup_PO_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT CustomerNo,Supplier_Po_Master.Sup_PO_Id, Supplier_Po_Master.Sup_PO_No, Supplier_Po_Master.Sup_PO_Date, Supplier_Quotation_Master.Sup_Quo_No, Supplier_Quotation_Master.Sup_Quo_Date, Supplier_Master.SUP_NAME, Supplier_Master.SUP_MOBILE, Supplier_Po_Master.GrandTotal,Employee_Master.EMP_FIRST_NAME+''+Employee_Master.EMP_LAST_NAME as preparedby FROM  Supplier_Po_Master INNER JOIN Supplier_Master ON Supplier_Po_Master.Sup_Id = Supplier_Master.SUP_ID INNER JOIN  Supplier_Quotation_Master ON Supplier_Po_Master.Matrequest_Id = Supplier_Quotation_Master.Sup_Quo_Id INNER JOIN Employee_Master ON Supplier_Po_Master.PreparedBy = Employee_Master.EMP_ID order by Supplier_Po_Master.Sup_PO_Id desc"></asp:SqlDataSource>
        <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        <%-- </div>--%>
    </div>
</asp:Content>
