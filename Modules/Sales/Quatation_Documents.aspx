<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Quatation_Documents.aspx.cs" Inherits="Modules_Sales_Quatation_Documents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
        <ContentTemplate>
            <div class="page-header">
                <div class="page-title">
                    <h3>Quatation Documents</h3>
                </div>
            </div>

            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="SalesQuotation.aspx">Quatation</a></li>
                    <li class="active">Quatation Documents</li>
                </ul>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Quatation Details</h6>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <label>Quatation No:  </label>
                                <asp:DropDownList ID="ddlQuatationno" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlQuatationno_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-5">
                                <label>Quatation Date:  </label>
                                <asp:TextBox ID="txtQuatationDate" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1"></div>
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

                                    <asp:BoundField DataField="Quatation_Doc_Id" HeaderText="Sl.No" SortExpression="Quatation_Doc_Id">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Quatation_Doc_Date" HeaderText="Received Date" SortExpression="Quatation_Doc_Date" DataFormatString="{0:dd/MM/yyyy}">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Quatation_Remarks" HeaderText="Remarks" SortExpression="Quatation_Remarks">
                                        <HeaderStyle Font-Size="Smaller" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <span class="text-center">
                                                <asp:HyperLink ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" Target="_blank" NavigateUrl='<%# "~/Content/Quatation_Doc/" + Eval("Quatation_Documents") %>'><i class="icon-attachment"></i></asp:HyperLink>
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