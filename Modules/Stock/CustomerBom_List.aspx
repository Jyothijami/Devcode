<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="CustomerBom_List.aspx.cs" Inherits="Modules_Stock_CustomerBom_List" %>

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
              $('#<%=gvmatana.ClientID%>').prepend($("<thead></thead>").append($('#<%=gvmatana.ClientID%>').find("tr:first"))).DataTable({

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
            <h3>Customer BOM Details</h3>
        </div>
    </div>
    <!-- /page header -->

  <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Customer BOM List</h6>
            <span class="pull-right">
        </div>

        <%--<div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="SalesOrder_No" HeaderText="SO No" SortExpression="SalesOrder_No">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>

                       <asp:BoundField DataField="SalesOrder_Date" HeaderText="SO Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="SalesOrder_Date">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>
                    
                      <asp:BoundField DataField="ProjectCode" HeaderText="Code"  ItemStyle-Width="120px" SortExpression="ProjectCode">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>
                      <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" ItemStyle-Width="120px"  SortExpression="CUST_UNIT_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                         
                    </asp:BoundField>

                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" SortExpression="Material_Code">
                        <HeaderStyle Font-Size="Smaller" />
                      
                    </asp:BoundField>


                     <asp:BoundField DataField="DESCRIPTION" HeaderText="Description" SortExpression="DESCRIPTION">
                        <HeaderStyle Font-Size="Smaller" />
                           
                    </asp:BoundField>


                        <asp:BoundField DataField="Color_Name" HeaderText="Color" SortExpression="Color_Name">
                        <HeaderStyle Font-Size="Smaller" />
                           
                           
                    </asp:BoundField>

                    


                    <asp:BoundField DataField="BARLENGTH" HeaderText="Length" SortExpression="BARLENGTH" >
                        <HeaderStyle Font-Size="Smaller" />
                          
                    </asp:BoundField>

                       <asp:BoundField DataField="UNIT" HeaderText="Unit" SortExpression="UNIT">
                        <HeaderStyle Font-Size="Smaller" />
                          
                    </asp:BoundField>
                     <asp:BoundField DataField="QUANTITY" HeaderText="Req Qty" SortExpression="QUANTITY">
                        <HeaderStyle Font-Size="Smaller" />
                           
                    </asp:BoundField>



                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        Sales_Order.SalesOrder_No,Sales_Order.SalesOrder_Date, Sales_Order.ProjectCode,Customer_Units.CUST_UNIT_NAME, Customer_Master.CUST_NAME, Material_Master.Material_Code, Color_Master.Color_Name, 
                         SalesOrder_MaterialAnalysis.QUANTITY, SalesOrder_MaterialAnalysis.BARLENGTH, SalesOrder_MaterialAnalysis.UNIT, SalesOrder_MaterialAnalysis.DESCRIPTION
FROM            Material_Master INNER JOIN
                         Color_Master INNER JOIN
                         SalesOrder_MaterialAnalysis ON Color_Master.Color_Id = SalesOrder_MaterialAnalysis.COLOR_ID INNER JOIN
                         Sales_Order ON SalesOrder_MaterialAnalysis.SO_ID = Sales_Order.SalesOrder_Id INNER JOIN
                         Customer_Master ON Sales_Order.CustId = Customer_Master.CUST_ID INNER JOIN
                         Customer_Units ON Sales_Order.CustSiteId = Customer_Units.CUST_UNIT_ID ON Material_Master.Material_Id = SalesOrder_MaterialAnalysis.ITEMCODE_ID



"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>--%>


        <div class="panel panel-danger">
                    <div class="panel-heading">
                         
                        <h5 class="panel-title">Get Items From Sales Order </h5>

                        <div class="panel-icons-group">
		                    	<a href="#" data-panel="collapse" class="btn btn-link btn-icon"><i class="icon-arrow-up9"></i></a>
	                    </div>


                    </div>
                    
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Sales Order No :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlSono" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="ddlSono_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>


                            <label class="col-sm-2 control-label text-right">Customer/Project :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlCustomer"  Width="100%"  CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>



                        </div>

                        <div class="form-group">


                        <div class="datatable-tasks">


                            <asp:GridView ID="gvmatana" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvmatana_RowDataBound">
                                <Columns>
                                  




                                    <asp:BoundField DataField="ITEM_CATEGORY_NAME" HeaderText="Material Type" />
                                    <asp:BoundField DataField="ITEMCODE" HeaderText="Item Code" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                     <asp:BoundField DataField="BARLENGTH" HeaderText="BarLength" />
                                     <asp:BoundField DataField="UNIT" HeaderText="Unit" />
                                     <asp:BoundField DataField="COLOR" HeaderText="Color" />
                                    
                                    <asp:BoundField DataField="PU" HeaderText="PU" />
                                   
                                    <asp:BoundField DataField="REQUIRED_QTY" HeaderText="Required Qty(Actual)" />
                                    <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" />
                                    <asp:BoundField  DataField="TotalStock" HeaderText ="Available Qty" />
                                   
                                    <asp:BoundField DataField="ITEMCODE_ID" HeaderText="ItemId" />
                                    <asp:BoundField DataField="COLOR_ID" HeaderText="ColorId" />
                                   
                                    <asp:BoundField DataField="SO_ID" HeaderText="SO_ID" />
                                    <asp:BoundField DataField="SO_MATANA_ID" HeaderText="SO_MATANA_ID" />

                                     <asp:BoundField DataField="PrevBlockedStock" HeaderText="Blocked Qty" />
                                     <asp:BoundField   DataField="iSSUED" HeaderText="Issued Qty" />




                                 <%--   <asp:TemplateField HeaderText="Location">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlSowaerhose" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>




                                </Columns>
                                <EmptyDataTemplate>
                                    <span style="color: #CC0000">No Data Found</span>
                                </EmptyDataTemplate>
                            </asp:GridView>

                            </div>
                        </div>
                    </div>
                    
                </div>











    </div>







</asp:Content>

