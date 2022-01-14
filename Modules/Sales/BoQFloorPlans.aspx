<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="BoQFloorPlans.aspx.cs" Inherits="Modules_Sales_BoQFloorPlans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


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
 <%--<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>--%>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
        <ContentTemplate>
     
            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>BOQ Information</h3>
                </div>
            </div>

            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="SalesEnquiry.aspx">Sales Enquiry</a></li>
                    <li class="active">BOQ Information</li>
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
                                <asp:DropDownList ID="ddlEnquiryNo" Enabled="false" Width="100%"  CssClass="select-full"  runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-5">
                                <label>Enquiry Date:  </label>
                                <asp:TextBox ID="txtenquirydate" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                    </div>
                </div>
            </div>

        



        





          <%--  Floor Plan --%>


            <div class="panel panel-default">
                 <div class="panel-heading">
                    <h6 class="panel-title">Floor Plan </h6>
                </div>
                <div class="panel-body">

                      <div class="form-group">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>FloorPlan Received Date:  </label>
                                        <asp:TextBox ID="txtfloorplanreceiveddate"  CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                                            TargetControlID="txtfloorplanreceiveddate">
                                        </cc1:CalendarExtender>
                                    </div>

                                    <div class="col-md-6">
                                        <label>FloorPlan Document:  </label>
                                        <asp:FileUpload ID="FileUpload2" AllowMultiple="true" CssClass="styled form-control" runat="server" />
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Remarks :  </label>
                                        <asp:TextBox ID="txtfloorplanremarks" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions text-right">
                                <asp:Button ID="btnfloorplansubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnfloorplansubmit_Click" />
                            </div>

                </div>



            </div>


             <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title">FloorPlan Details Received</h6>
        </div>
        <div class="panel-body">
            <div class="">
                <asp:GridView ID="gvFloorPlan" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False">
                                    <Columns>

                                        <asp:BoundField DataField="FLOORPLAN_ENQID" HeaderText="Sl.No" SortExpression="FLOORPLAN_ENQID">
                                            <HeaderStyle Font-Size="Smaller" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="FLOORPLAN_RECEIVEDDATE" HeaderText="Received Date" SortExpression="FLOORPLAN_RECEIVEDDATE" DataFormatString="{0:dd/MM/yyyy}">
                                            <HeaderStyle Font-Size="Smaller" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="FLOORPLAN_REMARKS" HeaderText="Remarks" SortExpression="FLOORPLAN_REMARKS">
                                            <HeaderStyle Font-Size="Smaller" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <span class="text-center">
                                                    <asp:HyperLink ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" Target="_blank" NavigateUrl='<%# "~/Content/FloorPlanDrawings/" + Eval("FLOORPLAN_DOCUMENTS") %>'><i class="icon-attachment"></i></asp:HyperLink>
                                                </span>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <span class="text-center">
                                                    <asp:LinkButton ID="lbtnFloorDetails" runat="server" CssClass="btn btn-icon btn-danger" OnClick="lbtnFloorDetails_Click"><i class="icon-remove3"></i></asp:LinkButton>
                                                </span>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>


                </div></div></div>


        </ContentTemplate>
        <Triggers>
           
            <asp:PostBackTrigger ControlID="btnfloorplansubmit" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>