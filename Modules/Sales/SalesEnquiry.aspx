<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SalesEnquiry.aspx.cs" Inherits="Modules_Sales_SalesEnquiry" %>

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
            <h3>Sales Enquiry</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Sales Enquiry</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="ENQ_ID" HeaderText="Sl.No" SortExpression="ENQ_ID"></asp:BoundField>
                    <asp:BoundField DataField="enno" HeaderText="Enquiry No" SortExpression="enno"></asp:BoundField>

                    <asp:BoundField DataField="ENQ_DATE" HeaderText="Date" SortExpression="ENQ_DATE" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>

                    <asp:BoundField DataField="CUST_NAME" HeaderText="Customer" SortExpression="CUST_NAME"></asp:BoundField>
                    <asp:BoundField DataField="CUST_ADDRESS" HeaderText="Address" SortExpression="CUST_ADDRESS"></asp:BoundField>

                    <asp:BoundField DataField="STATUS" HeaderText="Status" SortExpression="STATUS"></asp:BoundField>




                       <asp:BoundField DataField="emp" HeaderText="Prepared By" SortExpression="emp"></asp:BoundField>




                 <%--   <asp:TemplateField HeaderText="BOQ Info" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Sales/BOQInfo.aspx?Cid=" + Eval("ENQ_ID") %>'><i class="icon-attachment"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Attachments" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                             
                                	
                                <asp:LinkButton ID="lbtnfloorplans" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Sales/BoQFloorPlans.aspx?Cid=" + Eval("ENQ_ID") %>'><i class="icon-attachment"></i><strong class="label label-danger">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Cou") %>'></asp:Label></strong></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                   <%-- <asp:TemplateField HeaderText="Elevations" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnelvation" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Sales/BoQElevationDrawings.aspx?Cid=" + Eval("ENQ_ID") %>'><i class="icon-attachment"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>--%>

                   <%-- <asp:TemplateField HeaderText="Specifications" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnspeci" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Sales/BoQSpecifications.aspx?Cid=" + Eval("ENQ_ID") %>'><i class="icon-attachment"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Sales/Enquiry_Details.aspx?Cid=" + Eval("ENQ_ID") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

<%--            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT SalesEnquiry_Master.ENQ_ID, SalesEnquiry_Master.ENQ_NO, SalesEnquiry_Master.ENQ_DATE, SalesEnquiry_Master.CUST_ID, SalesEnquiry_Master.UNIT_ID, SalesEnquiry_Master.SLAESINCHARGE_ID, SalesEnquiry_Master.DESIGNINCHARGE_ID, SalesEnquiry_Master.PREPAREDBY, SalesEnquiry_Master.APPROVEDBY, SalesEnquiry_Master.REVISEDKEY, SalesEnquiry_Master.STATUS, Customer_Master.CUST_NAME, Customer_Units.CUST_UNIT_NAME FROM Customer_Master INNER JOIN SalesEnquiry_Master ON Customer_Master.CUST_ID = SalesEnquiry_Master.CUST_ID INNER JOIN Customer_Units ON SalesEnquiry_Master.UNIT_ID = Customer_Units.CUST_UNIT_ID"></asp:SqlDataSource>--%>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select      Employee_Master.EMP_FIRST_NAME+' ' +Employee_Master.EMP_LAST_NAME as emp,    *,Cou = (select count(*) from Enquiry_FloorPlanDetails where Enquiry_FloorPlanDetails.ENQ_ID = SalesEnquiry_Master.ENQ_ID ),ENQ_NO+' '+REVISEDKEY as enno from SalesEnquiry_Master,Customer_Master,Employee_Master where SalesEnquiry_Master.CUST_ID = Customer_Master.CUST_ID  and SalesEnquiry_Master.PREPAREDBY = Employee_Master.EMP_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>