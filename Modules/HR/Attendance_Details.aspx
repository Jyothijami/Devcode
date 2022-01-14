<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="Attendance_Details.aspx.cs" Inherits="Modules_HR_Attendance_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Attendance</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Attendance.aspx">Attendance</a></li>
					<li class="active">Attendance Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlemployee" CssClass="select-full" Width="100%"  runat="server" OnSelectedIndexChanged="ddlemployee_SelectedIndexChanged"></asp:DropDownList>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Company :</label>
				            <div class="col-sm-4">
                                  <asp:TextBox ID="txtCompany" CssClass="form-control"  runat="server"></asp:TextBox>    		
				            </div>
                       
                        </div>

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee Name :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployeeName" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				       <label class="col-sm-2 control-label text-right">Deparment :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtDepartment" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                       
                       
                        </div>

		 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Designation :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtdesignation" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				       <label class="col-sm-2 control-label text-right">Employee Type :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmployeetype" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
                       
                       
                       
                        </div>
                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Attendance Date :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtAttendanceDate" CssClass="form-control"  runat="server"></asp:TextBox>    	
				            </div>
				       <label class="col-sm-2 control-label text-right">Status :</label>
				            <div class="col-sm-4">
                                  <asp:DropDownList ID="ddlstatus" CssClass="form-control"  runat="server">
                                    <asp:ListItem>Present</asp:ListItem>
                                    <asp:ListItem>Absent</asp:ListItem>
                                        <asp:ListItem>OnLeave</asp:ListItem>
                                          <asp:ListItem>HalfDay</asp:ListItem>
                                </asp:DropDownList>     	
				            </div>
                       
                       
                       
                        </div>

            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       




</asp:Content>

