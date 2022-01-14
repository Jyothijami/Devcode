using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_Item : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);

        if(!IsPostBack)
        {
            GridView1.DataBind();
        }

    }

    //protected void lbtnDelete_Click(object sender, EventArgs e)
    //{
    //    LinkButton lbtnRegionalMaster;
    //    lbtnRegionalMaster = (LinkButton)sender;
    //    GridViewRow gvRow = (GridViewRow)lbtnRegionalMaster.Parent.Parent;
    //    GridView1.SelectedIndex = gvRow.RowIndex;

    //    if (GridView1.SelectedIndex > -1)
    //    {
    //        try
    //        {
    //            Masters.MaterialMaster objSM = new Masters.MaterialMaster();
    //            objSM.Matid = GridView1.SelectedRow.Cells[0].Text;
    //            MessageBox.Notify(this, objSM.MaterialMaster_Delete());
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(this, ex.Message);
    //        }
    //        finally
    //        {
    //          Page_Load(this, null);
    //        }
    //    }
    //    else
    //    {
    //        MessageBox.Notify(this, "Please select atleast a Record");
    //    }
    //}
    protected void btnAddnew_Click(object sender, EventArgs e)
    {
        string N = "Add";
        Response.Redirect("~/Modules/Masters/Item_Details.aspx?Cid=" + N);
    }
  
   
}