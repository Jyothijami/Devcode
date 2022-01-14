<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="MRN_Search.aspx.cs" Inherits="Modules_Stock_MRN_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>
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

    <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>MRN Details</h3>
        </div>
    </div>
    <!-- /page header -->
    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h6 class="panel-title"><i class="icon-file"></i>MRN Details</h6>
                <span class="pull-right"></span>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Project Code :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtPrjtcode" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                    </div>
                    <label class="col-sm-2 control-label text-right">Material Code :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtMaterialCode" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">From Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtrqstfrom" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>

                     <%--   <asp:Image
                            ID="Image3" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender4" runat="server" PopupButtonID="Image3"
                            TargetControlID="txtrqstfrom">
                        </cc1:CalendarExtender>--%>



                    </div>
                    <label class="col-sm-2 control-label text-right">To Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtrqstto" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>

                     <%--   <asp:Image
                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                            TargetControlID="txtrqstto">
                        </cc1:CalendarExtender>--%>

                    </div>
                </div>
                <div class="form-actions col-sm-offset-2">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick="btnSearch_Click" Text="Search" />
                </div>

            </div>
        </div>
    </div>




    <div class="panel panel-default">

        <div class="panel-body">

            <div class="datatable-tasks">

                <asp:GridView ID="hai" CssClass="table table-bordered" runat="server">
                    <EmptyDataTemplate>
                        <span class="auto-style1">No Data Found</span>
                    </EmptyDataTemplate>
                </asp:GridView>

                <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
            </div>


        </div>



    </div>



</asp:Content>
