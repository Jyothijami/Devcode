using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_ChangePassword : System.Web.UI.Page
{

  //  int empid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string hai = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            Fill();
        }
    }


    private void Fill()
    {
        try
        {
            HR.EmployeeMaster objEM = new HR.EmployeeMaster();
            if (objEM.EmployeeMaster_Select(Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId)) > 0)
            {
              //  empid = int.Parse(objEM.EmpID);
                txtUsername.Text = objEM.EMPUserName;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {

        }
    }










    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Masters.ChangePassword obj = new Masters.ChangePassword();
            int empid = int.Parse(Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId));
            MessageBox.Show(this, obj.ChangePassword_Update(empid, txtOldpassword.Text, txtNewpassword.Text));
            Response.Redirect("~/Login.aspx");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
}