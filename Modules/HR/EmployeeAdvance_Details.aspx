<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="EmployeeAdvance_Details.aspx.cs" Inherits="Modules_HR_EmployeeAdvance_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Employee Advance Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Users.aspx">Employee Advance</a></li>
					<li class="active">Employee Advance Details</li>
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
				        <label class="col-sm-2 control-label text-right">Posting Date :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtPostingDate" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                        </div>

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployee" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Employee Name :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployeeName" CssClass="form-control"  runat="server"></asp:TextBox>     	
				            </div>
                       
                        </div>



                        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Purpose :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtPurpose" CssClass="form-control" Rows="5" TextMode="MultiLine"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Advance Amount:</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtAdvanceAmount" CssClass="form-control"  runat="server"></asp:TextBox>     	
				            </div>
                       
                        </div>



                        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Status :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtStatus" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Advance Account :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtAdvanceAccount" CssClass="form-control"  runat="server"></asp:TextBox>     	
				            </div>
                       
                        </div>


                        

                            <div class="form-group">
				        <label class="col-sm-2 control-label text-right">Company :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtCompany" CssClass="form-control"  runat="server"></asp:TextBox>     	
				            </div>
                            <label class="col-sm-2 control-label text-right">Mode of Payment :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtModeofPayment" CssClass="form-control"  runat="server"></asp:TextBox>     	
				            </div>
                       
                        </div>



                        
		


            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server"  CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       



</asp:Content>

