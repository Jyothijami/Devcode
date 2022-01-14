﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="BOQInfo - Copy.aspx.cs" Inherits="Modules_Sales_BOQInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                <asp:DropDownList ID="ddlEnquiryNo" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlEnquiryNo_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-5">
                                <label>Enquiry Date:  </label>
                                <asp:TextBox ID="txtenquirydate" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Default pills -->
            <span class="subtitle">BoQ Info</span>
            <div class="well block">
                <div class="tabbable">
                    <ul class="nav nav-pills nav-justified">
                        <li class="active"><a href="#default-pill1" data-toggle="tab">Windows & Door Schedule</a></li>
                        <li><a href="#default-pill2" data-toggle="tab">Window Elevation Drawings </a></li>
                        <li><a href="#default-pill3" data-toggle="tab">Floor Plan Drawings</a></li>
                        <li><a href="#default-pill4" runat="server" visible="false" data-toggle="tab">Glazing Details</a></li>
                        <li><a href="#default-pill5" runat="server" visible="false" data-toggle="tab">Finish</a></li>
                    </ul>

                    <div class="tab-content pill-content">

                        <%-- Windows and DoorSchedule--%>

                        <div class="tab-pane fade in active" id="default-pill1">

                            <div class="form-group">
                                <div class="row">

                                    <div class="col-md-1"></div>
                                    <div class="col-md-1">
                                        <label>Code :</label>
                                        <asp:TextBox ID="txtCode" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Width :  </label>
                                        <asp:TextBox ID="txtwidth" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Height :  </label>
                                        <asp:TextBox ID="txtheight" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Sill Height :  </label>
                                        <asp:TextBox ID="txtsillHeight" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Series :  </label>
                                        <asp:TextBox ID="txtseries" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Quantity :  </label>
                                        <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Glass :  </label>
                                        <asp:TextBox ID="txtGlass" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-1">
                                        <label>Flyscreen :  </label>
                                        <asp:TextBox ID="txtflyscreen" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Profile Finish :  </label>
                                        <asp:TextBox ID="txtprofilefinish" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-1"></div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">

                                    <div class="text-center">

                                        <asp:Button ID="btnReset" CssClass="btn btn-danger " runat="server" Text="Reset" OnClick="btnReset_Click" />
                                        <asp:Button ID="btnAddItems" CssClass="btn btn-primary" OnClick="btnAddItems_Click" runat="server" Text="Add Item" />
                                    </div>
                                </div>
                            </div>

                            <div class="panel-body">
                                <div class="datatable-tasks">

                                    <div class="row" style="padding-top: 0px">
                                        <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                            Width="100%" OnRowDataBound="gvitems_RowDataBound" OnRowDeleting="gvitems_RowDeleting">
                                            <Columns>
                                                <asp:CommandField ShowEditButton="True" />
                                                <asp:CommandField ShowDeleteButton="True" />
                                                <asp:BoundField DataField="CodeNo" HeaderText="Code No" />
                                                <asp:BoundField DataField="Width" HeaderText="Width" />
                                                <asp:BoundField DataField="height" HeaderText="height" />
                                                <asp:BoundField DataField="SillHeight" HeaderText="SillHeight" />
                                                <asp:BoundField DataField="Series" HeaderText="Series" />
                                                <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                                <asp:BoundField DataField="Glass" HeaderText="Glass" />
                                                <asp:BoundField DataField="FlyScreen" HeaderText="FlyScreen" />
                                                <asp:BoundField DataField="ProfileFinish" HeaderText="Profile Finish" />
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="text-align: center">
                                                    <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                            <div class="form-actions text-right">
                                <asp:Button ID="btnDoorSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnDoorSubmit_Click" />
                            </div>
                       
                            
                        </div>
                        <%-- Windos Elevation Drawings --%>
                        <div class="tab-pane fade" id="default-pill2">

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Drawings Received Date:  </label>
                                        <asp:TextBox ID="txtElevationreceiveddate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="Image2" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender3" runat="server" PopupButtonID="Image2"
                                            TargetControlID="txtElevationreceiveddate">
                                        </cc1:CalendarExtender>
                                    </div>

                                    <div class="col-md-6">
                                        <label>Drawings Document:  </label>
                                        <asp:FileUpload ID="FileUpload1" type="file" CssClass="styled form-control" runat="server" />
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

                            <div class="form-group">

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
                        </div>

                        <%-- FloorPlan --%>
                        <div class="tab-pane fade" id="default-pill3">

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>FloorPlan Received Date:  </label>
                                        <asp:TextBox ID="txtfloorplanreceiveddate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                                            TargetControlID="txtfloorplanreceiveddate">
                                        </cc1:CalendarExtender>
                                    </div>

                                    <div class="col-md-6">
                                        <label>FloorPlan Document:  </label>
                                        <asp:FileUpload ID="FileUpload2" CssClass="styled form-control" runat="server" />
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

                            <div class="form-group">

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
                            </div>
                        </div>
                        <%-- Glazing Details --%>
                        <div class="tab-pane fade" id="default-pill4">

                            <div class="form-group">
                                <div class="row">

                                    <div class="col-md-3">
                                        <label>Glass Thick :  </label>
                                        <asp:TextBox ID="txtglassthick" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <label>Received Date :  </label>
                                        <asp:TextBox ID="txtglassreceiveddate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="Image3" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender4" runat="server" PopupButtonID="Image3"
                                            TargetControlID="txtglassreceiveddate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Glass Specification:  </label>
                                        <asp:TextBox ID="txtglassspecification" CssClass="editor" runat="server"></asp:TextBox>

                                        <%--  <RTE:Editor ID="txtglassspecification" Height="100px" ToolbarItems="bold,italic,forecolor,backcolor " runat="server" />--%>
                                    </div>

                                    <div class="col-md-12">
                                        <label>Remarks:  </label>
                                        <asp:TextBox ID="txtGlassremarks" CssClass="editor" runat="server"></asp:TextBox>
                                        <%--   <RTE:Editor ID="txtGlassremarks" Height="100px" ToolbarItems="bold,italic,forecolor,backcolor " runat="server" />--%>
                                    </div>
                                </div>
                            </div>

                            <div class="form-actions text-right">
                                <asp:Button ID="btnGlassdetailsSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnGlassdetailsSubmit_Click" />
                            </div>
                        </div>
                        <%-- Finish Details --%>
                        <div class="tab-pane fade" id="default-pill5">

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-3">
                                        <label>Color :  </label>
                                        <asp:TextBox ID="txtfinishcolor" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label>Finish Profile :  </label>
                                        <asp:TextBox ID="txtfinishprofile" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <label>Received Date :  </label>
                                        <asp:TextBox ID="txtfinsihedReceiveddate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="Image4" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender5" runat="server" PopupButtonID="Image4"
                                            TargetControlID="txtfinsihedReceiveddate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Remarks:  </label>
                                        <asp:TextBox ID="txtfinishremarks" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-actions text-right">
                                <asp:Button ID="btnfinishSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnfinishSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnsubmitElevationdrawing" />
            <asp:PostBackTrigger ControlID="btnfloorplansubmit" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>