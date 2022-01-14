using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mobile : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Alumil.Authentication.Session_Check(this);
            string userid = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            lblUserid.Text = userid;
            //Repeater1.DataBind();

          

            // string eMPiD = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
           // image1.ImageUrl = imag2.ImageUrl = imag3.ImageUrl = string.Format("~/Modules/HR/Handler.ashx?id={0}", lblUserid.Text);
            //string.Format("~/Modules/HR/Handler.ashx?id={0}", lblUserid.Text);
            //string.Format("~/Modules/HR/Handler.ashx?id={0}", lblUserid.Text);


            lblUserName.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpName);
            lblEmpIdHidden.Text = lblUserid.Text;
            lblCpIdHidden.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.CpId);
            //image1.ImageUrl = "~/Modules/HR/Handler.ashx?id=" + Convert.ToInt16(Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId));
            //imag2.ImageUrl = "~/Modules/HR/Handler.ashx?id=" + Convert.ToInt16(Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId));
           // lblDesgination.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.Designation);

           // lblName.Text = lblUserName.Text;
           // lblname3.Text = lblName.Text;
          //  lbldepart.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.Department);

            //  imag3.ImageUrl = "~/Modules/HR/Handler.ashx?id=" + Convert.ToInt16(Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId));




        }
    }
}
