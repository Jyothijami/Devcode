using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_UnitDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

        if (Qid != "Add")
        {

            Fill();

        }

        if (!IsPostBack)
        {

        }
    }

    private void Fill()
    {
        Masters.UnitMaster objmaster = new Masters.UnitMaster();
        if (objmaster.Unit_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtCategoryName.Text = objmaster.UOMName;
            txtDescription.Text = objmaster.UOMDesc;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.UnitMaster objMaster = new Masters.UnitMaster();
                objMaster.UOMName = txtCategoryName.Text;
                objMaster.UOMDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.UnitMaster_Save());
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
                Masters.UnitMaster objMaster = new Masters.UnitMaster();
                objMaster.UOMId = Request.QueryString["Cid"].ToString();
                objMaster.UOMName = txtCategoryName.Text;
                objMaster.UOMDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.UnitMaster_Update());
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