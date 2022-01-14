<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="EnquiryAssignment.aspx.cs" Inherits="Modules_Sales_EnquiryAssignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="select/select2.css" rel="stylesheet" />



    <style>
    .ajax__html_editor_extender_container
    {
        width: 100% !important;
        height: 100% !important;
    }
    .ajax__html_editor_extender_texteditor
    {
        width: 100% !important;
        height: 200px !important;
    }
</style>


    <script>

        $(document).ready(function () {
            $('#<%=Books.ClientID%>').select2({ placeholder: 'Select Employee Email' });

            //$("#ContentPlaceHolder1_Books").select2({ placeholder: 'Find and Select Books' });

        });

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            //Binding Code Again
            $(<%=Books.ClientID%>).select2({ placeholder: 'Select Employee Email' });
        }
    </script>

    <%-- For Cc --%>

    <script>

        $(document).ready(function () {
            $('#<%=toccc.ClientID%>').select2({ placeholder: 'Select Employee Email' });

             //$("#ContentPlaceHolder1_Books").select2({ placeholder: 'Find and Select Books' });

         });

         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
         function EndRequestHandler(sender, args) {
             //Binding Code Again
             $(<%=toccc.ClientID%>).select2({ placeholder: 'Select Employee Email' });
        }
    </script>

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
            <h3>Sales Inquiry Assignment</h3>
        </div>
    </div>
    <!-- /page header -->

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Sales Inquiry Assignment (New)</h6>
        </div>

        <div class="datatable">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="hai_RowDataBound" OnSelectedIndexChanged="hai_SelectedIndexChanged" AutoGenerateSelectButton="true">
                <Columns>
                    <asp:BoundField DataField="ENQ_ID" HeaderText="Sl.No" SortExpression="ENQ_ID"></asp:BoundField>
                    <asp:BoundField DataField="enno" HeaderText="Enq No" SortExpression="enno"></asp:BoundField>

                    <asp:BoundField DataField="ENQ_DATE" HeaderText="Date" SortExpression="ENQ_DATE" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>

                    <asp:BoundField DataField="CUST_NAME" HeaderText="Customer" SortExpression="CUST_NAME"></asp:BoundField>
                    <asp:BoundField DataField="CUST_ADDRESS" HeaderText="Address" SortExpression="CUST_ADDRESS"></asp:BoundField>

                    <asp:TemplateField HeaderText="Sales Attachments" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">

                                <asp:LinkButton ID="lbtnfloorplans" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Sales/BoQFloorPlans.aspx?Cid=" + Eval("ENQ_ID") %>'>
                                    <i class="icon-attachment"></i>
                                    <strong class="label label-danger">
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Cou") %>'></asp:Label></strong>
                                </asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="STATUS" HeaderText="Status" SortExpression="STATUS"></asp:BoundField>

                    <asp:TemplateField HeaderText="Design Assigned to">
                        <ItemTemplate>
                            <asp:Label ID="lbldesigner" CssClass="" runat="server" Text='<%# Eval("DESIGNINCHARGE_ID") %>' Visible="false" />
                            <asp:DropDownList ID="ddldesigner" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Design Status">
                        <ItemTemplate>

                            <asp:Label ID="lbldesignerstatus" runat="server" Text='<%# Eval("DesignerStatus") %>' Visible="false" />
                            <asp:DropDownList ID="ddldesignStatus" CssClass="select-full" Width="100%" runat="server">

                                <asp:ListItem Value="NotStarted">Not Started</asp:ListItem>
                                <asp:ListItem Value="Progress">In Progress</asp:ListItem>
                                <asp:ListItem Value="Completed">Completed</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Designer Attach" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnelvation" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Sales/BoQElevationDrawings.aspx?Cid=" + Eval("ENQ_ID") %>'>
                                    <i class="icon-attachment"></i><strong class="label label-primary">
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("ele") %>'></asp:Label></strong>
                                </asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estimation Assigned to">
                        <ItemTemplate>

                            <asp:Label ID="lblestimation" runat="server" Text='<%# Eval("EstimatationInchargeId") %>' Visible="false" />
                            <asp:DropDownList ID="ddlestimation" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estimation Status">
                        <ItemTemplate>
                            <asp:Label ID="lblestimationstatus" runat="server" Text='<%# Eval("EstimationStatus") %>' Visible="false" />
                            <asp:DropDownList ID="ddlestimationStatus" CssClass="select-full" Width="100%" runat="server">

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
                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CssClass="btn btn-icon btn-danger"><i class="icon-upload"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="DESIGNINCHARGE_ID" HeaderText="DESIGNINCHARGE_ID" SortExpression="DESIGNINCHARGE_ID"></asp:BoundField>
                    <asp:BoundField DataField="DesignerStatus" HeaderText="DesignerStatus" SortExpression="DesignerStatus"></asp:BoundField>

                    <asp:BoundField DataField="EstimatationInchargeId" HeaderText="EstimatationInchargeId" SortExpression="EstimatationInchargeId"></asp:BoundField>
                    <asp:BoundField DataField="EstimationStatus" HeaderText="EstimationStatus" SortExpression="EstimationStatus"></asp:BoundField>

                    <asp:BoundField DataField="empname" HeaderText="Sales Person" SortExpression="empname"></asp:BoundField>

                    <%--                     <asp:TemplateField HeaderText="Pay">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Pay Now" CssClass="btn btn-info"
                            OnClick="Display"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>

            <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT EstimatationInchargeId,EstimationStatus,DesignerStatus,DESIGNINCHARGE_ID,TODISCUSS,SalesEnquiry_Master.ENQ_ID, SalesEnquiry_Master.ENQ_NO, SalesEnquiry_Master.ENQ_DATE, SalesEnquiry_Master.CUST_ID, SalesEnquiry_Master.UNIT_ID, SalesEnquiry_Master.SLAESINCHARGE_ID, SalesEnquiry_Master.DESIGNINCHARGE_ID, SalesEnquiry_Master.PREPAREDBY, SalesEnquiry_Master.APPROVEDBY, SalesEnquiry_Master.REVISEDKEY, SalesEnquiry_Master.STATUS, Customer_Master.CUST_NAME, Customer_Units.CUST_UNIT_NAME FROM Customer_Master INNER JOIN SalesEnquiry_Master ON Customer_Master.CUST_ID = SalesEnquiry_Master.CUST_ID INNER JOIN Customer_Units ON SalesEnquiry_Master.UNIT_ID = Customer_Units.CUST_UNIT_ID"></asp:SqlDataSource>
            --%>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select *,
