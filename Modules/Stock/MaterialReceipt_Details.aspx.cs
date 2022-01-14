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

public partial class Modules_Stock_MaterialReceipt_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            
            Masters.MaterialMaster.MaterialMaster_Select(ddlitemCode);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            txtMaterialReceiptNo.Text = SCM.MaterialReceipt.MaterialReceipt_AutoGenCode();
            Masters.StorageLocation.StorageLocation_Select(ddlTargetwarehouse);
            txtPostingdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            gvItems.DataBind();
            if (Qid != "Add")
            {

                CategoryFill();

            }
        }
    }


    private void CategoryFill()
    {
        SCM.MaterialReceipt objmaster = new SCM.MaterialReceipt();
        if (objmaster.MaterialReceipt_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtPostingdate.Text = objmaster.PostingDate;
            txtMaterialReceiptNo.Text = objmaster.MrNo;
            ddlpreparedby.SelectedValue = objmaster.Preparedby;
            objmaster.MaterialReceiptDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);
        }
    }





   
    protected void ddlitemCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        Masters.MaterialMaster.ItemMaster_ModelNoSelect(ddlColor, ddlitemCode.SelectedValue);
    }
    protected void btnadditem_Click(object sender, EventArgs e)
    {
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ItemCode");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
      
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Warehouse");
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
                        dr["Qty"] = txtQty.Text; ;
                        dr["Warehouse"] = ddlTargetwarehouse.SelectedItem.Text;
                        dr["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
                        dr["Color"] = ddlColor.SelectedItem.Text;
                        dr["ColorId"] = ddlColor.SelectedItem.Value;
                        dr["WarehouseId"] = ddlTargetwarehouse.SelectedItem.Value;

                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["ItemCode"] = gvrow.Cells[1].Text;
                        dr["Color"] = gvrow.Cells[2].Text;
                        dr["Warehouse"] = gvrow.Cells[3].Text;
                        dr["Qty"] = gvrow.Cells[4].Text;
                       
                        dr["ItemCodeId"] = gvrow.Cells[5].Text;

                        dr["ColorId"] = gvrow.Cells[6].Text;
                        dr["WarehouseId"] = gvrow.Cells[7].Text;

                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = gvrow.Cells[1].Text;
                    dr["Color"] = gvrow.Cells[2].Text;
                    dr["Warehouse"] = gvrow.Cells[3].Text;
                    dr["Qty"] = gvrow.Cells[4].Text;

                    dr["ItemCodeId"] = gvrow.Cells[5].Text;

                    dr["ColorId"] = gvrow.Cells[6].Text;
                    dr["WarehouseId"] = gvrow.Cells[7].Text;

                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }


        if (gvItems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["ItemCode"] = ddlitemCode.SelectedItem.Text;
            drnew["Qty"] = txtQty.Text; ;
            drnew["Warehouse"] = ddlTargetwarehouse.SelectedItem.Text;
            drnew["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
            drnew["Color"] = ddlColor.SelectedItem.Text;
            drnew["ColorId"] = ddlColor.SelectedItem.Value;
            drnew["WarehouseId"] = ddlTargetwarehouse.SelectedItem.Value;

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

            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
        }
    }
    protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvItems.Rows[e.RowIndex].Cells[1].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ItemCode");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Warehouse");
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
                    dr["Warehouse"] = gvrow.Cells[3].Text;
                    dr["Qty"] = gvrow.Cells[4].Text;

                    dr["ItemCodeId"] = gvrow.Cells[5].Text;

                    dr["ColorId"] = gvrow.Cells[6].Text;
                    dr["WarehouseId"] = gvrow.Cells[7].Text;

                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvItems.DataSource = SalesOrderItems;
        gvItems.DataBind();
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
            SCM.MaterialReceipt objMaster = new SCM.MaterialReceipt();

            objMaster.MrNo = txtMaterialReceiptNo.Text;
            objMaster.PostingDate =General.toMMDDYYYY(txtPostingdate.Text);
            objMaster.Preparedby = ddlpreparedby.SelectedItem.Value;
            

            


            if (objMaster.MaterialReceipt_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.matid = gvRowOtherCorp.Cells[5].Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[6].Text;
                    objMaster.Qty = gvRowOtherCorp.Cells[4].Text;
                    objMaster.StorageLocid = gvRowOtherCorp.Cells[7].Text;
                    objMaster.MaterialReceiptDetails_Save();

                    objMaster.Stock_Update(objMaster.matid, objMaster.Qty, "1", objMaster.ColorId, objMaster.StorageLocid);

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
            Response.Redirect("~/Modules/Stock/MaterialReceipt.aspx");
        }
    }


    private void po_Update()
    {
        try
        {

            SCM.MaterialReceipt objMaster = new SCM.MaterialReceipt();
            objMaster.MrId = Request.QueryString["Cid"].ToString();
            objMaster.MrNo = txtMaterialReceiptNo.Text;
            objMaster.PostingDate = General.toMMDDYYYY(txtPostingdate.Text);
            objMaster.Preparedby = ddlpreparedby.SelectedItem.Value;
       

            if (objMaster.MaterialReceipt_Update() == "Data Updated Successfully")
            {

                objMaster.MaterialReceiptDetails_Delete(objMaster.MrId);
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.matid = gvRowOtherCorp.Cells[5].Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[6].Text;
                    objMaster.Qty = gvRowOtherCorp.Cells[4].Text;
                    objMaster.StorageLocid = gvRowOtherCorp.Cells[7].Text;
                    objMaster.MaterialReceiptDetails_Save();
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
            Response.Redirect("~/Modules/Stock/MaterialReceipt.aspx");
        }
    }




}