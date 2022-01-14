<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="Modules_Masters_Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <%--  <script type="text/javascript">
         //On Page Load
         $(function () {
             $('#<%= GridView1.ClientID %>').DataTable();
    });

</script>

      <script type="text/javascript" lang="javascript">
          var prm = Sys.WebForms.PageRequestManager.getInstance();
          if (prm != null) {
              prm.add_endRequest(function (sender, e) {
                  if (sender._postBackSettings.panelsToUpdate != null) {
                      $('#<%= GridView1.ClientID %>').DataTable();
            }
        });
    };
            </script>--%>



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
              $('#<%=GridView1.ClientID%>').prepend($("<thead></thead>").append($('#<%=GridView1.ClientID%>').find("tr:first"))).DataTable({

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
            <h6 class="panel-title"><i class="icon-file"></i>Item Details</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>
        <div class="panel-body">
            <div class="datatable-tasks">

                <asp:GridView ID="GridView1" CssClass="table table-bordered"  runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" >
                    <Columns>


                       

                        <asp:BoundField DataField="Material_Id" HeaderText="Sl.No" SortExpression="Material_Id" />


                         <%--   <asp:TemplateField HeaderText="Image">
             <ItemTemplate>
                    <asp:Image ID="Image" runat="server" ImageUrl="~/images/noname.jpg" Width="70px" />
             </ItemTemplate>
                   </asp:TemplateField>--%>

       <%-- <asp:TemplateField HeaderText="Image">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" Height="100px" Width="100px"
                    ImageUrl='<%# "data:Image/png;base64,"
                    + Convert.ToBase64String((byte[])Eval("Item_Image")) %>' />
            </ItemTemplate>
        </asp:TemplateField>--%>

                        <asp:BoundField DataField="Material_Code" HeaderText="Material Code" SortExpression="Material_Code" />
                        <asp:BoundField DataField="ITEM_CATEGORY_NAME" HeaderText="Category" SortExpression="ITEM_CATEGORY_NAME"  />
                        <asp:BoundField DataField="Box_Size" HeaderText="Box Size" SortExpression="Box_Size" />
                         <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                      <asp:TemplateField HeaderText="Change Image" HeaderStyle-CssClass="text-center">
                     <ItemTemplate>
                    <span class="text-center">
                    <asp:LinkButton ID="lbtnImage" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Masters/AddItemImage.aspx?Cid=" + Eval("Material_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
               </span> </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/MASTERS/Item_Details.aspx?Cid=" + Eval("Material_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
                                </span>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                      <%--  <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-icon btn-danger" OnClick="lbtnDelete_Click"><i class="icon-remove3"></i></asp:LinkButton>
                                </span>
                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center">
                            <span style="color: #CC0000">No Data Found</span>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT Category_Master.ITEM_CATEGORY_NAME, Material_Id, Material_Code, Category_Id, Box_Size, Bar_Length, UOM_Id, Cp_Id, SellingCurrency, Brand_Id, BuyingCurrency, BuyingPrice, Series, SellingPrice, Item_Group, Storage_Location_Id, Plant_Id, Weight, Description FROM [Material_Master],Category_Master where Material_Master.Category_Id = Category_Master.ITEM_CATEGORY_ID"></asp:SqlDataSource>
                <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
            </div>
        </div>
    </div>





</asp:Content>

