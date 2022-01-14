using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Purchases_Opearations : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SM.SalesOrder.SalesOrder_Select(ddlSoNo);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("Select * from SalesOrder_Details where SalesOrder_Id =@SOID ", con);
        cmd.CommandType = CommandType.Text ;

        if (ddlSoNo.SelectedValue != "0")
        {
            cmd.Parameters.AddWithValue("@SOID", ddlSoNo.SelectedItem.Value);
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        hai.DataSource = dt;
        hai.DataBind();
    }
    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        LinkButton lbtnRegionalMaster;
        lbtnRegionalMaster = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnRegionalMaster.Parent.Parent;
        hai.SelectedIndex = gvRow.RowIndex;


        if (hai.SelectedIndex > -1)
        {
            try
            {
 
            }
            catch (Exception ex) 
            {
 
            }
        }
    }
}