using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using phani.Classes;
using phaniDAL;
using Phani.Modules;

public partial class Modules_Sales_BOM_Search : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);
        if (!IsPostBack)
        {
            SM.SalesOrder.SalesOrder_Select(ddlSoNo);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("[USP_BOM_Serach]", con);
        cmd.CommandType = CommandType.StoredProcedure;

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
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    string Length = e.Row.Cells[4].Text.ToString();
        //    string PU = e.Row.Cells[6].Text.ToString();
        //    decimal shortage = 0;

        //    if (Length != "0")
        //    {

        //        shortage = decimal.Parse(e.Row.Cells[5].Text) - decimal.Parse(e.Row.Cells[9].Text);

        //        e.Row.Cells[4].Text = shortage.ToString();

        //    }
        //}


      





        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Length = e.Row.Cells[3].Text;
            string PU = e.Row.Cells[5].Text;
            decimal shortage = 0;

            decimal blcpfree = 0;

            if (Length != "0")
            {


                blcpfree = decimal.Parse(e.Row.Cells[8].Text) + decimal.Parse(e.Row.Cells[9].Text);

                shortage = decimal.Parse(e.Row.Cells[4].Text) - blcpfree;

                if(shortage < 0)
                {
                    e.Row.Cells[10].Text = "0";
                }
                else
                {
                    e.Row.Cells[10].Text = shortage.ToString();
                    e.Row.Cells[10].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[10].ForeColor = System.Drawing.Color.White;

                }

                

            }


            if (Length == "0")
            {


                blcpfree = decimal.Parse(e.Row.Cells[8].Text) + decimal.Parse(e.Row.Cells[9].Text);

                shortage = decimal.Parse(e.Row.Cells[6].Text) - blcpfree;

                if (shortage < 0)
                {
                    e.Row.Cells[10].Text = "0";
                }
                else
                {
                    e.Row.Cells[10].Text = shortage.ToString();
                    e.Row.Cells[10].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
                }

            }

        }


    }
}