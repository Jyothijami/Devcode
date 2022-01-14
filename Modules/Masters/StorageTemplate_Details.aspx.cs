using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_StorageTemplate_Details : System.Web.UI.Page
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
        Masters.SalesStorage objmaster = new Masters.SalesStorage();
        if (objmaster.SalesStorage_Select(Request.QueryString["Cid"].ToString()) > 0)
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
                Masters.SalesStorage objMaster = new Masters.SalesStorage();
                objMaster.Name = txtConditionsName.Text;
                objMaster.Desc = HttpUtility.HtmlEncode(txtDescription.Text);
                MessageBox.Show(this, objMaster.SalesStorage_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/Storage_Template.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                Masters.SalesStorage objMaster = new Masters.SalesStorage();
                objMaster.Id = Request.QueryString["Cid"].ToString();
                objMaster.Name = txtConditionsName.Text;
                objMaster.Desc = HttpUtility.HtmlEncode(txtDescription.Text);
                MessageBox.Notify(this, objMaster.SalesStorage_Update());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/Storage_Template.aspx");
            }
        }
    }
}