using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_State_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();

        

        if (!IsPostBack)
        {
            Masters.Country.Country_Select(ddlCountry);

            if (Qid != "Add")
            {

                SubCategoryFill();

            }
        }
    }

    private void SubCategoryFill()
    {
        Masters.State objmaster = new Masters.State();
        if (objmaster.State_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtState.Text = objmaster.StateName;
            ddlCountry.SelectedValue = objmaster.CountryId;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.State objMaster = new Masters.State();
                objMaster.StateName = txtState.Text;
                objMaster.CountryId = ddlCountry.SelectedItem.Value;

                MessageBox.Notify(this, objMaster.State_Save());
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
                Masters.State objMaster = new Masters.State();
                objMaster.StateName = txtState.Text;
                objMaster.CountryId = ddlCountry.SelectedItem.Value;
                objMaster.StateId = Request.QueryString["Cid"].ToString();
                MessageBox.Notify(this, objMaster.State_Update());
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