using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_GlassPurchaseOrderStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);

        if (!Page.IsPostBack)
        {
            hai.DataBind();
        }
    }


    protected void hai_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Print"))
        {

            try
            {

                int rowIndex = int.Parse(e.CommandArgument.ToString().Trim());
                DropDownList ddlPrint = (DropDownList)hai.Rows[rowIndex].FindControl("ddlReports");
                TextBox txtremarks = (TextBox)hai.Rows[rowIndex].FindControl("txtremarks");
                TextBox txtdeliverydate = (TextBox)hai.Rows[rowIndex].FindControl("txtdeliverydate");
                TextBox txtdeliveryto = (TextBox)hai.Rows[rowIndex].FindControl("txtdeliveredto");


                if (ddlPrint.SelectedItem.Value != "Select")
                {
                    String ID = hai.DataKeys[rowIndex].Values["Sup_GPO_Id"].ToString().Trim();
                    SCM.SupPo obj = new SCM.SupPo();
                    obj.Status = ddlPrint.SelectedItem.Text;
                    obj.PoId = ID;

                    obj.Remarks = txtremarks.Text;
                    obj.Deliverydate = txtdeliverydate.Text;
                    obj.Deliverto = txtdeliveryto.Text;

                    obj.GlassSupPoStatus_Update();
                    MessageBox.Show(this, "Updated Succesfully");
                }
                else
                {
                    MessageBox.Show(this, "Please Select PO NO to Update");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
            finally
            {
                hai.DataBind();
            }
        }
    }
  

}