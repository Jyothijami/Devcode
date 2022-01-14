<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="GlassPurchaseOrderStatus.aspx.cs" Inherits="Modules_Stock_GlassPurchaseOrderStatus" %>

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
                lengthChange: false,
                pageLength: 10,

                bStateSave: true,
                order: [[0, 'desc']],


                fixedHeader: {
                    header: true,
                    footer: true
                }

            });
        }
</script>

      <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Glass Purchase Order</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Glass Purchase Order</h6>
           
        </div>

        <div class="">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCommand="hai_RowCommand" DataKeyNames="Sup_GPO_Id">
                <Columns>
                    <asp:BoundField DataField="Sup_GPO_Id" HeaderText="Sl.No" SortExpression="Sup_GPO_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Sup_GPO_No" HeaderText="Glass PO No" SortExpression="Sup_GPO_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="SUP_NAME" HeaderText="Supplier Name" SortExpression="SUP_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                       
                     <asp:BoundField DataField="CustomerNo" HeaderText="Customer No" SortExpression="CustomerNo">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                      <asp:BoundField DataField="IndentNo" HeaderText="PO Nos" SortExpression="IndentNo">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                     <asp:TemplateField HeaderText="Delivered to">
                        <ItemTemplate>
                            <div class="row">
                                <div >
                                    <asp:TextBox ID="txtdeliveredto" runat="server"  Text='<%# Eval("Deliverto") %>'></asp:TextBox>
                                </div>
                               
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    

                      <asp:TemplateField HeaderText="DeliveryDate">
                        <ItemTemplate>
                            <div class="row">
                                <div >
                                    <asp:TextBox ID="txtdeliverydate" runat="server"  Text='<%# Eval("DeliveryDate") %>'></asp:TextBox>
                                </div>
                               
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <div class="row">
                                <div >
                                    <asp:TextBox ID="txtremarks" runat="server"  Text='<%# Eval("Message") %>'></asp:TextBox>
                                </div>
                               
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                   



                      <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlReports" runat="server" Width="60px" EnableViewState="true">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>Close</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="Print" runat="server" CssClass="btn btn-danger"
                                        CommandArgument="<%# Container.DataItemIndex%>" CommandName="Print"
                                        Text="Update" />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>



                   
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT  Glass_PO_Master.Deliverto, Glass_PO_Master.DeliveryDate, Glass_PO_Master.Message,  Glass_PO_Master.Status,   Glass_PO_Master.Sup_GPO_Id, Glass_PO_Master.Sup_GPO_No, Glass_PO_Master.Sup_GPO_Date, Supplier_Master.SUP_NAME, Supplier_Master.SUP_MOBILE, Glass_PO_Master.GrandTotal, Glass_PO_Master.IndentNo,
                         Employee_Master.EMP_FIRST_NAME + ' ' + Employee_Master.EMP_LAST_NAME AS preparedby, Glass_PO_Master.CustomerNo
FROM            Glass_PO_Master INNER JOIN
                         Supplier_Master ON Glass_PO_Master.Sup_Id = Supplier_Master.SUP_ID INNER JOIN
                         Employee_Master ON Glass_PO_Master.PreparedBy = Employee_Master.EMP_ID where Glass_PO_Master.Status != 'Close' order by Sup_GPO_Id desc "></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>






</asp:Content>

