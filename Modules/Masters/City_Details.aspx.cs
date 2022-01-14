using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_City_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();



        if (!IsPostBack)
        {
            Masters.State.State_Select(ddlState);

            if (Qid != "Add")
            {

                SubCategoryFill();

            }
        }
    }

    private void SubCategoryFill()
    {
        Masters.City objmaster = new Masters.City();
        if (objmaster.City_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtCity.Text = objmaster.CityName;
            ddlState.SelectedValue = objmaster.StateId;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.City objMaster = new Masters.City();
                objMaster.CityName = txtCity.Text;
                objMaster.StateId = ddlState.SelectedItem.Value;

                MessageBox.Notify(this, objMaster.City_Save());
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
                Masters.City objMaster = new Masters.City();
                objMaster.CityName = txtCity.Text;
                objMaster.StateId = ddlState.SelectedItem.Value;
                objMaster.CityId = Request.QueryString["Cid"].ToString();
                MessageBox.Notify(this, objMaster.City_Update());
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