<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="OfferTerm_Details.aspx.cs" Inherits="Modules_HR_OfferTerm_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Offer Terms Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
                    <li><asp:HyperLink runat="server" NavigateUrl="~/Modules/HR/OfferTerms.aspx" Text="Offer Terms"></asp:HyperLink></li>
					<li class="active">Offer Terms Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Offer Term :</label>
				            <div class="col-sm-10">
                             <asp:TextBox ID="txtofferterm" CssClass="validate[required] form-control" placeholder="Enter Offer Terms" ClientIDMode="Static" runat="server"></asp:TextBox>
				            	
				            </div>
				        </div>
			    <div class="form-group">
				            <label class="col-sm-2 control-label text-right"> Description :</label>
				            <div class="col-sm-10">
                             <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" Height="200px" runat="server"></asp:TextBox>
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

