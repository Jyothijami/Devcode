using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_Country_Details : System.Web.UI.Page
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
        Masters.Country objmaster = new Masters.Country();
        if (objmaster.Country_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtCountryName.Text = objmaster.CountryName;
            txtCurrency.Text = objmaster.cURRENCY;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.Country objMaster = new Masters.Country();
                objMaster.CountryName = txtCountryName.Text;
                objMaster.cURRENCY = txtCurrency.Text;
                MessageBox.Show(this, objMaster.Country_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/Country.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                Masters.Country objMaster = new Masters.Country();
                objMaster.CountryId = Request.QueryString["Cid"].ToString();
                objMaster.CountryName = txtCountryName.Text;
                objMaster.cURRENCY = txtCurrency.Text;
                MessageBox.Show(this, objMaster.Country_Update());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);
                Masters.Dispose();
                Response.Redirect("~/Modules/Masters/Country.aspx");
            }
        }
    }
}