using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_GoodsReceipt_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            SCM.SupPo.SupPo_Select(ddlPono);
            txtPreceiptno.Text = SCM.PurchaseReceipt.PurchaseReceipt_AutoGenCode();
            txtPrDate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlCheckedBy);



            if (Qid != "Add")
            {
                QuatationFill();
                btnSave.Visible = true;
                btnSave.Text = "Update";
               
            }
        }
    }

    private void QuatationFill()
    {
        SCM.PurchaseReceipt obj = new SCM.PurchaseReceipt();
        if (obj.PurchaseReceipt_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            txtPrDate.Text = obj.SPrDate;
            txtPreceiptno.Text = obj.SPrNo;
            ddlPono.SelectedValue = obj.POid;
            ddlPono_SelectedIndexChanged(new object(), new System.EventArgs());
            ddlpreparedby.SelectedValue = obj.Preparedby;

        }
    }

    protected void ddlPono_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.SupPo obj = new SCM.SupPo();
        if (obj.SupPoname_Select(ddlPono.SelectedItem.Value) > 0)
        {
            txtvendorname.Text = obj.Sname;
            txtVendorContactPerson.Text = obj.SContact;
            //  txtvendorContactNo.Text = obj.Smobile;

            txtPoDate.Text = obj.PoDate;

            obj.SupPoOrder_Select(ddlPono.SelectedItem.Value, GridView1);
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //this.GridView1.EditIndex = e.NewEditIndex;
        //GridView1.DataBind();

        //DataTable SuppliersFixedPOItems = new DataTable();
        //DataColumn col = new DataColumn();
        //col = new DataColumn("Series");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("Length");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("Description");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("Color");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("Qty");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("CustomerName");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("CustId");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("SeriesId");
        //SuppliersFixedPOItems.Columns.Add(col);

        //col = new DataColumn("Kgpermtr");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("TotalWeight");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("AlumiumCoating");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("Amount");
        //SuppliersFixedPOItems.Columns.Add(col);

        //col = new DataColumn("ReceivedQty");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("RemainingQty");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("PlantId");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("StorageLoc");
        //SuppliersFixedPOItems.Columns.Add(col);
        //col = new DataColumn("Stocktype");
        //SuppliersFixedPOItems.Columns.Add(col);

        //if (GridView1.Rows.Count > 0)
        //{
        //    foreach (GridViewRow gvrow in GridView1.Rows)
        //    {
        //        DataRow dr = SuppliersFixedPOItems.NewRow();
        //        dr["Series"] = gvrow.Cells[1].Text;
        //        dr["Description"] = gvrow.Cells[3].Text;
        //        dr["Length"] = gvrow.Cells[2].Text;
        //        dr["Color"] = gvrow.Cells[4].Text;
        //        dr["Qty"] = gvrow.Cells[5].Text;

        //        dr["SeriesID"] = gvrow.Cells[13].Text;
        //        dr["Amount"] = gvrow.Cells[12].Text;
        //        dr["CustomerName"] = gvrow.Cells[11].Text;
        //        dr["CustId"] = gvrow.Cells[12].Text;

        //        dr["ReceivedQty"] = gvrow.Cells[9].Text;
        //        dr["RemainingQty"] = gvrow.Cells[10].Text;

        //        dr["Kgpermtr"] = gvrow.Cells[6].Text;
        //        dr["TotalWeight"] = gvrow.Cells[7].Text;
        //        dr["AlumiumCoating"] = gvrow.Cells[8].Text;

        //        dr["PlantId"] = gvrow.Cells[14].Text;
        //        dr["StorageLoc"] = gvrow.Cells[15].Text;
        //        dr["Stocktype"] = gvrow.Cells[16].Text;
        //        SuppliersFixedPOItems.Rows.Add(dr);
        //        if (gvrow.RowIndex == GridView1.Rows[e.NewEditIndex].RowIndex)
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        //            lblMaterialName.Text = gvrow.Cells[1].Text;
        //           // lbltest.Text = gvrow.Cells[2].Text;
        //            lblMaterialLength.Text = gvrow.Cells[2].Text;
        //            lblMaterialDescription.Text = gvrow.Cells[3].Text;
        //            lblMaterialColor.Text = gvrow.Cells[4].Text;
        //            txtQty.Text = gvrow.Cells[5].Text;
        //            txtReceivedQty.Text = gvrow.Cells[9].Text;
        //            txtreaminingqty.Text = gvrow.Cells[10].Text;
        //            ddlPlant.SelectedValue = gvrow.Cells[14].Text;
        //            ddlStoragelocation.SelectedValue = gvrow.Cells[15].Text;
        //            ddlStocktype.SelectedValue = gvrow.Cells[16].Text;
        //            GridView1.SelectedIndex = gvrow.RowIndex;
        //        }
        //    }
        //}
        //GridView1.DataSource = SuppliersFixedPOItems;
        //GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlPlant = (DropDownList)e.Row.FindControl("ddlPlant");
            Masters.Plant.Plant_Select(ddlPlant);
            //DropDownList ddlStoragelocation = (DropDownList)e.Row.FindControl("ddlStoragelocation");
            //Masters.StorageLocation.StorageLocation_Select(ddlStoragelocation);
            //DropDownList ddlStocktype = (DropDownList)e.Row.FindControl("ddlStocktype");
            //Masters.StockType.StockType_Select(ddlStocktype);
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        // DataTable SuppliersFixedPOItems = new DataTable();
        // DataColumn col = new DataColumn();
        // col = new DataColumn("Series");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("Length");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("Description");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("Color");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("Qty");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("CustomerName");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("CustId");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("SeriesId");
        // SuppliersFixedPOItems.Columns.Add(col);

        // col = new DataColumn("Kgpermtr");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("TotalWeight");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("AlumiumCoating");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("Amount");
        // SuppliersFixedPOItems.Columns.Add(col);

        // col = new DataColumn("ReceivedQty");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("RemainingQty");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("PlantId");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("StorageLoc");
        // SuppliersFixedPOItems.Columns.Add(col);
        // col = new DataColumn("Stocktype");
        // SuppliersFixedPOItems.Columns.Add(col);

        // if (GridView1.Rows.Count > 0)
        // {
        //     foreach (GridViewRow gvrow in GridView1.Rows)
        //     {
        //         if (GridView1.SelectedIndex > -1)
        //         {
        //             if (gvrow.RowIndex == GridView1.SelectedRow.RowIndex)
        //             {
        //                 DataRow dr = SuppliersFixedPOItems.NewRow();
        //                 dr["Series"] = gvrow.Cells[1].Text;
        //                 dr["Description"] = gvrow.Cells[3].Text;
        //                 dr["Length"] = gvrow.Cells[2].Text;
        //                 dr["Color"] = gvrow.Cells[4].Text;
        //                 dr["Qty"] = gvrow.Cells[5].Text;

        //                 dr["SeriesID"] = gvrow.Cells[13].Text;
        //                 dr["Amount"] = gvrow.Cells[12].Text;
        //                 dr["CustomerName"] = gvrow.Cells[11].Text;
        //                 dr["CustId"] = gvrow.Cells[12].Text;

        //                 dr["ReceivedQty"] = txtReceivedQty.Text;
        //                 dr["RemainingQty"] = gvrow.Cells[10].Text;

        //                 dr["Kgpermtr"] = gvrow.Cells[6].Text;
        //                 dr["TotalWeight"] = gvrow.Cells[7].Text;
        //                 dr["AlumiumCoating"] = gvrow.Cells[8].Text;

        //                 dr["PlantId"] = ddlPlant.SelectedItem.Value;
        //                 dr["StorageLoc"] =ddlStoragelocation.SelectedItem.Value;
        //                 dr["Stocktype"] = ddlStocktype.SelectedItem.Value;
        //                 SuppliersFixedPOItems.Rows.Add(dr);
        //             }
        //             else
        //             {
        //                 DataRow dr = SuppliersFixedPOItems.NewRow();
        //                 dr["Series"] = gvrow.Cells[1].Text;
        //                 dr["Description"] = gvrow.Cells[3].Text;
        //                 dr["Length"] = gvrow.Cells[2].Text;
        //                 dr["Color"] = gvrow.Cells[4].Text;
        //                 dr["Qty"] = gvrow.Cells[5].Text;

        //                 dr["SeriesID"] = gvrow.Cells[13].Text;
        //                 dr["Amount"] = gvrow.Cells[12].Text;
        //                 dr["CustomerName"] = gvrow.Cells[11].Text;
        //                 dr["CustId"] = gvrow.Cells[12].Text;

        //                 dr["ReceivedQty"] = gvrow.Cells[9].Text;
        //                 dr["RemainingQty"] = gvrow.Cells[10].Text;

        //                 dr["Kgpermtr"] = gvrow.Cells[6].Text;
        //                 dr["TotalWeight"] = gvrow.Cells[7].Text;
        //                 dr["AlumiumCoating"] = gvrow.Cells[8].Text;

        //                 dr["PlantId"] = gvrow.Cells[14].Text;
        //                 dr["StorageLoc"] = gvrow.Cells[15].Text;
        //                 dr["Stocktype"] = gvrow.Cells[16].Text;

        //                 SuppliersFixedPOItems.Rows.Add(dr);
        //             }
        //         }
        //         else
        //         {
        //             DataRow dr = SuppliersFixedPOItems.NewRow();
        //             dr["Series"] = gvrow.Cells[1].Text;
        //             dr["Description"] = gvrow.Cells[3].Text;
        //             dr["Length"] = gvrow.Cells[2].Text;
        //             dr["Color"] = gvrow.Cells[4].Text;
        //             dr["Qty"] = gvrow.Cells[5].Text;

        //             dr["SeriesID"] = gvrow.Cells[13].Text;
        //             dr["Amount"] = gvrow.Cells[12].Text;
        //             dr["CustomerName"] = gvrow.Cells[11].Text;
        //             dr["CustId"] = gvrow.Cells[12].Text;

        //             dr["ReceivedQty"] = gvrow.Cells[9].Text;
        //             dr["RemainingQty"] = gvrow.Cells[10].Text;

        //             dr["Kgpermtr"] = gvrow.Cells[6].Text;
        //             dr["TotalWeight"] = gvrow.Cells[7].Text;
        //             dr["AlumiumCoating"] = gvrow.Cells[8].Text;
        //             dr["PlantId"] = gvrow.Cells[14].Text;
        //             dr["StorageLoc"] = gvrow.Cells[15].Text;
        //             dr["Stocktype"] = gvrow.Cells[16].Text;
        //             SuppliersFixedPOItems.Rows.Add(dr);
        //         }
        //     }
        // }

        // GridView1.DataSource = SuppliersFixedPOItems;
        // GridView1.DataBind();
        //// GridView1.SelectedIndex = -1;
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //this.GridView1.EditIndex = -1;
        //GridView1.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SCM.PurchaseReceipt objSM = new SCM.PurchaseReceipt();
            objSM.SPrNo = txtPreceiptno.Text;
            objSM.SPrDate = General.toMMDDYYYY(txtPrDate.Text);
            objSM.POid = ddlPono.SelectedItem.Value;

            objSM.Preparedby = ddlpreparedby.SelectedItem.Value;
            objSM.approvedby = "0";
            objSM.Remarks = txtremarks.Text;
            objSM.VehicalNo = txtVehicalNo.Text;
            objSM.CheckedBy = ddlCheckedBy.SelectedItem.Value;
            if (objSM.PurchaseReceipt_Save() == "Data Saved Successfully")
            {
                objSM.PurchaseReceiptDetails_Delete(objSM.SPrId);
                foreach (GridViewRow gvrow in GridView1.Rows)
                {


                    TextBox recqty = (TextBox)gvrow.FindControl("txtRECEIVEDQTY");
                    objSM.receivedqty = recqty.Text;

                    if(objSM.receivedqty != "0")
                    { 

                    objSM.matid = gvrow.Cells[10].Text;
                    //objSM.length = gvrow.Cells[1].Text;
                    objSM.color = gvrow.Cells[2].Text;
                    objSM.orderedqty = gvrow.Cells[4].Text;

                    //objSM.cutid = gvrow.Cells[10].Text;
                  

                    DropDownList plantid = (DropDownList)gvrow.FindControl("ddlPlant");
                    objSM.plantid = plantid.SelectedItem.Value;

                    DropDownList Storloc = (DropDownList)gvrow.FindControl("ddlStoragelocation");
                    objSM.storagelocid = Storloc.SelectedItem.Value;
                    //objSM.stocktype = gvrow.Cells[15].Text;
                    objSM.colorid = gvrow.Cells[11].Text;


                    TextBox rejqty = (TextBox)gvrow.FindControl("txtRejectedQTY");
                    objSM.rEJECTEDQTY = rejqty.Text;

                    TextBox Acceptedqty = (TextBox)gvrow.FindControl("txtAcceptedQTY");
                    objSM.aCCEPTEDQTY = Acceptedqty.Text;

                    objSM.podetid = gvrow.Cells[14].Text;

                    objSM.length = gvrow.Cells[15].Text;



                    objSM.PurchaseReceiptDetails_Save();

                    objSM.PurchaseOrderDetailsRemainingQty_Update(objSM.podetid, objSM.aCCEPTEDQTY);

                    objSM.Stock_Update1(objSM.matid, objSM.aCCEPTEDQTY, objSM.plantid, objSM.colorid, objSM.storagelocid,objSM.length);
              
                
                  if(objSM.rEJECTEDQTY != "0")
                  {
                      objSM.ScrapStock_Update1(objSM.matid, objSM.aCCEPTEDQTY, objSM.plantid, objSM.colorid, objSM.storagelocid, objSM.length);
              
                  }

                    }
                
                
                }

               
            }
            MessageBox.Show(this, "Data Saved Successfully");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
        }
    }

    protected void ddlPlant_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlPlant = (DropDownList)sender;
        string plant = ddlPlant.SelectedValue;
        GridViewRow row = (GridViewRow)ddlPlant.NamingContainer;

        DropDownList ddlStoragelocation = (DropDownList)row.FindControl("ddlStoragelocation");
        Masters.StorageLocation.PlantStorageLocation_Select(ddlStoragelocation, plant);
    }
}