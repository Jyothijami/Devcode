using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Phani.Modules;
using phani.MessageBox;
using phani.Classes;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public partial class Modules_SM_DR : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBcon"].ToString());



    private void Page_PreInit(object sender, System.EventArgs e)
    {
        if (System.Web.HttpContext.Current.Session["AlusoftSession"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {

        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);
        if (!IsPostBack)
        {
            HR.EmployeeMaster.EmployeeMaster_Select(ddlAttendedBy);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlSalesPerson);
            ddlAttendedBy.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            txtDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture);

            string hi = "1";

            lblUserType.Text = hi;
            lblEmpIdHidden.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
         
            BindGrid_All();



        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SM.DailyReport objdr = new SM.DailyReport();
        try
        {


            if(ddlAttendedBy.SelectedItem.Value != "0")
            { 

            objdr.DRDate = General.toMMDDYYYY(txtDateTime.Text);
            objdr.CustName = txtClientsName.Text;
            objdr.Purpose = txtPurpose.Text;
            objdr.Remarks = txtRemarks.Text;
            objdr.DRAttendedBy = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objdr.DRPreparedBy = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objdr.Time = "01/01/1900 " + ddlHour.SelectedItem.Value + ":" + ddlMin.SelectedItem.Value + " " + ddlAMPM.SelectedItem.Value;
            objdr.Address = txtAddress.Text;
            objdr.Phone = txtPhoneNo.Text;
            objdr.Reference = txtReference.SelectedItem.Value;
            objdr.Architect = txtArchitect.Text;
            objdr.outTime = "01/01/1900 " + ddlOutHour.SelectedItem.Value + ":" + ddlOutMin.SelectedItem.Value + " " + ddlOutAMPM.SelectedItem.Value;
            objdr.Comment = "";
            //ddlHour.SelectedValue + ":" + ddlMin.SelectedValue + " " + ddlAMPM.SelectedValue;
            objdr.FileName = "";
            objdr.DailyReports_Save();
            MessageBox.Show(this, "Data Saved Successfully");
            btnRefresh_Click(sender, e);
            BindGrid_All();
            }
            else
            {
                MessageBox.Show(this, "Something Went Wrong.Contact Admin");
            }
            

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "Unable to raise the request, please try again or contact Admin.");
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        txtClientsName.Text = string.Empty;
        txtPurpose.Text = string.Empty;
        txtRemarks.Text = string.Empty;
        //txtDateTime.Text = string.Empty;
        txtAddress.Text = string.Empty;
        txtPhoneNo.Text = string.Empty;
     //   ddlAttendedBy.SelectedValue = "0";
        txtArchitect.Text = string.Empty;
    }















    //protected void gvDrs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gvDrs.PageIndex = e.NewPageIndex;
    //    BindGrid_All();
    //}
    //protected void gvDrs_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Cells[15].Visible = false;
    //    }
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Cells[15].Visible = false;
    //        TextBox comments = (TextBox)e.Row.FindControl("txtComment");
    //        if (comments.Text != null && comments.Text != "")
    //        {
    //            e.Row.BackColor = System.Drawing.Color.Coral;
    //            e.Row.ForeColor = System.Drawing.Color.Black;
    //        }
    //    }
    //}
    //protected void Chk_CheckedChanged(object sender, EventArgs e)
    //{
    //    btnDelete.Visible = true;
    //    btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to remove this Item from Items list?');");

    //}
    //protected void btnDelete_Click(object sender, EventArgs e)
    //{
    //    DeleteDailyReport();
    //    BindGrid_All();
    //}
    //private void DeleteDailyReport()
    //{
    //    #region Delete Application
    //    foreach (GridViewRow gvr in gvDrs.Rows)
    //    {
    //        if (((CheckBox)gvr.FindControl("Chk")).Checked)
    //        {
    //            try
    //            {
    //                Label onDutyId = (Label)gvr.FindControl("lblId");
    //                int ID = Convert.ToInt32(onDutyId.Text);
    //                SqlCommand cmd = new SqlCommand("USP_Delete_DailyReport", con);
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Parameters.AddWithValue("@DailyReport_ID", ID);
    //                con.Open();
    //                cmd.ExecuteNonQuery();
    //                con.Close();
    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBox.Show(this, ex.Message.ToString());
    //            }
    //        }
    //    }
    //    #endregion
    //}
    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    BindGrid_All();
    //}
    //private void BindGrid_All()
    //{
    //    SqlCommand cmd = new SqlCommand("USP_DailyReportSearch", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    if (lblUserType.Text != "")
    //    {
    //        cmd.Parameters.AddWithValue("@userType", lblUserType.Text);

    //    }
    //    if (lblEmpIdHidden.Text != "")
    //    {
    //        cmd.Parameters.AddWithValue("@EmpId", lblEmpIdHidden.Text);

    //    }
    //    if (txtClientName.Text != "")
    //    {
    //        cmd.Parameters.AddWithValue("@CLIENTSNAME", txtClientName.Text);
    //    }
    //    //if (txtEmp_Name.Text != "")
    //    //{
    //    //    cmd.Parameters.AddWithValue("@EMP_FIRST_NAME", txtEmp_Name.Text);
    //    //}
    //    if (ddlSalesPerson.SelectedIndex != 0)
    //    {
    //        cmd.Parameters.AddWithValue("@EMP_FIRST_NAME", ddlSalesPerson.SelectedItem.Value);
    //    }
    //    if (txtFromDate.Text != "")
    //    {
    //        cmd.Parameters.AddWithValue("@FromDate", General.toMMDDYYYY(txtFromDate.Text));
    //    }
    //    if (txtToDate.Text != "")
    //    {
    //        cmd.Parameters.AddWithValue("@ToDate", General.toMMDDYYYY(txtToDate.Text));
    //    }
    //    if (lblDeptId.Text != "")
    //    {
    //        cmd.Parameters.AddWithValue("@DeptId", lblDeptId.Text);
    //    }
    //    if (lblDeptHead.Text != "")
    //    {
    //        //DeptHead_Check();
    //        cmd.Parameters.AddWithValue("@DeptHead", lblDeptHeadId.Text);
    //    }
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    da.Fill(dt);
    //    gvDrs.DataSource = dt;
    //    gvDrs.DataBind();
    //}
    protected void gvDrs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDrs.PageIndex = e.NewPageIndex;
        BindGrid_All();
    }
    protected void gvDrs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[13].Visible = false;

            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[13].Visible = false;

            TextBox comments = (TextBox)e.Row.FindControl("txtComment");
            if (comments.Text != null && comments.Text != "")
            {
                e.Row.BackColor = System.Drawing.Color.Coral;
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
    protected void Chk_CheckedChanged(object sender, EventArgs e)
    {
        btnDelete.Visible = true;
        btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to remove this Item from Items list?');");

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DeleteDailyReport();
        BindGrid_All();
    }
    private void DeleteDailyReport()
    {
        #region Delete Application
        foreach (GridViewRow gvr in gvDrs.Rows)
        {
            if (((CheckBox)gvr.FindControl("Chk")).Checked)
            {
                try
                {
                    Label onDutyId = (Label)gvr.FindControl("lblId");
                    int ID = Convert.ToInt32(onDutyId.Text);
                    SqlCommand cmd = new SqlCommand("USP_Delete_DailyReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DailyReport_ID", ID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message.ToString());
                }
            }
        }
        #endregion
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid_All();
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
        if (txtClientName.Text != "")
        {
            cmd.Parameters.AddWithValue("@CLIENTSNAME", txtClientName.Text);
        }
        //if (txtEmp_Name.Text != "")
        //{
        //    cmd.Parameters.AddWithValue("@EMP_FIRST_NAME", txtEmp_Name.Text);
        //}
        if (ddlSalesPerson.SelectedIndex != 0)
        {
            cmd.Parameters.AddWithValue("@EMP_FIRST_NAME", ddlSalesPerson.SelectedItem.Value);
        }
        if (txtFromDate.Text != "")
        {
            cmd.Parameters.AddWithValue("@FromDate", General.toMMDDYYYY(txtFromDate.Text));
        }
        if (txtToDate.Text != "")
        {
            cmd.Parameters.AddWithValue("@ToDate", General.toMMDDYYYY(txtToDate.Text));
        }
        //if (lblDeptId.Text != "")
        //{
        //    cmd.Parameters.AddWithValue("@DeptId", lblDeptId.Text);
        //}
        //if (lblDeptHead.Text != "")
        //{
        //    //DeptHead_Check();
        //    cmd.Parameters.AddWithValue("@DeptHead", lblDeptHeadId.Text);
        //}
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvDrs.DataSource = dt;
        gvDrs.DataBind();
    }












}