<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="PurchaseOrderList.aspx.cs" Inherits="Modules_Purchases_PurchaseOrderList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    



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


      <asp:UpdatePanel ID="UpdatePanel134" runat="server">
        <ContentTemplate>

   <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Purchase Order List</h3>
        </div>
    </div>
    <!-- /page header -->


    <div class="form-horizontal">

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Purchase Order List</h6>
        </div>

         <div class="panel-body">

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Supllier Name :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtPrjtcode" CssClass="form-control" runat="server"></asp:TextBox>
                      <%--  <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>--%>
                    </div>
                    <label class="col-sm-2 control-label text-right">Material Code :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtMaterialCode" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">From Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtrqstfrom" CssClass="form-control" placeholder="yyyy-mm-dd" runat="server"></asp:TextBox>

                       

                      
                    </div>
                    <label class="col-sm-2 control-label text-right">To Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtrqstto" CssClass="form-control" placeholder="yyyy-mm-dd" runat="server"></asp:TextBox>

                        

                    
                    </div>
                </div>

             

                


          </div>


        <div class="form-actions col-sm-offset-2">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick="btnSearch_Click" Text="Search" />
                </div>


                




    </div>



    <div class="panel panel-default">
        <div class="panel-body">
            <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField="ItemCode" HeaderText="Item Code" SortExpression="ItemCode">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>
                    <asp:BoundField DataField="ColorName" HeaderText="Color Name" SortExpression="ColorName">
                        <HeaderStyle Font-Size="Smaller" />
                      
                    </asp:BoundField>

                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                        <HeaderStyle Font-Size="Smaller" />
                           
                           
                    </asp:BoundField>

                     <asp:BoundField DataField="Uom" HeaderText="Uom" SortExpression="Uom">
                        <HeaderStyle Font-Size="Smaller" />
                           
                    </asp:BoundField>


                    <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" >
                        <HeaderStyle Font-Size="Smaller" />
                          
                    </asp:BoundField>


                     <asp:BoundField DataField="qty" HeaderText="Qty" SortExpression="qty">
                        <HeaderStyle Font-Size="Smaller" />
                           
                    </asp:BoundField>


                    <asp:BoundField DataField="Sup_PO_No" HeaderText="PO NO" SortExpression="Sup_PO_No">
                        <HeaderStyle Font-Size="Smaller" />
                          
                    </asp:BoundField>


                    
                     <asp:BoundField DataField="Sup_PO_Date" HeaderText="PO Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="Sup_PO_Date">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>


                    <asp:BoundField DataField="SUP_NAME" HeaderText="Suplier" SortExpression="SUP_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                             <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>


                       <asp:BoundField DataField="SUP_MOBILE" HeaderText="Mobile" SortExpression="SUP_MOBILE">
                        <HeaderStyle Font-Size="Smaller" />
                           
                    </asp:BoundField>


                    <asp:BoundField DataField="CustomerNo" HeaderText="Customer Code" SortExpression="CustomerNo">
                        <HeaderStyle Font-Size="Smaller" />
                            
                    </asp:BoundField>

                    
                   

                      
                
                    





                </Columns>
            </asp:GridView>

          <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT Material_Master.Material_Code as ItemCode, Color_Master.Color_Name as ColorName, Supplier_Po_Details.Series as Description, Supplier_Po_Details.Uom, Supplier_Po_Details.Length, Supplier_Po_Details.ReqQty as qty, Supplier_Po_Master.Sup_PO_No, 
                         Supplier_Po_Master.Sup_PO_Date, Supplier_Master.SUP_NAME, Supplier_Master.SUP_MOBILE, Sales_Order.ProjectCode
                         FROM Supplier_Po_Master INNER JOIN
                         Supplier_Master ON Supplier_Po_Master.Sup_Id = Supplier_Master.SUP_ID INNER JOIN
                         Supplier_Po_Details ON Supplier_Po_Master.Sup_PO_Id = Supplier_Po_Details.Sup_PO_Id INNER JOIN
                         Color_Master ON Supplier_Po_Details.Color_Id = Color_Master.Color_Id left JOIN
                         Sales_Order ON Supplier_Po_Details.SO_Id = Sales_Order.SalesOrder_Id INNER JOIN
                         Material_Master ON Supplier_Po_Details.ItemCode = Material_Master.Material_Id"></asp:SqlDataSource>--%>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
        </div>
    </div>

    </div>


      <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.6/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
   <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.6/js/buttons.html5.min.js"></script>
  </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>

