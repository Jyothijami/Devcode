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

public partial class Modules_Stock_RequestPackingList_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            Masters.MaterialMaster.ItemStock_Select(ddlitemCode);
            txtplno.Text = SCM.RequestPackingList.RequestPackingPackingList_AutoGenCode();
            txtpldate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlPreparedBy);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            Masters.ColorMaster.Color_Select(ddlColor);
            SM.CustomerMaster.CustomerProjectUnit_Select(ddlso);
            SM.CustomerMaster.CustomerUnit_Select(ddlProject);
            ddlPreparedBy.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            if (Qid != "Add")
            {
                btnApprove.Visible = true;
                CategoryFill();

            }
            else
            {
                btnApprove.Visible = false;
            }
        }
    }

    private void CategoryFill()
    {
        SCM.RequestPackingList objmaster = new SCM.RequestPackingList();
        if (objmaster.RequestPackingList_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtplno.Text = objmaster.RPLNo;
            txtpldate.Text = objmaster.RPLDate;
            ddlso.SelectedValue = objmaster.Soid;
            ddlProject.SelectedValue = objmaster.CustId;
            txtcustaddress.Text = objmaster.CustAddress;
            txtdeliveryaddress.Text = objmaster.DeliveryAddress;

            txttotalpackets.Text = objmaster.TotalPackets;
            txttotalWeight.Text = objmaster.TotalWeight;
            txtmethodofdispacth.Text = objmaster.Methodofdispach;


            objmaster.RequestPackingListDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);

            ddlPreparedBy.SelectedValue = objmaster.preapredby;
            ddlapprovedby.SelectedValue = objmaster.ApprovedBy;
            txttermscondtionscontent.Text = HttpUtility.HtmlDecode(objmaster.Remarks);
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
        txtAvailableStocktoBlock.Text = "";
        txtpreviousBlockedStock.Text = "";

        txtpu.Text = "";

        ddllength.Items.Clear();
    }

    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[7].Visible = false;
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
        //Masters.MaterialMaster obj = new Masters.MaterialMaster();
        //if (obj.MaterialPO_Select(ddlitemCode.SelectedItem.Value) > 0)
        //{
        //    txtseries.Text = obj.Description;
        //    txtUom.Text = obj.UomName;

        //    Masters.MaterialMaster.ColorStock_ModelNoSelect(ddlColor, ddlitemCode.SelectedItem.Value);
        //    Masters.MaterialMaster.LengthStock_ModelNoSelect(ddllength, ddlitemCode.SelectedItem.Value);

        //    if (ddlColor.Items.Count > 0)
        //    {
        //        ddlColor_SelectedIndexChanged(sender, e);
        //    }
        //}


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
            SCM.RequestPackingList objMaster = new SCM.RequestPackingList();

            objMaster.RPLNo = txtplno.Text;
            objMaster.RPLDate = General.toMMDDYYYY(txtpldate.Text);
            objMaster.Soid = ddlso.SelectedItem.Value;
            objMaster.CustId = ddlProject.SelectedItem.Value;
            objMaster.CustAddress = txtcustaddress.Text;
            objMaster.DeliveryAddress = txtdeliveryaddress.Text;
            objMaster.TotalPackets = txttotalpackets.Text;
            objMaster.TotalWeight = txttotalWeight.Text;
            objMaster.Methodofdispach = txtmethodofdispacth.Text;
            objMaster.preapredby = ddlPreparedBy.SelectedItem.Value;
            objMaster.ApprovedBy = ddlapprovedby.SelectedItem.Value;
            objMaster.Status = "New";
            objMaster.Remarks = HttpUtility.HtmlEncode(txttermscondtionscontent.Text);




            if (objMaster.RequestPackingList_Save() == "Data Saved Successfully")
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
                    objMaster.RequestPackingListDetails_Save();
                    
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
            Response.Redirect("~/Modules/Stock/RequestPackingList.aspx");
        }
    }

    private void po_Update()
    {
        try
        {
            SCM.RequestPackingList objMaster = new SCM.RequestPackingList();
            objMaster.RPLId = Request.QueryString["Cid"].ToString();
            objMaster.RPLNo = txtplno.Text;
            objMaster.RPLDate = General.toMMDDYYYY(txtpldate.Text);
            objMaster.Soid = ddlso.SelectedItem.Value;
            objMaster.CustId = ddlProject.SelectedItem.Value;
            objMaster.CustAddress = txtcustaddress.Text;
            objMaster.DeliveryAddress = txtdeliveryaddress.Text;
            objMaster.TotalPackets = txttotalpackets.Text;
            objMaster.TotalWeight = txttotalWeight.Text;
            objMaster.Methodofdispach = txtmethodofdispacth.Text;
            objMaster.preapredby = ddlPreparedBy.SelectedItem.Value;
            objMaster.ApprovedBy = ddlapprovedby.SelectedItem.Value;
            objMaster.Remarks = HttpUtility.HtmlEncode(txttermscondtionscontent.Text);

            if (objMaster.RequestPackingList_Update() == "Data Updated Successfully")
            {
                objMaster.RequestPackingListDetails_Delete(objMaster.RPLId);
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
                    objMaster.RequestPackingListDetails_Save();
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
            Response.Redirect("~/Modules/Stock/RequestPackingList.aspx");
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
        if (obj.SalesOrder_Select(ddlso.SelectedItem.Value) > 0)
        {
            ddlProject.SelectedValue = obj.SiteId;
            ddlProject_SelectedIndexChanged(sender, e);
        }
    }
    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.CustomerMaster obj = new SM.CustomerMaster();
        if (obj.CustomerUnitMaster_Select(ddlProject.SelectedItem.Value) > 0)
        {
            txtcustaddress.Text = obj.UnitAddress;
            txtdeliveryaddress.Text = obj.UnitAddress;
        }
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            SCM.RequestPackingList objSMSOApprove = new SCM.RequestPackingList();
            objSMSOApprove.RPLId = Request.QueryString["Cid"].ToString();
            objSMSOApprove.ApprovedBy = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSMSOApprove.RequestPackingApprove_Update();

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Response.Redirect("~/Modules/Stock/RequestPackingList.aspx");
        }
    }
}