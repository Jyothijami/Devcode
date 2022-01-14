<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="GlassRequestMast.aspx.cs" Inherits="Modules_Stock_GlassRequestMast" %>

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
            <h3>Glass Request Slip </h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Glass Request Slip </h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="GlasslRequest_Id" HeaderText="Sl.No" SortExpression="GlasslRequest_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GlasslRequest_No" HeaderText="Glass Request No" SortExpression="GlasslRequest_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Required_Date" HeaderText="Date" SortExpression="Required_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                     <asp:BoundField DataField="Requested_For" HeaderText="Requested For" SortExpression="Requested_For" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                      <%--<asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" SortExpression="CUST_UNIT_NAME" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>--%>

                    


                      <asp:BoundField DataField="Prepared_By" HeaderText="Prepared By" SortExpression="Prepared_By">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                      <asp:BoundField DataField="Approved_by" HeaderText="Approved By" SortExpression="Approved_by">
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
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Stock/GlassRequest.aspx?Cid=" + Eval("GlasslRequest_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand=" SELECT Glass_Request.GlasslRequest_Id , Glass_Request.GlasslRequest_No , Glass_Request.Required_Date ,Glass_Request.Requested_For, 
                         Glass_Request .Request_Type, Employee_Master_1.EMP_FIRST_NAME as Prepared_By, Employee_Master.EMP_FIRST_NAME AS Approved_By
                         FROM  Glass_Request INNER JOIN
                         Employee_Master AS Employee_Master_1 ON Glass_Request.Prepared_By  = Employee_Master_1.EMP_ID INNER JOIN
                         Employee_Master ON Glass_Request.Approved_By = Employee_Master.EMP_ID "></asp:SqlDataSource>
          
        </div>
    </div>
</asp:Content>

