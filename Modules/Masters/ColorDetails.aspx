<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="ColorDetails.aspx.cs" Inherits="Modules_Masters_ColorDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Color Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Color.aspx">Color</a></li>
					<li class="active">Color Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Color Name :</label>
				            <div class="col-sm-10">
                             <asp:TextBox ID="txtColorName" CssClass="validate[required] form-control" placeholder="Enter Color Name" ClientIDMode="Static" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtColorName" runat="server" ErrorMessage="Please Enter Color Name "></asp:RequiredFieldValidator>

				            	
				            </div>
				        </div>
			    <div class="form-group">
				            <label class="col-sm-2 control-label text-right"> Description :</label>
				            <div class="col-sm-10">
                             <asp:TextBox ID="txtDescription" CssClass="form-control" placeholder="Enter Description" TextMode="MultiLine" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDescription" runat="server" ErrorMessage="Please Enter Description "></asp:RequiredFieldValidator>

				            </div>


            </div>

                  <div class="form-actions text-right">
                            <asp:Button ID="btnSave" runat="server"  CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                        	                  </div>
        </div>
    </div>
        </div>
</asp:Content>

