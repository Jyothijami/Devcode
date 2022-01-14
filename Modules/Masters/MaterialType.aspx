<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="MaterialType.aspx.cs" Inherits="Modules_Masters_MaterialType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    
       <script type="text/javascript">
           $(document).ready(function () {
               //fnPageLoad();
           });
           function fnPageLoad() {
               $('#<%=GridView1.ClientID%>').prepend($("<thead></thead>").append($('#<%=GridView1.ClientID%>').find("tr:first"))).DataTable({

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
            <h6 class="panel-title"><i class="icon-file"></i>Item Group</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>
        <div class="panel-body">

            <div class="datatable-tasks">

                <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="MaterialType_Id" HeaderText="Sl.No" SortExpression="MaterialType_Id" />
                        <asp:BoundField DataField="Material_Type" HeaderText="Item Group" SortExpression="Material_Type" />
                        <asp:BoundField DataField="Material_Description" HeaderText="Description" SortExpression="Material_Description" />
                        <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Masters/MaterialType_Details.aspx?Cid=" + Eval("MaterialType_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="Select * from Material_Type"></asp:SqlDataSource>
                <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>