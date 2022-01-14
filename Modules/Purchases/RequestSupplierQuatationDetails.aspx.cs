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

public partial class Modules_Purchases_RequestSupplierQuatationDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
           
            SCM.SuppliersMaster.SuppliersMaster_Select(ddlSupplier);

            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            SCM.IndentApproval.IndentApproval_Select(ddlMaterialrequest);

          
            txtquatationno.Text = SCM.SupplierRequestQuotation.SupplierRequestQuotation_AutoGenCode();
            txtquotationdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            Masters.MaterialMaster.MaterialMaster_Select(ddlItemCode);
            Masters.ColorMaster.Color_Select(ddlItemColor);

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
        SCM.SupplierRequestQuotation obj = new SCM.SupplierRequestQuotation();
        if (obj.SupplierRequestQuotation_Select(Request.QueryString["Cid"].ToString()) > 0)
        {

            btnSave.Text = "Update";
            txtquatationno.Text = obj.ReqQuotNo;
            txtquotationdate.Text = obj.ReqQuotDate;
           

            if(obj.MateriralReqId != "0")
            {
                ddlMaterialrequest.SelectedValue = obj.MateriralReqId;
                ddlMaterialrequest_SelectedIndexChanged(new object(), new System.EventArgs());
            }
            else
            {
                ddlMaterialrequest.SelectedValue = obj.MateriralReqId;
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
        col = new DataColumn("CodeNo");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("QtyOrder");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemcodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoMatId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("RequestedFor");
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
                        dr["QtyOrder"] = txtitemQuantity.Text;
                        dr["ItemcodeId"] = ddlItemCode.SelectedItem.Value;
                        dr["ColorId"] = ddlItemColor.SelectedItem.Value;
                        dr["SoId"] = "0";
                        dr["SoMatId"] = "0";
                        dr["RequestedFor"] = txtrequiredfor.Text;
                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["CodeNo"] = gvrow.Cells[1].Text;
                        dr["Series"] = gvrow.Cells[2].Text;
                        dr["Color"] = gvrow.Cells[3].Text;
                        dr["QtyOrder"] = gvrow.Cells[4].Text;
                        dr["ItemcodeId"] = gvrow.Cells[5].Text;
                        dr["ColorId"] = gvrow.Cells[6].Text;
                        dr["SoId"] = gvrow.Cells[7].Text; ;
                        dr["SoMatId"] = gvrow.Cells[8].Text; ;
                        dr["RequestedFor"] = gvrow.Cells[9].Text;
                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["CodeNo"] = gvrow.Cells[1].Text;
                    dr["Series"] = gvrow.Cells[2].Text;
                    dr["Color"] = gvrow.Cells[3].Text;
                    dr["QtyOrder"] = gvrow.Cells[4].Text;
                    dr["ItemcodeId"] = gvrow.Cells[5].Text;
                    dr["ColorId"] = gvrow.Cells[6].Text;
                    dr["SoId"] = gvrow.Cells[7].Text; ;
                    dr["SoMatId"] = gvrow.Cells[8].Text; ;
                    dr["RequestedFor"] = gvrow.Cells[9].Text; 
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
            drnew["QtyOrder"] = txtitemQuantity.Text;
            drnew["ItemcodeId"] = ddlItemCode.SelectedItem.Value;
            drnew["ColorId"] = ddlItemColor.SelectedItem.Value;
            drnew["SoId"] = "0";
            drnew["SoMatId"] = "0";
            drnew["RequestedFor"] = txtrequiredfor.Text;

            SalesOrderItems.Rows.Add(drnew);
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
        gvitems.SelectedIndex = -1;
        celartext();
    }

    private void celartext()
    {
        ddlItemCode.SelectedIndex = -1;
        ddlItemColor.SelectedIndex = -1;
        txtitemSeries.Text = "";
        txtitemQuantity.Text = "";
        txtUOm.Text = "";
        txtrequiredfor.Text = "";
    }
    protected void ddlMaterialrequest_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.IndentApproval obj = new SCM.IndentApproval();

        if (obj.IndentApproval_Select(ddlMaterialrequest.SelectedItem.Value) > 0)
        {
            obj.IndentApprovalDetails_Select(ddlMaterialrequest.SelectedItem.Value, gvEnqItems);
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
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
        }
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
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemcodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SoMatId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("RequestedFor");
        SalesOrderItems.Columns.Add(col);
        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["CodeNo"] = gvrow.Cells[1].Text;
                    dr["Series"] = gvrow.Cells[2].Text;
                    dr["Color"] = gvrow.Cells[3].Text;
                    dr["Qty"] = gvrow.Cells[4].Text;
                    dr["ItemcodeId"] = gvrow.Cells[5].Text;
                    dr["ColorId"] = gvrow.Cells[6].Text;
                    dr["SoId"] = gvrow.Cells[7].Text; ;
                    dr["SoMatId"] = gvrow.Cells[8].Text; ;
                    dr["RequestedFor"] = gvrow.Cells[9].Text; 
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
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[8].Visible = false;
            //e.Row.Cells[9].Visible = false;
        }
    }

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("CodeNo");
        dt.Columns.Add("Series");
        dt.Columns.Add("Color");

        dt.Columns.Add("QtyOrder");
        dt.Columns.Add("ItemcodeId");
        dt.Columns.Add("ColorId");

        dt.Columns.Add("SoId");
        dt.Columns.Add("SoMatId");
        dt.Columns.Add("RequestedFor");


        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        //DataRow[] dr = dt.Select("SoMatId = '" + gvRow.Cells[8].Text + "'");

        DataRow[] dr = dt.Select("ItemcodeId = '" + gvRow.Cells[5].Text + "' and ColorId = '" + gvRow.Cells[6].Text + "'  ");


        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["CodeNo"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["Series"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["Color"] = gvRow.Cells[4].Text;
            dt.Rows[dt.Rows.Count - 1]["QtyOrder"] = gvRow.Cells[11].Text;
            dt.Rows[dt.Rows.Count - 1]["ItemcodeId"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["ColorId"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["SoId"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["SoMatId"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["RequestedFor"] = gvRow.Cells[13].Text;



            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
       // DataRow[] dr = dt.Select("SoMatId = '" + gvRow.Cells[8].Text + "'");

        DataRow[] dr = dt.Select("ItemcodeId = '" + gvRow.Cells[5].Text + "' and ColorId = '" + gvRow.Cells[6].Text + "'  ");

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
                    //DataRow[] dr = dt.Select("SoMatId = '" + gvEnqItems.Rows[i].Cells[8].Text + "'");
                    DataRow[] dr = dt.Select("ItemcodeId = '" + gvEnqItems.Rows[i].Cells[5].Text + "' and ColorId = '" + gvEnqItems.Rows[i].Cells[6].Text + "'  ");

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
            SCM.SupplierRequestQuotation objSM = new SCM.SupplierRequestQuotation();
            objSM.ReqQuotId = Request.QueryString["Cid"].ToString();
            objSM.ReqQuotNo = txtquatationno.Text;
            objSM.ReqQuotDate = General.toMMDDYYYY(txtquotationdate.Text);
            objSM.MateriralReqId = ddlMaterialrequest.SelectedItem.Value;
            objSM.Remarks = HttpUtility.HtmlEncode(txtRemarks.Text);
            objSM.Preparedby = ddlpreparedby.SelectedItem.Value;
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;
            objSM.Status = "Status";
            if (objSM.SupplierRequestQuotation_Update() == "Data Updated Successfully")
            {
                objSM.SupplierRequestQuotationDetails_Delete(objSM.ReqQuotId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.CodeId = gvrow.Cells[5].Text;

                    objSM.ColorId = gvrow.Cells[6].Text;
                    objSM.Quantity = gvrow.Cells[4].Text;
                    objSM.reqestedfor = gvrow.Cells[9].Text;

                    objSM.soid = gvrow.Cells[7].Text;
                    objSM.somatid = gvrow.Cells[8].Text;
                    objSM.SupplierRequestQuotationDetails_Save();
                }

                objSM.SupplierDetails_Delete(objSM.ReqQuotId);
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
            Response.Redirect("~/Modules/Purchases/RequestSupplierQuatation.aspx");
        }
    }

    private void SalesQuotationSave()
    {
        try
        {
            SCM.SupplierRequestQuotation objSM = new SCM.SupplierRequestQuotation();
            objSM.ReqQuotNo = txtquatationno.Text;
            objSM.ReqQuotDate = General.toMMDDYYYY(txtquotationdate.Text);
            objSM.MateriralReqId = ddlMaterialrequest.SelectedItem.Value;
            objSM.Remarks = HttpUtility.HtmlEncode(txtRemarks.Text);
            objSM.Preparedby = ddlpreparedby.SelectedItem.Value;
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;
            objSM.Status = "New";



            if (objSM.SupplierRequestQuotation_Save() == "Data Saved Successfully")
            {
                objSM.SupplierRequestQuotationDetails_Delete(objSM.ReqQuotId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.CodeId = gvrow.Cells[5].Text;
                  
                    objSM.ColorId = gvrow.Cells[6].Text;
                    objSM.Quantity = gvrow.Cells[4].Text;
                    objSM.reqestedfor = gvrow.Cells[9].Text;

                    objSM.soid = gvrow.Cells[7].Text;
                    objSM.somatid = gvrow.Cells[8].Text;


                    objSM.SupplierRequestQuotationDetails_Save();
                }

                objSM.SupplierDetails_Delete(objSM.ReqQuotId);
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    objSM.SupId = gvrow.Cells[5].Text;
                    objSM.SupplierRequestQuotationDetails_Save();
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
            Response.Redirect("~/Modules/Purchases/RequestSupplierQuatation.aspx");
        }
    }
    protected void ddlItemCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.MaterialMaster obj = new Masters.MaterialMaster();
        if(obj.MaterialPO_Select(ddlItemCode.SelectedItem.Value) > 0)
        {
            txtitemSeries.Text = obj.Description;
            txtUOm.Text = obj.UomName;
           // Masters.MaterialMaster.ItemMaster_ModelNoSelect(ddlItemColor, ddlItemCode.SelectedItem.Value);
        }

    }
}