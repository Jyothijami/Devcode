<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="LeaveBalance.aspx.cs" Inherits="Modules_HR_LeaveBalance" %>

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
            <h3>Employee Leave Balance</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file">Employee Leave Balance</i></h6>
        </div>

        <div class="datatable">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="hai_RowDataBound"  >
                <Columns>
                    <asp:BoundField DataField="EMP_Id" HeaderText="empId" SortExpression="EMP_Id"></asp:BoundField>
                    <asp:BoundField DataField="emid" HeaderText="Empid" SortExpression="emid"></asp:BoundField>

                    <asp:BoundField DataField="EmpName" HeaderText="Emp Name" SortExpression="EmpName"></asp:BoundField>

                    <asp:BoundField DataField="EMP_NO" HeaderText="Emp Code" SortExpression="EMP_NO"></asp:BoundField>
                  
                    

                    

                    <asp:TemplateField HeaderText="Causal Leaves">
                        <ItemTemplate>
                            <asp:TextBox ID="txtcasualleaves" CssClass="form-control" runat="server" Text='<%# Bind("Casual_Leaves") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Earned Leaves">
                        <ItemTemplate>
                            <asp:TextBox ID="txtearnedleaves" CssClass="form-control" runat="server" Text='<%# Bind("Earned_Leaves") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Submit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CssClass="btn btn-icon btn-danger"><i class="icon-upload"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

               
                </Columns>
            </asp:GridView>

           
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select Leave_tbl.*,Employee_Master.EMP_ID as emid,EMP_FIRST_NAME+' '+EMP_LAST_NAME as EmpName,EMP_NO from Leave_tbl right join  Employee_Master on Leave_tbl.EMP_Id = Employee_Master.EMP_ID where Status != 'InActive' and Employee_Master.EMP_ID != 0 and EMP_CPID = 1"></asp:SqlDataSource>

            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>

    

    








</asp:Content>

