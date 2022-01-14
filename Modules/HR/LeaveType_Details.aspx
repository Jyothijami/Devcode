<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="LeaveType_Details.aspx.cs" Inherits="Modules_HR_LeaveType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Leave Type Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="LeaveType.aspx">Leave Type</a></li>
					<li class="active">Leave Type Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Leave Type Name :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtLeaveType" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Max Days Leave Allowed :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtMaxDaysLeaveAllowed" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>



                <div class="form-group">
                     <label class="col-sm-2 control-label text-right"></label>
				            <div class="col-sm-4">
                              
									<div class="radio">
										<label>
                                        <asp:CheckBox ID="chkiscarryforward" style="margin-right:8px" CssClass="styled" runat="server" />
											Is Carry Forward
										</label>
									</div>

									<div class="radio">
										<label>
											<asp:CheckBox ID="chkisleavewithoutpay" style="margin-right:8px" CssClass="styled" runat="server" />
											Is Leave Without Pay
										</label>
									</div>

									<div class="radio">
										<label>
											<asp:CheckBox ID="chkallownegativebalance" style="margin-right:8px" CssClass="styled" runat="server" />
											Allow Negative Balance
										</label>
									</div>

									<div class="radio">
										<label>
												<asp:CheckBox ID="chkincludeholidaywithinleave" style="margin-right:8px" CssClass="styled" runat="server" />
											Include holidays within leaves as leaves
										</label>
									</div>
				            </div>
                   

                </div>

                          <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click"  CssClass="btn btn-primary" Text="Save" />


                        </div>
                        </div>
</div>
</div>
</asp:Content>

