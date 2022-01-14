<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="ExpenseClaimType_Details.aspx.cs" Inherits="Modules_HR_ExpenseClaimType_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Expense Claim Type Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Users.aspx">Expense Claim Type</a></li>
					<li class="active">Expense Claim Type Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Expense Claim Type :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtExpenseClaimType" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        
                       
                        </div>

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Description :</label>
				            <div class="col-sm-10">
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

