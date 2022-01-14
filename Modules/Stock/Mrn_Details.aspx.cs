using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System.Globalization;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Threading;
public partial class Modules_Stock_Mrn_Details : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
           
           




            SCM.SupPo.SupPo_Select(ddlPono);
            txtPreceiptno.Text = SCM.PurchaseReceipt.PurchaseReceipt_AutoGenCode();
            txtPrDate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtinvoicedate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlCheckedBy);
            ddlpreparedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            BindData();


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
            txtVendorContactPerson.Text = System.Web.HttpUtility.HtmlDecode(obj.SContact);
           // txtvendorContactNo.Text = obj.Smobile;

            txtPoDate.Text = obj.PoDate;

            //obj.SupPoOrder_Select(ddlPono.SelectedItem.Value, GridView1);
            // obj.SupPoOrderQtyNotZero_Select(ddlPono.SelectedItem.Value, GridView1);
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
            //e.Row.Cells[1].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[10].Visible = false;

            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;

            e.Row.Cells[17].Visible = false;
            e.Row.Cells[19].Visible = false;
            e.Row.Cells[20].Visible = false;

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlPlant = (DropDownList)e.Row.FindControl("ddlPlant");
            Masters.Plant.Plant_Select(ddlPlant);
            DropDownList ddlStoragelocation = (DropDownList)e.Row.FindControl("ddlStoragelocation");
            Masters.StorageLocation.StorageLocation_Select(ddlStoragelocation);
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

            //objSM.Invoiceno = ddl
            objSM.Invoiceno = txtinoviceno.Text;
            objSM.Invoicedate = General.toMMDDYYYY(txtinvoicedate.Text);

            objSM.PoNos = txtponos.Text;

            if (objSM.PurchaseReceipt_Save() == "Data Saved Successfully")
            {
                objSM.PurchaseReceiptDetails_Delete(objSM.SPrId);
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    TextBox recqty = (TextBox)gvrow.FindControl("txtRECEIVEDQTY");
                    objSM.receivedqty = recqty.Text;
                    if (objSM.receivedqty != "0")
                    {
                        objSM.matid = gvrow.Cells[11].Text;
                        //objSM.length = gvrow.Cells[1].Text;
                        objSM.color = gvrow.Cells[2].Text;
                        objSM.orderedqty = gvrow.Cells[5].Text;
                        //objSM.cutid = gvrow.Cells[10].Text;
                        DropDownList plantid = (DropDownList)gvrow.FindControl("ddlPlant");
                        if (plantid.SelectedItem.Value != "0")
                        {
                            objSM.plantid = plantid.SelectedItem.Value;
                        }
                        else
                        {
                            objSM.plantid = "1";
                        }




                        DropDownList Storloc = (DropDownList)gvrow.FindControl("ddlStoragelocation");

                        if (Storloc.SelectedItem.Value != "0")
                        {
                            objSM.storagelocid = Storloc.SelectedItem.Value;
                        }
                        else
                        {
                            objSM.storagelocid = "1";
                        }




                        //objSM.stocktype = gvrow.Cells[15].Text;
                        objSM.colorid = gvrow.Cells[12].Text;


                        TextBox rejqty = (TextBox)gvrow.FindControl("txtRejectedQTY");
                        objSM.rEJECTEDQTY = rejqty.Text;

                        TextBox Acceptedqty = (TextBox)gvrow.FindControl("txtAcceptedQTY");
                        objSM.aCCEPTEDQTY = Acceptedqty.Text;

                        objSM.podetid = gvrow.Cells[16].Text;

                        objSM.length = gvrow.Cells[4].Text;


                        DropDownList Instock = (DropDownList)gvrow.FindControl("ddlInstock");

                        objSM.Instock = Instock.SelectedItem.Value;


                        TextBox itemremarks = (TextBox)gvrow.FindControl("txtitemremarks");
                        objSM.itemremarks = itemremarks.Text;

                        objSM.Soid = gvrow.Cells[19].Text;

                        objSM.Description = gvrow.Cells[1].Text;


                        objSM.DetPOId = gvrow.Cells[20].Text;

                        objSM.PurchaseReceiptDetails_Save();


                        if (objSM.Instock == "InStock")
                        {
                            objSM.Stock_Update1(objSM.matid, objSM.aCCEPTEDQTY, objSM.plantid, objSM.colorid, objSM.storagelocid, objSM.length);
                        }

                        objSM.PurchaseOrderDetailsRemainingQty_Update(objSM.podetid, objSM.aCCEPTEDQTY);



                        if (objSM.rEJECTEDQTY != "0")
                        {
                           // objSM.ScrapStock_Update1(objSM.matid, objSM.aCCEPTEDQTY, objSM.plantid, objSM.colorid, objSM.storagelocid, objSM.length);
                            objSM.MRNRejectedDetails_Save();
                        }


                        TextBox txtblockqty = (TextBox)gvrow.FindControl("txtblockqty");
                        objSM.BlockQty = txtblockqty.Text;


                        if (objSM.Soid != "0")
                        {

                            if (objSM.BlockQty != "0")
                            {
                                objSM.BlockStock_Update1(objSM.matid, objSM.BlockQty, objSM.colorid, objSM.length, objSM.Soid);
                            }
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


            SCM.ClearControls(this);
            SCM.Dispose();
            Response.Redirect("~/Modules/Stock/PurchaseGoodsReceipt.aspx");


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



    private void BindData()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString()))
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT Sup_PO_No,Sup_PO_Id FROM [Supplier_Po_Master] where ApprovedBy != '0' ORDER BY Sup_PO_Id desc";
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                // BIND THE SELECT DROP-DOWN LIST WITH A DATABASE TABLE.
                Books.DataSource = dt;
                Books.DataTextField = "Sup_PO_No";
                Books.DataValueField = "Sup_PO_Id";

                Books.DataBind();

                // FOR MULTIPLE SELECTION. SET THE VALUE AS FALSE, AND SEE WHAT HAPPENS.
                Books.Multiple = true;
            }
        }


        // SM.CustomerMaster.CustomerMaster_Select(Books);


    }



    protected void Button1_Click(object sender, EventArgs e)
    {


      

        txtponos.Text = string.Empty;
        SCM.SupPo obj = new SCM.SupPo();
        string condition = string.Empty;
        string pons = string.Empty;
        //GridView1.DataSource = null;
        //GridView1.DataBind();


        foreach (ListItem item in Books.Items)
        {
            condition += item.Selected ? string.Format("'{0}',", item.Value) : string.Empty;
            pons += item.Selected ? string.Format("{0},", item.Text) : string.Empty;

        }

        if (!string.IsNullOrEmpty(condition))
        {
            condition = string.Format("and [Supplier_Po_Details].Sup_PO_Id IN ({0})", condition.Substring(0, condition.Length - 1));
            txtponos.Text = pons.Substring(0, pons.Length - 1);

        }

        if(condition != "")
        {
            obj.MultiSupPoOrderQtyNotZero_Select(condition, GridView1);
        }
        else
        {
            MessageBox.Show(this, "Please Select PO No");
        }


        
      
    }

}