<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="DyReport.aspx.cs" Inherits="Modules_Sales_DyReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
        <ContentTemplate>


    <script type="text/javascript">
        $(document).ready(function () {
            //fnPageLoad();
        });
        function fnPageLoad() {
            $('#<%=gvDrs.ClientID%>').prepend($("<thead></thead>").append($('#<%=gvDrs.ClientID%>').find("tr:first"))).DataTable({

                        bSort: true,
                        dom: '<"html5buttons"B>lTfgitp',
                        //lengthChange: false,
                        pageLength: 10,

                        bStateSave: true,
                        order: [[0, 'desc']],
                    });
                }
            </script>



            <div class="page-header">
                <div class="page-title">
                    <h3>Daily Report </h3>
                </div>
            </div>

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="DR.aspx">Daily Report</a></li>
                    <li class="active"><a href="ToDoList.aspx">To Do List</a></li>
                </ul>
            </div>
            
            <div class="form-horizontal">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h6 class="panel-title">Daily Report Details</h6>
                    </div>
                    <div class="panel-body">

                       <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Date & Time :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtDateTime" runat="server" CssClass="form-control"></asp:TextBox>

                                 <asp:Image
                                    ID="Image2" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender3" runat="server" PopupButtonID="Image2"  PopupPosition="TopRight"
                                    TargetControlID="txtDateTime">
                                </cc1:CalendarExtender>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">In Time :</label>
                            <div class="col-sm-4">
                                <table style="width: 64px">
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:DropDownList
                                                ID="ddlHour" runat="server" CssClass="form-control" TabIndex="3" Width="60px" EnableTheming="False">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>11</asp:ListItem>
                                                <asp:ListItem>12</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlMin" runat="server" CssClass="form-control" TabIndex="4" Width="60px" EnableTheming="False">
                                                <asp:ListItem>00</asp:ListItem>
                                                <asp:ListItem>05</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                                <asp:ListItem>25</asp:ListItem>
                                                <asp:ListItem>30</asp:ListItem>
                                                <asp:ListItem>35</asp:ListItem>
                                                <asp:ListItem>40</asp:ListItem>
                                                <asp:ListItem>45</asp:ListItem>
                                                <asp:ListItem>50</asp:ListItem>
                                                <asp:ListItem>55</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlAMPM" runat="server" CssClass="form-control" TabIndex="5" Width="60px" EnableTheming="False">
                                                <asp:ListItem>AM</asp:ListItem>
                                                <asp:ListItem>PM</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>
                            </div>

                            <label class="col-sm-2 control-label text-right">Out Time :</label>
                            <div class="col-sm-4">
                                <table style="width: 64px; height: 32px;">
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:DropDownList
                                                ID="ddlOutHour" runat="server" CssClass="form-control" TabIndex="3" Width="60px" EnableTheming="False">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>11</asp:ListItem>
                                                <asp:ListItem>12</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlOutMin" runat="server" CssClass="form-control" TabIndex="4" Width="60px" EnableTheming="False">
                                                <asp:ListItem>00</asp:ListItem>
                                                <asp:ListItem>05</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                                <asp:ListItem>25</asp:ListItem>
                                                <asp:ListItem>30</asp:ListItem>
                                                <asp:ListItem>35</asp:ListItem>
                                                <asp:ListItem>40</asp:ListItem>
                                                <asp:ListItem>45</asp:ListItem>
                                                <asp:ListItem>50</asp:ListItem>
                                                <asp:ListItem>55</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 100px">
                                            <asp:DropDownList ID="ddlOutAMPM" runat="server" CssClass="form-control" TabIndex="5" Width="60px" EnableTheming="False">
                                                <asp:ListItem>AM</asp:ListItem>
                                                <asp:ListItem>PM</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>
                            </div>
                        </div>



                         

                        <div runat="server" id="hide" visible="false">

                            <div class="form-group">
                                <label class="col-sm-2 control-label text-right">Client's Name :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtClientsName" onkeypress="return check(event)" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <label class="col-sm-2 control-label text-right">Mobile No :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label text-right">Reference :</label>
                                <div class="col-sm-4">
                                    <asp:DropDownList runat="server" ID="txtReference" CssClass="form-control">
                                        <asp:ListItem>Executive</asp:ListItem>
                                        <asp:ListItem>Walk-In</asp:ListItem>
                                        <asp:ListItem>Architect</asp:ListItem>
                                        <asp:ListItem>Web Site</asp:ListItem>
                                        <asp:ListItem>Exhibition</asp:ListItem>
                                        <asp:ListItem>Existing Customer</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <label class="col-sm-2 control-label text-right">Architect/Executive Name :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtArchitect" onkeypress="return check(event)" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label text-right">Address :</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" onkeypress="return check(event)" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Purpose :</label>
                            <div class="col-sm-10">

                                <asp:TextBox ID="txtPurpose" CssClass="form-control"  TextMode="MultiLine" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPurpose" runat="server" ErrorMessage="Please Enter Purpose"></asp:RequiredFieldValidator>

                          <%--      <cc1:HtmlEditorExtender
                                    ID="HtmlEditorExtender5" TargetControlID="txtPurpose" EnableSanitization="false" DisplaySourceTab="true"
                                    runat="server" />--%>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Remarks :</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtRemarks" TextMode="MultiLine" onkeypress="return check(event)" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>


                         <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Documents :</label>
                            <div class="col-sm-10">
                              <asp:FileUpload ID="FileUpload1" type="file" CssClass="styled form-control" runat="server" />
                            </div>
                        </div>



                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Attended By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlAttendedBy" Enabled="false" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">

                            <div class="form-actions col-sm-offset-10">

                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-danger " OnClick="btnSave_Click" Text="Save" />
                            </div>
                        </div>

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h6 class="panel-title">Daily Report Details</h6>
                            </div>
                            <div class="panel-body">

                                <div id="tblsearch" runat="server" visible="false">

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">From Date :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" type="datepic"></asp:TextBox>
                                    </div>

                                    <label class="col-sm-2 control-label text-right">To Date :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" type="datepic"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Client Name :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtClientName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <label class="col-sm-2 control-label text-right">Executive Name :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>


                                    </div>

                                <div class="form-group">

                                    <div class="form-actions col-sm-offset-6">
                                        <asp:Button ID="btnSearch" runat="server" Visible="false" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" CausesValidation="False" />
                                        <asp:Button ID="btnDelete" runat="server" CssClass="btn  btn-danger" Text="Delete" OnClick="btnDelete_Click" Visible="false" CausesValidation="False" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div>
                                        <asp:GridView ID="gvDrs" CssClass="table table-bordered" Width="100%" runat="server" EmptyDataText="No Records To Display" AllowPaging="True" OnPageIndexChanging="gvDrs_PageIndexChanging" PageSize="8" AutoGenerateColumns="False" OnRowDataBound="gvDrs_RowDataBound">
                                            <Columns>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkhdr" runat="server" AutoPostBack="True" OnClick="selectAll(this)" />
                                                    </HeaderTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="Chk" OnCheckedChanged="Chk_CheckedChanged" AutoPostBack="true" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Form Id" SortExpression="DAILYREPORTID" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblId" Text='<%#Eval("DAILYREPORTID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="In Time" HeaderText="In Time" SortExpression="In Time">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Out Time" HeaderText="Out TIME" SortExpression="Out Time">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Client Name" HeaderText="Client" SortExpression="Client Name" ItemStyle-Wrap="false">

                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Reference" HeaderText="Reference" SortExpression="Reference">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Architect" HeaderText="Architect" SortExpression="Architect">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-Wrap="false" SortExpression="Address">

                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Purpose" SortExpression="Purpose">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuestion" runat="server" Text='<%# Server.HtmlDecode(Eval("Purpose").ToString()) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="100%" />
                                                </asp:TemplateField>

                                                <%--  <asp:BoundField DataField="Purpose" HeaderText="Purpose" ItemStyle-Wrap="false" SortExpression="Purpose">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:BoundField>--%>

                                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-Wrap="false" SortExpression="Remarks">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Attended By" HeaderText="Attended By" SortExpression="Attended By" ItemStyle-Wrap="false">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:BoundField>

                                                <%--    <asp:BoundField DataField="Executive Name" HeaderText="Executive Name" SortExpression="Executive Name" ItemStyle-Wrap="false">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                        </asp:BoundField>--%>
                                                <asp:TemplateField HeaderText="Comments">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtComment" TextMode="SingleLine" Width="150px" Text='<%#Eval("Comments")%>' runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DAILYREPORTID" HeaderText="Id" />
                                                <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Sales/DailyReportDocs.aspx?Cid=" + Eval("DAILYREPORTID") %>'><i class="icon-attachment"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>





                                               <%-- <asp:TemplateField HeaderText="Files">
                                                    <ItemTemplate>
                                                    
                                                         <asp:HyperLink ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" Target="_blank" NavigateUrl='<%# "~/Content/DailyReports/" + Eval("FileName") %>'><i class="icon-attachment"></i></asp:HyperLink>

                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="Silver"></SelectedRowStyle>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="lables">
                            <asp:Label ID="lblUserType" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblEmpIdHidden" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblDeptId" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblDeptHead" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblDeptHeadId" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            
        </ContentTemplate>
         <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
            
            

            <script lang="javascript" type="text/javascript">
                function check(e) {
                    var keynum
                    var keychar
                    var numcheck
                    // For Internet Explorer
                    if (window.event) {
                        keynum = e.keyCode;
                    }
                        // For Netscape/Firefox/Opera
                    else if (e.which) {
                        keynum = e.which;
                    }
                    keychar = String.fromCharCode(keynum);
                    //List of special characters you want to restrict
                    if (keychar == "'" || keychar == "`" || keychar == "&" || keychar == "¬" || keychar == '"') {
                        return false;
                    } else {
                        return true;
                    }
                }
            </script>






</asp:Content>
