﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="IndentApproval.aspx.cs" Inherits="Modules_Stock_IndentApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


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
            <h3>Indent Approval Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Indent Approval</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="hai_RowDataBound" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="IndentApproval_Id" HeaderText="Sl.No" SortExpression="IndentApproval_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IndentApproval_No" HeaderText="Ind Approval No" SortExpression="IndentApproval_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="IndentApproval_Date" HeaderText="Date" SortExpression="IndentApproval_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="MaterialRequest_No" HeaderText="Ind No" SortExpression="MaterialRequest_No">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Requested_For" HeaderText="Requested For" SortExpression="Requested_For">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="empname" HeaderText="Prepared By" SortExpression="empname">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Status">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="ApprovedBy" HeaderText="Status" SortExpression="ApprovedBy">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                        <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Stock/IndentApprovalDocs.aspx?Cid=" + Eval("IndentApproval_Id") %>'><i class="icon-attachment"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

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
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Stock/IndentApproval_Details.aspx?Cid=" + Eval("IndentApproval_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT *,EMP_FIRST_NAME+' '+EMP_LAST_NAME as empname from IndentApproval,MaterialRequest,Employee_Master where IndentApproval.Indent_No =MaterialRequest.MaterialRequest_Id and IndentApproval.Prepared_By =Employee_Master.EMP_ID   order by IndentApproval_Id desc"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>