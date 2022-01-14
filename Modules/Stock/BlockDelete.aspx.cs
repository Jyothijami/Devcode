using phani.Classes;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_BlockDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          string Qid = Request.QueryString["Cid"].ToString();
          if (!IsPostBack)
          {
              SM.SalesOrder.SalesOrder_Select(ddlsono);
              SM.CustomerMaster.CustomerMaster_Select(ddlCustomer);
              SM.CustomerMaster.CustomerUnit_Select(ddlunitid);

          }
    }

    protected void ddlsono_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesOrder obj = new SM.SalesOrder();
        if (obj.SalesOrder_Select(ddlsono.SelectedItem.Value) > 0)
        {
            // txtSalesorderdate.Text = obj.SODATE;
            ddlCustomer.SelectedValue = obj.Custid;
            ddlunitid.SelectedValue = obj.SiteId;

            //General.GridBindwithCommand(gvQuatationItems, "SELECT *, TotalStock = (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID),PrevBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID and B.So_MatId = C.SO_MATANA_ID),TotalBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID ),AvailableStocktoBlock = case when ((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID) - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID )) < 0 then 0 else((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID) - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID )) end FROM SalesOrder_MaterialAnalysis C  where c.SO_ID ='" + ddlsono.SelectedItem.Value + "' order by SO_MATANA_ID desc");

         //   General.GridBindwithCommand(gvQuatationItems, "SELECT *,TotalStock = (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID and O.Length = C.BARLENGTH),PrevBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID and B.Length = C.BARLENGTH and B.So_Id = C.SO_ID),TotalBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID and B.Length = C.BARLENGTH),AvailableStocktoBlock = case when ((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID and O.Length = C.BARLENGTH) - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID and B.Length = C.BARLENGTH )) < 0 then 0 else((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID and O.Length = C.BARLENGTH) - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID and B.Length = C.BARLENGTH)) end FROM SalesOrder_MaterialAnalysis C  where c.SO_ID ='" + ddlsono.SelectedItem.Value + "' order by SO_MATANA_ID desc");



            General.GridBindwithCommand(gvalready, "SELECT BlockStock_Id, Stock_Reserve.Stock_Reserve_No, Stock_Reserve.Stock_Reserve_Date, Material_Master.Material_Code,Description, Color_Name, Qty,Customer_Units.CUST_UNIT_NAME, Sales_Order.SalesOrder_No FROM Stock_Reserve INNER JOIN Material_Master INNER JOIN Stock_Block ON Material_Master.Material_Id = Stock_Block.Item_Code INNER JOIN Color_Master ON Stock_Block.Color_Id = Color_Master.Color_Id ON Stock_Reserve.Stock_Reserve_Id = Stock_Block.StockReserve_Id INNER JOIN Customer_Units INNER JOIN Sales_Order ON Customer_Units.CUST_UNIT_ID = Sales_Order.CustSiteId ON Stock_Reserve.So_Id = Sales_Order.SalesOrder_Id INNER JOIN Employee_Master ON Stock_Reserve.PreparedBy = Employee_Master.EMP_ID where Stock_Reserve.So_Id ='" + ddlsono.SelectedItem.Value + "'");

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








}