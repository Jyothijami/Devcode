<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="SalarySlip_Details.aspx.cs" Inherits="Modules_HR_SalarySlip_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Salary Slip Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Users.aspx">Salary Slip</a></li>
					<li class="active">Salary Slip Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Posting Date :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtPostingDate" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Status :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtstatus" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployee" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Company :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtCompany" CssClass="form-control"  runat="server"></asp:TextBox>     	
				            </div>
                       
                        </div>



                        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee Name :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployeeName" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Letter Head :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtLetterHead" CssClass="form-control"  runat="server"></asp:TextBox>     	
				            </div>
                       
                        </div>



                        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Department :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtDepartment" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Designation :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtDesignation" CssClass="form-control"  runat="server"></asp:TextBox>     	
				            </div>
                       
                        </div>


                        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Branch :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtBranch" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                            </div>

                            <div class="form-group">
				        <label class="col-sm-2 control-label text-right">Start Date :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtStartDate" CssClass="form-control"  runat="server"></asp:TextBox>     	
				            </div>
                            <label class="col-sm-2 control-label text-right">End Date :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEndDate" CssClass="form-control"  runat="server"></asp:TextBox>     	
				            </div>
                       
                        </div>



                        <div class="form-group">
				        <label class="col-sm-2 control-label text-right">Payroll Frequency :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtPayrollFrequency" CssClass="form-control"  runat="server"></asp:TextBox>     	
				            </div>
                              </div>
		


            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server"  CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       





</asp:Content>
