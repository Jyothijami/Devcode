using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_DesignationDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

       

        if (!IsPostBack)
        {


            if (Qid != "Add")
            {

                Fill();

            }


        }
    }

    private void Fill()
    {
        Masters.Designation objmaster = new Masters.Designation();
        if (objmaster.Designation_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtCategoryName.Text = objmaster.DesgName;
            txtDescription.Text = objmaster.DesgDesc;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.Designation objMaster = new Masters.Designation();
                objMaster.DesgName = txtCategoryName.Text;
                objMaster.DesgDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.Designation_Save());
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
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                Masters.Designation objMaster = new Masters.Designation();
                objMaster.DesgId = Request.QueryString["Cid"].ToString();
                objMaster.DesgName = txtCategoryName.Text;
                objMaster.DesgDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.Designation_Update());
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
            }
        }

    }
}