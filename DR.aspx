<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DR.aspx.cs" Inherits="DR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Daily Report</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1, maximum-scale=1" />
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
     <link href="/css/londinium-theme.css" rel="stylesheet" type="text/css" />
    <link href="/css/styles.css" rel="stylesheet" type="text/css" />
    <link href="/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="/css/select2.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
             <ControlBundles>
             <cc1:ControlBundle Name="Group2" />
             </ControlBundles>
         </cc1:ToolkitScriptManager>
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
    <div>
    <asp:UpdatePanel ID="UpdatePanel34" runat="server">
        <ContentTemplate>


            <div class="panel panel-danger">

                    <div class="page-header">
                <div class="page-title">
                    <h3>Daily Report </h3>
                </div>
            </div>

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="DR.aspx">Daily Report</a></li>
                    <li><a href="DrDetails.aspx">Daily Details</a></li>



                    <li class="active"><a href="~/MobileLogin.aspx" runat="server"><i class="icon-exit"></i>Logout</a></li>
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
                                <asp:TextBox ID="txtDateTime" runat="server" CssClass="form-control" ></asp:TextBox>

                                    <asp:Image
                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
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

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Purpose :</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtPurpose" TextMode="MultiLine" onkeypress="return check(event)" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Remarks :</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtRemarks" TextMode="MultiLine" onkeypress="return check(event)" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Attended By :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlAttendedBy"  Enabled="false" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">

                            <div class="form-actions col-sm-offset-10">

                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-lg btn-danger " OnClick="btnSave_Click" Text="Save" />
                            </div>
                        </div>




                         <div class="panel panel-default" runat ="server" visible ="false"  >
                <div class="panel-heading">
                    <h6 class="panel-title">Daily Report Details</h6>
                </div>
                <div class="panel-body">

                      <div class="form-group">
                            <label class="col-sm-2 control-label text-right">From Date :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtFromDate" runat ="server" CssClass="form-control" type="datepic"></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">To Date :</label>
                            <div class="col-sm-4">
                                  <asp:TextBox ID="txtToDate" runat ="server" CssClass="form-control" type="datepic"></asp:TextBox>
                            </div>
                        </div>



                     <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Client Name :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtClientName" runat ="server" CssClass="form-control" ></asp:TextBox>
                            </div>

                            <label class="col-sm-2 control-label text-right">Executive Name :</label>
                            <div class="col-sm-4">
                                  <asp:DropDownList ID="ddlSalesPerson"  runat="server" CssClass ="form-control"></asp:DropDownList>
                    </div>
                            </div>

                       <div class="form-group">

                            <div class="form-actions col-sm-offset-6">
                                  <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" CausesValidation="False" />
                                  <asp:Button ID="btnDelete" runat="server" CssClass="btn  btn-danger" Text="Delete" OnClick="btnDelete_Click" Visible ="false"  CausesValidation="False" />
                            </div>
                        </div>


                    <div class="form-group">
                        <div>
                            <asp:GridView ID="gvDrs" CssClass="table table-bordered" Width="100%" runat="server"  EmptyDataText="No Records To Display" AllowPaging="True" OnPageIndexChanging="gvDrs_PageIndexChanging" PageSize="8" AutoGenerateColumns="False" OnRowDataBound="gvDrs_RowDataBound">
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
                            
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Wrap="true" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Reference" HeaderText="Reference" SortExpression="Reference">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Architect" HeaderText="Architect" SortExpression="Architect">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-Wrap="false" SortExpression="Address">
                            
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Purpose" HeaderText="Purpose" ItemStyle-Wrap="false" SortExpression="Purpose">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Remarks" HeaderText="Remarks"  ItemStyle-Wrap="false" SortExpression="Remarks">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Attended By" HeaderText="Attended By" SortExpression="Attended By" ItemStyle-Wrap="false">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                        </asp:BoundField>

                    <%--    <asp:BoundField DataField="Executive Name" HeaderText="Executive Name" SortExpression="Executive Name" ItemStyle-Wrap="false">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Comments">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtComment" TextMode="SingleLine" Width="150px" Text='<%#Eval("Comments")%>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        <asp:BoundField DataField ="DAILYREPORTID" HeaderText ="Id" />
                        <asp:TemplateField HeaderText="FileName" >
                                                <ItemTemplate>
                                                    <asp:Image runat ="server" EnableTheming="False"  ImageUrl = '<%# Eval("FileName","http://183.82.108.55/YANTRA_DOCUMENTS/SOFiles/{0}") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                                    <asp:Label ID="lblDeptId" runat ="server" Visible ="false" ></asp:Label>
                                    <asp:Label ID="lblDeptHead" runat ="server" Visible ="false"  ></asp:Label>
                                    <asp:Label ID="lblDeptHeadId" runat ="server" Visible ="false" ></asp:Label>


            </div>





                    </div>
                </div>
            </div>


            </div>


        
        
        
        
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
