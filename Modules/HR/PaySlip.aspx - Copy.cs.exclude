using phani.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_PaySlip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            HR.EmployeeMaster.EmployeeMaster_Select(ddlEmpId);
            txtYear.Text = DateTime.Now.Year.ToString();
        }
    }
    protected void ddlEmpId_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMonth.SelectedIndex = ddlMonth.Items.IndexOf(ddlMonth.Items.FindByValue("SELECT"));
        txtNoOfPresentDays.Text = "";
        txtNoAbsentDays.Text = "";
        txtNoOfLeaveDays.Text = "";
        txtNoOfHalfLeaveDays.Text = "";
        HR.EmployeeMaster obj = new HR.EmployeeMaster();
        if(obj.EmployeeMaster_Select(ddlEmpId.SelectedItem.Value) > 0)
        {
             txtName.Text = obj.EmpFirstName.ToString();
             txtBasicSalary.Text = obj.sALARY.ToString();
        }

//        General.GridBindwithCommand(gvEmpAllowanceDetails, "SELECT Employee_Master.EMP_FIRST_NAME, " +
//" Department_Master.DEPT_NAME,Employee_Master.EMP_SALARY,Salary_Component.SalaryComp_Name," +
//" Employee_SalaryDetails.ALLOWANCE_SETUP_TYPE,Employee_SalaryDetails.AMOUNT FROM " +
//" Employee_SalaryDetails,Employee_Master,Salary_Structure,Salary_Component,Employee_Details " +
//" Department_Master WHERE " +
//" Employee_SalaryDetails.ALLOWANCE_SETUP_ID=Salary_Structure.ALLOWANCE_SETUP_ID AND " +
//" Employee_SalaryDetails.EMP_ID=Employee_Master.EMP_ID AND " +
//" Salary_Structure.ALLOWANCE_MASTER_ID= Salary_Component.ALLOWANCE_MASTER_ID AND " +
//" Employee_Master.EMP_ID=Employee_Details.EMP_ID AND " +
//" Employee_Details.DEPT_ID=Department_Master.DEPT_ID AND " +
//            //" Employee_SalaryDetails.EMP_ID=" + int.Parse (ddlEmpWise.SelectedItem.Value) + "");
//" Employee_SalaryDetails.EMP_ID='" + (ddlEmpId.SelectedItem.Value) + "'");


        General.GridBindwithCommand(gvEmpAllowanceDetails, "Select * from Employee_SalaryDetails,Salary_Structure,Employee_Master,Salary_Component where Employee_SalaryDetails.EMP_ID = Employee_Master.EMP_ID and Employee_SalaryDetails.ALLOWANCE_SETUP_ID = Salary_Structure.ALLOWANCE_SETUP_ID and Salary_Structure.ALLOWANCE_MASTER_ID = Salary_Component.SalaryComp_id    and Employee_SalaryDetails.EMP_ID = '" + (ddlEmpId.SelectedItem.Value) + "'");


       
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        int DaysinMonth = DateTime.DaysInMonth(int.Parse(txtYear.Text), Convert.ToInt16(ddlMonth.SelectedItem.Value));
        lblNoOfDays.Text = DaysinMonth.ToString();
        int CurrentYear = int.Parse(txtYear.Text);
        int CurrentMonth = Convert.ToInt16(ddlMonth.SelectedItem.Value);

        txtNoOfPresentDays.Text = Convert.ToString(General.CountofRecordsWithQuery("select count(*) from Employee_Attendance where Attendance_Date>='" + CurrentMonth + "/01/" + CurrentYear + "' and Attendance_Date<= '" + CurrentMonth + " /" + DaysinMonth + "/" + CurrentYear + "' and Status = 'Present' AND Emp_Id='" + ddlEmpId.SelectedItem.Value + "'"));
        txtNoAbsentDays.Text = Convert.ToString(General.CountofRecordsWithQuery("select count(*) from Employee_Attendance where Attendance_Date>='" + CurrentMonth + "/01/" + CurrentYear + "' and Attendance_Date<= '" + CurrentMonth + " /" + DaysinMonth + "/" + CurrentYear + "' and Status = 'Absent' AND Emp_Id='" + ddlEmpId.SelectedItem.Value + "'"));
        txtNoOfLeaveDays.Text = Convert.ToString(General.CountofRecordsWithQuery("select count(*) from Employee_Attendance where Attendance_Date>='" + CurrentMonth + "/01/" + CurrentYear + "' and Attendance_Date<= '" + CurrentMonth + " /" + DaysinMonth + "/" + CurrentYear + "' and Status = 'Leave' AND Emp_Id='" + ddlEmpId.SelectedItem.Value + "'"));
        txtNoOfHalfLeaveDays.Text = Convert.ToString(General.CountofRecordsWithQuery("select count(*) from Employee_Attendance where Attendance_Date>='" + CurrentMonth + "/01/" + CurrentYear + "' and Attendance_Date<= '" + CurrentMonth + " /" + DaysinMonth + "/" + CurrentYear + "' and Status = 'Half Day'AND Emp_Id='" + ddlEmpId.SelectedItem.Value + "'"));

    }
}