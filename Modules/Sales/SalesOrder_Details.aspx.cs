using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modules_Sales_SalesOrder_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            
            //Masters.PaymentTerms.Payment_Select(ddlpaymentterms);
            //Masters.SalesTermsConditions.SalesTermsConditions_Select(ddltermscondtions);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            SM.SalesQuotation.SalesQuotation_Select(ddlQuotationno);
            txtsalesorderno.Text = SM.SalesOrder.SalesOrder_AutoGenCode();
            txtSalesorderdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            SM.CustomerMaster.CustomerMasterQuatation_Select(ddlCustomer);
            SM.CustomerMaster.CustomerUnit_Select(ddlsite);
            txtDeliveryDate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtInstallationDate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            ddlQuotationno.Enabled = false;


            btnApprove.Visible = false;
            btnPrint.Visible = false;


            if(Qid != "Add")
            {
                FillOrder();
                btnApprove.Visible = true;
                btnPrint.Visible = true;
            }
            else
            {
                ddlpreparedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            }
           
        }
    }

    private void FillOrder()
    {
        SM.SalesOrder obj = new SM.SalesOrder();
        if(obj.SalesOrder_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtsalesorderno.Text = obj.SONO;
            txtSalesorderdate.Text = obj.SODATE;
            ddlCustomer.SelectedValue = obj.Custid;
            ddlCustomer_SelectedIndexChanged(new object(), new System.EventArgs());
            ddlsite.SelectedValue = obj.SiteId;
            ddlQuotationno.SelectedValue = obj.QUOID;
            ddlQuotationno_SelectedIndexChanged(new object(), new System.EventArgs());
            txtpaymenttermsdetails.Text = HttpUtility.HtmlDecode(obj.Purconditionsid);
            txttermsconditions.Text = HttpUtility.HtmlDecode(obj.termsId);
            ddlpreparedby.SelectedValue = obj.PREPAREDBY;
            ddlapprovedby.SelectedValue = obj.APPROVEDBY;
            ddlOrdertype.SelectedItem.Text = obj.OrderType;
            txtCustPurchaseOrder.Text = obj.CustPoNo;
            txtProjectCode.Text = obj.ProjectCode;

            txtDeliveryDate.Text = obj.Deliverydate;
            txtwindowcolor.Text = obj.Windowcolor;
            txthardwarecolor.Text = obj.sohardwarecolor;
            txttotalarea.Text = obj.sototalarea;
            txttotalqty.Text = obj.totalqty;
            txtInstallationDate.Text = obj.Installationdate;
            txtalumilsystem.Text = obj.AlumilSystem;


            ddlstatus.SelectedItem.Text = obj.Status;
            obj.SalesOrderDetailsNew_Select(Request.QueryString["Cid"].ToString(), gvitems);


        }
    }

    protected void gvitems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;

           
        }

        
    }

  

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("CodeNo");
        dt.Columns.Add("Series");
        dt.Columns.Add("Width");
        dt.Columns.Add("height");
        dt.Columns.Add("Qty");
        dt.Columns.Add("Glass");
        dt.Columns.Add("Mesh");
        dt.Columns.Add("ProfileColor");
        dt.Columns.Add("HardwareColor");
        dt.Columns.Add("TotalArea");
        dt.Columns.Add("TotalAmount");
        dt.Columns.Add("ItemDeliverydate");

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
            dt.Rows[dt.Rows.Count - 1]["Series"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["Width"] = gvRow.Cells[3].Text;
            dt.Rows[dt.Rows.Count - 1]["height"] = gvRow.Cells[4].Text;
            dt.Rows[dt.Rows.Count - 1]["Qty"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["Glass"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["Mesh"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["ProfileColor"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["HardwareColor"] = gvRow.Cells[9].Text;
            dt.Rows[dt.Rows.Count - 1]["TotalArea"] = gvRow.Cells[10].Text;
            dt.Rows[dt.Rows.Count - 1]["TotalAmount"] = gvRow.Cells[11].Text;

            DateTime dtval = DateTime.Parse(txtSalesorderdate.Text);
            //Add values here
            dt.Rows[dt.Rows.Count - 1]["ItemDeliverydate"] = dtval.AddDays(91).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

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
                    DataRow[] dr = dt.Select("CodeNo = '" + gvQuatationItems.Rows[i].Cells[1].Text + "'");
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


        if (btnSave.Text == "Save")
        {
            SalesOrderSave();
        }
        else if (btnSave.Text == "Update")
        {
            SalesOrderUpdate();
        }



       
    }

    private void SalesOrderUpdate()
    {
        try
        {
            SM.SalesOrder objSM = new SM.SalesOrder();
            objSM.SOID = Request.QueryString["Cid"].ToString();
            objSM.SONO = txtsalesorderno.Text;
            objSM.SODATE = General.toMMDDYYYY(txtSalesorderdate.Text);
            objSM.QUOID = ddlQuotationno.SelectedItem.Value;
            objSM.Deliverydate = General.toMMDDYYYY(txtDeliveryDate.Text);
            objSM.OrderType = ddlOrdertype.SelectedItem.Value;
            objSM.CustPoNo = txtCustPurchaseOrder.Text;
            objSM.Custid = ddlCustomer.SelectedItem.Value;
            objSM.SiteId = ddlsite.SelectedItem.Value;
            objSM.Purconditionsid = HttpUtility.HtmlEncode(txtpaymenttermsdetails.Text);
            objSM.termsId = HttpUtility.HtmlEncode(txttermsconditions.Text);
            objSM.PREPAREDBY = ddlpreparedby.SelectedItem.Value;
            objSM.APPROVEDBY = ddlapprovedby.SelectedItem.Value;
            //objSM.Status = "New";
            objSM.ProjectCode = txtProjectCode.Text;

            objSM.AlumilSystem = txtalumilsystem.Text;
            objSM.Windowcolor = txtwindowcolor.Text;
            objSM.sohardwarecolor = txthardwarecolor.Text;
            objSM.sototalarea = txttotalarea.Text;
            objSM.totalqty = txttotalqty.Text;
            objSM.Installationdate = General.toMMDDYYYY(txtInstallationDate.Text);






            objSM.Status = ddlstatus.SelectedItem.Value;



            if (objSM.SalesOrder_Update() == "Data Updated Successfully")
            {
                objSM.SalesOrderDetails_Delete(objSM.SOID);
                objSM.SalesOrderWindowOperation_Delete(objSM.SOID);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.Code = gvrow.Cells[2].Text;
                    objSM.Series = gvrow.Cells[3].Text;
                    objSM.Width = gvrow.Cells[4].Text;
                    objSM.Height = gvrow.Cells[5].Text;
                    objSM.Quantity = gvrow.Cells[6].Text;
                    objSM.Glass = gvrow.Cells[7].Text;
                    objSM.Flyscreen = gvrow.Cells[8].Text;
                    objSM.Profilecolor = gvrow.Cells[9].Text;
                    objSM.Hardwarecolor = gvrow.Cells[10].Text;
                    objSM.TotalArea = gvrow.Cells[11].Text;
                    objSM.totalamount = gvrow.Cells[12].Text;
                    TextBox Deliveryda = (TextBox)gvrow.FindControl("txtdeliveryDate");
                    objSM.itemdeliverydate = General.toMMDDYYYY(Deliveryda.Text);
                    objSM.Bomstatus = "No";
                    objSM.SalesOrderDetails_Save();
                }
                
            
               // MessageBox.Show(this, "Data Updated Successfully");
            }
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            SM.ClearControls(this);
            SM.Dispose();
           Response.Redirect("~/Modules/Sales/SalesOrder.aspx");

        }
    }

    private void SalesOrderSave()
    {
        try
        {
            SM.SalesOrder objSM = new SM.SalesOrder();
            objSM.SONO = txtsalesorderno.Text;
            objSM.SODATE = General.toMMDDYYYY(txtSalesorderdate.Text);
            objSM.QUOID = ddlQuotationno.SelectedItem.Value;
            objSM.Deliverydate = General.toMMDDYYYY(txtDeliveryDate.Text);
            objSM.OrderType = ddlOrdertype.SelectedItem.Value;
            objSM.CustPoNo = txtCustPurchaseOrder.Text;
            objSM.Custid = ddlCustomer.SelectedItem.Value;
            objSM.SiteId = ddlsite.SelectedItem.Value;
            objSM.Purconditionsid = HttpUtility.HtmlEncode(txtpaymenttermsdetails.Text);
            objSM.termsId = HttpUtility.HtmlEncode(txttermsconditions.Text);
            objSM.PREPAREDBY = ddlpreparedby.SelectedItem.Value;
            objSM.APPROVEDBY = ddlapprovedby.SelectedItem.Value;
            objSM.Status = ddlstatus.SelectedItem.Value;


            objSM.AlumilSystem = txtalumilsystem.Text;
            objSM.Windowcolor = txtwindowcolor.Text;
            objSM.sohardwarecolor = txthardwarecolor.Text;
            objSM.sototalarea = txttotalarea.Text;
            objSM.totalqty = txttotalqty.Text;
            objSM.Installationdate = General.toMMDDYYYY(txtInstallationDate.Text);

            objSM.ProjectCode = txtProjectCode.Text;


            if (objSM.SalesOrder_Save() == "Data Saved Successfully")
            {
                objSM.SalesOrderDetails_Delete(objSM.SOID);
                objSM.SalesOrderWindowOperation_Delete(objSM.SOID);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.Code = gvrow.Cells[2].Text;
                    objSM.Series = gvrow.Cells[3].Text;
                    objSM.Width = gvrow.Cells[4].Text;
                    objSM.Height = gvrow.Cells[5].Text;
                    objSM.Quantity = gvrow.Cells[6].Text;
                    objSM.Glass = gvrow.Cells[7].Text;
                    objSM.Flyscreen = gvrow.Cells[8].Text;
                    objSM.Profilecolor = gvrow.Cells[9].Text;
                    objSM.Hardwarecolor = gvrow.Cells[10].Text;
                    objSM.TotalArea = gvrow.Cells[11].Text;
                    objSM.totalamount = gvrow.Cells[12].Text;
                    TextBox Deliveryda = (TextBox)gvrow.FindControl("txtdeliveryDate");
                    objSM.itemdeliverydate = General.toMMDDYYYY(Deliveryda.Text);
                    objSM.Bomstatus = "No";
                    objSM.SalesOrderDetails_Save();

                }
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);

               // MessageBox.Show(this, "Data Saved Successfully");
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            SM.ClearControls(this);
            SM.Dispose();
          //  Response.Redirect("~/Modules/Sales/SalesOrder.aspx");
        }
    }

    protected void gvQuatation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }

  

    //protected void btnAddItems_Click(object sender, EventArgs e)
    //{
    //    DataTable SalesOrderItems = new DataTable();
    //    DataColumn col = new DataColumn();
    //    col = new DataColumn("CodeNo");
    //    SalesOrderItems.Columns.Add(col);
    //    col = new DataColumn("Width");
    //    SalesOrderItems.Columns.Add(col);
    //    col = new DataColumn("height");
    //    SalesOrderItems.Columns.Add(col);
    //    col = new DataColumn("SillHeight");
    //    SalesOrderItems.Columns.Add(col);
    //    col = new DataColumn("Series");
    //    SalesOrderItems.Columns.Add(col);

    //    col = new DataColumn("Qty");
    //    SalesOrderItems.Columns.Add(col);
    //    col = new DataColumn("Glass");
    //    SalesOrderItems.Columns.Add(col);
    //    col = new DataColumn("FlyScreen");
    //    SalesOrderItems.Columns.Add(col);
    //    col = new DataColumn("Amount");
    //    SalesOrderItems.Columns.Add(col);
    //    col = new DataColumn("TotalAmount");
    //    SalesOrderItems.Columns.Add(col);
    //    col = new DataColumn("Deliverydate");
    //    SalesOrderItems.Columns.Add(col);

    //    if (gvitems.Rows.Count > 0)
    //    {
    //        foreach (GridViewRow gvrow in gvitems.Rows)
    //        {
    //            if (gvitems.SelectedIndex > -1)
    //            {
    //                if (gvrow.RowIndex == gvitems.SelectedRow.RowIndex)
    //                {
    //                    DataRow dr = SalesOrderItems.NewRow();
    //                    dr["CodeNo"] = txtCode.Text;
    //                    dr["Width"] = txtwidth.Text; ;
    //                    dr["height"] = txtheight.Text;
    //                    dr["SillHeight"] = txtsillHeight.Text;
    //                    dr["Series"] = txtseries.Text;
    //                    dr["Qty"] = txtQuantity.Text;
    //                    dr["Glass"] = txtGlass.Text;
    //                    dr["FlyScreen"] = txtflyscreen.Text;

    //                    // TextBox Itemamount = (TextBox)gvrow.FindControl("txtitemamount");
    //                    dr["Amount"] = txtamount.Text;
    //                    dr["TotalAmount"] = "";
    //                    TextBox dedate = (TextBox)gvrow.FindControl("txtdeliveryDate");
    //                    dr["Deliverydate"] = dedate.Text;
    //                    SalesOrderItems.Rows.Add(dr);
    //                }
    //                else
    //                {
    //                    DataRow dr = SalesOrderItems.NewRow();
    //                    dr["CodeNo"] = gvrow.Cells[2].Text;
    //                    dr["Width"] = gvrow.Cells[3].Text;
    //                    dr["height"] = gvrow.Cells[4].Text;
    //                    dr["SillHeight"] = gvrow.Cells[5].Text;
    //                    dr["Series"] = gvrow.Cells[6].Text;
    //                    dr["Qty"] = gvrow.Cells[7].Text;
    //                    dr["Glass"] = gvrow.Cells[8].Text;
    //                    dr["FlyScreen"] = gvrow.Cells[9].Text;
    //                    dr["Amount"] = gvrow.Cells[10].Text;
    //                    dr["TotalAmount"] = gvrow.Cells[11].Text;
    //                    dr["Deliverydate"] = gvrow.Cells[12].Text;
    //                    SalesOrderItems.Rows.Add(dr);
    //                }
    //            }
    //            else
    //            {
    //                DataRow dr = SalesOrderItems.NewRow();
    //                dr["CodeNo"] = gvrow.Cells[2].Text;
    //                dr["Width"] = gvrow.Cells[3].Text;
    //                dr["height"] = gvrow.Cells[4].Text;
    //                dr["SillHeight"] = gvrow.Cells[5].Text;
    //                dr["Series"] = gvrow.Cells[6].Text;
    //                dr["Qty"] = gvrow.Cells[7].Text;
    //                //TextBox qty = (TextBox)gvrow.FindControl("txtitemqty");
    //                //  dr["Qty"] = txtQuantity.Text;

    //                dr["Glass"] = gvrow.Cells[8].Text;
    //                dr["FlyScreen"] = gvrow.Cells[9].Text;

    //                // TextBox Itemamount = (TextBox)gvrow.FindControl("txtitemamount");
    //                dr["Amount"] = gvrow.Cells[10].Text;

    //                // dr["Amount"] = gvrow.Cells[10].Text;

    //                //Label amount = (Label)gvrow.FindControl("lblAmount");
    //                dr["TotalAmount"] = gvrow.Cells[11].Text;

    //                TextBox dedate = (TextBox)gvrow.FindControl("txtdeliveryDate");
    //                dr["Deliverydate"] = dedate.Text;

    //                SalesOrderItems.Rows.Add(dr);
    //            }
    //        }
    //    }

    //    if (gvitems.SelectedIndex == -1)
    //    {
    //        DataRow drnew = SalesOrderItems.NewRow();
    //        drnew["CodeNo"] = txtCode.Text;
    //        drnew["Width"] = txtwidth.Text; ;
    //        drnew["height"] = txtheight.Text;
    //        drnew["SillHeight"] = txtsillHeight.Text;
    //        drnew["Series"] = txtseries.Text;
    //        drnew["Qty"] = txtQuantity.Text;
    //        drnew["Glass"] = txtGlass.Text;
    //        drnew["FlyScreen"] = txtflyscreen.Text;
    //        //TextBox Itemamount = (TextBox)gvitems.FindControl("txtitemamount");
    //        drnew["Amount"] = txtamount.Text;

    //        drnew["TotalAmount"] = (Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtamount.Text)).ToString();
    //        drnew["Deliverydate"] = txtitemDeliverydate.Text;
    //        SalesOrderItems.Rows.Add(drnew);
    //    }
    //    gvitems.DataSource = SalesOrderItems;
    //    gvitems.DataBind();
    //    gvitems.SelectedIndex = -1;
    //}

    //protected void ddlpaymentterms_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    Masters.PaymentTerms obj = new Masters.PaymentTerms();

    //    if (obj.Payment_Select(ddlpaymentterms.SelectedItem.Value) > 0)
    //    {
    //        txtpaymenttermsdetails.Text = HttpUtility.HtmlDecode(obj.Desc);
    //    }

    //}

    //protected void ddltermscondtions_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Masters.SalesTermsConditions obj = new Masters.SalesTermsConditions();

    //    if (obj.SalesTermsConditions_Select(ddltermscondtions.SelectedItem.Value) > 0)
    //    {
    //        txttermsconditions.Text = HttpUtility.HtmlDecode(obj.Desc);
    //    }
    //}

    protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.CustomerMaster obj = new SM.CustomerMaster();
        txtCustomerAddress.Text = "";
      
        txtContactperson.Text = "";
        txtContactMobileNo.Text ="";
        txtsiteaddress.Text = "";
        txtsiteContactperson.Text ="";
        txtsiteMobileno.Text = "";
        ddlQuotationno.Enabled = false;
        SM.SalesQuotation.SalesQuotation_Select(ddlQuotationno);
        gvQuatationItems.DataSource = null;
        gvQuatationItems.DataBind();

        gvitems.DataSource = null;
        gvitems.DataBind();


        if (obj.CustomerMaster_Select(ddlCustomer.SelectedItem.Value) > 0)
        {
            txtCustomerAddress.Text = obj.custaddress;
          
            txtContactperson.Text = obj.CustName;
            txtContactMobileNo.Text = obj.CustMobile;
            SM.CustomerMaster.CustomerUnit_Select(ddlsite, ddlCustomer.SelectedItem.Value);
           
        }
        //SM.SalesQuotation.CustSalesQuotation_Select(ddlQuotationno, ddlCustomer.SelectedItem.Value);
    }

    protected void ddlQuotationno_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesQuotation obj = new SM.SalesQuotation();

        if (obj.SalesQuotation_Select(ddlQuotationno.SelectedItem.Value) > 0)
        {
            txtquotationdate.Text = obj.QuotDate;
            //ddlsite.SelectedValue = obj.UnitId;
            //ddlsite_SelectedIndexChanged(sender, e);

            obj.SalesQuotationDetails_Select(ddlQuotationno.SelectedItem.Value, gvQuatationItems);
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
        ddlQuotationno.Enabled = true;

        gvitems.DataSource = null;
        gvitems.DataBind();

        SM.SalesQuotation.CustUnitSalesQuotation_Select(ddlQuotationno, ddlsite.SelectedItem.Value);
    }

   
}