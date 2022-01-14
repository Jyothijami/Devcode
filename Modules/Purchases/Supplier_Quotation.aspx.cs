﻿using phani.MessageBox;
using Phani.Modules;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Purchases_Supplier_Quotation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);
        if (!Page.IsPostBack)
        {
            hai.DataBind();
        }
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        LinkButton lbtnRegionalMaster;
        lbtnRegionalMaster = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnRegionalMaster.Parent.Parent;
        hai.SelectedIndex = gvRow.RowIndex;

        if (hai.SelectedIndex > -1)
        {
            try
            {
                SCM.SupplierQuotation objSM = new SCM.SupplierQuotation();
                objSM.QuotId = hai.SelectedRow.Cells[0].Text;
                MessageBox.Notify(this, objSM.SupplierQuotation_Delete(objSM.QuotId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                hai.DataBind();
                SCM.ClearControls(this);
                SCM.Dispose();
            }
        }
        else
        {
            MessageBox.Notify(this, "Please select atleast a Record");
        }
    }

    protected void btnAddnew_Click(object sender, EventArgs e)
    {
        string N = "Add";
        Response.Redirect("~/Modules/Purchases/SupplierQuotation_Details.aspx?Cid=" + N);
    }
}