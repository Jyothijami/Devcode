using phani.MessageBox;
using System;
using System.Web;
using AjaxControlToolkit.HTMLEditor;
using mycontrols;

public partial class Modules_Masters_SalesTermsCondtion_Details : System.Web.UI.Page
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
        Masters.SalesTermsConditions objmaster = new Masters.SalesTermsConditions();
        if (objmaster.SalesTermsConditions_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtConditionsName.Text = objmaster.Name;
            txtDescription.Text = HttpUtility.HtmlDecode(objmaster.Desc);
            //  txtDescription.Text = objmaster.Desc;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.SalesTermsConditions objMaster = new Masters.SalesTermsConditions();
                objMaster.Name = txtConditionsName.Text;
                objMaster.Desc = HttpUtility.HtmlEncode(txtDescription.Text);
                MessageBox.Show(this, objMaster.SalesTermsConditions_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/SalesTerms_Conditions.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                Masters.SalesTermsConditions objMaster = new Masters.SalesTermsConditions();
                objMaster.Id = Request.QueryString["Cid"].ToString();
                objMaster.Name = txtConditionsName.Text;
                objMaster.Desc = HttpUtility.HtmlEncode(txtDescription.Text);
                MessageBox.Notify(this, objMaster.SalesTermsConditions_Update());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/SalesTerms_Conditions.aspx");
            }
        }
    }
   



   


}