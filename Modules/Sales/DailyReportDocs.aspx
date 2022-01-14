<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="DailyReportDocs.aspx.cs" Inherits="Modules_Sales_DailyReportDocs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:UpdatePanel ID="UpdatePanel34" runat="server">
        <ContentTemplate>
            <div class="page-header">
                <div class="page-title">
                    <h3>Daily Report Documents</h3>
                </div>
            </div>

            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="DyReport.aspx">Daily Report</a></li>
                    <li class="active">Daily Report Documents</li>
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
                                <asp:FileUpload ID="FileUpload1" type="file" CssClass="styled form-control" runat="server" />
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





</asp:Content>

