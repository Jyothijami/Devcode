using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_PackingMaterial_Details : System.Web.UI.Page
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
        Masters.PackingMaterial objmaster = new Masters.PackingMaterial();
        if (objmaster.PackingMaterial_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtCategoryName.Text = objmaster.Name;
            txtDescription.Text = objmaster.Desc;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.PackingMaterial objMaster = new Masters.PackingMaterial();
                objMaster.Name = txtCategoryName.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.PackingMaterial_Save());
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
                Masters.PackingMaterial objMaster = new Masters.PackingMaterial();
                objMaster.Mtid = Request.QueryString["Cid"].ToString();
                objMaster.Name = txtCategoryName.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.PackingMaterial_Update());
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