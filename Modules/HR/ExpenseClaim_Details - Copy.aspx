<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="ExpenseClaim_Details.aspx.cs" Inherits="Modules_HR_ExpenseClaim_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Expense Claim Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Users.aspx">Expense Claim</a></li>
					<li class="active">Expense Claim Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Series :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtSeries" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Approver :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtApprover" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>




                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Posting Date :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtPostingDate" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">From Employee :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtFromEmployee" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div> 



                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee Name :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployeeName" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Remark :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtRemark" CssClass="form-control" Rows="5" TextMode="MultiLine"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>       



                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Project :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtProject" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Task :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtTask" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>        


                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Company :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtCompany" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Payable Account :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtPayableAccount" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>        

                            



                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Cost Center :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtCostCenter" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">             :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="TextBox2" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>        
		


            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server"  CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
</asp:Content>

