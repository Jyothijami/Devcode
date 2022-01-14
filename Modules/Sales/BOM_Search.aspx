<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="BOM_Search.aspx.cs" Inherits="Modules_Sales_BOM_Search" %>

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
            <h3>BOM Search</h3>
        </div>
    </div>
    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>BOM Search</h6>
            <span class="pull-right"/>
        </div>
            <div class="panel-body">
                <div class="form-group">
                       <label class="col-sm-2 control-label text-right">Sales Order No :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList CssClass ="select-full" ID="ddlSoNo" runat ="server" Width="100%" ></asp:DropDownList>
                                        <asp:Label ID="Label1" runat ="server" Visible ="false" ></asp:Label>
                                    </div>
                                   
                   </div>
                 <div class="form-actions col-sm-offset-2">
             <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick ="btnSearch_Click" Text="Search" />
         </div>
                 <div class="datatable-tasks">
                     <asp:GridView ID="hai" runat ="server" CssClass="table table-bordered" OnRowDataBound="hai_RowDataBound" AutoGenerateColumns="false" >
                         <EmptyDataTemplate>
                             NO Data found
                         </EmptyDataTemplate>

                         <Columns >

                           <asp:BoundField HeaderText="Item Code" DataField="Material_Code" />
                              <asp:BoundField HeaderText="Description" DataField="DESCRIPTION" />
                                 <asp:BoundField HeaderText="Color" DataField="Color_Name" />
                              <asp:BoundField HeaderText="Length" DataField="length" />
                             <asp:BoundField HeaderText="BOM Qty" DataField="BOMQty" />
                              <asp:BoundField HeaderText="PU" DataField="PU" />
                                 <asp:BoundField HeaderText="Req Qty" DataField="REQUIRED_QTY" />
                              <asp:BoundField HeaderText="Unit" DataField="UNIT" />
                               <asp:BoundField HeaderText="Blocked" DataField="Blockedstock" />

                                <asp:BoundField HeaderText="FreeStock" DataField="FreeStock" />

                                

                               <asp:BoundField HeaderText="Short"  />
                                <asp:BoundField HeaderText="MumbaiStock" DataField="Mumbaistock" />
                         </Columns>
                     </asp:GridView>
                 </div>
            </div>
        </div>
    </div>
    
</asp:Content>

