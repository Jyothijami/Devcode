using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modules_Purchases_MaterialRequest_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            Masters.MaterialMaster.MaterialMaster_Select(ddlitemCode);
            Masters.StorageLocation.StorageLocation_Select(ddlforwarehouse);
            Masters.SalesTermsConditions.SalesTermsConditions_Select(ddltermscondtions);
            txtMaterialreqestNo.Text = SCM.MaterialRequest.MaterialRequest_AutoGenCode();
            txtMrdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtrequireddate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            SM.SalesOrder.SalesOrder_Select(ddlSono);
            gvItems.DataBind();
            if (Qid != "Add")
            {
                CategoryFill();
            }
        }
    }

    private void CategoryFill()
    {
        SCM.MaterialRequest objmaster = new SCM.MaterialRequest();
        if (objmaster.MaterialRequest_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtMaterialreqestNo.Text = objmaster.MRno;
            txtMrdate.Text = objmaster.Mrdate;
            ddlrequesttype.SelectedValue = objmaster.ReqType;
            txtrequestfor.Text = objmaster.Requestedfor;
            txtrequireddate.Text = objmaster.RequiredDate;
            ddltermscondtions.SelectedValue = objmaster.Termsconditonsid;
            ddltermscondtions_SelectedIndexChanged(new object(), new System.EventArgs());

            ddlstatus.SelectedValue = objmaster.Status;

            objmaster.MaterialRequestDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);
        }
    }

    protected void btnadditem_Click(object sender, EventArgs e)
    {
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ItemCode");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Warehouse");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Requireddate");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("WarehouseId");
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
                        dr["Color"] = ddlColor.SelectedItem.Value;
                        dr["Qty"] = txtQty.Text;
                        dr["Requireddate"] = txtrequireddate.Text;
                        dr["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
                        dr["Warehouse"] = ddlforwarehouse.SelectedItem.Text;
                        dr["ColorId"] = ddlColor.SelectedItem.Value;
                        dr["WarehouseId"] = ddlforwarehouse.SelectedItem.Value;

                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["ItemCode"] = gvrow.Cells[1].Text;
                        dr["Color"] = gvrow.Cells[2].Text;
                        dr["Qty"] = gvrow.Cells[3].Text;
                        dr["Warehouse"] = gvrow.Cells[4].Text;
                        dr["Requireddate"] = gvrow.Cells[5].Text;
                        dr["ItemCodeId"] = gvrow.Cells[6].Text;

                        dr["ColorId"] = gvrow.Cells[7].Text;
                        dr["WarehouseId"] = gvrow.Cells[8].Text;
                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = gvrow.Cells[1].Text;
                    dr["Color"] = gvrow.Cells[2].Text;
                    dr["Qty"] = gvrow.Cells[3].Text;
                    dr["Warehouse"] = gvrow.Cells[4].Text;
                    dr["Requireddate"] = gvrow.Cells[5].Text;
                    dr["ItemCodeId"] = gvrow.Cells[6].Text;

                    dr["ColorId"] = gvrow.Cells[7].Text;
                    dr["WarehouseId"] = gvrow.Cells[8].Text;

                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }

        if (gvItems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["ItemCode"] = ddlitemCode.SelectedItem.Text;
            drnew["Color"] = ddlColor.SelectedItem.Value;
            drnew["Qty"] = txtQty.Text;
            drnew["Requireddate"] = txtrequireddate.Text;
            drnew["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
            drnew["Warehouse"] = ddlforwarehouse.SelectedItem.Text;
            drnew["ColorId"] = ddlColor.SelectedItem.Value;
            drnew["WarehouseId"] = ddlforwarehouse.SelectedItem.Value;
            SalesOrderItems.Rows.Add(drnew);
        }
        gvItems.DataSource = SalesOrderItems;
        gvItems.DataBind();
        gvItems.SelectedIndex = -1;
    }

    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
        }
    }

    protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvItems.Rows[e.RowIndex].Cells[1].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ItemCode");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Warehouse");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Requireddate");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("WarehouseId");
        SalesOrderItems.Columns.Add(col);
        if (gvItems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvItems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = gvrow.Cells[1].Text;
                    dr["Color"] = gvrow.Cells[2].Text;
                    dr["Qty"] = gvrow.Cells[3].Text;
                    dr["Warehouse"] = gvrow.Cells[4].Text;
                    dr["Requireddate"] = gvrow.Cells[5].Text;
                    dr["ItemCodeId"] = gvrow.Cells[6].Text;

                    dr["ColorId"] = gvrow.Cells[7].Text;
                    dr["WarehouseId"] = gvrow.Cells[8].Text;

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
            ddlforwarehouse.SelectedValue = obj.StorageLocation;
        }
        Masters.MaterialMaster.ItemMaster_ModelNoSelect(ddlColor, ddlitemCode.SelectedValue);
    }

    protected void ddltermscondtions_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.SalesTermsConditions obj = new Masters.SalesTermsConditions();
        if (obj.SalesTermsConditions_Select(ddltermscondtions.SelectedItem.Value) > 0)
        {
            txttermscondtionscontent.Text = HttpUtility.HtmlDecode(obj.Desc);
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
            SCM.MaterialRequest objMaster = new SCM.MaterialRequest();

            objMaster.MRno = txtMaterialreqestNo.Text;
            objMaster.RequiredDate = General.toMMDDYYYY(txtrequireddate.Text);
            objMaster.ReqType = ddlrequesttype.SelectedItem.Value;
            objMaster.Requestedfor = txtrequestfor.Text;
            objMaster.Mrdate = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.Termsconditonsid = ddltermscondtions.SelectedItem.Value;
            objMaster.Preparedby = "0";
            objMaster.Status = ddlstatus.SelectedItem.Value;

            if (objMaster.MaterialRequest_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[6].Text;
                    objMaster.Quantity = gvRowOtherCorp.Cells[3].Text;
                    objMaster.ItemReqDate = General.toMMDDYYYY(gvRowOtherCorp.Cells[5].Text);
                    objMaster.ColorId = gvRowOtherCorp.Cells[7].Text;
                    objMaster.WarehouseId = gvRowOtherCorp.Cells[8].Text;
                    objMaster.MaterialRequestDetails_Save();
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
            Response.Redirect("~/Modules/Purchases/MaterialRequest.aspx");
        }
    }

    private void po_Update()
    {
        try
        {
            SCM.MaterialRequest objMaster = new SCM.MaterialRequest();
            objMaster.MreqId = Request.QueryString["Cid"].ToString();
            objMaster.MRno = txtMaterialreqestNo.Text;
            objMaster.RequiredDate = General.toMMDDYYYY(txtrequireddate.Text);
            objMaster.ReqType = ddlrequesttype.SelectedItem.Value;
            objMaster.Requestedfor = txtrequestfor.Text;
            objMaster.Mrdate = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.Termsconditonsid = ddltermscondtions.SelectedItem.Value;
            objMaster.Preparedby = "0";
            objMaster.Status = ddlstatus.SelectedItem.Value;

            if (objMaster.MaterialRequest_Update() == "Data Updated Successfully")
            {
                objMaster.MaterialRequestDetails_Delete(objMaster.MreqId);
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[6].Text;
                    objMaster.Quantity = gvRowOtherCorp.Cells[3].Text;
                    objMaster.ItemReqDate = General.toMMDDYYYY(gvRowOtherCorp.Cells[5].Text);
                    objMaster.ColorId = gvRowOtherCorp.Cells[7].Text;
                    objMaster.WarehouseId = gvRowOtherCorp.Cells[8].Text;
                    objMaster.MaterialRequestDetails_Save();
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
            Response.Redirect("~/Modules/Purchases/MaterialRequest.aspx");
        }
    }

    protected void gvmatana_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Itemcode = e.Row.Cells[9].Text.ToString();
            string ColorId = e.Row.Cells[10].Text.ToString();

            if (Itemcode != "")
            {
                SCM.Stock obj1 = new SCM.Stock();

                if (obj1.StockOnStorageLocationCS(Itemcode, ColorId) > 0)
                {
                    e.Row.Cells[11].Text = obj1.Quantity;
                }
                else
                {
                    e.Row.Cells[11].Text = "0";
                    e.Row.Cells[11].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[11].ForeColor = System.Drawing.Color.White;
                }
            }
        }
    }

    protected void ddlSono_SelectedIndexChanged(object sender, EventArgs e)
    {
        General.GridBindwithCommand(gvmatana, "select * from SalesOrder_MaterialAnalysis,Material_Master,Category_Master where SalesOrder_MaterialAnalysis.ITEMCODE_ID = Material_Master.Material_Id and Material_Master.Category_Id = Category_Master.ITEM_CATEGORY_ID and SO_ID = '" + ddlSono.SelectedItem.Value + "'");
    }

    //Grid

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("CodeNo");
        //dt.Columns.Add("ItemCode");
        //dt.Columns.Add("Color");
        dt.Columns.Add("Width");
        dt.Columns.Add("height");

        dt.Columns.Add("SillHeight");

        dt.Columns.Add("Series");

        dt.Columns.Add("Qty");
        dt.Columns.Add("Glass");
        dt.Columns.Add("FlyScreen");
        dt.Columns.Add("Amount");
        dt.Columns.Add("TotalAmount");
        dt.Columns.Add("ItemDeliverydate");

        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("CodeNo = '" + gvRow.Cells[1].Text + "'");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["CodeNo"] = gvRow.Cells[1].Text;
            //dt.Rows[dt.Rows.Count - 1]["ItemCode"] = "";
            //dt.Rows[dt.Rows.Count - 1]["Color"] = "";

            dt.Rows[dt.Rows.Count - 1]["Width"] = gvRow.Cells[2].Text;

            dt.Rows[dt.Rows.Count - 1]["height"] = gvRow.Cells[3].Text;

            dt.Rows[dt.Rows.Count - 1]["SillHeight"] = gvRow.Cells[4].Text;
            dt.Rows[dt.Rows.Count - 1]["Series"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["Qty"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["Glass"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["FlyScreen"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["Amount"] = gvRow.Cells[9].Text;

            dt.Rows[dt.Rows.Count - 1]["TotalAmount"] = gvRow.Cells[10].Text;
            dt.Rows[dt.Rows.Count - 1]["ItemDeliverydate"] = "";

            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("CodeNo = '" + gvRow.Cells[1].Text + "'");
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
                    DataRow[] dr = dt.Select("CodeNo = '" + gvmatana.Rows[i].Cells[1].Text + "'");
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
        gvmatana.DataSource = dt;
        gvmatana.DataBind();
    }
}