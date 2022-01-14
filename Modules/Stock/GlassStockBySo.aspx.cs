using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_GlassStockBySo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            SM.SalesOrder.SalesOrder_Select(ddlPono);





        }
    }
    protected void ddlPono_SelectedIndexChanged(object sender, EventArgs e)
    {


              SCM.GlassPo obj = new SCM.GlassPo();

        if(ddlPono.SelectedItem.Value != "0")
        {
            obj.SupPoOrderQtybyso_Select(ddlPono.SelectedItem.Value, GridView1);
        
        }
         
              


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[9].Visible = false;
        }
    }
}