using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_Operations_Details : System.Web.UI.Page
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
        Masters.OperationMaster objmaster = new Masters.OperationMaster();
        if (objmaster.Operation_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtOperation.Text = objmaster.ItCategoryName;
            txtDescription.Text = objmaster.ItCategoryDesc;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.OperationMaster objMaster = new Masters.OperationMaster();
                objMaster.ItCategoryName = txtOperation.Text;
                objMaster.ItCategoryDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.OperationMaster_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/Operations.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                Masters.OperationMaster objMaster = new Masters.OperationMaster();
                objMaster.ItCategoryId = Request.QueryString["Cid"].ToString();
                objMaster.ItCategoryName = txtOperation.Text;
                objMaster.ItCategoryDesc = txtDescription.Text;
                MessageBox.Show(this, objMaster.OperationMaster_Update());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/Operations.aspx");
            }
        }
    }
}