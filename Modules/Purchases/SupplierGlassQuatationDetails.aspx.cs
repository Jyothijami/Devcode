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

public partial class Modules_Purchases_SupplierGlassQuatationDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txttax.Attributes.Add("onkeyup", "javascript:grosscalc();");
        txtdiscount.Attributes.Add("onkeyup", "javascript:grosscalc();");
        string Qid = Request.QueryString["Cid"].ToString();

        if (!IsPostBack)
        {
            gvitems.DataBind();

            SCM.SuppliersMaster.SuppliersMaster_Select(ddlSupplier);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            SM.SalesOrder.SalesOrder_Select(ddlMaterialrequest);

            txtdiscount.Text = txttax.Text = txttotal.Text = txtsubtotal.Text = "0";
            txtquatationno.Text = SCM.SupplierGlassQuotation.SupplierGlassQuotation_AutoGenCode();
            txtquotationdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);


            if (Qid != "Add")
            {
                QuatationFill();
                btnSave.Visible = false;
                btnApprove.Visible = true;
            }
            else
            {
                btnPrint.Visible = false;
                btnApprove.Visible = false;
            }
        }
    }

    private void QuatationFill()
    {
        SCM.SupplierGlassQuotation obj = new SCM.SupplierGlassQuotation();
        if (obj.SupplierGlassQuotation_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            txtquatationno.Text = obj.QuotNo;
            txtquotationdate.Text = obj.QuotDate;
            ddlSupplier.SelectedValue = obj.SupId;
            ddlSupplier_SelectedIndexChanged(new object(), new System.EventArgs());

            ddlMaterialrequest.SelectedValue = obj.SoId;
            ddlMaterialrequest_SelectedIndexChanged(new object(), new System.EventArgs());

            txttermsconditions.Text = HttpUtility.HtmlDecode(obj.TermsCondtionId);
            txtpaymenttermsdetails.Text = HttpUtility.HtmlDecode(obj.PaymentTermsId);

            txtdiscount.Text = obj.Discount;
            txttax.Text = obj.Tax;
            txttotal.Text = obj.GrandTotal;
            ddlpreparedby.SelectedValue = obj.Preparedby;
            ddlapprovedby.SelectedValue = obj.Approvedby;
            obj.GlassQuotatation_Select(Request.QueryString["Cid"].ToString(), gvitems);
        }
    }

    protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.SuppliersMaster obj = new SCM.SuppliersMaster();

        if (obj.SuppliersMaster_Select(ddlSupplier.SelectedItem.Value) > 0)
        {
            txtsupaddress.Text = obj.SupAddress;
            txtSupCurrency.Text = obj.Currency;
            txtSupContactMobileNo.Text = obj.SupMobile;
            txtSupContactperson.Text = obj.SupContactPerson;
        }
    }

    protected void ddlMaterialrequest_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesOrder obj = new SM.SalesOrder();

        if (obj.SalesOrder_Select(ddlMaterialrequest.SelectedItem.Value) > 0)
        {
            obj.SoGlassEnquriy_Select(ddlMaterialrequest.SelectedItem.Value, gvEnqItems);
        }
    }





    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("WindowCode");
        dt.Columns.Add("Thickness");
        dt.Columns.Add("Description");
        dt.Columns.Add("Width");
        dt.Columns.Add("Height");
      
        dt.Columns.Add("Unit");
        dt.Columns.Add("Area");
        dt.Columns.Add("Weight");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Rate");
        dt.Columns.Add("Amount");
       

        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("WindowCode = '" + gvRow.Cells[1].Text + "'");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["WindowCode"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["Thickness"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["Description"] = gvRow.Cells[3].Text;
            dt.Rows[dt.Rows.Count - 1]["Width"] = gvRow.Cells[4].Text;
            dt.Rows[dt.Rows.Count - 1]["Height"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["Unit"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["Area"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["Weight"] = gvRow.Cells[9].Text;
            dt.Rows[dt.Rows.Count - 1]["Quantity"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["Rate"] = "";
            dt.Rows[dt.Rows.Count - 1]["Amount"] = "";

            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("WindowCode = '" + gvRow.Cells[1].Text + "'");
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
        CheckBox chkAll = (CheckBox)gvEnqItems.HeaderRow
                            .Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvEnqItems.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvEnqItems.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvEnqItems.Rows[i]
                                .Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    dt = AddRow(gvEnqItems.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRow(gvEnqItems.Rows[i], dt);
                }
            }
        }
        ViewState["SelectedRecords"] = dt;
    }

    private void SetData()
    {
        CheckBox chkAll = (CheckBox)gvEnqItems.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        if (ViewState["SelectedRecords"] != null)
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            for (int i = 0; i < gvEnqItems.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvEnqItems.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    DataRow[] dr = dt.Select("WindowCode = '" + gvEnqItems.Rows[i].Cells[1].Text + "'");
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

    protected void txtitemamount_TextChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gvitems.Rows)
        {
            TextBox rate = (TextBox)gvr.FindControl("txtitemamount");
            TextBox qty = (TextBox)gvr.FindControl("txtitemqty");
            Label amount = (Label)gvr.FindControl("lblAmount");

            if (rate.Text != "" && qty.Text != "")
            {
                amount.Text = (Convert.ToDecimal(rate.Text) * Convert.ToDecimal(qty.Text)).ToString();
                txtsubtotal.Text = txttotal.Text = NetAmountCalc().ToString();
            }
            else
            {
                amount.Text = "0";
                txtsubtotal.Text = txttotal.Text = NetAmountCalc().ToString();
            }
        }
    }

    private double NetAmountCalc()
    {
        double _totalAmt = 0;
        foreach (GridViewRow gvrow in gvitems.Rows)
        {
            Label amt = (Label)gvrow.FindControl("lblAmount");
            if (amt.Text != "")
            {
                _totalAmt = _totalAmt + Convert.ToDouble(amt.Text);
            }
            else
            {
                _totalAmt = _totalAmt + 0;
            }
        }
        return _totalAmt;
    }

    protected void btnAddItems_Click(object sender, EventArgs e)
    {
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("WindowCode");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Thickness");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Width");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Height");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Quantity");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Unit");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Area");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Weight");
        SalesOrderItems.Columns.Add(col);


        col = new DataColumn("Rate");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Amount");
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
                        dr["WindowCode"] = txtwindowCode.Text;
                        dr["Thickness"] = txtThickness.Text;
                        dr["Description"] = txtDescription.Text;
                        dr["Width"] = txtWidth.Text;
                        dr["Height"] = txtHeight.Text;
                        dr["Quantity"] = txtQuantity.Text;
                        dr["Unit"] = txtUnit.Text;
                        dr["Area"] = txtArea.Text;
                        dr["Weight"] = txtWeight.Text;
                        dr["Rate"] = txtitemrate.Text;
                        dr["Amount"] = txtitemamount.Text;

                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["WindowCode"] = gvrow.Cells[2].Text;
                        dr["Thickness"] = gvrow.Cells[3].Text;
                        dr["Description"] = gvrow.Cells[4].Text;
                        dr["Width"] = gvrow.Cells[5].Text;
                        dr["Height"] = gvrow.Cells[6].Text;
                        
                        dr["Unit"] = gvrow.Cells[7].Text;
                        dr["Area"] = gvrow.Cells[8].Text;
                        dr["Weight"] = gvrow.Cells[9].Text;
                        dr["Quantity"] = gvrow.Cells[10].Text;
                        dr["Rate"] = gvrow.Cells[11].Text;
                        dr["Amount"] = gvrow.Cells[12].Text;

                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["WindowCode"] = gvrow.Cells[2].Text;
                    dr["Thickness"] = gvrow.Cells[3].Text;
                    dr["Description"] = gvrow.Cells[4].Text;
                    dr["Width"] = gvrow.Cells[5].Text;
                    dr["Height"] = gvrow.Cells[6].Text;
                    dr["Unit"] = gvrow.Cells[7].Text;
                    dr["Area"] = gvrow.Cells[8].Text;
                    dr["Weight"] = gvrow.Cells[9].Text;
                    dr["Quantity"] = gvrow.Cells[10].Text;
                    dr["Rate"] = gvrow.Cells[11].Text;
                    dr["Amount"] = gvrow.Cells[12].Text;

                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }

        if (gvitems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["WindowCode"] = txtwindowCode.Text;
            drnew["Thickness"] = txtThickness.Text;
            drnew["Description"] = txtDescription.Text;
            drnew["Width"] = txtWidth.Text;
            drnew["Height"] = txtHeight.Text;
            drnew["Quantity"] = txtQuantity.Text;
            drnew["Unit"] = txtUnit.Text;
            drnew["Area"] = txtArea.Text;
            drnew["Weight"] = txtWeight.Text;
            drnew["Rate"] = txtitemrate.Text;
            drnew["Amount"] = txtitemamount.Text;

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
        col = new DataColumn("WindowCode");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Thickness");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Width");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Height");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Quantity");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Unit");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Area");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Weight");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Rate");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Amount");
        SalesOrderItems.Columns.Add(col);

        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["WindowCode"] = gvrow.Cells[2].Text;
                    dr["Thickness"] = gvrow.Cells[3].Text;
                    dr["Description"] = gvrow.Cells[4].Text;
                    dr["Width"] = gvrow.Cells[5].Text;
                    dr["Height"] = gvrow.Cells[6].Text;
                    dr["Unit"] = gvrow.Cells[7].Text;
                    dr["Area"] = gvrow.Cells[8].Text;
                    dr["Weight"] = gvrow.Cells[9].Text;
                    dr["Quantity"] = gvrow.Cells[10].Text;
                    dr["Rate"] = gvrow.Cells[11].Text;
                    dr["Amount"] = gvrow.Cells[12].Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
    }


    protected void gvitems_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[0].Visible = false;
            //e.Row.Cells[9].Visible = false;
            //e.Row.Cells[10].Visible = false;
        }

        GridViewRow row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.Cells[1].Attributes.Add("onclick", "return confirm('Are you sure you want to remove this Item from Interested Products list?');");

        }



        if (e.Row.RowType == DataControlRowType.Footer)
        {
            txtsubtotal.Text = txttotal.Text = NetAmountCalc().ToString();
        }


    }




    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            SCM.SupplierGlassQuotation objSMSOApprove = new SCM.SupplierGlassQuotation();
            objSMSOApprove.QuotId = Request.QueryString["Cid"].ToString();
            objSMSOApprove.Approvedby = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSMSOApprove.SupplierGlassQuotationApprove_Update();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Response.Redirect("~/Modules/Purchases/SupplierGlassQuatation.aspx");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            PurQuotationSave();
        }
        else if (btnSave.Text == "Update")
        {
            PurQuotationUpdate();
        }
    }

    private void PurQuotationUpdate()
    {
        try
        {
            SCM.SupplierGlassQuotation objSM = new SCM.SupplierGlassQuotation();
            objSM.QuotId = Request.QueryString["Cid"].ToString();
            objSM.QuotNo = txtquatationno.Text;
            objSM.QuotDate = General.toMMDDYYYY(txtquotationdate.Text);
            objSM.SupId = ddlSupplier.SelectedItem.Value;
            objSM.SoId = ddlMaterialrequest.SelectedItem.Value;

            objSM.PaymentTermsId = HttpUtility.HtmlEncode(txtpaymenttermsdetails.Text);
            objSM.TermsCondtionId = HttpUtility.HtmlEncode(txttermsconditions.Text);
            objSM.Discount = txtdiscount.Text;
            objSM.Tax = txttax.Text;
            objSM.GrandTotal = txttotal.Text;
            objSM.Preparedby = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;

            //  objSM.Status = "New";



            if (objSM.SupplierGlassQuotation_Update() == "Data Updated Successfully")
            {
                objSM.SupplierGlassQuotationDetails_Delete(objSM.QuotId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.WindowCode = gvrow.Cells[2].Text;
                    objSM.Thickness = gvrow.Cells[3].Text;
                    objSM.Description = gvrow.Cells[4].Text;
                    objSM.Width = gvrow.Cells[5].Text;
                    objSM.Height = gvrow.Cells[6].Text;
                    objSM.Unit = gvrow.Cells[7].Text;
                    objSM.Area = gvrow.Cells[8].Text;
                    objSM.Weight = gvrow.Cells[9].Text;
                    TextBox qty = (TextBox)gvrow.FindControl("txtitemqty");
                    objSM.ReqQty = qty.Text;
                    TextBox Amount = (TextBox)gvrow.FindControl("txtitemamount");
                    objSM.Rate = Amount.Text;
                    Label totalamount = (Label)gvrow.FindControl("lblAmount");
                    objSM.Amount = totalamount.Text;
                    objSM.SupplierGlassQuotationDetails_Save();
                }

                MessageBox.Show(this, "Data Saved Successfully");
            }
            else
            {
                MessageBox.Show(this, "Some Data Missing");
            }
        }
        catch (Exception ex)
        {

            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            SCM.ClearControls(this);
            SCM.Dispose();
            Response.Redirect("~/Modules/Purchases/SupplierGlassQuatation.aspx");
        }
    }

    private void PurQuotationSave()
    {
        try
        {
            SCM.SupplierGlassQuotation objSM = new SCM.SupplierGlassQuotation();
            objSM.QuotNo = txtquatationno.Text;
            objSM.QuotDate = General.toMMDDYYYY(txtquotationdate.Text);
            objSM.SupId = ddlSupplier.SelectedItem.Value;
            objSM.SoId = ddlMaterialrequest.SelectedItem.Value;

            objSM.PaymentTermsId = HttpUtility.HtmlEncode(txtpaymenttermsdetails.Text);
            objSM.TermsCondtionId = HttpUtility.HtmlEncode(txttermsconditions.Text);
            objSM.Discount = txtdiscount.Text;
            objSM.Tax = txttax.Text;
            objSM.GrandTotal = txttotal.Text;
            objSM.Preparedby = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;

            objSM.Status = "New";



            if (objSM.SupplierGlassQuotation_Save() == "Data Saved Successfully")
            {
                objSM.SupplierGlassQuotationDetails_Delete(objSM.QuotId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.WindowCode = gvrow.Cells[2].Text;
                    objSM.Thickness = gvrow.Cells[3].Text;
                    objSM.Description = gvrow.Cells[4].Text;
                    objSM.Width = gvrow.Cells[5].Text;
                    objSM.Height = gvrow.Cells[6].Text;
                    objSM.Unit = gvrow.Cells[7].Text;
                    objSM.Area = gvrow.Cells[8].Text;
                    objSM.Weight = gvrow.Cells[9].Text;
                    TextBox qty = (TextBox)gvrow.FindControl("txtitemqty");
                    objSM.ReqQty = qty.Text;
                    TextBox Amount = (TextBox)gvrow.FindControl("txtitemamount");
                    objSM.Rate = Amount.Text;
                    Label totalamount = (Label)gvrow.FindControl("lblAmount");
                    objSM.Amount = totalamount.Text;
                    objSM.SupplierGlassQuotationDetails_Save();
                }

                MessageBox.Show(this, "Data Saved Successfully");
            }
            else
            {
                MessageBox.Show(this, "Some Data Missing");
            }
        }
        catch (Exception ex)
        {

            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            SCM.ClearControls(this);
            SCM.Dispose();
            Response.Redirect("~/Modules/Purchases/SupplierGlassQuatation.aspx");
        }
    }
    protected void gvEnqItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[6].Visible = false;
            //e.Row.Cells[7].Visible = false;
            //e.Row.Cells[8].Visible = false;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
}