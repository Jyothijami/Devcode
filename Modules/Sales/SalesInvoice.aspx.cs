﻿using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_SalesInvoice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

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
                SM.SalesInvoice objSM = new SM.SalesInvoice();
                objSM.SIId = hai.SelectedRow.Cells[0].Text;
                MessageBox.Notify(this, objSM.SalesInvoice_Delete(objSM.SIId));
            }
            catch (Exception ex)
            {
                Masters.RollBackTransaction();
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                hai.DataBind();
                Masters.ClearControls(this);
                Masters.Dispose();
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
        Response.Redirect("~/Modules/Sales/SalesInvoiceDetails.aspx?Cid=" + N);
    }
}