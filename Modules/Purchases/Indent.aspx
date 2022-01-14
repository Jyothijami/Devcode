<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="Indent.aspx.cs" Inherits="Modules_Purchases_Indent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Indent</h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Indent</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Indent_Id" HeaderText="Sl.No" SortExpression="Indent_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Indent_No" HeaderText="Indent No" SortExpression="Indent_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Indent_Date" HeaderText="Date" SortExpression="Indent_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     <asp:BoundField DataField="DEPT_NAME" HeaderText="Department" SortExpression="DEPT_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Follow Up" SortExpression="EMP_FIRST_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Expr1" HeaderText="Prepared By" SortExpression="Expr1">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Purchases/IndentDetails.aspx?Cid=" + Eval("Indent_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT Indent_Master.Indent_Id, Indent_Master.Indent_No, Indent_Master.Indent_Date, Indent_Master.Dept_Id, Indent_Master.FollowUp_Id, Indent_Master.PreparedBy, Indent_Master.ApprovedBy, Department_Master.DEPT_NAME, Employee_Master.EMP_FIRST_NAME, Employee_Master_1.EMP_FIRST_NAME AS Expr1 FROM Department_Master INNER JOIN Indent_Master ON Department_Master.DEPT_ID = Indent_Master.Dept_Id INNER JOIN Employee_Master ON Indent_Master.FollowUp_Id = Employee_Master.EMP_ID INNER JOIN Employee_Master AS Employee_Master_1 ON Indent_Master.PreparedBy = Employee_Master_1.EMP_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>