<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="PaySlip.aspx.cs" Inherits="Modules_HR_PaySlip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>PaySlip</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					
					<li class="active">PaySlip Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

     <div class="form-horizontal">
          <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlEmpId" OnSelectedIndexChanged="ddlEmpId_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>    	
				            </div>
				       
                       
                        </div>
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee Name :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>

				            </div>
				        <label class="col-sm-2 control-label text-right">Basic Salary :</label>
				            <div class="col-sm-4">
                              <asp:TextBox ID="txtBasicSalary" CssClass="form-control" runat="server"></asp:TextBox>
				            </div>
                       
                        </div>




                  <div class="block-inner text-danger">
                        <h6 class="heading-hr">Employee Allowance Details
                        </h6>
                  </div>
                <asp:GridView id="gvEmpAllowanceDetails" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                            <footerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
                            <columns>
<asp:BoundField DataField="ALLOWANCE_SETUP_TYPE" HeaderText="Allowance Type">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="SalaryComp_Name" HeaderText="Allowance Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="AMOUNT" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
</asp:BoundField>
</columns>
                            <rowstyle backcolor="#F7F6F3" forecolor="#333333" />
                            <editrowstyle backcolor="#999999" />
                            <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
                            <pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" />
                            <headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
                            <alternatingrowstyle backcolor="White" forecolor="#284775" />
                        </asp:GridView>


                  <div class="block-inner text-danger">
                        <h6 class="heading-hr">Attendence Information
                        </h6>
                  </div>

                 <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Month :</label>
				            <div class="col-sm-4">
                               <asp:DropDownList id="ddlMonth" runat="server" CssClass="form-control" AutoPostBack="True"  OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"><asp:ListItem Value="SELECT">--select--</asp:ListItem>
                            <asp:ListItem Value="1">January</asp:ListItem>
                            <asp:ListItem Value="2">February</asp:ListItem>
                            <asp:ListItem Value="3">March</asp:ListItem>
                            <asp:ListItem Value="4">April</asp:ListItem>
                            <asp:ListItem Value="5">May</asp:ListItem>
                            <asp:ListItem Value="6">June</asp:ListItem>
                            <asp:ListItem Value="7">July</asp:ListItem>
                            <asp:ListItem Value="8">August</asp:ListItem>
                            <asp:ListItem Value="9">September</asp:ListItem>
                            <asp:ListItem Value="10">October</asp:ListItem>
                            <asp:ListItem Value="11">November</asp:ListItem>
                            <asp:ListItem Value="12">December</asp:ListItem>
                        </asp:DropDownList><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="ddlMonth" ErrorMessage="Please Select Any Month" InitialValue="SELECT">*</asp:RequiredFieldValidator>
				            </div>
				        <label class="col-sm-2 control-label text-right">Year :</label>
				            <div class="col-sm-4">
                              <asp:TextBox ID="txtYear" runat="server" CssClass="form-control" Enabled="False">
                        </asp:TextBox>				            </div>
                       
                        </div>


                  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">No Of Present Days:</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtNoOfPresentDays" CssClass="form-control" runat="server"></asp:TextBox>

				            </div>
				        <label class="col-sm-2 control-label text-right">No Of Absent Days:</label>
				            <div class="col-sm-4">
                              <asp:TextBox ID="txtNoAbsentDays" CssClass="form-control" runat="server"></asp:TextBox>
				            </div>
                       
                        </div>



                  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">No of Leave Days :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtNoOfLeaveDays" CssClass="form-control" runat="server"></asp:TextBox>

				            </div>
				        <label class="col-sm-2 control-label text-right">No of Half Leave Days :</label>
				            <div class="col-sm-4">
                              <asp:TextBox ID="txtNoOfHalfLeaveDays" CssClass="form-control" runat="server"></asp:TextBox>
				            </div>
                       
                        </div>


                  <asp:Label id="lblNoOfDays" runat="server" Visible="false"></asp:Label>





                </div>



         </div>

</asp:Content>

