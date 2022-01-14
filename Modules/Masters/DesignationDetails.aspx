<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="DesignationDetails.aspx.cs" Inherits="Modules_Masters_DesignationDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


       <script type="text/javascript">
           function hi() {
               // event.preventDefault();
               swal({
                   title: 'System Meassage',
                   text: "Data Submitted Sucessfully",
                   type: 'success',
                   confirmButtonColor: '#3085d6',
                   confirmButtonText: 'Ok'
               })
               .then(function () {
                   // Set data-confirmed attribute to indicate that the action was confirmed
                   window.location = 'Designation.aspx';
               }).catch(function (reason) {
                   // The action was canceled by the user
               });

           }
    </script>




     <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Designation Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Designation.aspx">Designation</a></li>
					<li class="active">Designation Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Designation Name :</label>
				            <div class="col-sm-10">
                             <asp:TextBox ID="txtCategoryName" CssClass="form-control" placeholder="Enter Designation Name" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCategoryName" runat="server" ErrorMessage="Please Enter Designation Name"></asp:RequiredFieldValidator>

				            	
				            </div>
				        </div>
			    <div class="form-group">
				            <label class="col-sm-2 control-label text-right"> Description :</label>
				            <div class="col-sm-10">
                             <asp:TextBox ID="txtDescription" CssClass="form-control" placeholder="Enter Description" TextMode="MultiLine" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDescription" runat="server" ErrorMessage="Please Enter Description"></asp:RequiredFieldValidator>

				            </div>


            </div>

                  <div class="form-actions text-right">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                        	
                  </div>
        </div>
    </div>
        </div>



</asp:Content>

