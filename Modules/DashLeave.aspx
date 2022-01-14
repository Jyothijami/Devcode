<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="DashLeave.aspx.cs" Inherits="Modules_HR_DashLeave" %>

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






     <div class="panel panel-default">
			                <div class="panel-heading"><h6 class="panel-title"><i class="icon-file"></i> Leave Application</h6> </div>
			         

                                <div class="">

    <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" >
        <Columns>
           <asp:BoundField DataField="Lap_id" HeaderText="Sl.No" SortExpression="Lap_id" />
            <asp:BoundField DataField="Lap_No" HeaderText="Application No" SortExpression="Lap_No" />
            <asp:BoundField DataField="EMPName" HeaderText="Employee" SortExpression="EMPName" />
            <asp:BoundField DataField="From_date" HeaderText="From Date" SortExpression="From_date" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="To_date" HeaderText="To Date" SortExpression="To_date" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="NoofDays" HeaderText="No.of Days" SortExpression="NoofDays" />
            <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
            <asp:BoundField DataField="HodStatus" HeaderText="HOD Status" SortExpression="HodStatus" />
          
   
        </Columns>
                                </asp:GridView>

                               

                                    </div>
  </div>









</asp:Content>

