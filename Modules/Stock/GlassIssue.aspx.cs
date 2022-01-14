using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_GlassIssue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            txtMaterialreqestNo.Text = SCM.GlassIssue.GlassIssue_AutoGenCode();
            txtMrdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            SM.SalesOrder.SalesOrder_Select(ddlSono);
            SCM.GlassRequest.GlassRequestNo_SelectNotissued(ddlRequestedNo);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlrequestedby);
            ddlapprovedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            if (Qid != "Add")
            {

                SCM.GlassRequest.GlassRequestNo_Select(ddlRequestedNo);
                CategoryFill();

            }
        }

    }
    private void CategoryFill()
    {
        SCM.GlassIssue  objmaster = new SCM.GlassIssue ();
        if (objmaster.GlassIssue_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtMaterialreqestNo.Text = objmaster.IssueNo;
            txtMrdate.Text = objmaster.IssueDate;
            ddlrequesttype.SelectedValue = objmaster.RequestPurpose;
            ddlrequestedby.SelectedValue = objmaster.RequestedBy;
            ddlapprovedby.SelectedValue = objmaster.ApprovedBy;
           
           // ddlSono.SelectedValue = objmaster.SoId;
            
            objmaster.GlassIssueDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);


            if(objmaster.RequestId != "0")
            {
                ddlRequestedNo.SelectedValue = objmaster.RequestId;
                ddlRequestedNo_SelectedIndexChanged(new object(), new System.EventArgs());

            }


        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            po_Save();
        }
        else if (btnSave.Text == "Update")
        {
            po_Update();
        }
    }

    private void po_Save()
    {
        try
        {
            SCM.GlassIssue objMaster = new SCM.GlassIssue();
            objMaster.IssueNo = txtMaterialreqestNo.Text;
            objMaster.IssueDate = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.RequestPurpose = ddlrequesttype.SelectedItem.Value;
            objMaster.ApprovedBy = ddlapprovedby.SelectedItem.Value;
            objMaster.RequestedBy = ddlrequestedby.SelectedItem.Value;
            objMaster.SoId = ddlSono.SelectedItem.Value;
            objMaster.RequestId = ddlRequestedNo.SelectedItem.Value;
            objMaster.Requested_For = ddlSono.SelectedItem.Text;
            if (objMaster.GlassIssue_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in gvmatana.Rows)
                {
                    objMaster.Windowcode  = gvRowOtherCorp.Cells[1].Text;
                    objMaster.Thickness = gvRowOtherCorp.Cells[2].Text;
                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.IssuedQty  = qty.Text;
                    objMaster.Description = gvRowOtherCorp.Cells[3].Text;
                    objMaster.Width = gvRowOtherCorp.Cells[4].Text;
                    TextBox Remarks = (TextBox)gvRowOtherCorp.FindControl("txtitemRemarks");
                    objMaster.Remarks = Remarks.Text;
                    objMaster.Height = gvRowOtherCorp.Cells[5].Text;
                    objMaster.SoId = ddlSono.SelectedItem.Value;

                    objMaster.Unit = gvRowOtherCorp.Cells[6].Text;
                    objMaster.Area = gvRowOtherCorp.Cells[7].Text;
                    objMaster.Weight = gvRowOtherCorp.Cells[8].Text;
                    objMaster.Stock = gvRowOtherCorp.Cells[9].Text;
                    objMaster.SoDetId  = gvRowOtherCorp.Cells[10].Text;
                    objMaster.ReqQty  = gvRowOtherCorp.Cells[11].Text;

                    objMaster.ReqIssuedetid = gvRowOtherCorp.Cells[12].Text;

                    objMaster.GlassIssueDetails_Save();
                   
                    objMaster.GlassPurchaseOrderDetailsStockQty_Update(objMaster.SoDetId, objMaster.IssuedQty);

                    objMaster.GlassRequest_DetailsStockQty_Update(objMaster.ReqIssuedetid, objMaster.IssuedQty);



                   

                }
            }
            MessageBox.Show(this, "Data Saved Successfully");

        }
        catch (Exception ex)
        {

        }
        finally
        {
           // SCM.ClearControls(this);
            SCM.Dispose();
            Response.Redirect("~/Modules/Stock/GlassIssueMast.aspx");
        }
    }

    private void po_Update()
    {

    }
    protected void ddlRequestedNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.GlassRequest obj = new SCM.GlassRequest();
        if (obj.GlassRequest_Select(ddlRequestedNo.SelectedItem.Value) > 0)
        {
            ddlSono.SelectedValue = obj.So_Id   ;
            ddlrequestedby.SelectedValue = obj.Prepared_By;
            obj.GlassRequestDetailsIssue_Select(ddlRequestedNo.SelectedItem.Value, gvmatana);

            //SCM.IssueRequest.ItemsIssueRequest_Select(ddlitemCode, ddlRequestedNo.SelectedItem.Value);
        }
    }
    protected void CheckBox_CheckChanged(object sender, EventArgs e)
    {
        GetData();
        SetData();
        BindSecondaryGrid();
    }
    private void BindSecondaryGrid()
    {
        DataTable dt = (DataTable)ViewState["SelectedRecords"];
        gvItems.DataSource = dt;
        gvItems.DataBind();
    }
    private void GetData()
    {
        DataTable dt;
        if (ViewState["SelectedRecords"] != null)
            dt = (DataTable)ViewState["SelectedRecords"];
        else
            dt = CreateDataTable();
        CheckBox chkAll = (CheckBox)gvmatana.HeaderRow
                            .Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvmatana.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvmatana.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvmatana.Rows[i]
                                .Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    dt = AddRow(gvmatana.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRow(gvmatana.Rows[i], dt);
                }
            }
        }
        ViewState["SelectedRecords"] = dt;
    }

    private void SetData()
    {
        CheckBox chkAll = (CheckBox)gvmatana.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        if (ViewState["SelectedRecords"] != null)
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            for (int i = 0; i < gvmatana.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvmatana.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    // DataRow[] dr = dt.Select("SoMatId = '" + gvmatana.Rows[i].Cells[9].Text + "'");

                    DataRow[] dr = dt.Select("WindowCode = '" + gvmatana.Rows[i].Cells[1].Text + "'   ");

                    chk.Checked = dr.Length > 0;
                    if (!chk.Checked)
                    {
                        chkAll.Checked = false;
                    }
                }
            }
        }
    }
    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("WindowCode");
        dt.Columns.Add("Thickness");
        dt.Columns.Add("Description");
        dt.Columns.Add("Width");
        dt.Columns.Add("Height");
        dt.Columns.Add("Unit");

        dt.Columns.Add("Area");
        dt.Columns.Add("Weight");
        dt.Columns.Add("Stock");
        dt.Columns.Add("PoDetId");
        dt.Columns.Add("Requestqty");
        dt.Columns.Add("Issued_Qty");
        dt.Columns.Add("Remarks");
        //dt.Columns.Add("Remarks");
        //dt.Columns.Add("WarehouseId");
        dt.AcceptChanges();
        return dt;
    }
    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        // DataRow[] dr = dt.Select("SoMatId = '" + gvRow.Cells[14].Text + "'");

        DataRow[] dr = dt.Select("WindowCode = '" + gvRow.Cells[1].Text + "'   ");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["WindowCode"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["Thickness"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["Description"] = gvRow.Cells[3].Text;
            dt.Rows[dt.Rows.Count - 1]["Width"] = gvRow.Cells[4].Text;
            dt.Rows[dt.Rows.Count - 1]["Height"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["Unit"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["Area"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["Weight"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["Stock"] = gvRow.Cells[9].Text;
            dt.Rows[dt.Rows.Count - 1]["PoDetId"] = gvRow.Cells[10].Text;




            dt.Rows[dt.Rows.Count - 1]["Requestqty"] = gvRow.Cells[11].Text;



            dt.Rows[dt.Rows.Count - 1]["Issued_Qty"] = "";
            dt.Rows[dt.Rows.Count - 1]["Remarks"] = "";

            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("WindowCode = '" + gvRow.Cells[1].Text + "' ");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
        }
        return dt;
    }


    protected void gvmatana_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[12].Visible = false;
        }
    }
}