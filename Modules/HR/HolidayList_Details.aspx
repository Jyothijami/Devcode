<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="HolidayList_Details.aspx.cs" Inherits="Modules_HR_HolidayList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Holiday List Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="Users.aspx">Holiday List</a></li>
					<li class="active">Holiday List Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Holiday List Name :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlHolidayListName" CssClass="form-control"  runat="server"></asp:DropDownList>    	
				            </div>

                            </div>


				        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">From Date :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlFromDate" CssClass="form-control"  runat="server"></asp:DropDownList>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">To Date :</label>
				            <div class="col-sm-4">
                            <asp:DropDownList ID="ddlToDate" CssClass="form-control"  runat="server"></asp:DropDownList>         	
				            </div>
                       
                        </div>
                       
                        </div>
                        </div>

                         </div>
                        




</asp:Content>