Cou = (select count(*) from Enquiry_FloorPlanDetails where Enquiry_FloorPlanDetails.ENQ_ID = SalesEnquiry_Master.ENQ_ID ),
ele = (select count(*) from Enquiry_ElevationDetails where Enquiry_ElevationDetails.ENQ_ID = SalesEnquiry_Master.ENQ_ID ),
ENQ_NO+' '+REVISEDKEY as enno ,
EMP_FIRST_NAME+''+EMP_LAST_NAME as empname
from SalesEnquiry_Master,Customer_Master,Employee_Master
where SalesEnquiry_Master.CUST_ID = Customer_Master.CUST_ID
and SalesEnquiry_Master.SLAESINCHARGE_ID = Employee_Master.EMP_ID
and SalesEnquiry_Master.STATUS = 'New'
order by ENQ_ID desc"></asp:SqlDataSource>

            <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
        </div>
    </div>

    <div id="myModal1" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Enquiry Details</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="Panel1" runat="server">

                        <div class="form-horizontal">
                            <div class="panel panel-default">
                                <div class="panel-body">

                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h3 class="panel-title">Email </h3>
                                        </div>
                                        <div class="panel-body">
                                            <div class="form-group">

                                                <label class="col-sm-2 control-label text-right">Enq No:</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtenqno" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <label class="col-sm-2 control-label text-right">Enq Date :</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtenqdate" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">

                                                <label class="col-sm-2 control-label text-right">Cust Name:</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtCustname" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <label class="col-sm-2 control-label text-right">Cust Address :</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtCustaddress" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                              <div class="form-group">

                                                <label class="col-sm-2 control-label text-right">Design Assigned to:</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtdesignedassigned" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <label class="col-sm-2 control-label text-right">Estimation Assigned to :</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtestimationassigned" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                             <div class="form-group">

                                                <label class="col-sm-2 control-label text-right">Sales Person:</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtSalesperson" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                              
                                            </div>

                                             <div class="form-group">

                                                <label class="col-sm-2 control-label text-right">Subject:</label>
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtsub" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                               
                                            </div>

                                              <div class="form-group">

                                                <label class="col-sm-2 control-label text-right">To:</label>
                                                <div class="col-sm-10">
                                                    <select id="Books" style="width: 100%" runat="server"></select>

                                                        <asp:SqlDataSource ID="usersds1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT [EMP_ID], [EMP_EMAIL] FROM [Employee_master] where emp_email not in ('0','-',' ')  ORDER BY [EMP_ID]"></asp:SqlDataSource>
                                                        <asp:HiddenField ID="hffromuid1" runat="server" />

                                                        <script>
                                                            $(document).ready(function () {
                                                                $("#Books").select2({ placeholder: 'Select Employee EmailId' });
                                                            });
                                                        </script>
                                                       <asp:TextBox  ID="txtBCC" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                    
                                                </div>
                                               
                                            </div>
                                             <%--<div class="form-group">

                                                <label class="col-sm-2 control-label text-right">To:</label>
                                                <div class="col-sm-10">
                                                             </div>
                                               
                                            </div>--%>
                                              <div class="form-group">

                                                <label class="col-sm-2 control-label text-right">CC:</label>
                                                <div class="col-sm-10">
                                                   <select id="toccc" style="width: 100%" runat="server"></select>

                                                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT [EMP_ID], [EMP_EMAIL] FROM [Employee_master] where emp_email not in ('0','-',' ') ORDER BY [EMP_ID]"></asp:SqlDataSource>
                                                        <asp:HiddenField ID="HiddenField2" runat="server" />

                                                        <script>
                                                            $(document).ready(function () {
                                                                $("#toccc").select2({ placeholder: 'Select Employee Emailid' });
                                                            });
                                                        </script>                                                </div>
                                               
                                            </div>

                                              <div class="form-group">

                                                <label class="col-sm-2 control-label text-right">Message:</label>
                                                <div class="col-sm-10">
                                                           <asp:TextBox ID="txtmsg" runat="server" CssClass="form-control" ></asp:TextBox>
                                                          <cc1:HtmlEditorExtender ID="HtmlEditorExtender4"  TargetControlID="txtmsg" EnableSanitization="false" DisplaySourceTab="false" runat="server" />
                                                 </div>
                                               
                                            </div>



                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <div class="modal-footer">

                    <asp:Button ID="Button1" runat="server" Text="Send" BackColor="#999966" OnClick="Button1_Click" />
                    <asp:Button ID="Button3" runat="server" Text="Reset" BackColor="#999966" OnClick="btnreset_Click" /><br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" ForeColor="Green"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Sales Inquiry Assignment (Close)</h6>
        </div>

        <div class="datatable">

            <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ENQ_ID" HeaderText="Sl.No" SortExpression="ENQ_ID"></asp:BoundField>
                    <asp:BoundField DataField="enno" HeaderText="Enq No" SortExpression="enno"></asp:BoundField>

                    <asp:BoundField DataField="ENQ_DATE" HeaderText="Date" SortExpression="ENQ_DATE" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>

                    <asp:BoundField DataField="CUST_NAME" HeaderText="Customer" SortExpression="CUST_NAME"></asp:BoundField>
                    <asp:BoundField DataField="CUST_ADDRESS" HeaderText="Address" SortExpression="CUST_ADDRESS"></asp:BoundField>

                    <asp:TemplateField HeaderText="Sales Attachments" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">

                                <asp:LinkButton ID="lbtnfloorplans" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Sales/BoQFloorPlans.aspx?Cid=" + Eval("ENQ_ID") %>'>
                                    <i class="icon-attachment"></i>
                                    <strong class="label label-danger">
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Cou") %>'></asp:Label></strong>
                                </asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="STATUS" HeaderText="Status" SortExpression="STATUS"></asp:BoundField>

                    <asp:TemplateField HeaderText="Design Assigned to">
                        <ItemTemplate>
                            <asp:Label ID="lbldesigner" CssClass="" runat="server" Text='<%# Eval("DESIGNINCHARGE_ID") %>' Visible="false" />
                            <asp:DropDownList ID="ddldesigner" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Design Status">
                        <ItemTemplate>

                            <asp:Label ID="lbldesignerstatus" runat="server" Text='<%# Eval("DesignerStatus") %>' Visible="false" />
                            <asp:DropDownList ID="ddldesignStatus" CssClass="select-full" Width="100%" runat="server">

                                <asp:ListItem Value="NotStarted">Not Started</asp:ListItem>
                                <asp:ListItem Value="Progress">In Progress</asp:ListItem>
                                <asp:ListItem Value="Completed">Completed</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Designer Attach" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnelvation" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Sales/BoQElevationDrawings.aspx?Cid=" + Eval("ENQ_ID") %>'>
                                    <i class="icon-attachment"></i><strong class="label label-primary">
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("ele") %>'></asp:Label></strong>
                                </asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estimation Assigned to">
                        <ItemTemplate>

                            <asp:Label ID="lblestimation" runat="server" Text='<%# Eval("EstimatationInchargeId") %>' Visible="false" />
                            <asp:DropDownList ID="ddlestimation" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estimation Status">
                        <ItemTemplate>
                            <asp:Label ID="lblestimationstatus" runat="server" Text='<%# Eval("EstimationStatus") %>' Visible="false" />
                            <asp:DropDownList ID="ddlestimationStatus" CssClass="select-full" Width="100%" runat="server">

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
                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CssClass="btn btn-icon btn-danger"><i class="icon-upload"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="DESIGNINCHARGE_ID" HeaderText="DESIGNINCHARGE_ID" SortExpression="DESIGNINCHARGE_ID"></asp:BoundField>
                    <asp:BoundField DataField="DesignerStatus" HeaderText="DesignerStatus" SortExpression="DesignerStatus"></asp:BoundField>

                    <asp:BoundField DataField="EstimatationInchargeId" HeaderText="EstimatationInchargeId" SortExpression="EstimatationInchargeId"></asp:BoundField>
                    <asp:BoundField DataField="EstimationStatus" HeaderText="EstimationStatus" SortExpression="EstimationStatus"></asp:BoundField>

                    <asp:BoundField DataField="empname" HeaderText="Sales Person" SortExpression="empname"></asp:BoundField>

                    <%--                     <asp:TemplateField HeaderText="Pay">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Pay Now" CssClass="btn btn-info"
                            OnClick="Display"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>

            <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT EstimatationInchargeId,EstimationStatus,DesignerStatus,DESIGNINCHARGE_ID,TODISCUSS,SalesEnquiry_Master.ENQ_ID, SalesEnquiry_Master.ENQ_NO, SalesEnquiry_Master.ENQ_DATE, SalesEnquiry_Master.CUST_ID, SalesEnquiry_Master.UNIT_ID, SalesEnquiry_Master.SLAESINCHARGE_ID, SalesEnquiry_Master.DESIGNINCHARGE_ID, SalesEnquiry_Master.PREPAREDBY, SalesEnquiry_Master.APPROVEDBY, SalesEnquiry_Master.REVISEDKEY, SalesEnquiry_Master.STATUS, Customer_Master.CUST_NAME, Customer_Units.CUST_UNIT_NAME FROM Customer_Master INNER JOIN SalesEnquiry_Master ON Customer_Master.CUST_ID = SalesEnquiry_Master.CUST_ID INNER JOIN Customer_Units ON SalesEnquiry_Master.UNIT_ID = Customer_Units.CUST_UNIT_ID"></asp:SqlDataSource>
            --%>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select *,
Cou = (select count(*) from Enquiry_FloorPlanDetails where Enquiry_FloorPlanDetails.ENQ_ID = SalesEnquiry_Master.ENQ_ID ),
ele = (select count(*) from Enquiry_ElevationDetails where Enquiry_ElevationDetails.ENQ_ID = SalesEnquiry_Master.ENQ_ID ),
ENQ_NO+' '+REVISEDKEY as enno ,
EMP_FIRST_NAME+''+EMP_LAST_NAME as empname
from SalesEnquiry_Master,Customer_Master,Employee_Master
where SalesEnquiry_Master.CUST_ID = Customer_Master.CUST_ID
and SalesEnquiry_Master.SLAESINCHARGE_ID = Employee_Master.EMP_ID
and SalesEnquiry_Master.STATUS = 'Close'
order by ENQ_ID desc"></asp:SqlDataSource>

            <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="Label4" runat="server" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>