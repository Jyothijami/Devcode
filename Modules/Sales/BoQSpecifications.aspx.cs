using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_BoQSpecifications : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {

            SM.SalesEnquiry.SalesEnquiry_Select(ddlEnquiryNo);
            EnquiryFill();


        }
    }



    private void EnquiryFill()
    {
        SM.SalesEnquiry obj = new SM.SalesEnquiry();

        if (obj.SalesEnquiry_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            ddlEnquiryNo.SelectedValue = obj.Enqid;
            txtenquirydate.Text = obj.EnqDate;
            txtSpecifications.Text = HttpUtility.HtmlDecode(obj.Specificaitons);

        }


    }
    protected void ddlEnquiryNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesEnquiry obj = new SM.SalesEnquiry();
        if (obj.SalesEnquiry_Select(ddlEnquiryNo.SelectedItem.Value) > 0)
        {
            txtenquirydate.Text = obj.EnqDate;
            txtSpecifications.Text = HttpUtility.HtmlDecode(obj.Specificaitons);
        }

    }








    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SM.SalesEnquiry objSM = new SM.SalesEnquiry();

            
            objSM.Enqid = ddlEnquiryNo.SelectedItem.Value;
            objSM.Specificaitons = HttpUtility.HtmlEncode(txtSpecifications.Text);
            

            MessageBox.Show(this, objSM.SalesEnquirySpecifications_Update());
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {

            SM.Dispose();
           // Response.Redirect("~/Modules/Sales/SalesEnquiry.aspx");
        }
    }
}