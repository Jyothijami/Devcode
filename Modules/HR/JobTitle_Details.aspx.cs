using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_JobTitle_Details : System.Web.UI.Page
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
        Masters.JobTitle objmaster = new Masters.JobTitle();
        if (objmaster.JobTitle_Select(Request.QueryString["Cid"].ToString()) > 0)
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
                Masters.JobTitle objMaster = new Masters.JobTitle();
                objMaster.ItCategoryName = txtCategoryName.Text;
                objMaster.ItCategoryDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.JobTitle_Save());
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
                Masters.JobTitle objMaster = new Masters.JobTitle();
                objMaster.ItCategoryId = Request.QueryString["Cid"].ToString();
                objMaster.ItCategoryName = txtCategoryName.Text;
                objMaster.ItCategoryDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.JobTitle_Update());
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