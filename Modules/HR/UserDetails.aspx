<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="Modules_HR_UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>User Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Users.aspx">User</a></li>
					<li class="active">User Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">User Name :</label>
				            <div class="col-sm-6">
                                <asp:TextBox ID="txtUserName" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        </div>

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Password :</label>
				            <div class="col-sm-6">
                                <asp:TextBox ID="txtPassword" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        </div>

			  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Confirm Password :</label>
				            <div class="col-sm-6">
                                <asp:TextBox ID="txtCOnpassword" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        </div>


            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       


</asp:Content>

