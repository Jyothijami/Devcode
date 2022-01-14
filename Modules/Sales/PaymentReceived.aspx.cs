using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_PaymentReceived : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

      

        if (!IsPostBack)
        {
            SM.SalesInvoice.SalesInvoice_Select(ddlInvoiceNo);

            InvoiceFill();

            if (Qid != "Add")
            {
               
            }
        }
    }

    private void InvoiceFill()
    {
        SM.SalesInvoice objmaster = new SM.SalesInvoice();
        if (objmaster.SalesInvoiceCU_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            txtPaymentrevicedNo.Text = SM.SalesInvoice.Prno_AutoGenCode();
            txtPaymentReceivedDate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            ddlInvoiceNo.SelectedValue = objmaster.SIId;
            txtInvoiceDate.Text = objmaster.SIdate;
            txtCustomerName.Text = objmaster.CustomerName;
            txtMobileNo.Text = objmaster.CustMobileno;
            txtSiteLocation.Text = objmaster.UnitLocation;
            txtsitename.Text = objmaster.UnitName;

            txtDuedate.Text = objmaster.Duedate;
            txtOriginalAmount.Text = objmaster.Grandtotal;
            txtOpenBalance.Text = objmaster.BalanceDue;
            General.GridBindwithCommand(hai, "Select * from Payments_Received where SI_Id = '" + Request.QueryString["Cid"].ToString() + "'");
            
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        SM.SalesInvoice obj = new SM.SalesInvoice();

        obj.Prno = txtPaymentrevicedNo.Text;
        obj.Prdate = General.toMMDDYYYY(txtPaymentReceivedDate.Text);
        obj.PSiid = ddlInvoiceNo.SelectedItem.Value;
        obj.Psiamount = txtOriginalAmount.Text;
        obj.amountreceived = txtPaymentRecieved.Text;
        obj.paymodetype = ddlPaymentMethod.SelectedItem.Value;
        obj.Status = "A";
        obj.BalanceDue = txtOpenBalance.Text;


         if (obj.PaymentReceived_Save() == "Data Saved Successfully")
         {
             InvoiceFill();
         }


        


    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.Cells[0].Visible = false;
           

        }
    }
}