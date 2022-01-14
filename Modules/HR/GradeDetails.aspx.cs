using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_GradeDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

        if (!IsPostBack)
        {
            if (Qid != "Add")
            {
                CategoryFill();
            }
        }
    }

    private void CategoryFill()
    {
        Masters.GradeMaster objmaster = new Masters.GradeMaster();
        if (objmaster.GradeMaster_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtCategoryName.Text = objmaster.ItCategoryName;
            txtDescription.Text = objmaster.ItCategoryDesc;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.GradeMaster objMaster = new Masters.GradeMaster();
                objMaster.ItCategoryName = txtCategoryName.Text;
                objMaster.ItCategoryDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.GradeMaster_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/HR/GradeMaster.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                Masters.GradeMaster objMaster = new Masters.GradeMaster();
                objMaster.ItCategoryId = Request.QueryString["Cid"].ToString();
                objMaster.ItCategoryName = txtCategoryName.Text;
                objMaster.ItCategoryDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.GradeMaster_Update());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/HR/GradeMaster.aspx");
            }
        }
    }
}