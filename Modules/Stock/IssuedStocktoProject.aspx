<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="IssuedStocktoProject.aspx.cs" Inherits="Modules_Stock_IssuedStocktoProject" %>

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


    <div class="row">
    </div>

    <br />

    <div class="row" runat="server" visible="true">

        <div class="heading-hr">Total Issued Material to Project</div>
        <div class="col-md-3 text-right">
            <label class="control-label text-right">Select Project Code :</label>
        </div>
        <div class="col-md-9">
            <asp:DropDownList ID="ddlprojects" Width="50%" CssClass="select-full" runat="server"></asp:DropDownList>
        </div>
    </div>

    

    <br />
    <div class="row text-center">

        <asp:Button ID="btnfromto" OnClick="btnfromto_Click" runat="server" Text="Search" CssClass="btn btn-danger" />


    </div>



    <div class="panel">

        <div class="panel-body">
            <div class="row">

                <asp:GridView ID="GridView1" CssClass="table table-bordered" Width="100%" OnRowDataBound="GridView1_RowDataBound" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Material_Code" HeaderText="Item Code" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Color_Name" HeaderText="Color" />
                        <asp:BoundField DataField="Lent" HeaderText="Length" />
                        <asp:BoundField DataField="MaterialIssue" HeaderText="MaterialIssue" />
                        <asp:BoundField DataField="NrgpIssue" HeaderText="NrgpIssue" />
                        <asp:BoundField DataField="PackingListIssue" HeaderText="PackingListIssue" />


                        <asp:TemplateField HeaderText="Total Issued">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text ='<%# Convert.ToDouble(Eval("MaterialIssue"))+ Convert.ToDouble(Eval("NrgpIssue")) + Convert.ToDouble(Eval("PackingListIssue")) %>'></asp:Label>
                              
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:BoundField DataField="Received" HeaderText="Received" />
                        <asp:BoundField DataField="InBlockedQty" HeaderText="InBlockedQty" />
                    </Columns>








                </asp:GridView>


            </div>
        </div>


    </div>







</asp:Content>

