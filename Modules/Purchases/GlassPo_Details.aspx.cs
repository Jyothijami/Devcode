using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Purchases_GlassPo_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        txttax.Attributes.Add("onkeyup", "javascript:grosscalc();");
        txtdiscount.Attributes.Add("onkeyup", "javascript:grosscalc();");

        txtInsurance.Attributes.Add("onkeyup", "javascript:grosscalc();");
        txtfreight.Attributes.Add("onkeyup", "javascript:grosscalc();");
        txttransportcharges.Attributes.Add("onkeyup", "javascript:grosscalc();");
        txtpackingcharges.Attributes.Add("onkeyup", "javascript:grosscalc();");

        string Qid = Request.QueryString["Cid"].ToString();

        if (!IsPostBack)
        {
            gvitems.DataBind();


            SCM.SuppliersMaster.SuppliersMaster_Select(ddlSupplier);

            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            SCM.SupplierGlassQuotation.GlassQuotation_Select(ddlMaterialrequest);
            SCM.SupPo.SupPo1_Select(ddlponos);


            txtdiscount.Text = txttax.Text = txttotal.Text = txtsubtotal.Text = txtInsurance.Text = txtfreight.Text = txttransportcharges.Text = txtpackingcharges.Text = "0";
           
            txtPONo.Text = SCM.GlassPo.GlassPo_AutoGenCode();
            txtPOdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            ddlpreparedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            txtWriteFreight.Text = "Other :";
            txtWriteinsurance.Text = "Shipping & Handling :";
            txtindentno.Text = "";
            SM.SalesOrder.SalesOrder_SelectNA(ddlreqfor);
            SM.SalesOrder.SalesOrder_SelectNAp(ddlcustrefno);


            if (Qid != "Add")
            {
               
                btnSave.Text = "Update";
                btnApprove.Visible = true;
                btnPrint.Visible = false;
                QuatationFill();
                


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
        SCM.GlassPo obj = new SCM.GlassPo();
        if (obj.GlassPo_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            txtPONo.Text = obj.PONo;
            txtPOdate.Text = obj.PoDate;
            ddlSupplier.SelectedValue = obj.SupId;
            ddlSupplier_SelectedIndexChanged(new object(), new System.EventArgs());

            ddlMaterialrequest.SelectedValue = obj.QuatId;
            ddlMaterialrequest_SelectedIndexChanged(new object(), new System.EventArgs());

            txttermsconditions.Text = HttpUtility.HtmlDecode(obj.TermsCondtionId);
            txtpaymenttermsdetails.Text = HttpUtility.HtmlDecode(obj.PaymentTermsId);

            txtdiscount.Text = obj.Discount;
            txttax.Text = obj.Tax;
            txttotal.Text = obj.GrandTotal;
            ddlpreparedby.SelectedValue = obj.Preparedby;
            ddlapprovedby.SelectedValue = obj.Approvedby;
            obj.GlassPoOrder_Select(Request.QueryString["Cid"].ToString(), gvitems);

            txtdiscount.Text = obj.Discount;
            txttax.Text = obj.Tax;
            txtfreight.Text = obj.frieght;
            txttransportcharges.Text = obj.transport;
            txtInsurance.Text = obj.Insurance;
            txtpackingcharges.Text = obj.Packing;
         
            txttotal.Text = obj.GrandTotal;
          
            txtWriteFreight.Text = obj.WriteFreight;
            txtWriteinsurance.Text = obj.Writeinsurance;
            txtindentno.Text = obj.Indentnos;
            ddlcustrefno.SelectedItem.Text = obj.CustomerNo;



            txtmessage.Text = obj.Message;

            txtglasstype.Text = obj.Glasstype;
            txtsuppono.Text = obj.SupPoNo;
            ddlponos.SelectedItem.Text = obj.AlumilPoNO;
            txtdeliveryto.Text = obj.Deliverto;
            txtestimatedDeliverydate.Text = obj.Expteddelvierydate;
            




            if(obj.Approvedby != "0")
            {
                btnApprove.Visible = false;
                btnSave.Visible = false;
            }




        }
    }

    protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.SuppliersMaster obj = new SCM.SuppliersMaster();

        if (obj.SuppliersMaster_Select(ddlSupplier.SelectedItem.Value) > 0)
        {
            txtsupaddress.Text = HttpUtility.HtmlDecode(obj.SupAddress);
           // txtSupCurrency.Text = obj.Currency;
            txtSupContactMobileNo.Text = obj.SupMobile;
            txtSupContactperson.Text = obj.SupContactPerson;
        }
    }

    protected void ddlMaterialrequest_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.SupplierGlassQuotation obj = new SCM.SupplierGlassQuotation();

        if (obj.SupplierGlassQuotation_Select(ddlMaterialrequest.SelectedItem.Value) > 0)
        {

            ddlSupplier.SelectedValue = obj.SupId;
            ddlSupplier_SelectedIndexChanged(sender, e);
            txttermsconditions.Text = HttpUtility.HtmlDecode(obj.TermsCondtionId);
            txtpaymenttermsdetails.Text = HttpUtility.HtmlDecode(obj.PaymentTermsId);
            obj.GlassQuotatation_Select(ddlMaterialrequest.SelectedItem.Value, gvEnqItems);
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

        dt.Columns.Add("RequiredDate");

        dt.Columns.Add("Requiredfor");



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
            dt.Rows[dt.Rows.Count - 1]["Rate"] = gvRow.Cells[10].Text;
            dt.Rows[dt.Rows.Count - 1]["Amount"] = gvRow.Cells[11].Text;
            dt.Rows[dt.Rows.Count - 1]["RequiredDate"] = "";

            dt.Rows[dt.Rows.Count - 1]["Requiredfor"] = "";


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
        col = new DataColumn("RequiredDate");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Requiredfor");
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
                        dr["Amount"] = txtitmamount.Text; 
                        dr["RequiredDate"] = txtitemreqdate.Text;

                        if (ddlreqfor.SelectedItem.Text != "NA")
                        {
                            //dr["SoId"] = ddlreqfor.SelectedItem.Value;
                            dr["Requestfor"] = ddlreqfor.SelectedItem.Text;
                        }
                        else
                        {
                            //dr["SoId"] = ddlcustrefno.SelectedItem.Value;
                            dr["Requestfor"] = ddlcustrefno.SelectedItem.Text;
                        }


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
                        dr["RequiredDate"] = gvrow.Cells[13].Text;

                        dr["Requiredfor"] = gvrow.Cells[14].Text;

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
                    dr["RequiredDate"] = gvrow.Cells[13].Text;
                    dr["Requiredfor"] = gvrow.Cells[14].Text;
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
            drnew["Amount"] = txtitmamount.Text; 
            drnew["RequiredDate"] = txtitemreqdate.Text;

            if (ddlreqfor.SelectedItem.Text != "NA")
            {
                //drnew["SoId"] = ddlreqfor.SelectedItem.Value;
                drnew["Requiredfor"] = ddlreqfor.SelectedItem.Text;
            }
            else
            {
                //drnew["SoId"] = ddlcustrefno.SelectedItem.Value;
                drnew["Requiredfor"] = ddlcustrefno.SelectedItem.Text;
            }

            SalesOrderItems.Rows.Add(drnew);
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
        gvitems.SelectedIndex = -1;
        clearall();
    }

    private void clearall()
    {
        txtwindowCode.Text = "";
        txtThickness.Text = "";
        txtDescription.Text = "";
        txtWidth.Text = "";
        txtHeight.Text = "";
        txtQuantity.Text = "";
        txtUnit.Text = "";
        txtArea.Text = "";
        txtWeight.Text = "";
        txtitemrate.Text = "";
        txtitmamount.Text = "";
        txtitemreqdate.Text = "";
        ddlreqfor.SelectedIndex = -1;
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

        col = new DataColumn("RequiredDate");
        SalesOrderItems.Columns.Add(col);


        col = new DataColumn("Requiredfor");
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
                    dr["RequiredDate"] = gvrow.Cells[13].Text;

                    dr["Requiredfor"] = gvrow.Cells[14].Text;

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
            SCM.GlassPo objSMSOApprove = new SCM.GlassPo();
            objSMSOApprove.PoId = Request.QueryString["Cid"].ToString();
            objSMSOApprove.Approvedby = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSMSOApprove.GlassPoApprove_Update();

            if (ddlMaterialrequest.SelectedItem.Value != "0")
            {
                objSMSOApprove.QuatId = ddlMaterialrequest.SelectedItem.Value;
                objSMSOApprove.GlassPoQuatationApprove_Update();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Response.Redirect("~/Modules/Purchases/GlassPo.aspx");
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
            SCM.GlassPo objSM = new SCM.GlassPo();
            objSM.PoId = Request.QueryString["Cid"].ToString();
            objSM.PONo = txtPONo.Text;
            objSM.PoDate = General.toMMDDYYYY(txtPOdate.Text);
            objSM.SupId = ddlSupplier.SelectedItem.Value;
            objSM.QuatId = ddlMaterialrequest.SelectedItem.Value;

            objSM.PaymentTermsId = HttpUtility.HtmlEncode(txtpaymenttermsdetails.Text);
            objSM.TermsCondtionId = HttpUtility.HtmlEncode(txttermsconditions.Text);
            objSM.Discount = txtdiscount.Text;
            objSM.Tax = txttax.Text;
            objSM.GrandTotal = txttotal.Text;
            objSM.Preparedby = ddlpreparedby.SelectedItem.Value;
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;


            objSM.frieght = txtfreight.Text;
            objSM.transport = txttransportcharges.Text;
            objSM.Insurance = txtInsurance.Text;
            objSM.Packing = txtpackingcharges.Text;

            objSM.WriteFreight = txtWriteFreight.Text;
            objSM.Writeinsurance = txtWriteinsurance.Text;
            objSM.Indentnos = ddlponos.SelectedItem.Text;

            objSM.CustomerNo = ddlcustrefno.SelectedItem.Text;
            objSM.Message = HttpUtility.HtmlEncode(txtmessage.Text);



            objSM.Status = "Updated";

            objSM.Glasstype = txtglasstype.Text;
            objSM.SupPoNo = txtsuppono.Text;
            objSM.AlumilPoNO = ddlponos.SelectedItem.Text;
            objSM.Deliverto = txtdeliveryto.Text;
            objSM.Expteddelvierydate = txtestimatedDeliverydate.Text;
            objSM.Deliverydate = "";



            if (objSM.GlassPo_Update() == "Data Updated Successfully")
            {
                objSM.GlassPoDetails_Delete(objSM.PoId);
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
                    TextBox reqdate = (TextBox)gvrow.FindControl("txtitemrequireddate");
                    objSM.reqdate = General.toMMDDYYYY(reqdate.Text);
                    Label totalamount = (Label)gvrow.FindControl("lblAmount");
                    objSM.Amount = totalamount.Text;

                    objSM.ReceivedQty = "0";
                    objSM.RemainingQty = qty.Text;
                    objSM.stock = "0";
                    objSM.ItemStatus = "Pending";
                    objSM.RequiredFor = gvrow.Cells[14].Text;
                    objSM.SOid = ddlcustrefno.SelectedItem.Value;
                    objSM.GlassPoDetails_Save();
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
            Response.Redirect("~/Modules/Purchases/GlassPo.aspx");
        }
    }

    private void PurQuotationSave()
    {


        if (ddlcustrefno.SelectedItem.Value != "0")
        {

        



        try
        {
            SCM.GlassPo objSM = new SCM.GlassPo();
            objSM.PONo = txtPONo.Text;
            objSM.PoDate = General.toMMDDYYYY(txtPOdate.Text);
            objSM.SupId = ddlSupplier.SelectedItem.Value;
            objSM.QuatId = ddlMaterialrequest.SelectedItem.Value;

            objSM.PaymentTermsId = HttpUtility.HtmlEncode(txtpaymenttermsdetails.Text);
            objSM.TermsCondtionId = HttpUtility.HtmlEncode(txttermsconditions.Text);
            objSM.Discount = txtdiscount.Text;
            objSM.Tax = txttax.Text;
            objSM.GrandTotal = txttotal.Text;
            objSM.Preparedby = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;

            objSM.Status = "New";
            objSM.frieght = txtfreight.Text;
            objSM.transport = txttransportcharges.Text;
            objSM.Insurance = txtInsurance.Text;
            objSM.Packing = txtpackingcharges.Text;

            objSM.WriteFreight = txtWriteFreight.Text;
            objSM.Writeinsurance = txtWriteinsurance.Text;
            objSM.Indentnos = ddlponos.SelectedItem.Text;
            objSM.Message = HttpUtility.HtmlEncode(txtmessage.Text);
            objSM.CustomerNo = ddlcustrefno.SelectedItem.Text;


            objSM.Glasstype = txtglasstype.Text;
            objSM.SupPoNo = txtsuppono.Text;
            objSM.AlumilPoNO = ddlponos.SelectedItem.Text;
            objSM.Deliverto = txtdeliveryto.Text;
            objSM.Expteddelvierydate = txtestimatedDeliverydate.Text;
            objSM.Deliverydate = "";


            if (objSM.GlassPo_Save() == "Data Saved Successfully")
            {
                objSM.GlassPoDetails_Delete(objSM.PoId);




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
                    TextBox reqdate = (TextBox)gvrow.FindControl("txtitemrequireddate");
                    objSM.reqdate = General.toMMDDYYYY(reqdate.Text);
                    Label totalamount = (Label)gvrow.FindControl("lblAmount");
                    objSM.Amount = totalamount.Text;

                    objSM.ReceivedQty = "0";
                    objSM.RemainingQty = qty.Text;
                    objSM.stock = "0";
                    objSM.ItemStatus = "Pending";
                    objSM.RequiredFor = gvrow.Cells[14].Text;
                    objSM.SOid = ddlcustrefno.SelectedItem.Value;
                    objSM.GlassPoDetails_Save();
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
            Response.Redirect("~/Modules/Purchases/GlassPo.aspx");
        }
        }
        else
        {
            MessageBox.Show(this, "Please Select Customer Code");
        }
    }
    protected void gvEnqItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
        }
    }

    protected void btnUploadExcel_Click(object sender, EventArgs e)
    {







        if (FileUpload.HasFile)
        {
            if (!Convert.IsDBNull(FileUpload.PostedFile) &
                    FileUpload.PostedFile.ContentLength > 0)
            {
                // SAVE THE SELECTED FILE IN THE ROOT DIRECTORY.
                FileUpload.SaveAs(Server.MapPath(".") + "\\" + "UploadDocs" + "\\" + FileUpload.FileName);

                // SET A CONNECTION WITH THE EXCEL FILE.
                OleDbConnection myExcelConn = new OleDbConnection
                    ("Provider=Microsoft.ACE.OLEDB.12.0; " +
                        "Data Source=" + Server.MapPath(".") + "\\" + "UploadDocs" + "\\" + FileUpload.FileName +
                        ";Extended Properties=Excel 12.0;");
                try
                {
                    myExcelConn.Open();

                    // GET DATA FROM EXCEL SHEET.
                    OleDbCommand objOleDB =
                        new OleDbCommand("SELECT *FROM [General$]", myExcelConn);

                    // READ THE DATA EXTRACTED FROM THE EXCEL FILE.
                    OleDbDataReader objBulkReader = null;
                    objBulkReader = objOleDB.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(objBulkReader);

                    //Create Tempory Table
                    DataTable dtTemp = new DataTable();

                    // Creating Header Row
                    dtTemp.Columns.Add("WindowCode");
                    dtTemp.Columns.Add("Thickness");
                    dtTemp.Columns.Add("Description");
                    dtTemp.Columns.Add("Width");
                    dtTemp.Columns.Add("Height");
                    dtTemp.Columns.Add("Unit");
                    dtTemp.Columns.Add("Area");
                    dtTemp.Columns.Add("Weight");
                    dtTemp.Columns.Add("Quantity");
                    dtTemp.Columns.Add("Rate");
                    dtTemp.Columns.Add("Amount");
                    dtTemp.Columns.Add("RequiredDate");
                    dtTemp.Columns.Add("Requiredfor");
                  

                    DataRow drAddItem;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        drAddItem = dtTemp.NewRow();
                        drAddItem[0] = dt.Rows[i]["Window Code"].ToString();
                        drAddItem[1] = dt.Rows[i]["Thickness (mm)"].ToString();
                        drAddItem[2] = dt.Rows[i]["Description"].ToString();
                        drAddItem[3] = dt.Rows[i]["Width (mm)"].ToString();
                        drAddItem[4] = dt.Rows[i]["Height (mm)"].ToString();
                        drAddItem[5] = dt.Rows[i]["Unit"].ToString();
                        drAddItem[6] = dt.Rows[i]["Area (m²)"].ToString();
                        drAddItem[7] = dt.Rows[i]["Weight (kg)"].ToString();
                        drAddItem[8] = dt.Rows[i]["Quantity"].ToString();
                        drAddItem[9] = dt.Rows[i]["Rate"].ToString();
                        drAddItem[10] = dt.Rows[i]["Amount"].ToString();
                        drAddItem[11] = txtPOdate.Text;
                        drAddItem[12] = ddlcustrefno.SelectedItem.Text;
                    
                        dtTemp.Rows.Add(drAddItem);
                    }

                    // FINALLY, BIND THE EXTRACTED DATA TO THE GRIDVIEW.
                    gvitems.DataSource = dtTemp;
                    gvitems.DataBind();

                  

                    MessageBox.Show(this, "DATA IMPORTED TO THE GRID, SUCCESSFULLY.");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(this, ex.ToString());
                }
                finally
                {
                    // CLEAR.
                    myExcelConn.Close(); myExcelConn = null;
                }
            }
        }
    }

















   
}