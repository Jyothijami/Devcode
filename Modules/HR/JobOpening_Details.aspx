<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="JobOpening_Details.aspx.cs" Inherits="Modules_HR_JobOpening_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Job Opening Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="JobOpening.aspx">Job Opening</a></li>
					<li class="active">Job Opening Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Job Title :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtJobTitle" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Status :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlstatus" CssClass="form-control"  runat="server">
                                    <asp:ListItem>Open</asp:ListItem>
                                    <asp:ListItem>Closed</asp:ListItem>
                                </asp:DropDownList>    	
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
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       





</asp:Content>

