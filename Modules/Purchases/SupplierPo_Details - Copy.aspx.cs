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

public partial class Modules_Purchases_SupplierPo_Details : System.Web.UI.Page
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
           // SCM.MaterialRequest.MaterialRequest_Select(ddlMaterialrequest);
            SCM.SupplierQuotation.SupplierQuotation_Select(ddlMaterialrequest);
            txtdiscount.Text = txttax.Text = txttotal.Text = txtsubtotal.Text = "0";
            txtPONo.Text = SCM.SupPo.SupPo_AutoGenCode();
            txtPOdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            Masters.MaterialMaster.MaterialMaster_Select(ddlItemCode);
            Masters.ColorMaster.Color_Select(ddlItemColor);
            ddlpreparedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            if (Qid != "Add")
            {
                btnSave.Visible = false;
                btnSave.Text = "Update";
                btnApprove.Visible = true;
                QuatationFill();
            }
            else
            {
                btnApprove.Visible = false;
            }
        }
    }

    private void QuatationFill()
    {
        SCM.SupPo obj = new SCM.SupPo();
        if (obj.SupPo_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            txtPONo.Text = obj.PONo;
            txtPOdate.Text = obj.PoDate;
            ddlSupplier.SelectedValue = obj.SupId;
            ddlSupplier_SelectedIndexChanged(new object(), new System.EventArgs());

            ddlMaterialrequest.SelectedValue = obj.MateriralReqId;
            ddlMaterialrequest_SelectedIndexChanged(new object(), new System.EventArgs());

            txttermsconditions.Text = HttpUtility.HtmlDecode(obj.TermsCondtionId);
            txtpaymenttermsdetails.Text = HttpUtility.HtmlDecode(obj.PaymentTermsId);
            obj.SupPoOrder_Select(Request.QueryString["Cid"].ToString(), gvitems);
            txtdiscount.Text = obj.Discount;
            txttax.Text = obj.Tax;
            
            txttotal.Text = "";
            txttotal.Text = obj.GrandTotal;
            ddlpreparedby.SelectedValue = obj.Preparedby;
            ddlapprovedby.SelectedValue = obj.Approvedby;
          

            if(obj.Approvedby == "0")
            {
                btnSave.Visible = true;
                btnApprove.Visible = true;
            }
            else
            {
               
                btnSave.Visible = false;
                btnApprove.Visible = false;
            }

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
        SCM.SupplierQuotation obj = new SCM.SupplierQuotation();

        if (obj.SupplierQuotation_Select(ddlMaterialrequest.SelectedItem.Value) > 0)
        {

            ddlSupplier.SelectedValue = obj.SupId;
            ddlSupplier_SelectedIndexChanged(sender, e);

            txttermsconditions.Text = HttpUtility.HtmlDecode(obj.TermsCondtionId);
            txtpaymenttermsdetails.Text = HttpUtility.HtmlDecode(obj.PaymentTermsId);

            obj.SupplierQuotOrder_Select(ddlMaterialrequest.SelectedItem.Value, gvEnqItems);
        }
    }

   

   
    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("CodeNo");
        dt.Columns.Add("Series");
        dt.Columns.Add("Color");
        dt.Columns.Add("Uom");
        dt.Columns.Add("Qty");
        dt.Columns.Add("Rate");
        dt.Columns.Add("Amount");
        dt.Columns.Add("ItemcodeId");
        dt.Columns.Add("ColorId");
        dt.Columns.Add("RequiredDate");

        dt.Columns.Add("SoId");
        dt.Columns.Add("SoMatId");
        dt.Columns.Add("Requestfor");



        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("ItemcodeId = '" + gvRow.Cells[8].Text + "' and ColorId = '" + gvRow.Cells[9].Text + "'  ");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["CodeNo"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["Series"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["Color"] = gvRow.Cells[3].Text;

            dt.Rows[dt.Rows.Count - 1]["Uom"] = gvRow.Cells[4].Text;

            dt.Rows[dt.Rows.Count - 1]["Qty"] = gvRow.Cells[5].Text;

            dt.Rows[dt.Rows.Count - 1]["Rate"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["Amount"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["ItemcodeId"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["ColorId"] = gvRow.Cells[9].Text;
            dt.Rows[dt.Rows.Count - 1]["RequiredDate"] = "";


            dt.Rows[dt.Rows.Count - 1]["SoId"] = gvRow.Cells[10].Text;
            dt.Rows[dt.Rows.Count - 1]["SoMatId"] = gvRow.Cells[11].Text;
            dt.Rows[dt.Rows.Count - 1]["Requestfor"] = gvRow.Cells[12].Text;


            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("ItemcodeId = '" + gvRow.Cells[8].Text + "' and ColorId = '" + gvRow.Cells[9].Text + "'  ");

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
                    DataRow[] dr = dt.Select("ItemCodeId = '" + gvEnqItems.Rows[i].Cells[8].Text + "' and ColorId = '" + gvEnqItems.Rows[i].Cells[9].Text + "'  ");
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
        col = new DataColumn("CodeNo");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Uom");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Rate");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Amount");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemcodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("RequiredDate");
        SalesOrderItems.Columns.Add(col);


        col = new DataColumn("SoId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoMatId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Requestfor");
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
                        dr["CodeNo"] = ddlItemCode.SelectedItem.Text;
                        dr["Series"] = txtitemSeries.Text;
                        dr["Color"] = ddlItemColor.SelectedItem.Text;
                        dr["Uom"] = txtUOm.Text;
                        dr["Qty"] = txtitemQuantity.Text;
                        dr["Rate"] = txtamount.Text;
                        // TextBox Itemamount = (TextBox)gvrow.FindControl("txtitemamount");
                        dr["Amount"] = (Convert.ToDecimal(txtitemQuantity.Text) * Convert.ToDecimal(txtamount.Text)).ToString();

                        dr["ItemcodeId"] = ddlItemCode.SelectedItem.Value;
                        dr["ColorId"] = ddlItemColor.SelectedItem.Value;
                        dr["RequiredDate"] = txtitemreqdate.Text;

                        dr["SoId"] = "0";
                        dr["SoMatId"] = "0";
                        dr["Requestfor"] = txtrequiredfor.Text;




                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["CodeNo"] = gvrow.Cells[2].Text;
                        dr["Series"] = gvrow.Cells[3].Text;
                        dr["Color"] = gvrow.Cells[4].Text;
                        dr["Uom"] = gvrow.Cells[5].Text;
                        dr["Qty"] = gvrow.Cells[6].Text;
                        dr["Rate"] = gvrow.Cells[7].Text;
                        dr["Amount"] = gvrow.Cells[8].Text;

                        dr["ItemcodeId"] = gvrow.Cells[9].Text;
                        dr["ColorId"] = gvrow.Cells[10].Text;
                        dr["RequiredDate"] = gvrow.Cells[11].Text;


                        dr["SoId"] = gvrow.Cells[12].Text;
                        dr["SoMatId"] = gvrow.Cells[13].Text;
                        dr["Requestfor"] = gvrow.Cells[14].Text;

                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["CodeNo"] = gvrow.Cells[2].Text;
                    dr["Series"] = gvrow.Cells[3].Text;
                    dr["Color"] = gvrow.Cells[4].Text;
                    dr["Uom"] = gvrow.Cells[5].Text;

                    // dr["Qty"] = gvrow.Cells[7].Text;
                    TextBox qty = (TextBox)gvrow.FindControl("txtitemqty");
                    dr["Qty"] = qty.Text;



                    TextBox Itemamount = (TextBox)gvrow.FindControl("txtitemamount");
                    dr["Rate"] = Itemamount.Text;

                    // dr["Amount"] = gvrow.Cells[10].Text;

                    Label amount = (Label)gvrow.FindControl("lblAmount");
                    dr["Amount"] = amount.Text;
                    dr["ItemcodeId"] = gvrow.Cells[9].Text;
                    dr["ColorId"] = gvrow.Cells[10].Text;
                    TextBox reqdate = (TextBox)gvrow.FindControl("txtitemrequireddate");
                    dr["RequiredDate"] = reqdate.Text;
                    dr["SoId"] = gvrow.Cells[12].Text;
                    dr["SoMatId"] = gvrow.Cells[13].Text;
                    dr["Requestfor"] = gvrow.Cells[14].Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }

        if (gvitems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();

            drnew["CodeNo"] = ddlItemCode.SelectedItem.Text;
            drnew["Series"] = txtitemSeries.Text;
            drnew["Color"] = ddlItemColor.SelectedItem.Text;
            drnew["Uom"] = txtUOm.Text;
            drnew["Qty"] = txtitemQuantity.Text;
            drnew["Rate"] = txtamount.Text;
            // TextBox Itemamount = (TextBox)gvrow.FindControl("txtitemamount");

            // Label Totalamount = (Label)gvrow.FindControl("lblAmount");
            drnew["Amount"] = (Convert.ToDecimal(txtitemQuantity.Text) * Convert.ToDecimal(txtamount.Text)).ToString();
            drnew["ItemcodeId"] = ddlItemCode.SelectedItem.Value;
            drnew["ColorId"] = ddlItemColor.SelectedItem.Value;
            drnew["RequiredDate"] = txtitemreqdate.Text;

            drnew["SoId"] = "0";
            drnew["SoMatId"] = "0";
            drnew["Requestfor"] = txtrequiredfor.Text;

            SalesOrderItems.Rows.Add(drnew);
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
        gvitems.SelectedIndex = -1;
        celarall();
    }

    private void celarall()
    {
        ddlItemCode.SelectedIndex = -1;
        ddlItemColor.SelectedIndex = -1;
        txtitemSeries.Text = "";
        txtUOm.Text = "";
        txtitemQuantity.Text = "";
        txtamount.Text = "";
        txtitemreqdate.Text = "";
        txtrequiredfor.Text = "";

    }


    protected void gvitems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvitems.Rows[e.RowIndex].Cells[1].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("CodeNo");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Uom");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Rate");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Amount");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemcodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("RequiredDate");
        SalesOrderItems.Columns.Add(col);


        col = new DataColumn("SoId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoMatId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Requestfor");
        SalesOrderItems.Columns.Add(col);


        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["CodeNo"] = gvrow.Cells[2].Text;
                    dr["Series"] = gvrow.Cells[3].Text;
                    dr["Color"] = gvrow.Cells[4].Text;
                    dr["Uom"] = gvrow.Cells[5].Text;
                    dr["Qty"] = gvrow.Cells[6].Text;
                    dr["Rate"] = gvrow.Cells[7].Text;
                    dr["Amount"] = gvrow.Cells[8].Text;

                    dr["ItemcodeId"] = gvrow.Cells[9].Text;
                    dr["ColorId"] = gvrow.Cells[10].Text;
                    dr["RequiredDate"] = gvrow.Cells[11].Text;

                    dr["SoId"] = gvrow.Cells[12].Text;
                    dr["SoMatId"] = gvrow.Cells[13].Text;
                    dr["Requestfor"] = gvrow.Cells[14].Text;
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
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
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
            SCM.SupPo objSMSOApprove = new SCM.SupPo();
            objSMSOApprove.PoId = Request.QueryString["Cid"].ToString();
            objSMSOApprove.Approvedby = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSMSOApprove.SupPoApprove_Update();

            //if (ddlMaterialrequest.SelectedItem.Value != "0")
            //{
            //    objSMSOApprove.MateriralReqId = ddlMaterialrequest.SelectedItem.Value;
            //    objSMSOApprove.SupPoQuatationApprove_Update();
            //}
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Response.Redirect("~/Modules/Purchases/SupPo.aspx");
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
            SCM.SupPo objSM = new SCM.SupPo();
            objSM.PoId = Request.QueryString["Cid"].ToString();
            objSM.PONo = txtPONo.Text;
            objSM.PoDate = General.toMMDDYYYY(txtPOdate.Text);
            objSM.SupId = ddlSupplier.SelectedItem.Value;
            objSM.MateriralReqId = ddlMaterialrequest.SelectedItem.Value;

            objSM.PaymentTermsId = HttpUtility.HtmlEncode(txtpaymenttermsdetails.Text);
            objSM.TermsCondtionId = HttpUtility.HtmlEncode(txttermsconditions.Text);
            objSM.Discount = txtdiscount.Text;
            objSM.Tax = txttax.Text;
            objSM.GrandTotal = txttotal.Text;
            objSM.Preparedby = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;

            objSM.Status = "Updated";



            if (objSM.SupPo_Update() == "Data Updated Successfully")
            {
                objSM.SupPoDetails_Delete(objSM.PoId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.CodeId = gvrow.Cells[9].Text;

                    objSM.Uom = gvrow.Cells[5].Text;
                    objSM.ColorId = gvrow.Cells[10].Text;



                    TextBox qty = (TextBox)gvrow.FindControl("txtitemqty");
                    objSM.Quantity = qty.Text;



                    objSM.Series = gvrow.Cells[3].Text;

                    TextBox Amount = (TextBox)gvrow.FindControl("txtitemamount");
                    objSM.Rate = Amount.Text;
                    TextBox reqdate = (TextBox)gvrow.FindControl("txtitemrequireddate");
                    objSM.reqdate = General.toMMDDYYYY(reqdate.Text);
                    Label totalamount = (Label)gvrow.FindControl("lblAmount");
                    objSM.Amount = totalamount.Text;

                    objSM.ReceivedQty = "0";
                    objSM.RemainingQty = qty.Text;
                    objSM.ItemStatus = "Pending";



                    objSM.SOid = gvrow.Cells[12].Text;
                    objSM.SoMatid = gvrow.Cells[13].Text;
                    objSM.RequiredFor = gvrow.Cells[14].Text;


                    objSM.SupPoDetails_Save();
                }

                MessageBox.Show(this, "Data Updated Successfully");
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
            Response.Redirect("~/Modules/Purchases/SupPo.aspx");
        }
    }

    private void PurQuotationSave()
    {
        try
        {
            SCM.SupPo objSM = new SCM.SupPo();
            objSM.PONo = txtPONo.Text;
            objSM.PoDate = General.toMMDDYYYY(txtPOdate.Text);
            objSM.SupId = ddlSupplier.SelectedItem.Value;
            objSM.MateriralReqId = ddlMaterialrequest.SelectedItem.Value;

            objSM.PaymentTermsId = HttpUtility.HtmlEncode(txtpaymenttermsdetails.Text);
            objSM.TermsCondtionId = HttpUtility.HtmlEncode(txttermsconditions.Text);
            objSM.Discount = txtdiscount.Text;
            objSM.Tax = txttax.Text;
            objSM.GrandTotal = txttotal.Text;
            objSM.Preparedby = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;

            objSM.Status = "New";



            if (objSM.SupPo_Save() == "Data Saved Successfully")
            {
                objSM.SupPoDetails_Delete(objSM.PoId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.CodeId = gvrow.Cells[9].Text;

                    objSM.Uom = gvrow.Cells[5].Text;
                    objSM.ColorId = gvrow.Cells[10].Text;



                    TextBox qty = (TextBox)gvrow.FindControl("txtitemqty");
                    objSM.Quantity = qty.Text;



                    objSM.Series = gvrow.Cells[3].Text;

                    TextBox Amount = (TextBox)gvrow.FindControl("txtitemamount");
                    objSM.Rate = Amount.Text;
                    TextBox reqdate = (TextBox)gvrow.FindControl("txtitemrequireddate");
                    objSM.reqdate = General.toMMDDYYYY(reqdate.Text);
                    Label totalamount = (Label)gvrow.FindControl("lblAmount");
                    objSM.Amount = totalamount.Text;

                    objSM.ReceivedQty = "0";
                    objSM.RemainingQty = qty.Text;
                    objSM.ItemStatus = "Pending";



                    objSM.SOid = gvrow.Cells[12].Text;
                    objSM.SoMatid = gvrow.Cells[13].Text;
                    objSM.RequiredFor = gvrow.Cells[14].Text;


                    objSM.SupPoDetails_Save();
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
            Response.Redirect("~/Modules/Purchases/SupPo.aspx");
        }
    }
    protected void gvEnqItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        
    }
    protected void ddlItemCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.MaterialMaster obj = new Masters.MaterialMaster();
        if (obj.MaterialType_Select(ddlItemCode.SelectedItem.Value) > 0)
        {
            txtitemSeries.Text = obj.Description;
            txtUOm.Text = obj.UomName;
        }
    }
}