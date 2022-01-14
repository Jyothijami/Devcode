<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="GlassPo.aspx.cs" Inherits="Modules_Purchases_GlassPo" %>

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
            <h3>Glass Purchase Order</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Glass Purchase Order</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Sup_GPO_Id" HeaderText="Sl.No" SortExpression="Sup_GPO_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Sup_GPO_No" HeaderText="Glass PO No" SortExpression="Sup_GPO_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Sup_GPO_Date" HeaderText="Date" SortExpression="Sup_GPO_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     




                    <asp:BoundField DataField="SUP_NAME" HeaderText="Supplier Name" SortExpression="SUP_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                        <asp:BoundField DataField="GrandTotal" HeaderText="Grand Total" SortExpression="GrandTotal">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                     <asp:BoundField DataField="CustomerNo" HeaderText="Customer No" SortExpression="CustomerNo">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                      <asp:BoundField DataField="IndentNo" HeaderText="PO Nos" SortExpression="IndentNo">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                     <asp:BoundField DataField="preparedby" HeaderText="Prepared By" SortExpression="preparedby">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Purchases/GlassPo_Details.aspx?Cid=" + Eval("Sup_GPO_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        Glass_PO_Master.Sup_GPO_Id, Glass_PO_Master.Sup_GPO_No, Glass_PO_Master.Sup_GPO_Date, Supplier_Master.SUP_NAME, Supplier_Master.SUP_MOBILE, Glass_PO_Master.GrandTotal, Glass_PO_Master.IndentNo,
                         Employee_Master.EMP_FIRST_NAME + ' ' + Employee_Master.EMP_LAST_NAME AS preparedby, Glass_PO_Master.CustomerNo
FROM            Glass_PO_Master INNER JOIN
                         Supplier_Master ON Glass_PO_Master.Sup_Id = Supplier_Master.SUP_ID INNER JOIN
                         Employee_Master ON Glass_PO_Master.PreparedBy = Employee_Master.EMP_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>






</asp:Content>

