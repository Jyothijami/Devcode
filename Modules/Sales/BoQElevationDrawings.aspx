<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="BoQElevationDrawings.aspx.cs" Inherits="Modules_Sales_BoQElevationDrawings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<%--<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>--%>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
    <asp:UpdatePanel ID="UpdatePanel341" runat="server">
        <ContentTemplate>

     <script type="text/javascript">
         function hi() {
             // event.preventDefault();
             swal({
                 title: 'System Meassage',
                 text: "Data Submitted Sucessfully",
                 type: 'success',
                 confirmButtonColor: '#3085d6',
                 confirmButtonText: 'Ok'
             })
             .then(function () {
                 // Set data-confirmed attribute to indicate that the action was confirmed
                 window.location = 'SalesEnquiry.aspx';
             }).catch(function (reason) {
                 // The action was canceled by the user
             });

         }
    </script>



            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Elevation Drawings</h3>
                </div>
            </div>

            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="SalesEnquiry.aspx">Sales Enquiry</a></li>
                    <li class="active">Elevation Information</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Enquiry Details</h6>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <label>Enquiry No:  </label>
                                <asp:DropDownList ID="ddlEnquiryNo" Enabled="false" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlEnquiryNo_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-5">
                                <label>Enquiry Date:  </label>
                                <asp:TextBox ID="txtenquirydate" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                    </div>
                </div>
            </div>

        



         




            <%-- Elevation Drawings --%>


            <div class="panel panel-default">
                 <div class="panel-heading">
                    <h6 class="panel-title">Elevation Drawings </h6>
                </div>
                <div class="panel-body">

                      <div class="form-group">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Drawings Received Date:  </label>
                                        <asp:TextBox ID="txtElevationreceiveddate" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="Image2" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender3" runat="server" PopupButtonID="Image2"
                                            TargetControlID="txtElevationreceiveddate">
                                        </cc1:CalendarExtender>
                                    </div>

                                    <div class="col-md-6">
                                        <label>Drawings Document:  </label>
                                        <asp:FileUpload ID="FileUpload1" type="file" AllowMultiple="true" CssClass="styled form-control" runat="server" />
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Remarks :  </label>
                                        <asp:TextBox ID="txtElevationremarks" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-actions text-right">
                                <asp:Button ID="btnsubmitElevationdrawing" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnsubmitElevationdrawing_Click" />
                            </div>

                   
                </div>


            </div>






       <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title">Elevations Details Received</h6>
        </div>
        <div class="panel-body">
            <div class="datatable-tasks">
                <asp:GridView ID="gvElevationDrawings" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False">
                                    <Columns>

                                        <asp:BoundField DataField="ELEVATION_ENQID" HeaderText="Sl.No" SortExpression="ELEVATION_ENQID">
                                            <HeaderStyle Font-Size="Smaller" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="ELEVATION_RECEIVEDDATE" HeaderText="Received Date" SortExpression="ELEVATION_RECEIVEDDATE" DataFormatString="{0:dd/MM/yyyy}">
                                            <HeaderStyle Font-Size="Smaller" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="ELEVATION_REMARKS" HeaderText="Remarks" SortExpression="ELEVATION_REMARKS">
                                            <HeaderStyle Font-Size="Smaller" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <span class="text-center">
                                                    <asp:HyperLink ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" Target="_blank" NavigateUrl='<%# "~/Content/ElevationDrawings/" + Eval("ELEVATION_DOCUMENTS") %>'><i class="icon-attachment"></i></asp:HyperLink>
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

                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                </div>
            </div></div>


        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnsubmitElevationdrawing" />
           
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>