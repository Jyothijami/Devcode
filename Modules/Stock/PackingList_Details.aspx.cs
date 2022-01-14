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

public partial class Modules_Stock_PackingList_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            Masters.MaterialMaster.ItemStock_Select(ddlitemCode);
            txtplno.Text = SCM.PackingList.PackingList_AutoGenCode();
            txtpldate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlPreparedBy);
            Masters.ColorMaster.Color_Select(ddlColor);
            SM.CustomerMaster.CustomerProjectUnit_Select(ddlso);
            SM.CustomerMaster.CustomerUnit_Select(ddlProject);
            SCM.RequestPackingList.RequestPackingListBeforeApproveandstatus_Select(ddlRequestedNo);
  

            ddlPreparedBy.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            if (Qid != "Add")
            {
                SCM.RequestPackingList.RequestPackingList_Select(ddlRequestedNo);
                CategoryFill();
            }
        }
    }

    private void CategoryFill()
    {
        SCM.PackingList objmaster = new SCM.PackingList();
        if (objmaster.PackingList_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtplno.Text = objmaster.PLNo;
            txtpldate.Text = objmaster.PLDate;
            ddlso.SelectedValue = objmaster.Soid;
            ddlProject.SelectedValue = objmaster.CustId;
            txtcustaddress.Text = objmaster.CustAddress;
            txtdeliveryaddress.Text = objmaster.DeliveryAddress;

            txttotalpackets.Text = objmaster.TotalPackets;
            txttotalWeight.Text = objmaster.TotalWeight;
            txtmethodofdispacth.Text = objmaster.Methodofdispach;
            ddlRequestedNo.SelectedValue = objmaster.reqpackid;
            txttermscondtionscontent.Text = HttpUtility.HtmlDecode(objmaster.Remarks);
            objmaster.PackingListDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);
            
            ddlPreparedBy.SelectedValue = objmaster.preapredby;

        }
    }

    protected void btnadditem_Click(object sender, EventArgs e)
    {
          decimal value = 0 ,pu = 0;
        decimal.TryParse(txtQty.Text,out value);
        decimal.TryParse(txtpu.Text,out pu);

        decimal blockedstock = 0, Freestock = 0,Totalavailstock =0;
        decimal.TryParse(txtpreviousBlockedStock.Text, out blockedstock);
        decimal.TryParse(txtAvailableStocktoBlock.Text, out Freestock);


        Totalavailstock = (blockedstock + Freestock);


        if (value > Totalavailstock)
        {
            MessageBox.Show(this, "Stock is not available in free stock");
        }
        else
        {

                 if (value <= pu)
            {


        #region Code

        if (txtpurpose.Text == "") { txtpurpose.Text = "-"; }
        if (txtremarks.Text == "") { txtremarks.Text = "-"; }



        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ItemCode");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Uom");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Length");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ReqQty");
        SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Warehouse");
        //SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Packedqty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Remarks");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoId");
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
                        dr["Uom"] = txtUom.Text;
                        dr["Color"] = ddlColor.SelectedItem.Text;
                        dr["ReqQty"] = txtQty.Text;
                        dr["Packedqty"] = txtpurpose.Text;
                        dr["Remarks"] = txtremarks.Text;
                        dr["Length"] = ddllength.SelectedItem.Text;
                        dr["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
                        dr["ColorId"] = ddlColor.SelectedItem.Value;
                        dr["SoId"] = ddlso.SelectedItem.Value;
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
                        dr["ReqQty"] = gvrow.Cells[6].Text;
                        dr["Packedqty"] = gvrow.Cells[7].Text;
                        dr["Remarks"] = gvrow.Cells[8].Text;
                        dr["ItemCodeId"] = gvrow.Cells[9].Text;
                        dr["ColorId"] = gvrow.Cells[10].Text;
                        dr["SoId"] = gvrow.Cells[11].Text;
                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = gvrow.Cells[1].Text;
                    dr["Description"] = gvrow.Cells[2].Text;
                    dr["Uom"] = gvrow.Cells[3].Text;
                    dr["Length"] = gvrow.Cells[4].Text;
                    dr["Color"] = gvrow.Cells[5].Text;
                    dr["ReqQty"] = gvrow.Cells[6].Text;
                    dr["Packedqty"] = gvrow.Cells[7].Text;
                    dr["Remarks"] = gvrow.Cells[8].Text;
                    dr["ItemCodeId"] = gvrow.Cells[9].Text;
                    dr["ColorId"] = gvrow.Cells[10].Text;
                    dr["SoId"] = gvrow.Cells[11].Text;

                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }

        if (gvItems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["ItemCode"] = ddlitemCode.SelectedItem.Text;
            drnew["Description"] = txtseries.Text;
            drnew["Uom"] = txtUom.Text;
            drnew["Color"] = ddlColor.SelectedItem.Text;
            drnew["ReqQty"] = txtQty.Text;
            drnew["Packedqty"] = txtpurpose.Text;
            drnew["Remarks"] = txtremarks.Text;
            drnew["Length"] = ddllength.SelectedItem.Text;
            drnew["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
            drnew["ColorId"] = ddlColor.SelectedItem.Value;
            drnew["SoId"] = ddlso.SelectedItem.Value;
            SalesOrderItems.Rows.Add(drnew);
        }
        gvItems.DataSource = SalesOrderItems;
        gvItems.DataBind();
        gvItems.SelectedIndex = -1;
        Clear_Items();

        #endregion

            }
                 else
                 {
                     MessageBox.Show(this, "Issuing Qty More than Stock Qty");
                 }



        }
    }

    private void Clear_Items()
    {
        //ddlitemCode.DataBind();
        //ddlColor.DataBind();

        Masters.ColorMaster.Color_Select(ddlColor);
        Masters.MaterialMaster.ItemStock_Select(ddlitemCode);
        ddlitemCode.SelectedValue = "0";
        ddlColor.SelectedValue = "0";
        txtseries.Text = "";
        txtUom.Text = "";
        txtQty.Text = "";
        txtpurpose.Text = "";
        txtremarks.Text = "";
        txtpu.Text = "";
        txtAvailableStocktoBlock.Text = "";
        txtpreviousBlockedStock.Text = "";

        ddllength.Items.Clear();
    }

    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[7].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
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
        col = new DataColumn("Uom");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Length");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ReqQty");
        SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Warehouse");
        //SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Packedqty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Remarks");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoId");
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
                    dr["Length"] = gvrow.Cells[4].Text;
                    dr["Color"] = gvrow.Cells[5].Text;
                    dr["ReqQty"] = gvrow.Cells[6].Text;
                    dr["Packedqty"] = gvrow.Cells[7].Text;
                    dr["Remarks"] = gvrow.Cells[8].Text;
                    dr["ItemCodeId"] = gvrow.Cells[9].Text;
                    dr["ColorId"] = gvrow.Cells[10].Text;
                    dr["SoId"] = gvrow.Cells[11].Text;

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
        if (obj.MaterialPO_Select(ddlitemCode.SelectedItem.Value) > 0)
        {
            txtseries.Text = obj.Description;
            txtUom.Text = obj.UomName;

            Masters.MaterialMaster.ColorStock_ModelNoSelect(ddlColor, ddlitemCode.SelectedItem.Value);
            Masters.MaterialMaster.LengthStock_ModelNoSelect(ddllength, ddlitemCode.SelectedItem.Value);

            if (ddlColor.Items.Count > 0)
            {
                ddlColor_SelectedIndexChanged(sender, e);
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
            SCM.PackingList objMaster = new SCM.PackingList();

            objMaster.PLNo = txtplno.Text;
            objMaster.PLDate = General.toMMDDYYYY(txtpldate.Text);
            objMaster.Soid = ddlso.SelectedItem.Value;
            objMaster.CustId = ddlProject.SelectedItem.Value;
            objMaster.CustAddress = txtcustaddress.Text;
            objMaster.DeliveryAddress = txtdeliveryaddress.Text;
            objMaster.TotalPackets = txttotalpackets.Text;
            objMaster.TotalWeight = txttotalWeight.Text;
            objMaster.Methodofdispach = txtmethodofdispacth.Text;
            objMaster.preapredby = ddlPreparedBy.SelectedItem.Value;
            objMaster.reqpackid = ddlRequestedNo.SelectedItem.Value;
            objMaster.Remarks = HttpUtility.HtmlEncode(txttermscondtionscontent.Text);

            if (objMaster.PackingList_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[9].Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[10].Text;
                    objMaster.Uom = gvRowOtherCorp.Cells[3].Text;
                    objMaster.Length = gvRowOtherCorp.Cells[4].Text;
                    objMaster.Qty = gvRowOtherCorp.Cells[6].Text;
                    objMaster.PackedQty = gvRowOtherCorp.Cells[7].Text;
                    objMaster.DetRemarks = gvRowOtherCorp.Cells[8].Text;
                    objMaster.Soid = ddlso.SelectedItem.Value;
                    objMaster.PackingListDetails_Save();
                    objMaster.Stock_UpdatePQC(objMaster.Itemcode, objMaster.Qty, objMaster.ColorId, objMaster.Length);
                    if (objMaster.Soid != "0")
                    {
                        objMaster.BlockStock_Update(objMaster.Itemcode, objMaster.Qty, objMaster.ColorId, objMaster.Soid, objMaster.Length);
                    }
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
            Response.Redirect("~/Modules/Stock/Packinglist.aspx");
        }
    }

    private void po_Update()
    {
        try
        {
            SCM.PackingList objMaster = new SCM.PackingList();
            objMaster.PLId = Request.QueryString["Cid"].ToString();
            objMaster.PLNo = txtplno.Text;
            objMaster.PLDate = General.toMMDDYYYY(txtpldate.Text);
            objMaster.Soid = ddlso.SelectedItem.Value;
            objMaster.CustId = ddlProject.SelectedItem.Value;
            objMaster.CustAddress = txtcustaddress.Text;
            objMaster.DeliveryAddress = txtdeliveryaddress.Text;
            objMaster.TotalPackets = txttotalpackets.Text;
            objMaster.TotalWeight = txttotalWeight.Text;
            objMaster.Methodofdispach = txtmethodofdispacth.Text;
            objMaster.preapredby = ddlPreparedBy.SelectedItem.Value;
            objMaster.reqpackid = ddlRequestedNo.SelectedItem.Value;
            objMaster.Remarks = HttpUtility.HtmlEncode(txttermscondtionscontent.Text);

            if (objMaster.PackingList_Update() == "Data Updated Successfully")
            {
                objMaster.PackingListDetails_Delete(objMaster.PLId);
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[9].Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[10].Text;
                    objMaster.Uom = gvRowOtherCorp.Cells[3].Text;
                    objMaster.Length = gvRowOtherCorp.Cells[4].Text;
                    objMaster.Qty = gvRowOtherCorp.Cells[6].Text;
                    objMaster.PackedQty = gvRowOtherCorp.Cells[7].Text;
                    objMaster.DetRemarks = gvRowOtherCorp.Cells[8].Text;
                    objMaster.Soid = ddlso.SelectedItem.Value;
                    objMaster.PackingListDetails_Save();
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
            Response.Redirect("~/Modules/Stock/Packinglist.aspx");
        }
    }


    protected void ddlColor_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.MaterialMaster.ItemColorLengthStock_ModelNoSelect(ddllength, ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value);

        if (ddllength.Items.Count > 0)
        {
            ddllength_SelectedIndexChanged(sender, e);
        }
    }
    protected void ddllength_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.Stock Stock = new SCM.Stock();
        if (Stock.MCLStockAvailable(ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value, ddllength.SelectedItem.Value) > 0)
        {
            txtpu.Text = Stock.TStock;
        }

        if (int.Parse(ddlso.SelectedItem.Value) > 0)
        {
            if (Stock.SoMCLStockAvailable(ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value, ddllength.SelectedItem.Value, ddlso.SelectedItem.Value) > 0)
            {
                txtpreviousBlockedStock.Text = Stock.PreviousBlockforSo;
                txtAvailableStocktoBlock.Text = Stock.FreeStock;
            }
        }
    }
    protected void ddlso_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesOrder obj = new SM.SalesOrder();
        if(obj.SalesOrder_Select(ddlso.SelectedItem.Value) > 0)
        {
            ddlProject.SelectedValue = obj.SiteId;
            ddlProject_SelectedIndexChanged(sender, e);
        }
    }
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.CustomerMaster obj = new SM.CustomerMaster();
        if(obj.CustomerUnitMaster_Select(ddlProject.SelectedItem.Value) > 0)
        {
            txtcustaddress.Text = obj.UnitAddress;
            txtdeliveryaddress.Text = obj.UnitAddress;
        }
    }
    protected void ddlRequestedNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.RequestPackingList obj = new SCM.RequestPackingList();
        if (obj.RequestPackingList_Select(ddlRequestedNo.SelectedItem.Value) > 0)
        {
            ddlso.SelectedValue = obj.Soid;
            ddlso_SelectedIndexChanged(sender, e);
            ddlProject.SelectedValue = obj.CustId;
            txtmethodofdispacth.Text = obj.Methodofdispach;
            txttotalpackets.Text = obj.TotalPackets;
            txttotalWeight.Text = obj.TotalWeight;
            txttermscondtionscontent.Text = HttpUtility.HtmlDecode(obj.Remarks);
            obj.RequestPackingListDetails_Select(ddlRequestedNo.SelectedItem.Value, gvmatana);

           // SCM.IssueRequest.ItemsIssueRequest_Select(ddlitemCode, ddlRequestedNo.SelectedItem.Value);
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
        dt.Columns.Add("ReqQty");
        dt.Columns.Add("Packedqty");
        dt.Columns.Add("Remarks");
        dt.Columns.Add("ItemCodeId");
        dt.Columns.Add("ColorId");
        dt.Columns.Add("SoId");

        //dt.Columns.Add("WarehouseId");
        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        //DataRow[] dr = dt.Select("SoMatId = '" + gvRow.Cells[9].Text + "'");

        DataRow[] dr = dt.Select("ItemCodeId = '" + gvRow.Cells[9].Text + "' and ColorId = '" + gvRow.Cells[10].Text + "' and  Length = '" + gvRow.Cells[3].Text + "' ");

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
            dt.Rows[dt.Rows.Count - 1]["ReqQty"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["Packedqty"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["Remarks"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["ItemCodeId"] = gvRow.Cells[9].Text;
            dt.Rows[dt.Rows.Count - 1]["ColorId"] = gvRow.Cells[10].Text;
            dt.Rows[dt.Rows.Count - 1]["SoId"] = gvRow.Cells[11].Text;
         


            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        // DataRow[] dr = dt.Select("SoMatId = '" + gvRow.Cells[9].Text + "'");

      //  DataRow[] dr = dt.Select("ItemCodeId = '" + gvRow.Cells[7].Text + "' and ColorId = '" + gvRow.Cells[8].Text + "' and  Length = '" + gvRow.Cells[3].Text + "' ");
        DataRow[] dr = dt.Select("ItemCodeId = '" + gvRow.Cells[9].Text + "' and ColorId = '" + gvRow.Cells[10].Text + "' and  Length = '" + gvRow.Cells[3].Text + "' ");

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

                    DataRow[] dr = dt.Select("ItemCodeId = '" + gvmatana.Rows[i].Cells[9].Text + "' and ColorId = '" + gvmatana.Rows[i].Cells[10].Text + "' and Length = '" + gvmatana.Rows[i].Cells[3].Text + "'  ");

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














    protected void gvmatana_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[11].Visible = false;
            //e.Row.Cells[10].Visible = false;
        }



        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Itemcode = e.Row.Cells[9].Text.ToString();
            string ColorId = e.Row.Cells[10].Text.ToString();

            string soid = e.Row.Cells[11].Text.ToString();
            string length = e.Row.Cells[3].Text.ToString();

            if (Itemcode != "")
            {
                SCM.Stock obj1 = new SCM.Stock();

                //if (obj1.StockOnStorageLocationCS1(Itemcode, ColorId) > 0)
                //{
                //    e.Row.Cells[10].Text = obj1.Quantity;
                //}
                //else
                //{
                //    e.Row.Cells[10].Text = "0";
                //}


                if (obj1.BlockStockSo(Itemcode, ColorId, soid, length) > 0)
                {
                    e.Row.Cells[12].Text = obj1.BlockQty;
                }

                if (obj1.IssuedStockSO(Itemcode, ColorId, soid, length) > 0)
                {
                    e.Row.Cells[13].Text = obj1.Issuedqty;
                }

                if (obj1.SoMCLStockAvailable(Itemcode, ColorId, length, soid) > 0)
                {
                    e.Row.Cells[14].Text = obj1.FreeStock;
                }




            }

            //    //DropDownList ddlwarehouse = (e.Row.FindControl("ddlSowaerhose") as DropDownList);
            //    //Masters.StorageLocation.StorageLocation_Select(ddlwarehouse);
        }
    }
}