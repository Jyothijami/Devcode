using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_SalesQuotation : System.Web.UI.Page
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
                SM.SalesQuotation objSM = new SM.SalesQuotation();
                objSM.QuotId = hai.SelectedRow.Cells[0].Text;
                MessageBox.Notify(this, objSM.SalesQuotation_Delete(objSM.QuotId));
            }
            catch (Exception ex)
            {
                Masters.RollBackTransaction();
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                hai.DataBind();
                Masters.ClearControls(this);
                Masters.Dispose();
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
        Response.Redirect("~/Modules/Sales/SalesQuotationDetails.aspx?Cid=" + N);
    }
    protected void hai_RowCommand(object sender, GridViewCommandEventArgs e)
    {


       

        if (e.CommandName.Equals("Print"))
        {

            //GridView Row Index
            int rowIndex = int.Parse(e.CommandArgument.ToString().Trim());
            DropDownList ddlPrint = (DropDownList)hai.Rows[rowIndex].FindControl("ddlReports");

            if(ddlPrint.SelectedItem.Value != "Select")
            { 
                String ID = hai.DataKeys[rowIndex].Values["Quotation_Id"].ToString().Trim();
                String uNITID = hai.DataKeys[rowIndex].Values["Unit_Id"].ToString().Trim();
                string pagenavigationstr = "";
                 if(ddlPrint.SelectedItem.Value == "Basic")
                 {
                     pagenavigationstr = "../Reports/SMReportViewer.aspx?type=quot&qno=" + ID + "";
                     System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);

                 }
                 if (ddlPrint.SelectedItem.Value == "Group By Color")
                 {
                     pagenavigationstr = "../Reports/SMReportViewer.aspx?type=quotColor&qno=" + ID + "";
                     System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);

                 }
                 if (ddlPrint.SelectedItem.Value == "With Image")
                 {
                     pagenavigationstr = "../Reports/SMReportViewer.aspx?type=quotImage&qno=" + ID + "";
                     System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);

                 }
                 if (ddlPrint.SelectedItem.Value == "With Discount")
                 {
                     pagenavigationstr = "../Reports/SMReportViewer.aspx?type=quotDiscount&qno=" + ID + "";
                     System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);
                 }

                 if (ddlPrint.SelectedItem.Value == "System & Glass Price")
                 {
                     pagenavigationstr = "../Reports/SMReportViewer.aspx?type=quotSystemGlass&qno=" + ID + "";
                     System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);
                 }

                 if (ddlPrint.SelectedItem.Value == "Summary")
                 {
                     pagenavigationstr = "../Reports/SMReportViewer.aspx?type=quotSummary&qno=" + ID + "";
                     System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);




                     //pagenavigationstr = "../Reports/SMReportViewer.aspx?type=Compare&qno=" + uNITID + "";
                     //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);



                 }

            }
            else
            {
                MessageBox.Show(this, "Please Select Print Format to Print");
            }

            //hai.UseAccessibleHeader = true;
            //if ((hai.ShowHeader == true && hai.Rows.Count > 0) || (hai.ShowHeaderWhenEmpty == true))
            //{
            //    hai.HeaderRow.TableSection = TableRowSection.TableHeader;
            //}

        }
    }
    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[13].Visible = false;

        }

    }
}