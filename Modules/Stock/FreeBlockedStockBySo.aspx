<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="FreeBlockedStockBySo.aspx.cs" Inherits="Modules_Stock_FreeBlockedStockBySo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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

                bStateSave: true,
                order: [[0, 'desc']],
            });
        }
    </script>


        <div class="form-horizontal">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Item Blocked Details</h6>
            <span class="pull-right"/>
        </div>
            <div class="panel-body">
           
            <div class="form-group">
                       <label class="col-sm-2 control-label text-right">Project Code :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID ="txtPrjtcode" Width="100%" CssClass ="select-full" runat ="server" ></asp:DropDownList>
                                        <asp:Label ID="Label1" runat ="server" Visible ="false" ></asp:Label>
                                    </div>
                                   
             </div>
            <div class="form-actions col-sm-offset-2">
             <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick ="btnSearch_Click" Text="Search" />
         </div>

               </div> 

            <div class="panel panel-default">
                 <div class="panel-body">

            <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="BlockStock_Id" HeaderText="Sl.No" SortExpression="BlockStock_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                  <%--  <asp:BoundField DataField="SalesOrder_No" HeaderText="SO No" SortExpression="SalesOrder_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>--%>

                    <asp:BoundField DataField="CUST_NAME" HeaderText="Cust Name" SortExpression="CUST_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="ProjectCode" HeaderText="Project Code" SortExpression="ProjectCode">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Material_Code" HeaderText="Item Code" SortExpression="Material_Code">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Color_Name" HeaderText="Color" SortExpression="Color_Name">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                

                    <asp:BoundField DataField="UOM_SHORT_DESC" HeaderText="UOM" SortExpression="UOM_SHORT_DESC">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="blocklength" HeaderText="Length" SortExpression="blocklength">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Free Qty">
                        <ItemTemplate>
                            <asp:TextBox ID="txtitemqty" CssClass="form-control" runat="server" ></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:TextBox ID="txtitemRemarks" CssClass="form-control" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                   <%-- <asp:TemplateField HeaderText="Make to Free" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-icon btn-danger" OnClick="lbtnDelete_Click"><i class="icon-remove3"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>

            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT        Stock_Block.BlockStock_Id, Sales_Order.SalesOrder_No, Color_Master.Color_Name, Material_Master.Material_Code, Material_Master.Description, Uom_Master.UOM_SHORT_DESC, Stock_Block.Length as blocklength,
                         Stock_Block.Qty, Stock_Block.Remarks, Sales_Order.ProjectCode, Customer_Master.CUST_NAME, Customer_Units.CUST_UNIT_NAME
FROM            Stock_Block LEFT OUTER JOIN
                         Sales_Order ON Stock_Block.So_Id = Sales_Order.SalesOrder_Id LEFT OUTER JOIN
                         Color_Master ON Stock_Block.Color_Id = Color_Master.Color_Id LEFT OUTER JOIN
                         Material_Master ON Stock_Block.Item_Code = Material_Master.Material_Id LEFT OUTER JOIN
                         Customer_Units ON Stock_Block.Project_Id = Customer_Units.CUST_UNIT_ID LEFT OUTER JOIN
                         Customer_Master ON Stock_Block.Cust_Id = Customer_Master.CUST_ID LEFT OUTER JOIN
                         Uom_Master ON Material_Master.UOM_Id = Uom_Master.UOM_ID"></asp:SqlDataSource>--%>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>




               <div class="form-actions col-sm-offset-2">
               <asp:Button ID="BtnUpdate" runat="server" CssClass="btn btn-danger" OnClick ="BtnUpdate_Click" Text="Update" />
              </div>


                     </div>
                </div>

         
        </div>
        </div> 







</asp:Content>

