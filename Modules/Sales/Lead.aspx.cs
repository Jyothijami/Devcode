using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_Lead : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);

        if (!IsPostBack)
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
                SM.Lead objSM = new SM.Lead();
                objSM.LeadId = hai.SelectedRow.Cells[0].Text;
                MessageBox.Notify(this, objSM.Lead_Delete());
            }
            catch (Exception ex)
            {
                SM.RollBackTransaction();
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                hai.DataBind();
                SM.ClearControls(this);
                SM.Dispose();
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
        Response.Redirect("~/Modules/Sales/Lead_Details.aspx?Cid=" + N);
    }
    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[8].Text == "High" )
        {
            e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
            e.Row.Cells[8].ForeColor = System.Drawing.Color.White;
        }

        if (e.Row.Cells[8].Text == "Medium")
        {
            e.Row.Cells[8].BackColor = System.Drawing.Color.Orange;
            e.Row.Cells[8].ForeColor = System.Drawing.Color.White;
        }

        
    }
}