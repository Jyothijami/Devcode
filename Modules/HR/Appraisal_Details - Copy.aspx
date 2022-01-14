<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="Appraisal_Details.aspx.cs" Inherits="Modules_HR_Appraisal_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Appraisal Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Users.aspx">Appraisal</a></li>
					<li class="active">Appraisal Details</li>
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
				        <label class="col-sm-2 control-label text-right">Appraisal Template :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlAppraisalTemplate" CssClass="form-control"  runat="server"></asp:DropDownList>    	
				            </div>
                       
                        </div>

                 

		


            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server"  CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       










</asp:Content>

