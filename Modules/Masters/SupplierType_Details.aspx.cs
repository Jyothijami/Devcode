using phani.MessageBox;
using System;

public partial class Modules_Masters_SupplierType_Details : System.Web.UI.Page
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
        Masters.SupplierType objmaster = new Masters.SupplierType();
        if (objmaster.SupplierType_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtsupplierType.Text = objmaster.Name;
            txtDescription.Text = objmaster.Desc;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.SupplierType objMaster = new Masters.SupplierType();
                objMaster.Name = txtsupplierType.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.SupplierType_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/SupplierType.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                Masters.SupplierType objMaster = new Masters.SupplierType();
                objMaster.Id = Request.QueryString["Cid"].ToString();
                objMaster.Name = txtsupplierType.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.SupplierType_Update());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/SupplierType.aspx");
            }
        }
    }
}