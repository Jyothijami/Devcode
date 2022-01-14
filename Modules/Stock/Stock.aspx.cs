using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using phani.MessageBox;
public partial class Modules_Stock_Stock : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);
        if (!IsPostBack)
        {
            hai.DataBind();


            string chenna = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
               
            if(chenna == "1" || chenna == "30")
            {
                btnAddnew.Visible = true;
            }





        }
    }



    protected void btnAddnew_Click(object sender, EventArgs e)
    {
      
        Response.Redirect("~/Modules/Stock/ManualStockUpdate.aspx", false);
    }



    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[5].Visible = false;
          
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        //e.Row.Cells[9].Text = (Convert.ToDecimal(e.Row.Cells[7].Text) - Convert.ToDecimal(e.Row.Cells[8].Text)).ToString();


          
        }


        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

        //    string Itemcode = e.Row.Cells[7].Text.ToString();
        //    string ColorId = e.Row.Cells[8].Text.ToString();

        //    if (Itemcode != "")
        //    {

        //        SCM.Stock obj1 = new SCM.Stock();
        //        if (obj1.BlockStock(Itemcode, ColorId) > 0)
        //        {
        //            e.Row.Cells[9].Text = obj1.BlockQty;
        //        }
        //        else
        //        {
        //            e.Row.Cells[9].Text = "0";
        //        }

        //    }



        //}
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        
            SqlCommand cmd = new SqlCommand("USP_StockReportNew_ModelNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ModelNo", txtModelNo.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            hai.DataSource = dt;
            hai.DataBind();
        
    }
    protected void btnstockleng_Click(object sender, EventArgs e)
    {
        
        string pagenavigationstr = "";
       
       
            try
            {
                pagenavigationstr = "../Reports/SMReportViewer.aspx?type=Stockview";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {

            }
        
    }
    
}