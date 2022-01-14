 using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_MaterialIssue : System.Web.UI.Page
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
                SCM.MaterialIssue objSM = new SCM.MaterialIssue();
                objSM.MaterialIssueId = hai.SelectedRow.Cells[0].Text;
                MessageBox.Show(this, objSM.MaterialIssue_Delete(objSM.MaterialIssueId));
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
        Response.Redirect("~/Modules/Stock/MaterialIssue_Details.aspx?Cid=" + N);
    }

    protected void lbtnPrint_Click(object sender, EventArgs e)
    {
        LinkButton lbtnRegionalMaster;
        lbtnRegionalMaster = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnRegionalMaster.Parent.Parent;
        hai.SelectedIndex = gvRow.RowIndex;
        string pagenavigationstr = "";
        string Id = hai.SelectedRow.Cells[0].Text; ;
        if (hai.SelectedIndex > -1)
        {
            try
            {
                pagenavigationstr = "../Reports/SMReportViewer.aspx?type=mATIssueSlip&qno=" + Id + "";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {

            }
        }
        else
        {
            MessageBox.Notify(this, "Please select atleast a Record");
        }
    }
}