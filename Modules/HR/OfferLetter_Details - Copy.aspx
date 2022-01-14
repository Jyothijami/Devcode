<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="OfferLetter_Details.aspx.cs" Inherits="Modules_HR_OfferLetter_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Offer Letter Details</h3>
                </div>
            </div>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="OfferLetter.aspx">Offer Letter</a></li>
                    <li class="active">Offer Letter Details</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="form-horizontal">
                <div class="panel panel-default">
                    <div class="panel-body">


                         <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Offer No :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtofferNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                          
                        </div>




                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Job Applicant :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlJobApplicant" CssClass="select-full" Width="100%" runat="server"></asp:DropDownList>
                            </div>
                            <label class="col-sm-2 control-label text-right">Status :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlstatus" CssClass="form-control" runat="server">
                                    <asp:ListItem>Awaiting Response</asp:ListItem>
                                    <asp:ListItem>Accepted</asp:ListItem>
                                    <asp:ListItem>Rejected</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Offer Date :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtOfferDate" CssClass="form-control" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server"
                                    TargetControlID="txtOfferDate">
                                </cc1:CalendarExtender>
                            </div>
                            <label class="col-sm-2 control-label text-right">Designation :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlDesignation" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                     
							<div class="block-inner">
								<h6 class="heading-hr">
									<i class="icon-accessibility"></i>Add Items: 
								</h6>
							</div>

                          <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Offer Terms :</label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlofferterms" CssClass="form-control" Width="100%" runat="server"></asp:DropDownList>
                            </div>
                            <label class="col-sm-1 control-label text-right">Description:</label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                              <div class="col-sm-1">
                                   <asp:Button ID="btnAddnew" runat="server" OnClick="btnAddnew_Click" CssClass="btn btn-danger" Text="Add New" />
                              </div>
                           </div>
                        	

                        <div class="form-group">
                            <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered"  runat="server"  AutoGenerateColumns="False" OnRowDeleting="gvitems_RowDeleting"
                                        Width="100%">
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:BoundField DataField="OfferTerms" HeaderText="OfferTerms" />
                                            <asp:BoundField DataField="Description" HeaderText="Description" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="text-align: center">
                                                <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                        </div>


                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Terms and Conditions :</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtTermsandConditions" CssClass="form-control" Rows="5" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>