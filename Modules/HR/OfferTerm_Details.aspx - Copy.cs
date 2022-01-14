using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_OfferTerm_Details : System.Web.UI.Page
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
        HR.OfferTerms objmaster = new HR.OfferTerms();
        if (objmaster.OfferTerms_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtofferterm.Text = objmaster.OfferTerm;
            txtDescription.Text = HttpUtility.HtmlDecode(objmaster.OfferTermsDesc);
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                HR.OfferTerms objMaster = new HR.OfferTerms();
                objMaster.OfferTerm = txtofferterm.Text;
                objMaster.OfferTermsDesc = HttpUtility.HtmlEncode(txtDescription.Text);
                MessageBox.Notify(this, objMaster.OfferTerms_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
                Response.Redirect("~/Modules/HR/OfferTerms.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                HR.OfferTerms objMaster = new HR.OfferTerms();
                objMaster.OfferTermsId = Request.QueryString["Cid"].ToString();
                objMaster.OfferTerm = txtofferterm.Text;
                objMaster.OfferTermsDesc = HttpUtility.HtmlEncode(txtDescription.Text);
                MessageBox.Notify(this, objMaster.OfferTerms_Update());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
                Response.Redirect("~/Modules/HR/OfferTerms.aspx");
            }
        }

    }

}