using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_Incoterm_Details : System.Web.UI.Page
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
        Masters.IncoTerms objmaster = new Masters.IncoTerms();
        if (objmaster.IncoTerms_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtIncoTermsName.Text = objmaster.Name;
            txtDescription.Text = objmaster.Desc;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.IncoTerms objMaster = new Masters.IncoTerms();
                objMaster.Name = txtIncoTermsName.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.IncoTerms_Save());
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
                Masters.IncoTerms objMaster = new Masters.IncoTerms();
                objMaster.Id = Request.QueryString["Cid"].ToString();
                objMaster.Name = txtIncoTermsName.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.IncoTerms_Update());
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