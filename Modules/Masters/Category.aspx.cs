using phani.Classes;
using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);

        if(!IsPostBack)
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
                Masters.ItemCategory objSM = new Masters.ItemCategory();
                objSM.ItCategoryId = hai.SelectedRow.Cells[0].Text;
                MessageBox.Show(this, objSM.ItemCategory_Delete());
            }
            catch (Exception ex)
            {
              //  Masters.RollBackTransaction();
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
               // hai.DataBind();
               // General.GridBindwithCommand(hai, "select * from Category_Master");
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
        Response.Redirect("~/Modules/Masters/CategoryDetails.aspx?Cid=" +N );
    }
}