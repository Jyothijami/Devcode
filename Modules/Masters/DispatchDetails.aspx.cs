using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_DispatchDetails : System.Web.UI.Page
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
        Masters.DespatchMode objmaster = new Masters.DespatchMode();
        if (objmaster.Despatch_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtCategoryName.Text = objmaster.DespmName;
            txtDescription.Text = objmaster.DespmDesc;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.DespatchMode objMaster = new Masters.DespatchMode();
                objMaster.DespmName = txtCategoryName.Text;
                objMaster.DespmDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.DespatchMode_Save());
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
                Masters.DespatchMode objMaster = new Masters.DespatchMode();
                objMaster.DespmId = Request.QueryString["Cid"].ToString();
                objMaster.DespmName = txtCategoryName.Text;
                objMaster.DespmDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.DespatchMode_Update());
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