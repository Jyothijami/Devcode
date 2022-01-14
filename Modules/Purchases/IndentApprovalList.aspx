<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="IndentApprovalList.aspx.cs" Inherits="Modules_Purchases_IndentApprovalList" %>

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
            <h3>Indent Approval Details</h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Indent Approval List</h6>
            <span class="pull-right">
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="IndentApproval_No" HeaderText="Indent Approval No" SortExpression="IndentApproval_No">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>

                       <asp:BoundField DataField="IndentApproval_Date" HeaderText="Indent Approval Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="IndentApproval_Date">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>

                       <asp:BoundField DataField="MaterialRequest_No" HeaderText="Indent No" SortExpression="MaterialRequest_No">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>


                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" SortExpression="Material_Code">
                        <HeaderStyle Font-Size="Smaller" />
                      
                    </asp:BoundField>

                        <asp:BoundField DataField="Color_Name" HeaderText="Color" SortExpression="Color_Name">
                        <HeaderStyle Font-Size="Smaller" />
                           
                           
                    </asp:BoundField>

                    


                    <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" >
                        <HeaderStyle Font-Size="Smaller" />
                          
                    </asp:BoundField>
                      <asp:BoundField DataField="UOM_SHORT_DESC" HeaderText="UOM" SortExpression="UOM_SHORT_DESC" >
                        <HeaderStyle Font-Size="Smaller" />
                          
                    </asp:BoundField>


                     <asp:BoundField DataField="ReqQty" HeaderText="Requested Qty" SortExpression="ReqQty">
                        <HeaderStyle Font-Size="Smaller" />
                           
                    </asp:BoundField>

                     <asp:BoundField DataField="QtytoOrder" HeaderText="Approved Qty" SortExpression="QtytoOrder">
                        <HeaderStyle Font-Size="Smaller" />
                           
                    </asp:BoundField>


                    <asp:BoundField DataField="Remarks" HeaderText="Project Code" SortExpression="Remarks">
                        <HeaderStyle Font-Size="Smaller" />
                          
                    </asp:BoundField>




                    
                  


                    <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Prepared By" SortExpression="EMP_FIRST_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                            
                    </asp:BoundField>


                   

                    
                   

                      
                
                    





                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        IndentApproval.IndentApproval_No, IndentApproval.IndentApproval_Date, MaterialRequest.MaterialRequest_No, MaterialRequest.Required_Date, Material_Master.Material_Code, Color_Master.Color_Name, 
                         IndentApproval_Details.Length, Uom_Master.UOM_SHORT_DESC, IndentApproval_Details.ReqQty, IndentApproval_Details.QtytoOrder, IndentApproval_Details.Remarks, Employee_Master_1.EMP_FIRST_NAME, 
                         Employee_Master.EMP_FIRST_NAME AS Expr1
                         FROM Color_Master INNER JOIN
                         IndentApproval_Details ON Color_Master.Color_Id = IndentApproval_Details.Color_Id INNER JOIN
                         IndentApproval ON IndentApproval_Details.IndentApproval_Id = IndentApproval.IndentApproval_Id INNER JOIN
                         MaterialRequest ON IndentApproval.Indent_No = MaterialRequest.MaterialRequest_Id INNER JOIN
                         Material_Master ON IndentApproval_Details.Item_Code = Material_Master.Material_Id INNER JOIN
                         Employee_Master AS Employee_Master_1 ON IndentApproval.Prepared_By = Employee_Master_1.EMP_ID INNER JOIN
                         Uom_Master ON Material_Master.UOM_Id = Uom_Master.UOM_ID INNER JOIN
                         Employee_Master ON IndentApproval.ApprovedBy = Employee_Master.EMP_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>




</asp:Content>

