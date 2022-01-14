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

public partial class Modules_Stock_Return_Nrgp_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {

            txtRgpreturnNo.Text = SCM.ReturnNRGP.RNRGP_AutoGenCode();
            txtRgpreturnDate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlPreparedBy);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlReceivedby);
            SCM.NRGP.NRGP_Select(ddlRgpno);
            ddlPreparedBy.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            if (Qid != "Add")
            {
                CategoryFill();
            }
        }
    }
    protected void ddlRgpno_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.NRGP obj = new SCM.NRGP();
        if (obj.NRGP_Select(ddlRgpno.SelectedItem.Value) > 0)
        {
            txtaddress.Text = obj.Address;
            txtrecivername.Text = obj.ReceiverName;
            txtRgpDate.Text = obj.NRgpDate;
            obj.NRGPDetails_Select(ddlRgpno.SelectedItem.Value, GridView1);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[12].Visible = false;
        }
    }


    private void CategoryFill()
    {
        SCM.ReturnNRGP objmaster = new SCM.ReturnNRGP();
        if (objmaster.RNRGP_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtRgpreturnNo.Text = objmaster.RNRgpNo;
            txtRgpreturnDate.Text = objmaster.RNRgpDate;

            ddlstatus.SelectedValue = objmaster.status;
            txttermscondtionscontent.Text = HttpUtility.HtmlDecode(objmaster.Remarks);
            ddlstatus.SelectedValue = objmaster.status;
            // objmaster.RGPDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);
            ddlReceivedby.SelectedValue = objmaster.ReceivedBy;
            ddlPreparedBy.SelectedValue = objmaster.PreparedBy;
            ddlRgpno.SelectedValue = objmaster.Nrgpid;
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
            SCM.ReturnNRGP objMaster = new SCM.ReturnNRGP();

            objMaster.RNRgpNo = txtRgpreturnNo.Text;
            objMaster.RNRgpDate = General.toMMDDYYYY(txtRgpreturnDate.Text);
            objMaster.status = ddlstatus.SelectedItem.Value;
            objMaster.ReceiverName = txtrecivername.Text;
            objMaster.Address = txtaddress.Text;
            objMaster.Remarks = HttpUtility.HtmlEncode(txttermscondtionscontent.Text);
            objMaster.PreparedBy = ddlPreparedBy.SelectedItem.Value;
            objMaster.ReceivedBy = ddlReceivedby.SelectedItem.Value;
            objMaster.Nrgpid = ddlRgpno.SelectedItem.Value;

            if (objMaster.RNRGP_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in GridView1.Rows)
                {
                    TextBox recqty = (TextBox)gvRowOtherCorp.FindControl("txtRECEIVEDQTY");
                    objMaster.ReceivedQty = recqty.Text;
                    if (objMaster.ReceivedQty != "")
                    {

                        objMaster.Itemcode = gvRowOtherCorp.Cells[9].Text;
                        objMaster.ColorId = gvRowOtherCorp.Cells[10].Text;
                        objMaster.Uom = gvRowOtherCorp.Cells[2].Text;
                        //TextBox recqty = (TextBox)GridView1.FindControl("txtRECEIVEDQTY");
                        objMaster.Qty = recqty.Text;
                        objMaster.Purpose = gvRowOtherCorp.Cells[7].Text;
                        objMaster.DetRemarks = gvRowOtherCorp.Cells[8].Text;
                        objMaster.nrgpdetid = gvRowOtherCorp.Cells[12].Text;
                        objMaster.ReceivedQty = recqty.Text;

                        objMaster.Length = gvRowOtherCorp.Cells[3].Text;


                        objMaster.RNRGPDetails_Save();
                        objMaster.NRgpDetailsRemainingQty_Update(objMaster.nrgpdetid, objMaster.Qty);
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
            Response.Redirect("~/Modules/Stock/Return_Nrgp.aspx");
        }
    }

    private void po_Update()
    {
        try
        {
            SCM.ReturnNRGP objMaster = new SCM.ReturnNRGP();
            objMaster.RNRGPId = Request.QueryString["Cid"].ToString();
            objMaster.RNRgpNo = txtRgpreturnNo.Text;
            objMaster.RNRgpDate = General.toMMDDYYYY(txtRgpreturnDate.Text);
            objMaster.status = ddlstatus.SelectedItem.Value;
            objMaster.ReceiverName = txtrecivername.Text;
            objMaster.Address = txtaddress.Text;
            objMaster.Remarks = HttpUtility.HtmlEncode(txttermscondtionscontent.Text);
            objMaster.PreparedBy = ddlPreparedBy.SelectedItem.Value;
            objMaster.ReceivedBy = ddlReceivedby.SelectedItem.Value;
            if (objMaster.RNRGP_Update() == "Data Updated Successfully")
            {
                objMaster.RNRGPDetails_Delete(objMaster.RNRGPId);
                foreach (GridViewRow gvRowOtherCorp in GridView1.Rows)
                {
                    TextBox recqty = (TextBox)GridView1.FindControl("txtRECEIVEDQTY");
                    if (recqty.Text != "")
                    {

                        objMaster.Itemcode = gvRowOtherCorp.Cells[9].Text;
                        objMaster.ColorId = gvRowOtherCorp.Cells[10].Text;
                        objMaster.Uom = gvRowOtherCorp.Cells[2].Text;
                        //TextBox recqty = (TextBox)GridView1.FindControl("txtRECEIVEDQTY");
                        objMaster.Qty = recqty.Text;
                        objMaster.Purpose = gvRowOtherCorp.Cells[7].Text;
                        objMaster.DetRemarks = gvRowOtherCorp.Cells[8].Text;
                        objMaster.nrgpdetid = gvRowOtherCorp.Cells[12].Text;
                        objMaster.ReceivedQty = recqty.Text;

                        objMaster.Length = gvRowOtherCorp.Cells[3].Text;


                        objMaster.RNRGPDetails_Save();
                        objMaster.NRgpDetailsRemainingQty_Update(objMaster.nrgpdetid, objMaster.Qty);
                        objMaster.Stock_UpdatePQC(objMaster.Itemcode, objMaster.Qty, objMaster.ColorId, objMaster.Length);
                    }
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
            Response.Redirect("~/Modules/Stock/Return_Nrgp.aspx");
        }
    }




}