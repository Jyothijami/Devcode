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

public partial class Modules_Stock_BlukReturnRequest_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            Masters.MaterialMaster.ItemStock_Select(ddlitemCode);

            txtMaterialreqestNo.Text = SCM.BulkReturnRequest.BulkReturnRequest_AutoGenCode();
            txtMrdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
           
            Masters.ColorMaster.Color_Select(ddlColor);
            SM.SalesOrder.SalesOrder_Select(ddlSono);
            SM.CustomerMaster.CustomerUnit_Select(ddlCustomer);

            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlrequestedby);

            ddlrequestedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            // gvItems.DataBind();
            if (Qid != "Add")
            {
                btnApprove.Visible = true;
                CategoryFill();

            }
            else
            {
                btnApprove.Visible = false;
            }
        }
    }

    private void CategoryFill()
    {
        SCM.BulkReturnRequest objmaster = new SCM.BulkReturnRequest();
        if (objmaster.BulkReturnIssueRequest_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtMaterialreqestNo.Text = objmaster.BulkReqIssueNo;
            txtMrdate.Text = objmaster.RequestDate;
            ddlrequesttype.SelectedValue = objmaster.RequestPurpose;
            ddlrequestedby.SelectedValue = objmaster.ReturnBy;
            ddlapprovedby.SelectedValue = objmaster.ApprovedBy;
            ddlCustomer.SelectedValue = objmaster.Custid;
            ddlSono.SelectedValue = objmaster.SoId;

            if (objmaster.ApprovedBy != "0")
            {
                btnApprove.Visible = false;
                //  btnSave.Visible = false;
            }


            objmaster.BulkReturnIssueRequestDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);

           

        }
    }

    protected void btnadditem_Click(object sender, EventArgs e)
    {



        //if( int.Parse(txtQty.Text) > int.Parse(txtpu.Text))
        //{
        //    MessageBox.Show(this,"Qty Should Not Exceed the Available Qty")
        //}
        //else
        //{ 


        //decimal value = 0, pu = 0;
        //decimal.TryParse(txtQty.Text, out value);
        //decimal.TryParse(txtpu.Text, out pu);



        //if (value <= pu)
        //{


            if (txtremakrs.Text == "")
            {
                txtremakrs.Text = "-";
            }


            DataTable SalesOrderItems = new DataTable();
            DataColumn col = new DataColumn();
            col = new DataColumn("ItemCode");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("Series");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("Length");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("Uom");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("Color");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("Qty");
            SalesOrderItems.Columns.Add(col);
            //col = new DataColumn("Warehouse");
            //SalesOrderItems.Columns.Add(col);
            // SalesOrderItems.Columns.Add(col);
            col = new DataColumn("ItemCodeId");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("ColorId");
            SalesOrderItems.Columns.Add(col);
            //col = new DataColumn("SoMatId");
            //SalesOrderItems.Columns.Add(col);
            col = new DataColumn("Remarks");
            SalesOrderItems.Columns.Add(col);
            if (gvItems.Rows.Count > 0)
            {
                foreach (GridViewRow gvrow in gvItems.Rows)
                {
                    if (gvItems.SelectedIndex > -1)
                    {
                        if (gvrow.RowIndex == gvItems.SelectedRow.RowIndex)
                        {
                            DataRow dr = SalesOrderItems.NewRow();
                            dr["ItemCode"] = ddlitemCode.SelectedItem.Text;
                            dr["Series"] = txtseries.Text;
                            dr["Length"] = txtitemtLength.Text;
                            dr["Uom"] = txtUom.Text;
                            dr["Color"] = ddlColor.SelectedItem.Text;
                            TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                            dr["Qty"] = txtQty.Text;
                            dr["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
                            dr["ColorId"] = ddlColor.SelectedItem.Value;
                            //dr["SoMatId"] = "0";
                            TextBox Remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                            dr["Remarks"] = txtremakrs.Text;



                            SalesOrderItems.Rows.Add(dr);
                        }
                        else
                        {
                            DataRow dr = SalesOrderItems.NewRow();
                            dr["ItemCode"] = gvrow.Cells[1].Text;
                            dr["Series"] = gvrow.Cells[2].Text;
                            dr["Length"] = gvrow.Cells[3].Text;
                            dr["Uom"] = gvrow.Cells[4].Text;
                            dr["Color"] = gvrow.Cells[5].Text;
                            dr["Qty"] = gvrow.Cells[6].Text;


                            dr["ItemCodeId"] = gvrow.Cells[7].Text;
                            dr["ColorId"] = gvrow.Cells[8].Text;

                            //dr["SoMatId"] = gvrow.Cells[9].Text;
                            dr["Remarks"] = gvrow.Cells[9].Text;
                            SalesOrderItems.Rows.Add(dr);
                        }
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["ItemCode"] = gvrow.Cells[1].Text;
                        dr["Series"] = gvrow.Cells[2].Text;
                        dr["Length"] = gvrow.Cells[3].Text;
                        dr["Uom"] = gvrow.Cells[4].Text;
                        dr["Color"] = gvrow.Cells[5].Text;
                        TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                        dr["Qty"] = Qty.Text;
                        dr["ItemCodeId"] = gvrow.Cells[7].Text;
                        dr["ColorId"] = gvrow.Cells[8].Text;
                        //dr["SoMatId"] = gvrow.Cells[9].Text;

                        TextBox Remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                        dr["Remarks"] = Remarks.Text;


                        SalesOrderItems.Rows.Add(dr);
                    }
                }
            }

            if (gvItems.SelectedIndex == -1)
            {
                DataRow drnew = SalesOrderItems.NewRow();
                drnew["ItemCode"] = ddlitemCode.SelectedItem.Text;
                drnew["Series"] = txtseries.Text;
                drnew["Length"] = txtitemtLength.Text;
                drnew["Uom"] = txtUom.Text;
                drnew["Color"] = ddlColor.SelectedItem.Text;
                //TextBox Qty = (TextBox)gvItems.FindControl("txtitemqty");
                //Qty.Text = txtQty.Text;
                drnew["Qty"] = txtQty.Text;
                drnew["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
                drnew["ColorId"] = ddlColor.SelectedItem.Value;
                //drnew["SoMatId"] = "0";
                // TextBox Remarks = (TextBox)gvItems.FindControl("txtitemRemarks");
                // Remarks.Text = txtremakrs.Text;

                drnew["Remarks"] = txtremakrs.Text;




                // drnew["Remarks"] = txtremakrs.Text;
                SalesOrderItems.Rows.Add(drnew);
            }
            gvItems.DataSource = SalesOrderItems;
            gvItems.DataBind();
            gvItems.SelectedIndex = -1;
            clearitems();
       
    }

    private void clearitems()
    {
        Masters.ColorMaster.Color_Select(ddlColor);
        Masters.MaterialMaster.ItemStock_Select(ddlitemCode);
        ddlitemCode.SelectedValue = "0";
        ddlColor.SelectedValue = "0";
        txtseries.Text = "";
        txtUom.Text = "";
        txtitemtLength.Text = "";
       // txtpu.Text = "";
        txtQty.Text = "";
        txtremakrs.Text = "";
    }

    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            //e.Row.Cells[9].Visible = false;

        }
    }

    protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvItems.Rows[e.RowIndex].Cells[0].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ItemCode");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Length");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Uom");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("Warehouse");
        //SalesOrderItems.Columns.Add(col);
        // SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("SoMatId");
        //SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Remarks");
        SalesOrderItems.Columns.Add(col);
        if (gvItems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvItems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    //dr["ItemCode"] = gvrow.Cells[1].Text;
                    //dr["Series"] = gvrow.Cells[2].Text;
                    //dr["Length"] = gvrow.Cells[3].Text;
                    //dr["Uom"] = gvrow.Cells[4].Text;
                    //dr["Color"] = gvrow.Cells[5].Text;


                    //TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                    //dr["Qty"] = Qty.Text;



                    //dr["ItemCodeId"] = gvrow.Cells[7].Text;
                    //dr["ColorId"] = gvrow.Cells[8].Text;

                    //dr["SoMatId"] = gvrow.Cells[9].Text;
                    //TextBox Remarks = (TextBox)gvItems.FindControl("txtitemRemarks");
                    //dr["Remarks"] = Remarks.Text;
                    dr["ItemCode"] = gvrow.Cells[1].Text;
                    dr["Series"] = gvrow.Cells[2].Text;
                    dr["Length"] = gvrow.Cells[3].Text;
                    dr["Uom"] = gvrow.Cells[4].Text;
                    dr["Color"] = gvrow.Cells[5].Text;
                    //dr["Qty"] = gvrow.Cells[6].Text;
                    TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                    dr["Qty"] = Qty.Text;


                    dr["ItemCodeId"] = gvrow.Cells[7].Text;
                    dr["ColorId"] = gvrow.Cells[8].Text;

                    //dr["SoMatId"] = gvrow.Cells[9].Text;
                    //dr["Remarks"] = gvrow.Cells[10].Text;
                    TextBox Remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                    dr["Remarks"] = Remarks.Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvItems.DataSource = SalesOrderItems;
        gvItems.DataBind();
    }

    protected void ddlitemCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Masters.MaterialMaster obj = new Masters.MaterialMaster();
        //if (obj.MaterialPO_Select(ddlitemCode.SelectedItem.Value) > 0)
        //{
        //    txtseries.Text = obj.Description;
        //    txtUom.Text = obj.UomName;
        //    //txtitemtLength.Text = obj.BarLength;
        //    //txtpu.Text = obj.Boxsize;


        //    Masters.MaterialMaster.ColorStock_ModelNoSelect(ddlColor, ddlitemCode.SelectedItem.Value);
        //    Masters.MaterialMaster.LengthStock_ModelNoSelect(ddllength, ddlitemCode.SelectedItem.Value);

        //    if (ddlColor.Items.Count > 0)
        //    {
        //        ddlColor_SelectedIndexChanged(sender, e);
        //    }



        //}


        Masters.MaterialMaster obj = new Masters.MaterialMaster();
        if (obj.MaterialPO_Select(ddlitemCode.SelectedItem.Value) > 0)
        {
            txtseries.Text = obj.Description;
            txtUom.Text = obj.UomName;
            txtitemtLength.Text = obj.BarLength;
            Masters.MaterialMaster.ColorStock_ModelNoSelect(ddlColor, ddlitemCode.SelectedItem.Value);
          //  Masters.MaterialMaster.LengthStock_ModelNoSelect(ddllength, ddlitemCode.SelectedItem.Value);
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
            SCM.BulkReturnRequest objMaster = new SCM.BulkReturnRequest();

            objMaster.BulkReqIssueNo = txtMaterialreqestNo.Text;
            objMaster.RequestDate = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.RequestPurpose = ddlrequesttype.SelectedItem.Value;
            objMaster.ApprovedBy = ddlapprovedby.SelectedItem.Value;
            objMaster.ReturnBy = ddlrequestedby.SelectedItem.Value;
            objMaster.Custid = ddlCustomer.SelectedItem.Value;
            objMaster.SoId = ddlSono.SelectedItem.Value;
           
            objMaster.Status = "Not Issued";
            if (objMaster.BulkReturnIssueRequest_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[7].Text;
                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.Quantity = qty.Text;

                    objMaster.ColorId = gvRowOtherCorp.Cells[8].Text;

                    objMaster.SoId = ddlSono.SelectedItem.Value;


                    objMaster.Length = gvRowOtherCorp.Cells[3].Text;

                    TextBox Remarks = (TextBox)gvRowOtherCorp.FindControl("txtitemRemarks");
                    objMaster.remarks = Remarks.Text;



                    objMaster.BulkReturnIssueRequestDetails_Save();
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
            Response.Redirect("~/Modules/Stock/BlukReturnRequest.aspx");
        }
    }

    private void po_Update()
    {
        try
        {
            SCM.BulkReturnRequest objMaster = new SCM.BulkReturnRequest();
            objMaster.ReqIssueId = Request.QueryString["Cid"].ToString();
            objMaster.BulkReqIssueNo = txtMaterialreqestNo.Text;
            objMaster.RequestDate = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.RequestPurpose = ddlrequesttype.SelectedItem.Value;
            objMaster.ApprovedBy = ddlapprovedby.SelectedItem.Value;
            objMaster.ReturnBy = ddlrequestedby.SelectedItem.Value;
            objMaster.Custid = ddlCustomer.SelectedItem.Value;
            objMaster.SoId = ddlSono.SelectedItem.Value;
            objMaster.Status = "Not Issued";
            if (objMaster.BulkReturnIssueRequest_Update() == "Data Updated Successfully")
            {
                objMaster.BulkReturnIssueRequestDetails_Delete(objMaster.ReqIssueId);
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[7].Text;
                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.Quantity = qty.Text;

                    objMaster.ColorId = gvRowOtherCorp.Cells[8].Text;

                    objMaster.SoId = ddlSono.SelectedItem.Value;


                    objMaster.Length = gvRowOtherCorp.Cells[3].Text;

                    TextBox Remarks = (TextBox)gvRowOtherCorp.FindControl("txtitemRemarks");
                    objMaster.remarks = Remarks.Text;



                    objMaster.BulkReturnIssueRequestDetails_Save();
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
            Response.Redirect("~/Modules/Stock/BlukReturnRequest.aspx");
        }
    }

  
    protected void ddlSono_SelectedIndexChanged(object sender, EventArgs e)
    {


        //SM.SalesOrder obj = new SM.SalesOrder();
        //if(obj.SalesOrder_Select(ddlSono.SelectedItem.Value) > 0)
        //{
        //    ddlCustomer.SelectedValue = obj.SiteId;
        //}

        General ob = new General();
        string Val = ob.GetColumnVal("SELECT CustSiteId FROM [Sales_Order] WHERE Sales_Order.SalesOrder_Id='" + ddlSono.SelectedItem.Value + "' ", "CustSiteId");
        if (Val != "")
        {
            ddlCustomer.SelectedValue = Val;
        }


    }

   
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            SCM.BulkReturnRequest objSMSOApprove = new SCM.BulkReturnRequest();
            objSMSOApprove.ReqIssueId = Request.QueryString["Cid"].ToString();
            objSMSOApprove.ApprovedBy = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSMSOApprove.BulkReturnIssueRequestApprove_Update();

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Response.Redirect("~/Modules/Stock/BlukReturnRequest.aspx");
        }
    }


  
  
   
}