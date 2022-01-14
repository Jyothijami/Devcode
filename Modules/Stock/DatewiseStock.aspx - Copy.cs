using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using phani.Classes;
using Phani.Modules;
using phani.MessageBox;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Modules_Stock_DatewiseStock : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

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
        SqlCommand cmd = new SqlCommand("[USP_DatewiseStock_Search]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        if (ddlprojects.SelectedIndex != 0)
        {
            cmd.Parameters.AddWithValue("@ProjectCode", ddlprojects.SelectedItem.Value);
        }
        if (txtfromdate.Text != "")
        {
            cmd.Parameters.AddWithValue("@FromDate", txtfromdate.Text);
        }
        if (txttodate.Text != "")
        {
            cmd.Parameters.AddWithValue("@ToDate", txttodate.Text);
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string str = e.Row.Cells[5].Text.ToString();
            string str1 = e.Row.Cells[6].Text.ToString();
            if (str == "0.00" && str1 == "0.00")
            {
                e.Row.Visible = false;

            }

        }
    }
}