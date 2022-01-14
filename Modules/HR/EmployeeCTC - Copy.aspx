<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="EmployeeCTC.aspx.cs" Inherits="Modules_HR_EmployeeCTC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript" >



        function sumCalc() {
            var BasicSalary = document.getElementById('<%= txtbasicsalaryMonthly.ClientID %>');
            var HouserentAllowance = document.getElementById('<%= txthouserentallowanceMonthly.ClientID %>');
            var COnveyanceAllowance = document.getElementById('<%= txtConveyanceallowancemonthly.ClientID %>');
            var medicalAllowacne = document.getElementById('<%= txtmedicalallowancemonthly.ClientID %>');
            var OtherAllowance = document.getElementById('<%= txtotherallowancemonthly.ClientID %>');
            var Monthlygross = document.getElementById('<%= txtmonthlytotal.ClientID %>');

            var PfContrivutionEmp = document.getElementById('<%= txtpfcontributionemployeemonthly.ClientID %>');
            var esicContributionEmp = document.getElementById('<%= txtesiccontributionemployeemonthly.ClientID %>');
            var Professionaltax = document.getElementById('<%= txtprofessionaltaxmonthly.ClientID %>');
            var totalb = document.getElementById('<%= txttotalbmonthly.ClientID %>');
            var Netsalary = document.getElementById('<%= txtnetsalarymonthly.ClientID %>');


            var pfContributionemployeer = document.getElementById('<%= txtpfcontributionemployeermonthly.ClientID %>');
            var esiccontributionemployeer = document.getElementById('<%= txtesiccontributionemployeermonthly.ClientID %>');
            var totalc = document.getElementById('<%= txttotalcmonthly.ClientID %>');
            var totalctc = document.getElementById('<%= txttotalctcmonthly.ClientID %>');



            var E1 = 0, E2 = 0, E3 = 0, E4 = 0, E5 = 0, E6 = 0;
            var SD1 = 0, SD2 = 0, SD3 = 0, SD4 = 0, SD5 = 0;
            var SC1 = 0, SC2 = 0, SC3 = 0, SC4 = 0;


             if (BasicSalary.value != "") E1 = BasicSalary.value;
             document.getElementById('<%= txtbasicsalaryYearly.ClientID %>') = E1 * 12;
             

             if (HouserentAllowance.value != "") E2 = HouserentAllowance.value;

             if (COnveyanceAllowance.value != "") E1 = BasicSalary.value;
             if (medicalAllowacne.value != "") E2 = HouserentAllowance.value;




             _txt3.value = parseInt(t1) + parseInt(t2);
         }


       




    </script>



     <script type="text/javascript">

         function grosscalc() {
                 var Basic;
                 Basic = document.getElementById('<%= txtbasicsalaryMonthly.ClientID %>');
                var grossamt = "12";
             
                if (Basic == "" || Basic == "0" || isNaN(Basic)) { Basic = "0"; }

                

                TOTAL = Basic * 12;

                document.getElementById('<%=txtbasicsalaryYearly.ClientID %>').value = parseInt(TOTAL);
         }
            </script>










    <!-- Page header -->
			<div class="page-header">
				<div class="page-title">
					<h3>Employee Cost to Company(CTC)</h3>

				</div>
				
			</div>
   <!-- /page header -->

    <!-- Breadcrumbs line -->
			<div class="breadcrumb-line">
				<ul class="breadcrumb">
					<li><a href="">Employee Cost to Company</a></li>
					<li class="active">Employee Cost to Company Details</li>
				</ul>
						
			</div>
			<!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">

                <div class="panel panel-default">
                     <div class="panel-heading"><h2 class="panel-title">Personal Details</h2></div>
            <div class="panel-body">

                  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee Name :</label>
				            <div class="col-sm-4">
                               <asp:DropDownlist ID="ddlEmployee" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged" AutoPostBack="true" CssClass="select-full" Width="100%"  runat="server"></asp:DropDownlist>    	
				            </div>
				        <label class="col-sm-2 control-label text-right">Designation :</label>
				            <div class="col-sm-4">
                                <asp:DropDownlist ID="ddlDesignation" CssClass="select-full" Width="100%"  runat="server"></asp:DropDownlist>    	
				            </div>
                       
                        </div>

                  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Employee Code :</label>
				            <div class="col-sm-4">
                               	<asp:TextBox ID="txtemployeeCode" CssClass="form-control"  runat="server"></asp:TextBox> 
				            </div>
                           <label class="col-sm-2 control-label text-right">Date of Birth :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtdob" CssClass="form-control"  runat="server"></asp:TextBox> 
                                 <cc1:calendarextender Format="dd/MM/yyyy" ID="CalendarExtender4" runat="server" 
                                TargetControlID="txtdob">
                            </cc1:calendarextender>   	
				            </div>


                              
                       </div>
                       
                  <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Date of Joining :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtdoj" CssClass="form-control"  runat="server"></asp:TextBox> 
                                 <cc1:calendarextender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server" 
                                TargetControlID="txtdoj">
                            </cc1:calendarextender>   	
				            </div>
				        <label class="col-sm-2 control-label text-right">Department :</label>
				            <div class="col-sm-4">
                                   <asp:DropDownlist ID="ddlDepartment" CssClass="select-full" Width="100%"  runat="server"></asp:DropDownlist>    	
				            </div>
                        </div>



                 <div class="form-group">
				           
				        <label class="col-sm-2 control-label text-right">Age :</label>
				            <div class="col-sm-4">
                                  <asp:TextBox ID="txtage" CssClass="form-control"  runat="server"></asp:TextBox> 
                             </div>
                       
                <label class="col-sm-2 control-label text-right">Monthly Salary :</label>
				            <div class="col-sm-4">
                 <asp:TextBox ID="txtGrossAmount" CssClass="form-control" runat="server"> </asp:TextBox>
                      <asp:TextBox ID="txtGrossAmountYear" Visible="false" runat="server">
                     </asp:TextBox>
                       </div>
                     

                </div>


                
                        <div class="form-actions text-center">
                            <asp:Button ID="btnCalc" runat="server" CssClass="btn btn-primary" Text="Calculate" OnClick="btnCalc_Click" />
                        </div>



                    </div>

                 
                <div class="panel panel-default" style="width:50%;text-align:right;margin-left:30%">
                    <div class="panel-heading"><h2 class="panel-title">Earnings</h2></div>
            <div class="panel-body">


                <table class="table table-bordered" style="text-align:center">
    <thead>
      <tr>
        <th class="text-center">Description</th>
        <th class="text-center">Monthly</th>
        <th class="text-center">Yearly</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td class="text-right">Basic Salary :</td>
        <td><asp:TextBox ID="txtbasicsalaryMonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txtbasicsalaryYearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>
      <tr>
        <td class="text-right">House Rent Allowance :</td>
         <td><asp:TextBox ID="txthouserentallowanceMonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txthouserentallowanceyearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>
      <tr>
        <td class="text-right">Conveyance Allowance :</td>
         <td><asp:TextBox ID="txtConveyanceallowancemonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txtconveyanceallowanceyearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>

        <tr>
        <td class="text-right">Medical Allowance :</td>
         <td><asp:TextBox ID="txtmedicalallowancemonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txtmedicalallowanceyearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>
         <tr>
        <td class="text-right">Other Allowance :</td>
         <td><asp:TextBox ID="txtotherallowancemonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txtotherallowanceyearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>

        <tr>
        <td class="text-right">Monthly/Yearly Gross(A) :</td>
         <td><asp:TextBox ID="txtmonthlytotal" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txtyearlytotal" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>

    </tbody>
  </table>

                



                </div>
                    </div>


                <div class="panel panel-default" style="width:50%;text-align:right;margin-left:30%">
                    <div class="panel-heading"><h2 class="panel-title">Statutory Deductions</h2></div>
            <div class="panel-body">


                <table class="table table-bordered">
    <thead>
      <tr>
        <th class="text-center">Description</th>
        <th class="text-center">Monthly</th>
        <th class="text-center">Yearly</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td class="text-right">PF Contribution(Employee) :</td>
        <td><asp:TextBox ID="txtpfcontributionemployeemonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txtpfcontributionemployeeyearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>
      <tr>
        <td class="text-right">ES IC Contribution(Employee) :</td>
         <td><asp:TextBox ID="txtesiccontributionemployeemonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txtesiccontributionemployeeyearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>
      <tr>
        <td class="text-right">Professional Tax :</td>
         <td><asp:TextBox ID="txtprofessionaltaxmonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txtprofessionaltaxYearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>

        <tr>
        <td class="text-right">Total(B) :</td>
         <td><asp:TextBox ID="txttotalbmonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txttotalbYearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>
         <tr>
        <td class="text-right">NetSalary :</td>
         <td><asp:TextBox ID="txtnetsalarymonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txtnetsalaryYearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>
    </tbody>
  </table>

                



                </div>
                    </div>



                <div class="panel panel-default" style="width:50%;text-align:right;margin-left:30%">
                    <div class="panel-heading"><h2 class="panel-title">Statutory Contributions(Employer)</h2></div>
            <div class="panel-body">


                <table class="table table-bordered">
    <thead>
      <tr>
        <th class="text-center">Description</th>
        <th class="text-center">Monthly</th>
        <th class="text-center">Yearly</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td class="text-right">PF Contribution(Employeer) :</td>
        <td><asp:TextBox ID="txtpfcontributionemployeermonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txtpfcontributionemployeerYearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>
      <tr>
        <td class="text-right">ESIC Contribution(Employeer) :</td>
         <td><asp:TextBox ID="txtesiccontributionemployeermonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txtesiccontributionemployeeryearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>
     

        <tr>
        <td class="text-right">Total(C) :</td>
         <td><asp:TextBox ID="txttotalcmonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txttotalcyearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>
         <tr>
        <td class="text-right">Total CTC(A+B+C) :</td>
         <td><asp:TextBox ID="txttotalctcmonthly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
        <td><asp:TextBox ID="txttotalctcyearly" CssClass="form-control"  runat="server"></asp:TextBox> </td>
      </tr>
    </tbody>
  </table>

                



                </div>
                    </div>



                  <div class="panel panel-default">
            <div class="panel-body">


                <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Prepared By :</label>
				            <div class="col-sm-4">
                               <asp:DropDownlist ID="ddlpreparedby" CssClass="select-full" Width="100%"  runat="server"></asp:DropDownlist>    	
				            </div>
				        
                       
                        </div>
        
                </div>
                      </div>
                  <div class="form-actions col-sm-offset-2">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click"  CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
        </div>
    </div>
       
        </div>
         










</asp:Content>

