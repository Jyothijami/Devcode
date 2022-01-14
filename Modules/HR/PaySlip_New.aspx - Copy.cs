using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                //txtName.Text = objmas.EmpFirstName;
                //txtDesignation.Text = objmas.DesgName12;
                //txtDepartment.Text = objmas.DeptName12;
                //lblSal.Text = objmas.GrossSal;
                lblDOB.Text = objmas.EmpDOB;
                //lblAccNo.Text = objmas.AssignedAccNo;
                lblDOJ.Text = objmas.EmpDetDOJ;
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
            string pagenavigationstr = "../Reports/SMReportViewer.aspx?type=Payslip&siid=" + lblEmpId.Text + " &e=" + ddlMonth.SelectedValue + " &year=" + ddlYear.SelectedItem.Text + "";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
}