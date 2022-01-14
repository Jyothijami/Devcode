<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="StorageLocation.aspx.cs" Inherits="Modules_Masters_StorageLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


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
            <h6 class="panel-title"><i class="icon-file"></i>Stroage Locations</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>
        <div class="panel-body">
            <div class="datatable-tasks">

                <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="StorageLoacation_Id" HeaderText="Sl.No" SortExpression="StorageLoacation_Id" />
                        <asp:BoundField DataField="Plant_Name" HeaderText="Plant" SortExpression="Plant_Name" />
                        <asp:BoundField DataField="CP_FULL_NAME" HeaderText="Company" SortExpression="CP_FULL_NAME" />
                        <asp:BoundField DataField="StorageLocation_Name" HeaderText="Location" SortExpression="StorageLocation_Name" />
                        <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Masters/StorageLocation_Details.aspx?Cid=" + Eval("StorageLoacation_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select * from Plant_Master,Company_Profile,StorageLocation_Master WHERE StorageLocation_Master.Plant_Id = Plant_Master.Plant_Id and StorageLocation_Master.CP_Id = Company_Profile.CP_ID" SelectCommandType="Text">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblSearchItemHidden" DefaultValue="0" Name="SearchItemName" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="lblSearchValueHidden" DefaultValue="0" Name="SearchValue" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>