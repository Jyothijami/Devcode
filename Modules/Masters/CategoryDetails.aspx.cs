using phani.MessageBox;
using System;

public partial class Modules_Masters_CategoryDetails : System.Web.UI.Page
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
        Masters.ItemCategory objmaster = new Masters.ItemCategory();
        if (objmaster.ItemCategory_Select(Request.QueryString["Cid"].ToString()) > 0)
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
                Masters.ItemCategory objMaster = new Masters.ItemCategory();
                objMaster.ItCategoryName = txtCategoryName.Text;
                objMaster.ItCategoryDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.ItemCategory_Save());
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
                Masters.ItemCategory objMaster = new Masters.ItemCategory();
                objMaster.ItCategoryId = Request.QueryString["Cid"].ToString();
                objMaster.ItCategoryName = txtCategoryName.Text;
                objMaster.ItCategoryDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.ItemCategory_Update());
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