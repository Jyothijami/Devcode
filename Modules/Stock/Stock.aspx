<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Stock.aspx.cs" Inherits="Modules_Stock_Stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <h6 class="panel-title"><i class="icon-file"></i>Stock Details</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Manual Stock Update" Visible="false" OnClick="btnAddnew_Click" /></span>
        </div>
        <div class="panel-body">



            <div class="row">

            </div>


            <div class="form-group">
                <label class="col-sm-2 control-label text-right">Search By Item Code :</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtModelNo" runat="server"></asp:TextBox>
                    <asp:Button ID="btnGo0" runat="server" OnClick="btnGo_Click" Text="Search" Width="100px" />
                </div>

                 <label class="col-sm-2 control-label text-right">Item with Color & Length Wise Stock:</label>
                <div class="col-sm-4">
                  
                    <asp:Button ID="btnstockleng" runat="server" OnClick="btnstockleng_Click" Text="View" Width="100px" />
                </div>

            </div>






         




            <div class="datatable-tasks">

                <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="hai_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="Material_Code" HeaderText="Item Code" SortExpression="Material_Code" />
                        <asp:BoundField DataField="Color_Name" HeaderText="Color" SortExpression="Color_Name" />

                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="ITEM_CATEGORY_NAME" HeaderText="Category" SortExpression="ITEM_CATEGORY_NAME" />

                        <asp:BoundField DataField="stocklength" HeaderText="Length" SortExpression="stocklength" />

                        <%--  <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />--%>

                        <%--   <asp:BoundField DataField="Plant_Name" HeaderText="Plant" SortExpression="Plant_Name" />--%>

                        <%--   <asp:BoundField DataField="StorageLocation_Name" HeaderText="Storage" SortExpression="StorageLocation_Name" />
                        --%>

                        <asp:BoundField DataField="MatId" HeaderText="ItemCodeId" SortExpression="MatId" />
                        <asp:BoundField DataField="ColorId" HeaderText="ColorId" SortExpression="ColorId" />

                        <asp:BoundField DataField="TotalStock" HeaderText="Total Stock" SortExpression="TotalStock" />
                        <asp:BoundField DataField="Blockedstock" HeaderText="Blocked Stock" SortExpression="Blockedstock" />
                        <asp:BoundField DataField="FreeStock" HeaderText="Free Stock" />
                    </Columns>
                </asp:GridView>

                <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select *,Stock.Length as stocklength,ITEM_CATEGORY_NAME from Stock,Material_Master,Plant_Master,Color_Master,Category_Master
where
Stock.MatId = Material_Master.Material_Id and
Stock.ColorId = Color_Master.Color_Id and
Stock.PlantId = Plant_Master.Plant_Id and
 Material_Master.Category_Id= Category_Master.ITEM_CATEGORY_ID "></asp:SqlDataSource>--%>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select *, O.Length AS stocklength,
  TotalStock = (SELECT  isnull(sum(K.Quantity),0) FROM Stock K WHERE K.MatId = O.MatId and K.ColorId = O.ColorId and K.Length = O.Length),
  Blockedstock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = O.MatId and B.Color_Id = O.ColorId and B.Length = O.Length )

  from Stock O,Material_Master M,Color_Master C,Category_Master CM where O.MatId = M.Material_Id and O.ColorId = C.Color_Id and O.Length = O.Length AND M.Category_Id = CM.ITEM_CATEGORY_ID "></asp:SqlDataSource>

                <%--
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select *, O.Length AS stocklength,
  TotalStock = (SELECT  isnull(sum(K.Quantity),0) FROM Stock K WHERE K.MatId = O.MatId and K.ColorId = O.ColorId and K.Length = O.Length),
  Blockedstock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = O.MatId and B.Color_Id = O.ColorId and B.Length = O.Length ),
  Freestock =  case when((SELECT  isnull(sum(K.Quantity),0) FROM Stock K WHERE K.MatId = O.MatId and K.ColorId = O.ColorId and K.Length = O.Length) - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = O.MatId and B.Color_Id = O.ColorId and B.Length = O.Length ) ) < 0  then 0 else (SELECT  isnull(sum(K.Quantity),0) FROM Stock K WHERE K.MatId = O.MatId and K.ColorId = O.ColorId and K.Length = O.Length)- (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = O.MatId and B.Color_Id = O.ColorId and B.Length = O.Length ) end
 from Stock O,Material_Master M,Color_Master C,Category_Master CM where O.MatId = M.Material_Id and O.ColorId = C.Color_Id and O.Length = O.Length AND M.Category_Id = CM.ITEM_CATEGORY_ID"></asp:SqlDataSource>--%>

                <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>