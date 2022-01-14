<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Company.aspx.cs" Inherits="Modules_Masters_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Company Master</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>
        <div class="panel-body">
            <div class="datatable-tasks">

                <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="CP_ID" HeaderText="Sl.No" SortExpression="CP_ID" />
                        <asp:BoundField DataField="CP_FULL_NAME" HeaderText="Company Name" SortExpression="CP_FULL_NAME" />
                        <asp:BoundField DataField="CP_PHONE_OFFICE" HeaderText="Office No" SortExpression="CP_PHONE_OFFICE" />
                        <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Masters/CompanySetup.aspx?Cid=" + Eval("CP_ID") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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
                    <EmptyDataTemplate>
                        <div style="text-align: center">
                            <span style="color: #CC0000">No Data Found</span>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select * from Company_Profile"></asp:SqlDataSource>
                <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>