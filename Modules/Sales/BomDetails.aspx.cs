using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using phaniDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_BomDetails : System.Web.UI.Page
{


    DataTable dt = new DataTable();
    static DBManager dbManager = new DBManager(DataProvider.SqlServer, DBConString.ConnectionString());
    private static int _returnIntValue;
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
        UpdatePanelControlTrigger trigger = new PostBackTrigger();
        trigger.ControlID = btnfileUpload.UniqueID;
        updatePanel.Triggers.Add(trigger);
        if (!IsPostBack)
        {
            if (Qid != "")
            {
                SM.SalesOrder.SalesOrder_Select(ddlsono);
                SM.CustomerMaster.CustomerMaster_Select(ddlCustomer);
                Masters.ColorMaster.Color_Select(ddlColor);
                Masters.MaterialMaster.MaterialMaster_Select(ddlitemCode);
          
                //fill();
              //  GVBind();
            }
        }
    }

    protected void ddlsono_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesOrder obj = new SM.SalesOrder();

        if (obj.SalesOrder_Select(ddlsono.SelectedItem.Value) > 0)
        {
            txtDeliveryDate.Text = obj.Deliverydate;
            txtSalesorderdate.Text = obj.SODATE;
            ddlCustomer.SelectedValue = obj.Custid;
            ddlunitid.SelectedValue = obj.SiteId;
        }
    }


    protected void btnfileUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
                string filename = FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath(filename));
                ExportToGrid(Server.MapPath(filename));
            }
            else
            {
                MessageBox.Show(this, "File Not exist");
            }
        }

    private void ExportToGrid(string path)
    {
        OleDbConnection MyConnection = null;
        DataSet DtSet = null;
        OleDbDataAdapter MyCommand = null;
        MyConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties=Excel 12.0;");


        MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
        DtSet = new System.Data.DataSet();
        MyCommand.Fill(DtSet, "[Sheet1$]");
        dt = DtSet.Tables[0];
        MyConnection.Close();

        General obj = new General();

        if (dt.Rows.Count > 0)
        {
            bool found = false;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.ItemArray[5].ToString() == "")
                {
                    found = true;
                    MessageBox.Show(this, "Please Check Excel Having Correct Values");
                    break;
                }

                else
                {

                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    if (!found)
                    //    {

                    string ItemCode = "0";
                    string ColorId = "0";

                    string Barlength, Color;

                    if (dr.ItemArray[2].ToString() == "")
                    {
                        Barlength = "0";
                    }
                    else
                    {
                        Barlength = dr.ItemArray[2].ToString();
                    }
                    if (dr.ItemArray[7].ToString() == "")
                    {
                        Color = "NA";
                    }
                    else
                    {
                        Color = dr.ItemArray[7].ToString();
                    }
                    // Getting ItemCode
                    string sql = @"select Material_Id  from  Material_Master where Material_Code = '" + Convert.ToString(dr.ItemArray[5]).Trim().ToString() + "' ";
                    DataTable dttemp = obj.ReturnDataTable(sql);
                    if (dttemp.Rows.Count > 0)
                    {
                        ItemCode = dttemp.Rows[0]["Material_Id"].ToString();
                        //gETTING cOLOR iD

                        string sql1 = @"select Color_Id  from  Color_Master where Color_Name = '" + Convert.ToString(dr.ItemArray[7]).Trim().ToString() + "' ";
                        DataTable dttemp1 = obj.ReturnDataTable(sql1);
                        if (dttemp1.Rows.Count > 0)
                        {
                            ColorId = dttemp1.Rows[0]["Color_Id"].ToString();
                        }
                        else
                        {
                            ColorId = "0";
                        }

                        sql = @"insert into SalesOrder_MaterialAnalysis(SO_ID,	QUANTITY,PU, BARLENGTH,	REQUIRED_QTY,UNIT,DESCRIPTION,COLOR,WEIGHT,ITEMCODE,ITEMCODE_ID,COLOR_ID)
                                values('" + ddlsono.SelectedItem.Value + "', '" + dr.ItemArray[0].ToString() + "','" + dr.ItemArray[1].ToString() + "','" + Barlength + "','" + dr.ItemArray[3].ToString() + "','" + dr.ItemArray[4].ToString() + "','" + dr.ItemArray[6].ToString() + "','" + dr.ItemArray[7].ToString() + "','" + "0" + "','" + dr.ItemArray[5].ToString() + "','" + ItemCode + "','" + ColorId + "') ";
                        obj.ReturnExecuteNoneQuery(sql);

                    }
                    else
                    {
                        string Code = Convert.ToString(dr.ItemArray[5]).Trim().ToString();
                        SM.SalesOrder smobjj = new SM.SalesOrder();
                        smobjj.SalesOrderMaterialAnalysisDetails_Delete(Request.QueryString["Cid"].ToString());

                        //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Item Code Missing "+Code+"')", true);


                        MessageBox.Show(this, "Item Code Missing " + Code + "");



                        break;
                    }

                    //    }

                    //}



                }





            }









            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }






    protected void btnadditem_Click(object sender, EventArgs e)
    {
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ITEMCODE");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("QUANTITY");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("PU");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("BARLENGTH");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("REQUIRED_QTY");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("UNIT");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("COLOR");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ITEMCODE_ID");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("COLOR_ID");
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
                        dr["ITEMCODE"] = ddlitemCode.SelectedItem.Text;
                        dr["QUANTITY"] = txtQty.Text;
                        dr["PU"] = txtpu.Text;
                        dr["BARLENGTH"] = txtitemtLength.Text;
                        dr["REQUIRED_QTY"] = txtQty.Text;
                        dr["UNIT"] = txtUom.Text;
                        dr["COLOR"] = ddlColor.SelectedItem.Value;
                        dr["ITEMCODE_ID"] = ddlitemCode.SelectedItem.Value;
                        dr["COLOR_ID"] = ddlColor.SelectedItem.Value;
                      

                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                       
                        dr["ITEMCODE"] = gvrow.Cells[1].Text;
                        dr["QUANTITY"] = gvrow.Cells[2].Text;
                        dr["PU"] = gvrow.Cells[3].Text;
                        dr["BARLENGTH"] = gvrow.Cells[4].Text;
                        dr["REQUIRED_QTY"] = gvrow.Cells[5].Text;
                        dr["UNIT"] = gvrow.Cells[6].Text;
                        dr["COLOR"] = gvrow.Cells[7].Text;
                        dr["ITEMCODE_ID"] = gvrow.Cells[8].Text;
                        dr["COLOR_ID"] = gvrow.Cells[9].Text;
                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ITEMCODE"] = gvrow.Cells[1].Text;
                    dr["QUANTITY"] = gvrow.Cells[2].Text;
                    dr["PU"] = gvrow.Cells[3].Text;
                    dr["BARLENGTH"] = gvrow.Cells[4].Text;
                    dr["REQUIRED_QTY"] = gvrow.Cells[5].Text;
                    dr["UNIT"] = gvrow.Cells[6].Text;
                    dr["COLOR"] = gvrow.Cells[7].Text;
                    dr["ITEMCODE_ID"] = gvrow.Cells[8].Text;
                    dr["COLOR_ID"] = gvrow.Cells[9].Text;

                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }

        if (gvItems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["ITEMCODE"] = ddlitemCode.SelectedItem.Text;
            drnew["QUANTITY"] = txtQty.Text;
            drnew["PU"] = txtpu.Text;
            drnew["BARLENGTH"] = txtitemtLength.Text;
            drnew["REQUIRED_QTY"] = txtQty.Text;
            drnew["UNIT"] = txtUom.Text;
            drnew["COLOR"] = ddlColor.SelectedItem.Text;
            drnew["ITEMCODE_ID"] = ddlitemCode.SelectedItem.Value;
            drnew["COLOR_ID"] = ddlColor.SelectedItem.Value;
            SalesOrderItems.Rows.Add(drnew);
        }
        gvItems.DataSource = SalesOrderItems;
        gvItems.DataBind();
        gvItems.SelectedIndex = -1;
    }
    protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvItems.Rows[e.RowIndex].Cells[0].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ITEMCODE");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("QUANTITY");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("PU");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("BARLENGTH");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("REQUIRED_QTY");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("UNIT");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("COLOR");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ITEMCODE_ID");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("COLOR_ID");
        SalesOrderItems.Columns.Add(col);
        if (gvItems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvItems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ITEMCODE"] = gvrow.Cells[1].Text;
                    dr["QUANTITY"] = gvrow.Cells[2].Text;
                    dr["PU"] = gvrow.Cells[3].Text;
                    dr["BARLENGTH"] = gvrow.Cells[4].Text;
                    dr["REQUIRED_QTY"] = gvrow.Cells[5].Text;
                    dr["UNIT"] = gvrow.Cells[6].Text;
                    dr["COLOR"] = gvrow.Cells[7].Text;
                    dr["ITEMCODE_ID"] = gvrow.Cells[8].Text;
                    dr["COLOR_ID"] = gvrow.Cells[9].Text;

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
        if (obj.MaterialType_Select(ddlitemCode.SelectedItem.Value) > 0)
        {
          
            txtUom.Text = obj.UomName;
            txtitemtLength.Text = obj.BarLength;
            txtpu.Text = obj.Boxsize;
            txtdescription.Text = obj.Description;
        }
    }
    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[8].Visible = false;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
}