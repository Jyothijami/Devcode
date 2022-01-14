using AjaxControlToolkit;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Purchases_PoStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);

        if (!IsPostBack)
        {
            hai.DataBind();
        }
    }
    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.Cells[5].Text == "New")
        //{
        //    e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
        //    e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
        //}

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[0].Visible = false;
           // e.Row.Cells[10].Visible = false;
            // e.Row.Cells[16].Visible = false;


        }



        if (e.Row.RowType == DataControlRowType.DataRow)
        {
             DropDownList ddldesigner = (DropDownList)e.Row.FindControl("ddldesignStatus");
            //HR.EmployeeMaster.EmployeeMaster_Select(ddldesigner);

            //Select the Desinger in DropDownList
            string Desinger = (e.Row.FindControl("lbldesignerstatus") as Label).Text;

            //string Desinger = ((e.Row.FindControl("lbldesignerstatus") as Label).Text == null) ? "New" : (e.Row.FindControl("lbldesignerstatus") as Label).Text;
            ddldesigner.Items.FindByValue(Desinger).Selected = true;

        

        }






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
                obj.PoId = hai.SelectedRow.Cells[0].Text;


                obj.PONo = hai.SelectedRow.Cells[1].Text;
                obj.PoDate = hai.SelectedRow.Cells[2].Text;

                DropDownList ddlStaus = (DropDownList)gvRow.FindControl("ddldesignStatus");
                obj.Status = ddlStaus.SelectedItem.Value;

                TextBox txtPaidAmt = (TextBox)gvRow.FindControl("txtPaidAmt");
                obj.Rate = txtPaidAmt.Text;

                TextBox txtreamrks = (TextBox)gvRow.FindControl("txtremarks");
                obj.PoStatusRemarks = txtreamrks.Text;

                obj.Preparedby = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

                MessageBox.Show(this, obj.SupPO_Status(obj.PoId));


            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.ToString());
            }

            finally
            {
                hai.DataBind();
            }
        }
    }
}