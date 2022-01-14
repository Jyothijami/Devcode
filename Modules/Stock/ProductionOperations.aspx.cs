using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_ProductionOperations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if(!IsPostBack)
        {
            SCM.ProductionOrder.ProductionOrder_Select(ddlproducionno);
            SCM.BOM.BOM_Select(ddlBomno);


        }
    }
}