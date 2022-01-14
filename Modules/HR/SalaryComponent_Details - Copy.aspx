<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="SalaryComponent_Details.aspx.cs" Inherits="Modules_HR_SalaryComponent_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Salary Component Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="SalaryComponent.aspx">Salary Component</a></li>
					<li class="active">Salary Component Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Salary Component Name :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtComponentName" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Type :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlstatus" CssClass="form-control"  runat="server">
                                    <asp:ListItem>Earnings</asp:ListItem>
                                    <asp:ListItem>Deduction</asp:ListItem>
                                </asp:DropDownList>    	
				            </div>
                       
                        </div>

                 <div class="form-group">

                      <label class="col-sm-2 control-label text-right">Maximum Amount :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtMaximumAmount" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>


				            <label class="col-sm-2 control-label text-right">Description :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtDescription" CssClass="form-control" Rows="5" TextMode="MultiLine" runat="server"></asp:TextBox>    	
				            </div>
				       
                       
                       
                       
                        </div>

		


            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       





</asp:Content>

