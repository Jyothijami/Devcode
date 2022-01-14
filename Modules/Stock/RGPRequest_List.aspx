<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="RGPRequest_List.aspx.cs" Inherits="Modules_Stock_RGPRequest_List" %>

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
            <h3>RGP Request Details</h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>RGP Request List</h6>
            <span class="pull-right">
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Rgp_Request_No" HeaderText="RGP Request No" ItemStyle-Width="80px" SortExpression="Rgp_Request_No">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>

                       <asp:BoundField DataField="Rgp_Request_Date" HeaderText="Request Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Rgp_Request_Date">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>
                    
                      <asp:BoundField DataField="ProjectCode" HeaderText="Code"  ItemStyle-Width="120px" SortExpression="ProjectCode">
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


                    
                    <asp:BoundField DataField="Uom" HeaderText="Uom" SortExpression="Uom" >
                        <HeaderStyle Font-Size="Smaller" />
                          
                    </asp:BoundField>

                      
                     <asp:BoundField DataField="Qty" HeaderText="Req Qty" SortExpression="Qty">
                        <HeaderStyle Font-Size="Smaller" />
                           
                    </asp:BoundField>

                      <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks">
                        <HeaderStyle Font-Size="Smaller" />
                           
                    </asp:BoundField>


                       <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Prepared By" SortExpression="EMP_FIRST_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                           
                    </asp:BoundField>


                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        RGP_Request.Rgp_Request_No, RGP_Request.Rgp_Request_Date, Sales_Order.ProjectCode, Material_Master.Material_Code, Color_Master.Color_Name, RGP_Request_Details.Length, 
                         RGP_Request_Details.Uom, RGP_Request_Details.Qty, RGP_Request_Details.Remarks, Employee_Master.EMP_FIRST_NAME
FROM            RGP_Request_Details INNER JOIN
                         Color_Master ON RGP_Request_Details.Color_Id = Color_Master.Color_Id INNER JOIN
                         Material_Master ON RGP_Request_Details.Item_Id = Material_Master.Material_Id INNER JOIN
                         RGP_Request ON RGP_Request_Details.Rgp_Request_Id = RGP_Request.RGP_Request_Id INNER JOIN
                         Sales_Order ON RGP_Request.Project = Sales_Order.SalesOrder_Id INNER JOIN
                         Employee_Master ON RGP_Request.PreparedBy = Employee_Master.EMP_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>









</asp:Content>

