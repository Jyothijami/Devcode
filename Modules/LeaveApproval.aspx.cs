using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using phani.Classes;
using phani.MessageBox;

public partial class Modules_LeaveApproval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string userid = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            General.GridBindwithCommand(hai, "select *,EMP_FIRST_NAME+' '+EMP_LAST_NAME as EMPName from Leave_Application,Employee_Master where Leave_Application.Emp_Id = Employee_Master.EMP_ID and HodStatus = 'Open' and Leaveapprover_id = '"+userid+"'");
            
  
        }
    }

    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlhodstatus = (DropDownList)e.Row.FindControl("ddlhodstatus");

            //Select the Desinger in DropDownList
            string Desinger = (e.Row.FindControl("lblhodstatus") as Label).Text;
            ddlhodstatus.Items.FindByValue(Desinger).Selected = true;
        }
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        LinkButton lbtnRegionalMaster;
        lbtnRegionalMaster = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnRegionalMaster.Parent.Parent;
        hai.SelectedIndex = gvRow.RowIndex;


        if (hai.SelectedIndex > -1)
        {
            try
            {
                HR.Leave_Application obj = new HR.Leave_Application();

                obj.Leave_ApplicationId = hai.SelectedRow.Cells[0].Text;

                DropDownList ddlestimationid = (DropDownList)gvRow.FindControl("ddlhodstatus");
                obj.Status = ddlestimationid.SelectedItem.Value;

                MessageBox.Show(this, obj.Leave_ApplicationApprove_Update());

            }

            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                hai.DataBind();

            }

        }
        else
        {
            MessageBox.Notify(this, "Please select atleast a Record");
        }
    }
}