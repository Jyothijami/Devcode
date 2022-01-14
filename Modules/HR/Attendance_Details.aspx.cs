using phani.Classes;
using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_Attendance_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();



        if (!IsPostBack)
        {
            if (Qid != "Add")
            {

                HR.EmployeeMaster.EmployeeMaster_Select(ddlemployee);


            }
        }
    }

    private void CategoryFill()
    {
        HR.Employee_Attendance objmaster = new HR.Employee_Attendance();
        if (objmaster.Employee_Attendance_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            ddlemployee.SelectedItem.Value = objmaster.Emp_Id;
            ddlemployee_SelectedIndexChanged(new object(), new System.EventArgs());
            txtAttendanceDate.Text = objmaster.Attendance_Date;
            ddlstatus.SelectedItem.Value = objmaster.Status;

        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                HR.Employee_Attendance objMaster = new HR.Employee_Attendance();
                objMaster.Attendance_Date = General.toMMDDYYYY(txtAttendanceDate.Text);
                objMaster.Status = ddlstatus.SelectedItem.Value;
                objMaster.Emp_Id = ddlemployee.SelectedItem.Value;

              
                MessageBox.Show(this, objMaster.EmployeeAttendance_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                HR.Employee_Attendance objMaster = new HR.Employee_Attendance();
                objMaster.Attendance_Id = Request.QueryString["Cid"].ToString();
                objMaster.Attendance_Date = General.toMMDDYYYY(txtAttendanceDate.Text);
                objMaster.Status = ddlstatus.SelectedItem.Value;
                objMaster.Emp_Id = ddlemployee.SelectedItem.Value;
                MessageBox.Show(this, objMaster.Employee_Attendance_Update());


            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
            }
        }

    }

    protected void ddlemployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        HR.EmployeeMaster objmaster = new HR.EmployeeMaster();
        if (objmaster.EmployeeMaster_Select(ddlemployee.SelectedItem.Value) > 0)
        {

            txtEmployeeName.Text = objmaster.EmpLastName + "" + objmaster.EmpLastName;
            txtCompany.Text = objmaster.CompanyName;
            txtDepartment.Text = objmaster.DeptName12;
            txtEmployeetype.Text = objmaster.EmpTypeName;
            txtdesignation.Text = objmaster.DesgName12;
        }
    }
}