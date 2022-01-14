using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_PersonalInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Department_Fill();
            Designation_Fill();
            EmployeeType_Fill();
            Fill();
        }
    }



    private void EmployeeType_Fill()
    {
        try
        {
            Masters.EmployeeType.EmployeeType_Select(ddlEmployeeType);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Masters.Dispose();
        }
    }

    #region Department Fill
    public void Department_Fill()
    {
        try
        {
            Masters.Department.Department_Select(ddlDepartment);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Masters.Dispose();
        }
    }
    #endregion

    #region Designation Fill
    public void Designation_Fill()
    {
        try
        {
            Masters.Designation.Designation_Select(ddlDesignation);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Masters.Dispose();
        }
    }
    #endregion


    private void Fill()
    {
        try
        {
            HR.EmployeeMaster objEM = new HR.EmployeeMaster();
            if (objEM.EmployeeMaster_Select(Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId)) > 0)
            {

                txtFirstName.Text = objEM.EmpFirstName;
                txtLastName.Text = objEM.EmpLastName;
               
                txtAddress.Text = objEM.EmpAddress;
                txtCity.Text = objEM.EmpCity;
                txtDateOfBirth.Text = objEM.EmpDOB;
                txtEmail.Text = objEM.EmpEMail;
                txtMobileNo.Text = objEM.EmpMobile;
                txtPhoneNo.Text = objEM.EmpPhone;
                ddlDepartment.SelectedValue = objEM.DeptID;
                ddlDesignation.SelectedValue = objEM.DesgID;
                ddlEmployeeType.SelectedValue = objEM.EmpTypeID;
               
                txtDateOfAppointment.Text = objEM.EmpDetDOJ;
                
                txtEmpSeries.Text = objEM.Empseries;
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

}