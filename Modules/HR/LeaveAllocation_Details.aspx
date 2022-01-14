<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="LeaveAllocation_Details.aspx.cs" Inherits="Modules_HR_LeaveAllocation_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Leave Allocation Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Users.aspx">Leave Allocationg</a></li>
					<li class="active">Leave Allocation Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Series :</label>
				            <div class="col-sm-4">
                              <asp:DropDownList ID="ddlSeries" CssClass="form-control"  runat="server"></asp:DropDownList>  	
				            </div>
				        <label class="col-sm-2 control-label text-right">Employee:</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployee" CssClass="form-control"  runat="server"></asp:TextBox>     	
				            </div>
                       
                        </div>



                        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee Name :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployeeName" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Description:</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtDescription" CssClass="form-control" Rows="5" TextMode="MultiLine" runat="server"></asp:TextBox>     	
				            </div>
                       
                        </div>




                        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Leave Type :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlLeaveType" CssClass="form-control"  runat="server"></asp:DropDownList>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">New Leaves Allocated:</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtNewLeavesAllocated" CssClass="form-control"  runat="server"></asp:TextBox>     	
				            </div>
                       
                        </div>



                        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">From Date :</label>
				            <div class="col-sm-4">
                              <asp:DropDownList ID="ddlFromDate" CssClass="form-control"  runat="server"></asp:DropDownList>      	
				            </div>
				        <label class="col-sm-2 control-label text-right">To Date:</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlToDate" CssClass="form-control"  runat="server"></asp:DropDownList>   	
				            </div>
                       
                        </div>

                 
                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Total Leaves Allocated :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtTotalLeavesAllocated" CssClass="form-control"  runat="server"></asp:TextBox>      	
				            </div>
				       
                       
                        </div>
		


            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server"  CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       





</asp:Content>

