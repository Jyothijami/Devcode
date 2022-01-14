using phani.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_DailyReceipts : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);

        if (!IsPostBack)
        {

            General.GridBindwithCommand(hai, "SELECT Sales_Order.ProjectCode, Supplier_PurchaseReceipt.SPR_NO AS MRN_No, CONVERT(varchar, Supplier_PurchaseReceipt.SPR_DATE, 3) AS [MRN Date], Supplier_Master.SUP_NAME,  Material_Master.Material_Code, Color_Master.Color_Name, Supplier_PurchaseReceipt_Details.Lengthh, Uom_Master.UOM_SHORT_DESC, Supplier_PurchaseReceipt_Details.Description,   Supplier_PurchaseReceipt_Details.PO_ACCEPTED_QTY AS [Accepted Qty], Supplier_PurchaseReceipt.InvoiceNo, CONVERT(varchar, Supplier_PurchaseReceipt.InvoiceDate, 3) AS [Invoice Date], Supplier_PurchaseReceipt.Vehical_No,   Supplier_PurchaseReceipt_Details.Remarks FROM            Supplier_PurchaseReceipt INNER JOIN  Supplier_PurchaseReceipt_Details ON Supplier_PurchaseReceipt.SPR_ID = Supplier_PurchaseReceipt_Details.SPR_ID INNER JOIN   Supplier_Po_Master ON Supplier_PurchaseReceipt.SUP_PO_ID = Supplier_Po_Master.Sup_PO_Id INNER JOIN   Supplier_Master ON Supplier_Po_Master.Sup_Id = Supplier_Master.SUP_ID INNER JOIN    Material_Master ON Supplier_PurchaseReceipt_Details.MAT_ID = Material_Master.Material_Id INNER JOIN   Color_Master ON Supplier_PurchaseReceipt_Details.COLOR_ID = Color_Master.Color_Id INNER JOIN   Sales_Order ON Supplier_PurchaseReceipt_Details.SO_Id = Sales_Order.SalesOrder_Id INNER JOIN  Uom_Master ON Material_Master.UOM_Id = Uom_Master.UOM_ID WHERE SPR_DATE = GETDATE()");
            hai.DataBind();

        }
    }












    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("[USP_Inward_Serach]", con);
        cmd.CommandType = CommandType.StoredProcedure;

       
        if (txtrqstfrom.Text != "")
        {
            //cmd.Parameters.AddWithValue("@FromDate", General.toMMDDYYYY(txtrqstfrom.Text));
            cmd.Parameters.AddWithValue("@FromDate", txtrqstfrom.Text);
        }
        if (txtrqstto.Text != "")
        {
            cmd.Parameters.AddWithValue("@ToDate", txtrqstto.Text);
            //cmd.Parameters.AddWithValue("@ToDate", General.toMMDDYYYY(txtrqstto.Text));
        }
        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        hai.DataSource = dt;
        hai.DataBind();
    }
}