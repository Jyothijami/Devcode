using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_PaymentTerm_Detail : System.Web.UI.Page
{
   
 protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

        

        if(!IsPostBack)
        {
            if (Qid != "Add")
            {

                CategoryFill();

            }
        }
    }

    private void CategoryFill()
    {
        Masters.PaymentTerms objmaster = new Masters.PaymentTerms();
        if (objmaster.Payment_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtPaymentTerm.Text = objmaster.Name;
            txtDescription.Text = HttpUtility.HtmlDecode(objmaster.Desc);
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if(btnSave.Text == "Save")
        {
            try
            {
                Masters.PaymentTerms objMaster = new Masters.PaymentTerms();
                objMaster.Name = txtPaymentTerm.Text;
                objMaster.Desc = HttpUtility.HtmlEncode(txtDescription.Text); 
                MessageBox.Notify(this, objMaster.PaymetnTerms_Save());
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

        if(btnSave.Text == "Update")
        {
            try
            {
                Masters.PaymentTerms objMaster = new Masters.PaymentTerms();
                objMaster.Id = Request.QueryString["Cid"].ToString();
                objMaster.Name = txtPaymentTerm.Text;
                objMaster.Desc = HttpUtility.HtmlEncode(txtDescription.Text); 
                MessageBox.Notify(this, objMaster.PaymentMaster_Update());
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