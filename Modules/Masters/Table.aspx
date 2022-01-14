﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Table.aspx.cs" Inherits="Modules_Masters_Table" %>

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






    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Color Master</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Table_Id" HeaderText="Sl.No" SortExpression="Table_Id" />
                    <asp:BoundField DataField="Table_Name" HeaderText="Table Name" SortExpression="Table_Name" />
                    <asp:BoundField DataField="Table_Location" HeaderText="Location" SortExpression="Table_Location" />
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Masters/Table_Details.aspx?Cid=" + Eval("Table_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT * FROM [Table_Master]"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>
