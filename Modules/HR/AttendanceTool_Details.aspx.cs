using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using phani.Classes;
using System.Globalization;
public partial class Modules_HR_AttendanceTool_Details : System.Web.UI.Page
{
    string sqlcmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime date = DateTime.Now;
            txtDate.Text = date.ToString("yyyy-MM-dd");
            Masters.Department.Department_Select(ddldepartment);
          //  txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture);


        }
    }


   
    protected void ddldepartment_SelectedIndexChanged(object sender, EventArgs e)
    {

        sqlcmd = "SELECT * FROM Employee_Master,Employee_Details WHERE Employee_Master.EMP_ID = Employee_Details.EMP_ID and DEPT_ID = " + ddldepartment.SelectedItem.Value + " ";

        General.GridBindwithCommand(gvEmployeeDetails, sqlcmd);

        if (gvEmployeeDetails.Rows.Count == 0)
        {
            gvEmployeeDetails.Visible = false;
            
        }
        else
        {
            gvEmployeeDetails.Visible = true;
           
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        foreach (GridViewRow gvr in gvEmployeeDetails.Rows)
        {
            RadioButtonList rb = gvr.FindControl("rbtnlist") as RadioButtonList;

            HR.EmployeeAttendance obj = new HR.EmployeeAttendance();
            //i = i + obj.EmployeeAttendance_Save(Convert.ToInt16(gvr.Cells[0].Text.ToString()), Convert.ToDateTime(txtDate.Text), rb.SelectedValue);

          //  DateTime dt = txtDate.Text;

            i = i + obj.EmployeeAttendance_Save(gvr.Cells[0].Text, Convert.ToDateTime(txtDate.Text), rb.SelectedValue);

            //Response.Write(i.ToString() + " - " + rb.SelectedValue + "<br />");

        }
        MessageBox.Show(this, " Total " + i + " Employees Attendance Updated ");
    }
}