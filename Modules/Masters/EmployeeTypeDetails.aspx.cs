using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_EmployeeTypeDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

        if (Qid != "Add")
        {

            DepartmentFill();

        }

        if (!IsPostBack)
        {

        }
    }

    private void DepartmentFill()
    {
        Masters.EmployeeType objmaster = new Masters.EmployeeType();
        if (objmaster.EmployeeType_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtCategoryName.Text = objmaster.EmpTypeName;
            txtDescription.Text = objmaster.EmpTypeDesc;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.EmployeeType objMaster = new Masters.EmployeeType();
                objMaster.EmpTypeName = txtCategoryName.Text;
                objMaster.EmpTypeDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.EmployeeType_Save());
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
                Masters.EmployeeType objMaster = new Masters.EmployeeType();
                objMaster.EmpTypeId = Request.QueryString["Cid"].ToString();
                objMaster.EmpTypeName = txtCategoryName.Text;
                objMaster.EmpTypeDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.EmployeeType_Update());
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