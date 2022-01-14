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

public partial class Modules_Stock_Inventory_Search : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);
       // System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad1()", true);

        ////gvIssues.DataBind();


        if(!IsPostBack)
        {
            //BindGrid_All();
            //BindGrid_All1();
            //BindGrid_RGP();
        }
    }

    protected void btnrqstSearch_Click(object sender, EventArgs e)
    {
        if (rdbIssueSlip.SelectedItem.Value == "1")
        {
            BindGrid_All1();
        }
        else if (rdbIssueSlip.SelectedItem.Value == "2")
        {
            BindGrid_RGP1();
        }
        else if (rdbIssueSlip.SelectedItem.Value == "3")
        {
            BindGrid_NRGP1();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (rdbIssueSlip.SelectedItem.Value == "1")
        {
            BindGrid_All();
        }
        else if (rdbIssueSlip.SelectedItem.Value == "2")
        {
            BindGrid_RGP();
        }
        else if (rdbIssueSlip.SelectedItem.Value == "3")
        {
            BindGrid_NRGP();
        }
        else if (rdbIssueSlip.SelectedItem.Value == "4")
        {
            BindGrid_PackinglIst();
        }
    }

    private void BindGrid_PackinglIst()
    {
        SqlCommand cmd = new SqlCommand("[USP_PackingList_Serach]", con);
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
        if (txtFromDate2.Text != "")
        {
            cmd.Parameters.AddWithValue("@FromDate", General.toMMDDYYYY(txtFromDate2.Text));
        }
        if (txtToDate2.Text != "")
        {
            cmd.Parameters.AddWithValue("@ToDate", General.toMMDDYYYY(txtToDate2.Text));
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvIssues.DataSource = dt;
        gvIssues.DataBind();
    }
    private void BindGrid_All1()
    {
        SqlCommand cmd = new SqlCommand("[USP_MaterialRequest_Serach]", con);
        cmd.CommandType = CommandType.StoredProcedure;

        if (txtrqstmaterial.Text != "")
        {
            cmd.Parameters.AddWithValue("@Item_Code", txtrqstmaterial.Text);
        }
        if (txtrqstcust.Text != "")
        {
            cmd.Parameters.AddWithValue("@CustName", txtrqstcust.Text);
        }
        if (txtrqstprjtcode.Text != "")
        {
            cmd.Parameters.AddWithValue("@ProjectCode", txtrqstprjtcode.Text);
        }
        if (txtrqstfrom.Text != "")
        {
            cmd.Parameters.AddWithValue("@FromDate", General.toMMDDYYYY(txtrqstfrom.Text));
        }
        if (txtrqstto.Text != "")
        {
            cmd.Parameters.AddWithValue("@ToDate", General.toMMDDYYYY(txtrqstto.Text));
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvRqst.DataSource = dt;
        gvRqst.DataBind();
    }
    private void BindGrid_All()
    {
        SqlCommand cmd = new SqlCommand("[USP_MaterialIssue_Serach]", con);
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
        if (txtFromDate2.Text != "")
        {
            cmd.Parameters.AddWithValue("@FromDate", General.toMMDDYYYY(txtFromDate2.Text));
        }
        if (txtToDate2.Text != "")
        {
            cmd.Parameters.AddWithValue("@ToDate", General.toMMDDYYYY(txtToDate2.Text));
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvIssues.DataSource = dt;
        gvIssues.DataBind();
    }
    private void BindGrid_RGP()
    {
        SqlCommand cmd = new SqlCommand("[USP_RGP_Serach]", con);
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
        if (txtFromDate2.Text != "")
        {
            cmd.Parameters.AddWithValue("@FromDate", General.toMMDDYYYY (txtFromDate2 .Text));
        }
        if (txtToDate2.Text != "")
        {
            cmd.Parameters.AddWithValue("@ToDate", General.toMMDDYYYY(txtToDate2.Text));
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvIssues.DataSource = dt;
        gvIssues.DataBind();
    }
    private void BindGrid_NRGP()
    {
        SqlCommand cmd = new SqlCommand("[USP_NRGP_Serach]", con);
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
        if (txtFromDate2.Text != "")
        {
            cmd.Parameters.AddWithValue("@FromDate", General.toMMDDYYYY(txtFromDate2.Text));
        }
        if (txtToDate2.Text != "")
        {
            cmd.Parameters.AddWithValue("@ToDate", General.toMMDDYYYY(txtToDate2.Text));
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvIssues.DataSource = dt;
        gvIssues.DataBind();
    }
    private void BindGrid_RGP1()
    {
        SqlCommand cmd = new SqlCommand("[USP_RGP_Request_Serach]", con);
        cmd.CommandType = CommandType.StoredProcedure;

        if (txtrqstmaterial.Text != "")
        {
            cmd.Parameters.AddWithValue("@Item_Code", txtrqstmaterial.Text);
        }
        if (txtrqstcust.Text != "")
        {
            cmd.Parameters.AddWithValue("@CustName", txtrqstcust.Text);
        }
        if (txtrqstprjtcode.Text != "")
        {
            cmd.Parameters.AddWithValue("@ProjectCode", txtrqstprjtcode.Text);
        }
        if (txtrqstfrom.Text != "")
        {
            cmd.Parameters.AddWithValue("@FromDate", General.toMMDDYYYY(txtrqstfrom.Text));
        }
        if (txtrqstto.Text != "")
        {
            cmd.Parameters.AddWithValue("@ToDate", General.toMMDDYYYY(txtrqstto.Text));
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvRqst.DataSource = dt;
        gvRqst.DataBind();
    }
    private void BindGrid_NRGP1()
    {
        SqlCommand cmd = new SqlCommand("[USP_NRGP_Request_Serach]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        if (txtrqstmaterial.Text != "")
        {
            cmd.Parameters.AddWithValue("@Item_Code", txtrqstmaterial.Text);
        }
        if (txtrqstcust.Text != "")
        {
            cmd.Parameters.AddWithValue("@CustName", txtrqstcust.Text);
        }
        if (txtrqstprjtcode.Text != "")
        {
            cmd.Parameters.AddWithValue("@ProjectCode", txtrqstprjtcode.Text);
        }
        if (txtrqstfrom.Text != "")
        {
            cmd.Parameters.AddWithValue("@FromDate", General.toMMDDYYYY(txtrqstfrom.Text));
        }
        if (txtrqstto.Text != "")
        {
            cmd.Parameters.AddWithValue("@ToDate", General.toMMDDYYYY(txtrqstto.Text));
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvRqst.DataSource = dt;
        gvRqst.DataBind();
    }
    protected void lnkIssues_Click(object sender, EventArgs e)
    {
        pnlDC.Visible = true;
        pnlreqst.Visible = false;
    }
    protected void lnkReqst_Click(object sender, EventArgs e)
    {
        pnlDC.Visible = false;
        pnlreqst.Visible = true;
    }
   
}