using phani.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_DashLeave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);
        if (!IsPostBack)
        {
            gridbind();
        }
    }

    private void gridbind()
    {
        General.GridBindwithCommand(hai, "select *,EMP_FIRST_NAME+' '+EMP_LAST_NAME as EMPName from Leave_Application,Employee_Master where Leave_Application.Emp_Id = Employee_Master.EMP_ID and Leave_Application.Emp_Id = '" + Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId) + "'");
    }



    //protected void btnAddnew_Click(object sender, EventArgs e)
    //{
    //    string N = "Add";
    //    Response.Redirect("~/Modules/LeaveApplication_Details?Cid=" + N);
    //}



}