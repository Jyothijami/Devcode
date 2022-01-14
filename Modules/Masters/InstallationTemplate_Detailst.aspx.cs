using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_InstallationTemplate_Detailst : System.Web.UI.Page
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
        Masters.Installationtech objmaster = new Masters.Installationtech();
        if (objmaster.Installationtech_Select(Request.QueryString["Cid"].ToString()) > 0)
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
                Masters.Installationtech objMaster = new Masters.Installationtech();
                objMaster.Name = txtConditionsName.Text;
                objMaster.Desc = HttpUtility.HtmlEncode(txtDescription.Text);
                MessageBox.Show(this, objMaster.Installationtech_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/Installation_Template.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                Masters.Installationtech objMaster = new Masters.Installationtech();
                objMaster.Id = Request.QueryString["Cid"].ToString();
                objMaster.Name = txtConditionsName.Text;
                objMaster.Desc = HttpUtility.HtmlEncode(txtDescription.Text);
                MessageBox.Notify(this, objMaster.Installationtech_Update());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/Installation_Template.aspx");
            }
        }
    }
}