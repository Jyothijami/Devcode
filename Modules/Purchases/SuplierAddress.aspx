<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SuplierAddress.aspx.cs" Inherits="Modules_Purchases_SuplierAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.6/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.6/js/buttons.html5.min.js"></script>

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
                  buttons: ['copyHtml5',
     'excelHtml5',
     'csvHtml5',
     'pdfHtml5'],
                  bStateSave: true,
                  order: [[0, 'desc']],
              });
          }
    </script>

    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Supplier Address & Contact Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Supplier Address & Contact</h6>
            <span class="pull-right">
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                      
                        <asp:BoundField DataField="SUP_NAME" HeaderText="Supplier Name" SortExpression="SUP_NAME" ItemStyle-Width="30%">
                            <HeaderStyle   Font-Size="Smaller" />
                          
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


                          <asp:BoundField DataField="SUP_EMAIL" HeaderText="E-Mail" SortExpression="SUP_EMAIL">

                            <HeaderStyle Font-Size="Smaller" />
                        </asp:BoundField>


                          <asp:BoundField DataField="SUP_GSTNO" HeaderText="GST No" SortExpression="SUP_GSTNO">

                            <HeaderStyle Font-Size="Smaller" />
                        </asp:BoundField>

                        <asp:BoundField DataField="COUNTRY_NAME" HeaderText="Country" SortExpression="COUNTRY_NAME">

                            <HeaderStyle Font-Size="Smaller" />
                        </asp:BoundField>

                      
                    </Columns>
                </asp:GridView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT  Supplier_Master.SUP_ID, Supplier_Master.SUP_NAME, Supplier_Master.SUP_CONTACT_PERSON, Supplier_Master.SUP_ADDRESS, Supplier_Master.SUP_CONTACT_PER_DET, Supplier_Master.SUP_PHONE, Supplier_Master.SUP_MOBILE, Supplier_Master.SUP_EMAIL, Supplier_Master.SUP_FAXNO, Supplier_Master.SUP_PANNO, Supplier_Master.SUP_CSTNO, Supplier_Master.SUP_VATNO, Supplier_Master.SUP_GSTNO, Supplier_Master.COUNTRY_ID, Supplier_Master.TITLE, Country_Master.COUNTRY_NAME FROM Supplier_Master INNER JOIN Country_Master ON Supplier_Master.COUNTRY_ID = Country_Master.COUNTRY_ID"></asp:SqlDataSource>
                <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>