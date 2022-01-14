<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="EmployeeLoan_Details.aspx.cs" Inherits="Modules_HR_EmployeeLoan_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Employee Loan Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Users.aspx">Employee Loan</a></li>
					<li class="active">Employee Loan Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployee" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Posting Date :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlPostingDate" CssClass="form-control"  runat="server"></asp:DropDownList>    	
				            </div>
                       
                        </div>



                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee Name :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployeeName" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Company :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtCompany" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>



                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee Loan Application :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployeeLoanApplication" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Status :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtStatus" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>

                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Loan Type :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtLoanType" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				              </div>
                 
                

                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Loan Amount :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtLoanAmount" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Repayment Method :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtRepaymentMethod" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>


                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Disbursement Date :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtDisbursementDate" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Repayment Period in Months :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtRepaymentPeriodinMonths" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>
		


               <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Mode of Payment :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtModeofPayment" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Employee Loan Account :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployeeLoanAccount" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>




              <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Payment Account :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtPaymentAccount" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Interest Income Account :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtInterestIncomeAccount" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>



             <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Total Payment :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtTotalPayment" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Total Interest Payable :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtTotalInterestPayable" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>

		
             

            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server"  CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       





</asp:Content>

