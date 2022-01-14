using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_PO_Reserve : System.Web.UI.Page
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
                SCM.ReserveStock objSM = new SCM.ReserveStock();
                objSM.ReserveId = hai.SelectedRow.Cells[0].Text;
                MessageBox.Show(this, objSM.ReserveStock_Delete(objSM.ReserveId));
            }
            catch (Exception ex)
            {
                SCM.RollBackTransaction();
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
        Response.Redirect("~/Modules/Stock/PO_Reserve_Details.aspx?Cid=" + N);
    }




}