<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SoGlassAnalaysis.aspx.cs" Inherits="Modules_Sales_SoGlassAnalaysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <div class="page-header">
                <div class="page-title">
                    <h3>SO Glass Analysis</h3>
                </div>
            </div>

            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="SalesOrder.aspx">Sales Order</a></li>
                    <li class="active">Glass Analysis</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Glass Analysis Details</h6>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <label>SalesOrder No:  </label>
                                <asp:DropDownList ID="ddlEnquiryNo" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlEnquiryNo_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-5">
                                <label>SalesOrder Date:  </label>
                                <asp:TextBox ID="txtenquirydate" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                    </div>
                </div>
            </div>

            <%-- Windows and Doors --%>

            <div class="panel panel-default">

                <div class="panel-heading">
                    <h6 class="panel-title">Glass Details </h6> 
                     <span class="pull-right">
                   <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-warning"  NavigateUrl="~/Content/Templates/GlassAnalaysis_Template.xlsx" Text="Download Excel Template"/></span>
                </div>


                  <div class="panel panel-default">
                    <div class="panel-heading">
                        <h6 class="panel-title">Upload File </h6>
                       <%-- <span class="pull-right">
                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-danger" NavigateUrl="~/Content/Templates/Enquiry_Template.xlsx">Download Excel Template</asp:HyperLink>--%>
                    </div>
                      
                    <div class="panel-body">
                        <div class="form-horizontal">

                            <div class="form-group">
                                <div class="row ">
                                    <label class="col-sm-2 control-label text-right">Select a file :</label>
                                    <div class="col-sm-3">
                                        <asp:FileUpload ID="FileUpload" CssClass="styled form-control" type="file" runat="server" />
                                    </div>

                                    <div class="col-sm-2 text-left">
                                        <asp:Button ID="btnUploadExcel" CssClass="btn btn-primary" OnClick="btnUploadExcel_Click" runat="server" Text="Excel Upload" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="panel-body">

                   

                    <div class="panel-body">
                        <div class="datatable">

                            <div class="row" style="padding-top: 0px">
                                <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                    Width="100%" OnRowDataBound="gvitems_RowDataBound" OnRowDeleting="gvitems_RowDeleting">
                                    <Columns>
                                        <asp:CommandField ShowEditButton="True" />
                                        <asp:CommandField ShowDeleteButton="True" />
                                        <asp:BoundField DataField="WindowCode" HeaderText="Window Code" />
                                         <asp:BoundField DataField="Thickness" HeaderText="Thickness" />
                                           <asp:BoundField DataField="Description" HeaderText="Description" />
                                         <asp:BoundField DataField="Width" HeaderText="Width" />
                                          <asp:BoundField DataField="Height" HeaderText="Height" />
                                          <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                        <asp:BoundField DataField="Area" HeaderText="Area" />
                                        <asp:BoundField DataField="Weight" HeaderText="Weight" />
                                      
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


                    <div class="form-group">

                    </div>

                    <div class="form-actions text-center">
                        <asp:Button ID="btnDoorSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnDoorSubmit_Click" />
                    </div>
                </div>
            </div>






</asp:Content>

