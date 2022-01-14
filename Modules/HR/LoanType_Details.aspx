<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="LoanType_Details.aspx.cs" Inherits="Modules_HR_LoanType_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Loan Type Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Users.aspx">Loan Type</a></li>
					<li class="active">Loan Type Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Loan Name :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtLoanName" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>

				             <label class="col-sm-2 control-label text-right">Maximum Loan Amount:</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtMaximumLoanAmount" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>



                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Rate of Interest (%) Yearly :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtRateofInterestYearly" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>

				             <label class="col-sm-2 control-label text-right">Description:</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtDescription" CssClass="form-control" Rows="5" TextMode="MultiLine" runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div> 
		


            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server"  CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       






</asp:Content>

