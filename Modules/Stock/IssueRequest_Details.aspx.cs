
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

public partial class Modules_Stock_IssueRequest_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            Masters.MaterialMaster.ItemStock_Select(ddlitemCode);

            txtMaterialreqestNo.Text = SCM.IssueRequest.IssueRequest_AutoGenCode();
            txtMrdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtrequireddate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            Masters.ColorMaster.Color_Select(ddlColor);
            SM.SalesOrder.SalesOrder_Select(ddlSono);
            SM.CustomerMaster.CustomerUnit_Select(ddlCustomer);

            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlrequestedby);

            ddlrequestedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

           // gvItems.DataBind();
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
        SCM.IssueRequest objmaster = new SCM.IssueRequest();
        if (objmaster.IssueRequest_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtMaterialreqestNo.Text = objmaster.ReqIssueNo;
            txtMrdate.Text = objmaster.RequestDate;
            txtrequireddate.Text = objmaster.RequriedDate;
            ddlrequesttype.SelectedValue = objmaster.RequestPurpose;
            ddlrequestedby.SelectedValue = objmaster.RequestedBy;
            ddlapprovedby.SelectedValue = objmaster.ApprovedBy;
            ddlCustomer.SelectedValue = objmaster.Custid;


            if(objmaster.ApprovedBy != "0")
            {
                btnApprove.Visible = false;
                btnSave.Visible = false;

                string palash = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
                string chenna = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
               
                if(palash == "7" || chenna == "42" )
                {
                    btnSave.Visible = true;
                }



            }





            objmaster.IssueRequestDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);

            if (objmaster.SoId != "0")
            {
                ddlSono.SelectedValue = objmaster.SoId;
                ddlSono_SelectedIndexChanged(new object(), new System.EventArgs());
            }

        }
    }

    protected void btnadditem_Click(object sender, EventArgs e)
    {



        //if( int.Parse(txtQty.Text) > int.Parse(txtpu.Text))
        //{
        //    MessageBox.Show(this,"Qty Should Not Exceed the Available Qty")
        //}
        //else
        //{ 


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

            #region CODE


            if (value <= pu)
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
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoMatId");
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
                                dr["Series"] = txtseries.Text;
                                dr["Length"] = ddllength.SelectedItem.Value;
                                dr["Uom"] = txtUom.Text;
                                dr["Color"] = ddlColor.SelectedItem.Text;
                                TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                                dr["Qty"] = txtQty.Text;
                                dr["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
                                dr["ColorId"] = ddlColor.SelectedItem.Value;
                                dr["SoMatId"] = ddlSono.SelectedItem.Value;
                                TextBox Remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                                dr["Remarks"] = txtremakrs.Text;



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
                                dr["Qty"] = gvrow.Cells[6].Text;


                                dr["ItemCodeId"] = gvrow.Cells[7].Text;
                                dr["ColorId"] = gvrow.Cells[8].Text;

                                dr["SoMatId"] = gvrow.Cells[9].Text;
                                dr["Remarks"] = gvrow.Cells[10].Text;
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
                            TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                            dr["Qty"] = Qty.Text;
                            dr["ItemCodeId"] = gvrow.Cells[7].Text;
                            dr["ColorId"] = gvrow.Cells[8].Text;
                            dr["SoMatId"] = gvrow.Cells[9].Text;

                            TextBox Remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                            dr["Remarks"] = Remarks.Text;


                            SalesOrderItems.Rows.Add(dr);
                        }
                    }
                }



                if (gvItems.Rows.Count > 0)
                {
                    if (gvItems.SelectedIndex == -1)
                    {
                        foreach (GridViewRow gvrow in gvItems.Rows)
                        {
                            if (gvrow.Cells[7].Text == ddlitemCode.SelectedItem.Value && gvrow.Cells[8].Text == ddlColor.SelectedItem.Value && gvrow.Cells[3].Text == ddllength.SelectedItem.Value)
                            {
                                gvItems.DataSource = SalesOrderItems;
                                gvItems.DataBind();
                                MessageBox.Show(this, "This Itemcode with same Color have selected is already exists in list");
                                return;
                            }
                        }
                    }
                }




                if (gvItems.SelectedIndex == -1)
                {
                    DataRow drnew = SalesOrderItems.NewRow();
                    drnew["ItemCode"] = ddlitemCode.SelectedItem.Text;
                    drnew["Series"] = txtseries.Text;
                    drnew["Length"] = ddllength.SelectedItem.Value;
                    drnew["Uom"] = txtUom.Text;
                    drnew["Color"] = ddlColor.SelectedItem.Text;
                    //TextBox Qty = (TextBox)gvItems.FindControl("txtitemqty");
                    //Qty.Text = txtQty.Text;
                    drnew["Qty"] = txtQty.Text;
                    drnew["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
                    drnew["ColorId"] = ddlColor.SelectedItem.Value;
                    drnew["SoMatId"] = ddlSono.SelectedItem.Value;
                    // TextBox Remarks = (TextBox)gvItems.FindControl("txtitemRemarks");
                    // Remarks.Text = txtremakrs.Text;

                    drnew["Remarks"] = txtremakrs.Text;




                    // drnew["Remarks"] = txtremakrs.Text;
                    SalesOrderItems.Rows.Add(drnew);
                }
                gvItems.DataSource = SalesOrderItems;
                gvItems.DataBind();
                gvItems.SelectedIndex = -1;
                clearitems();
            }
            else
            {
                MessageBox.Show(this, "Issuing Qty More than Stock Qty");
            }


            #endregion
        }
    }

    private void clearitems()
    {
        Masters.ColorMaster.Color_Select(ddlColor);
        Masters.MaterialMaster.ItemStock_Select(ddlitemCode);
        ddlitemCode.SelectedValue = "0";
        ddlColor.SelectedValue = "0";
        txtseries.Text = "";
        txtUom.Text = "";
        ddllength.Items.Clear(); 
        txtpu.Text = "";
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
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Warehouse");
        //SalesOrderItems.Columns.Add(col);
        // SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoMatId");
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
                    //dr["ItemCode"] = gvrow.Cells[1].Text;
                    //dr["Series"] = gvrow.Cells[2].Text;
                    //dr["Length"] = gvrow.Cells[3].Text;
                    //dr["Uom"] = gvrow.Cells[4].Text;
                    //dr["Color"] = gvrow.Cells[5].Text;


                    //TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                    //dr["Qty"] = Qty.Text;



                    //dr["ItemCodeId"] = gvrow.Cells[7].Text;
                    //dr["ColorId"] = gvrow.Cells[8].Text;

                    //dr["SoMatId"] = gvrow.Cells[9].Text;
                    //TextBox Remarks = (TextBox)gvItems.FindControl("txtitemRemarks");
                    //dr["Remarks"] = Remarks.Text;
                    dr["ItemCode"] = gvrow.Cells[1].Text;
                    dr["Series"] = gvrow.Cells[2].Text;
                    dr["Length"] = gvrow.Cells[3].Text;
                    dr["Uom"] = gvrow.Cells[4].Text;
                    dr["Color"] = gvrow.Cells[5].Text;
                    //dr["Qty"] = gvrow.Cells[6].Text;
                    TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                    dr["Qty"] = Qty.Text;


                    dr["ItemCodeId"] = gvrow.Cells[7].Text;
                    dr["ColorId"] = gvrow.Cells[8].Text;

                    dr["SoMatId"] = gvrow.Cells[9].Text;
                    //dr["Remarks"] = gvrow.Cells[10].Text;
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
        //Masters.MaterialMaster obj = new Masters.MaterialMaster();
        //if (obj.MaterialPO_Select(ddlitemCode.SelectedItem.Value) > 0)
        //{
        //    txtseries.Text = obj.Description;
        //    txtUom.Text = obj.UomName;
        //    //txtitemtLength.Text = obj.BarLength;
        //    //txtpu.Text = obj.Boxsize;


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
            SCM.IssueRequest objMaster = new SCM.IssueRequest();

            objMaster.ReqIssueNo = txtMaterialreqestNo.Text;
            objMaster.RequestDate = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.RequestPurpose = ddlrequesttype.SelectedItem.Value;
            objMaster.ApprovedBy = ddlapprovedby.SelectedItem.Value;
            objMaster.RequestedBy = ddlrequestedby.SelectedItem.Value;
            objMaster.Custid = ddlCustomer.SelectedItem.Value;
            objMaster.SoId = ddlSono.SelectedItem.Value;
            objMaster.RequriedDate = General.toMMDDYYYY(txtrequireddate.Text);
            objMaster.Status = "Not Issued";
            if (objMaster.IssueRequest_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[7].Text;
                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.Quantity = qty.Text;
                   
                    objMaster.ColorId = gvRowOtherCorp.Cells[8].Text;
                   
                    objMaster.sodetid = gvRowOtherCorp.Cells[9].Text;


                    objMaster.Length = gvRowOtherCorp.Cells[3].Text;

                    TextBox Remarks = (TextBox)gvRowOtherCorp.FindControl("txtitemRemarks");
                    objMaster.remarks = Remarks.Text;



                    objMaster.IssueRequestDetails_Save();
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
            Response.Redirect("~/Modules/Stock/IssueRequest.aspx");
        }
    }

    private void po_Update()
    {
        try
        {
            SCM.IssueRequest objMaster = new SCM.IssueRequest();
            objMaster.ReqIssueId = Request.QueryString["Cid"].ToString();
            objMaster.ReqIssueNo = txtMaterialreqestNo.Text;
            objMaster.RequestDate = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.RequestPurpose = ddlrequesttype.SelectedItem.Value;
            objMaster.ApprovedBy = ddlapprovedby.SelectedItem.Value;
            objMaster.RequestedBy = ddlrequestedby.SelectedItem.Value;
            objMaster.Custid = ddlCustomer.SelectedItem.Value;
            objMaster.SoId = ddlSono.SelectedItem.Value;
            objMaster.RequriedDate = General.toMMDDYYYY(txtrequireddate.Text);
            if (objMaster.IssueRequest_Update() == "Data Updated Successfully")
            {
                objMaster.IssueRequestDetails_Delete(objMaster.ReqIssueId);
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[7].Text;
                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.Quantity = qty.Text;

                    objMaster.ColorId = gvRowOtherCorp.Cells[8].Text;

                    objMaster.sodetid = gvRowOtherCorp.Cells[9].Text;


                    objMaster.Length = gvRowOtherCorp.Cells[3].Text;

                    TextBox Remarks = (TextBox)gvRowOtherCorp.FindControl("txtitemRemarks");
                    objMaster.remarks = Remarks.Text;



                    objMaster.IssueRequestDetails_Save();
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
            Response.Redirect("~/Modules/Stock/IssueRequest.aspx");
        }
    }

    protected void gvmatana_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[11].Visible = false;
            //e.Row.Cells[10].Visible = false;
        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string Itemcode = e.Row.Cells[11].Text.ToString();
        //    string ColorId = e.Row.Cells[12].Text.ToString();
        //    string matid = e.Row.Cells[14].Text.ToString();
        //    if (Itemcode != "")
        //    {
        //        SCM.Stock obj1 = new SCM.Stock();

        //        //if (obj1.StockOnStorageLocationCS1(Itemcode, ColorId) > 0)
        //        //{
        //        //    e.Row.Cells[10].Text = obj1.Quantity;
        //        //}
        //        //else
        //        //{
        //        //    e.Row.Cells[10].Text = "0";
        //        //}


        //        //if(obj1.BlockStock(Itemcode, ColorId) > 0)
        //        //{
        //        //    e.Row.Cells[15].Text = obj1.BlockQty;
        //        //}

        //        if (obj1.IssuedStock(Itemcode, ColorId,matid) > 0)
        //        {
        //            e.Row.Cells[16].Text = obj1.Issuedqty;
        //        }






           // }

        //    //DropDownList ddlwarehouse = (e.Row.FindControl("ddlSowaerhose") as DropDownList);
        //    //Masters.StorageLocation.StorageLocation_Select(ddlwarehouse);
       // }
    }

    protected void ddlSono_SelectedIndexChanged(object sender, EventArgs e)
    {

      //  General.GridBindwithCommand(gvmatana, "SELECT c.SO_ID as SO_ID ,c.SO_MATANA_ID as SO_MATANA_ID, c.ITEMCODE_ID as ITEMCODE_ID,c.COLOR_ID as COLOR_ID, c.REQUIRED_QTY as REQUIRED_QTY, cat.ITEM_CATEGORY_NAME as ITEM_CATEGORY_NAME,c.ITEMCODE as ITEMCODE, C.DESCRIPTION as Description,C.BARLENGTH as BARLENGTH,C.UNIT as UNIT,C.COLOR as COLOR, C.PU as PU,C.QUANTITY as QUANTITY, TotalStock = (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID and O.Length = C.BARLENGTH),PrevBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID and B.So_Id = C.SO_ID and B.Length = C.BARLENGTH),iSSUED = (SELECT sum(Issued_Qty) as Issuedqty FROM Material_Issue_Details D where  D.Color_Id = C.COLOR_ID and D.Item_Code = C.ITEMCODE_ID and D.Length = C.BARLENGTH and D.So_Id = C.SO_ID) FROM SalesOrder_MaterialAnalysis C ,Material_Master It,Category_Master cat,Uom_Master Uom,Color_Master color where C.ITEMCODE_ID = It.Material_Id and It.Category_Id = cat.ITEM_CATEGORY_ID and It.UOM_Id = Uom.UOM_ID and C.COLOR_ID = color.Color_Id and c.SO_ID = '" + ddlSono.SelectedItem.Value + "'");

        //SM.SalesOrder obj = new SM.SalesOrder();
        //if(obj.SalesOrder_Select(ddlSono.SelectedItem.Value) > 0)
        //{
        //    ddlCustomer.SelectedValue = obj.SiteId;
        //}

        General ob = new General();
        string Val = ob.GetColumnVal("SELECT CustSiteId FROM [Sales_Order] WHERE Sales_Order.SalesOrder_Id='" + ddlSono.SelectedItem.Value + "' ", "CustSiteId");
        if(Val != "")
        {
            ddlCustomer.SelectedValue = Val;
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
        dt.Columns.Add("Qty");
        dt.Columns.Add("RequiredQty");
        dt.Columns.Add("Requireddate");
        dt.Columns.Add("Requestfor");
        dt.Columns.Add("ItemCodeId");
        dt.Columns.Add("ColorId");
        dt.Columns.Add("SoMatId");
        dt.Columns.Add("Remarks");
        //dt.Columns.Add("WarehouseId");
        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
       // DataRow[] dr = dt.Select("SoMatId = '" + gvRow.Cells[14].Text + "'");

        DataRow[] dr = dt.Select("ItemCodeId = '" + gvRow.Cells[11].Text + "' and ColorId = '" + gvRow.Cells[12].Text + "'  ");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["ItemCode"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["Series"] = gvRow.Cells[3].Text;
            dt.Rows[dt.Rows.Count - 1]["Length"] = gvRow.Cells[4].Text;
            dt.Rows[dt.Rows.Count - 1]["Uom"] = gvRow.Cells[5].Text;


            if (gvRow.Cells[6].Text == "&nbsp;" || gvRow.Cells[6].Text == " ")
            {
                dt.Rows[dt.Rows.Count - 1]["Color"] = "NA";
            }
            else
            {
                dt.Rows[dt.Rows.Count - 1]["Color"] = gvRow.Cells[6].Text;
            }


            dt.Rows[dt.Rows.Count - 1]["Qty"] = gvRow.Cells[9].Text;

         
        
            dt.Rows[dt.Rows.Count - 1]["ItemCodeId"] = gvRow.Cells[11].Text;
            dt.Rows[dt.Rows.Count - 1]["ColorId"] = gvRow.Cells[12].Text;
            dt.Rows[dt.Rows.Count - 1]["SoMatId"] = gvRow.Cells[14].Text;
            dt.Rows[dt.Rows.Count - 1]["Remarks"] = "";
          
            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("ItemCodeId = '" + gvRow.Cells[11].Text + "' and ColorId = '" + gvRow.Cells[12].Text + "'  ");
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
                  //  DataRow[] dr = dt.Select("SoMatId = '" + gvmatana.Rows[i].Cells[14].Text + "'");
                    DataRow[] dr = dt.Select("ItemCodeId = '" + gvmatana.Rows[i].Cells[11].Text + "' and ColorId = '" + gvmatana.Rows[i].Cells[12].Text + "'  ");
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
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            SCM.IssueRequest objSMSOApprove = new SCM.IssueRequest();
            objSMSOApprove.ReqIssueId = Request.QueryString["Cid"].ToString();
            objSMSOApprove.ApprovedBy = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSMSOApprove.IssueRequestApprove_Update();

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Response.Redirect("~/Modules/Stock/IssueRequest.aspx");
        }
    }
    protected void ddllength_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.Stock Stock = new SCM.Stock();

        if (Stock.MCLStockAvailable(ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value, ddllength.SelectedItem.Value) > 0)
        {
            txtpu.Text = Stock.TStock;
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