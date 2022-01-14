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

public partial class Modules_Stock_ToolRequest_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            Masters.MaterialMaster.ItemStock_Select(ddlitemCode);
            Masters.TableMaster.TableMaster_Select(ddltable);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlemployee);

            HR.EmployeeMaster.EmployeeMaster_Select(ddlrequestedBY);


            txtrequestno.Text = SCM.ToolsRequest.ToolsRequest_AutoGenCode();
            txtrequestdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            Masters.ColorMaster.Color_Select(ddlColor);
          

          
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);

            ddlpreparedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            // gvItems.DataBind();
            if (Qid != "Add")
            {
               
                CategoryFill();

            }
            
        }
    }

    private void CategoryFill()
    {
        SCM.ToolsRequest objmaster = new SCM.ToolsRequest();
        if (objmaster.ToolRequest_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtrequestno.Text = objmaster.RequestNo;
            txtrequestdate.Text = objmaster.RequestTooldate;
            ddlpreparedby.SelectedValue = objmaster.PreparedBy;
            ddlrequestedBY.SelectedValue = objmaster.Reqby;
          
            


            objmaster.ToolRequestDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);



        }
    }

    protected void btnadditem_Click(object sender, EventArgs e)
    {

        if(txtremarks.Text == "")
        {
            txtremarks.Text = "-";
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
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Table");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Employee");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("TableId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("EmployeeId");
        SalesOrderItems.Columns.Add(col);

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
                        dr["Length"] = ddllength.SelectedItem.Text; ;
                        dr["Uom"] = txtUom.Text;
                        dr["Color"] = ddlColor.SelectedItem.Text;
                        TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                        dr["Qty"] = txtQty.Text;
                        dr["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
                        dr["ColorId"] = ddlColor.SelectedItem.Value;
                        dr["Table"] = ddltable.SelectedItem.Text;
                        dr["TableId"] = ddltable.SelectedItem.Value;
                        dr["Employee"] = ddlemployee.SelectedItem.Text;
                        dr["EmployeeId"] = ddlemployee.SelectedItem.Value;

                        dr["Remarks"] = txtremarks.Text;

                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["ItemCode"] =   gvrow.Cells[1].Text;
                        dr["Series"] =     gvrow.Cells[2].Text;
                        dr["Length"] =     gvrow.Cells[3].Text;
                        dr["Uom"] =        gvrow.Cells[4].Text;
                        dr["Color"] =      gvrow.Cells[5].Text;
                        dr["Table"] =      gvrow.Cells[6].Text;
                        dr["Employee"] =   gvrow.Cells[7].Text;
                        dr["Qty"] =        gvrow.Cells[8].Text;
                        dr["ItemCodeId"] = gvrow.Cells[9].Text;
                        dr["ColorId"] =    gvrow.Cells[10].Text;
                        dr["TableId"] =    gvrow.Cells[11].Text;
                        dr["EmployeeId"] = gvrow.Cells[12].Text;
                        dr["Remarks"] =    gvrow.Cells[13].Text;





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
                    dr["Table"] = gvrow.Cells[6].Text;
                    dr["Employee"] = gvrow.Cells[7].Text;
                    TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                    dr["Qty"] = Qty.Text;
                    dr["ItemCodeId"] = gvrow.Cells[9].Text;
                    dr["ColorId"] = gvrow.Cells[10].Text;
                    dr["TableId"] = gvrow.Cells[11].Text;
                    dr["EmployeeId"] = gvrow.Cells[12].Text;

                    dr["Remarks"] = gvrow.Cells[13].Text;


                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }

        if (gvItems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["ItemCode"] = ddlitemCode.SelectedItem.Text;
            drnew["Series"] = txtseries.Text;
            drnew["Length"] = ddllength.SelectedItem.Text;
            drnew["Uom"] = txtUom.Text;
            drnew["Color"] = ddlColor.SelectedItem.Text;
            drnew["Qty"] = txtQty.Text;
            drnew["ItemCodeId"] = ddlitemCode.SelectedItem.Value;
            drnew["ColorId"] = ddlColor.SelectedItem.Value;

            drnew["Table"] = ddltable.SelectedItem.Text;
            drnew["TableId"] = ddltable.SelectedItem.Value;
            drnew["Employee"] = ddlemployee.SelectedItem.Text;
            drnew["EmployeeId"] = ddlemployee.SelectedItem.Value;

            drnew["Remarks"] = txtremarks.Text;



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
        //Masters.ColorMaster.Color_Select(ddlColor);
        //Masters.MaterialMaster.ItemStock_Select(ddlitemCode);
        //HR.EmployeeMaster.EmployeeMaster_Select(ddlemployee);
        //Masters.TableMaster.TableMaster_Select(ddltable);

        ddlemployee.SelectedValue = "0";
        ddlitemCode.SelectedValue = "0";
        ddlColor.SelectedValue = "0";
        ddltable.SelectedValue = "0";
        txtseries.Text = "";
        txtUom.Text = "";
        ddllength.SelectedValue = "0";
        // txtpu.Text = "";
        txtQty.Text = "";
        txtavailableqty.Text = "";
        txtremarks.Text = "";
        
    }

    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;

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
        col = new DataColumn("ItemCodeId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Table");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Employee");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("TableId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("EmployeeId");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Remarks");
        SalesOrderItems.Columns.Add(col);

        if (gvItems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvItems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = gvrow.Cells[1].Text;
                    dr["Series"] = gvrow.Cells[2].Text;
                    dr["Length"] = gvrow.Cells[3].Text;
                    dr["Uom"] = gvrow.Cells[4].Text;
                    dr["Color"] = gvrow.Cells[5].Text;
                    dr["Table"] = gvrow.Cells[6].Text;
                    dr["Employee"] = gvrow.Cells[7].Text;
                    TextBox Qty = (TextBox)gvrow.FindControl("txtitemqty");
                    dr["Qty"] = Qty.Text;
                    dr["ItemCodeId"] = gvrow.Cells[9].Text;
                    dr["ColorId"] = gvrow.Cells[10].Text;
                    dr["TableId"] = gvrow.Cells[11].Text;
                    dr["EmployeeId"] = gvrow.Cells[12].Text;

                    dr["Remarks"] = gvrow.Cells[13].Text;

                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvItems.DataSource = SalesOrderItems;
        gvItems.DataBind();
    }

    protected void ddlitemCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        Masters.MaterialMaster obj = new Masters.MaterialMaster();
        if (obj.MaterialPO_Select(ddlitemCode.SelectedItem.Value) > 0)
        {
            txtseries.Text = obj.Description;
            txtUom.Text = obj.UomName;
            Masters.MaterialMaster.ColorStock_ModelNoSelect(ddlColor, ddlitemCode.SelectedItem.Value);
            Masters.MaterialMaster.LengthStock_ModelNoSelect(ddllength, ddlitemCode.SelectedItem.Value);

            if (ddlColor.Items.Count > 0)
            {
                ddlColor_SelectedIndexChanged(sender, e);
            }
           // Masters.MaterialMaster.ColorStock_ModelNoSelect(ddlColor, ddlitemCode.SelectedItem.Value);
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
            SCM.ToolsRequest objMaster = new SCM.ToolsRequest();
            objMaster.RequestNo = txtrequestno.Text;
            objMaster.RequestTooldate = General.toMMDDYYYY(txtrequestdate.Text);
            objMaster.Reqby = ddlrequestedBY.SelectedItem.Value;
            objMaster.PreparedBy = ddlpreparedby.SelectedItem.Value;
            objMaster.Status = "";
           
            if (objMaster.ToolsRequest_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[9].Text;
                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.Quantity = qty.Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[10].Text;
                    objMaster.remarks = gvRowOtherCorp.Cells[2].Text;
                    objMaster.Length = gvRowOtherCorp.Cells[3].Text;
                    objMaster.tableid = gvRowOtherCorp.Cells[11].Text;
                    objMaster.empid = gvRowOtherCorp.Cells[12].Text;
                    objMaster.detstatus = gvRowOtherCorp.Cells[13].Text;

                    objMaster.ToolRequestDetails_Save();

                    objMaster.Stock_Update(objMaster.Itemcode, objMaster.Quantity, "1", objMaster.ColorId, "1", objMaster.Length);
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
            Response.Redirect("~/Modules/Stock/ToolRequest.aspx");
        }
    }

    private void po_Update()
    {
        try
        {
            SCM.ToolsRequest objMaster = new SCM.ToolsRequest();
            objMaster.ReqToolId = Request.QueryString["Cid"].ToString();
            objMaster.RequestNo = txtrequestno.Text;
            objMaster.RequestTooldate = General.toMMDDYYYY(txtrequestdate.Text);
            objMaster.Reqby = ddlrequestedBY.SelectedItem.Value;
            objMaster.PreparedBy = ddlpreparedby.SelectedItem.Value;
            objMaster.Status = "";
            if (objMaster.ToolsRequest_Update() == "Data Updated Successfully")
            {
                objMaster.ToolRequestDetails_Delete(objMaster.ReqToolId);
                foreach (GridViewRow gvRowOtherCorp in gvItems.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[9].Text;
                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.Quantity = qty.Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[10].Text;
                    objMaster.remarks = gvRowOtherCorp.Cells[2].Text;
                    objMaster.Length = gvRowOtherCorp.Cells[3].Text;
                    objMaster.tableid = gvRowOtherCorp.Cells[11].Text;
                    objMaster.empid = gvRowOtherCorp.Cells[12].Text;
                    objMaster.detstatus = gvRowOtherCorp.Cells[13].Text;
                    objMaster.ToolRequestDetails_Save();



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
            Response.Redirect("~/Modules/Stock/ToolRequest.aspx");
        }
    }







    protected void ddlColor_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.MaterialMaster.ItemColorLengthStock_ModelNoSelect(ddllength, ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value);

        if (ddllength.Items.Count > 0)
        {
            ddllength_SelectedIndexChanged(sender, e);
        }
    }
    protected void ddllength_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.Stock Stock = new SCM.Stock();

        if (Stock.MCLStockAvailable(ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value, ddllength.SelectedItem.Value) > 0)
        {
            txtavailableqty.Text = Stock.TStock;
        }

        
    }
}