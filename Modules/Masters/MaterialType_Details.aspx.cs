using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_MaterialType_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

        if (!IsPostBack)
        {
            if (Qid != "Add")
            {

                DepartmentFill();

            }
        }
    }

    private void DepartmentFill()
    {
        Masters.MaterialType objmaster = new Masters.MaterialType();
        if (objmaster.MaterialType_Select(Request.QueryString["Cid"].ToString()) > 0)
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
                Masters.MaterialType objMaster = new Masters.MaterialType();
                objMaster.Name = txtCategoryName.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.MaterialType_Save());

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);


            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                Masters.ClearControls(this);
                Masters.Dispose();
               // Response.Redirect("~/Modules/Masters/MaterialType.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                Masters.MaterialType objMaster = new Masters.MaterialType();
                objMaster.Mtid = Request.QueryString["Cid"].ToString();
                objMaster.Name = txtCategoryName.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.MaterialType_Update());

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                Masters.ClearControls(this);
                Masters.Dispose();
              //  Response.Redirect("~/Modules/Masters/MaterialType.aspx");
            }
        }

    }
   
}