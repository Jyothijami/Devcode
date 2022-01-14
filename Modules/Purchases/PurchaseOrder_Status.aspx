<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="PurchaseOrder_Status.aspx.cs" Inherits="Modules_Purchases_PurchaseOrder_Status" %>

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
            <h3>Supplier Purchase Order</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Purchase Order</h6>
        </div>

       <div class="datatable-tasks">

         <div class="panel-body">

              

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="hai_RowDataBound">


                <Columns>
                    <asp:BoundField DataField="Sup_PO_Id" HeaderText="Sl.No" SortExpression="Sup_PO_Id">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Sup_PO_No" HeaderText="Sup PO No" SortExpression="Sup_PO_No">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Sup_PO_Date" HeaderText="Date" SortExpression="Sup_PO_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>


                    <%--    <asp:BoundField DataField="Sup_Quo_Date" HeaderText="Quot Date" SortExpression="Sup_Quo_Date" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>--%>

                    <asp:BoundField DataField="SUP_NAME" HeaderText="Supplier Name" SortExpression="SUP_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="GrandTotal" HeaderText="Grand Total" SortExpression="GrandTotal">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <%--                    <asp:BoundField DataField="preparedby" HeaderText="Prepared By" SortExpression="preparedby">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>--%>




                    <asp:BoundField DataField="CustomerNo" HeaderText="CustomerNo" SortExpression="CustomerNo">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Payment Status">
                        <ItemTemplate>

                            <asp:Label ID="lbldesignerstatus" runat="server" Text='<%# Eval("Staus") %>' Visible="false" />
                            <asp:DropDownList ID="ddldesignStatus" CssClass="select-full" Width="100%" runat="server">

                                <asp:ListItem Value="Not Paid">Not Paid</asp:ListItem>
                                <asp:ListItem Value="Half Paid">Half Paid</asp:ListItem>
                                <asp:ListItem Value="Paid">Paid</asp:ListItem>


                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Paid Amount">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPaidAmt" runat="server" Text='<%# Bind("Amount_Paid") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Expected Delivery Dt">
                        <ItemTemplate>
                            <asp:TextBox ID="txtDeliveryDt" runat="server" Text='<%# Bind("Delivery_Option") %>'></asp:TextBox>
                            <asp:Image
                                ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                            <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                                TargetControlID="txtDeliveryDt">
                            </cc1:CalendarExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Assign" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click" CssClass="btn btn-icon btn-danger"><i class="icon-upload"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>


            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT Sup_PO_Status.staus,Amount_Paid,Delivery_Option,Sup_PO_Status.PreparedBy,Sup_PO_Status.Remarks,CustomerNo,Supplier_Po_Master.Sup_PO_Id, Supplier_Po_Master.Sup_PO_No, Supplier_Po_Master.Sup_PO_Date, Supplier_Quotation_Master.Sup_Quo_No, Supplier_Quotation_Master.Sup_Quo_Date, Supplier_Master.SUP_NAME, Supplier_Master.SUP_MOBILE, Supplier_Po_Master.GrandTotal,Employee_Master.EMP_FIRST_NAME+''+Employee_Master.EMP_LAST_NAME as preparedby FROM  Supplier_Po_Master left outer join Sup_PO_status on Sup_PO_Status.Sup_PO_ID=Supplier_Po_Master.Sup_PO_Id INNER JOIN Supplier_Master ON Supplier_Po_Master.Sup_Id = Supplier_Master.SUP_ID INNER JOIN  Supplier_Quotation_Master ON Supplier_Po_Master.Matrequest_Id = Supplier_Quotation_Master.Sup_Quo_Id INNER JOIN Employee_Master ON Supplier_Po_Master.PreparedBy = Employee_Master.EMP_ID order by Supplier_Po_Master.Sup_PO_Id desc"></asp:SqlDataSource>
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>


        </div>
        </div>
     </div>

        


</asp:Content>

