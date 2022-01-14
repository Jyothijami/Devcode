using phani.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_BLockedItemDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string Qid = Request.QueryString["Cid"].ToString();


            if (Qid != "0")
            {


                General.GridBindwithCommand(hai, " SELECT Stock_Block.BlockStock_Id, Sales_Order.SalesOrder_No, Color_Master.Color_Name, Material_Master.Material_Code, Material_Master.Description, Uom_Master.UOM_SHORT_DESC, Stock_Block.Length as blocklength, " +
                            " Stock_Block.Qty, Stock_Block.Remarks, Sales_Order.ProjectCode, Customer_Master.CUST_NAME, Customer_Units.CUST_UNIT_NAME  " +
            "FROM Stock_Block LEFT OUTER JOIN  " +
                           "  Sales_Order ON Stock_Block.So_Id = Sales_Order.SalesOrder_Id LEFT OUTER JOIN  " +
                           "  Color_Master ON Stock_Block.Color_Id = Color_Master.Color_Id LEFT OUTER JOIN  " +
                          "   Material_Master ON Stock_Block.Item_Code = Material_Master.Material_Id LEFT OUTER JOIN  " +
                          "   Customer_Units ON Stock_Block.Project_Id = Customer_Units.CUST_UNIT_ID LEFT OUTER JOIN  " +
                          "   Customer_Master ON Stock_Block.Cust_Id = Customer_Master.CUST_ID LEFT OUTER JOIN  " +
                           "  Uom_Master ON Material_Master.UOM_Id = Uom_Master.UOM_ID where   Stock_Block.Item_Code = '" + Request.QueryString["Cid"].ToString() + "' and Stock_Block.Color_Id = '" + Request.QueryString["ColorId"].ToString() + "' and Stock_Block.Length = '" + Request.QueryString["Length"].ToString() + "' and Stock_Block.Qty > '0' ");






               General.GridBindwithCommand(GridView1,"SELECT Supplier_PurchaseReceipt_Details.SPR_DET_ID, Supplier_PurchaseReceipt_Details.SPR_ID, Supplier_PurchaseReceipt_Details.MAT_ID, Supplier_PurchaseReceipt_Details.PO_DET_COLOR,  " +
                        " Supplier_PurchaseReceipt_Details.PO_DET_QTY, Supplier_PurchaseReceipt_Details.PO_RECEIVED_QTY, Supplier_PurchaseReceipt_Details.PLANT_ID, Supplier_PurchaseReceipt_Details.STORAGELOC_ID,  " +
                        " Supplier_PurchaseReceipt_Details.COLOR_ID, Supplier_PurchaseReceipt_Details.PO_ACCEPTED_QTY, Supplier_PurchaseReceipt_Details.PO_REJECTED_QTY, Supplier_PurchaseReceipt_Details.InStock, " +
                        " Supplier_PurchaseReceipt_Details.Remarks, Supplier_PurchaseReceipt_Details.SO_Id, Supplier_PurchaseReceipt_Details.Description, Supplier_PurchaseReceipt_Details.Lengthh, " +
                       "  Supplier_PurchaseReceipt_Details.PO_Id, Supplier_PurchaseReceipt.SPR_NO, Supplier_PurchaseReceipt.SPR_DATE, Supplier_PurchaseReceipt.InvoiceNo, Color_Master.Color_Name, " +
                        " Material_Master.Material_Code,Material_Master.Material_Code, Sales_Order.ProjectCode " +
                        " FROM   Supplier_PurchaseReceipt_Details INNER JOIN " +
                        " Color_Master ON Supplier_PurchaseReceipt_Details.COLOR_ID = Color_Master.Color_Id INNER JOIN " +
                        " Supplier_PurchaseReceipt ON Supplier_PurchaseReceipt_Details.SPR_ID = Supplier_PurchaseReceipt.SPR_ID INNER JOIN " +
                        " Material_Master ON Supplier_PurchaseReceipt_Details.MAT_ID = Material_Master.Material_Id INNER JOIN " + 
                        " Sales_Order ON Supplier_PurchaseReceipt_Details.SO_Id = Sales_Order.SalesOrder_Id " +
                        " WHERE (Supplier_PurchaseReceipt_Details.MAT_ID = '" + Request.QueryString["Cid"].ToString() + "') AND (Supplier_PurchaseReceipt_Details.COLOR_ID = '" + Request.QueryString["ColorId"].ToString() + "') AND (Supplier_PurchaseReceipt_Details.Lengthh = '" + Request.QueryString["Length"].ToString() + "')");












            }

        }
    }
}