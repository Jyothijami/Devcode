<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SalaryStructure_Details.aspx.cs" Inherits="Modules_HR_SalaryStructure_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Salary Structure Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="SalaryStructure.aspx">Salary Structure</a></li>
					<li class="active">Salary Structure Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee Category :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlempcategory" CssClass="form-control"  runat="server"></asp:DropDownList>    	
				            </div>
				       
                       
                        </div>
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Allowance :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlallowance" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAllowance_SelectedIndexChanged"  runat="server"></asp:DropDownList>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Type :</label>
				            <div class="col-sm-4">
                                <asp:RadioButton id="rdbearnings" CssClass="radio-inline" runat="server" GroupName="Same" Text="Earnings" Checked="True">
                        </asp:RadioButton>
                        <asp:RadioButton id="rdbDeduction" CssClass="radio-inline" runat="server" GroupName="Same" Text="Deduction">
                        </asp:RadioButton>
				            </div>
                       
                        </div>
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Calculation :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlCalculation" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCalculation_SelectedIndexChanged">
                <asp:ListItem>AMOUNT</asp:ListItem>
                <asp:ListItem>PERCENTAGE</asp:ListItem>
            </asp:DropDownList>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Max Amount for Allowance  :</label>
				            <div class="col-sm-4">
                               <asp:TextBox ID="txtMaxAmount" runat="server" CssClass="form-control" Enabled="False">
                        </asp:TextBox>
				            </div>
                       
                        </div>



                   <div class="form-group">
				           
				        <asp:Label class="col-sm-2 control-label text-right" runat="server" id="lblAmount" Text="Amount :"></asp:Label>
				            <div class="col-sm-4">
                              <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtAmount"
                            ErrorMessage="Please Enter the Amount" Visible="False">*</asp:RequiredFieldValidator>
                      
				            </div>
                       
                        </div>



                 



               
            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       




</asp:Content>

