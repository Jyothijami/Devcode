<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Incoterm_Details.aspx.cs" Inherits="Modules_Masters_Incoterm_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>IncoTerms Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Incoterms.aspx">IncoTerms</a></li>
					<li class="active">IncoTerms Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">IncoTerms Name :</label>
				            <div class="col-sm-10">
                             <asp:TextBox ID="txtIncoTermsName" CssClass="validate[required] form-control" placeholder="Enter IncoTerms Name" ClientIDMode="Static" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtIncoTermsName" runat="server" ErrorMessage="Please Enter IncoTerms Name"></asp:RequiredFieldValidator>
				            	
				            </div>
				        </div>
			    <div class="form-group">
				            <label class="col-sm-2 control-label text-right"> Description :</label>
				            <div class="col-sm-10">
                             <asp:TextBox ID="txtDescription" CssClass="validate[required] form-control" placeholder="Enter Description"  runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDescription" runat="server" ErrorMessage="Please Enter Description"></asp:RequiredFieldValidator>

				            </div>


            </div>

                  <div class="form-actions text-right">
                            <asp:Button ID="btnSave" runat="server"  CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                        	                  </div>
        </div>
    </div>
        </div>
</asp:Content>

