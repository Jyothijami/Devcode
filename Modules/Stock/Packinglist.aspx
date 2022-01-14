<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Packinglist.aspx.cs" Inherits="Modules_Stock_Packinglist" %>

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
            <h3>Packing List</h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>PackingList</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="PackingList_Id" HeaderText="Sl.No" SortExpression="PackingList_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PackingList_No" HeaderText="Packing list No" SortExpression="PackingList_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="PackingList_Date" HeaderText="Date" SortExpression="PackingList_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                  

                    <asp:BoundField DataField="Cust_Address" HeaderText="Cust Address" SortExpression="Cust_Address">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    
                    <asp:BoundField DataField="Delivery_Address" HeaderText="Delivery Address" SortExpression="Delivery_Address">
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
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Stock/PackingList_Details.aspx?Cid=" + Eval("PackingList_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT * from Packing_List"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>
