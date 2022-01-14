using phani.Classes;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_IssuedStocktoProject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);
        if (!IsPostBack)
        {
            SM.SalesOrder.SalesOrder_Select(ddlprojects);
        }
    }


    protected void btnfromto_Click(object sender, EventArgs e)
    {




        General.GridBindwithCommand(GridView1, "select Material_Code ,Description,Color_Name,O.Length as Lent, " +
" MaterialIssue = (select isnull(sum(M.Issued_Qty),0) FROM Material_Issue_Details M where m.Item_Code = o.MatId and m.Color_Id = o.ColorId and m.Length = o.Length and m.So_Id = '"+ ddlprojects.SelectedItem.Value+"'), "+
 " NrgpIssue = (select isnull(sum(N.Qty),0) FROM NRGP_Details N where N.Item_Id = o.MatId and N.Color_Id = o.ColorId and N.Length = o.Length and N.ProjectId = '" + ddlprojects.SelectedItem.Value + "'), " +
"PackingListIssue = (select isnull(sum(P.Qty),0) FROM PackingList_Details P where P.Item_Id = o.MatId and P.Color_Id = o.ColorId and P.Length = o.Length and P.SO_Id = '" + ddlprojects.SelectedItem.Value + "')," +
"Received = (select isnull(sum(S.PO_ACCEPTED_QTY),0) FROM Supplier_PurchaseReceipt_Details S where S.MAT_ID = o.MatId and S.COLOR_ID = o.ColorId and S.Lengthh = o.Length and S.SO_Id = '" + ddlprojects.SelectedItem.Value + "')," +
"InBlockedQty = (select isnull(sum(B.Qty),0) FROM Stock_Block B where B.Item_Code = o.MatId and B.Color_Id = o.ColorId and B.Length = o.Length and B.So_Id = '" + ddlprojects.SelectedItem.Value + "')" +
"from Stock o,Material_Master Mm,Color_Master C,Category_Master CM where O.MatId = Mm.Material_Id "+
" and O.ColorId = C.Color_Id and O.Length = O.Length AND Mm.Category_Id = CM.ITEM_CATEGORY_ID  order by O.MatId asc ");





    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Use your column value below
            string str = e.Row.Cells[4].Text.ToString();
            string str1 = e.Row.Cells[5].Text.ToString();
            string str2 = e.Row.Cells[6].Text.ToString();
            string str3 = e.Row.Cells[8].Text.ToString();
            string str4 = e.Row.Cells[9].Text.ToString();
          //  Label lblcou = (Label)GridView1.FindControl("Label1");
           // e.Row.Cells[7].Text = int.Parse(str+str1+str2).ToString() ;
           // string total = 0;


            //lblcou.Text = (Convert.ToDouble(e.Row.Cells[4].Text) + Convert.ToDouble(e.Row.Cells[5].Text) + Convert.ToDouble(e.Row.Cells[6].Text)).ToString();

           // lblcou.Text = total.ToString();

            // or you can try str == String.Empty in below condition as necessary.


            
            if (str == "0.00" && str1 == "0.00" && str2 == "0.00" && str3 == "0.00" && str4 == "0.00")
            {
                e.Row.Visible = false;
            }

           


        }
           
        
    }
}