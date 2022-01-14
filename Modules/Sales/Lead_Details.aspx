<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Lead_Details.aspx.cs" Inherits="Modules_Sales_Lead_Details" %>

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
                window.location = 'Lead.aspx';
            }).catch(function (reason) {
                // The action was canceled by the user
            });

        }
    </script>
  <%--  <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <!-- Page header -->
            <div class="page-header">
                <div class="page-title">
                    <h3>Lead Details</h3>
                </div>
            </div>
            <!-- /page header -->

            <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="Lead.aspx">Lead</a></li>
                    <li class="active">Lead Details</li>
                </ul>
            </div>
            <!-- /breadcrumbs line -->

            <div class="form-horizontal">
                <div class="panel panel-default">
                    <div class="panel-body">

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h6 class="panel-title">Basic Lead Details</h6>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Lead No :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtleadno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                     <label class="col-sm-2 control-label text-right">Lead Date :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtleaddate" CssClass="form-control" runat="server"></asp:TextBox>
                                    
                                     <asp:Image
                                            ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                                            TargetControlID="txtleaddate">
                                        </cc1:CalendarExtender>
                                    
                                    
                                    </div>
                                </div>



                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Subject :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtSubject" CssClass="form-control" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtSubject" runat="server" Text="*" ErrorMessage="Please Enter Subject"></asp:RequiredFieldValidator>
                                      
                                    </div>
                                  
                                </div>


                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Person Name :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtPersonName" CssClass="form-control" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPersonName" runat="server" Text="*" ErrorMessage="Please Enter Person Name"></asp:RequiredFieldValidator>
                                      
                                    </div>
                                   <%-- <label class="col-sm-2 control-label text-right">Gender :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlgender" CssClass="form-control" Width="100%" runat="server">
                                            <asp:ListItem>----</asp:ListItem>
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>--%>
                                     <label class="col-sm-2 control-label text-right">Organzation Name :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtorganzationName" CssClass="form-control" runat="server"></asp:TextBox>
                                         
                                    </div>
                                </div>

                                <div class="form-group">
                                   
                                    <label class="col-sm-2 control-label text-right">Source :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlSource" CssClass="form-control" Width="100%" runat="server">
                                        </asp:DropDownList>
                                    </div>

                                     <label class="col-sm-2 control-label text-right">By Whom :</label>
                                    <div class="col-sm-4">
                                       <asp:TextBox ID="txtbywhom" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>



                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Email Address :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtEmailAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>


                                     <label class="col-sm-2 control-label text-right">Stage :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlstatus" CssClass="form-control" Width="100%" runat="server">
                                            <asp:ListItem>Draft</asp:ListItem>
                                            <asp:ListItem>In progress</asp:ListItem>
                                            <asp:ListItem>Qualified</asp:ListItem>
                                            <asp:ListItem>Cancelled</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>


                                </div>



                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Priority :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlpriority" CssClass="form-control" Width="100%" runat="server">
                                            <asp:ListItem>Low</asp:ListItem>
                                            <asp:ListItem>Medium</asp:ListItem>
                                            <asp:ListItem>High</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>


                                      <label class="col-sm-2 control-label text-right">Assigned to :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlassignedto" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>


                                </div>




                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Notes :</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtNotes" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox> 
                                      
                                    </div>
                                  
                                </div>


                                  <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Lead Owner :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlleadowner" Width="100%" CssClass="select-full" Enabled="false" runat="server"></asp:DropDownList>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Next Contact Date :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtNextContactDate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Image
                                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                                            TargetControlID="txtNextContactDate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--   <div class="block-inner">
								<h6 class="heading-hr">
									<i class="icon-accessibility"></i>Materials:
								</h6>
					    </div>--%>

                        

                        <div class="panel panel-default">

                            <div class="panel-heading">
                                <div>
                                    <h5 class="panel-title">Address & Contact</h5>
                                </div>
                            </div>
                            <div class="panel-body">

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Salutation :</label>
                                    <div class="col-sm-4">
                                         <asp:DropDownList ID="ddlSalutation" CssClass="form-control" Width="100%" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Phone :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Address :</label>
                                    <div class="col-sm-4">
                                   <asp:TextBox ID="txtFaxNo" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Mobile No :</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txtMobileNO" CssClass="form-control" runat="server"></asp:TextBox>
                                        
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">State :</label>
                                    <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlstate" CssClass="form-control" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    </div>
                                    <label class="col-sm-2 control-label text-right">City :</label>
                                    <div class="col-sm-4">
                                       <asp:DropDownList ID="ddlCity" CssClass="form-control" Width="100%" runat="server"></asp:DropDownList>
                                    </div>
                                </div>

                               
                                </div>
                            </div>






                        

                        <div class="panel panel-default">

                            <div class="panel-heading">
                                <h5 class="panel-title">More Information</h5>
                            </div>
                            <div class="panel-body">

                                <div class="form-group">

                                    <label class="col-sm-2 control-label text-right">Market Segment :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlMarketSegment" CssClass="form-control" Width="100%" runat="server">
                                            <asp:ListItem>Lower Income</asp:ListItem>
                                            <asp:ListItem>Middle Income</asp:ListItem>
                                            <asp:ListItem>Upper Income</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <label class="col-sm-2 control-label text-right">Request Type :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlRequesttype" CssClass="form-control" Width="100%" runat="server">
                                            <asp:ListItem>Product Enquiry</asp:ListItem>
                                            <asp:ListItem>Request For Information</asp:ListItem>
                                            <asp:ListItem>Suggestions</asp:ListItem>
                                            <asp:ListItem>Other</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">

                                    <label class="col-sm-2 control-label text-right">Industry :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlIndustry" CssClass="form-control" Width="100%" runat="server">
                                        </asp:DropDownList>
                                    </div>

                                     <label class="col-sm-2 control-label text-right">Company :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlCompany" CssClass="form-control" Width="100%" runat="server">
                                        </asp:DropDownList>
                                    </div>


                                </div>
                            </div>
                        </div>
                        </div>

                        
                    </div>

                    <div class="form-group">

                        <div class="form-actions col-sm-offset-10">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>


              <%--  <div class="panel panel-default">

                            <div class="panel-heading">
                                <div>
                                    <h5 class="panel-title">Follow Up Details</h5>
                                </div>
                            </div>
                            <div class="panel-body">

                              
                                <div class="form-group">

                                    <label class="col-sm-2 control-label text-right"></label>
                                    <div class="col-sm-4">
                                    </div>
                                    <label class="col-sm-2 control-label text-right">Next Contact By :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlNextContactBy" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>--%>









           
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtorganzationName" runat="server" ErrorMessage="Please Enter Organzation Name"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtMobileNO" runat="server" ErrorMessage="Please Enter Mobile No"></asp:RequiredFieldValidator>
               <asp:ValidationSummary ID="ValidationSummary1" runat="server"   ShowMessageBox="true"/>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>