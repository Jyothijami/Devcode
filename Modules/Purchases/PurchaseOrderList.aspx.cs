using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Purchases_PurchaseOrderList : System.Web.UI.Page
{
     SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);
        if (!IsPostBack)
        {
            hai.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("[USP_PO_Serach]", con);
        cmd.CommandType = CommandType.StoredProcedure;

        if (txtMaterialCode.Text != "")
        {
            cmd.Parameters.AddWithValue("@Item_Code", txtMaterialCode.Text);
        }
        if (txtrqstfrom.Text != "")
        {
            cmd.Parameters.AddWithValue("@FromDate", txtrqstfrom.Text);
        }
        if (txtrqstto.Text != "")
        {
            cmd.Parameters.AddWithValue("@ToDate", txtrqstto.Text);
        }
        if (txtPrjtcode.Text != "")
        {
            cmd.Parameters.AddWithValue("@ProjectCode", txtPrjtcode.Text);
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        hai.DataSource = dt;
        hai.DataBind();
    }
}