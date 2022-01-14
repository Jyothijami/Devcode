using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Purchases_PurchaseOrder_Status : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);

        if(!IsPostBack)
        { hai.DataBind(); }
       
    }
    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        LinkButton lbtnSave;
        lbtnSave = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnSave.Parent.Parent;
        hai.SelectedIndex = gvRow.RowIndex;


        if (hai.SelectedIndex > -1)
        {
            try
            {
               
                SCM.SupPo obj = new SCM.SupPo();
                obj.PoId  = hai.SelectedRow.Cells[0].Text;

                DropDownList ddlStaus = (DropDownList)gvRow.FindControl("ddldesignStatus");
                obj.Status = ddlStaus.SelectedItem.Value;

                TextBox txtPaidAmt = (TextBox)gvRow.FindControl("txtPaidAmt");
                obj.Rate = txtPaidAmt.Text;

                TextBox txtDeliveryDt = (TextBox)gvRow.FindControl("txtDeliveryDt");
                obj.PoDate  = txtDeliveryDt.Text;
               
                obj.Preparedby = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
                
                MessageBox.Notify(this, obj.SupPO_Status(obj.PoId));


            }
            catch (Exception ex)
            {

            }
        }
    }
    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        //DropDownList ddldesignStatus = (DropDownList)e.Row.FindControl("ddldesignStatus");
        //string Desingerstatus = (e.Row.FindControl("lbldesignerstatus") as Label).Text;
        //ddldesignStatus.Items.FindByValue(Desingerstatus).Selected = true;
    }
}