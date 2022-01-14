<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="IndentRemainder.aspx.cs" Inherits="Modules_Stock_IndentRemainder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    
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


    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Indent Remiander</h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Indent Remainder</h6>
            
        </div>

    <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Reminder_ID" HeaderText="Reminder_ID" SortExpression="Reminder_ID" />
            <asp:BoundField DataField="Cust_Name" HeaderText="Cust Name" SortExpression="Cust_Name" />
            <asp:BoundField DataField="Project_Id" HeaderText="Project_Id" SortExpression="Project_Id" />
            <asp:BoundField DataField="Material_Code" HeaderText="Material_Code" SortExpression="Material_Code" />
            <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color" />
            <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
            <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Free_Qty" />
            <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
            <asp:BoundField DataField="CreatedOn" HeaderText="CreatedOn" SortExpression="CreatedOn"  DataFormatString="{0:dd/MM/yyyy}"/>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT [Reminder_ID], [Cust_Name], [Project_Id], [Material_Code], [Color], [Length], [Qty], [Remarks], [CreatedOn] FROM [Indent_Reminder]"></asp:SqlDataSource>







</asp:Content>

