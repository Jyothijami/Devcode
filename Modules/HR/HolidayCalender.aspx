<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="HolidayCalender.aspx.cs" Inherits="Modules_HR_HolidayCalender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
            <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Holiday Calender</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="HrHome.aspx">Home</a></li>
					<li class="active">Holiday Calender</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->
            <div class="form-horizontal">
                 <div class="panel panel-default">
                     <div class="panel-body">
                         <div class="form-group">
                              <label class="col-sm-2 control-label text-right">Holiday Description :</label>
				            <div class="col-sm-6">
                                <asp:TextBox CssClass ="form-control " ID="txtHoliday" runat="server"></asp:TextBox>
				            </div>
                         </div>

                         <div class="form-group">
                              <label class="col-sm-2 control-label text-right">From Date :</label>
				            <div class="col-sm-6">
                                <asp:TextBox ID="txtDateselTbox" CssClass ="form-control " runat="server" type="datepic"></asp:TextBox>
                                <cc1:calendarextender Format="dd/MM/yyyy" ID="CalendarExtender2" runat="server" 
                                TargetControlID="txtDateselTbox">
                            </cc1:calendarextender>   	
				            </div>
                         </div>
                         <div class="form-group">
                              <label class="col-sm-2 control-label text-right">To Date :</label>
				            <div class="col-sm-6">
                                <asp:TextBox ID="txtDay" CssClass ="form-control " ReadOnly="false" runat="server" type="datepic"></asp:TextBox>
                                <cc1:calendarextender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server" 
                                TargetControlID="txtDay">
                            </cc1:calendarextender>   	
				            </div>
                         </div>
                          <div class="form-group">
                              <label class="col-sm-2 control-label text-right">Location :</label>
				            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlLocation" CssClass="select-full" Width ="100%" runat="server">
                                                            </asp:DropDownList>
				            </div>
                         </div>
                         <div class ="form-group ">
                             <asp:Button ID="btnAddHoliday" runat="server" Text="Add Holiday" OnClick="btnAddHoliday_Click" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete Holiday" OnClick="btnDelete_Click" Visible="False" />
                            <asp:Label ID="lblHolidayId" Visible="false" runat="server" />
                            <asp:Label ID="lblDay" Visible="False" runat="server" />
                         </div>
                     </div>
                 </div>
            </div>
            
            <br />
            <div id="HolidayList">
                <asp:GridView ID="gvHolidayList" AutoGenerateColumns="False" runat="server" EmptyDataText="No Records Found" DataSourceID="SqlDataSource1" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Holiday Id">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnHolidayId" ForeColor="#0066ff" OnClick="lbtnHolidayId_Click" runat="server" Text="<%# Bind('Holiday_Id') %>" CausesValidation="False"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Location Id" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblLocationId" Text='<%# Eval("Location_Id") %>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Holiday Description">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblHolidayDesc" Text='<%# Eval("Holiday_Desc") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="From Date">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDateOfHoliday" Text='<%#Eval("Frm_date")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="To Date">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDayg" Text='<%#Eval("To_date")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Location">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblLocation" Text='<%# Eval("Location") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <SelectedRowStyle BackColor="Silver" />
                </asp:GridView>

                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>"
                    SelectCommand="SELECT Holiday_Id, Location_Id, Holiday_Desc, CONVERT (varchar, Date_Of_Holiday, 103) AS Frm_date, CONVERT (varchar, Day, 103) AS To_date, Location FROM HolidayCalender_tbl 
where year(Date_Of_Holiday)=year(getdate())   order by Date_Of_Holiday "></asp:SqlDataSource>
            </div>

       
</asp:Content>

