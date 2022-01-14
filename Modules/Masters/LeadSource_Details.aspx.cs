using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_LeadSource_Details : System.Web.UI.Page
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
        Masters.LeadSource objmaster = new Masters.LeadSource();
        if (objmaster.LeadSource_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtLeadSource.Text = objmaster.Name;
            txtDescription.Text = objmaster.Desc;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.LeadSource objMaster = new Masters.LeadSource();
                objMaster.Name = txtLeadSource.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.LeadSource_Save());
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
                Masters.LeadSource objMaster = new Masters.LeadSource();
                objMaster.Id = Request.QueryString["Cid"].ToString();
                objMaster.Name = txtLeadSource.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.LeadSource_Update());
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