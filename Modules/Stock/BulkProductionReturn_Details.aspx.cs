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

public partial class Modules_Stock_BulkProductionReturn_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            Masters.MaterialMaster.MaterialMaster_Select(ddlitemCode);
          
            txtreturnno.Text = SCM.BulkReturnProduction.BulkReturnProduction_AutoGenCode();
            txtreturndate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            Masters.ColorMaster.Color_Select(ddlColor);
            SM.SalesOrder.SalesOrder_Select(ddlSono);
            SM.CustomerMaster.CustomerUnit_Select(ddlCustomer);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlrequestedby);

            //  ddlrequestedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            ddlapprovedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);


            gvItems.DataBind();
            if (Qid != "Add")
            {
                SCM.BulkReturnRequest.BulkReturnIssueRequestsTATUS_Select(ddlMaterialIssueno);
                CategoryFill();
            }
            else
            {
                SCM.BulkReturnRequest.BulkReturnIssueRequest_Select(ddlMaterialIssueno);
            }
        }
    }

    private void CategoryFill()
    {
        SCM.BulkReturnProduction objmaster = new SCM.BulkReturnProduction();
        if (objmaster.BulkReturnProduction_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtreturnno.Text = objmaster.ReturnNo;
            txtreturndate.Text = objmaster.ReturnDate;
            ddlReturnFrom.SelectedValue = objmaster.ReturnFrom;
            ddlrequestedby.SelectedValue = objmaster.ReturnBy;
            ddlapprovedby.SelectedValue = objmaster.PreparedBy;
            ddlCustomer.SelectedValue = objmaster.Custid;

            objmaster.BulkReturnProductionDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);

            if (objmaster.BulkRequetId != "0")
            {
                ddlMaterialIssueno.SelectedValue = objmaster.BulkRequetId;
                ddlMaterialIssueno_SelectedIndexChanged(new object(), new System.EventArgs());
            }

        }
    }

    protected void btnadditem_Click(object sender, EventArgs e)
    {
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ItemCode");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Length");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Uom");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ReceivingQty");
        SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Warehouse");
        //SalesOrderItems.Columns.Add(col);

        //SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoId");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Remarks");
        SalesOrderItems.Columns.Add(col);
        if (gvItems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvItems.Rows)
            {
                if (gvItems.SelectedIndex > -1)
                {
                    if (gvrow.RowIndex == gvItems.SelectedRow.RowIndex)
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["ItemCode"] = ddlitemCode.SelectedItem.Text;
                        dr["Description"] = txtseries.Text;

                        TextBox Length = (TextBox)gvrow.FindControl("txtlength");
                        dr["Length"] = Length.Text;


                        dr["Uom"] = txtUom.Text;
                        dr["Color"] = ddlColor.SelectedItem.Text;


                        dr["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
                        dr["ColorId"] = ddlColor.SelectedItem.Value;
                        dr["SoId"] = ddlSono.SelectedItem.Value;

                        TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                        dr["ReceivingQty"] = Qty.Text;

                        TextBox Remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                        dr["Remarks"] = Remarks.Text;

                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["ItemCode"] = gvrow.Cells[1].Text;
                        dr["Description"] = gvrow.Cells[2].Text;
                        dr["Uom"] = gvrow.Cells[3].Text;
                        dr["Length"] = gvrow.Cells[4].Text;
                        dr["Color"] = gvrow.Cells[5].Text;
                        dr["ItemCodeId"] = gvrow.Cells[6].Text;
                        dr["ColorId"] = gvrow.Cells[7].Text;
                        dr["SoId"] = gvrow.Cells[8].Text;
                        dr["ReceivingQty"] = gvrow.Cells[9].Text;
                        dr["Remarks"] = gvrow.Cells[10].Text;
                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = gvrow.Cells[1].Text;
                    dr["Description"] = gvrow.Cells[2].Text;
                    dr["Uom"] = gvrow.Cells[3].Text;

                    TextBox Length = (TextBox)gvrow.FindControl("txtlength");
                    dr["Length"] = Length.Text;

                    dr["Color"] = gvrow.Cells[5].Text;
                    dr["ItemCodeId"] = gvrow.Cells[6].Text;
                    dr["ColorId"] = gvrow.Cells[7].Text;
                    dr["SoId"] = gvrow.Cells[8].Text;
                    TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                    dr["ReceivingQty"] = Qty.Text;
                    TextBox Remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                    dr["Remarks"] = Remarks.Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }

        if (gvItems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["ItemCode"] = ddlitemCode.SelectedItem.Text;
            drnew["Description"] = txtseries.Text;
            drnew["Length"] = txtitemtLength.Text;
            drnew["Uom"] = txtUom.Text;
            drnew["Color"] = ddlColor.SelectedItem.Text;
            drnew["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
            drnew["ColorId"] = ddlColor.SelectedItem.Value;
            drnew["SoId"] = ddlSono.SelectedItem.Value;
            TextBox Qty = (TextBox)gvItems.FindControl("txtitemqty");
            drnew["ReceivingQty"] = txtQty.Text;
            TextBox Remarks = (TextBox)gvItems.FindControl("txtitemRemarks");
            drnew["Remarks"] = txtremakrs.Text;
            SalesOrderItems.Rows.Add(drnew);
        }
        gvItems.DataSource = SalesOrderItems;
        gvItems.DataBind();
        gvItems.SelectedIndex = -1;
        clearitems();
    }

    private void clearitems()
    {
        Masters.ColorMaster.Color_Select(ddlColor);
        Masters.MaterialMaster.ItemStock_Select(ddlitemCode);
        ddlitemCode.SelectedValue = "0";
        ddlColor.SelectedValue = "0";
        txtseries.Text = "";
        txtUom.Text = "";
        txtitemtLength.Text = "";
        txtpu.Text = "";
        txtQty.Text = "";
        txtremakrs.Text = "";
    }

    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[6].Visible = false;

        }
    }

    protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvItems.Rows[e.RowIndex].Cells[0].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ItemCode");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Length");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Uom");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ReceivingQty");
        SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Warehouse");
        //SalesOrderItems.Columns.Add(col);

      //  SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoId");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Remarks");
        SalesOrderItems.Columns.Add(col);
        if (gvItems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvItems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = gvrow.Cells[1].Text;
                    dr["Description"] = gvrow.Cells[2].Text;
                    dr["Uom"] = gvrow.Cells[3].Text;
                    //dr["Length"] = gvrow.Cells[4].Text;

                    TextBox Length = (TextBox)gvrow.FindControl("txtlength");
                    dr["Length"] = Length.Text;

                    dr["Color"] = gvrow.Cells[5].Text;
                    dr["ItemCodeId"] = gvrow.Cells[6].Text;
                    dr["ColorId"] = gvrow.Cells[7].Text;
                    dr["SoId"] = gvrow.Cells[8].Text;
                    TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                    dr["ReceivingQty"] = Qty.Text;
                    TextBox Remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                    dr["Remarks"] = Remarks.Text;

                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvItems.DataSource = SalesOrderItems;
        gvItems.DataBind();
    }

    protected void ddlitemCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.MaterialMaster obj = new Masters.MaterialMaster();
        if (obj.MaterialType_Select(ddlitemCode.SelectedItem.Value) > 0)
        {
            txtseries.Text = obj.Description;
            txtUom.Text = obj.UomName;
            txtitemtLength.Text = obj.BarLength;
            txtpu.Text = obj.Boxsize;
        }
        //Masters.MaterialMaster.ItemMaster_ModelNoSelect(ddlColor, ddlitemCode.SelectedValue);
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
            SCM.BulkReturnProduction objMaster = new SCM.BulkReturnProduction();

            objMaster.ReturnNo = txtreturnno.Text;
            objMaster.ReturnDate = General.toMMDDYYYY(txtreturndate.Text);
            objMaster.ReturnFrom = ddlReturnFrom.SelectedItem.Value;
            objMaster.PreparedBy = ddlapprovedby.SelectedItem.Value;
            objMaster.ReturnBy = ddlrequestedby.SelectedItem.Value;
            objMaster.Custid = ddlCustomer.SelectedItem.Value;
            objMaster.SoId = ddlSono.SelectedItem.Value;
            objMaster.BulkRequetId = ddlMaterialIssueno.SelectedItem.Value;

            if (objMaster.BulkReturnProduction_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {

                  

                    objMaster.Itemcode = gvRowOtherCorp.Cells[6].Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[7].Text;

                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.Qty = qty.Text;
                    TextBox Remarks = (TextBox)gvRowOtherCorp.FindControl("txtitemRemarks");
                    objMaster.DetRemarks = Remarks.Text;
                    objMaster.SoId = gvRowOtherCorp.Cells[8].Text;
                    TextBox Length = (TextBox)gvRowOtherCorp.FindControl("txtlength");
                    objMaster.Length = Length.Text;

                    // objMaster.Length = gvRowOtherCorp.Cells[3].Text;


                    objMaster.BulkReturnProductionDetails_Save();
                    objMaster.Stock_Update1(objMaster.Itemcode, objMaster.Qty, "1", objMaster.ColorId, "1", objMaster.Length);
                    objMaster.BlockStock_Update1(objMaster.Itemcode, objMaster.Qty, objMaster.ColorId,objMaster.Length, objMaster.SoId);



                }
            }

            MessageBox.Show(this, "Data Saved Successfully");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            SCM.ClearControls(this);
            SCM.Dispose();
            Response.Redirect("~/Modules/Stock/BulkProductionReturn.aspx");
        }
    }

    private void po_Update()
    {
        try
        {
            SCM.BulkReturnProduction objMaster = new SCM.BulkReturnProduction();
            objMaster.ReturnId = Request.QueryString["Cid"].ToString();
            objMaster.ReturnNo = txtreturnno.Text;
            objMaster.ReturnDate = General.toMMDDYYYY(txtreturndate.Text);
            objMaster.ReturnFrom = ddlReturnFrom.SelectedItem.Value;
            objMaster.PreparedBy = ddlapprovedby.SelectedItem.Value;
            objMaster.ReturnBy = ddlrequestedby.SelectedItem.Value;
            objMaster.Custid = ddlCustomer.SelectedItem.Value;
            objMaster.SoId = ddlSono.SelectedItem.Value;
            objMaster.BulkRequetId = ddlMaterialIssueno.SelectedItem.Value;
            if (objMaster.BulkReturnProduction_Update() == "Data Updated Successfully")
            {
                objMaster.BulkReturnProductionDetails_Delete(objMaster.ReturnId);
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[6].Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[7].Text;
                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.Qty = qty.Text;
                    TextBox Remarks = (TextBox)gvRowOtherCorp.FindControl("txtitemRemarks");
                    objMaster.DetRemarks = Remarks.Text;
                    objMaster.SoId = gvRowOtherCorp.Cells[8].Text;
                    TextBox Length = (TextBox)gvRowOtherCorp.FindControl("txtlength");
                    objMaster.Length = Length.Text;


                    objMaster.BulkReturnProductionDetails_Save();
                }
            }
            MessageBox.Show(this, "Data Updated Successfully");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            SCM.ClearControls(this);
            SCM.Dispose();
            Response.Redirect("~/Modules/Stock/BulkProductionReturn.aspx");
        }
    }

    protected void gvmatana_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
        }

    }


    //Grid

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ItemCode");
        dt.Columns.Add("Description");
        dt.Columns.Add("Length");
        dt.Columns.Add("Uom");
        dt.Columns.Add("Color");
        dt.Columns.Add("ItemCodeId");
        dt.Columns.Add("ColorId");
        dt.Columns.Add("SoId");
        dt.Columns.Add("ReceivingQty");
        dt.Columns.Add("Remarks");
        //dt.Columns.Add("WarehouseId");
        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        // DataRow[] dr = dt.Select("SoMatId = '" + gvRow.Cells[9].Text + "'");
        DataRow[] dr = dt.Select("ItemCodeId = '" + gvRow.Cells[7].Text + "' and ColorId = '" + gvRow.Cells[8].Text + "' and Length = '" + gvRow.Cells[3].Text + "'  ");

        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["ItemCode"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["Description"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["Length"] = gvRow.Cells[3].Text;
            dt.Rows[dt.Rows.Count - 1]["Uom"] = gvRow.Cells[4].Text;
            if (gvRow.Cells[5].Text == "&nbsp;" || gvRow.Cells[5].Text == " ")
            {
                dt.Rows[dt.Rows.Count - 1]["Color"] = "NA";
            }
            else
            {
                dt.Rows[dt.Rows.Count - 1]["Color"] = gvRow.Cells[5].Text;
            }
            dt.Rows[dt.Rows.Count - 1]["ItemCodeId"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["ColorId"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["SoId"] = gvRow.Cells[10].Text;
            dt.Rows[dt.Rows.Count - 1]["ReceivingQty"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["Remarks"] = "";

            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        // DataRow[] dr = dt.Select("SoMatId = '" + gvRow.Cells[9].Text + "'");

        DataRow[] dr = dt.Select("ItemCodeId = '" + gvRow.Cells[7].Text + "' and ColorId = '" + gvRow.Cells[8].Text + "' and Length = '" + gvRow.Cells[3].Text + "' ");

        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
        }
        return dt;
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

                    DataRow[] dr = dt.Select("ItemCodeId = '" + gvmatana.Rows[i].Cells[7].Text + "' and ColorId = '" + gvmatana.Rows[i].Cells[8].Text + "' and Length = '" + gvmatana.Rows[i].Cells[3].Text + "'  ");

                    chk.Checked = dr.Length > 0;
                    if (!chk.Checked)
                    {
                        chkAll.Checked = false;
                    }
                }
            }
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

    protected void ddlMaterialIssueno_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.BulkReturnRequest obj = new SCM.BulkReturnRequest();
        if (obj.BulkReturnIssueRequest_Select(ddlMaterialIssueno.SelectedItem.Value) > 0)
        {
            ddlSono.SelectedValue = obj.SoId;
            ddlCustomer.SelectedValue = obj.Custid;
            ddlrequestedby.SelectedValue = obj.ReturnBy;
            obj.BulkReturnIssueRequestDetails_Select(ddlMaterialIssueno.SelectedItem.Value, gvmatana);
        }
    }
}