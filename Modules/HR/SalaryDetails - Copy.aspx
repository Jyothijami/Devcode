<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="SalaryDetails.aspx.cs" Inherits="Modules_HR_SalaryDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Salary Details</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					
					<li class="active">Salary Structure Details</li>
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
                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee Department :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlEmployeeCategory" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployeeCategory_SelectedIndexChanged">
               
                                </asp:DropDownList>    	
				            </div>
				      
                       
                        </div>

                  <div class="block-inner text-danger">
                        <h6 class="heading-hr">Existing Allowances Details
                        </h6>
                    </div>

               
                    <div class="form-group">

                       <div class="datatable">
                        <asp:GridView ID="gvEmployeeSalaryDetails" CssClass="table table-bordered" OnRowDataBound="gvEmployeeSalaryDetails_RowDataBound" AutoGenerateColumns="False" runat="server"  >

                             <columns>
<asp:BoundField DataField="SalaryComp_Name" HeaderText="Allowance Name">
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 <ItemStyle HorizontalAlign="Center" />
                                 </asp:BoundField>
<asp:BoundField DataField="ALLOWANCE_SETUP_TYPE" HeaderText="Type">
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:BoundField>
<asp:BoundField DataField="ALLOWANCE_SETUP_AMOUNT" HeaderText="Amount">
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 </asp:BoundField>
</columns>


                        </asp:GridView>


                    </div>
              </div>


                   <div class="block-inner text-danger">
                        <h6 class="heading-hr"> Allowances Details
                        </h6>
                    </div>

                <div class="form-group">

                    <asp:GridView id="gvAllowanceDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                                       OnRowDataBound="gvAllowanceDetails_RowDataBound"
                                        Width="100%" >
                                        
                                        <columns>
<asp:TemplateField HeaderText="Select"><ItemTemplate>
<asp:CheckBox id="cblSelect" runat="server"  ></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="ALLOWANCE_SETUP_ID" HeaderText="Id"></asp:BoundField>
<asp:BoundField DataField="DEPT_NAME" HeaderText="Department"></asp:BoundField>
<asp:BoundField DataField="SalaryComp_Name" HeaderText="Allowance Name"></asp:BoundField>
<asp:BoundField DataField="ALLOWANCE_SETUP_TYPE" HeaderText="Type"></asp:BoundField>
<asp:BoundField DataField="ALLOWANCE_SETUP_CALCULATIONS" HeaderText="Calculations"></asp:BoundField>
<asp:BoundField DataField="ALLOWANCE_SETUP_AMOUNT" HeaderText="Amount"></asp:BoundField>
</columns>
                                      
                                    </asp:GridView>




                </div>



               
            </div>

                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       








</asp:Content>

