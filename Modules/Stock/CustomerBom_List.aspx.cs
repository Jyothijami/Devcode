using phani.Classes;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_CustomerBom_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);

        if (!IsPostBack)
        {
            //hai.DataBind();


            SM.SalesOrder.SalesOrder_Select(ddlSono);
            SM.CustomerMaster.CustomerUnit_Select(ddlCustomer);



        }
    }



    protected void ddlSono_SelectedIndexChanged(object sender, EventArgs e)
    {

        General.GridBindwithCommand(gvmatana, "SELECT c.SO_ID as SO_ID ,c.SO_MATANA_ID as SO_MATANA_ID, c.ITEMCODE_ID as ITEMCODE_ID,c.COLOR_ID as COLOR_ID, c.REQUIRED_QTY as REQUIRED_QTY, cat.ITEM_CATEGORY_NAME as ITEM_CATEGORY_NAME,c.ITEMCODE as ITEMCODE, C.DESCRIPTION as Description,C.BARLENGTH as BARLENGTH,C.UNIT as UNIT,C.COLOR as COLOR, C.PU as PU,C.QUANTITY as QUANTITY, TotalStock = (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = C.ITEMCODE_ID and O.ColorId = C.COLOR_ID and O.Length = C.BARLENGTH),PrevBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = C.ITEMCODE_ID and B.Color_Id = C.COLOR_ID and B.So_Id = C.SO_ID and B.Length = C.BARLENGTH),iSSUED = (SELECT sum(Issued_Qty) as Issuedqty FROM Material_Issue_Details D where  D.Color_Id = C.COLOR_ID and D.Item_Code = C.ITEMCODE_ID and D.Length = C.BARLENGTH and D.So_Id = C.SO_ID) FROM SalesOrder_MaterialAnalysis C ,Material_Master It,Category_Master cat,Uom_Master Uom,Color_Master color where C.ITEMCODE_ID = It.Material_Id and It.Category_Id = cat.ITEM_CATEGORY_ID and It.UOM_Id = Uom.UOM_ID and C.COLOR_ID = color.Color_Id and c.SO_ID = '" + ddlSono.SelectedItem.Value + "'");

        General ob = new General();
        string Val = ob.GetColumnVal("SELECT CustSiteId FROM [Sales_Order] WHERE Sales_Order.SalesOrder_Id='" + ddlSono.SelectedItem.Value + "' ", "CustSiteId");
        if (Val != "")
        {
            ddlCustomer.SelectedValue = Val;
        }


    }









    protected void gvmatana_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[11].Visible = false;
            //e.Row.Cells[10].Visible = false;
        }
    }
}