using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_IndustryType_Details : System.Web.UI.Page
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
        Masters.IndustryType objmaster = new Masters.IndustryType();
        if (objmaster.IndustryType_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtIndustryTypeName.Text = objmaster.Name;
            txtDescription.Text = objmaster.Desc;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.IndustryType objMaster = new Masters.IndustryType();
                objMaster.Name = txtIndustryTypeName.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.IndustryType_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/IndustryType.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                Masters.IndustryType objMaster = new Masters.IndustryType();
                objMaster.Id = Request.QueryString["Cid"].ToString();
                objMaster.Name = txtIndustryTypeName.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.IndustryType_Update());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/IndustryType.aspx");
            }
        }

    }

}