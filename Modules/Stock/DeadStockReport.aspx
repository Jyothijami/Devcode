<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="DeadStockReport.aspx.cs" Inherits="Modules_Stock_DeadStockReport" %>

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

     <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Dead Stock(Not Used by till date)</h6>
        </div>

        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="MatId" HeaderText="Id" SortExpression="MatId" />
                    <asp:BoundField DataField="ITEM_CATEGORY_NAME" HeaderText="Category Name" SortExpression="ITEM_CATEGORY_NAME" />
                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code"  SortExpression="Material_Code" />
                     
                    
                      <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                     <asp:BoundField DataField="Color_Name" HeaderText="Color Name" SortExpression="Color_Name" />
                     <asp:BoundField DataField="stocklength" HeaderText="Length" SortExpression="stocklength" />
                     <asp:BoundField DataField="TotalStock" HeaderText="Total Stock" SortExpression="TotalStock" />
                    <%-- <asp:BoundField DataField="Blockedstock" HeaderText="Blocked stock" SortExpression="Blockedstock" />--%>
                    
                    <asp:TemplateField HeaderText="Blocked stock" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <span class="text-center">



                                                              <a runat="server"  href='<%# "~/Modules/Stock/BLockedItemDetails.aspx?Cid="+ Eval("MatId")+"&ColorId="+Eval("ColorId")+"&Length="+Eval("stocklength") %>'  onclick="window.open(this.href, 'newwindow', 'width=500, height=500'); return false;"> <asp:Label ID="lblAmount" Text='<%# Bind("Blockedstock") %>' runat="server"></asp:Label></a>

                                                          
                                                        <%--    <asp:LinkButton  ID="lnkb"    runat="server" Text='<%# Bind("Blockedstock") %>' href='<%# "~/Modules/Reports/Details/QuatationDetails.aspx?Cid=" + Eval("MatId") %>'  OnClick="OpenPopupCenter(this.href, 'newwindow', 1000, 800);return false; ">View</asp:LinkButton>--%>


                                                        </span>
                                                    </ItemTemplate>
                                                 
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                    
                     <asp:BoundField DataField="FreeStock" HeaderText="Free Stock" SortExpression="FreeStock" />
                    
                 <%--   <asp:BoundField DataField="ColorId" HeaderText="ColorId" SortExpression="ColorId" />--%>
                  
                  

                  
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT MatId,ITEM_CATEGORY_NAME,Material_Code,Description,Color_Name,stocklength,[TotalStock],ColorId
      ,[Blockedstock]
      ,[FreeStock]
FROM StockView3 
EXCEPT
SELECT MatId,ITEM_CATEGORY_NAME,Material_Code,a.Description,Color_Name,stocklength,[TotalStock],ColorId
      ,[Blockedstock]
      ,[FreeStock]
FROM StockView3  a
JOIN Material_Issue_Details b ON a.MatId = b.Item_Code 
EXCEPT
SELECT MatId,ITEM_CATEGORY_NAME,Material_Code,a.Description,Color_Name,stocklength,[TotalStock],ColorId
      ,[Blockedstock]
      ,[FreeStock]
FROM StockView3  a
JOIN PackingList_Details b ON a.MatId = b.Item_Id 
EXCEPT
SELECT MatId,ITEM_CATEGORY_NAME,Material_Code,a.Description,Color_Name,stocklength,[TotalStock],ColorId
      ,[Blockedstock]
      ,[FreeStock]
FROM StockView3  a
JOIN NRGP_Details b ON a.MatId = b.Item_Id 
EXCEPT
SELECT MatId,ITEM_CATEGORY_NAME,Material_Code,a.Description,Color_Name,stocklength,[TotalStock],ColorId
      ,[Blockedstock]
      ,[FreeStock]
FROM StockView3  a
JOIN RGP_Details b ON a.MatId = b.Item_Id 
EXCEPT
SELECT MatId,ITEM_CATEGORY_NAME,Material_Code,a.Description,Color_Name,stocklength,[TotalStock],ColorId
      ,[Blockedstock]
      ,[FreeStock]
FROM StockView3  a
JOIN Request_Tools_Details b ON a.MatId = b.Item_Code "></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>


</asp:Content>

