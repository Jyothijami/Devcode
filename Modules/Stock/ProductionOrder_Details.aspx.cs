using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_ProductionOrder_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {


            txtProductionOrderno.Text = SCM.ProductionOrder.ProductionOrderNo_AutoGenCode();
            SCM.BOM.BOM_Select(ddlBomno);
          //  Masters.MaterialMaster.MaterialMasterGroup_Select(ddlItems);
            Masters.StorageLocation.StorageLocation_Select(ddlworkinprogress);
            Masters.StorageLocation.StorageLocation_Select(ddlScarpwarehouse);
            Masters.StorageLocation.StorageLocation_Select(ddlTargetWarehouse);
            SM.SalesOrder.SalesOrder_Select(ddlSoID);
          //  Masters.MaterialMaster.MaterialMaster_Select(ddlItemCode);
            if (Qid != "Add")
            {

                CategoryFill();

            }
            
        }
    }


    private void CategoryFill()
    {
        SCM.ProductionOrder objmaster = new SCM.ProductionOrder();
        if (objmaster.ProductionOrder_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
         //   ddlItems.SelectedValue = objmaster.ItemId;
            ddlBomno.SelectedValue = objmaster.BomId;
            txtQtytoManufacture.Text = objmaster.QtytoManf;
         //   ddlSono.SelectedValue = objmaster.SOid;
            ddlworkinprogress.SelectedValue = objmaster.WorkinprogressId;
            ddlScarpwarehouse.SelectedValue = objmaster.ScrapWarehouseId;
            ddlTargetWarehouse.SelectedValue = objmaster.TargetWarehouseId;
            txtplannedstartdate.Text = objmaster.PlannedStartDate;
            txtexpectedDeliverydate.Text = objmaster.ExpectedDeliveryDate;
            
            objmaster.ProductionDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);
        }
    }




   
    protected void btnAddnew_Click(object sender, EventArgs e)
    {
        //DataTable SalesOrderItems = new DataTable();
        //DataColumn col = new DataColumn();
        //col = new DataColumn("ItemCode");
        //SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("SourceWarehouse");
        //SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("ReqQty");
        //SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Transferqty");
        //SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("ItemcodeId");
        //SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Sourcewarehouseid");
        //SalesOrderItems.Columns.Add(col);
        //if (gvItems.Rows.Count > 0)
        //{
        //    foreach (GridViewRow gvrow in gvItems.Rows)
        //    {
        //        if (gvItems.SelectedIndex > -1)
        //        {
        //            if (gvrow.RowIndex == gvItems.SelectedRow.RowIndex)
        //            {
        //                DataRow dr = SalesOrderItems.NewRow();
        //                dr["ItemCode"] = ddlItemCode.SelectedItem.Text;
        //                dr["SourceWarehouse"] = ddlsourcewarehouse.SelectedItem.Value ;
        //                dr["ReqQty"] = txtRequiredQty.Text;
        //                dr["Transferqty"] = "0";
        //                dr["ItemcodeId"] = ddlItemCode.SelectedItem.Value;
        //                dr["Sourcewarehouseid"] = ddlsourcewarehouse.SelectedItem.Value;
        //                SalesOrderItems.Rows.Add(dr);
        //            }
        //            else
        //            {
        //                DataRow dr = SalesOrderItems.NewRow();
        //                dr["ItemCode"] = gvrow.Cells[1].Text;
        //                dr["SourceWarehouse"] = gvrow.Cells[2].Text;
        //                dr["ReqQty"] = gvrow.Cells[3].Text;
        //                dr["Transferqty"] = gvrow.Cells[4].Text;
        //                dr["ItemcodeId"] = gvrow.Cells[5].Text;
        //                dr["Sourcewarehouseid"] = gvrow.Cells[6].Text;

        //                SalesOrderItems.Rows.Add(dr);
        //            }
        //        }
        //        else
        //        {
        //            DataRow dr = SalesOrderItems.NewRow();
        //            dr["ItemCode"] = gvrow.Cells[1].Text;
        //            dr["SourceWarehouse"] = gvrow.Cells[2].Text;
        //            dr["ReqQty"] = gvrow.Cells[3].Text;
        //            dr["Transferqty"] = gvrow.Cells[4].Text;
        //            dr["ItemcodeId"] = gvrow.Cells[5].Text;
        //            dr["Sourcewarehouseid"] = gvrow.Cells[6].Text;

        //            SalesOrderItems.Rows.Add(dr);
        //        }
        //    }
        //}


        //if (gvItems.SelectedIndex == -1)
        //{
        //    DataRow drnew = SalesOrderItems.NewRow();
        //    drnew["ItemCode"] = ddlItemCode.SelectedItem.Text;
        //    drnew["SourceWarehouse"] = ddlsourcewarehouse.SelectedItem.Value;
        //    drnew["ReqQty"] = txtRequiredQty.Text;
        //    drnew["Transferqty"] = "0";
        //    drnew["ItemcodeId"] = ddlItemCode.SelectedItem.Value;
        //    drnew["Sourcewarehouseid"] = ddlsourcewarehouse.SelectedItem.Value;
        //    SalesOrderItems.Rows.Add(drnew);

        //}
        //gvItems.DataSource = SalesOrderItems;
        //gvItems.DataBind();
        //gvItems.SelectedIndex = -1;
    }


    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
        }
    }

    protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //string x1 = gvItems.Rows[e.RowIndex].Cells[1].Text;
        //DataTable SalesOrderItems = new DataTable();
        //DataColumn col = new DataColumn();
        //col = new DataColumn("ItemCode");
        //SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("SourceWarehouse");
        //SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("ReqQty");
        //SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Transferqty");
        //SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("ItemcodeId");
        //SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Sourcewarehouseid");
        //SalesOrderItems.Columns.Add(col);

        //if (gvItems.Rows.Count > 0)
        //{
        //    foreach (GridViewRow gvrow in gvItems.Rows)
        //    {
        //        if (gvrow.RowIndex != e.RowIndex)
        //        {
        //            DataRow dr = SalesOrderItems.NewRow();
        //            dr["ItemCode"] = gvrow.Cells[1].Text;
        //            dr["SourceWarehouse"] = gvrow.Cells[2].Text;
        //            dr["ReqQty"] = gvrow.Cells[3].Text;
        //            dr["Transferqty"] = gvrow.Cells[4].Text;
        //            dr["ItemcodeId"] = gvrow.Cells[5].Text;
        //            dr["Sourcewarehouseid"] = gvrow.Cells[6].Text;
        //            SalesOrderItems.Rows.Add(dr);
        //        }
        //    }
        //}
        //gvItems.DataSource = SalesOrderItems;
        //gvItems.DataBind();
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
            SCM.ProductionOrder objMaster = new SCM.ProductionOrder();

            objMaster.ProductionNo = txtProductionOrderno.Text;
            objMaster.ItemId = ddlsodetid.SelectedItem.Value;
            objMaster.BomId = ddlBomno.SelectedItem.Value;
            objMaster.QtytoManf = txtQtytoManufacture.Text;
            objMaster.SOid = ddlSoID.SelectedItem.Value;
            objMaster.WorkinprogressId = ddlworkinprogress.SelectedItem.Value;
            objMaster.ScrapWarehouseId = ddlScarpwarehouse.SelectedItem.Value;
            objMaster.TargetWarehouseId = ddlTargetWarehouse.SelectedItem.Value;
            objMaster.PlannedStartDate = General.toMMDDYYYY(txtplannedstartdate.Text);
            objMaster.ExpectedDeliveryDate = General.toMMDDYYYY(txtexpectedDeliverydate.Text);
            objMaster.PreparedBy = "0";
            objMaster.Status = "Not Started";

           
            if (objMaster.ProductionOrder_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.ItemCode = gvRowOtherCorp.Cells[8].Text;
                    objMaster.Color = gvRowOtherCorp.Cells[9].Text;
                    objMaster.reqqty = gvRowOtherCorp.Cells[3].Text;
                    objMaster.barlength = gvRowOtherCorp.Cells[4].Text;
                    objMaster.requiredbarlength = gvRowOtherCorp.Cells[5].Text;
                    objMaster.transferqty = gvRowOtherCorp.Cells[6].Text;
                    objMaster.uom = gvRowOtherCorp.Cells[7].Text;
                    objMaster.ItemScarpwarehouseid = ddlScarpwarehouse.SelectedItem.Value;
                    objMaster.ItemSourcewarehouseid = "0";
                    objMaster.ItemTargetwarehouseid = ddlTargetWarehouse.SelectedItem.Value;
                    objMaster.ProductionOrderDetails_Save();
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
            Response.Redirect("~/Modules/Stock/ProductionOrder.aspx");
        }
    }



    private void po_Update()
    {
        try
        {

            SCM.ProductionOrder objMaster = new SCM.ProductionOrder();
            objMaster.ProductionId = Request.QueryString["Cid"].ToString();
            objMaster.ProductionNo = txtProductionOrderno.Text;
          //  objMaster.ItemId = ddlItems.SelectedItem.Value;
            objMaster.BomId = ddlBomno.SelectedItem.Value;
            objMaster.QtytoManf = txtQtytoManufacture.Text;
           // objMaster.SOid = ddlSono.SelectedItem.Value;
            objMaster.WorkinprogressId = ddlworkinprogress.SelectedItem.Value;
            objMaster.ScrapWarehouseId = ddlScarpwarehouse.SelectedItem.Value;
            objMaster.TargetWarehouseId = ddlTargetWarehouse.SelectedItem.Value;
            objMaster.PlannedStartDate = General.toMMDDYYYY(txtplannedstartdate.Text);
            objMaster.ExpectedDeliveryDate = General.toMMDDYYYY(txtexpectedDeliverydate.Text);
            objMaster.PreparedBy = "0";
            objMaster.Status = "Not Started";

            if (objMaster.ProductionOrder_Update() == "Data Updated Successfully")
            {

                objMaster.ProductionOrderDetails_Delete(objMaster.BomId);
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.ItemCode = gvRowOtherCorp.Cells[8].Text;
                    objMaster.Color = gvRowOtherCorp.Cells[9].Text;
                    objMaster.reqqty = gvRowOtherCorp.Cells[3].Text;
                    objMaster.barlength = gvRowOtherCorp.Cells[4].Text;
                    objMaster.requiredbarlength = gvRowOtherCorp.Cells[5].Text;
                    objMaster.transferqty = gvRowOtherCorp.Cells[6].Text;
                    objMaster.uom = gvRowOtherCorp.Cells[7].Text;
                    objMaster.ItemScarpwarehouseid = ddlScarpwarehouse.SelectedItem.Value;
                    objMaster.ItemSourcewarehouseid = "0";
                    objMaster.ItemTargetwarehouseid = ddlTargetWarehouse.SelectedItem.Value;
                    objMaster.ProductionOrderDetails_Save();
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
            Response.Redirect("~/Modules/Stock/ProductionOrder.aspx");
        }
    }


    //protected void ddlsourcewarehouse_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SCM.Stock obj = new SCM.Stock();

    //    if(obj.StockOnStorageLocation(ddlItemCode.SelectedItem.Value,ddlsourcewarehouse.SelectedItem.Value) > 0)
    //    {
    //        txtavailableqtysource.Text = obj.Quantity;
    //    }


    //}
    protected void ddlBomno_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.BOM obj = new SCM.BOM();

        if(obj.Bom_Select(ddlBomno.SelectedItem.Value) > 0)
        {

            ddlSoID.SelectedValue = obj.Soid;
            ddlSoID_SelectedIndexChanged(sender, e);
            ddlsodetid.SelectedValue = obj.SoDetId;
            txtQtytoManufacture.Text = obj.Quantity;

            obj.BomProductionDetails_Select(ddlBomno.SelectedItem.Value, gvItems);
        }

       
     
       
    }
    protected void txtQtytoManufacture_TextChanged(object sender, EventArgs e)
    {
        if(int.Parse(ddlBomno.SelectedItem.Value) > 0)
        {
            SCM.ProductionOrder obj = new SCM.ProductionOrder();
            obj.BomQtyProductionDetails_Select(ddlBomno.SelectedItem.Value,txtQtytoManufacture.Text, gvItems);
        }
    }
    protected void ddlSoID_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesOrder.SalesOrderItemBomStatus_Select(ddlsodetid, ddlSoID.SelectedItem.Value);
    }
}