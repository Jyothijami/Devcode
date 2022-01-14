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
 
public partial class Modules_Stock_GlassRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {

            SM.SalesOrder.SalesOrder_Select(ddlPono);
            txtMrdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtMaterialreqestNo .Text = SCM.GlassRequest.GlassRequest_AutoGenCode();
            HR.EmployeeMaster.EmployeeMaster_Select(ddlrequestedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            ddlrequestedby .SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            //ddlapprovedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            if (Qid != "Add")
            {
                btnApprove.Visible = true;

                GlassRequestFill();
            }
            else
            {
                btnApprove.Visible = false;
            }
        }
    }
    private void GlassRequestFill()
    {
        SCM.GlassRequest objmaster = new SCM.GlassRequest();
        if (objmaster.GlassRequest_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtMaterialreqestNo.Text = objmaster.GlassRequest_No;
            txtMrdate.Text = objmaster.Required_Date;
            ddlrequesttype.SelectedValue = objmaster.Requested_Type;
            ddlrequestedby.SelectedValue = objmaster.Prepared_By;
            ddlPono.SelectedValue = objmaster.So_Id;
            ddlapprovedby.SelectedValue = objmaster.Approved_By;
            txtrequireddate.Text = objmaster.Req_date;

            ddlPono_SelectedIndexChanged (new object(),new System .EventArgs ());
            if (objmaster.Approved_By  != "0")
            {
                btnApprove.Visible = false;
                btnSave.Visible = false;

                string palash = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
                string chenna = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

                if (palash == "7" || chenna == "42")
                {
                    btnSave.Visible = true;
                }



            }
            objmaster.GlassRequestDetails_Select(Request.QueryString["Cid"].ToString(), GridView1 );

        }
    }
    protected void ddlPono_SelectedIndexChanged(object sender, EventArgs e)
    {


        SCM.GlassPo obj = new SCM.GlassPo();

        if (ddlPono.SelectedItem.Value != "0")
        {
            obj.SupPoOrderQtybysoStock_Select(ddlPono.SelectedItem.Value, GridView1);

        }


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[9].Visible = false;
        }
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

    private void po_Update()
    {
        try
        {
            SCM.GlassRequest objMaster = new SCM.GlassRequest();

            objMaster.GlassRequest_No = txtMaterialreqestNo.Text;
            objMaster.Required_Date = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.Request_Type = ddlrequesttype.SelectedItem.Value;
            objMaster.Req_date = General.toMMDDYYYY(txtrequireddate.Text);
            objMaster.Requested_for = ddlPono.SelectedItem.Text;
            objMaster.So_Id = ddlPono.SelectedItem.Value;
            objMaster.Status = "";
            objMaster.TermsCondition_Id = "0";
            objMaster.Prepared_By = ddlrequestedby.SelectedItem.Value;
            objMaster.Approved_By = ddlapprovedby.SelectedItem.Value;
            objMaster.GlassRequest_Id = Request.QueryString["Cid"].ToString();

            if (objMaster.GlassRequest_Update() == "Data Updated Successfully")
            {
                objMaster.GlassRequestDetails_Delete(Request.QueryString["Cid"].ToString());
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    TextBox recqty = (TextBox)gvrow.FindControl("txtRequestqty");
                    objMaster.Reqqty = recqty.Text;
                    if (objMaster.Reqqty != "0")
                    {
                        objMaster.Windowcode = gvrow.Cells[0].Text;
                        objMaster.Thickness = gvrow.Cells[1].Text;
                        objMaster.Description = gvrow.Cells[2].Text;

                        objMaster.width = gvrow.Cells[3].Text;
                        objMaster.height = gvrow.Cells[4].Text;
                        objMaster.unit = gvrow.Cells[5].Text;

                        objMaster.Area = gvrow.Cells[6].Text;
                        objMaster.weight = gvrow.Cells[7].Text;
                        objMaster.stock = gvrow.Cells[8].Text;
                        objMaster.Reqqty = recqty.Text;
                        objMaster.sodetid = gvrow.Cells[9].Text;
                        objMaster.GlassRequestDetails_Save();

                    }
                }
                MessageBox.Show(this, "Data Saved Successfully");

            }
        }
        catch (Exception ex)
        {

        }
    }

    private void po_Save()
    {
        try
        {
            SCM.GlassRequest objMaster = new SCM.GlassRequest();

            objMaster.GlassRequest_No = txtMaterialreqestNo.Text;
            objMaster.Required_Date = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.Request_Type = ddlrequesttype.SelectedItem.Value;
            objMaster.Req_date = General.toMMDDYYYY(txtrequireddate.Text);
            objMaster.Requested_for = ddlPono.SelectedItem.Text;
            objMaster.So_Id = ddlPono.SelectedItem.Value;
            objMaster.Status = "";
            objMaster.TermsCondition_Id = "0";
            objMaster.Prepared_By = ddlrequestedby.SelectedItem.Value;
            objMaster.Approved_By = ddlapprovedby.SelectedItem.Value;
            if (objMaster.GlassRequest_Save() == "Data Saved Successfully")
            {
                //objMaster.GlassRequestDetails_Delete(Request.QueryString["Cid"].ToString());
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    TextBox recqty = (TextBox)gvrow.FindControl("txtRequestqty");
                    objMaster.Reqqty = recqty.Text;
                    if (objMaster.Reqqty != "0")
                    {
                        objMaster.Windowcode = gvrow.Cells[0].Text;
                        objMaster.Thickness = gvrow.Cells[1].Text;
                        objMaster.Description = gvrow.Cells[2].Text;

                        objMaster.width = gvrow.Cells[3].Text;
                        objMaster.height = gvrow.Cells[4].Text;
                        objMaster.unit = gvrow.Cells[5].Text;

                        objMaster.Area = gvrow.Cells[6].Text;
                        objMaster.weight = gvrow.Cells[7].Text;
                        objMaster.stock = gvrow.Cells[8].Text;
                        objMaster.Reqqty = recqty.Text;
                        objMaster.sodetid = gvrow.Cells[9].Text;
                        objMaster.GlassRequestDetails_Save();

                    }
                }
                MessageBox.Show(this, "Data Saved Successfully");

            }


        }
        catch (Exception ex)
        {

        }
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            SCM.GlassRequest  objSMSOApprove = new SCM.GlassRequest ();
            objSMSOApprove.GlassRequest_Id  = Request.QueryString["Cid"].ToString();
            objSMSOApprove.Approved_By  = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSMSOApprove.GlassRequestApprove_Update();

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Response.Redirect("~/Modules/Stock/GlassRequestMast.aspx");
        }
    }

    //protected void CheckBox_CheckChanged(object sender, EventArgs e)
    //{
    //    GetData();
    //    SetData();
    //    BindSecondaryGrid();
    //}

    //private void BindSecondaryGrid()
    //{
    //    DataTable dt = (DataTable)ViewState["SelectedRecords"];
    //    gvItems.DataSource = dt;
    //    gvItems.DataBind();
    //}

    //private void GetData()
    //{
    //    DataTable dt;
    //    if (ViewState["SelectedRecords"] != null)
    //        dt = (DataTable)ViewState["SelectedRecords"];
    //    else
    //        dt = CreateDataTable();
    //    CheckBox chkAll = (CheckBox)GridView1.HeaderRow
    //                        .Cells[0].FindControl("chkAll");
    //    for (int i = 0; i < GridView1.Rows.Count; i++)
    //    {
    //        if (chkAll.Checked)
    //        {
    //            dt = AddRow(GridView1.Rows[i], dt);
    //        }
    //        else
    //        {
    //            CheckBox chk = (CheckBox)GridView1.Rows[i]
    //                            .Cells[0].FindControl("chk");
    //            if (chk.Checked)
    //            {
    //                dt = AddRow(GridView1.Rows[i], dt);
    //            }
    //            else
    //            {
    //                dt = RemoveRow(GridView1.Rows[i], dt);
    //            }
    //        }
    //    }
    //    ViewState["SelectedRecords"] = dt;
    //}

    //private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    //{
    //    // DataRow[] dr = dt.Select("SoMatId = '" + gvRow.Cells[14].Text + "'");

    //    DataRow[] dr = dt.Select("WindowCode = '" + gvRow.Cells[11].Text + "' and ColorId = '" + gvRow.Cells[12].Text + "'  ");
    //    if (dr.Length <= 0)
    //    {
    //        dt.Rows.Add();
    //        dt.Rows[dt.Rows.Count - 1]["ItemCode"] = gvRow.Cells[2].Text;
    //        dt.Rows[dt.Rows.Count - 1]["Series"] = gvRow.Cells[3].Text;
    //        dt.Rows[dt.Rows.Count - 1]["Length"] = gvRow.Cells[4].Text;
    //        dt.Rows[dt.Rows.Count - 1]["Uom"] = gvRow.Cells[5].Text;


    //        if (gvRow.Cells[6].Text == "&nbsp;" || gvRow.Cells[6].Text == " ")
    //        {
    //            dt.Rows[dt.Rows.Count - 1]["Color"] = "NA";
    //        }
    //        else
    //        {
    //            dt.Rows[dt.Rows.Count - 1]["Color"] = gvRow.Cells[6].Text;
    //        }


    //        dt.Rows[dt.Rows.Count - 1]["Qty"] = gvRow.Cells[9].Text;



    //        dt.Rows[dt.Rows.Count - 1]["ItemCodeId"] = gvRow.Cells[11].Text;
    //        dt.Rows[dt.Rows.Count - 1]["ColorId"] = gvRow.Cells[12].Text;
    //        dt.Rows[dt.Rows.Count - 1]["SoMatId"] = gvRow.Cells[14].Text;
    //        dt.Rows[dt.Rows.Count - 1]["Remarks"] = "";

    //        dt.AcceptChanges();
    //    }
    //    return dt;
    //}

    //private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    //{
    //    DataRow[] dr = dt.Select("ItemCodeId = '" + gvRow.Cells[11].Text + "' and ColorId = '" + gvRow.Cells[12].Text + "'  ");
    //    if (dr.Length > 0)
    //    {
    //        dt.Rows.Remove(dr[0]);
    //        dt.AcceptChanges();
    //    }
    //    return dt;
    //}

    //private void SetData()
    //{
    //    CheckBox chkAll = (CheckBox)GridView1.HeaderRow.Cells[0].FindControl("chkAll");
    //    chkAll.Checked = true;
    //    if (ViewState["SelectedRecords"] != null)
    //    {
    //        DataTable dt = (DataTable)ViewState["SelectedRecords"];
    //        for (int i = 0; i < GridView1.Rows.Count; i++)
    //        {
    //            CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chk");
    //            if (chk != null)
    //            {
    //                //  DataRow[] dr = dt.Select("SoMatId = '" + GridView1.Rows[i].Cells[14].Text + "'");
    //                DataRow[] dr = dt.Select("ItemCodeId = '" + GridView1.Rows[i].Cells[11].Text + "' and ColorId = '" + GridView1.Rows[i].Cells[12].Text + "'  ");
    //                chk.Checked = dr.Length > 0;
    //                if (!chk.Checked)
    //                {
    //                    chkAll.Checked = false;
    //                }
    //            }
    //        }
    //    }
    //}
    //private DataTable CreateDataTable()
    //{
    //    DataTable dt = new DataTable();
    //    dt.Columns.Add("WindowCode");
    //    dt.Columns.Add("Thickness");
    //    dt.Columns.Add("Description");
    //    dt.Columns.Add("Width");
    //    dt.Columns.Add("Height");
    //    dt.Columns.Add("Area");
    //    dt.Columns.Add("Weight");
    //    dt.Columns.Add("Stock");
    //    dt.Columns.Add("PoDetId");
    //    dt.Columns.Add("txtRequestqty");
    //    //dt.Columns.Add("ColorId");
    //    //dt.Columns.Add("SoMatId");
    //    //dt.Columns.Add("Remarks");
    //    //dt.Columns.Add("WarehouseId");
    //    dt.AcceptChanges();
    //    return dt;
    //}
}