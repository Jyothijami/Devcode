<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="City_Details.aspx.cs" Inherits="Modules_Masters_City_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>City Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="City.aspx">City</a></li>
					<li class="active">City Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">State :</label>
				            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server"></asp:DropDownList>          	
				            </div>
				        </div>

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">City :</label>
				            <div class="col-sm-6">
                             <asp:TextBox ID="txtCity" CssClass="form-control"  runat="server"></asp:TextBox>
				            </div>
                     </div>


                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
        </div>



</asp:Content>

