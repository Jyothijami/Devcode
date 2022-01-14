using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Alumil.Authentication.Session_Check(this);
        lblUserName.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpName);
        lblEmpIdHidden.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
        lblCpIdHidden.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.CpId);
    }
    //protected void lbtnlogout_Click(object sender, EventArgs e)
    //{
    //    Alumil.Authentication.ClearSession(this);
    //}
    protected void lbtnmasters_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Modules/Masters/MastersHome.aspx");
    }
    protected void lbtnSales_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Modules/Sales/SalesHome.aspx");
    }
}
