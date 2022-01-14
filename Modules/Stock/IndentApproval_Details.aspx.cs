
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

public partial class Modules_Stock_IndentApproval_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            txtMaterialreqestNo.Text = SCM.IndentApproval.IndentApproval_AutoGenCode();
            txtMrdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            SCM.MaterialRequest.MaterialRequestStatus_Select(ddlIndent);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            ddlpreparedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            //ddlapprovedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            btnApprove.Visible = false;

            gvIndent.DataBind();
            if (Qid != "Add")
            {
                SCM.MaterialRequest.MaterialRequest_Select(ddlIndent);
                CategoryFill();
                btnApprove.Visible = true;
            }
        }
    }

    private void CategoryFill()
    {
        SCM.IndentApproval objmaster = new SCM.IndentApproval();
        if (objmaster.IndentApproval_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtMaterialreqestNo.Text = objmaster.IndappNo;
            txtMrdate.Text = objmaster.IndappDate;
            ddlpreparedby.SelectedValue = objmaster.PreparedBy;
            ddlapprovedby.SelectedValue = objmaster.ApprovedBy;
            txttermscondtionscontent.Text = HttpUtility.HtmlDecode(objmaster.TermsConditons);

            if (objmaster.IndentId != "0")
            {
                ddlIndent.SelectedValue = objmaster.IndentId;
                ddlIndent_SelectedIndexChanged(new object(), new System.EventArgs());
            }


            General.GridBindwithCommand(gvIndentedappr, "Select * from IndentApproval_Details,Color_Master,Material_Master where IndentApproval_Details.Item_Code = Material_Master.Material_Id and IndentApproval_Details.Color_Id = Color_Master.Color_Id and IndentApproval_Details.IndentApproval_Id = '" + Request.QueryString["Cid"].ToString() + "' ");

          //  objmaster.IndentApprovalDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);

            //if(objmaster.ApprovedBy == "0")
            //{
            //    btnSave.Text = "Update";
            //    btnSave.Visible = true;
            //    btnApprove.Visible = true;
            //}
            //else
            //{
            //    btnApprove.Visible = false;
            //    btnSave.Visible = false;
            //}



        }
    }
    protected void gvIndent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[13].Visible = false;
        }
    }
    protected void ddlIndent_SelectedIndexChanged(object sender, EventArgs e)
    {
        //General.GridBindwithCommand(gvIndent, "select * from MaterialRequest_Details,Material_Master,Category_Master,ItemSeries,Uom_Master, Color_Master where MaterialRequest_Details.Color_Id = Color_Master.Color_Id and Material_Master.UOM_Id = Uom_Master.UOM_ID and MaterialRequest_Details.Item_Code = Material_Master.Material_Id and Material_Master.Category_Id = Category_Master.ITEM_CATEGORY_ID and ItemSeries.Item_Series_Id = Material_Master.Series  and Mreq_Id  = '" + ddlIndent.SelectedItem.Value + "'");

        SCM.MaterialRequest obj = new SCM.MaterialRequest();
        obj.MaterialRequestDetails_Select(ddlIndent.SelectedItem.Value, gvIndent);
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
            SCM.IndentApproval objMaster = new SCM.IndentApproval();
            objMaster.IndappNo = txtMaterialreqestNo.Text;
            objMaster.IndappDate = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.IndentId = ddlIndent.SelectedItem.Value;
            objMaster.TermsConditons = HttpUtility.HtmlEncode(txttermscondtionscontent.Text);
            objMaster.PreparedBy = ddlpreparedby.SelectedItem.Value;
            objMaster.ApprovedBy = ddlapprovedby.SelectedItem.Value;

            if (objMaster.IndentApproval_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[7].Text;
                    objMaster.Quantity = gvRowOtherCorp.Cells[14].Text;
                    objMaster.ItemReqDate = General.toMMDDYYYY(gvRowOtherCorp.Cells[5].Text);
                    objMaster.WarehouseId = "0";
                    objMaster.ColorId = gvRowOtherCorp.Cells[8].Text;
                    objMaster.Itemrequestedfor = gvRowOtherCorp.Cells[6].Text;
                    objMaster.SoId = gvRowOtherCorp.Cells[9].Text;
                    objMaster.Somatid = gvRowOtherCorp.Cells[10].Text;
                    objMaster.ReqQty = gvRowOtherCorp.Cells[11].Text;
                    TextBox qtytoorder = (TextBox)gvRowOtherCorp.FindControl("txtqtyorder");
                    objMaster.QtytoOrder = qtytoorder.Text;
                    TextBox remarks = (TextBox)gvRowOtherCorp.FindControl("txtitemremarks");
                    objMaster.Remarks = remarks.Text;
                    TextBox Block = (TextBox)gvRowOtherCorp.FindControl("txtBlockQty");
                    objMaster.BlockStock = Block.Text;
                    objMaster.IndId = ddlIndent.SelectedItem.Value;


                    objMaster.Length = gvRowOtherCorp.Cells[3].Text;

                    objMaster.IndentApprovalDetails_Save();

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
            Response.Redirect("~/Modules/Stock/IndentApproval.aspx");
        }
    }

    private void po_Update()
    {
        try
        {
            SCM.IndentApproval objMaster = new SCM.IndentApproval();
            objMaster.IndappId = Request.QueryString["Cid"].ToString();
            objMaster.IndappNo = txtMaterialreqestNo.Text;
            objMaster.IndappDate = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.IndentId = ddlIndent.SelectedItem.Value;
            objMaster.TermsConditons = HttpUtility.HtmlEncode(txttermscondtionscontent.Text);
            objMaster.PreparedBy = ddlpreparedby.SelectedItem.Value;
            objMaster.ApprovedBy = ddlapprovedby.SelectedItem.Value;
            if (objMaster.IndentApproval_Update() == "Data Updated Successfully")
            {
               
                objMaster.IndentApprovalDetails_Delete(objMaster.IndappId);
                //objMaster.IndentApprovalBlock_Delete(objMaster.IndappId);
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[7].Text;
                    objMaster.Quantity = gvRowOtherCorp.Cells[14].Text;
                    objMaster.ItemReqDate = General.toMMDDYYYY(gvRowOtherCorp.Cells[5].Text);
                    objMaster.WarehouseId = "0";
                    objMaster.ColorId = gvRowOtherCorp.Cells[8].Text;
                    objMaster.Itemrequestedfor = gvRowOtherCorp.Cells[6].Text;
                    objMaster.SoId = gvRowOtherCorp.Cells[9].Text;
                    objMaster.Somatid = gvRowOtherCorp.Cells[10].Text;
                    objMaster.ReqQty = gvRowOtherCorp.Cells[11].Text;
                    TextBox qtytoorder = (TextBox)gvRowOtherCorp.FindControl("txtqtyorder");
                    objMaster.QtytoOrder = qtytoorder.Text;
                    TextBox remarks = (TextBox)gvRowOtherCorp.FindControl("txtitemremarks");
                    objMaster.Remarks = remarks.Text;
                    TextBox Block = (TextBox)gvRowOtherCorp.FindControl("txtBlockQty");
                    objMaster.BlockStock = Block.Text;
                    objMaster.IndId = ddlIndent.SelectedItem.Value;


                    objMaster.Length = gvRowOtherCorp.Cells[3].Text;

                    objMaster.IndentApprovalDetails_Save();
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
            Response.Redirect("~/Modules/Stock/IndentApproval.aspx");
        }
    }







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
        dt.Columns.Add("RequiredDate");
        dt.Columns.Add("Requestfor");
        dt.Columns.Add("ItemCodeId");
        dt.Columns.Add("ColorId");
        dt.Columns.Add("SoId");
        dt.Columns.Add("SoMatId");
        dt.Columns.Add("QtyinStock");
        dt.Columns.Add("qtyorder");
        dt.Columns.Add("Remarks");
        dt.Columns.Add("PU");
        dt.Columns.Add("BlockQty");

        dt.Columns.Add("IndId");

        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("IndId = '" + gvRow.Cells[15].Text + "'");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["ItemCode"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["Series"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["Length"] = gvRow.Cells[3].Text;
         
            dt.Rows[dt.Rows.Count - 1]["Color"] = gvRow.Cells[4].Text;
          
            dt.Rows[dt.Rows.Count - 1]["RequiredDate"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["Requestfor"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["ItemCodeId"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["ColorId"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["SoId"] = gvRow.Cells[9].Text;
            dt.Rows[dt.Rows.Count - 1]["SoMatId"] = gvRow.Cells[10].Text;
            
            dt.Rows[dt.Rows.Count - 1]["RequiredQty"] = gvRow.Cells[11].Text;
            dt.Rows[dt.Rows.Count - 1]["Uom"] = gvRow.Cells[12].Text;
            dt.Rows[dt.Rows.Count - 1]["PU"] = gvRow.Cells[13].Text;
            dt.Rows[dt.Rows.Count - 1]["Qty"] = gvRow.Cells[14].Text;

            string Itemcode = gvRow.Cells[7].Text;
            string ColorId  =  gvRow.Cells[8].Text;
            string Length = gvRow.Cells[3].Text;

            if (Itemcode != "")
            {
                SCM.Stock obj1 = new SCM.Stock();

                if (obj1.StockOnStorageLocationCS1(Itemcode, ColorId,Length) > 0)
                {
                    dt.Rows[dt.Rows.Count - 1]["QtyinStock"] = obj1.Quantity;
                }
                else
                {
                    dt.Rows[dt.Rows.Count - 1]["QtyinStock"] = "0";
                }

               

            }
            dt.Rows[dt.Rows.Count - 1]["qtyorder"] = "";
            dt.Rows[dt.Rows.Count - 1]["Remarks"] = "";

            dt.Rows[dt.Rows.Count - 1]["BlockQty"] = "";
            dt.Rows[dt.Rows.Count - 1]["IndId"] = gvRow.Cells[15].Text;

            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("IndId = '" + gvRow.Cells[15].Text + "'");
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
        CheckBox chkAll = (CheckBox)gvIndent.HeaderRow
                            .Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvIndent.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvIndent.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvIndent.Rows[i]
                                .Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    dt = AddRow(gvIndent.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRow(gvIndent.Rows[i], dt);
                }
            }
        }
        ViewState["SelectedRecords"] = dt;
    }

    private void SetData()
    {
        CheckBox chkAll = (CheckBox)gvIndent.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        if (ViewState["SelectedRecords"] != null)
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            for (int i = 0; i < gvIndent.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvIndent.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    DataRow[] dr = dt.Select("IndId = '" + gvIndent.Rows[i].Cells[15].Text + "'");
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

        col = new DataColumn("qtyorder");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Remarks");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("BlockQty");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("IndId");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("QtyinStock");
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
                    dr["Color"] = gvrow.Cells[4].Text;
                    dr["RequiredDate"] = gvrow.Cells[5].Text;
                    dr["Requestfor"] = gvrow.Cells[6].Text;
                    dr["ItemCodeId"] = gvrow.Cells[7].Text;
                    dr["ColorId"] = gvrow.Cells[8].Text;
                    dr["SoId"] = gvrow.Cells[9].Text;
                    dr["SoMatId"] = gvrow.Cells[10].Text;
                    dr["RequiredQty"] = gvrow.Cells[11].Text;
                    dr["Uom"] = gvrow.Cells[12].Text;
                    dr["PU"] = gvrow.Cells[13].Text;
                    dr["Qty"] = gvrow.Cells[14].Text;
                    dr["QtyinStock"] = gvrow.Cells[15].Text;

                    TextBox qtyorder = (TextBox)gvrow.FindControl("txtqtyorder");
                    dr["qtyorder"] = qtyorder.Text;

                    TextBox remarks = (TextBox)gvrow.FindControl("txtitemremarks");
                    dr["Remarks"] = remarks.Text;


                    TextBox Blockqty = (TextBox)gvrow.FindControl("txtBlockQty");
                    dr["BlockQty"] = Blockqty.Text;


                    dr["IndId"] = gvrow.Cells[19].Text;


                    
                  
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvItems.DataSource = SalesOrderItems;
        gvItems.DataBind();
    }
    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[18].Visible = false;
            e.Row.Cells[19].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[13].Visible = false;

         
        }
    }




    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            SCM.IndentApproval objSMSOApprove = new SCM.IndentApproval();
            objSMSOApprove.IndappId = Request.QueryString["Cid"].ToString();
            objSMSOApprove.IndId = ddlIndent.SelectedItem.Value;
            objSMSOApprove.ApprovedBy = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSMSOApprove.IndentAppvalApprove_Update();


            foreach (GridViewRow gvRowOtherCorp in gvIndentedappr.Rows)
            {

                objSMSOApprove.Indappdetid = gvRowOtherCorp.Cells[8].Text;
                TextBox remarks = (TextBox)gvRowOtherCorp.FindControl("txtitemremarks");
                objSMSOApprove.Remarks = remarks.Text;

                if(objSMSOApprove.Remarks != "")
                { 
                objSMSOApprove.IndentApproverRemarksStatus_Update();
                }



            }



            if (ddlIndent.SelectedItem.Value != "0")
            {
               
                objSMSOApprove.IndentAppvalApproveMaterial_Update();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Response.Redirect("~/Modules/Stock/IndentApproval.aspx");
        }
    }
    protected void gvIndentedappr_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[8].Visible = false;

        }
    }
}