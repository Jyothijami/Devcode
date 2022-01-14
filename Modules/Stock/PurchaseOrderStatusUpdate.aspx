<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="PurchaseOrderStatusUpdate.aspx.cs" Inherits="Modules_Stock_PurchaseOrderStatusUpdate" %>

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
            pageLength: 100,

            bStateSave: true,
            order: [[0, 'desc']],


            fixedHeader: {
                header: true,
                footer: true
            }

        });
    }
</script>


      <div class="page-header">
        <div class="page-title">
            <h3>Purchase Order Status Update</h3>
        </div>
    </div>
    <!-- /page header -->



      <div class="panel panel-default">

          <div class="panel-body">

    <div class="form-horizontal">


      <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" DataKeyNames="Sup_PO_Id" OnRowCommand="hai_RowCommand" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
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

                    <asp:BoundField DataField="SUP_MOBILE" HeaderText="Mobile No" SortExpression="SUP_MOBILE">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="GrandTotal" HeaderText="Grand Total" SortExpression="GrandTotal">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                    <asp:BoundField DataField="preparedby" HeaderText="Prepared By" SortExpression="preparedby">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>

                      <asp:BoundField DataField="CustomerNo" HeaderText="CustomerNo" SortExpression="CustomerNo">
                        <HeaderStyle Font-Size="Smaller" />
                    </asp:BoundField>





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

     
        
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT CustomerNo,Supplier_Po_Master.Sup_PO_Id, Supplier_Po_Master.Sup_PO_No, Supplier_Po_Master.Sup_PO_Date, Supplier_Quotation_Master.Sup_Quo_No, Supplier_Quotation_Master.Sup_Quo_Date, Supplier_Master.SUP_NAME, Supplier_Master.SUP_MOBILE, Supplier_Po_Master.GrandTotal,Employee_Master.EMP_FIRST_NAME+''+Employee_Master.EMP_LAST_NAME as preparedby ,Supplier_Po_Master.Status FROM  Supplier_Po_Master INNER JOIN Supplier_Master ON Supplier_Po_Master.Sup_Id = Supplier_Master.SUP_ID INNER JOIN  Supplier_Quotation_Master ON Supplier_Po_Master.Matrequest_Id = Supplier_Quotation_Master.Sup_Quo_Id INNER JOIN Employee_Master ON Supplier_Po_Master.PreparedBy = Employee_Master.EMP_ID where Supplier_Po_Master.Status != 'Close' order by Supplier_Po_Master.Sup_PO_Id desc"></asp:SqlDataSource>





    </div>


          </div>

      </div>


</asp:Content>

