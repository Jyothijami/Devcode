<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="MumbaiStock.aspx.cs" Inherits="Modules_Stock_MumbaiStock" %>

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

             <div class="page-header">
                <div class="page-title">
                    <h3>Mumbai Stocks</h3>
                </div>
             </div>

           


     <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Mumbai Stock</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Update MumbaiStock" OnClick="btnAddnew_Click" /></span>
        </div>




         <div class="datatable-tasks">

                <asp:GridView ID="hai" CssClass="table table-bordered" DataSourceID="SqlDataSource1" runat="server" AutoGenerateColumns="False" >
                    <Columns>
                        <asp:BoundField DataField="Material_Code" HeaderText="Item Code" SortExpression="Material_Code" />
                        <asp:BoundField DataField="Color_Name" HeaderText="Color" SortExpression="Color_Name" />

                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        
                        <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />

                       <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />

                    
                    </Columns>
                </asp:GridView>

               

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select *
  from MumbaiStock O,Material_Master M,Color_Master C  where O.MatId = M.Material_Id and O.ColorId = C.Color_Id "></asp:SqlDataSource>

              
             
            </div>
















         </div>
    




</asp:Content>

