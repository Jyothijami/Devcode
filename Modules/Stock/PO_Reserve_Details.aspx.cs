using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI.WebControls;


public partial class Modules_Stock_PO_Reserve_Details : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            SM.SalesOrder.SalesOrder_Selectforblock(ddlsono);
            SM.CustomerMaster.CustomerMaster_Select(ddlCustomer);
            Masters.ColorMaster.Color_Select(ddlColor);
            Masters.MaterialMaster.ItemStock_Select(ddlitemCode);
            SM.CustomerMaster.CustomerUnit_Select(ddlunitid);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            ddlpreparedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

           // txtSalesorderdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            txtrerservestockno.Text = SCM.ReserveStock.ReserveStock_AutoGenCode();
            txtreservedate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            
            if (Qid != "Add")
            {
                FillOrder();
                SM.SalesOrder.SalesOrder_Select(ddlsono);
            }
        }
    }

    private void FillOrder()
    {
        
    }

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ITEMCODE");
        dt.Columns.Add("BARLENGTH");
        dt.Columns.Add("UNIT");
        dt.Columns.Add("COLOR");
        dt.Columns.Add("ITEMCODE_ID");
        dt.Columns.Add("COLOR_ID");
        dt.Columns.Add("SO_MATANA_ID");
        dt.Columns.Add("PrevBlockedStock");
        dt.Columns.Add("AvailableStocktoBlock");
        dt.Columns.Add("ReserveQty");
        dt.Columns.Add("QUANTITY");
        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("SO_MATANA_ID = '" + gvRow.Cells[15].Text + "'");

        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["ITEMCODE"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["BARLENGTH"] = gvRow.Cells[4].Text;
            dt.Rows[dt.Rows.Count - 1]["UNIT"] = gvRow.Cells[6].Text;

            if (gvRow.Cells[6].Text.Contains("&amp;"))
            {
                dt.Rows[dt.Rows.Count - 1]["COLOR"] = gvRow.Cells[6].Text.Replace("&amp;", "&").Trim();
            }
            else
            {
                dt.Rows[dt.Rows.Count - 1]["COLOR"] = gvRow.Cells[3].Text.Trim();
            }
            dt.Rows[dt.Rows.Count - 1]["ITEMCODE_ID"] = gvRow.Cells[12].Text;
            dt.Rows[dt.Rows.Count - 1]["COLOR_ID"] = gvRow.Cells[13].Text;
            dt.Rows[dt.Rows.Count - 1]["SO_MATANA_ID"] = gvRow.Cells[15].Text;


            if (gvRow.Cells[4].Text != "0")
            {
                dt.Rows[dt.Rows.Count - 1]["QUANTITY"] = gvRow.Cells[5].Text;
            }
            else
            {
                dt.Rows[dt.Rows.Count - 1]["QUANTITY"] = gvRow.Cells[7].Text;
            }


            
            dt.Rows[dt.Rows.Count - 1]["PrevBlockedStock"] = gvRow.Cells[9].Text;
            dt.Rows[dt.Rows.Count - 1]["AvailableStocktoBlock"] = gvRow.Cells[10].Text;


            dt.Rows[dt.Rows.Count - 1]["ReserveQty"] = "";

            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("SO_MATANA_ID = '" + gvRow.Cells[15].Text + "'");
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
        CheckBox chkAll = (CheckBox)gvQuatationItems.HeaderRow
                            .Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvQuatationItems.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvQuatationItems.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvQuatationItems.Rows[i]
                                .Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    dt = AddRow(gvQuatationItems.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRow(gvQuatationItems.Rows[i], dt);
                }
            }
        }
        ViewState["SelectedRecords"] = dt;
    }

    private void SetData()
    {
        CheckBox chkAll = (CheckBox)gvQuatationItems.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        if (ViewState["SelectedRecords"] != null)
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            for (int i = 0; i < gvQuatationItems.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvQuatationItems.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    DataRow[] dr = dt.Select("SO_MATANA_ID = '" + gvQuatationItems.Rows[i].Cells[15].Text + "'");
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
        gvItems.DataSource = dt;
        gvItems.DataBind();
    }

    protected void ddlsono_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesOrder obj = new SM.SalesOrder();
        if (obj.SalesOrder_Select(ddlsono.SelectedItem.Value) > 0)
        {
            txtSalesorderdate.Text = obj.SODATE;
            ddlCustomer.SelectedValue = obj.Custid;
            ddlunitid.SelectedValue = obj.SiteId;


            //General.GridBindwithCommand(gvQuatationItems, "SELECT *, TotalStock = (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID),PrevBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID and B.So_MatId = C.SO_MATANA_ID),TotalBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID ),AvailableStocktoBlock = case when ((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID) - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID )) < 0 then 0 else((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID) - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID )) end FROM SalesOrder_MaterialAnalysis C  where c.SO_ID ='" + ddlsono.SelectedItem.Value + "' order by SO_MATANA_ID desc");

            //General.GridBindwithCommand(gvQuatationItems, "SELECT *,TotalStock = (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID and O.Length = C.BARLENGTH),PrevBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID and B.Length = C.BARLENGTH and B.So_Id = C.SO_ID),TotalBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID and B.Length = C.BARLENGTH),AvailableStocktoBlock = case when ((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID and O.Length = C.BARLENGTH) - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID and B.Length = C.BARLENGTH )) < 0 then 0 else((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID and O.Length = C.BARLENGTH) - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID and B.Length = C.BARLENGTH)) end FROM SalesOrder_MaterialAnalysis C  where c.SO_ID ='" + ddlsono.SelectedItem.Value + "' order by SO_MATANA_ID desc");
            //General.GridBindwithCommand(gvQuatationItems, "USP_BOM_Serach");

            gvQuotation();
            
            General.GridBindwithCommand(gvalready,"SELECT BlockStock_Id, Stock_Reserve.Stock_Reserve_No, Stock_Reserve.Stock_Reserve_Date, Material_Master.Material_Code,Description, Color_Name, Qty,Customer_Units.CUST_UNIT_NAME, Sales_Order.SalesOrder_No FROM Stock_Reserve INNER JOIN Material_Master INNER JOIN Stock_Block ON Material_Master.Material_Id = Stock_Block.Item_Code INNER JOIN Color_Master ON Stock_Block.Color_Id = Color_Master.Color_Id ON Stock_Reserve.Stock_Reserve_Id = Stock_Block.StockReserve_Id INNER JOIN Customer_Units INNER JOIN Sales_Order ON Customer_Units.CUST_UNIT_ID = Sales_Order.CustSiteId ON Stock_Reserve.So_Id = Sales_Order.SalesOrder_Id INNER JOIN Employee_Master ON Stock_Reserve.PreparedBy = Employee_Master.EMP_ID where Stock_Reserve.So_Id ='"+ddlsono.SelectedItem.Value+"'");
            
            //  General.GridBindwithCommand(gvQuatationItems, "SELECT *, " +
          // "TotalStock = (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID)," +
          // "PrevBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID and B.So_MatId = C.SO_MATANA_ID)," +
          // "TotalBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID )," +
          // "AvailableStocktoBlock = case when ((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID) - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID )) < 0 then 0" +
          //"else" +
          //"((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID) - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID ))" +
          //"end" +
          //"FROM SalesOrder_MaterialAnalysis C  where c.SO_ID = 1");
        }
    }
    private void gvQuotation()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("[USP_BOM_Serach]", con);
            cmd.CommandType = CommandType.StoredProcedure;

            if (ddlsono.SelectedValue != "0")
            {
                cmd.Parameters.AddWithValue("@SOID", ddlsono.SelectedItem.Value);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvQuatationItems.DataSource = dt;
            gvQuatationItems.DataBind();
        }
        catch (Exception ex) { }
    }
    protected void gvQuatationItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
        }



        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Length = e.Row.Cells[4].Text;
            string PU = e.Row.Cells[6].Text;
            decimal shortage = 0;

            decimal blcpfree = 0;

            if (Length != "0")
            {


                blcpfree = decimal.Parse(e.Row.Cells[9].Text) + decimal.Parse(e.Row.Cells[10].Text);

                shortage = decimal.Parse(e.Row.Cells[5].Text) - blcpfree;

                if (shortage < 0)
                {
                    e.Row.Cells[11].Text = "0";
                }
                else
                {
                    e.Row.Cells[11].Text = shortage.ToString();
                    e.Row.Cells[11].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[11].ForeColor = System.Drawing.Color.White;

                }



            }


            if (Length == "0")
            {


                blcpfree = decimal.Parse(e.Row.Cells[9].Text) + decimal.Parse(e.Row.Cells[10].Text);

                shortage = decimal.Parse(e.Row.Cells[7].Text) - blcpfree;

                if (shortage < 0)
                {
                    e.Row.Cells[11].Text = "0";
                }
                else
                {
                    e.Row.Cells[11].Text = shortage.ToString();
                    e.Row.Cells[11].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[11].ForeColor = System.Drawing.Color.White;
                }

            }

        }


        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string Length = e.Row.Cells[6].Text;
        //    string PU = e.Row.Cells[4].Text;
        //    decimal shortage = 0;

        //    decimal blcpfree = 0;

        //    if (Length != "0")
        //    {


        //        blcpfree = decimal.Parse(e.Row.Cells[14].Text) + decimal.Parse(e.Row.Cells[15].Text);

        //        shortage = decimal.Parse(e.Row.Cells[3].Text) - blcpfree;

        //        if (shortage < 0)
        //        {
        //            e.Row.Cells[16].Text = "0";
        //        }
        //        else
        //        {
        //            e.Row.Cells[16].Text = shortage.ToString();
        //            e.Row.Cells[16].BackColor = System.Drawing.Color.Red;
        //            e.Row.Cells[16].ForeColor = System.Drawing.Color.White;

        //        }



        //    }


        //    if (Length == "0")
        //    {


        //        blcpfree = decimal.Parse(e.Row.Cells[14].Text) + decimal.Parse(e.Row.Cells[15].Text);

        //        shortage = decimal.Parse(e.Row.Cells[5].Text) - blcpfree;

        //        if (shortage < 0)
        //        {
        //            e.Row.Cells[16].Text = "0";
        //        }
        //        else
        //        {
        //            e.Row.Cells[16].Text = shortage.ToString();
        //            e.Row.Cells[16].BackColor = System.Drawing.Color.Red;
        //            e.Row.Cells[16].ForeColor = System.Drawing.Color.White;
        //        }

        //    }

        //}









       
    }

    protected void ddlitemCode_SelectedIndexChanged(object sender, EventArgs e)
    {



        
        Masters.MaterialMaster obj = new Masters.MaterialMaster();
        if (obj.MaterialType_Select(ddlitemCode.SelectedItem.Value) > 0)
        {
            txtAvailableStocktoBlock.Text = "";
            txtpreviousBlockedStock.Text = "";
            txtQty.Text = "";

            txtUom.Text = obj.UomName;
            //txtitemtLength.Text = obj.BarLength;
            txtpu.Text = obj.Boxsize;
            txtdescription.Text = obj.Description;

            Masters.MaterialMaster.ColorStock_ModelNoSelect(ddlColor, ddlitemCode.SelectedItem.Value);
            Masters.MaterialMaster.LengthStock_ModelNoSelect(ddllength, ddlitemCode.SelectedItem.Value);

            if(ddlColor.Items.Count > 0)
            {
                ddlColor_SelectedIndexChanged(sender, e);
            }



        }

        //SCM.Stock Stock = new SCM.Stock();
        //if(int.Parse(ddlsono.SelectedItem.Value) > 0)
        //{ 
        //if(Stock.StockAvailableAfterBlock(ddlitemCode.SelectedItem.Value,ddlColor.SelectedItem.Value,ddlsono.SelectedItem.Value) > 0)
        //{
        //    txtpreviousBlockedStock.Text = Stock.PreviousBlockforSo;
        //    txtAvailableStocktoBlock.Text = Stock.TotalavailableStockafterBlock;
        //}
        
        //}
        //else
        //{
        //    if (Stock.StockAvailableAfterBlockWithoutSo(ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value) > 0)
        //    {
        //        txtpreviousBlockedStock.Text = Stock.PreviousBlockforSo;
        //        txtAvailableStocktoBlock.Text = Stock.TotalavailableStockafterBlock;
        //    }
        //    else
        //    {
        //        txtpreviousBlockedStock.Text = "0";
        //        txtAvailableStocktoBlock.Text = "0";
        //    }
        //}
        

    }

    protected void btnadditem_Click(object sender, EventArgs e)
    {



          decimal value = 0 ,pu = 0;
        decimal.TryParse(txtQty.Text,out value);
        decimal.TryParse(txtAvailableStocktoBlock.Text,out pu);


        if(txtblockremarks.Text == "")
        {
            txtblockremarks.Text = "-";
        }


        if (value <= pu)
        {


            DataTable SalesOrderItems = new DataTable();
            DataColumn col = new DataColumn();
            col = new DataColumn("ITEMCODE");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("BARLENGTH");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("UNIT");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("COLOR");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("ITEMCODE_ID");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("COLOR_ID");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("SO_MATANA_ID");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("PrevBlockedStock");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("AvailableStocktoBlock");
            SalesOrderItems.Columns.Add(col);

            col = new DataColumn("QUANTITY");
            SalesOrderItems.Columns.Add(col);
            col = new DataColumn("ReserveQty");
            SalesOrderItems.Columns.Add(col);

            col = new DataColumn("blockremarks");
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
                            dr["BARLENGTH"] = ddllength.SelectedItem.Text;
                            dr["UNIT"] = txtUom.Text;
                            dr["COLOR"] = ddlColor.SelectedItem.Text;
                            dr["ITEMCODE_ID"] = ddlitemCode.SelectedItem.Value;
                            dr["COLOR_ID"] = ddlColor.SelectedItem.Value;
                            dr["SO_MATANA_ID"] = "0";
                            dr["PrevBlockedStock"] = txtpreviousBlockedStock.Text;
                            dr["AvailableStocktoBlock"] = txtAvailableStocktoBlock.Text;
                            TextBox qty = (TextBox)gvrow.FindControl("txtqtytoreserve");
                            dr["ReserveQty"] = txtQty.Text;
                            dr["QUANTITY"] = "0";
                            dr["blockremarks"] = txtblockremarks.Text;

                            SalesOrderItems.Rows.Add(dr);
                        }
                        else
                        {
                            DataRow dr = SalesOrderItems.NewRow();

                            dr["ITEMCODE"] = gvrow.Cells[1].Text;
                            dr["BARLENGTH"] = gvrow.Cells[2].Text;
                            dr["UNIT"] = gvrow.Cells[3].Text;
                            dr["COLOR"] = gvrow.Cells[4].Text;
                            dr["ITEMCODE_ID"] = gvrow.Cells[5].Text;
                            dr["COLOR_ID"] = gvrow.Cells[6].Text;
                            dr["SO_MATANA_ID"] = gvrow.Cells[7].Text;
                            dr["PrevBlockedStock"] = gvrow.Cells[9].Text;
                            dr["AvailableStocktoBlock"] = gvrow.Cells[10].Text;
                            TextBox qty = (TextBox)gvrow.FindControl("txtqtytoreserve");
                            dr["ReserveQty"] = qty.Text;
                            dr["QUANTITY"] = "0";
                            dr["blockremarks"] = gvrow.Cells[12].Text;
                            SalesOrderItems.Rows.Add(dr);
                        }
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["ITEMCODE"] = gvrow.Cells[1].Text;
                        dr["BARLENGTH"] = gvrow.Cells[2].Text;
                        dr["UNIT"] = gvrow.Cells[3].Text;
                        dr["COLOR"] = gvrow.Cells[4].Text;
                        dr["ITEMCODE_ID"] = gvrow.Cells[5].Text;
                        dr["COLOR_ID"] = gvrow.Cells[6].Text;
                        dr["SO_MATANA_ID"] = gvrow.Cells[7].Text;
                        dr["PrevBlockedStock"] = gvrow.Cells[9].Text;
                        dr["AvailableStocktoBlock"] = gvrow.Cells[10].Text;
                        TextBox qty = (TextBox)gvrow.FindControl("txtqtytoreserve");
                        dr["ReserveQty"] = qty.Text;
                        dr["QUANTITY"] = "0";
                        dr["blockremarks"] = gvrow.Cells[12].Text;
                        SalesOrderItems.Rows.Add(dr);
                    }
                }
            }

            if (gvItems.SelectedIndex == -1)
            {
                DataRow drnew = SalesOrderItems.NewRow();
                drnew["ITEMCODE"] = ddlitemCode.SelectedItem.Text;
                drnew["BARLENGTH"] = ddllength.SelectedItem.Text;
                drnew["UNIT"] = txtUom.Text;
                drnew["COLOR"] = ddlColor.SelectedItem.Text;
                drnew["ITEMCODE_ID"] = ddlitemCode.SelectedItem.Value;
                drnew["COLOR_ID"] = ddlColor.SelectedItem.Value;
                drnew["SO_MATANA_ID"] = "0";
                drnew["PrevBlockedStock"] = txtpreviousBlockedStock.Text;
                drnew["AvailableStocktoBlock"] = txtAvailableStocktoBlock.Text;
                drnew["ReserveQty"] = txtQty.Text;

                drnew["QUANTITY"] = "0";
                drnew["blockremarks"] = txtblockremarks.Text;
                SalesOrderItems.Rows.Add(drnew);
            }
            gvItems.DataSource = SalesOrderItems;
            gvItems.DataBind();
            gvItems.SelectedIndex = -1;
            clearitems();

        }
        else
        {
            MessageBox.Show(this, "Blocking Qty More than Stock Qty");
        }

    }

    private void clearitems()
    {
        Masters.ColorMaster.Color_Select(ddlColor);
        Masters.MaterialMaster.ItemStock_Select(ddlitemCode);
        
        txtQty.Text = "";
        txtpu.Text = "";
      //  txtitemtLength.Text = "";
        //txtQty.Text = "";
        txtUom.Text = "";
      
        txtpreviousBlockedStock.Text = "";
        txtAvailableStocktoBlock.Text = "";
        txtdescription.Text = "";
        txtblockremarks.Text = "";
        ddllength.Items.Clear(); 
    }

    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
        }

    }

    protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string x1 = gvItems.Rows[e.RowIndex].Cells[0].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("ITEMCODE");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("BARLENGTH");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("UNIT");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("COLOR");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ITEMCODE_ID");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("COLOR_ID");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SO_MATANA_ID");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("PrevBlockedStock");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("AvailableStocktoBlock");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("QUANTITY");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ReserveQty");
        SalesOrderItems.Columns.Add(col);

        col = new DataColumn("blockremarks");
        SalesOrderItems.Columns.Add(col);


        if (gvItems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvItems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ITEMCODE"] = gvrow.Cells[1].Text;
                    dr["BARLENGTH"] = gvrow.Cells[2].Text;
                    dr["UNIT"] = gvrow.Cells[3].Text;
                    dr["COLOR"] = gvrow.Cells[4].Text;
                    dr["ITEMCODE_ID"] = gvrow.Cells[5].Text;
                    dr["COLOR_ID"] = gvrow.Cells[6].Text;
                    dr["SO_MATANA_ID"] = gvrow.Cells[7].Text;
                    dr["QUANTITY"] = gvrow.Cells[8].Text;
                    dr["PrevBlockedStock"] = gvrow.Cells[9].Text;
                    dr["AvailableStocktoBlock"] = gvrow.Cells[10].Text;
                    TextBox qty = (TextBox)gvrow.FindControl("txtqtytoreserve");
                    dr["ReserveQty"] = qty.Text;

                    dr["blockremarks"] = gvrow.Cells[12].Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvItems.DataSource = SalesOrderItems;
        gvItems.DataBind();



    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (btnSave.Text == "Save")
        {
            ReserveStockSave();
        }
        else if (btnSave.Text == "Update")
        {
            ReserveStockUpdate();
        }
    }

    private void ReserveStockUpdate()
    {
        throw new NotImplementedException();
    }

    private void ReserveStockSave()
    {
        try
        {
            SCM.ReserveStock objSM = new SCM.ReserveStock();
            objSM.Soid = ddlsono.SelectedItem.Value;
            objSM.ReserveDate = General.toMMDDYYYY(txtreservedate.Text);
            objSM.PreparedBy = ddlpreparedby.SelectedItem.Value;
            objSM.ProjectId = ddlunitid.SelectedItem.Value;
            objSM.CustID = ddlCustomer.SelectedItem.Value;

            if (objSM.ReserveStock_Save() == "Data Saved Successfully")
            {
                objSM.ReserveDetails_Delete(objSM.ReserveId);
                foreach (GridViewRow gvrow in gvItems.Rows)
                {
                    objSM.Itemcode = gvrow.Cells[5].Text;
                    objSM.Soid = ddlsono.SelectedItem.Value;
                    objSM.ColorId = gvrow.Cells[6].Text;
                    objSM.SoMatId = gvrow.Cells[7].Text;
                    TextBox Deliveryda = (TextBox)gvrow.FindControl("txtqtytoreserve");
                    objSM.Qty = Deliveryda.Text;
                    objSM.Length = gvrow.Cells[2].Text;
                    objSM.ProjectId = ddlunitid.SelectedItem.Value;
                    objSM.CustID = ddlCustomer.SelectedItem.Value;
                    objSM.Remarks = gvrow.Cells[12].Text;

                    objSM.ReserveDetails_Save();
                    objSM.BlockStock_Update2(objSM.Itemcode, objSM.Qty, objSM.ColorId, objSM.Length,objSM.Soid,objSM.ProjectId,objSM.Remarks);

                }
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);

                // MessageBox.Show(this, "Data Saved Successfully");
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
            Response.Redirect("~/Modules/Stock/PO_Reserve.aspx");
        }
    }

    protected void ddlColor_SelectedIndexChanged(object sender, EventArgs e)
    {


        //Masters.MaterialMaster obj = new Masters.MaterialMaster();
        //if (obj.MaterialType_Select(ddlitemCode.SelectedItem.Value) > 0)
        //{

        //    Masters.MaterialMaster.ColorStock_ModelNoSelect(ddlColor, ddlitemCode.SelectedItem.Value);
        //    Masters.MaterialMaster.LengthStock_ModelNoSelect(ddllength, ddlitemCode.SelectedItem.Value);
        //}

        Masters.MaterialMaster.ItemColorLengthStock_ModelNoSelect(ddllength, ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value);

       if(ddllength.Items.Count > 0)
       {
           ddllength_SelectedIndexChanged(sender, e);
       }


    }
    protected void ddllength_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.Stock Stock = new SCM.Stock();
        //if (int.Parse(ddlsono.SelectedItem.Value) > 0)
        //{
        //    if (Stock.StockAvailableAfterBlock(ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value, ddlsono.SelectedItem.Value) > 0)
        //    {
        //        txtpreviousBlockedStock.Text = Stock.PreviousBlockforSo;
        //        txtAvailableStocktoBlock.Text = Stock.TotalavailableStockafterBlock;
        //    }
        //}

       

        if(Stock.MCLStockAvailable(ddlitemCode.SelectedItem.Value,ddlColor.SelectedItem.Value,ddllength.SelectedItem.Value) > 0)
        {
            txtpu.Text = Stock.TStock;
        }

        if (int.Parse(ddlsono.SelectedItem.Value) > 0)
        {
            if (Stock.SoMCLStockAvailable(ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value,ddllength.SelectedItem.Value, ddlsono.SelectedItem.Value) > 0)
            {
                txtpreviousBlockedStock.Text = Stock.PreviousBlockforSo;
                txtAvailableStocktoBlock.Text = Stock.FreeStock;
            }
            
        }
        else
        {
            if (Stock.freeMCLStockAvailable(ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value, ddllength.SelectedItem.Value) > 0)
            {
                txtpreviousBlockedStock.Text = "0";
                txtAvailableStocktoBlock.Text = Stock.FreeStock;
            }
        }





        //}
        //else
        //{
        //    if (Stock.StockAvailableAfterBlockWithoutSo(ddlitemCode.SelectedItem.Value, ddlColor.SelectedItem.Value) > 0)
        //    {
        //        txtpreviousBlockedStock.Text = Stock.PreviousBlockforSo;
        //        txtAvailableStocktoBlock.Text = Stock.TotalavailableStockafterBlock;
        //    }
        //    else
        //    {
        //        txtpreviousBlockedStock.Text = "0";
        //        txtAvailableStocktoBlock.Text = "0";
        //    }
        //}
    }
    protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.CustomerMaster.CustomerUnit_Select(ddlunitid, ddlCustomer.SelectedItem.Value);
    }
    //protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        string Length = e.Row.Cells[3].Text;
    //        string PU = e.Row.Cells[5].Text;
    //        decimal shortage = 0;

    //        decimal blcpfree = 0;

    //        if (Length != "0")
    //        {


    //            blcpfree = decimal.Parse(e.Row.Cells[8].Text) + decimal.Parse(e.Row.Cells[9].Text);

    //            shortage = decimal.Parse(e.Row.Cells[4].Text) - blcpfree;

    //            if (shortage < 0)
    //            {
    //                e.Row.Cells[10].Text = "0";
    //            }
    //            else
    //            {
    //                e.Row.Cells[10].Text = shortage.ToString();
    //                e.Row.Cells[10].BackColor = System.Drawing.Color.Red;
    //                e.Row.Cells[10].ForeColor = System.Drawing.Color.White;

    //            }



    //        }


    //        if (Length == "0")
    //        {


    //            blcpfree = decimal.Parse(e.Row.Cells[8].Text) + decimal.Parse(e.Row.Cells[9].Text);

    //            shortage = decimal.Parse(e.Row.Cells[6].Text) - blcpfree;

    //            if (shortage < 0)
    //            {
    //                e.Row.Cells[10].Text = "0";
    //            }
    //            else
    //            {
    //                e.Row.Cells[10].Text = shortage.ToString();
    //                e.Row.Cells[10].BackColor = System.Drawing.Color.Red;
    //                e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
    //            }

    //        }

    //    }
    //}
}