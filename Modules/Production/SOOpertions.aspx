<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SOOpertions.aspx.cs" Inherits="Modules_Production_SOOpertions" %>

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
                 buttons: ['copyHtml5',
    'excelHtml5',
    'csvHtml5',
    'pdfHtml5'],
                 bStateSave: true,
                 order: [[0, 'desc']],
             });
         }
</script>









     <div class="page-header">
        <div class="page-title">
            <h3>Operations to windows</h3>
        </div>
    </div>
    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Give Operations to Windows</h6>
            <span class="pull-right"/>
        </div>
            <div class="panel-body">
                <div class="form-group">
                       <label class="col-sm-2 control-label text-right">Sales Order No :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList CssClass ="select-full" ID="ddlSoNo" runat ="server" Width="100%" ></asp:DropDownList>
                                        <asp:Label ID="Label1" runat ="server" Visible ="false" ></asp:Label>
                                    </div>


                     <div class="col-sm-4">
                          <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick ="btnSearch_Click" Text="Search" />
                         </div>
                                   
                   </div>
                 
                 <div class="datatable">
                     <asp:GridView ID="hai" runat ="server" CssClass="table table-striped table-bordered" OnRowDataBound="hai_RowDataBound" AutoGenerateColumns="false" Width="100%" >
                         <EmptyDataTemplate>
                             NO Data found
                         </EmptyDataTemplate>

                         <Columns >
                          <asp:BoundField HeaderText ="Id" DataField ="Sow_OperationId" />
                           <asp:BoundField HeaderText ="Project Code" DataField ="ProjectCode" />
                           <asp:BoundField HeaderText="Window" DataField="Wincode" />

                           <%--  <asp:BoundField HeaderText="Strat Date" DataField="Start_Date" />--%>
                           <%--  <asp:BoundField HeaderText="End Date" DataField="End_Date" />--%>


                               <asp:TemplateField HeaderText="Start Date">
                        <ItemTemplate>
                            <asp:TextBox ID="txtstratdate" CssClass="form-control" ClientIDMode="AutoID" runat="server" Text='<%# Bind("Startdate") %>'></asp:TextBox>
                       
                            <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" 
                                TargetControlID="txtstratdate">
                            </cc1:CalendarExtender>
                        </ItemTemplate>
                    </asp:TemplateField>

                               <asp:TemplateField HeaderText="End Date">
                        <ItemTemplate>
                            <asp:TextBox ID="txtenddate" CssClass="form-control" runat="server" ClientIDMode="AutoID" Text='<%# Bind("EndDate") %>'></asp:TextBox>
                       
                            <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server"
                                TargetControlID="txtenddate">
                            </cc1:CalendarExtender>
                        </ItemTemplate>
                    </asp:TemplateField>



                             
                                <asp:TemplateField HeaderText="Priority">
                                        <ItemTemplate>
                                             <asp:Label ID="lblPriority" CssClass="" runat="server" Text='<%# Eval("priority") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlPriority" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="Low">Low</asp:ListItem>
                                                 <asp:ListItem Value="Medium">Medium</asp:ListItem>
                                                 <asp:ListItem Value="High">High</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>


                                <asp:TemplateField HeaderText="Cutting">
                                        <ItemTemplate>
                                             <asp:Label ID="lblCutting" CssClass="" runat="server" Text='<%# Eval("Cutting") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlcutting" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Floding">
                                        <ItemTemplate>
                                             <asp:Label ID="lblFloding" CssClass="" runat="server" Text='<%# Eval("Floding") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlFloding" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>

                              <asp:TemplateField HeaderText="Machining">
                                        <ItemTemplate>
                                             <asp:Label ID="lblMachining" CssClass="" runat="server" Text='<%# Eval("Machining") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlMachining" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Punching">
                                        <ItemTemplate>
                                             <asp:Label ID="lblPunching" CssClass="" runat="server" Text='<%# Eval("Punching") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlPunching" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>


                              <asp:TemplateField HeaderText="Shearing">
                                        <ItemTemplate>
                                             <asp:Label ID="lblShearing" CssClass="" runat="server" Text='<%# Eval("Shearing") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlShearing" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>

                                <asp:TemplateField HeaderText="Stamping">
                                        <ItemTemplate>
                                             <asp:Label ID="lblStamping" CssClass="" runat="server" Text='<%# Eval("Stamping") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlStamping" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>

                               <asp:TemplateField HeaderText="Casting">
                                        <ItemTemplate>
                                             <asp:Label ID="lblCasting" CssClass="" runat="server" Text='<%# Eval("Casting") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlCasting" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>

                               <asp:TemplateField HeaderText="Welding">
                                        <ItemTemplate>
                                             <asp:Label ID="lblWelding" CssClass="" runat="server" Text='<%# Eval("Welding") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlWelding" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>


                                <asp:TemplateField HeaderText="Finishing">
                                        <ItemTemplate>
                                             <asp:Label ID="lblFinishing" CssClass="" runat="server" Text='<%# Eval("Finishing") %>' Visible = "false" />
                                            <asp:DropDownList ID="ddlFinishing" CssClass="select-full" Width="100%" runat="server">
                                                 <asp:ListItem Value="0">No</asp:ListItem>
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                 </asp:TemplateField>


                             
                    <asp:TemplateField HeaderText="Assign" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click"  CssClass="btn btn-icon btn-danger" ><i class="icon-upload"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>




                         </Columns>
                     </asp:GridView>
                 </div>
            </div>
        </div>
    </div>



</asp:Content>

