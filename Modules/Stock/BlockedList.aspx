<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="BlockedList.aspx.cs" Inherits="Modules_Stock_BlockedList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.6/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
   <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.6/js/buttons.html5.min.js"></script>

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

   <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Item Blocked Details</h3>
        </div>
    </div>
    <!-- /page header -->
     <div class="form-horizontal">
  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Item Blocked Details</h6>
            <span class="pull-right">
        </div>
      <div class="panel-body">
          <div class="form-group">
                       <label class="col-sm-2 control-label text-right">Customer Name :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID ="txtCust" CssClass ="form-control" runat ="server" ></asp:TextBox>
                                        <asp:Label ID="lblEmpId" runat ="server" Visible ="false" ></asp:Label>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Material Code :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtMaterialCode" runat="server" CssClass ="form-control"></asp:TextBox>
                                    </div>
                   </div>
          <div class="form-group">
                       <label class="col-sm-2 control-label text-right">Project Code :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID ="txtPrjtcode" CssClass ="form-control" runat ="server" ></asp:TextBox>
                                        <asp:Label ID="Label1" runat ="server" Visible ="false" ></asp:Label>
                                    </div>
                                   
                   </div>
          <div class="form-actions col-sm-offset-2">
             <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick ="btnSearch_Click" Text="Search" />
         </div>
     
        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField="BlockStock_Id" HeaderText="Sl.No" SortExpression="BlockStock_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SalesOrder_No" HeaderText="SO No" SortExpression="SalesOrder_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                        <asp:BoundField DataField="ProjectCode" HeaderText="Project Code" SortExpression="ProjectCode">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                      <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" SortExpression="CUST_UNIT_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    


                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" SortExpression="Material_Code" >
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     <asp:BoundField DataField="Color_Name" HeaderText="Color" SortExpression="Color_Name">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    
                     <asp:BoundField DataField="UOM_SHORT_DESC" HeaderText="UOM" SortExpression="UOM_SHORT_DESC">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    <asp:BoundField DataField="blocklength" HeaderText="Length" SortExpression="blocklength">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                      <%-- <asp:BoundField DataField="blockedqty" HeaderText="blockedqty" SortExpression="blockedqty">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>--%>

                       <asp:BoundField DataField="remainqty" HeaderText="Qty" SortExpression="remainqty">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    
                   

                     
                
                    





                </Columns>
            </asp:GridView>

          


             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT Stock_Block.BlockStock_Id, Sales_Order.SalesOrder_No, Color_Master.Color_Name, Material_Master.Material_Code, Material_Master.Description, Uom_Master.UOM_SHORT_DESC, 
                         Stock_Block.Length AS blocklength, Stock_Block.TotalQty AS blockedqty, Stock_Block.Qty AS remainqty, Stock_Block.Remarks, Sales_Order.ProjectCode, Customer_Units.CUST_UNIT_NAME
FROM                     Customer_Units INNER JOIN
                         Sales_Order ON Customer_Units.CUST_UNIT_ID = Sales_Order.CustSiteId RIGHT OUTER JOIN
                         Stock_Block ON Sales_Order.SalesOrder_Id = Stock_Block.So_Id LEFT OUTER JOIN
                         Color_Master ON Stock_Block.Color_Id = Color_Master.Color_Id LEFT OUTER JOIN
                         Material_Master ON Stock_Block.Item_Code = Material_Master.Material_Id LEFT OUTER JOIN
                         Uom_Master ON Material_Master.UOM_Id = Uom_Master.UOM_ID"></asp:SqlDataSource>



            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
           </div>
    </div>
         </div> 
</asp:Content>