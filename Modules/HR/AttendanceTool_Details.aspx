<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="AttendanceTool_Details.aspx.cs" Inherits="Modules_HR_AttendanceTool_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
       <%-- <asp:ScriptManager ID="SManger" runat="server"></asp:ScriptManager> --%>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>
  <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Employee Attendance Tool</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="HrHome.aspx">HR Home</a></li>
					<li class="active">Employee Attendance Tool</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Date :</label>
				            <div class="col-sm-4">
                                  <asp:TextBox ID="txtDate" CssClass="form-control"  runat="server"></asp:TextBox>
                                 <cc1:calendarextender Format="dd/MM/yyyy" ID="CalendarExtender2" runat="server" 
                                TargetControlID="txtDate">
                            </cc1:calendarextender>
				            </div>
				        <label class="col-sm-2 control-label text-right">Department :</label>
				            <div class="col-sm-4">
                                  <asp:DropDownList ID="ddldepartment"  CssClass="form-control" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddldepartment_SelectedIndexChanged"></asp:DropDownList>    		
				            </div>
                       
                        </div>

             

		 <div class="panel">
             <div class="panel-body">


                 <asp:GridView id="gvEmployeeDetails" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%"
                   
                    >
                   
                    <columns>
<asp:BoundField DataField="EMP_ID" HeaderText="Emp Id">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Wrap="False"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="Employee Name">
<ItemStyle  Wrap="False" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Wrap="False" HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Status">
<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:RadioButtonList id="rbtnlist" runat="server" Width="307px" RepeatDirection="Horizontal" ><asp:ListItem Selected="True">Present</asp:ListItem>
<asp:ListItem>Absent</asp:ListItem>
<asp:ListItem>Leave</asp:ListItem>
<asp:ListItem>Half Day</asp:ListItem>
</asp:RadioButtonList> 
</ItemTemplate>
</asp:TemplateField>
</columns>
                    <rowstyle backcolor="#F7F6F3" forecolor="#333333" />
                    <emptydatatemplate>
<asp:RadioButtonList id="RadioButtonList1" Width="307px" runat="server"><asp:ListItem>present</asp:ListItem>
<asp:ListItem>absent</asp:ListItem>
<asp:ListItem>leave</asp:ListItem>
</asp:RadioButtonList>
</emptydatatemplate>
                    <editrowstyle backcolor="#999999" />
                    <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
                    <pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" />
                    <headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
                    <alternatingrowstyle backcolor="White" forecolor="#284775" />
                </asp:GridView>



				          
                 </div>
				        </div>
                 

            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server"  CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                        	
                  </div>
        </div>
    </div>
       


  </ContentTemplate>    
</asp:UpdatePanel>



</asp:Content>

