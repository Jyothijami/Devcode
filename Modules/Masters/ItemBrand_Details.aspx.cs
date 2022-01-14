using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_ItemBrand_Details : System.Web.UI.Page
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
        Masters.ItemBrand objmaster = new Masters.ItemBrand();
        if (objmaster.ItemBrand_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtBrandname.Text = objmaster.ItemBrandName;
            txtDescription.Text = objmaster.ItemBrandDesc;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.ItemBrand objMaster = new Masters.ItemBrand();
                objMaster.ItemBrandName = txtBrandname.Text;
                objMaster.ItemBrandDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.ItemBrand_Save());
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
                Masters.ItemBrand objMaster = new Masters.ItemBrand();
                objMaster.ItemBrandId = Request.QueryString["Cid"].ToString();
                objMaster.ItemBrandName = txtBrandname.Text;
                objMaster.ItemBrandDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.ItemBrand_Update());
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