<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="UserPermissions.aspx.cs" Inherits="Modules_HR_UserPermissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


       <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>User Permissions</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Users.aspx">User</a></li>
					<li class="active">Permissions</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">User Name :</label>
				            <div class="col-sm-6">
                             <asp:DropDownList ID="ddlUserName" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlUserName_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>          	
				            </div>
				        </div>

                 <div class="form-group">
				            <label class="col-md-2 control-label text-right"></label>
				            <div class="col-md-8">
                            <asp:CheckBoxList ID="cblPermissions" CssClass="checkbox-inline" runat="server"  CellPadding="2" CellSpacing="1"  DataSourceID="SqlDataSource1" DataTextField="menu" DataValueField="slno">
                            </asp:CheckBoxList>
                                <asp:SqlDataSource id="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>"
                            SelectCommand="SELECT * FROM [Users_Menu]"></asp:SqlDataSource>
                         <asp:Button ID="btnSelectAll" runat="server" Visible="false" CssClass="btn btn-success" OnClick="btnSelectAll_Click" Text="Select All"  />
                         <asp:Button ID="btnUnselect" runat="server" Visible="false" CssClass="btn btn-warning" OnClick="btnUnselect_Click" Text="De Select All"  />
				            </div>
                     <div class="col-md-2">
                     </div>
				        </div>
                <div class="form-group">
                    <div class="col-sm-2"></div>
                     <div class="col-sm-6 radio">
                        
                          <asp:CheckBox ID="chkIsedit" CssClass="checkbox-inline" runat="server" Text="Edit" />
                                
                          <asp:CheckBox ID="chkIsdelete" CssClass="checkbox-inline" runat="server" Text="Delete" />
                               
                     </div>
                </div>


			  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        	
               </div>


            </div>

                
        </div>
    </div>
       


</asp:Content>

