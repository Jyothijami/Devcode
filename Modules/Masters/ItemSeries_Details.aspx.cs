using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_ItemSeries_Details : System.Web.UI.Page
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
        Masters.ItemSeries objmaster = new Masters.ItemSeries();
        if (objmaster.ItemSeries_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtseriesName.Text = objmaster.ItemSeriesName;
            txtDescription.Text = objmaster.ItemSeriesDesc;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.ItemSeries objMaster = new Masters.ItemSeries();
                objMaster.ItemSeriesName = txtseriesName.Text;
                objMaster.ItemSeriesDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.ItemSeries_Save());

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
                Masters.ItemSeries objMaster = new Masters.ItemSeries();
                objMaster.ItemSeriesId = Request.QueryString["Cid"].ToString();
                objMaster.ItemSeriesName = txtseriesName.Text;
                objMaster.ItemSeriesDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.ItemSeries_Update());
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