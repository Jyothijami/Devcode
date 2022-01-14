<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="PlantDetails.aspx.cs" Inherits="Modules_Masters_PlantDetails" %>

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
                 window.location = 'Plant.aspx';
             }).catch(function (reason) {
                 // The action was canceled by the user
             });

         }


    </script>

     <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Plant Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Plant.aspx">Plant</a></li>
					<li class="active">Plant Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Company :</label>
				            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server"></asp:DropDownList>          	
				            </div>
				        </div>

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right"> Plant Name :</label>
				            <div class="col-sm-6">
                             <asp:TextBox ID="txtPlantName" CssClass="form-control"  runat="server"></asp:TextBox>
				            </div>
                     </div>

			    <div class="form-group">
				            <label class="col-sm-2 control-label text-right"> Description :</label>
				            <div class="col-sm-6">
                             <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
				            </div>


            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                        	
                  </div>
        </div>
    </div>
        </div>




</asp:Content>

