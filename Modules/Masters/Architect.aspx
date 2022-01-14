<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Architect.aspx.cs" Inherits="Modules_Masters_Architect" %>

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

    <asp:UpdatePanel ID="RegUpdatePanel" runat="server">
        <ContentTemplate>

            <script type="text/javascript">
                function CallButtonEvent() {
                    alert('Button clicked.');
                }
            </script>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title"><i class="icon-file"></i>Architect Master</h6>
                    <span class="pull-right">
                        <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>

                    <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="CallButtonEvent()" OnClick="submit" />
                </div>

                <%--  <div class="datatable-tasks">--%>
                <div class="">

                    <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" >
                        <Columns>
                            <asp:BoundField DataField="Architect_Id" HeaderText="Sl.No" SortExpression="Architect_Id" />
                            <asp:BoundField DataField="Architect_Name" HeaderText="Architect Name" SortExpression="Architect_Name" />
                            <asp:BoundField DataField="Architect_Mobile" HeaderText="Mobile" SortExpression="Architect_Mobile" />
                            <asp:BoundField DataField="Architect_Email" HeaderText="Email" SortExpression="Architect_Email" />
                            <asp:BoundField DataField="Architect_Address" HeaderText="Address" SortExpression="Architect_Address" />

                            <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <span class="text-center">
                                        <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Masters/Architect_Details.aspx?Cid=" + Eval("Architect_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT * FROM [Architect_Master]"></asp:SqlDataSource>
                    <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
                </div>
            </div>
        </ContentTemplate>
        <%--     <Triggers>
            <asp:PostBackTrigger ControlID="btnUploadExcel" />
            <%--   <asp:AsyncPostBackTrigger ControlID="btSubmit" />
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>