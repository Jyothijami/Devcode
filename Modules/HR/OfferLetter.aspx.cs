using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_OfferLetter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
                HR.OfferLetter objSM = new HR.OfferLetter();
                objSM.OfferLetterId = hai.SelectedRow.Cells[0].Text;
                MessageBox.Notify(this, objSM.OfferLetter_Delete());
            }
            catch (Exception ex)
            {
                HR.RollBackTransaction();
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                hai.DataBind();
                HR.ClearControls(this);
                HR.Dispose();
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
        Response.Redirect("~/Modules/HR/OfferLetter_Details.aspx?Cid=" + N);
    }
}