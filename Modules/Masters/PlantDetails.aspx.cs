using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_PlantDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();

       

        if (!IsPostBack)
        {
            Masters.CompanyProfile.Company_Select(ddlCategory);


            if (Qid != "Add")
            {

                Fill();

            }
        }
    }

    private void Fill()
    {
        Masters.Plant objmaster = new Masters.Plant();
        if (objmaster.Plant_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtPlantName.Text = objmaster.Name;
            txtDescription.Text = objmaster.Desc;
            ddlCategory.SelectedValue = objmaster.Cpid;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.Plant objMaster = new Masters.Plant();
                objMaster.Name = txtPlantName.Text;
                objMaster.Desc = txtDescription.Text;
                objMaster.Cpid = ddlCategory.SelectedItem.Value;

                MessageBox.Notify(this, objMaster.Plant_Save());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);

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
                Masters.Plant objMaster = new Masters.Plant();
                objMaster.Name = txtPlantName.Text;
                objMaster.Desc = txtDescription.Text;
                objMaster.Cpid = ddlCategory.SelectedItem.Value;
                objMaster.PlantId = Request.QueryString["Cid"].ToString();
                MessageBox.Notify(this, objMaster.Plant_Update());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);

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