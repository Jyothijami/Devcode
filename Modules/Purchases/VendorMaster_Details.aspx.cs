using phani.MessageBox;
using Phani.Modules;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
public partial class Modules_Purchases_VendorMaster_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

        if (!IsPostBack)
        {
            CountryFill();
            SupplierType();
            if (Qid != "Add")
            {

                Supplierfill();


            }
        }
    }

    private void Supplierfill()
    {
        SCM.SuppliersMaster objmaster = new SCM.SuppliersMaster();
        if (objmaster.SuppliersMaster_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            ddlTitle.SelectedValue = objmaster.Title;
            ddlSupplierType.SelectedValue = objmaster.Catid;
            txtVendorAddress.Text = objmaster.SupAddress;
            txtVendorName.Text = objmaster.SupName;
            txtContactPerson.Text = objmaster.SupContactPerson;
            txtVendorAddress.Text =  HttpUtility.HtmlDecode(objmaster.SupAddress);
           // txtContactPersondetails.Text = objmaster.SupContactPersonDetails;
            txtphoneno.Text = objmaster.SupPhone;
            txtMobileNo.Text = objmaster.SupMobile;
            txtEmail.Text = objmaster.SupEmail;
            txtFaxno.Text = objmaster.SupFaxNo;
            txtpanno.Text = objmaster.SupPanNo;
            txtCstno.Text = objmaster.SupCstNo;
            txtvatno.Text = objmaster.SupVatNo;
            txtgstno.Text = objmaster.SupGstNo;

            ddlCountry.SelectedValue = objmaster.Countryid;
            ddlCountry_SelectedIndexChanged(new object(), new System.EventArgs());


        }
    }

    private void SupplierType()
    {
        Masters.SupplierType.SupplierType_Select(ddlSupplierType);
    }

   

    private void CountryFill()
    {
        Masters.Country.Country_Select(ddlCountry);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
               // SCM.BeginTransaction();
                SCM.SuppliersMaster objSCM = new SCM.SuppliersMaster();
                objSCM.SupName = txtVendorName.Text;
                objSCM.SupContactPerson = txtContactPerson.Text;
                objSCM.SupAddress = HttpUtility.HtmlEncode(txtVendorAddress.Text);
                objSCM.SupContactPersonDetails = "-";
                objSCM.SupPhone = txtphoneno.Text;
                objSCM.SupMobile = txtMobileNo.Text;
                objSCM.SupEmail = txtEmail.Text;
                objSCM.SupFaxNo = txtFaxno.Text;
                objSCM.SupPanNo = txtpanno.Text;
                objSCM.SupCstNo = txtCstno.Text;
                objSCM.SupVatNo = txtvatno.Text;
                objSCM.SupGstNo = txtgstno.Text;
                objSCM.Catid = ddlSupplierType.SelectedItem.Value;
                objSCM.Countryid = ddlCountry.SelectedItem.Value;
                objSCM.Title = ddlTitle.SelectedItem.Value;
                MessageBox.Show(this, objSCM.SuppliersMaster_Save());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
              //  SCM.CommitTransaction();
            }
            catch (Exception ex)
            {
               // SCM.RollBackTransaction();
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                SCM.ClearControls(this);
               // SCM.Dispose();
               // Response.Redirect("~/Modules/Purchases/VendorMaster.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
              //  SCM.BeginTransaction();
                SCM.SuppliersMaster objSCM = new SCM.SuppliersMaster();
                objSCM.SupId = Request.QueryString["Cid"].ToString();
                objSCM.SupName = txtVendorName.Text;
                objSCM.SupContactPerson = txtContactPerson.Text;
                objSCM.SupAddress = HttpUtility.HtmlEncode(txtVendorAddress.Text);
                objSCM.SupContactPersonDetails = "-";
                objSCM.SupPhone = txtphoneno.Text;
                objSCM.SupMobile = txtMobileNo.Text;
                objSCM.SupEmail = txtEmail.Text;
                objSCM.SupFaxNo = txtFaxno.Text;
                objSCM.SupPanNo = txtpanno.Text;
                objSCM.SupCstNo = txtCstno.Text;
                objSCM.SupVatNo = txtvatno.Text;
                objSCM.SupGstNo = txtgstno.Text;
                objSCM.Catid = ddlSupplierType.SelectedItem.Value;
                objSCM.Countryid = ddlCountry.SelectedItem.Value;
                MessageBox.Show(this, objSCM.SuppliersMaster_Update());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
               // SCM.CommitTransaction();
            }
            catch (Exception ex)
            {
              //  SCM.RollBackTransaction();
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                SCM.ClearControls(this);
              //  SCM.Dispose();
               // Response.Redirect("~/Modules/Purchases/VendorMaster.aspx");
            }
        }









    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.Country obj = new Masters.Country();
        if(obj.Country_Select(ddlCountry.SelectedItem.Value) > 0)
        {
            txtBillingCurrency.Text = obj.cURRENCY;
        }
    }
}