using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_DepartmentDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

        

        if (!IsPostBack)
        {

            HR.EmployeeMaster.EmployeeMaster_Select(ddlemployee);

            if (Qid != "Add")
            {

                DepartmentFill();

            }
        }
    }

    private void DepartmentFill()
    {
        Masters.Department objmaster = new Masters.Department();
        if (objmaster.Department_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtCategoryName.Text = objmaster.DeptName;
            txtDescription.Text = objmaster.DeptDesc;
            ddlemployee.SelectedValue = objmaster.empid;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.Department objMaster = new Masters.Department();
                objMaster.DeptName = txtCategoryName.Text;
                objMaster.DeptDesc = txtDescription.Text;
                objMaster.empid = ddlemployee.SelectedItem.Value;
                MessageBox.Notify(this, objMaster.Department_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                Masters.ClearControls(this);
                Masters.Dispose();
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                Masters.Department objMaster = new Masters.Department();
                objMaster.DeptId = Request.QueryString["Cid"].ToString();
                objMaster.DeptName = txtCategoryName.Text;
                objMaster.DeptDesc = txtDescription.Text;
                objMaster.empid = ddlemployee.SelectedItem.Value;
                MessageBox.Notify(this, objMaster.Department_Update());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                Masters.ClearControls(this);
                Masters.Dispose();
            }
        }

    }
   
}