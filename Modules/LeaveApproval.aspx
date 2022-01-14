<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="LeaveApproval.aspx.cs" Inherits="Modules_LeaveApproval" %>

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
			                <div class="panel-heading"><h6 class="panel-title"><i class="icon-file"></i>HOD Leave Approval</h6> </div>
			         

                                <div class="">

    <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="hai_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Lap_id" HeaderText="Sl.No" SortExpression="Lap_id" />
            <asp:BoundField DataField="Lap_No" HeaderText="Application No" SortExpression="Lap_No" />
            <asp:BoundField DataField="EMPName" HeaderText="Employee" SortExpression="EMPName" />
               <asp:BoundField DataField="From_date" HeaderText="From Date" SortExpression="From_date" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="To_date" HeaderText="To Date" SortExpression="To_date" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="NoofDays" HeaderText="No.of Days" SortExpression="NoofDays" />
            <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
           
                        

              <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                                    <asp:Label ID="lblhodstatus" runat="server" Text='<%# Eval("HodStatus") %>' Visible="false" />
                                    <asp:DropDownList ID="ddlhodstatus" CssClass="form-control"  runat="server">
                                    <asp:ListItem Value="Open">Open</asp:ListItem>
                                    <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                    <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                                </asp:DropDownList>   
                           
                        </ItemTemplate>
                      
                    </asp:TemplateField>


              <asp:TemplateField HeaderText="Update" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CssClass="btn btn-icon btn-danger"><i class="icon-upload"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

        
                  </Columns>
                                </asp:GridView>

                                                                <asp:Label id="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                            <asp:Label id="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>

                                    </div>
  </div>






</asp:Content>

