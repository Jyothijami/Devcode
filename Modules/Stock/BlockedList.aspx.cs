using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Modules_Stock_BlockedList : System.Web.UI.Page
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
        SqlCommand cmd = new SqlCommand("[USP_BlockingStock_Serach]", con);
        cmd.CommandType = CommandType.StoredProcedure;

        if (txtMaterialCode.Text != "")
        {
            cmd.Parameters.AddWithValue("@Item_Code", txtMaterialCode.Text);
        }
        if (txtCust.Text != "")
        {
            cmd.Parameters.AddWithValue("@CustName", txtCust.Text);
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