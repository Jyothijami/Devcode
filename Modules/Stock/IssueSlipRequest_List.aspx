<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="IssueSlipRequest_List.aspx.cs" Inherits="Modules_Stock_IssueSlipRequest_List" %>

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
            <h3>Issue Slip Request Details</h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Issue Slip Request List</h6>
            <span class="pull-right">
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Req_Issue_No" HeaderText="Issue Request No" ItemStyle-Width="80px" SortExpression="Req_Issue_No">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>

                       <asp:BoundField DataField="Req_Issue_Date" HeaderText="Request Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Req_Issue_Date">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>
                    
                      <asp:BoundField DataField="ProjectCode" HeaderText="Code"  ItemStyle-Width="120px" SortExpression="ProjectCode">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>
                      <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" ItemStyle-Width="90px"  SortExpression="CUST_UNIT_NAME">
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

                      
                     <asp:BoundField DataField="Issue_Qty" HeaderText="Req Qty" SortExpression="Issue_Qty">
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        Request_Material_Issue.Req_Issue_No, Request_Material_Issue.Req_Issue_Date, Sales_Order.ProjectCode, Customer_Units.CUST_UNIT_NAME, Material_Master.Material_Code, Color_Master.Color_Name, Material_Master.Description,
                         Request_Material_Issue_Details.Length, Request_Material_Issue_Details.Issue_Qty, Request_Material_Issue_Details.Remarks, Employee_Master.EMP_FIRST_NAME, 
                         Employee_Master_1.EMP_FIRST_NAME AS approved
FROM            Request_Material_Issue_Details INNER JOIN
                         Color_Master ON Request_Material_Issue_Details.Color_Id = Color_Master.Color_Id INNER JOIN
                         Material_Master ON Request_Material_Issue_Details.Item_Code = Material_Master.Material_Id INNER JOIN
                         Request_Material_Issue ON Request_Material_Issue_Details.ReqIssue_Id = Request_Material_Issue.Req_Issue_Id LEFT OUTER JOIN
                         Sales_Order ON Request_Material_Issue.So_Id = Sales_Order.SalesOrder_Id INNER JOIN
                         Customer_Units ON Sales_Order.CustSiteId = Customer_Units.CUST_UNIT_ID INNER JOIN
                         Employee_Master ON Request_Material_Issue.Reqested_By = Employee_Master.EMP_ID INNER JOIN
                         Employee_Master AS Employee_Master_1 ON Request_Material_Issue.Approved_By = Employee_Master_1.EMP_ID"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>








</asp:Content>

