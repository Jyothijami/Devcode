<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="SubCateogoryDetails.aspx.cs" Inherits="Modules_Masters_SubCateogoryDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>SubCategory Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="SubCategory.aspx">SubCategory</a></li>
					<li class="active">SubCategory Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Category :</label>
				            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server"></asp:DropDownList>          	
				            </div>
				        </div>

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right"> Sub Category :</label>
				            <div class="col-sm-6">
                             <asp:TextBox ID="txtSubcategory" CssClass="form-control"  runat="server"></asp:TextBox>
				            </div>
                     </div>

			    <div class="form-group">
				            <label class="col-sm-2 control-label text-right"> Description :</label>
				            <div class="col-sm-6">
                             <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
				            </div>


            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
        </div>



</asp:Content>

