using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_ProductionReturn : System.Web.UI.Page
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
                SCM.ReturnProduction objSM = new SCM.ReturnProduction();
                objSM.ReturnId = hai.SelectedRow.Cells[0].Text;
                MessageBox.Show(this, objSM.ReturnProduction_Delete(objSM.ReturnId));
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                hai.DataBind();
                SCM.Dispose();
            }
        }
        else
        {
            MessageBox.Show(this, "Please select atleast a Record");
        }
    }
    protected void btnAddnew_Click(object sender, EventArgs e)
    {
        string N = "Add";
        Response.Redirect("~/Modules/Stock/ReturnProductionIssue_Details.aspx?Cid=" + N);
    }

}