<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Opearations.aspx.cs" Inherits="Modules_Purchases_Opearations" %>

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
                  buttons: ['copyHtml5',
     'excelHtml5',
     'csvHtml5',
     'pdfHtml5'],
                  bStateSave: true,
                  order: [[0, 'desc']],
              });
          }
</script>









     <div class="page-header">
        <div class="page-title">
            <h3>Operations to windows</h3>
        </div>
    </div>
    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Give Operations to Windows</h6>
            <span class="pull-right"/>
        </div>
            <div class="panel-body">
                <div class="form-group">
                       <label class="col-sm-2 control-label text-right">Sales Order No :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList CssClass ="select-full" ID="ddlSoNo" runat ="server" Width="100%" ></asp:DropDownList>
                                        <asp:Label ID="Label1" runat ="server" Visible ="false" ></asp:Label>
                                    </div>
                                   
                   </div>
                 <div class="form-actions col-sm-offset-2">
             <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick ="btnSearch_Click" Text="Search" />
         </div>
                 <div class="datatable-tasks">
                     <asp:GridView ID="hai" runat ="server" CssClass="table table-bordered" OnRowDataBound="hai_RowDataBound" AutoGenerateColumns="false" >
                         <EmptyDataTemplate>
                             NO Data found
                         </EmptyDataTemplate>

                         <Columns >
                             <asp:BoundField HeaderText ="SO Id" DataField ="SalesOrder_Id" />
                             <asp:BoundField HeaderText ="So Det Id" DataField ="SalesOrderDet_Id" />
                           <asp:BoundField HeaderText="Item Code" DataField="Code" />
                              <asp:BoundField HeaderText="Series" DataField="Series" />
                                 <asp:BoundField HeaderText="ProfileColor" DataField="ProfileColor" />
                              <asp:BoundField HeaderText="Width" DataField="Width" />
                             <asp:BoundField HeaderText="Height" DataField="Height" />
                              <asp:BoundField HeaderText="Qty" DataField="Quantity" />
                                <asp:TemplateField HeaderText="Operations Master">
                                    <ItemTemplate >
                                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Operation_Name" DataValueField="Operation_Id"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT [Operation_Id], [Operation_Name] FROM [Operation_Master]"></asp:SqlDataSource>
           
                                    </ItemTemplate>
                                </asp:TemplateField>

                         </Columns>
                     </asp:GridView>
                 </div>
            </div>
        </div>
    </div>
</asp:Content>

