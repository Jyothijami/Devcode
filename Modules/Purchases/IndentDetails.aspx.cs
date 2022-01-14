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

public partial class Modules_Purchases_IndentDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //  gvQuatation.DataBind();
            SM.CustomerMaster.CustomerMaster_Select(ddlCustomerName);
            Masters.MaterialMaster.MaterialMaster_Select(ddlMaterial);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlFollowUp);
            Masters.Department.Department_Select(ddlDepart);
            txtIndentNo.Text = SCM.Indent.Indent_AutoGenCode();
            txtindentdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
          
        }
    }
    protected void btnadditem_Click(object sender, EventArgs e)
    {
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Length");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("CustomerName");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("CustId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SeriesId");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Kgpermtr");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("TotalWeight");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("AlumiumCoating");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Amount");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ColorId");
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
                        dr["Series"] = ddlMaterial.SelectedItem.Text;
                        dr["Length"] = txtlength.Text; ;
                        dr["Description"] = txtDescription.Text;
                        dr["Color"] = txtColor.SelectedItem.Text;
                        dr["Qty"] = txtQty.Text;
                        dr["CustomerName"] = ddlCustomerName.SelectedItem.Text;
                        dr["CustId"] = ddlCustomerName.SelectedItem.Value;
                        dr["SeriesId"] = ddlMaterial.SelectedItem.Text;

                        dr["Kgpermtr"] = txtkgpermtr.Text;
                        dr["TotalWeight"] = txttotalweight.Text;
                        dr["AlumiumCoating"] = txtaluminumcoating.Text;
                        dr["Amount"] = txtamount.Text;
                        dr["ColorId"] = txtColor.SelectedItem.Value;
                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["Series"] = gvrow.Cells[1].Text;
                        dr["Length"] = gvrow.Cells[2].Text;
                        dr["Description"] = gvrow.Cells[3].Text;
                        dr["Color"] = gvrow.Cells[4].Text;
                        dr["Qty"] = gvrow.Cells[5].Text;
                        dr["CustomerName"] = gvrow.Cells[10].Text;
                        dr["CustId"] = gvrow.Cells[11].Text;
                        dr["SeriesId"] = gvrow.Cells[12].Text;
                        dr["Kgpermtr"] = gvrow.Cells[6].Text;
                        dr["TotalWeight"] = gvrow.Cells[7].Text;
                        dr["AlumiumCoating"] = gvrow.Cells[8].Text;
                        dr["Amount"] = gvrow.Cells[9].Text;
                        dr["ColorId"] = gvrow.Cells[13].Text;

                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Series"] = gvrow.Cells[1].Text;
                    dr["Length"] = gvrow.Cells[2].Text;
                    dr["Description"] = gvrow.Cells[3].Text;
                    dr["Color"] = gvrow.Cells[4].Text;
                    dr["Qty"] = gvrow.Cells[5].Text;
                    dr["CustomerName"] = gvrow.Cells[10].Text;
                    dr["CustId"] = gvrow.Cells[11].Text;
                    dr["SeriesId"] = gvrow.Cells[12].Text;
                    dr["Kgpermtr"] = gvrow.Cells[6].Text;
                    dr["TotalWeight"] = gvrow.Cells[7].Text;
                    dr["AlumiumCoating"] = gvrow.Cells[8].Text;
                    dr["Amount"] = gvrow.Cells[9].Text;
                    dr["ColorId"] = gvrow.Cells[13].Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }


        if (gvitems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["Series"] = ddlMaterial.SelectedItem.Text;
            drnew["Length"] = txtlength.Text;
            drnew["Description"] = txtDescription.Text;
            drnew["Color"] = txtColor.SelectedItem.Text;
            drnew["Qty"] = txtQty.Text;
            drnew["CustomerName"] = ddlCustomerName.SelectedItem.Text;
            drnew["CustId"] = ddlCustomerName.SelectedItem.Value;
            drnew["SeriesId"] = ddlMaterial.SelectedItem.Value;
            drnew["Kgpermtr"] = txtkgpermtr.Text;
            drnew["TotalWeight"] = txttotalweight.Text;
            drnew["AlumiumCoating"] = txtaluminumcoating.Text;
            drnew["Amount"] = txtamount.Text;
            drnew["ColorId"] = txtColor.SelectedItem.Value;
            SalesOrderItems.Rows.Add(drnew);

        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
        gvitems.SelectedIndex = -1;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SCM.Indent objSM = new SCM.Indent();
            objSM.INDNo = txtIndentNo.Text;
            objSM.INDDate = General.toMMDDYYYY(txtindentdate.Text);
            objSM.DeptId = ddlDepart.SelectedItem.Value;
           
            objSM.INDPreparedBy = ddlpreparedby.SelectedItem.Value;
            objSM.INDApprovedBy = ddlapprovedby.SelectedItem.Value;
            objSM.FollowUp = ddlFollowUp.SelectedItem.Value;


            if (objSM.Indent_Save() == "Data Saved Successfully")
            {
                 objSM.IndentDetails_Delete(objSM.INDId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.MatId = gvrow.Cells[12].Text;
                    objSM.Description = gvrow.Cells[3].Text;
                    objSM.Length = gvrow.Cells[2].Text;
                    objSM.Color = gvrow.Cells[4].Text;
                    objSM.Qty = gvrow.Cells[5].Text;
                    objSM.CustId = gvrow.Cells[11].Text;
                    objSM.kgpermt = gvrow.Cells[6].Text;
                    objSM.totalweight = gvrow.Cells[7].Text;
                    objSM.aluminumcoating = gvrow.Cells[8].Text;
                    objSM.amount = gvrow.Cells[9].Text;
                    objSM.ColorId = gvrow.Cells[13].Text;
                    objSM.IndentDetails_Save();
                }

                MessageBox.Show(this, "Data Saved Successfully");
            }

        }
        catch (Exception ex)
        {

            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {

        }
    }
    protected void ddlMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.MaterialMaster obj = new Masters.MaterialMaster();
        if(obj.MaterialType_Select(ddlMaterial.SelectedItem.Value) > 0)
        {
            txtDescription.Text = obj.Description;
            txtlength.Text = obj.BarLength;
            txtkgpermtr.Text = obj.weight;
            
        }
        Masters.MaterialMaster.ItemMaster_ModelNoSelect(txtColor, ddlMaterial.SelectedValue);

    }
    protected void gvitems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvitems.Rows[e.RowIndex].Cells[1].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Length");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Color");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("CustomerName");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("CustId");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SeriesId");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("Kgpermtr");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("TotalWeight");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("AlumiumCoating");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Amount");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("ColorId");
        SalesOrderItems.Columns.Add(col);


        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Series"] = gvrow.Cells[1].Text;
                    dr["Length"] = gvrow.Cells[2].Text;
                    dr["Description"] = gvrow.Cells[3].Text;
                    dr["Color"] = gvrow.Cells[4].Text;
                    dr["Qty"] = gvrow.Cells[5].Text;
                    dr["CustomerName"] = gvrow.Cells[10].Text;
                    dr["CustId"] = gvrow.Cells[11].Text;
                    dr["SeriesId"] = gvrow.Cells[12].Text;
                    dr["Kgpermtr"] = gvrow.Cells[6].Text;
                    dr["TotalWeight"] = gvrow.Cells[7].Text;
                    dr["AlumiumCoating"] = gvrow.Cells[8].Text;
                    dr["Amount"] = gvrow.Cells[9].Text;

                    dr["ColorId"] = gvrow.Cells[13].Text;
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
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;

        }
    }
}