<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="VendorMaster.aspx.cs" Inherits="Modules_Purchases_VendorMaster" %>

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

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Supplier Master</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="panel-body">

            <div class="datatable-tasks">

                <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="SUP_ID" HeaderText="Sl.No" SortExpression="SUP_ID">
                            <HeaderStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUP_NAME" HeaderText="Supplier Name" SortExpression="SUP_NAME">
                            <HeaderStyle Font-Size="Smaller" />
                            <ItemStyle Font-Size="Smaller" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Address" SortExpression="SUP_ADDRESS">
                            <ItemTemplate>
                                <asp:Label ID="lblQuestion" runat="server" Text='<%# Server.HtmlDecode(Eval("SUP_ADDRESS").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                        </asp:TemplateField>
                        <%-- <asp:BoundField DataField="SUP_ADDRESS" HeaderText="Address" SortExpression="SUP_ADDRESS">
                            <HeaderStyle Font-Size="Smaller" />
                        </asp:BoundField>--%>
                        <asp:BoundField DataField="SUP_PHONE" HeaderText="Phone" SortExpression="SUP_PHONE">
                            <HeaderStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SUP_MOBILE" HeaderText="Mobile" SortExpression="SUP_MOBILE">

                            <HeaderStyle Font-Size="Smaller" />
                        </asp:BoundField>

                        <asp:BoundField DataField="COUNTRY_NAME" HeaderText="Country" SortExpression="COUNTRY_NAME">

                            <HeaderStyle Font-Size="Smaller" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Purchases/VendorMaster_Details.aspx?Cid=" + Eval("SUP_ID") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT  Supplier_Master.SUP_ID, Supplier_Master.SUP_NAME, Supplier_Master.SUP_CONTACT_PERSON, Supplier_Master.SUP_ADDRESS, Supplier_Master.SUP_CONTACT_PER_DET, Supplier_Master.SUP_PHONE, Supplier_Master.SUP_MOBILE, Supplier_Master.SUP_EMAIL, Supplier_Master.SUP_FAXNO, Supplier_Master.SUP_PANNO, Supplier_Master.SUP_CSTNO, Supplier_Master.SUP_VATNO, Supplier_Master.SUP_GSTNO, Supplier_Master.COUNTRY_ID, Supplier_Master.TITLE, Country_Master.COUNTRY_NAME FROM Supplier_Master INNER JOIN Country_Master ON Supplier_Master.COUNTRY_ID = Country_Master.COUNTRY_ID"></asp:SqlDataSource>
                <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>