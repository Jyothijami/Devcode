using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_BomDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if(!IsPostBack)
        {
            cblPermissions.ClearSelection();
            cblPermissions.DataBind();
            SM.SalesOrder.SalesOrder_Select(ddlsalesorderno);
            Masters.MaterialMaster.MaterialMaster_Select(ddlitemCode);
            txtBomNo.Text = SCM.BOM.BOMNo_AutoGenCode();



            gvItems.DataBind();
            if (Qid != "Add")
            {
                SM.SalesOrder.SalesOrderItemWS_Select(ddlsalesorderitems);
               
                CategoryFill();
                
            }
        }
    }


    private void CategoryFill()
    {
        SCM.BOM objmaster = new SCM.BOM();
        if (objmaster.Bom_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            ddlsalesorderno.SelectedValue = objmaster.Soid;
            ddlsalesorderitems.SelectedValue = objmaster.SoDetId;
            ddlsalesorderitems_SelectedIndexChanged(new object(), new System.EventArgs());
            txtQuantity.Text = objmaster.Quantity;
            txtBomNo.Text = objmaster.BomNo;
            DataTable dt = objmaster.BomOperations_Select(int.Parse(ddlsalesorderitems.SelectedItem.Value));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem currentCheckBox = cblPermissions.Items.FindByValue(dt.Rows[i][0].ToString());
                if (currentCheckBox != null)
                {
                    currentCheckBox.Selected = true;
                }
            }
            objmaster.BomDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);
        }
    }





   
    protected void ddlitemCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.MaterialMaster obj = new Masters.MaterialMaster();
        if (obj.MaterialType_Select(ddlitemCode.SelectedItem.Value) > 0)
        {
            txtbarlength.Text = obj.BarLength;
            txtItemUom.Text = obj.UomName;
            Masters.MaterialMaster.ItemMaster_ModelNoSelect(ddlColor, ddlitemCode.SelectedValue);
        }
       
    }
    protected void btnadditem_Click(object sender, EventArgs e)
    {
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ItemCode");
        SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Qty");
        //SalesOrderItems.Columns.Add(col);
        col = new DataColumn("UOM");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Required");
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
                        //dr["Qty"] = txtQty.Text; ;
                        dr["UOM"] = txtItemUom.Text;
                        dr["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
                        dr["Color"] = ddlColor.SelectedItem.Text;
                        dr["ColorId"] = ddlColor.SelectedItem.Value;
                        dr["Required"] = txtrequiredbarlength.Text;
                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["ItemCode"] = gvrow.Cells[1].Text;
                        dr["Color"] = gvrow.Cells[2].Text;
                        //dr["Qty"] = gvrow.Cells[3].Text;
                        dr["Required"] = gvrow.Cells[3].Text;
                        dr["UOM"] = gvrow.Cells[4].Text;
                        dr["ItemCodeId"] = gvrow.Cells[5].Text;
                        
                        dr["ColorId"] = gvrow.Cells[6].Text;

                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = gvrow.Cells[1].Text;
                    dr["Color"] = gvrow.Cells[2].Text;
                    //dr["Qty"] = gvrow.Cells[3].Text;
                    dr["Required"] = gvrow.Cells[3].Text;
                    dr["UOM"] = gvrow.Cells[4].Text;
                    dr["ItemCodeId"] = gvrow.Cells[5].Text;

                    dr["ColorId"] = gvrow.Cells[6].Text;
                  
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }


        if (gvItems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["ItemCode"] = ddlitemCode.SelectedItem.Text;
            //drnew["Qty"] = txtQty.Text;
            drnew["UOM"] = txtItemUom.Text;
            drnew["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
            drnew["Color"] = ddlColor.SelectedItem.Text;
            drnew["ColorId"] = ddlColor.SelectedItem.Value;
            drnew["Required"] = txtrequiredbarlength.Text;
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
        }
    }
    protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvItems.Rows[e.RowIndex].Cells[1].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ItemCode");
        SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Qty");
        //SalesOrderItems.Columns.Add(col);
        col = new DataColumn("UOM");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Required");
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
                    //dr["Qty"] = gvrow.Cells[3].Text;
                    dr["Required"] = gvrow.Cells[3].Text;
                    dr["UOM"] = gvrow.Cells[4].Text;
                    dr["ItemCodeId"] = gvrow.Cells[5].Text;

                    dr["ColorId"] = gvrow.Cells[6].Text;

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
            SCM.BOM objMaster = new SCM.BOM();

            objMaster.Soid = ddlsalesorderno.SelectedItem.Value;
            objMaster.SoDetId = ddlsalesorderitems.SelectedItem.Value;

            objMaster.Quantity = txtQuantity.Text;

          

            objMaster.BomNo = txtBomNo.Text;
            objMaster.Status = "Yes";
            foreach (ListItem Permissions in cblPermissions.Items)
            {
                if (Permissions.Selected == true)
                {
                    objMaster.BomOperations_Save(int.Parse(ddlsalesorderitems.SelectedItem.Value), Permissions.Value);

                }
            }
            if (objMaster.BOM_Save() == "Data Saved Successfully")
            {

               
                objMaster.SalesOrderItemAStatus_Update(ddlsalesorderitems.SelectedItem.Value);
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.ItemCodeId = gvRowOtherCorp.Cells[5].Text;
                    objMaster.ItemQty = gvRowOtherCorp.Cells[3].Text;
                    objMaster.Uom = gvRowOtherCorp.Cells[4].Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[6].Text;
                    objMaster.requiredlength = gvRowOtherCorp.Cells[3].Text;
                    objMaster.BomDetails_Save();
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
            Response.Redirect("~/Modules/Stock/Bom.aspx");
        }
    }


    private void po_Update()
    {
        try
        {

            SCM.BOM objMaster = new SCM.BOM();
            objMaster.BomId = Request.QueryString["Cid"].ToString();
            objMaster.Soid = ddlsalesorderno.SelectedItem.Value;
            objMaster.SoDetId = ddlsalesorderitems.SelectedItem.Value;

            objMaster.Quantity = txtQuantity.Text;



            objMaster.BomNo = txtBomNo.Text;
            objMaster.Status = "Yes";


            if (objMaster.BOM_Update() == "Data Updated Successfully")
            {

                objMaster.BomDetails_Delete(objMaster.BomId);
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.ItemCodeId = gvRowOtherCorp.Cells[5].Text;
                    objMaster.ItemQty = gvRowOtherCorp.Cells[3].Text;
                    objMaster.Uom = gvRowOtherCorp.Cells[4].Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[6].Text;
                    objMaster.requiredlength = gvRowOtherCorp.Cells[3].Text;
                    objMaster.BomDetails_Save();
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
            Response.Redirect("~/Modules/Stock/Bom.aspx");
        }
    }




    protected void ddlsalesorderno_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesOrder.SalesOrderItem_Select(ddlsalesorderitems, ddlsalesorderno.SelectedItem.Value);
    }
    protected void ddlsalesorderitems_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesOrder obj = new SM.SalesOrder();
        if(obj.SalesOrderItem_Select(ddlsalesorderitems.SelectedItem.Value) > 0)
        {
            txtwidth.Text = obj.Width;
            txtHeight.Text = obj.Height;
            txtStillheight.Text = obj.TotalArea;
            txtSeries.Text = obj.Series;
            txtQuantity.Text = obj.Quantity;
            txtGlass.Text = obj.Glass;
            txtflyscreen.Text = obj.Flyscreen;
        }
    }
}