<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="PersonalInformation.aspx.cs" Inherits="Modules_HR_PersonalInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Employee Personal Information</h3>
				</div>
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li class="active">Employee Personal Information</li>
				</ul>
						
			</div>
     <!-- /breadcrumbs line -->

      <div class="form-horizontal">

            <div class="panel panel-default">

                <div class="panel-heading">
                                <h5 class="panel-title">Professional Details</h5>
                </div>


            <div class="panel-body">

                  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Emp No :</label>
				            <div class="col-sm-4">
                               <asp:TextBox ID="txtEmpSeries" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
				            </div>
				        <label class="col-sm-2 control-label text-right">Department :</label>
				            <div class="col-sm-4">
                               <asp:DropDownList ID="ddlDepartment" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
				            </div>
                  </div>

                  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Designation :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlDesignation" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
				            </div>
				        <label class="col-sm-2 control-label text-right">Employee Type :</label>
				            <div class="col-sm-4">
                          <asp:DropDownList ID="ddlEmployeeType" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
				            </div>
                  </div>

                  

                  </div>
             </div>


          <div class="panel panel-default">

                <div class="panel-heading">
                                <h5 class="panel-title">Personal Information</h5>
                </div>


            <div class="panel-body">

                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">First Name :</label>
				            <div class="col-sm-4">
                               <asp:TextBox ID="txtFirstName" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
				            </div>
				        <label class="col-sm-2 control-label text-right">Last Name :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtLastName" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
				            </div>
                  </div>

                <div class="form-group">

                            <label class="col-sm-2 control-label text-right">Date Of Birth :</label>
				            <div class="col-sm-4">
                            <asp:TextBox ID="txtDateOfBirth" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
				            </div>

				            <label class="col-sm-2 control-label text-right">Date Of Appointment :</label>
				            <div class="col-sm-4">
                            <asp:TextBox ID="txtDateOfAppointment" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
				            </div>
				      
                  </div>

                  </div>
             </div>

          <div class="panel panel-default">

                <div class="panel-heading">
                                <h5 class="panel-title">Contact Information</h5>
                </div>


            <div class="panel-body">

                        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Phone No :</label>
				            <div class="col-sm-4">
                             <asp:TextBox ID="txtPhoneNo" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
				            </div>
				        <label class="col-sm-2 control-label text-right">Mobile No :</label>
				            <div class="col-sm-4">
                              <asp:TextBox ID="txtMobileNo" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
				            </div>
                          </div>

                          <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Email :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmail" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
				            </div>
				            <label class="col-sm-2 control-label text-right">City :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtCity" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
				            </div>
                           </div>

                            <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Address :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtAddress" TextMode="MultiLine" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
				            </div>
				           
                           </div>

                           

                  </div>
             </div>







              



      </div>







</asp:Content>

