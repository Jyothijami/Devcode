using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBcon"].ToString());


  



    protected void Page_Load(object sender, EventArgs e)
    {

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);
        if (!IsPostBack)
        {

            lblUserType.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpUserType);
            lblEmpIdHidden.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            BindGrid_All();



        }
    }
    


    protected void gvDrs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox comments = (TextBox)e.Row.FindControl("txtComment");
            if (comments.Text != null && comments.Text != "")
            {
                e.Row.BackColor = System.Drawing.Color.Coral;
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
  
    private void BindGrid_All()
    {
        SqlCommand cmd = new SqlCommand("USP_DailyReportSearch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        if (lblUserType.Text != "")
        {
            cmd.Parameters.AddWithValue("@userType", lblUserType.Text);

        }
        if (lblEmpIdHidden.Text != "")
        {
            cmd.Parameters.AddWithValue("@EmpId", lblEmpIdHidden.Text);

        }
      
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvDrs.DataSource = dt;
        gvDrs.DataBind();
    }
}