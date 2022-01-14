using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Modules_Masters_StorageLocation_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();

        

        if (!IsPostBack)
        {
            Masters.CompanyProfile.Company_Select(ddlCompany);

            if (Qid != "Add")
            {

                Fill();

            }
        }
    }

    private void Fill()
    {
        Masters.StorageLocation objmaster = new Masters.StorageLocation();
        if (objmaster.Stroage_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";

            ddlCompany.SelectedValue = objmaster.Cpid;
            ddlCompany_SelectedIndexChanged(new object(), new System.EventArgs());
            ddlPlant.SelectedValue = objmaster.PlantId;
            txtStroageLocName.Text = objmaster.StoreageLocName;
            txtDescription.Text = objmaster.Desc;
           
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.StorageLocation objMaster = new Masters.StorageLocation();
                objMaster.Cpid = ddlCompany.SelectedItem.Value;
                objMaster.PlantId = ddlPlant.SelectedItem.Value;
                objMaster.StoreageLocName = txtStroageLocName.Text;
                objMaster.StorageLocDesc = txtDescription.Text;

                MessageBox.Notify(this, objMaster.StorageLoc_Save());
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
                Masters.StorageLocation objMaster = new Masters.StorageLocation();
                objMaster.Cpid = ddlCompany.SelectedItem.Value;
                objMaster.PlantId = ddlPlant.SelectedItem.Value;
                objMaster.StoreageLocName = txtStroageLocName.Text;
                objMaster.StorageLocDesc = txtDescription.Text;
                objMaster.SLid = Request.QueryString["Cid"].ToString();
                MessageBox.Notify(this, objMaster.StorageLoc_Update());
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
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.Plant.Company_Plant_Select(ddlPlant, ddlCompany.SelectedItem.Value);
    }
}