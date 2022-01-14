using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_EnquiryDetails : System.Web.UI.Page
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
        Masters.EnquiryMode objmaster = new Masters.EnquiryMode();
        if (objmaster.Enquiry_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtCategoryName.Text = objmaster.EnqmName;
            txtDescription.Text = objmaster.EnqmDesc;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.EnquiryMode objMaster = new Masters.EnquiryMode();
                objMaster.EnqmName = txtCategoryName.Text;
                objMaster.EnqmDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.EnquiryMode_Save());
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
                Masters.EnquiryMode objMaster = new Masters.EnquiryMode();
                objMaster.EnqmId = Request.QueryString["Cid"].ToString();
                objMaster.EnqmName = txtCategoryName.Text;
                objMaster.EnqmDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.EnquiryMode_Update());
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