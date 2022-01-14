<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="BOQInfo.aspx.cs" Inherits="Modules_Sales_BOQInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
   <%-- <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
  <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>

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

            <%-- Windows and Doors --%>

            <div class="panel panel-default">

                <div class="panel-heading">
                    <h6 class="panel-title">Windows and Doors </h6> 
                     <span class="pull-right">
                   <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-warning"  NavigateUrl="~/Content/Templates/Enquiry_Template.xlsx">Download Excel Template</asp:Hyperlink>
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

                    <div class="form-group">
                        <div class="row">

                         <%--   <div class="col-md-1"></div>--%>
                            <div class="col-md-2">
                                <label>Window Code:</label>
                                <asp:TextBox ID="txtCode" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                             <div class="col-md-2">
                                <label>Series:  </label>
                                <asp:TextBox ID="txtseries" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                             <div class="col-md-2">
                                <label>Description:  </label>
                                <asp:TextBox ID="txtdescription" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                             <div class="col-md-2">
                                <label>Glass:  </label>
                                <asp:TextBox ID="txtGlass" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                             <div class="col-md-2">
                                <label>Location:  </label>
                                <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                                <div class="col-md-2">
                                <label>Flyscreen:  </label>
                                <asp:TextBox ID="txtflyscreen" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            </div>

                        </div>

                    <div class="form-group">

                        <div class="row">




                            <div class="col-md-2">
                                <label>Width :  </label>
                                <asp:TextBox ID="txtwidth" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label>Height :  </label>
                                <asp:TextBox ID="txtheight" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                           
                           
                            <div class="col-md-2">
                                <label>Quantity :  </label>
                                <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                           
                        </div>
                    </div>

                    <div class="form-group" runat="server" visible="false">

                        <div class="row">
                            <div class="col-md-2">
                                <label>Profile Finish :  </label>
                                <asp:TextBox ID="txtprofilefinish" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                             <div class="col-md-2">
                                <label>Sill Height :  </label>
                                <asp:TextBox ID="txtsillHeight" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                             <div class="col-md-2">
                                <label>Total Area :  </label>
                                <asp:TextBox ID="txttotalarea" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                             <div class="col-md-2">
                                <label>Total Amount :  </label>
                                <asp:TextBox ID="txttotalamount" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <%--<div class="col-md-1"></div>--%>
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
                        <div class="datatable">

                            <div class="row" style="padding-top: 0px">
                                <asp:GridView ID="gvitems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                    Width="100%" OnRowDataBound="gvitems_RowDataBound" OnRowDeleting="gvitems_RowDeleting">
                                    <Columns>
                                        <asp:CommandField ShowEditButton="True" />
                                        <asp:CommandField ShowDeleteButton="True" />
                                        <asp:BoundField DataField="CodeNo" HeaderText="Code No" />
                                         <asp:BoundField DataField="Series" HeaderText="Series" />
                                           <asp:BoundField DataField="Description" HeaderText="Description" />
                                         <asp:BoundField DataField="Glass" HeaderText="Glass" />
                                          <asp:BoundField DataField="Location" HeaderText="Location" />
                                          <asp:BoundField DataField="FlyScreen" HeaderText="FlyScreen" />
                                        <asp:BoundField DataField="Width" HeaderText="Width(MM)" />
                                        <asp:BoundField DataField="height" HeaderText="Height(MM)" />
                                        <asp:BoundField DataField="SillHeight" HeaderText="SillHeight" />
                                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                        <asp:BoundField DataField="TotalArea" HeaderText="TotalArea(Sq.Mt)" />
                                       <asp:BoundField DataField="TotalAmount" HeaderText="TotalAmount" />
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


                    <div class="form-group">

                    </div>

                    <div class="form-actions text-center">
                        <asp:Button ID="btnDoorSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnDoorSubmit_Click" />
                    </div>
                </div>
            </div>

          
       <%-- </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUploadExcel" />
          <%--  <asp:PostBackTrigger ControlID="btnfloorplansubmit" />--%>
     <%--   </Triggers>
    </asp:UpdatePanel>--%>
</asp:Content>