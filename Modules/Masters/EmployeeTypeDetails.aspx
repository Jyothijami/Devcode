<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="EmployeeTypeDetails.aspx.cs" Inherits="Modules_Masters_EmployeeTypeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Employee Type Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="EmployeeType.aspx">Employee Type</a></li>
					<li class="active">Employee Type Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee Type :</label>
				            <div class="col-sm-10">
                             <asp:TextBox ID="txtCategoryName" CssClass="form-control" placeholder="Enter Employee Type" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCategoryName" runat="server" ErrorMessage="Please Enter Employee Type"></asp:RequiredFieldValidator>

				            	
				            </div>
				        </div>
			    <div class="form-group">
				            <label class="col-sm-2 control-label text-right"> Description :</label>
				            <div class="col-sm-10">
                             <asp:TextBox ID="txtDescription" CssClass="form-control" placeholder="Enter Description" TextMode="MultiLine" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDescription" runat="server" ErrorMessage="Please Enter Description"></asp:RequiredFieldValidator>

				            </div>


            </div>

                  <div class="form-actions text-right">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                        	
                  </div>
        </div>
    </div>
        </div>
</asp:Content>

