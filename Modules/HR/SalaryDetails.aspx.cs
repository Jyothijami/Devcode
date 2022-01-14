using phani.Classes;
using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_SalaryDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Masters.Department.Department_Select(ddlEmployeeCategory);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlEmpId);

            gvEmployeeSalaryDetails.DataBind();

        }
    }
    protected void ddlEmpId_SelectedIndexChanged(object sender, EventArgs e)
    {
        HR.SalaryDetails obj = new HR.SalaryDetails();
        obj.SalaryDetails_Go(ddlEmpId.SelectedItem.Value);
        txtName.Text = obj.EmpName;
        txtBasicSalary.Text = obj.BasicSalary;
        ddlEmployeeCategory.SelectedValue = obj.Emp_Category_Id;
        ddlEmployeeCategory_SelectedIndexChanged(sender, e);

        String GridCommand = " SELECT Employee_Master.EMP_FIRST_NAME, Salary_Component.SalaryComp_Name,  " +
                                                        " Salary_Structure.ALLOWANCE_SETUP_TYPE, Salary_Structure.ALLOWANCE_SETUP_AMOUNT " +
                                                        " FROM " +
                                                        " Salary_Structure,Salary_Component, Employee_Master,Department_Master " +
                                                        " WHERE " +
                                                        " Salary_Structure.ALLOWANCE_MASTER_ID = Salary_Component.SalaryComp_id AND " +
                                                        " Salary_Structure.ALLOWANCE_SETUP_ID = Department_Master.DEPT_ID AND " +
                                                     
                                                        " Employee_Master.EMP_ID = '" + ddlEmpId.SelectedItem.Value + "'";


        General.GridBindwithCommand(gvEmployeeSalaryDetails, GridCommand);
        
    }
    protected void ddlEmployeeCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Gridbind(Convert.ToInt16(ddlEmployeeCategory.SelectedItem.Value));
    }
    #region GridBind
    public void Gridbind(int Employee_Category_Id)
    {
        General.GridBindwithCommand(gvAllowanceDetails, "select * from Salary_Structure,Department_Master,Salary_Component where Salary_Structure.Categoryid=Department_Master.DEPT_ID and Salary_Structure.ALLOWANCE_MASTER_ID=Salary_Component.SalaryComp_id and Department_Master.DEPT_ID = " + ddlEmployeeCategory.SelectedItem.Value + "");
    }
    #endregion



    #region RowDataBound
    protected void gvAllowanceDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Visible = false;
        }
    }
    #endregion




    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;

            foreach (GridViewRow gvr in gvAllowanceDetails.Rows)
            {
                CheckBox chkselect = gvr.FindControl("cblSelect") as CheckBox;
                if ((chkselect != null) && chkselect.Checked)
                {
                    count = count + 1;
                }
            }
            if (count == 0)
            {
                MessageBox.Show(this, "Please Select Atleast One Allowance");
            }
            else
            {
                HR.SalaryDetails obj = new HR.SalaryDetails();
                MessageBox.Show(this, obj.SalaryDetails_Save(ddlEmpId.SelectedItem.Value.ToString(), Convert.ToDouble(txtBasicSalary.Text), gvAllowanceDetails));
            }


        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);

        }

    }
    protected void gvEmployeeSalaryDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    //add the thead and tbody section programatically
        //    e.Row.TableSection = TableRowSection.TableHeader;
        //}


        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[2].Visible = false;
        }

    }
}