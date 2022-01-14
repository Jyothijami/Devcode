﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="BulkProductionReturn.aspx.cs" Inherits="Modules_Stock_BulkProductionReturn" %>

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
            <h3>Bulk Production Return </h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Bulk Production Return </h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="BulkReturnIssue_Id" HeaderText="Sl.No" SortExpression="BulkReturnIssue_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BulkReturnIssue_No" HeaderText="Return No" SortExpression="BulkReturnIssue_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="BulkReturn_Date" HeaderText="Date" SortExpression="BulkReturn_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     <asp:BoundField DataField="ProjectCode" HeaderText="Project" SortExpression="ProjectCode">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                     

                      <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Prepared By" SortExpression="EMP_FIRST_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                   
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Stock/BulkProductionReturn_Details.aspx?Cid=" + Eval("BulkReturnIssue_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select BulkReturnMaterial.*,Sales_Order.ProjectCode,Employee_Master.EMP_FIRST_NAME from BulkReturnMaterial,Sales_Order,Employee_Master where BulkReturnMaterial.So_Id = Sales_Order.SalesOrder_Id and BulkReturnMaterial.BulkPreparedBy = Employee_Master.EMP_ID order by BulkReturnIssue_Id desc"></asp:SqlDataSource>
          
        </div>
    </div>












</asp:Content>



