<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrDocs.aspx.cs" Inherits="DrDocs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Daily Report Docs</title>
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
            <div class="page-header">
                <div class="page-title">
                    <h3>Daily Report Documents</h3>
                </div>
            </div>

            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="DR.aspx">Daily Report</a></li>
                    <li><a href="DrDetails.aspx">Daily Details</a></li>

                    

                    <li class="active"><a href="~/MobileLogin.aspx" runat="server"><i class="icon-exit"></i>Logout</a></li>
                </ul>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Daily Report</h6>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <asp:Label ID="lbldailyreportId" Visible="false" runat="server" Text="Label"></asp:Label>
                                                           </div>
                            <div class="col-md-5">
                                <label>Daily Report Date:  </label>
                                <asp:TextBox ID="txtQuatationDate" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                    </div>


                     <div class="form-group">
                        <div class="row">
                            <div class="col-md-2">Purpose</div>
                            <div class="col-md-10">
                                <asp:Label ID="lblPurpose"  runat="server" Text=""></asp:Label>
                                                           </div>
                           
                        </div>
                    </div>



                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <label>Document Received Date:  </label>
                                <asp:TextBox ID="txtReceiveddate" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:Image
                                    ID="Image2" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender3" runat="server" PopupButtonID="Image2"
                                    TargetControlID="txtReceiveddate">
                                </cc1:CalendarExtender>
                            </div>

                            <div class="col-md-5">
                                <label>Upload Document:  </label>
                                <asp:FileUpload ID="FileUpload1" AllowMultiple="true" type="file"  CssClass="styled form-control" runat="server" />
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-10">
                                <label>Remarks :  </label>
                                <asp:TextBox ID="txtremarks" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-10">
                                <div class="form-actions text-right">
                                    <asp:Button ID="btnsubmitElevationdrawing" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnsubmitElevationdrawing_Click" />
                                </div>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                    </div>

                    <div class="form-group">

                        <div class="datatable-tasks">

                            <asp:GridView ID="gvElevationDrawings" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False">
                                <Columns>

                                    <asp:BoundField DataField="DA_Doc_Id" HeaderText="Sl.No" SortExpression="DA_Doc_Id">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="DA_Doc_Date" HeaderText="Received Date" SortExpression="DA_Doc_Date" DataFormatString="{0:dd/MM/yyyy}">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="DA_Remarks" HeaderText="Remarks" SortExpression="DA_Remarks">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>


                                   <asp:TemplateField HeaderText="Image">

                      <ItemTemplate >

                        <asp:Image ID="Image1" runat="server" ImageUrl ='<%# "~/Content/DailyReports/" + Eval("DA_Documents") %>' height="120px" Width="150px" />

                      </ItemTemplate>

                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <span class="text-center">
                                                <asp:HyperLink ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" Target="_blank" NavigateUrl='<%# "~/Content/DailyReports/" + Eval("DA_Documents") %>'><i class="icon-attachment"></i></asp:HyperLink>
                                            </span>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <span class="text-center">
                                                <asp:LinkButton ID="lbtnElevationDelete" runat="server" CssClass="btn btn-icon btn-danger" OnClick="lbtnElevationDelete_Click"><i class="icon-remove3"></i></asp:LinkButton>
                                            </span>
                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <span style="color: #FF0000">No Data Found</span>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="btnsubmitElevationdrawing" />
        </Triggers>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
