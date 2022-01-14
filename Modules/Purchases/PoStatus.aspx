<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="PoStatus.aspx.cs" Inherits="Modules_Purchases_PoStatus" %>

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







    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>PO Status</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>PO Status</h6>
        </div>

        <div class="">

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

                    <asp:BoundField DataField="SUP_NAME" HeaderText="Supplier Name" SortExpression="SUP_NAME">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="GrandTotal" HeaderText="Grand Total" SortExpression="GrandTotal">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="CustomerNo" HeaderText="Project Code" SortExpression="CustomerNo" >
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="PO Status">
                        <ItemTemplate>

                            <asp:Label ID="lbldesignerstatus" runat="server" Text='<%# Eval("status") %>' Visible="false" />
                            <asp:DropDownList ID="ddldesignStatus" CssClass="form-control" Width="100%" runat="server">

                                <asp:ListItem Value="New">New</asp:ListItem>
                                <asp:ListItem Value="Released">Released</asp:ListItem>
                                <asp:ListItem Value="Received">Received</asp:ListItem>
                                 <asp:ListItem Value="ChangeOrder">Change Order</asp:ListItem>
                                 <asp:ListItem Value="Canceled">Canceled</asp:ListItem>
                                 <asp:ListItem Value="Closed">Closed</asp:ListItem>


                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Paid Amount" >
                        <ItemTemplate>
                            <asp:TextBox ID="txtPaidAmt"  CssClass="form-control"  runat="server" Text='<%# Bind("Amount_Paid") %>'></asp:TextBox>
                            
                                              </ItemTemplate>
                           

                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:TextBox ID="txtremarks" CssClass="form-control" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>


               
                    <asp:TemplateField HeaderText="Update" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click" CssClass="btn btn-icon btn-danger"><i class="icon-upload"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                
                
                
                
                
                
                 <%--<Columns>
                    <asp:BoundField DataField="ENQ_ID" HeaderText="Sl.No" SortExpression="ENQ_ID"></asp:BoundField>
                    <asp:BoundField DataField="ENQ_NO" HeaderText="Enq No" SortExpression="ENQ_NO"></asp:BoundField>

                    <asp:BoundField DataField="ENQ_DATE" HeaderText="Date" SortExpression="ENQ_DATE" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>

                    <asp:BoundField DataField="CUST_NAME" HeaderText="Customer" SortExpression="CUST_NAME"></asp:BoundField>
                    <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" SortExpression="CUST_UNIT_NAME"></asp:BoundField>

                    <asp:BoundField DataField="STATUS" HeaderText="Status" SortExpression="STATUS"></asp:BoundField>

                    

                         <asp:TemplateField HeaderText="Design Assigned to">
                                        <ItemTemplate>
                                             <asp:Label ID="lbldesigner" CssClass="" runat="server" Text='<%# Eval("DESIGNINCHARGE_ID") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddldesigner" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Design Status">
                                        <ItemTemplate>

                                            <asp:Label ID="lbldesignerstatus" runat="server" Text='<%# Eval("DesignerStatus") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddldesignStatus" CssClass="select-full" Width="100%" runat="server">

                                              <asp:ListItem Value="NotStarted">Not Started</asp:ListItem>
                                            <asp:ListItem Value="Progress">In Progress</asp:ListItem>
                                            <asp:ListItem Value="Completed">Completed</asp:ListItem>

                                            </asp:DropDownList>
                                        </ItemTemplate>
                    </asp:TemplateField>


                       <asp:TemplateField HeaderText="Estimation Assigned to">
                                        <ItemTemplate>


                                            <asp:Label ID="lblestimation" runat="server" Text='<%# Eval("EstimatationInchargeId") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlestimation" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estimation Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblestimationstatus" runat="server" Text='<%# Eval("EstimationStatus") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlestimationStatus" CssClass="select-full"  Width="100%" runat="server">

                                            <asp:ListItem Value="NotStarted">Not Started</asp:ListItem>
                                            <asp:ListItem Value="Progress">In Progress</asp:ListItem>
                                            <asp:ListItem Value="Completed">Completed</asp:ListItem>

                                            </asp:DropDownList>
                                        </ItemTemplate>
                    </asp:TemplateField>


                     <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:TextBox ID="txtitemRemarks" TextMode="MultiLine" runat="server" Text='<%# Bind("TODISCUSS") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Assign" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CssClass="btn btn-icon btn-danger" ><i class="icon-upload"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>







                </Columns>--%>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT ISNULL(Sup_PO_Status.staus, 'New') as status,Amount_Paid,Delivery_Option,Sup_PO_Status.PreparedBy,Sup_PO_Status.Remarks,CustomerNo,Supplier_Po_Master.Sup_PO_Id, Supplier_Po_Master.Sup_PO_No, Supplier_Po_Master.Sup_PO_Date, Supplier_Quotation_Master.Sup_Quo_No, Supplier_Quotation_Master.Sup_Quo_Date, Supplier_Master.SUP_NAME, Supplier_Master.SUP_MOBILE, Supplier_Po_Master.GrandTotal,Employee_Master.EMP_FIRST_NAME+''+Employee_Master.EMP_LAST_NAME as preparedby FROM  Supplier_Po_Master left outer join Sup_PO_status on Sup_PO_Status.Sup_PO_ID=Supplier_Po_Master.Sup_PO_Id INNER JOIN Supplier_Master ON Supplier_Po_Master.Sup_Id = Supplier_Master.SUP_ID INNER JOIN  Supplier_Quotation_Master ON Supplier_Po_Master.Matrequest_Id = Supplier_Quotation_Master.Sup_Quo_Id INNER JOIN Employee_Master ON Supplier_Po_Master.PreparedBy = Employee_Master.EMP_ID order by Supplier_Po_Master.Sup_PO_Id desc"></asp:SqlDataSource>
          
            
            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>