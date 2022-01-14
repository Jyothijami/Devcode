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

public partial class Modules_Sales_SalesOrder_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        txttax.Attributes.Add("onkeyup", "javascript:grosscalc();");
        txtdiscount.Attributes.Add("onkeyup", "javascript:grosscalc();");

        if (!IsPostBack)
        {
          //  gvQuatation.DataBind();
          //  SM.CustomerMaster.CustomerMaster_Select(ddlSoldtoParty);
            Masters.PaymentTerms.Payment_Select(ddlpaymentterms);
          //  Masters.IncoTerms.IncoTerms_Select(ddlincoterms);
           
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);

            SM.SalesQuotation.SalesQuotation_Select(ddlQuotationno);

           txtsalesorderno.Text = SM.SalesOrder.SalesOrder_AutoGenCode();
           txtSalesorderdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

           SM.CustomerMaster.CustomerMaster_Select(ddlCustomer);
           SM.CustomerMaster.CustomerMaster_Select(ddlQuotCust);
           SM.CustomerMaster.CustomerUnit_Select(ddlsite);
           txtDeliveryDate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

           

            Masters.MaterialMaster.MaterialMaster_Select(ddlItemcode);
            Masters.ColorMaster.Color_Select(ddlColor);
        }

    }

   
    protected void gvitems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // e.Row.Cells[1].Attributes.Add("onclick", "return confirm('Are you sure you want to remove this Item from Item Details list?');");
              //  e.Row.Cells[9].Text = (Convert.ToDecimal(e.Row.Cells[7].Text) * Convert.ToDecimal(txtratepersqmt.Text)).ToString();

               // DropDownList ddlitemcodes = e.Row.FindControl("ddlitemcodes");
              //  DropDownList ddlitemcodes = (DropDownList)gvitems.FindControl("ddlitemcodes");
               // DropDownList ddlColor = (DropDownList)gvitems.FindControl("ddlitemColors");

                DropDownList ddlitemcodes = (e.Row.FindControl("ddlitemcodes") as DropDownList);
                DropDownList ddlColor = (e.Row.FindControl("ddlitemColors") as DropDownList);
                
                Masters.MaterialMaster.MaterialMaster_Select(ddlitemcodes);
                Masters.ColorMaster.Color_Select(ddlColor);
            
            }


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            txtsubtotal.Text = txttotal.Text = GrossAmountCalc().ToString();
            // GrandTotal();
        }
             
    }

    private double GrossAmountCalc()
    {
        double _totalAmt = 0;
        //  double gst = 0;
        foreach (GridViewRow gvrow in gvitems.Rows)
        {



            _totalAmt = _totalAmt + Convert.ToDouble(gvrow.Cells[13].Text);

           
        }
        return _totalAmt;
    }


    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("CodeNo");
        dt.Columns.Add("ItemCode");
        dt.Columns.Add("Color");
        dt.Columns.Add("Width");
        dt.Columns.Add("height");

        dt.Columns.Add("SillHeight");

        dt.Columns.Add("Series");

        dt.Columns.Add("Qty");
        dt.Columns.Add("Glass");
        dt.Columns.Add("FlyScreen");
        dt.Columns.Add("Amount");
        dt.Columns.Add("TotalAmount");

        
        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("CodeNo = '" + gvRow.Cells[1].Text + "'");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["CodeNo"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["ItemCode"] = "";
            dt.Rows[dt.Rows.Count - 1]["Color"] = "";


            dt.Rows[dt.Rows.Count - 1]["Width"] = gvRow.Cells[2].Text;

            dt.Rows[dt.Rows.Count - 1]["height"] = gvRow.Cells[3].Text;

            dt.Rows[dt.Rows.Count - 1]["SillHeight"] = gvRow.Cells[4].Text;
            dt.Rows[dt.Rows.Count - 1]["Series"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["Qty"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["Glass"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["FlyScreen"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["Amount"] = gvRow.Cells[9].Text;

            dt.Rows[dt.Rows.Count - 1]["TotalAmount"] = gvRow.Cells[10].Text;
            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("CodeNo = '" + gvRow.Cells[1].Text + "'");
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
        CheckBox chkAll = (CheckBox)gvQuatationItems.HeaderRow
                            .Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvQuatationItems.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvQuatationItems.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvQuatationItems.Rows[i]
                                .Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    dt = AddRow(gvQuatationItems.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRow(gvQuatationItems.Rows[i], dt);
                }
            }
        }
        ViewState["SelectedRecords"] = dt;
    }

    private void SetData()
    {
        CheckBox chkAll = (CheckBox)gvQuatationItems.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        if (ViewState["SelectedRecords"] != null)
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            for (int i = 0; i < gvQuatationItems.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvQuatationItems.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    DataRow[] dr = dt.Select("CodeNo = '" + gvQuatationItems.Rows[i].Cells[2].Text + "'");
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







    protected void btnadditem_Click(object sender, EventArgs e)
    {
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Glass");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Mesh");
        SalesOrderItems.Columns.Add(col);
       
        col = new DataColumn("Width");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Height");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Areasq");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SeriesID");
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
                        //dr["Series"] = ddlItemSeries.SelectedItem.Text;
                        //dr["Description"] = txtItemDescription.Text; ;

                        //dr["Mesh"] = txtmesh.Text;
                        //dr["Glass"] = txtItemGlass.Text;
                        //dr["Width"] = txtitemwidth.Text;
                        //dr["Height"] = txtHeight.Text;
                        //dr["Qty"] = txtitemqty.Text;
                        //dr["Areasq"] = txtareasq.Text;
                        //dr["SeriesID"] = ddlItemSeries.SelectedItem.Value;
                       
                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["Series"] = gvrow.Cells[1].Text;
                        dr["Description"] = gvrow.Cells[2].Text;
                        dr["Glass"] = gvrow.Cells[3].Text;
                        dr["Mesh"] = gvrow.Cells[4].Text;
                       
                        dr["Width"] = gvrow.Cells[5].Text;
                        dr["Height"] = gvrow.Cells[6].Text;
                        dr["Qty"] = gvrow.Cells[7].Text;
                        dr["Areasq"] = gvrow.Cells[8].Text;
                        dr["SeriesID"] = gvrow.Cells[10].Text;
                       
                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Series"] = gvrow.Cells[1].Text;
                    dr["Description"] = gvrow.Cells[2].Text;
                    dr["Glass"] = gvrow.Cells[3].Text;
                    dr["Mesh"] = gvrow.Cells[4].Text;

                    dr["Width"] = gvrow.Cells[5].Text;
                    dr["Height"] = gvrow.Cells[6].Text;
                    dr["Qty"] = gvrow.Cells[7].Text;
                    dr["Areasq"] = gvrow.Cells[8].Text;
                    dr["SeriesID"] = gvrow.Cells[10].Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }


        if (gvitems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            //drnew["Series"] = ddlItemSeries.SelectedItem.Text;
            //drnew["Description"] = txtItemDescription.Text; ;

            //drnew["Mesh"] = txtmesh.Text;
            //drnew["Glass"] = txtItemGlass.Text;
            //drnew["Width"] = txtitemwidth.Text;
            //drnew["Height"] = txtHeight.Text;
            //drnew["Qty"] = txtitemqty.Text;
            //drnew["Areasq"] = txtareasq.Text;
            //drnew["SeriesID"] = ddlItemSeries.SelectedItem.Value;
            SalesOrderItems.Rows.Add(drnew);
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
        gvitems.SelectedIndex = -1;
    }
    protected void gvitems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvitems.Rows[e.RowIndex].Cells[1].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Glass");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Mesh");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Width");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Height");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Areasq");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SeriesID");
        SalesOrderItems.Columns.Add(col);
        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Series"] = gvrow.Cells[1].Text;
                    dr["Description"] = gvrow.Cells[2].Text;
                    dr["Glass"] = gvrow.Cells[3].Text;
                    dr["Mesh"] = gvrow.Cells[4].Text;

                    dr["Width"] = gvrow.Cells[5].Text;
                    dr["Height"] = gvrow.Cells[6].Text;
                    dr["Qty"] = gvrow.Cells[7].Text;
                    dr["Areasq"] = gvrow.Cells[8].Text;
                    dr["SeriesID"] = gvrow.Cells[10].Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    SM.SalesOrder objSM = new SM.SalesOrder();
        //    objSM.SONO = txtsalesorderno.Text;
        //    objSM.SODATE = General.toMMDDYYYY(txtSalesorderdate.Text);
        //    objSM.QUOID = ddlQuotationno.SelectedItem.Value;
        //    objSM.PRICINGDATE = General.toMMDDYYYY(txtPricingDate.Text);
        //    objSM.PREPAREDBY = ddlpreparedby.SelectedItem.Value;
        //    objSM.APPROVEDBY = ddlapprovedby.SelectedItem.Value;
        //    //objSM.TERMSCONDTIONS = HttpUtility.HtmlEncode(txttermsconditions.Text);
        //    objSM.TERMSCONDTIONS = txttermsconditions.Text;
        //    objSM.Custid = ddlSoldtoParty.SelectedItem.Value;
        //    objSM.SiteId = ddlshiptoparty.SelectedItem.Value;
        //    objSM.Status = "New";

        //    if (objSM.SalesOrder_Save() == "Data Saved Successfully")
        //    {
        //        objSM.SalesOrderDetails_Delete(objSM.SOID);
        //        foreach (GridViewRow gvrow in gvitems.Rows)
        //        {
        //            objSM.Matid = gvrow.Cells[10].Text;
        //            objSM.Description = gvrow.Cells[2].Text;
        //           objSM.Mesh = gvrow.Cells[4].Text;
        //            objSM.Glass = gvrow.Cells[3].Text;
        //            objSM.Width = gvrow.Cells[5].Text;
        //            objSM.Height = gvrow.Cells[6].Text;
        //            objSM.Qty = gvrow.Cells[7].Text;
        //            objSM.Areasqmt = gvrow.Cells[8].Text;
        //            objSM.Amount = gvrow.Cells[9].Text;

        //            objSM.SalesOrderDetails_Save();
        //        }

        //        MessageBox.Show(this, "Data Saved Successfully");
        //    }
          
        //}
        //catch (Exception ex)
        //{

        //    MessageBox.Show(this, ex.Message.ToString());
        //}
        //finally
        //{

        //}
    }
    protected void gvQuatation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[0].Visible = false;
          
            //e.Row.Cells[10].Visible = false;
            //e.Row.Cells[11].Visible = false;
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void btnAddItems_Click(object sender, EventArgs e)
    {

    }
    protected void ddlpaymentterms_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddltermscondtions_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesQuotation.CustSalesQuotation_Select(ddlQuotationno, ddlCustomer.SelectedItem.Value);
    }
    protected void ddlQuotationno_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesQuotation obj = new SM.SalesQuotation();

        if(obj.SalesQuotation_Select(ddlQuotationno.SelectedItem.Value) > 0)
        {
            txtquotationdate.Text = obj.QuotDate;

            ddlQuotCust.SelectedValue = obj.CustId;
            ddlQuotCust_SelectedIndexChanged(sender, e);

            ddlsite.SelectedValue = obj.UnitId;
            ddlsite_SelectedIndexChanged(sender, e);

            obj.SalesQuotationDetails_Select(ddlQuotationno.SelectedItem.Value, gvQuatationItems);

            




        }


    }
    protected void ddlQuotCust_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.CustomerMaster obj = new SM.CustomerMaster();

        if (obj.CustomerMaster_Select(ddlQuotCust.SelectedItem.Value) > 0)
        {

            txtCustomerAddress.Text = obj.custaddress;
            txtshippingaddress.Text = obj.custaddress;
            txtContactperson.Text = obj.CustContactPerson;
            txtContactMobileNo.Text = obj.CustMobile;
            SM.CustomerMaster.CustomerUnit_Select(ddlsite, ddlQuotCust.SelectedItem.Value);
        
        }
    }
    protected void ddlsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.CustomerMaster obj = new SM.CustomerMaster();

        if (obj.CustomerUnitMaster_Select(ddlsite.SelectedItem.Value) > 0)
        {
            txtsiteaddress.Text = obj.UnitAddress;
            txtsiteContactperson.Text = obj.UnitContactPerson;
            txtsiteMobileno.Text = obj.UnitMobileNo;
        }

    }
    protected void ddlItemcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.MaterialMaster.ItemMaster_ModelNoSelect(ddlColor, ddlItemcode.SelectedItem.Value);
    }
    protected void ddlitemcodes_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gvitems.Rows)
        {
            DropDownList ddlitemcodes = (DropDownList)gvr.FindControl("ddlitemcodes");
            DropDownList ddlColor = (DropDownList)gvr.FindControl("ddlitemColors");



            Masters.MaterialMaster.ItemMaster_ModelNoSelect(ddlColor, ddlitemcodes.SelectedItem.Value);
           
        }
    }
}