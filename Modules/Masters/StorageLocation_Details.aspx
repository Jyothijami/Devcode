<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="StorageLocation_Details.aspx.cs" Inherits="Modules_Masters_StorageLocation_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                  window.location = 'StorageLocation.aspx';
              }).catch(function (reason) {
                  // The action was canceled by the user
              });

          }


    </script>
   

      <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Storage Location Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Plant.aspx">Storage Location</a></li>
					<li class="active">Storage Location Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Company :</label>
				            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlCompany" AutoPostBack="true" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>          	
				            </div>
				        </div>

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right"> Plant :</label>
				            <div class="col-sm-6">
                            <asp:DropDownList ID="ddlPlant" CssClass="form-control" runat="server"></asp:DropDownList>          	
				            </div>
                     </div>


                  <div class="form-group">
				            <label class="col-sm-2 control-label text-right"> Stroage Location Name :</label>
				            <div class="col-sm-6">
                        <asp:TextBox ID="txtStroageLocName" CssClass="form-control"  runat="server"></asp:TextBox>
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

