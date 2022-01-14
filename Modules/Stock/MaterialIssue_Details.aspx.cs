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

public partial class Modules_Stock_MaterialIssue_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {

            Masters.MaterialMaster.ItemStock_Select(ddlitemCode);
            SCM.IssueRequest.IssueRequestBeforeApproveandstatus_Select(ddlRequestedNo);
            txtMaterialreqestNo.Text = SCM.MaterialIssue.MaterialIssue_AutoGenCode();
            txtMrdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            Masters.ColorMaster.Color_Select(ddlColor);
            SM.SalesOrder.SalesOrder_Select(ddlSono);
            SM.CustomerMaster.CustomerUnit_Select(ddlCustomer);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlrequestedby);

          //  ddlrequestedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            ddlapprovedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            if (Qid != "Add")
            {
                SCM.IssueRequest.IssueRequest_Select(ddlRequestedNo);
                CategoryFill();
            }

            //gvItems.DataBind();
            
        }
    }

    private void CategoryFill()
    {
        SCM.MaterialIssue objmaster = new SCM.MaterialIssue();
        if (objmaster.MaterialIssue_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtMaterialreqestNo.Text = objmaster.IssueNo;
            txtMrdate.Text = objmaster.IssueDate;
            ddlrequesttype.SelectedValue = objmaster.RequestPurpose;
            ddlrequestedby.SelectedValue = objmaster.RequestedBy;
            ddlapprovedby.SelectedValue = objmaster.ApprovedBy;
            ddlCustomer.SelectedValue = objmaster.Custid;

            objmaster.MaterialIssueDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);

            if (objmaster.RequestId != "0")
            {
                ddlRequestedNo.SelectedValue = objmaster.RequestId;
                ddlRequestedNo_SelectedIndexChanged(new object(), new System.EventArgs());
            }

        }
    }

    protected void btnadditem_Click(object sender, EventArgs e)
    {


        if (txtremakrs.Text == "")
        {
            txtremakrs.Text = "-";
        }

        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ItemCode");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Length");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Uom");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ReqQty");
        SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Warehouse");
        //SalesOrderItems.Columns.Add(col);

     //   SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoMatId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("IssuedQty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Remarks");
        SalesOrderItems.Columns.Add(col);


        col = new DataColumn("BlockedQty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("FreeQty");
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
                        dr["Series"] = txtseries.Text;
                        dr["Length"] = ddllength.SelectedItem.Text;
                        dr["Uom"] = txtUom.Text;
                        dr["Color"] = ddlColor.SelectedItem.Text;
                        dr["ReqQty"] = txtQty.Text;
                       
                        dr["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
                        dr["ColorId"] = ddlColor.SelectedItem.Value;
                        dr["SoMatId"] = "0";

                        TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                        dr["IssuedQty"] = txtQty.Text;

                        TextBox Remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                        dr["Remarks"] = Remarks.Text;

                        dr["BlockedQty"] = txtpreviousBlockedStock.Text;
                        dr["FreeQty"]       = txtAvailableStocktoBlock.Text;



                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["ItemCode"] = gvrow.Cells[1].Text;
                        dr["Series"] = gvrow.Cells[2].Text;
                        dr["Length"] = gvrow.Cells[3].Text;
                        dr["Uom"] = gvrow.Cells[4].Text;
                        dr["Color"] = gvrow.Cells[5].Text;
                        dr["ReqQty"] = gvrow.Cells[6].Text;


                        dr["ItemCodeId"] = gvrow.Cells[7].Text;
                        dr["ColorId"] = gvrow.Cells[8].Text;

                        dr["SoMatId"] = gvrow.Cells[9].Text;
                        dr["IssuedQty"] = gvrow.Cells[10].Text;
                        dr["Remarks"] = gvrow.Cells[11].Text;

                        dr["BlockedQty"] = gvrow.Cells[12].Text;
                        dr["FreeQty"] = gvrow.Cells[13].Text;


                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = gvrow.Cells[1].Text;
                    dr["Series"] = gvrow.Cells[2].Text;
                    dr["Length"] = gvrow.Cells[3].Text;
                    dr["Uom"] = gvrow.Cells[4].Text;
                    dr["Color"] = gvrow.Cells[5].Text;
                    dr["ReqQty"] = gvrow.Cells[6].Text;
                    dr["ItemCodeId"] = gvrow.Cells[7].Text;
                    dr["ColorId"] = gvrow.Cells[8].Text;

                    dr["SoMatId"] = gvrow.Cells[9].Text;

                    TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                    dr["IssuedQty"] = Qty.Text;
                    TextBox Remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                    dr["Remarks"] = Remarks.Text;

                    dr["BlockedQty"] = gvrow.Cells[12].Text;
                    dr["FreeQty"] = gvrow.Cells[13].Text;


                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }

        if (gvItems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["ItemCode"] = ddlitemCode.SelectedItem.Text;
            drnew["Series"] = txtseries.Text;
            drnew["Length"] = ddllength.SelectedItem.Text;
            drnew["Uom"] = txtUom.Text;
            drnew["Color"] = ddlColor.SelectedItem.Text;
            drnew["ReqQty"] = txtQty.Text;
            drnew["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
            drnew["ColorId"] = ddlColor.SelectedItem.Value;
            drnew["SoMatId"] = "0";
            drnew["IssuedQty"] = txtQty.Text;
            drnew["Remarks"] = txtremakrs.Text;

            drnew["BlockedQty"] = txtpreviousBlockedStock.Text;
            drnew["FreeQty"] = txtAvailableStocktoBlock.Text;

            //TextBox Qty = (TextBox)gvItems.FindControl("txtitemqty");
            //drnew["IssuedQty"] = txtQty.Text;
            //TextBox Remarks = (TextBox)gvItems.FindControl("txtitemRemarks");
            //drnew["Remarks"] = Remarks.Text;
            SalesOrderItems.Rows.Add(drnew);
        }
       

        gvItems.DataSource = SalesOrderItems;
        gvItems.DataBind();
        gvItems.SelectedIndex = -1;


        clearitems();

       //}
    }

    private void clearitems()
    {
        Masters.ColorMaster.Color_Select(ddlColor);

        if(ddlSono.SelectedItem.Value != "0")
        {
            SCM.IssueRequest.ItemsIssueRequest_Select(ddlitemCode, ddlRequestedNo.SelectedItem.Value);
        }
        else
        {
            Masters.MaterialMaster.ItemStock_Select(ddlitemCode);
        }
        ddlitemCode.SelectedValue = "0";
        ddlColor.SelectedValue = "0";
        txtseries.Text = "";
        txtUom.Text = "";
        ddllength.Items.Clear();
        txtavailableQty.Text = "";
        txtQty.Text = "";
        txtremakrs.Text = "";
        txtpreviousBlockedStock.Text = "";
        txtAvailableStocktoBlock.Text = "";
        ddllength.Items.Clear(); 
    }

    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;

        }
    }

    protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvItems.Rows[e.RowIndex].Cells[0].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ItemCode");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Length");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Uom");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ReqQty");
        SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Warehouse");
        //SalesOrderItems.Columns.Add(col);

        //SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoMatId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("IssuedQty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Remarks");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("BlockedQty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("FreeQty");
        SalesOrderItems.Columns.Add(col);


        if (gvItems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvItems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = gvrow.Cells[1].Text;
                    dr["Series"] = gvrow.Cells[2].Text;
                    dr["Length"] = gvrow.Cells[3].Text;
                    dr["Uom"] = gvrow.Cells[4].Text;
                    dr["Color"] = gvrow.Cells[5].Text;
                    dr["ReqQty"] = gvrow.Cells[6].Text;

                   

                    dr["ItemCodeId"] = gvrow.Cells[7].Text;
                    dr["ColorId"] = gvrow.Cells[8].Text;
                    dr["SoMatId"] = gvrow.Cells[9].Text;
                  //  dr["IssuedQty"] = gvrow.Cells[10].Text;

                    TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                    dr["IssuedQty"] = Qty.Text;
                    //dr["Remarks"] = gvrow.Cells[11].Text;
                    TextBox Remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                    dr["Remarks"] = Remarks.Text;

                    dr["BlockedQty"] = gvrow.Cells[12].Text;
                    dr["FreeQty"] = gvrow.Cells[13].Text;

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
            SCM.MaterialIssue objMaster = new SCM.MaterialIssue();

            objMaster.IssueNo = txtMaterialreqestNo.Text;
            objMaster.IssueDate = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.RequestPurpose = ddlrequesttype.SelectedItem.Value;
            objMaster.ApprovedBy = ddlapprovedby.SelectedItem.Value;
            objMaster.RequestedBy = ddlrequestedby.SelectedItem.Value;
            objMaster.Custid = ddlCustomer.SelectedItem.Value;
            objMaster.SoId = ddlSono.SelectedItem.Value;
            objMaster.RequestId = ddlRequestedNo.SelectedItem.Value;
            if (objMaster.MaterialIssue_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[7].Text;
                    objMaster.ReqQuantity = gvRowOtherCorp.Cells[6].Text;
                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.Issuedqty = qty.Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[8].Text;
                    objMaster.sodetid = gvRowOtherCorp.Cells[9].Text;
                    TextBox Remarks = (TextBox)gvRowOtherCorp.FindControl("txtitemRemarks");
                    objMaster.remarks = Remarks.Text;
                    objMaster.length = gvRowOtherCorp.Cells[3].Text;
                    objMaster.SoId = ddlSono.SelectedItem.Value;

                    objMaster.Receivedqty = "0";

                    objMaster.Blockedqty = gvRowOtherCorp.Cells[12].Text;
                    objMaster.FreeQty = gvRowOtherCorp.Cells[13].Text;


                    objMaster.MaterialIssueDetails_Save();
                    objMaster.Stock_Update(objMaster.Itemcode, objMaster.Issuedqty, "1", objMaster.ColorId, "1", objMaster.length);

                    if(objMaster.SoId != "0")
                    {
                        objMaster.BlockStock_Update(objMaster.Itemcode, objMaster.Issuedqty, objMaster.ColorId, objMaster.SoId, objMaster.length);
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
            Response.Redirect("~/Modules/Stock/MaterialIssue.aspx");
        }
    }

    private void po_Update()
    {
        try
        {
            SCM.MaterialIssue objMaster = new SCM.MaterialIssue();
            objMaster.MaterialIssueId = Request.QueryString["Cid"].ToString();
            objMaster.IssueNo = txtMaterialreqestNo.Text;
            objMaster.IssueDate = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.RequestPurpose = ddlrequesttype.SelectedItem.Value;
            objMaster.ApprovedBy = ddlapprovedby.SelectedItem.Value;
            objMaster.RequestedBy = ddlrequestedby.SelectedItem.Value;
            objMaster.Custid = ddlCustomer.SelectedItem.Value;
            objMaster.SoId = ddlSono.SelectedItem.Value;
            objMaster.RequestId = ddlRequestedNo.SelectedItem.Value;
            if (objMaster.MaterialIssue_Update() == "Data Updated Successfully")
            {
                objMaster.MaterialIssueDetails_Delete(objMaster.MaterialIssueId);
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[7].Text;
                    objMaster.ReqQuantity = gvRowOtherCorp.Cells[6].Text;
                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.Issuedqty = qty.Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[8].Text;
                    objMaster.sodetid = gvRowOtherCorp.Cells[9].Text;
                    TextBox Remarks = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.remarks = Remarks.Text;
                    objMaster.length = gvRowOtherCorp.Cells[3].Text;
                    objMaster.SoId = ddlSono.SelectedItem.Value;
                    objMaster.Receivedqty = "0";
                    objMaster.Blockedqty = gvRowOtherCorp.Cells[12].Text;
                    objMaster.FreeQty = gvRowOtherCorp.Cells[13].Text;
                    objMaster.MaterialIssueDetails_Save();
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
            Response.Redirect("~/Modules/Stock/MaterialIssue.aspx");
        }
    }

    protected void gvmatana_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[11].Visible = false;
            //e.Row.Cells[10].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Itemcode = e.Row.Cells[7].Text.ToString();
            string ColorId = e.Row.Cells[8].Text.ToString();
            string matid = e.Row.Cells[9].Text.ToString();

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


                if (obj1.BlockStockSo(Itemcode, ColorId,soid,length) > 0)
                {
                    e.Row.Cells[12].Text = obj1.BlockQty;
                }

                if (obj1.IssuedStockSO(Itemcode, ColorId,soid,length) > 0)
                {
                    e.Row.Cells[13].Text = obj1.Issuedqty;
                }

                if(obj1.SoMCLStockAvailable(Itemcode,ColorId,length,soid) > 0)
                {
                    e.Row.Cells[14].Text = obj1.FreeStock;
                }




            }

            //    //DropDownList ddlwarehouse = (e.Row.FindControl("ddlSowaerhose") as DropDownList);
            //    //Masters.StorageLocation.StorageLocation_Select(ddlwarehouse);
        }
    }

   
    //Grid

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ItemCode");
        dt.Columns.Add("Series");
        dt.Columns.Add("Length");
        dt.Columns.Add("Uom");
        dt.Columns.Add("Color");
        dt.Columns.Add("ReqQty");
        dt.Columns.Add("ItemCodeId");
        dt.Columns.Add("ColorId");
        dt.Columns.Add("SoMatId");
        dt.Columns.Add("IssuedQty");
        dt.Columns.Add("Remarks");

        dt.Columns.Add("BlockedQty");
        dt.Columns.Add("FreeQty");


        //dt.Columns.Add("WarehouseId");
        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        //DataRow[] dr = dt.Select("SoMatId = '" + gvRow.Cells[9].Text + "'");

        DataRow[] dr = dt.Select("ItemCodeId = '" + gvRow.Cells[7].Text + "' and ColorId = '" + gvRow.Cells[8].Text + "' and  Length = '" + gvRow.Cells[3].Text + "' ");

        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["ItemCode"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["Series"] = gvRow.Cells[2].Text;
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
            dt.Rows[dt.Rows.Count - 1]["ItemCodeId"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["ColorId"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["SoMatId"] = gvRow.Cells[9].Text;
            dt.Rows[dt.Rows.Count - 1]["IssuedQty"] = "";
            dt.Rows[dt.Rows.Count - 1]["Remarks"] = "";

            dt.Rows[dt.Rows.Count - 1]["BlockedQty"] = gvRow.Cells[12].Text;
            dt.Rows[dt.Rows.Count - 1]["FreeQty"] = gvRow.Cells[14].Text;


            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
       // DataRow[] dr = dt.Select("SoMatId = '" + gvRow.Cells[9].Text + "'");

        DataRow[] dr = dt.Select("ItemCodeId = '" + gvRow.Cells[7].Text + "' and ColorId = '" + gvRow.Cells[8].Text + "' and  Length = '" + gvRow.Cells[3].Text + "' ");

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
    protected void ddlRequestedNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.IssueRequest obj = new SCM.IssueRequest();
        if(obj.IssueRequest_Select(ddlRequestedNo.SelectedItem.Value) > 0)
        {
            ddlSono.SelectedValue = obj.SoId;
            ddlCustomer.SelectedValue = obj.Custid;
            ddlrequestedby.SelectedValue = obj.RequestedBy;
            obj.IssueRequestDetails_Select(ddlRequestedNo.SelectedItem.Value, gvmatana);

            SCM.IssueRequest.ItemsIssueRequest_Select(ddlitemCode, ddlRequestedNo.SelectedItem.Value);
        }
    }
    protected void ddllength_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.Stock Stock = new SCM.Stock();

        if (Stock.MCLStockAvailable(ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value, ddllength.SelectedItem.Value) > 0)
        {
            txtavailableQty.Text = Stock.TStock;
        }

        if (int.Parse(ddlSono.SelectedItem.Value) > 0)
        {
            if (Stock.SoMCLStockAvailable(ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value, ddllength.SelectedItem.Value, ddlSono.SelectedItem.Value) > 0)
            {
                txtpreviousBlockedStock.Text = Stock.PreviousBlockforSo;
                txtAvailableStocktoBlock.Text = Stock.FreeStock;
            }
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
}