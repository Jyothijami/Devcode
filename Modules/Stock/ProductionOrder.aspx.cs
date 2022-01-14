using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_ProductionOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if(!IsPostBack)
        {
            GridView1.DataBind();
        }


    }



    protected void btnAddnew_Click(object sender, EventArgs e)
    {
        string N = "Add";
        Response.Redirect("~/Modules/Stock/ProductionOrder_Details.aspx?Cid=" + N);
    }




}