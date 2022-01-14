<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="PaymentTerm_Detail.aspx.cs" Inherits="Modules_Masters_PaymentTerm_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


        <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>PaymentTerm Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="PaymentTerms.aspx">PaymentTerm</a></li>
					<li class="active">PaymentTerm Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">PaymentTerm Name :</label>
				            <div class="col-sm-10">
                             <asp:TextBox ID="txtPaymentTerm" CssClass="validate[required] form-control" placeholder="Enter PaymentTerm Name" ClientIDMode="Static" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPaymentTerm" runat="server" ErrorMessage="Please Enter PaymentTerm Name"></asp:RequiredFieldValidator>
				            	
				            </div>
				        </div>
			    <div class="form-group">
				            <label class="col-sm-2 control-label text-right"> Description :</label>
				            <div class="col-sm-10">
                             <asp:TextBox ID="txtDescription" CssClass="editor" placeholder="Enter Description"  runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDescription" runat="server" ErrorMessage="Please Enter Description"></asp:RequiredFieldValidator>
                                 <cc1:HtmlEditorExtender
                                                ID="HtmlEditorExtender5" TargetControlID="txtDescription" EnableSanitization="false" DisplaySourceTab="false" 
                                                runat="server" />
				            </div>


            </div>

                  <div class="form-actions text-right">
                            <asp:Button ID="btnSave" runat="server"  CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                        	                  </div>
        </div>
    </div>
        </div>


</asp:Content>

