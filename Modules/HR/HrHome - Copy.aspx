<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="HrHome.aspx.cs" Inherits="Modules_HR_HrHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="padding-top: 20px">

        <div class="form-group">

            <div class="col-lg-5">
                <ul class="nav nav-list">
                    <li class="nav-header">Employee and Attendance </li>
                     <li><asp:HyperLink runat="server" NavigateUrl="~/Modules/HR/EmployeeMaster.aspx" Text="Employees"></asp:HyperLink></li>
                     <li><asp:HyperLink runat="server" NavigateUrl="~/Modules/HR/AttendanceTool_Details.aspx" Text="Employee Attendance Tool"></asp:HyperLink></li>
                     <li><asp:HyperLink runat="server" NavigateUrl="~/Modules/HR/Attendance.aspx" Text="Attendance"></asp:HyperLink></li>
                </ul>

                <ul class="nav nav-list">
                    <li class="nav-header">Leaves and Holiday </li>
                    <li><a href="LeaveApplication.aspx">Leave Application </a></li>

                      <li><a href="HODApproval.aspx">HOD Leave Approval </a></li>
                      <li><a href="HRApproval.aspx">HR Leave Approval</a></li>



                    <li><a href="LeaveType.aspx">Leave Type </a></li>
                   
                </ul>

                <ul class="nav nav-list">
                    <li class="nav-header">Expense Claims</li>
                    <li><a href="#">Employee Advance </a></li>
                    <li><a href="#">Expense Claim </a></li>
                    <li><a href="#">Expense Claim Type </a></li>
                </ul>

                <ul class="nav nav-list">
                    <li class="nav-header">Employee Loan Management </li>
                    <li><a href="#">Loan Type </a></li>
                    <li><a href="#">Employee Loan Application </a></li>
                    <li><a href="#">Employee Loan  </a></li>
                </ul>
            </div>

            <div class="col-lg-5">
                <ul class="nav nav-list">
                    <li class="nav-header">Recruitment </li>
                    <li><a href="JobApplicant.aspx">Job Applicant </a></li>
                    <li><a href="JobOpening.aspx">Job Opening </a></li>
                    <li><a href="OfferLetter.aspx">Offer Letter</a></li>
                </ul>

                <ul class="nav nav-list">
                    <li class="nav-header">Payroll  </li>
                     <li><a href="EmployeeCTC.aspx">Employee CTC </a></li>
                    <li><a href="LeaveBalance.aspx">Leave Balance </a></li>

                      <li><a href="Attendence_Report.aspx">Employee Attendance Report</a></li>
                    <li><a href="Payroll.aspx">Payroll Statement </a></li>



                    <li><a href="PaySlip_New.aspx">Salary Slip </a></li>
                 <%--   <li><a href="#">Payroll Entry </a></li>
                    <li><a href="SalaryStructure.aspx">Salary Structure </a></li>
                    <li><a href="SalaryComponent.aspx">Salary Components</a></li>--%>
                </ul>

                <ul class="nav nav-list">
                    <li class="nav-header">Setup</li>
                    <li><asp:HyperLink runat="server" NavigateUrl="~/Modules/HR/Users.aspx" Text="Users"></asp:HyperLink></li>
                    <li><asp:HyperLink runat="server" NavigateUrl="~/Modules/Masters/Company.aspx" Text="Company"></asp:HyperLink></li>
                    <li><asp:HyperLink runat="server" NavigateUrl="~/Modules/Masters/Department.aspx" Text="Department"></asp:HyperLink></li>
                    <li><asp:HyperLink runat="server" NavigateUrl="~/Modules/Masters/Designation.aspx" Text="Designation / Job Title"></asp:HyperLink></li>
                    <li><asp:HyperLink runat="server" NavigateUrl="~/Modules/HR/GradeMaster.aspx" Text="Grade"></asp:HyperLink></li>
                    <li><asp:HyperLink runat="server" NavigateUrl="~/Modules/HR/OfferTerms.aspx" Text="Offer Terms Template"></asp:HyperLink></li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>