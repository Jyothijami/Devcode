using phani.MessageBox;
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

public partial class Modules_Stock_FreeBlockedStockBySo : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            SM.SalesOrder.SalesOrderProjectcode_Select(txtPrjtcode);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {



        SqlCommand cmd = new SqlCommand("[USP_FreeBlock_Serach]", con);
        cmd.CommandType = CommandType.StoredProcedure;

       
        if (txtPrjtcode.SelectedItem.Value != "0")
        {
            cmd.Parameters.AddWithValue("@ProjectCode", txtPrjtcode.SelectedItem.Text);
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        hai.DataSource = dt;
        hai.DataBind();
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {

        SCM.ReserveStock objSM = new SCM.ReserveStock();
        foreach (GridViewRow gvrow in hai.Rows)
        {

            TextBox qty = (TextBox)gvrow.FindControl("txtitemqty");
            objSM.Qty = qty.Text;
            if (objSM.Qty != "")
            {

                objSM.ReserveDetid = gvrow.Cells[0].Text;
                //TextBox qty = (TextBox)gvrow.FindControl("txtitemqty");
                //objSM.Qty = qty.Text;

                TextBox remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                objSM.Remarks = remarks.Text;
                objSM.ReserveBlockStock_Update();
            }

        }

        MessageBox.Show(this, "Data Updated Sucessfully" );
        btnSearch_Click(sender, e);
    }
}