using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_PaySlip_New : System.Web.UI.Page
{
   SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    int yy, mn, dy;
    int sundays;
    int ttlDays, holidays;
    string Loc_Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Masters.Department.Department_Select(ddlDepartment);
            BindYears();
            GetYearValue();
            if (!IsPostBack)
            {
                HR.EmployeeMaster objmas = new HR.EmployeeMaster();
                objmas.EmployeeMaster_Select(Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId));
                lblEmpId.Text = objmas.EmpID;
                lblDeptId.Text = objmas.DeptID;
                //txtName.Text = objmas.EmpFirstName;
                //txtDesignation.Text = objmas.DesgName12;
                //txtDepartment.Text = objmas.DeptName12;
                //lblSal.Text = objmas.GrossSal;
                lblDOB.Text = objmas.EmpDOB;
                //lblAccNo.Text = objmas.AssignedAccNo;
                lblDOJ.Text = objmas.EmpDetDOJ;
                ddlDepartment.SelectedValue = lblDeptId.Text;
                ddlDepartment_SelectedIndexChanged(sender, e);
                ddlEmployee.SelectedValue = lblEmpId.Text;
                BindYears();

            }
        }
    }
    private void BindYears()
    {
        int year = DateTime.Now.Year;
        for (int i = year; i >= year - 4; i--)
        {
            ddlYear.Items.Add(i.ToString());
        }
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Get Total Days In A Month

        int month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
        yy = Convert.ToInt32(txtYear.Text);
        ttlDays = System.DateTime.DaysInMonth(yy, month);

        txtNOD.Text = ttlDays.ToString();

        //Get Total Holidays (Sundays+Holidays)

        sundays = CountSundays(Convert.ToInt32(txtYear.Text), Convert.ToInt32(ddlMonth.SelectedItem.Value));

        lblWoff.Text = sundays.ToString();

        //HR.EmployeeMaster objmas = new HR.EmployeeMaster();
        //objmas.EmployeeMaster_Select(Yantra.Authentication.GetEmployeeInSession(Yantra.Authentication.Logged_EMP_Details.EmpId));
        //Loc_Id = objmas.locid;

        SqlCommand cmd = new SqlCommand("SELECT SUM(total_days) FROM [HolidayCalender_tbl] where from_no=" + ddlMonth.SelectedItem.Value + " and from_year=" + txtYear.Text, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            string lbl = dt.Rows[0][0].ToString();
            if (lbl != "")
            {
                holidays = Convert.ToInt32(dt.Rows[0][0]);
                lblHoli.Text = holidays.ToString();

            }
            else
            {
                holidays = 0;
                lblHoli.Text = holidays.ToString();

            }
        }
        else
        {
            MessageBox.Show(this, "Please Select Proper Month");
        }

        int totalHolidays = sundays + holidays;
         txtHolidays.Text = totalHolidays.ToString();
        //BindCTCgrid();

    }
    static int CountSundays(int year, int month)
    {
        var firstDay = new DateTime(year, month, 1);

        var day29 = firstDay.AddDays(28);
        var day30 = firstDay.AddDays(29);
        var day31 = firstDay.AddDays(30);

        if ((day29.Month == month && day29.DayOfWeek == DayOfWeek.Sunday)
        || (day30.Month == month && day30.DayOfWeek == DayOfWeek.Sunday)
        || (day31.Month == month && day31.DayOfWeek == DayOfWeek.Sunday))
        {
            return 5;

        }
        else
        {
            return 4;
        }
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        HR.EmployeeMaster.EmployeeMaster_SelectDept_Comp(ddlEmployee, ddlDepartment.SelectedItem.Value);
    }
    private void GetYearValue()
    {
        String sDate = DateTime.Now.ToString();
        DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

        dy = datevalue.Day;
        mn = datevalue.Month;
        yy = datevalue.Year;

        txtYear.Text = yy.ToString();
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        //Here we need to generate our new form bhaya..
        try
        {
            string pagenavigationstr = "../Reports/SMReportViewer.aspx?type=Payslip&siid=" + ddlEmployee.SelectedItem .Value + " &e=" + ddlMonth.SelectedValue + " &year=" + ddlYear.SelectedItem.Text + "";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
}