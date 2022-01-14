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

public partial class Modules_Purchases_PurchaseOrderDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            SCM.SuppliersMaster.SuppliersMaster_Select(ddlsupplier);
            SCM.Indent.Indent_Select(ddlIndent);
            Masters.PaymentTerms.Payment_Select(ddlPaymentterms);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            Masters.MaterialMaster.MaterialMaster_Select(ddlMaterial);
            txtPONo.Text = SCM.SupplierPO.SupplierPO_AutoGenCode();
            txtPOdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            Masters.DespatchMode.DespatchMode_Select(ddldispatch);
            SM.CustomerMaster.CustomerMaster_Select(ddlCustomerName);
            


            txtCif.Attributes.Add("onkeyup", "javascript:netamtcalc();");
            txtFob.Attributes.Add("onkeyup", "javascript:netamtcalc();");
            txtgst.Attributes.Add("onkeyup", "javascript:netamtcalc();");
            txtdiscount.Attributes.Add("onkeyup", "javascript:netamtcalc();");
        }
        {
            txtnetamount.Text = NetAmountCalc().ToString();
            if (txtdiscount.Text == "" || txtdiscount.Text == string.Empty) { txtdiscount.Text = "0"; }
            if (txtgst.Text == "" || txtgst.Text == string.Empty) { txtgst.Text = "0"; }
            if (txtFob.Text == "" || txtFob.Text == string.Empty) { txtFob.Text = "0"; }
            if (txtCif.Text == "" || txtCif.Text == string.Empty) { txtCif.Text = "0"; }
            txtnetamount.Text = Convert.ToString(double.Parse(txtnetamount.Text) - (double.Parse(txtdiscount.Text) * double.Parse(txtnetamount.Text) / 100) + (double.Parse(txtgst.Text) * double.Parse(txtnetamount.Text) / 100) + double.Parse(txtCif.Text) + double.Parse(txtFob.Text));
        }
    }


    protected void ddlsupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.SuppliersMaster obj = new SCM.SuppliersMaster();
        if(obj.SuppliersMaster_Select(ddlsupplier.SelectedItem.Value)>0)
        {
            txtContactPerson.Text = obj.SupContactPerson;
            txtContactNo.Text = obj.SupMobile;
            txtCountry.Text = obj.CountryName;
            txtCurrency.Text = obj.Currency;
        }

    }
    protected void ddlIndent_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.Indent obj = new SCM.Indent();
        if(obj.Indent_Select(ddlIndent.SelectedItem.Value) >0)
        {
            txtIndentdate.Text = obj.INDDate;
            obj.IndentDetails_Select(ddlIndent.SelectedItem.Value, gvIndentItems);

        }

    }
    protected void gvIndentItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
        }
    }



    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Series");
        dt.Columns.Add("Length");
        dt.Columns.Add("Description");
        dt.Columns.Add("Color");
        dt.Columns.Add("Qty");
       
       
      
        dt.Columns.Add("SeriesId");

        dt.Columns.Add("CustomerName");
        dt.Columns.Add("CustId");

        dt.Columns.Add("Kgpermtr");
        dt.Columns.Add("TotalWeight");
        dt.Columns.Add("AlumiumCoating");
        dt.Columns.Add("Amount");
        dt.Columns.Add("ColorId");


        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("SeriesId = '" + gvRow.Cells[12].Text + "'");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["Series"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["Length"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["Description"] = gvRow.Cells[3].Text;
            dt.Rows[dt.Rows.Count - 1]["Color"] = gvRow.Cells[4].Text;
            dt.Rows[dt.Rows.Count - 1]["Qty"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["Kgpermtr"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["TotalWeight"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["AlumiumCoating"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["Amount"] = gvRow.Cells[9].Text;
            dt.Rows[dt.Rows.Count - 1]["CustomerName"] = gvRow.Cells[10].Text;
            dt.Rows[dt.Rows.Count - 1]["CustId"] = gvRow.Cells[11].Text;
            dt.Rows[dt.Rows.Count - 1]["SeriesId"] = gvRow.Cells[12].Text;
            dt.Rows[dt.Rows.Count - 1]["ColorId"] = gvRow.Cells[13].Text;


            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("SeriesId = '" + gvRow.Cells[12].Text + "'");
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
        CheckBox chkAll = (CheckBox)gvIndentItems.HeaderRow
                            .Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvIndentItems.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvIndentItems.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvIndentItems.Rows[i]
                                .Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    dt = AddRow(gvIndentItems.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRow(gvIndentItems.Rows[i], dt);
                }
            }
        }
        ViewState["SelectedRecords"] = dt;
    }

    private void SetData()
    {
        CheckBox chkAll = (CheckBox)gvIndentItems.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        if (ViewState["SelectedRecords"] != null)
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            for (int i = 0; i < gvIndentItems.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvIndentItems.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    DataRow[] dr = dt.Select("SeriesId = '" + gvIndentItems.Rows[i].Cells[12].Text + "'");
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
        gvitems.DataSource = dt;
        gvitems.DataBind();
    }

    protected void gvitems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    // e.Row.Cells[1].Attributes.Add("onclick", "return confirm('Are you sure you want to remove this Item from Item Details list?');");
            //    e.Row.Cells[7].Text = (Convert.ToDecimal(e.Row.Cells[5].Text) * Convert.ToDecimal(e.Row.Cells[6].Text)).ToString();
            //}
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            txttotalExworks.Text = NetAmountCalc().ToString();
        }
    }

    private object NetAmountCalc()
    {
        double _totalAmt = 0;
        foreach (GridViewRow gvrow in gvitems.Rows)
        {
            _totalAmt = _totalAmt + Convert.ToDouble(gvrow.Cells[9].Text);
        }
        txtnetamount.Text = _totalAmt.ToString();
        if (txtdiscount.Text == "" || txtdiscount.Text == string.Empty) { txtdiscount.Text = "0"; }
        if (txtgst.Text == "" || txtgst.Text == string.Empty) { txtgst.Text = "0"; }
        txtnetamount.Text = Convert.ToString(double.Parse(txtnetamount.Text) - (double.Parse(txtdiscount.Text) * double.Parse(txtnetamount.Text) / 100) + (double.Parse(txtgst.Text) * double.Parse(txtnetamount.Text) / 100));

            return _totalAmt;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SCM.SupplierPO objSM = new SCM.SupplierPO();
            objSM.PONo = txtPONo.Text;
            objSM.PODate = General.toMMDDYYYY(txtPOdate.Text);
            objSM.INDID = ddlIndent.SelectedItem.Value;
            objSM.SUPID = ddlsupplier.SelectedItem.Value;
            objSM.STATUS = "New";
            objSM.NETAMOUNT = txtnetamount.Text;
            objSM.TermsConds = txttermscondtions.Text;
            objSM.DespmId = ddldispatch.SelectedItem.Value;
            objSM.PAYMENTTERMSID = ddlPaymentterms.SelectedItem.Value;
            objSM.CURRENCYID = txtCurrency.Text;
            objSM.DESTINATION = txtDestination.Text;
            objSM.INSURANCE = txtInsurance.Text;
            objSM.FREIGHT = txtFreight.Text;
            objSM.DISCOUNT = txtdiscount.Text;
            objSM.GST = txtgst.Text;
            objSM.PREPAREDBY = ddlpreparedby.SelectedItem.Value;
            objSM.APPROVEDBY = ddlapprovedby.SelectedItem.Value;
            objSM.CIF = txtCif.Text;
            objSM.FOB = txtFob.Text;
            objSM.TERMSOFDELIVERY = txttermsofdelivery.Text;

            if (objSM.SuppliersPO_Save() == "Data Saved Successfully")
            {
                objSM.SuppliersPODetails_Delete(objSM.POId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.MatId = gvrow.Cells[12].Text;
                    objSM.Description = gvrow.Cells[3].Text;
                    objSM.Length = gvrow.Cells[2].Text;
                    objSM.Color = gvrow.Cells[4].Text;
                    objSM.Qty = gvrow.Cells[5].Text;
                    objSM.custid = gvrow.Cells[11].Text;
                    objSM.kgpermt = gvrow.Cells[6].Text;
                    objSM.totalweight = gvrow.Cells[7].Text;
                    objSM.aluminumcoating = gvrow.Cells[8].Text;
                    objSM.amount = gvrow.Cells[9].Text;

                    objSM.PoRecievedqty = "0";
                    objSM.PoRemainingQty = gvrow.Cells[5].Text;
                    objSM.PoItemStatus = "Pending";
                    objSM.plantid = "0";
                    objSM.storagelocid = "0";
                    objSM.stocktypeid = "0";
                    objSM.cOLORID = gvrow.Cells[13].Text;
                    objSM.SuppliersPODetails_Save();
                }

                MessageBox.Show(this, "Data Saved Successfully");
            }

        }
        catch (Exception ex)
        {

            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {

        }

    }
    protected void gvitems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvitems.Rows[e.RowIndex].Cells[1].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Length");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("CustomerName");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("CustId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SeriesId");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Kgpermtr");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("TotalWeight");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("AlumiumCoating");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Amount");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Series"] = gvrow.Cells[1].Text;
                    dr["Length"] = gvrow.Cells[2].Text;
                    dr["Description"] = gvrow.Cells[3].Text;
                    dr["Color"] = gvrow.Cells[4].Text;
                    dr["Qty"] = gvrow.Cells[5].Text;
                    dr["CustomerName"] = gvrow.Cells[10].Text;
                    dr["CustId"] = gvrow.Cells[11].Text;
                    dr["SeriesId"] = gvrow.Cells[12].Text;
                    dr["Kgpermtr"] = gvrow.Cells[6].Text;
                    dr["TotalWeight"] = gvrow.Cells[7].Text;
                    dr["AlumiumCoating"] = gvrow.Cells[8].Text;
                    dr["Amount"] = gvrow.Cells[9].Text;
                    dr["ColorId"] = gvrow.Cells[13].Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
    }
    protected void btnadditem_Click(object sender, EventArgs e)
    {
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Length");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("CustomerName");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("CustId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SeriesId");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Kgpermtr");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("TotalWeight");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("AlumiumCoating");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Amount");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);

        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvitems.SelectedIndex > -1)
                {
                    if (gvrow.RowIndex == gvitems.SelectedRow.RowIndex)
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["Series"] = ddlMaterial.SelectedItem.Text;
                        dr["Length"] = txtlength.Text; ;
                        dr["Description"] = txtDescription.Text;
                        dr["Color"] = txtColor.SelectedItem.Text;
                        dr["Qty"] = txtQty.Text;
                        dr["CustomerName"] = ddlCustomerName.SelectedItem.Text;
                        dr["CustId"] = ddlCustomerName.SelectedItem.Value;
                        dr["SeriesId"] = ddlMaterial.SelectedItem.Text;

                        dr["Kgpermtr"] = txtkgpermtr.Text;
                        dr["TotalWeight"] = txttotalweight.Text;
                        dr["AlumiumCoating"] = txtaluminumcoating.Text;
                        dr["Amount"] = txtamount.Text;
                        dr["ColorId"] = txtColor.SelectedItem.Value;
                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["Series"] = gvrow.Cells[1].Text;
                        dr["Length"] = gvrow.Cells[2].Text;
                        dr["Description"] = gvrow.Cells[3].Text;
                        dr["Color"] = gvrow.Cells[4].Text;
                        dr["Qty"] = gvrow.Cells[5].Text;
                        dr["CustomerName"] = gvrow.Cells[10].Text;
                        dr["CustId"] = gvrow.Cells[11].Text;
                        dr["SeriesId"] = gvrow.Cells[12].Text;
                        dr["Kgpermtr"] = gvrow.Cells[6].Text;
                        dr["TotalWeight"] = gvrow.Cells[7].Text;
                        dr["AlumiumCoating"] = gvrow.Cells[8].Text;
                        dr["Amount"] = gvrow.Cells[9].Text;
                        dr["ColorId"] = gvrow.Cells[13].Text;

                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Series"] = gvrow.Cells[1].Text;
                    dr["Length"] = gvrow.Cells[2].Text;
                    dr["Description"] = gvrow.Cells[3].Text;
                    dr["Color"] = gvrow.Cells[4].Text;
                    dr["Qty"] = gvrow.Cells[5].Text;
                    dr["CustomerName"] = gvrow.Cells[10].Text;
                    dr["CustId"] = gvrow.Cells[11].Text;
                    dr["SeriesId"] = gvrow.Cells[12].Text;
                    dr["Kgpermtr"] = gvrow.Cells[6].Text;
                    dr["TotalWeight"] = gvrow.Cells[7].Text;
                    dr["AlumiumCoating"] = gvrow.Cells[8].Text;
                    dr["Amount"] = gvrow.Cells[9].Text;
                    dr["ColorId"] = gvrow.Cells[13].Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }


        if (gvitems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["Series"] = ddlMaterial.SelectedItem.Text;
            drnew["Length"] = txtlength.Text;
            drnew["Description"] = txtDescription.Text;
            drnew["Color"] = txtColor.Text;
            drnew["Qty"] = txtQty.Text;
            drnew["CustomerName"] = ddlCustomerName.SelectedItem.Text;
            drnew["CustId"] = ddlCustomerName.SelectedItem.Value;
            drnew["SeriesId"] = ddlMaterial.SelectedItem.Value;
            drnew["Kgpermtr"] = txtkgpermtr.Text;
            drnew["TotalWeight"] = txttotalweight.Text;
            drnew["AlumiumCoating"] = txtaluminumcoating.Text;
            drnew["Amount"] = txtamount.Text;
            drnew["ColorId"] = txtColor.SelectedItem.Value;
            SalesOrderItems.Rows.Add(drnew);

        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
        gvitems.SelectedIndex = -1;
    }
    protected void ddlMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.MaterialMaster obj = new Masters.MaterialMaster();
        if (obj.MaterialType_Select(ddlMaterial.SelectedItem.Value) > 0)
        {
            txtDescription.Text = obj.Description;
            txtlength.Text = obj.BarLength;
            txtkgpermtr.Text = obj.weight;

        }
        Masters.MaterialMaster.ItemMaster_ModelNoSelect(txtColor, ddlMaterial.SelectedValue);

    }
}