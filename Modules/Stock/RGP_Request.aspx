<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="RGP_Request.aspx.cs" Inherits="Modules_Stock_RGP_Request" %>

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
            <h3>Request RGP</h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Request RGP</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="RGP_Request_Id" HeaderText="Sl.No" SortExpression="RGP_Request_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Rgp_Request_No" HeaderText="RGP Request No" SortExpression="Rgp_Request_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Rgp_Request_Date" HeaderText="Date" SortExpression="Rgp_Request_Date" DataFormatString="{0:dd/MM/yyyy}">
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
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Stock/RGP_Request_Details.aspx?Cid=" + Eval("RGP_Request_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT  RGP_Request.RGP_Request_Id, RGP_Request.Rgp_Request_No, RGP_Request.Rgp_Request_Date, RGP_Request.Receiver_Name, RGP_Request.Address, RGP_Request.PreparedBy, 
                         RGP_Request.RequestedBy, RGP_Request.Status, RGP_Request.Remarks, Employee_Master.EMP_FIRST_NAME as Preparedb, Employee_Master_1.EMP_FIRST_NAME AS Approvedby
FROM            RGP_Request INNER JOIN
                         Employee_Master ON RGP_Request.PreparedBy = Employee_Master.EMP_ID INNER JOIN
                         Employee_Master AS Employee_Master_1 ON RGP_Request.RequestedBy = Employee_Master_1.EMP_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>




</asp:Content>

