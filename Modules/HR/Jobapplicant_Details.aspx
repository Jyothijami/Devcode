<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Jobapplicant_Details.aspx.cs" Inherits="Modules_HR_Jobapplicant_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


  <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Job Applicant Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="JobApplicant.aspx">Job Applicant</a></li>
					<li class="active">Job Applicant Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Applicant Name :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtapplicantname" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Job Opening :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddljobopening" CssClass="select-full" Width="100%"  runat="server"></asp:DropDownList>    	
				            </div>
                       
                        </div>

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Email Address :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmailAddress" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				       
                         <label class="col-sm-2 control-label text-right">Status :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlstatus" CssClass="form-control"  runat="server">
                                    <asp:ListItem>Open</asp:ListItem>
                                    <asp:ListItem>Replied</asp:ListItem>
                                    <asp:ListItem>Rejected</asp:ListItem>
                                    <asp:ListItem>Hold</asp:ListItem>
                                </asp:DropDownList>    	
				            </div>
                       
                       
                        </div>

			  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Cover Letter :</label>
				            <div class="col-sm-10">
                                <asp:TextBox ID="txtCoverletter" TextMode="MultiLine" Rows="5" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				        </div>

                  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Resume Attachment :</label>
				            <div class="col-sm-10">
                                <asp:FileUpload ID="FileUpload1" CssClass="styled"  runat="server" />

                                <asp:LinkButton ID="link" Visible="false" runat="server"></asp:LinkButton>
                            </div>
				        </div>
            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       




</asp:Content>

