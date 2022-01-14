using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_SubCateogoryDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string Qid = Request.QueryString["Cid"].ToString();

        if (Qid != "Add")
        {

            SubCategoryFill();

        }

        if (!IsPostBack)
        {
            Masters.ItemCategory.ItemCategory_Select(ddlCategory);
        }
    }

    private void SubCategoryFill()
    {
        Masters.ItemSubCategory objmaster = new Masters.ItemSubCategory();
        if (objmaster.SubItemCategory_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtSubcategory.Text = objmaster.ItsubCategoryName;
            txtDescription.Text = objmaster.ItsubCategoryDesc;
            ddlCategory.SelectedValue = objmaster.Catid;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.ItemSubCategory objMaster = new Masters.ItemSubCategory();
                objMaster.ItsubCategoryName = txtSubcategory.Text;
                objMaster.ItsubCategoryDesc = txtDescription.Text;
                objMaster.Catid = ddlCategory.SelectedItem.Value;

                MessageBox.Notify(this, objMaster.ItemSubCategory_Save());
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
                Masters.ItemSubCategory objMaster = new Masters.ItemSubCategory();
                objMaster.ItsubCategoryName = txtSubcategory.Text;
                objMaster.ItsubCategoryDesc = txtDescription.Text;
                objMaster.Catid = ddlCategory.SelectedItem.Value;
                objMaster.ItsubCategoryId = Request.QueryString["Cid"].ToString();
                MessageBox.Notify(this, objMaster.ItemSubCategory_Update());
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