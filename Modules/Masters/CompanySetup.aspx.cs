using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_CompanySetup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if(!IsPostBack)
        {
            
            if (Qid != "Add")
            {

                CompanyProfileSelect();

            }
        }
    }

    #region CompanyProfileUpdate
    private void CompanyProfileUpdate()
    {
        try
        {
            Masters.CompanyProfile objMaster = new Masters.CompanyProfile();
            objMaster.Cpid = "1";  
            objMaster.fullname = txtCompanyfullName.Text;
            objMaster.shortname = txtcompnayshortname.Text;
            objMaster.address = txtaddress.Text;
            objMaster.ceo = txtCEO.Text;
            objMaster.foundataiondate = phani.Classes.General.toMMDDYYYY(txtFoundationDate.Text);
            objMaster.phoneoffice = txtphoneoffice.Text;
            objMaster.email = txtEmail.Text;
            objMaster.mobile = txtMobile.Text;
            objMaster.faxno = txtfax.Text;
            objMaster.address = txtaddress.Text;
            objMaster.gst = txtgst.Text;
            objMaster.cfyear = txtCurrentFinancialYear.Text;
            MessageBox.Show(this, objMaster.CompanyProfile_Update());

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Masters.ClearControls(this);
            Masters.Dispose();
        }
    }
    #endregion

    #region CompanyProfileSelect
    private void CompanyProfileSelect()
    {
        try
        {
            Masters.CompanyProfile objMaster = new Masters.CompanyProfile();
            if (objMaster.CompanyProfile_Select(Request.QueryString["Cid"].ToString()) > 0)
            {
                btnSave.Text = "Update";
                 txtCompanyfullName.Text = objMaster.fullname;
                txtcompnayshortname.Text = objMaster.shortname;
                 txtaddress.Text = objMaster.address;
                txtCEO.Text = objMaster.ceo;
                txtFoundationDate.Text = objMaster.foundataiondate;
               txtphoneoffice.Text = objMaster.phoneoffice;
                 txtEmail.Text = objMaster.email;
               txtMobile.Text = objMaster.mobile;
                txtfax.Text = objMaster.faxno;
                 txtaddress.Text = objMaster.address;
               txtgst.Text = objMaster.gst;
                 txtCurrentFinancialYear.Text = objMaster.cfyear;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Masters.Dispose();
        }
    }
    #endregion






    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (btnSave.Text == "Save")
        {
            CompanyProfileSave();
        }
        else if (btnSave.Text == "Update")
        {
            CompanyProfileUpdate();
        }


       
    }

    private void CompanyProfileSave()
    {
        try
        {
            Masters.CompanyProfile objMaster = new Masters.CompanyProfile();
            //objMaster.Cpid = "1";
            objMaster.fullname = txtCompanyfullName.Text;
            objMaster.shortname = txtcompnayshortname.Text;
            objMaster.address = txtaddress.Text;
            objMaster.ceo = txtCEO.Text;
            objMaster.foundataiondate = phani.Classes.General.toMMDDYYYY(txtFoundationDate.Text);
            objMaster.phoneoffice = txtphoneoffice.Text;
            objMaster.email = txtEmail.Text;
            objMaster.mobile = txtMobile.Text;
            objMaster.faxno = txtfax.Text;
            objMaster.address = txtaddress.Text;
            objMaster.gst = txtgst.Text;
            objMaster.cfyear = txtCurrentFinancialYear.Text;
            MessageBox.Show(this, objMaster.CompanyProfile_Save());

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Masters.ClearControls(this);
            Masters.Dispose();

            Response.Redirect("~/Modules/Masters/Company.aspx");

        }
    }
}