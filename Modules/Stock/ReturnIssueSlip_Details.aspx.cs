using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_ReturnIssueSlip_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {

            txtRgpreturnNo.Text = SCM.ReturnIssueSlip.ReturnIssueSlip_AutoGenCode();
            txtRgpreturnDate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlPreparedBy);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlReceivedby);
            SCM.MaterialIssue.MaterialIssue_Select(ddlRgpno);
            ddlPreparedBy.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            if (Qid != "Add")
            {
                CategoryFill();
            }
        }
    }
    protected void ddlRgpno_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.MaterialIssue obj = new SCM.MaterialIssue();
        if (obj.MaterialIssue_Select(ddlRgpno.SelectedItem.Value) > 0)
        {
           
            txtRgpDate.Text = obj.IssueDate;
            obj.MaterialIssueDetails2_Select(ddlRgpno.SelectedItem.Value, GridView1);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[11].Visible = false;
        }
    }


    private void CategoryFill()
    {
        SCM.ReturnIssueSlip objmaster = new SCM.ReturnIssueSlip();
        if (objmaster.ReturnIssueSlip_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtRgpreturnNo.Text = objmaster.IssueReturnNo;
            txtRgpreturnDate.Text = objmaster.IssuereturnDate;

            ddlstatus.SelectedValue = objmaster.status;
            txttermscondtionscontent.Text = HttpUtility.HtmlDecode(objmaster.Remarks);
            ddlstatus.SelectedValue = objmaster.status;
            // objmaster.RGPDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);
            ddlReceivedby.SelectedValue = objmaster.ReceivedBy;
            ddlPreparedBy.SelectedValue = objmaster.PreparedBy;
            ddlRgpno.SelectedValue = objmaster.IssueId;
            ddlRgpno_SelectedIndexChanged(new object(), new System.EventArgs());
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

    private void po_Save()
    {
        try
        {
            SCM.ReturnIssueSlip objMaster = new SCM.ReturnIssueSlip();

            objMaster.IssueReturnNo = txtRgpreturnNo.Text;
            objMaster.IssuereturnDate = General.toMMDDYYYY(txtRgpreturnDate.Text);
            objMaster.status = ddlstatus.SelectedItem.Value;
            objMaster.ReceiverName = txtrecivername.Text;
            objMaster.Address = txtaddress.Text;
            objMaster.Remarks = HttpUtility.HtmlEncode(txttermscondtionscontent.Text);
            objMaster.PreparedBy = ddlPreparedBy.SelectedItem.Value;
            objMaster.ReceivedBy = ddlReceivedby.SelectedItem.Value;
            objMaster.IssueId = ddlRgpno.SelectedItem.Value;

            if (objMaster.ReturnIssueSlip_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in GridView1.Rows)
                {
                    TextBox recqty = (TextBox)gvRowOtherCorp.FindControl("txtRECEIVEDQTY");
                    objMaster.ReceivedQty  = recqty.Text;

                    if (objMaster.ReceivedQty != "")
                    {

                        objMaster.Itemcode = gvRowOtherCorp.Cells[8].Text;
                        objMaster.ColorId = gvRowOtherCorp.Cells[9].Text;
                        objMaster.Uom = gvRowOtherCorp.Cells[2].Text;
                        //TextBox recqty = (TextBox)GridView1.FindControl("txtRECEIVEDQTY");
                        objMaster.Qty = recqty.Text;
                        objMaster.Length = gvRowOtherCorp.Cells[3].Text;
                        objMaster.Purpose = "-";
                        objMaster.DetRemarks = gvRowOtherCorp.Cells[7].Text;
                        objMaster.IssuedetId = gvRowOtherCorp.Cells[11].Text;
                        objMaster.ReceivedQty = recqty.Text;
                        objMaster.ReturnIssueSlipDetails_Save();
                        objMaster.IssueDetailsRemainingQty_Update(objMaster.IssuedetId, objMaster.Qty);
                        objMaster.Stock_UpdatePQC(objMaster.Itemcode, objMaster.Qty, objMaster.ColorId,objMaster.Length);
                    }
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
            Response.Redirect("~/Modules/Stock/ReturnIssue.aspx");
        }
    }

    private void po_Update()
    {
        try
        {
            SCM.ReturnIssueSlip objMaster = new SCM.ReturnIssueSlip();
            objMaster.IssueReturnId = Request.QueryString["Cid"].ToString();
            objMaster.IssueReturnNo = txtRgpreturnNo.Text;
            objMaster.IssuereturnDate = General.toMMDDYYYY(txtRgpreturnDate.Text);
            objMaster.status = ddlstatus.SelectedItem.Value;
            objMaster.ReceiverName = txtrecivername.Text;
            objMaster.Address = txtaddress.Text;
            objMaster.Remarks = HttpUtility.HtmlEncode(txttermscondtionscontent.Text);
            objMaster.PreparedBy = ddlPreparedBy.SelectedItem.Value;
            objMaster.ReceivedBy = ddlReceivedby.SelectedItem.Value;
            if (objMaster.ReturnIssueSlip_Update() == "Data Updated Successfully")
            {
                objMaster.ReturnIssueDetails_Delete(objMaster.IssueId);
                foreach (GridViewRow gvRowOtherCorp in GridView1.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[8].Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[9].Text;
                    objMaster.Uom = gvRowOtherCorp.Cells[2].Text;
                    TextBox recqty = (TextBox)GridView1.FindControl("txtRECEIVEDQTY");
                    objMaster.Qty = recqty.Text;
                    objMaster.Purpose = gvRowOtherCorp.Cells[6].Text;
                    objMaster.DetRemarks = gvRowOtherCorp.Cells[7].Text;
                    objMaster.IssuedetId = gvRowOtherCorp.Cells[11].Text;
                    objMaster.ReceivedQty = recqty.Text;
                    objMaster.ReturnIssueSlipDetails_Save();
                    objMaster.IssueDetailsRemainingQty_Update(objMaster.IssuedetId, objMaster.Qty);
                   // objMaster.Stock_UpdatePQC(objMaster.Itemcode, objMaster.Qty, objMaster.ColorId);

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
            Response.Redirect("~/Modules/Stock/ReturnIssue.aspx");
        }
    }




}