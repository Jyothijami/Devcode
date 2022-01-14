using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_MRN_RejecedtoStock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if(!IsPostBack)
        {
            SCM.PurchaseReceipt.PurchaseReceipt_Select(ddlmrnno);
        }



    }
    protected void ddlmrnno_SelectedIndexChanged(object sender, EventArgs e)
    {

        if(ddlmrnno.SelectedItem.Value != "0")
        {
            SCM.PurchaseReceipt obj = new SCM.PurchaseReceipt();
            obj.Rejectedtostockmrn(ddlmrnno.SelectedItem.Value, GridView1);
        }

        


    }














    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            SCM.PurchaseReceipt objSM = new SCM.PurchaseReceipt();
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                    TextBox recqty = (TextBox)gvrow.FindControl("txtRECEIVEDQTY");
                    objSM.receivedqty = recqty.Text;
                    if (objSM.receivedqty != "0")
                    {
                        objSM.receivedqty = recqty.Text;
                        objSM.mrndetid = gvrow.Cells[12].Text;
                        objSM.matid = gvrow.Cells[9].Text;
                        objSM.plantid = "0";
                        objSM.colorid = gvrow.Cells[10].Text;
                        objSM.storagelocid = "0";
                        objSM.length = gvrow.Cells[3].Text;
                        TextBox remarks = (TextBox)gvrow.FindControl("txtitemremarks");
                        objSM.itemremarks = remarks.Text;
                        objSM.MRNRjectStock_Update(objSM.mrndetid, objSM.receivedqty,objSM.itemremarks);
                        objSM.Stock_Update1(objSM.matid, objSM.receivedqty, objSM.plantid, objSM.colorid, objSM.storagelocid, objSM.length);

                    }
            }

            MessageBox.Show(this, "Data Updated Successfully");
        }

        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            GridView1.DataBind();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Visible = false;

            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[12].Visible = false;
        }
    }
}