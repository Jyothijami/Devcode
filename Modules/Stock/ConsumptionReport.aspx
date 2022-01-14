<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="ConsumptionReport.aspx.cs" Inherits="Modules_Stock_ConsumptionReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        <div class="heading-hr">Consumption Trough Project Code</div>
        <div class="col-md-3 text-right">
            <label class="control-label text-right">Select Project Code :</label>
        </div>
        <div class="col-md-9">
            <asp:DropDownList ID="ddlprojects" Width="50%" CssClass="select-full" runat="server"></asp:DropDownList>
        </div>
    </div>

    <div class="row">

        <div class="heading-hr">Consumption Date Wise</div>

        <div class="col-md-3 text-right">
            <label class="control-label text-right">From Date :</label>
        </div>
        <div class="col-md-3 text-right">
            <asp:TextBox ID="txtfromdate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>

        </div>

        <div class="col-md-3 text-right">
            <label class="control-label text-right">To Date :</label>
        </div>
        <div class="col-md-3 text-right">
            <asp:TextBox ID="txttodate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
            <%-- <asp:Image
                            ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="txttodate"
                            TargetControlID="txttodate">
                        </cc1:CalendarExtender>--%>
        </div>
    </div>

    <br />
    <div class="row text-center">

        <asp:Button ID="btnfromto" OnClick="btnfromto_Click" runat="server" Text="Search" CssClass="btn btn-danger" />


    </div>



    <div class="panel">

        <div class="panel-body">
            <div class="row">

                <asp:GridView ID="GridView1" CssClass="table table-bordered" Width="100%" runat="server"></asp:GridView>


            </div>
        </div>


    </div>







</asp:Content>

