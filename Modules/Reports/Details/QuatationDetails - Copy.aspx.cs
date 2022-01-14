using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Reports_Details_QuatationDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            string Qid = Request.QueryString["Cid"].ToString();
            if (Qid != "0")
            {
                SM.SalesQuotation obj = new SM.SalesQuotation();
                obj.NewSalesQuotationDetails_Select(Request.QueryString["Cid"].ToString(), gvitems);
            }

        }
    }
}