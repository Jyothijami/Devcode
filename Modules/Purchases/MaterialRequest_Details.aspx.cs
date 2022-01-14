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

      //  System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            Masters.MaterialMaster.MaterialMaster_Select(ddlitemCode);
          
            txtMaterialreqestNo.Text = SCM.MaterialRequest.MaterialRequest_AutoGenCode();
            txtMrdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtrequireddate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            Masters.ColorMaster.Color_Select(ddlColor);
            SM.SalesOrder.SalesOrder_Select(ddlSono);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            ddlpreparedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            gvItems.DataBind();

            txtrequestfor.Text = "Self";

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
            txttermscondtionscontent.Text = HttpUtility.HtmlDecode(objmaster.Termsconditonsid);
            ddlstatus.SelectedValue = objmaster.Status;
            ddlpreparedby.SelectedValue = objmaster.Preparedby;
          


            objmaster.MaterialRequestDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);

            if (objmaster.SoId != "0")
            {
                ddlSono.SelectedValue = objmaster.SoId;
                ddlSono_SelectedIndexChanged(new object(), new System.EventArgs());
            }
        
        }
    }

    protected void btnadditem_Click(object sender, EventArgs e)
    {
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
        col = new DataColumn("Requireddate");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Requestfor");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("SoId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoMatId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("RequiredQty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("PU");
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
                        dr["Length"] = txtitemtLength.Text;
                        dr["Uom"] = txtUom.Text;
                        dr["Color"] = ddlColor.SelectedItem.Text;
                        TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                        dr["Qty"] = txtQty.Text;
                        TextBox Requireddate = (TextBox)gvrow.FindControl("txtitemRequireddate");
                        dr["Requireddate"] = txtrequireddate.Text;
                        dr["Requestfor"] = txtrequestfor.Text;
                        dr["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
                        dr["ColorId"] = ddlColor.SelectedItem.Value;
                        dr["SoId"] = "0";
                        dr["SoMatId"] = "0";
                        dr["RequiredQty"] = txtQty.Text;
                        dr["PU"] = txtpu.Text;

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

                        dr["Requireddate"] = gvrow.Cells[7].Text;
                        dr["Requestfor"] = gvrow.Cells[8].Text;
                        dr["ItemCodeId"] = gvrow.Cells[9].Text;
                        dr["ColorId"] = gvrow.Cells[10].Text;
                        dr["SoId"] = gvrow.Cells[11].Text;
                        dr["SoMatId"] = gvrow.Cells[12].Text;
                        dr["RequiredQty"] = gvrow.Cells[13].Text;
                        dr["PU"] = gvrow.Cells[14].Text;
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
                    TextBox Requireddate = (TextBox)gvrow.FindControl("txtitemRequireddate");
                    dr["Requireddate"] = Requireddate.Text;

                    dr["Requestfor"] = gvrow.Cells[8].Text;
                    dr["ItemCodeId"] = gvrow.Cells[9].Text;
                    dr["ColorId"] = gvrow.Cells[10].Text;
                    dr["SoId"] = gvrow.Cells[11].Text;
                    dr["SoMatId"] = gvrow.Cells[12].Text;
                    dr["RequiredQty"] = gvrow.Cells[13].Text;
                    dr["PU"] = gvrow.Cells[14].Text;

                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }

        if (gvItems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["ItemCode"] = ddlitemCode.SelectedItem.Text;
            drnew["ItemCode"] = ddlitemCode.SelectedItem.Text;
            drnew["Series"] = txtseries.Text;
            drnew["Length"] = txtitemtLength.Text;
            drnew["Uom"] = txtUom.Text;
            drnew["Color"] = ddlColor.SelectedItem.Text;
            TextBox Qty = (TextBox)gvItems.FindControl("txtitemqty");
            drnew["Qty"] = txtQty.Text;
            TextBox Requireddate = (TextBox)gvItems.FindControl("txtitemRequireddate");
            drnew["Requireddate"] = txtrequireddate.Text;
            drnew["Requestfor"] = txtrequestfor.Text;
            drnew["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
            drnew["ColorId"] = ddlColor.SelectedItem.Value;
            drnew["SoId"] = "0";
            drnew["SoMatId"] = "0";
            drnew["RequiredQty"] = txtQty.Text;
            drnew["PU"] = txtpu.Text;
            SalesOrderItems.Rows.Add(drnew);
        }
        gvItems.DataSource = SalesOrderItems;
        gvItems.DataBind();
        gvItems.SelectedIndex = -1;

        ClearGrid();


    }

    private void ClearGrid()
    {
        ddlitemCode.SelectedIndex = -1;
        ddlColor.SelectedIndex = -1;
        txtseries.Text = "";
        txtUom.Text = "";
        txtitemtLength.Text = "";
        txtpu.Text = "";
        txtQty.Text = "";
        
    }

    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[7].Visible = false;
            //e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
        }

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    //DropDownList ddlitemcodes = (e.Row.FindControl("ddlitemcodes") as DropDownList);
        //    //DropDownList ddlColor = (e.Row.FindControl("ddlitemColors") as DropDownList);
        //    //DropDownList ddlwarehouse = (e.Row.FindControl("ddlitemWarehouse") as DropDownList);

        //    ////Masters.MaterialMaster.MaterialMaster_Select(ddlitemcodes);
        //    ////Masters.ColorMaster.Color_Select(ddlColor);
        //    //Masters.StorageLocation.StorageLocation_Select(ddlwarehouse);
        //}
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
        col = new DataColumn("Requireddate");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Requestfor");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("SoId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoMatId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("RequiredQty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("PU");
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


                    TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                    dr["Qty"] = Qty.Text;
                    TextBox Requireddate = (TextBox)gvrow.FindControl("txtitemRequireddate");
                    dr["Requireddate"] = Requireddate.Text;

                    dr["Requestfor"] = gvrow.Cells[8].Text;
                    dr["ItemCodeId"] = gvrow.Cells[9].Text;
                    dr["ColorId"] = gvrow.Cells[10].Text;
                    dr["SoId"] = gvrow.Cells[11].Text;
                    dr["SoMatId"] = gvrow.Cells[12].Text;
                    dr["RequiredQty"] = gvrow.Cells[13].Text;
                    dr["PU"] = gvrow.Cells[14].Text;

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
            SCM.MaterialRequest objMaster = new SCM.MaterialRequest();

            objMaster.MRno = txtMaterialreqestNo.Text;
            objMaster.RequiredDate = General.toMMDDYYYY(txtrequireddate.Text);
            objMaster.ReqType = ddlrequesttype.SelectedItem.Value;
            objMaster.Requestedfor = txtrequestfor.Text;
            objMaster.Mrdate = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.Termsconditonsid = HttpUtility.HtmlEncode(txttermscondtionscontent.Text);
            objMaster.Preparedby = ddlpreparedby.SelectedItem.Value;
            objMaster.Status = ddlstatus.SelectedItem.Value;
            objMaster.Somainid = ddlSono.SelectedItem.Value;

            if (objMaster.MaterialRequest_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[9].Text;
                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.Quantity = qty.Text;
                    TextBox IRDate = (TextBox)gvRowOtherCorp.FindControl("txtitemrequireddate");
                    objMaster.ItemReqDate = General.toMMDDYYYY(IRDate.Text);
                    objMaster.ColorId = gvRowOtherCorp.Cells[10].Text;
                    objMaster.WarehouseId = "0";
                    objMaster.Itemrequestedfor = gvRowOtherCorp.Cells[8].Text;
                    objMaster.SoId = gvRowOtherCorp.Cells[11].Text;

                    objMaster.Somatid = gvRowOtherCorp.Cells[12].Text;
                    objMaster.ReqQty = gvRowOtherCorp.Cells[13].Text;
                    objMaster.Length = gvRowOtherCorp.Cells[3].Text;


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
            objMaster.Termsconditonsid = HttpUtility.HtmlEncode(txttermscondtionscontent.Text);
            objMaster.Preparedby = ddlpreparedby.SelectedItem.Value;
            objMaster.Status = ddlstatus.SelectedItem.Value;
            objMaster.Somainid = ddlSono.SelectedItem.Value;
            if (objMaster.MaterialRequest_Update() == "Data Updated Successfully")
            {
                objMaster.MaterialRequestDetails_Delete(objMaster.MreqId);
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[9].Text;
                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.Quantity = qty.Text;
                    TextBox IRDate = (TextBox)gvRowOtherCorp.FindControl("txtitemrequireddate");
                    objMaster.ItemReqDate = General.toMMDDYYYY(IRDate.Text);
                    objMaster.ColorId = gvRowOtherCorp.Cells[10].Text;
                    objMaster.WarehouseId = "0";
                    objMaster.Itemrequestedfor = gvRowOtherCorp.Cells[8].Text;
                    objMaster.SoId = gvRowOtherCorp.Cells[11].Text;

                    objMaster.Somatid = gvRowOtherCorp.Cells[12].Text;
                    objMaster.ReqQty = gvRowOtherCorp.Cells[13].Text;
                    objMaster.Length = gvRowOtherCorp.Cells[3].Text;
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
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[10].Visible = false;
        }


      
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string Itemcode = e.Row.Cells[11].Text.ToString();
        //    string ColorId = e.Row.Cells[12].Text.ToString();

        //    if (Itemcode != "")
        //    {
        //        SCM.Stock obj1 = new SCM.Stock();

        //        if (obj1.StockOnStorageLocationCS1(Itemcode, ColorId) > 0)
        //        {
        //            e.Row.Cells[10].Text = obj1.Quantity;
        //        }
        //        else
        //        {
        //            e.Row.Cells[10].Text = "0";
        //            e.Row.Cells[10].BackColor = System.Drawing.Color.Red;
        //            e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
        //        }
        //    }

        //    //DropDownList ddlwarehouse = (e.Row.FindControl("ddlSowaerhose") as DropDownList);
        //    //Masters.StorageLocation.StorageLocation_Select(ddlwarehouse);
        //}
    }

    protected void ddlSono_SelectedIndexChanged(object sender, EventArgs e)
    {

        General.GridBindwithCommand(gvmatana, "select *,PrevBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = c.ITEMCODE_ID and B.Color_Id = c.COLOR_ID and B.So_MatId = c.SO_MATANA_ID) from SalesOrder_MaterialAnalysis c,Material_Master,Category_Master,ItemSeries where  c.ITEMCODE_ID = Material_Master.Material_Id and Material_Master.Category_Id = Category_Master.ITEM_CATEGORY_ID and ItemSeries.Item_Series_Id = Material_Master.Series  and SO_ID  = '" + ddlSono.SelectedItem.Value + "'");


    //    gvmatana.HeaderRow.TableSection = TableRowSection.TableHeader;

        txtrequestfor.Text = "";
        txtrequestfor.Text = ddlSono.SelectedItem.Text;
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
        dt.Columns.Add("SoId");
        dt.Columns.Add("SoMatId");
        dt.Columns.Add("PU");
        //dt.Columns.Add("WarehouseId");
        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("SoMatId = '" + gvRow.Cells[14].Text + "'");
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

            
            dt.Rows[dt.Rows.Count - 1]["Qty"] = gvRow.Cells[7].Text;

           //   DropDownList ddlwarehouse = (gvRow.FindControl("ddlSowaerhose") as DropDownList);

            //if(ddlwarehouse.SelectedValue == "0")
            //{
            //    dt.Rows[dt.Rows.Count - 1]["Warehouse"] = "Plant1";
            //    dt.Rows[dt.Rows.Count - 1]["WarehouseId"] = "1";
            //}
            //else
            //{
            //    dt.Rows[dt.Rows.Count - 1]["Warehouse"] = ddlwarehouse.SelectedItem.Text;
            //    dt.Rows[dt.Rows.Count - 1]["WarehouseId"] = ddlwarehouse.SelectedItem.Value;
            //}
            dt.Rows[dt.Rows.Count - 1]["RequiredQty"] = gvRow.Cells[9].Text;
            
            dt.Rows[dt.Rows.Count - 1]["Requestfor"] = txtrequestfor.Text;
            dt.Rows[dt.Rows.Count - 1]["RequiredDate"] = txtrequireddate.Text;
            dt.Rows[dt.Rows.Count - 1]["ItemCodeId"] = gvRow.Cells[11].Text;
            dt.Rows[dt.Rows.Count - 1]["ColorId"] = gvRow.Cells[12].Text;
            dt.Rows[dt.Rows.Count - 1]["SoMatId"] = gvRow.Cells[14].Text;
            dt.Rows[dt.Rows.Count - 1]["SoId"] = gvRow.Cells[13].Text;
            dt.Rows[dt.Rows.Count - 1]["PU"] = gvRow.Cells[8].Text;
            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("SoMatId = '" + gvRow.Cells[14].Text + "'");
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
                    DataRow[] dr = dt.Select("SoMatId = '" + gvmatana.Rows[i].Cells[14].Text + "'");
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
    
}