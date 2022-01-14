using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_MaterialTrasfer_ManufactureDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

        if (!IsPostBack)
        {
            SCM.ProductionOrder.ProductionOrder_Select(ddlproductionNo);
            SCM.BOM.BOM_Select(ddlbomno);
            Masters.StorageLocation.StorageLocation_Select(ddlworkinprogress);
            Masters.StorageLocation.StorageLocation_Select(ddlScarpwarehouse);
            Masters.StorageLocation.StorageLocation_Select(ddlTargetWarehouse);
            Masters.MaterialMaster.MaterialMasterGroup_Select(ddlitem);

            Masters.MaterialMaster.MaterialMaster_Select(ddlitemcode);
            Masters.ColorMaster.Color_Select(ddlColor);
            Masters.StorageLocation.StorageLocation_Select(ddlitemSourceWarehouse);
            Masters.StorageLocation.StorageLocation_Select(ddlitemTargetwarehouse);


           
           // General.GridBindwithCommand(hai, "Select * from Customer_Units where CUST_ID = '" + Request.QueryString["Cid"].ToString() + "'");
            if (Qid != "Add")
            {
                productionorderFill();
            }
        }
    }

    private void productionorderFill()
    {
        SCM.ProductionOrder objmaster = new SCM.ProductionOrder();
        if (objmaster.ProductionOrder_Select(Request.QueryString["Cid"].ToString()) > 0)
        {

            if (objmaster.Status == "Not Started")
            {
                btnstatus.Text = "Start";
            }
            if (objmaster.Status == "InProcess")
            {
                btnstatus.Text = "Finish";
            }

            ddlproductionNo.SelectedValue = objmaster.ProductionId;
            ddlbomno.SelectedValue = objmaster.BomId;
            ddlitem.SelectedValue = objmaster.ItemId;
            txtforquantity.Text = objmaster.QtytoManf;
            ddlScarpwarehouse.SelectedValue = objmaster.ScrapWarehouseId;
            ddlTargetWarehouse.SelectedValue = objmaster.TargetWarehouseId;
            ddlworkinprogress.SelectedValue = objmaster.WorkinprogressId;
            objmaster.ProductionDetails_Selectformaterialtranfer(Request.QueryString["Cid"].ToString(), gvItems);
        }
    }
    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
        }
    }
    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        LinkButton lbtnCompanyName;
        lbtnCompanyName = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnCompanyName.Parent.Parent;
        gvItems.SelectedIndex = gvRow.RowIndex;

        if (gvItems.SelectedIndex > -1)
        {

            tblDetails.Visible = true;

            ddlitemcode.SelectedValue = gvItems.SelectedRow.Cells[11].Text;
            ddlColor.SelectedValue = gvItems.SelectedRow.Cells[12].Text;

            SCM.Stock.StockOnItemandColor(ddlitemSourceWarehouse, ddlitemcode.SelectedItem.Value, ddlColor.SelectedItem.Value);
            
            ddlitemTargetwarehouse.SelectedValue = ddlworkinprogress.SelectedItem.Value;

            txtitemuom.Text = gvItems.SelectedRow.Cells[7].Text;
            txtitemreqqty.Text = gvItems.SelectedRow.Cells[3].Text;
            txtItemqtyatsourcewarehouse.Text = "0";
            txtitemtranserqty.Text = "0";
            lblProddetid.Text = gvItems.SelectedRow.Cells[16].Text;

            //txtnooffloors.Text = hai.SelectedRow.Cells[3].Text;
            //txtwinload.Text = hai.SelectedRow.Cells[4].Text;

            btnSave.Text = "Update";
        }
        else
        {
            MessageBox.Show(this, "Please select atleast a Record");
        }
    }
    protected void ddlitemSourceWarehouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.Stock obj = new SCM.Stock();
        if(obj.StockOnStorageLocationCCS(ddlitemcode.SelectedItem.Value,ddlColor.SelectedItem.Value,ddlitemSourceWarehouse.SelectedItem.Value) > 0)
        {
            txtItemqtyatsourcewarehouse.Text = obj.Quantity;
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SCM.MaterialReceipt objMaster = new SCM.MaterialReceipt();
            objMaster.podetid = lblProddetid.Text;
            objMaster.transferqty = txtitemtranserqty.Text;
            objMaster.sourcewarehouseid = ddlitemSourceWarehouse.SelectedItem.Value;
            objMaster.targetwarehouseid = ddlitemTargetwarehouse.SelectedItem.Value;
            objMaster.scrapwarehouseid = ddlScarpwarehouse.SelectedItem.Value;

            objMaster.MaterialTransferManufacutere_Update();
            objMaster.StockMinus_Update(ddlitemcode.SelectedItem.Value, txtitemtranserqty.Text, ddlColor.SelectedItem.Value, ddlitemSourceWarehouse.SelectedItem.Value);
            objMaster.StockPuls_Update(ddlitemcode.SelectedItem.Value, txtitemtranserqty.Text, ddlColor.SelectedItem.Value, ddlitemTargetwarehouse.SelectedItem.Value);

            MessageBox.Show(this, "Item Updated Successfully");
            
           
            
        }
        catch (Exception ex)
        {
            MessageBox.Notify(this, ex.Message);
        }
        finally
        {
            txtItemqtyatsourcewarehouse.Text = "0";
            txtitemtranserqty.Text = "0";
            ddlitemSourceWarehouse.SelectedValue = "0";
            tblDetails.Visible = false;
            productionorderFill();
        }
    }
    protected void btnstatus_Click(object sender, EventArgs e)
    {
        if (btnstatus.Text == "Not Started")
        {
            foreach (GridViewRow row in gvItems.Rows)
            {
                if(row.Cells[6].Text == "0")
                {
                    MessageBox.Show(this, "Please Transfer qty before Start");
                }
                else
                {
                    SCM.ProductionOrder obj = new SCM.ProductionOrder();

                    obj.ProductionId = ddlproductionNo.SelectedItem.Value;
                    obj.Status = "In Process";
                    MessageBox.Show(this, obj.ProductionOrderStatus_Update());

                }
            }
        }

        else if (btnstatus.Text == "In Process")
        {
            
                
                    SCM.ProductionOrder obj = new SCM.ProductionOrder();

                    obj.ProductionId = ddlproductionNo.SelectedItem.Value;
                    obj.Status = "Completed";
                    obj.ProductionOrderStatus_Update();


                    SCM.MaterialReceipt objMaster = new SCM.MaterialReceipt();
                    objMaster.StockPuls_Update(ddlitem.SelectedItem.Value, txtforquantity.Text, "0", ddlTargetWarehouse.SelectedItem.Value);

                    foreach (GridViewRow row in gvItems.Rows)
                    {
                        objMaster.StockMinus_Update(row.Cells[11].Text, row.Cells[6].Text, row.Cells[12].Text, row.Cells[14].Text);
                    }
        }



    }
}