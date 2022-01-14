<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Inventory_Search.aspx.cs" Inherits="Modules_Stock_Inventory_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            color: #FF0000;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.6/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
   <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.6/js/buttons.html5.min.js"></script>

      <script type="text/javascript">
          $(document).ready(function () {
              fnPageLoad();
          });
          function fnPageLoad() {
              $('#<%=gvIssues.ClientID%>').prepend($("<thead></thead>").append($('#<%=gvIssues.ClientID%>').find("tr:first"))).DataTable({

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

      <script type="text/javascript">
        $(document).ready(function () {
            fnPageLoad1();
        });
        function fnPageLoad1() {
            $('#<%=gvRqst.ClientID%>').prepend($("<thead></thead>").append($('#<%=gvRqst.ClientID%>').find("tr:first"))).DataTable({

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
					<h3>Requests/Issues</h3>

				</div>
				
			</div>
   <!-- /page header -->
    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					
					<li class="active">Requests/Issues Search</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->
    <div class="form-horizontal">
        <div class="panel panel-default">
            
            <div class="panel-heading text-center">
            <div class ="">
                            <asp:LinkButton CssClass=" btn btn-danger "  ID="lnkReqst" OnClick ="lnkReqst_Click" runat ="server" Font-Underline ="true"  >Material Request Search</asp:LinkButton> || 
                            <asp:LinkButton CssClass="btn btn-danger" ID ="lnkIssues" OnClick ="lnkIssues_Click" runat ="server" Font-Underline ="true" >Material Issue Search</asp:LinkButton>
              </div>
            </div>


            <div class="panel-body">
                <div class="form-group text-center">

                <asp:RadioButtonList ID="rdbIssueSlip" runat="server" RepeatDirection="Horizontal" >
                        <%--<asp:ListItem Value="0" Selected="True">All</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="1" >Material Slip</asp:ListItem>
                        <asp:ListItem Value="2">RGP</asp:ListItem>
                        <asp:ListItem Value="3">NRGP</asp:ListItem>
                      <asp:ListItem Value="4">Packing List</asp:ListItem>
                 </asp:RadioButtonList>

                </div>
                <asp:Panel runat ="server" ID ="pnlreqst" Visible ="false" >
                    <div class ="form-group">
                        <label class="col-sm-2 control-label text-right">Customer Name :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID ="txtrqstcust" CssClass ="form-control" runat ="server" ></asp:TextBox>
                                        <asp:Label ID="Label2" runat ="server" Visible ="false" ></asp:Label>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Material Code :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtrqstmaterial" runat="server" CssClass ="form-control"></asp:TextBox>
                                    </div>
                    </div>
                     <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">From Date :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtrqstfrom" CssClass="form-control"  runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="Image2" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender3" runat="server" PopupButtonID="Image2"
                                            TargetControlID="txtrqstfrom">
                                        </cc1:CalendarExtender>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">To Date :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtrqstto" CssClass="form-control"  runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="Image3" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender4" runat="server" PopupButtonID="Image3"
                                            TargetControlID="txtrqstto">
                                        </cc1:CalendarExtender>
                                    </div>
               </div>
                <div class="form-group">
                       <label class="col-sm-2 control-label text-right">Project Code :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID ="txtrqstprjtcode" CssClass ="form-control" runat ="server" ></asp:TextBox>
                                        <asp:Label ID="Label3" runat ="server" Visible ="false" ></asp:Label>
                                    </div>
                                   
                   </div>
                   <div class="form-actions col-sm-offset-2">
             <asp:Button ID="btnrqstSearch" runat="server" CssClass="btn btn-primary" OnClick="btnrqstSearch_Click" Text="Search" />
                       </div> 
                    <div>
                        <asp:GridView ID="gvRqst" runat ="server" Width="100%" SelectedRowStyle-BackColor="#c0c0c0" EmptyDataText="No Records To Display">

                        </asp:GridView>
                    </div>
                </asp:Panel>
               <asp:Panel runat="server" ID="pnlDC" Visible ="false"  >
                   <div class="form-group">
                       <label class="col-sm-2 control-label text-right">Customer Name :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID ="txtCust" CssClass ="form-control" runat ="server" ></asp:TextBox>
                                        <asp:Label ID="lblEmpId" runat ="server" Visible ="false" ></asp:Label>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Material Code :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtMaterialCode" runat="server" CssClass ="form-control"></asp:TextBox>
                                    </div>
                   </div>
                   <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">From Date :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtFromDate2" CssClass="form-control"  runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                                            TargetControlID="txtFromDate2">
                                        </cc1:CalendarExtender>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">To Date :</label>
                                    <div class="col-sm-4">
                                         <asp:TextBox ID="txtToDate2" CssClass="form-control"  runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                                            TargetControlID="txtToDate2">
                                        </cc1:CalendarExtender>
                                    </div>
               </div>
                <div class="form-group">
                       <label class="col-sm-2 control-label text-right">Project Code :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID ="txtPrjtcode" CssClass ="form-control" runat ="server" ></asp:TextBox>
                                        <asp:Label ID="Label1" runat ="server" Visible ="false" ></asp:Label>
                                    </div>
                                   
                   </div>
                   <div class="form-actions col-sm-offset-2">
             <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick ="btnSearch_Click" Text="Search" />
         </div>
                   <div>
                       <asp:GridView ID="gvIssues" runat ="server" Width="100%" SelectedRowStyle-BackColor="#c0c0c0" EmptyDataText="No Records To Display" >
                           <%--<Columns>
                               <asp:BoundField DataField ="Issue_No" HeaderText ="Issue No" />
                               <asp:BoundField DataField ="Issue_Date" HeaderText ="Issued Dt" />
                               <asp:BoundField DataField ="ProjectCode" HeaderText ="Project Code" />
                               <asp:BoundField DataField ="Material_Code" HeaderText ="Material Code" />
                               <asp:BoundField DataField ="Issued_Qty" HeaderText ="Issued Qty" />
                               <asp:BoundField DataField ="Length" HeaderText ="Length" />
                               <asp:BoundField DataField ="ReceiveQty" HeaderText ="Recive Qty" />
                               <asp:BoundField DataField ="CUST_UNIT_NAME" HeaderText ="Cust Name" />
                               
                           </Columns>
                           <EmptyDataTemplate>
                               <div class="auto-style1">
                                   No Data Found</div>
                           </EmptyDataTemplate>
                           <SelectedRowStyle BackColor="Silver" />--%>
                       </asp:GridView>

                   </div>
                   
               </asp:Panel>
            </div>


        </div>
    </div>
</asp:Content>

