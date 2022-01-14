<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="LeaveApplication_Details.aspx.cs" Inherits="Modules_HR_New_Leave_Application_Details" %>

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
                        window.location = 'LeaveApplication.aspx';
                    }).catch(function (reason) {
                        // The action was canceled by the user
                    });

                }
            </script>



<!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Leave Application Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="LeaveApplication.aspx">Leave Application</a></li>
					<li class="active">Leave Application Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                       <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Leave Application No :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtLaveappNo" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>


                          <label class="col-sm-2 control-label text-right">Posting Date :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtPostingDate" Enabled="false" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>



				     
                       
                        </div>

                       <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlemployee" CssClass="select-full" OnSelectedIndexChanged="ddlemployee_SelectedIndexChanged" AutoPostBack="true" Width="100%"  runat="server"></asp:DropDownList>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Leave Approver:</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlleaveapprover" CssClass="select-full" Width="100%"  runat="server"></asp:DropDownList>    	
				            </div>
                       
                  </div>

                 
                       

                       <div class="form-group">
				            <label class="col-sm-2 control-label text-right">From Date :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtfromdate" CssClass="form-control"  runat="server"></asp:TextBox> 
                                 <cc1:calendarextender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server" 
                                TargetControlID="txtfromdate">
                            </cc1:calendarextender>   	
				            </div>
				         <label class="col-sm-2 control-label text-right">To Date :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txttodate" CssClass="form-control"  runat="server"></asp:TextBox>   
                                <cc1:calendarextender Format="dd/MM/yyyy" ID="CalendarExtender2" runat="server" 
                                TargetControlID="txttodate">
                            </cc1:calendarextender>   	
				            </div>
                        </div>

                       
                       <div class="form-group">
				            <label class="col-sm-2 control-label text-right">No.of Days :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtnoofdays" CssClass="form-control"  runat="server"></asp:TextBox> 
				            </div>
				        
                        </div>

                 
                        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Reason :</label>
				            <div class="col-sm-10">
                                <asp:TextBox ID="txtReason" CssClass="form-control"  Rows="5" TextMode="MultiLine"  runat="server"></asp:TextBox>    	
				            </div>
                             
                           </div>
   
                        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Address While on Leave :</label>
				            <div class="col-sm-10">
                                <asp:TextBox ID="txtAddressonleave" CssClass="form-control"  Rows="5" TextMode="MultiLine"  runat="server"></asp:TextBox>    	
				            </div>
                             
                           </div>
                     
                  
                  
                       
                        
                          <div class="panel panel-default" id="tblhod" runat="server" visible="false">
                      <div class="panel-heading"><h6 class="panel-title">For HOD/Recommending Authority Approval</h6></div>
               <div class="panel-body">


                   <div class="form-group">
				            <label class="col-sm-2 control-label text-right">HOD :</label>
				            <div class="col-sm-4">
                                 	 
                                <asp:DropDownList ID="ddlHod" CssClass="select-full"  Width="100%"  runat="server"></asp:DropDownList>    	
				          
				            </div>


                          <label class="col-sm-2 control-label text-right">Status :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlhodstatus" CssClass="form-control"  runat="server">
                                    <asp:ListItem>Open</asp:ListItem>
                                    <asp:ListItem>Approved</asp:ListItem>
                                    <asp:ListItem>Rejected</asp:ListItem>
                                </asp:DropDownList>    	
				            </div>
                       
                        </div>


                     </div>
                      </div>



                <div class="panel panel-default" id="tblhr" runat="server" visible="false">
                      <div class="panel-heading"><h6 class="panel-title">For HR Approval</h6></div>
               <div class="panel-body">

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">No of CL Available :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtCLAvailable" Enabled="false" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>


                          <label class="col-sm-2 control-label text-right">No of EL Available :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtELAvailable" Enabled="false" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>

                 <div class="panel panel-default">
                      <div class="panel-heading"><h6 class="panel-title">Allocate Leaves From</h6></div>
            <div class="panel-body">

                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Casual Leave :</label>
				            <div class="col-sm-2">
                                <asp:TextBox ID="txtcasualleaveallocate"  CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>


                           <label class="col-sm-2 control-label text-right">Earned Leave :</label>
				            <div class="col-sm-2">
                                <asp:TextBox ID="txtelleaveallocate"  CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>

                           <label class="col-sm-2 control-label text-right">LOP :</label>
				            <div class="col-sm-2">
                                <asp:TextBox ID="txtLopallocate" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                  </div>



                </div>
                     </div>

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">HR :</label>
				            <div class="col-sm-4">
                                 	
                                <asp:DropDownList ID="ddlHR"  CssClass="select-full" Width="100%"  runat="server"></asp:DropDownList>    	
				            
				            </div>


                          <label class="col-sm-2 control-label text-right">Status :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlhrStatus" CssClass="form-control"  runat="server">
                                    <asp:ListItem>Open</asp:ListItem>
                                    <asp:ListItem>Close</asp:ListItem>
                                </asp:DropDownList>    	
				            </div>
                       
                        </div>

                </div>
                      </div>
                          

                <div class="" id="tblvis" runat="server" visible="false">
     
                         <div class="form-group">
				           
                     <label class="col-sm-2 control-label text-right">Half Day: </label>
				           <div class="col-sm-4">
                               <asp:CheckBox ID="chkhalfday" CssClass="form-control"  runat="server"></asp:CheckBox>    	
				          </div>
                     <div id="halfdaydiv" runat="server" visible="false">
				        <label class="col-sm-2 control-label text-right">Half Day Date :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txthalfdaydate" CssClass="form-control"  runat="server"></asp:TextBox>
                                 <cc1:calendarextender Format="dd/MM/yyyy" ID="CalendarExtender3" runat="server" 
                                TargetControlID="txthalfdaydate">
                            </cc1:calendarextender>   	    	
				            </div>
                       
                        </div>
                      </div>
                        
                         <div class="form-group">
				            
				         <label class="col-sm-2 control-label text-right">Leave Type :</label>
				            <div class="col-sm-4">
                                <asp:DropDownlist ID="ddlLeaveType" CssClass="select-full" Width="100%" runat="server"></asp:DropDownlist>    	
				            </div>
                       
                        </div>  

		
                         <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Status :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlstatus" CssClass="form-control"   runat="server">
                                    <asp:ListItem>Open</asp:ListItem>
                                    <asp:ListItem>Approved</asp:ListItem>
                                    <asp:ListItem>Rejected</asp:ListItem>
                                </asp:DropDownList>    	
				            </div>
                              
                       </div>
         
                </div>
        

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       
        </div>
         


</asp:Content>

