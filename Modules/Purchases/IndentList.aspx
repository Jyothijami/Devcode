<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="IndentList.aspx.cs" Inherits="Modules_Purchases_IndentList" %>

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
            <h3>Indent Order Details</h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Indent Order List</h6>
            <span class="pull-right">
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="MaterialRequest_No" HeaderText="Indent No" SortExpression="MaterialRequest_No">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>

                       <asp:BoundField DataField="Required_Date" HeaderText="Indent Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Required_Date">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>




                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" SortExpression="Material_Code">
                        <HeaderStyle Font-Size="Smaller" />
                      
                    </asp:BoundField>


                     <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                        <HeaderStyle Font-Size="Smaller" />
                           
                    </asp:BoundField>


                        <asp:BoundField DataField="Color_Name" HeaderText="Color" SortExpression="Color_Name">
                        <HeaderStyle Font-Size="Smaller" />
                           
                           
                    </asp:BoundField>

                    


                    <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" >
                        <HeaderStyle Font-Size="Smaller" />
                          
                    </asp:BoundField>


                     <asp:BoundField DataField="ReqQty" HeaderText="Qty" SortExpression="ReqQty">
                        <HeaderStyle Font-Size="Smaller" />
                           
                    </asp:BoundField>


                    <asp:BoundField DataField="ProjectCode" HeaderText="Project Code" SortExpression="ProjectCode">
                        <HeaderStyle Font-Size="Smaller" />
                          
                    </asp:BoundField>


                    
                  


                    <asp:BoundField DataField="PreparedBy" HeaderText="Prepared By" SortExpression="PreparedBy">
                        <HeaderStyle Font-Size="Smaller" />
                             <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>


                   

                    
                   

                      
                
                    





                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        MaterialRequest.MaterialRequest_No, MaterialRequest.Required_Date, Material_Master.Material_Code, Color_Master.Color_Name, MaterialRequest_Details.Length, MaterialRequest_Details.ReqQty, 
                         Sales_Order.ProjectCode, Employee_Master.EMP_FIRST_NAME + ' ' + Employee_Master.EMP_LAST_NAME AS PreparedBy, Material_Master.Description
FROM            Employee_Master INNER JOIN
                         MaterialRequest ON Employee_Master.EMP_ID = MaterialRequest.Prepared_By RIGHT OUTER JOIN
                         MaterialRequest_Details LEFT OUTER JOIN
                         Color_Master ON MaterialRequest_Details.Color_Id = Color_Master.Color_Id ON MaterialRequest.MaterialRequest_Id = MaterialRequest_Details.Mreq_Id LEFT OUTER JOIN
                         Material_Master ON MaterialRequest_Details.Item_Code = Material_Master.Material_Id LEFT OUTER JOIN
                         Sales_Order ON MaterialRequest_Details.SO_Id = Sales_Order.SalesOrder_Id"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>

</asp:Content>

