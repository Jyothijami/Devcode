using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_Bom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        LinkButton lbtnRegionalMaster;
        lbtnRegionalMaster = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnRegionalMaster.Parent.Parent;
        GridView1.SelectedIndex = gvRow.RowIndex;

        if (GridView1.SelectedIndex > -1)
        {
            try
            {
                SCM.BOM objSM = new SCM.BOM();
                objSM.BomId = GridView1.SelectedRow.Cells[0].Text;
                MessageBox.Notify(this, objSM.BOM_Delete(objSM.BomId));
            }
            catch (Exception ex)
            {
                SCM.RollBackTransaction();
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                GridView1.DataBind();
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
        Response.Redirect("~/Modules/Stock/BomDetails.aspx?Cid=" + N);
    }
}