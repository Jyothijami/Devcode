using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modules_Purchases_RequestGlassQuatations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            SCM.SuppliersMaster.SuppliersMaster_Select(ddlSupplier);

            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            SM.SalesOrder.SalesOrder_Select(ddlMaterialrequest);

            txtquatationno.Text = SCM.GlassRequestQuotation.GlassRequestQuotation_AutoGenCode();
            txtquotationdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (Qid != "Add")
            {
                QuatationFill();
                btnSave.Visible = false;
            }
            else
            {
                ddlpreparedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
                ddlapprovedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            }
        }
    }

    private void QuatationFill()
    {
        SCM.GlassRequestQuotation obj = new SCM.GlassRequestQuotation();
        if (obj.SupplierRequestQuotation_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtquatationno.Text = obj.GlassReqQuotNo;
            txtquotationdate.Text = obj.GlassReqQuotDate;

            if (obj.SoId != "0")
            {
                ddlMaterialrequest.SelectedValue = obj.SoId;
                ddlMaterialrequest_SelectedIndexChanged(new object(), new System.EventArgs());
            }
            else
            {
                ddlMaterialrequest.SelectedValue = obj.SoId;
            }

            txtRemarks.Text = HttpUtility.HtmlDecode(obj.Remarks);

            ddlpreparedby.SelectedValue = obj.Preparedby;
            ddlapprovedby.SelectedValue = obj.Approvedby;
            obj.SupplierRequestQuotOrder_Select(Request.QueryString["Cid"].ToString(), gvitems);
            obj.SupplierRequestSupplier_Select(Request.QueryString["Cid"].ToString(), GridView1);
        }
    }

    protected void btnadditem_Click(object sender, EventArgs e)
    {
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("VendorName");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ContactPerson");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("MobileNo");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Email");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("VendorId");
        SalesOrderItems.Columns.Add(col);

        if (GridView1.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                if (GridView1.SelectedIndex > -1)
                {
                    if (gvrow.RowIndex == GridView1.SelectedRow.RowIndex)
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["VendorName"] = ddlSupplier.SelectedItem.Text;
                        dr["ContactPerson"] = txtsupContactPerson.Text;
                        dr["MobileNo"] = txtSupMobileno.Text;
                        dr["Email"] = txtSupEmail.Text;
                        dr["VendorId"] = ddlSupplier.SelectedItem.Value;

                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["VendorName"] = gvrow.Cells[1].Text;
                        dr["ContactPerson"] = gvrow.Cells[2].Text;
                        dr["MobileNo"] = gvrow.Cells[3].Text;
                        dr["Email"] = gvrow.Cells[4].Text;
                        dr["VendorId"] = gvrow.Cells[5].Text;

                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["VendorName"] = gvrow.Cells[1].Text;
                    dr["ContactPerson"] = gvrow.Cells[2].Text;
                    dr["MobileNo"] = gvrow.Cells[3].Text;
                    dr["Email"] = gvrow.Cells[4].Text;
                    dr["VendorId"] = gvrow.Cells[5].Text;

                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }

        if (GridView1.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["VendorName"] = ddlSupplier.SelectedItem.Text;
            drnew["ContactPerson"] = txtsupContactPerson.Text;
            drnew["MobileNo"] = txtSupMobileno.Text;
            drnew["Email"] = txtSupEmail.Text;
            drnew["VendorId"] = ddlSupplier.SelectedItem.Value;

            SalesOrderItems.Rows.Add(drnew);
        }
        GridView1.DataSource = SalesOrderItems;
        GridView1.DataBind();
        GridView1.SelectedIndex = -1;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[5].Visible = false;
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = GridView1.Rows[e.RowIndex].Cells[1].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("VendorName");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ContactPerson");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("MobileNo");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Email");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("VendorId");
        SalesOrderItems.Columns.Add(col);

        if (GridView1.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["VendorName"] = gvrow.Cells[1].Text;
                    dr["ContactPerson"] = gvrow.Cells[2].Text;
                    dr["MobileNo"] = gvrow.Cells[3].Text;
                    dr["Email"] = gvrow.Cells[4].Text;
                    dr["VendorId"] = gvrow.Cells[5].Text;

                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        GridView1.DataSource = SalesOrderItems;
        GridView1.DataBind();
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

                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["WindowCode"] = gvrow.Cells[1].Text;
                        dr["Thickness"] = gvrow.Cells[2].Text;
                        dr["Description"] = gvrow.Cells[3].Text;
                        dr["Width"] = gvrow.Cells[4].Text;
                        dr["Height"] = gvrow.Cells[5].Text;
                        dr["Quantity"] = gvrow.Cells[6].Text;
                        dr["Unit"] = gvrow.Cells[7].Text;
                        dr["Area"] = gvrow.Cells[8].Text;
                        dr["Weight"] = gvrow.Cells[9].Text;
                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["WindowCode"] = gvrow.Cells[1].Text;
                    dr["Thickness"] = gvrow.Cells[2].Text;
                    dr["Description"] = gvrow.Cells[3].Text;
                    dr["Width"] = gvrow.Cells[4].Text;
                    dr["Height"] = gvrow.Cells[5].Text;
                    dr["Quantity"] = gvrow.Cells[6].Text;
                    dr["Unit"] = gvrow.Cells[7].Text;
                    dr["Area"] = gvrow.Cells[8].Text;
                    dr["Weight"] = gvrow.Cells[9].Text;

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

            SalesOrderItems.Rows.Add(drnew);
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
        gvitems.SelectedIndex = -1;
    }

    protected void ddlMaterialrequest_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesOrder obj = new SM.SalesOrder();

        if (obj.SalesOrder_Select(ddlMaterialrequest.SelectedItem.Value) > 0)
        {
            obj.SoGlassEnquriy_Select(ddlMaterialrequest.SelectedItem.Value, gvEnqItems);
        }
    }

    protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.SuppliersMaster obj = new SCM.SuppliersMaster();

        if (obj.SuppliersMaster_Select(ddlSupplier.SelectedItem.Value) > 0)
        {
            txtSupEmail.Text = obj.SupEmail;
            txtSupMobileno.Text = obj.SupMobile;
            txtsupContactPerson.Text = obj.SupContactPerson;
        }
    }

    protected void gvEnqItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[6].Visible = false;
        //    e.Row.Cells[7].Visible = false;
        //}
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

        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["WindowCode"] = gvrow.Cells[1].Text;
                    dr["Thickness"] = gvrow.Cells[2].Text;
                    dr["Description"] = gvrow.Cells[3].Text;
                    dr["Width"] = gvrow.Cells[4].Text;
                    dr["Height"] = gvrow.Cells[5].Text;
                    dr["Quantity"] = gvrow.Cells[6].Text;
                    dr["Unit"] = gvrow.Cells[7].Text;
                    dr["Area"] = gvrow.Cells[8].Text;
                    dr["Weight"] = gvrow.Cells[9].Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
    }

    protected void gvitems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[6].Visible = false;
        //    e.Row.Cells[7].Visible = false;
        //}
    }

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("WindowCode");
        dt.Columns.Add("Thickness");
        dt.Columns.Add("Description");
        dt.Columns.Add("Width");
        dt.Columns.Add("Height");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Unit");
        dt.Columns.Add("Area");
        dt.Columns.Add("Weight");

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
            dt.Rows[dt.Rows.Count - 1]["Quantity"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["Unit"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["Area"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["Weight"] = gvRow.Cells[9].Text;

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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            SalesQuotationSave();
        }
        else if (btnSave.Text == "Update")
        {
            SalesQuotationUpdate();
        }
    }

    private void SalesQuotationUpdate()
    {
        try
        {
            SCM.GlassRequestQuotation objSM = new SCM.GlassRequestQuotation();
            objSM.GlassReqQuotId = Request.QueryString["Cid"].ToString();
            objSM.GlassReqQuotNo = txtquatationno.Text;
            objSM.GlassReqQuotDate = General.toMMDDYYYY(txtquotationdate.Text);
            objSM.SoId = ddlMaterialrequest.SelectedItem.Value;
            objSM.Remarks = HttpUtility.HtmlEncode(txtRemarks.Text);
            objSM.Preparedby = ddlpreparedby.SelectedItem.Value;
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;
            objSM.Status = "New";
            if (objSM.GlassRequestQuotation_Update() == "Data Updated Successfully")
            {
                objSM.GlassRequestQuotationDetails_Delete(objSM.GlassReqQuotId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.GlassWindowcode = gvrow.Cells[1].Text;
                    objSM.GlassThickness = gvrow.Cells[2].Text;
                    objSM.GlassDescription = gvrow.Cells[3].Text;
                    objSM.GlassWidth = gvrow.Cells[4].Text;
                    objSM.Glassheight = gvrow.Cells[5].Text;
                    objSM.GlassQuantity = gvrow.Cells[6].Text;
                    objSM.GlassUnit = gvrow.Cells[7].Text;
                    objSM.GlassArea = gvrow.Cells[8].Text;
                    objSM.GlassWeight = gvrow.Cells[9].Text;
                    objSM.GlassRequestQuotationDetails_Save();
                }

                objSM.SupplierDetails_Delete(objSM.GlassReqQuotId);
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    objSM.SupId = gvrow.Cells[5].Text;
                    objSM.SupplierDetails_Save();
                }
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
            Response.Redirect("~/Modules/Purchases/RequestGlassQuatation.aspx");
        }
    }

    private void SalesQuotationSave()
    {
        try
        {
            SCM.GlassRequestQuotation objSM = new SCM.GlassRequestQuotation();
            objSM.GlassReqQuotNo = txtquatationno.Text;
            objSM.GlassReqQuotDate = General.toMMDDYYYY(txtquotationdate.Text);
            objSM.SoId = ddlMaterialrequest.SelectedItem.Value;
            objSM.Remarks = HttpUtility.HtmlEncode(txtRemarks.Text);
            objSM.Preparedby = ddlpreparedby.SelectedItem.Value;
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;
            objSM.Status = "New";

            if (objSM.GlassRequestQuotation_Save() == "Data Saved Successfully")
            {
                objSM.GlassRequestQuotationDetails_Delete(objSM.GlassReqQuotId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.GlassWindowcode = gvrow.Cells[1].Text;
                    objSM.GlassThickness = gvrow.Cells[2].Text;
                    objSM.GlassDescription = gvrow.Cells[3].Text;
                    objSM.GlassWidth = gvrow.Cells[4].Text;
                    objSM.Glassheight = gvrow.Cells[5].Text;
                    objSM.GlassQuantity = gvrow.Cells[6].Text;
                    objSM.GlassUnit = gvrow.Cells[7].Text;
                    objSM.GlassArea = gvrow.Cells[8].Text;
                    objSM.GlassWeight = gvrow.Cells[9].Text;
                    objSM.GlassRequestQuotationDetails_Save();
                }

                objSM.SupplierDetails_Delete(objSM.GlassReqQuotId);
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    objSM.SupId = gvrow.Cells[5].Text;
                    objSM.SupplierDetails_Save();
                }
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
            Response.Redirect("~/Modules/Purchases/RequestGlassQuatation.aspx");
        }
    }
}