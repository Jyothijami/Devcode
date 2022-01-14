using phani.Classes;
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

public partial class Modules_Sales_ToDoList : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {

        if(!IsPostBack)
        {

       

        lblEmpIdHidden.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
        HR.EmployeeMaster.EmployeeMaster_Select (ddlEmp);
        //txtIssueddt.Text = DateTime.Now.ToString();

        string hi = "1";

        //lblUserType.Text = hi;
        lblUserId.Text = lblEmpIdHidden.Text;
        BindToDoList_All();
        BindData();

        }
    }
    private void BindData()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString()))
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT EMP_FIRST_NAME,EMP_ID FROM EMPLOYEE_MASTER";
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                // BIND THE SELECT DROP-DOWN LIST WITH A DATABASE TABLE.
                Books.DataSource = dt;
                Books.DataTextField = "EMP_FIRST_NAME";
                Books.DataValueField = "EMP_ID";

                Books.DataBind();

                // FOR MULTIPLE SELECTION. SET THE VALUE AS FALSE, AND SEE WHAT HAPPENS.
                Books.Multiple = true;
            }
        }


        // SM.CustomerMaster.CustomerMaster_Select(Books);


    }
    protected void btnListSearch_Click(object sender, EventArgs e)
    {
        BindToDoList_All();
    }

    protected void btnListSave_Click(object sender, EventArgs e)
    {
        SM.DailyReport objdr = new SM.DailyReport();
        //objdr.Date = DateTime.Now.ToString("");
        objdr.Subject = txtSubject.Text;
        objdr.IssuedDate = General.toMMDDYYYY(txtIssueddt.Text);
        objdr.Description = txtDescr.Text;
        objdr.Status = ddlActivity.SelectedItem.Text;
        objdr.PreparedBy = lblEmpIdHidden.Text;

        if (objdr.ToDo_List_Save() == "Data Saved Successfully")
        {
            //foreach (var hai in Books.DataTextField )
            //{
            //    objdr.EmpID = hai.ToString();
            //    objdr.ToDO_List_Det_Save();
            //}
            //for (int i = 0; i <= Books.Items.Count - 1; i++)
            //{
            //    var selectedText = Books.Items[Books.SelectedIndex].Value.Trim();
            //    objdr.ToDO_List_Det_Save();
            //    //MessageBox.Show(this, selectedText);
            //}
            lblItem.Text = "";
            foreach (ListItem item in Books.Items)
            {
                if (item.Selected)
                {

                    objdr.EmpID = item.Value.ToString();
                    objdr.ToDO_List_Det_Save();

                }
            }
        }
        MessageBox.Show(this, "Data Saved Suucessfully");
        btnRefresh1_Click(sender, e);
        BindToDoList_All();
    }
    private void BindToDoList_All()
    {
        SqlCommand cmd = new SqlCommand("[USP_ToDOListSearch]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        if (lblUserType.Text != "")
        {
            cmd.Parameters.AddWithValue("@userType", lblUserType.Text);

        }
        if (lblEmpIdHidden.Text != "")
        {
            cmd.Parameters.AddWithValue("@EmpId", lblUserId.Text);

        }
        if (txtListSubject.Text != "")
        {
            cmd.Parameters.AddWithValue("@CLIENTSNAME", txtListSubject.Text);
        }
        //if (txtEmp_Name.Text != "")
        //{
        //    cmd.Parameters.AddWithValue("@EMP_FIRST_NAME", txtEmp_Name.Text);
        //}
        if (ddlEmp.SelectedIndex != 0)
        {
            cmd.Parameters.AddWithValue("@EMP_FIRST_NAME", ddlEmp.SelectedItem.Value);
        }
        if (txtListFrom.Text != "")
        {
            cmd.Parameters.AddWithValue("@FromDate", General.toMMDDYYYY(txtListFrom.Text));
        }
        if (txtListTo.Text != "")
        {
            cmd.Parameters.AddWithValue("@ToDate", General.toMMDDYYYY(txtListTo.Text));
        }
        if (lblDeptId.Text != "")
        {
            cmd.Parameters.AddWithValue("@DeptId", lblDeptId.Text);
        }
        if (lblDeptHead.Text != "")
        {
            //DeptHead_Check();
            cmd.Parameters.AddWithValue("@DeptHead", lblDeptHeadId.Text);
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gvList.DataSource = dt;
        gvList.DataBind();
        BindChildGV();

    }
    private void BindChildGV()
    {
        foreach (GridViewRow gvrow in gvList.Rows)
        {
            GridView gvDC = (GridView)(gvList.Rows[gvrow.RowIndex].Cells[8].FindControl("gvChild"));
            SqlCommand cmd = new SqlCommand("USP_ToDOList_ReportingTo_Search", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (gvrow.Cells[8].Text != "")
            {
                cmd.Parameters.AddWithValue("@ID", gvrow.Cells[8].Text);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvDC.DataSource = dt;
            gvDC.DataBind();
        }


    }
    protected void btnListDelete_Click(object sender, EventArgs e)
    {
        DeleteListReport();
        BindToDoList_All();
    }

    private void DeleteListReport()
    {
        #region Delete Application
        foreach (GridViewRow gvr in gvList.Rows)
        {
            if (((CheckBox)gvr.FindControl("Chk")).Checked)
            {
                try
                {
                    Label onDutyId = (Label)gvr.FindControl("lblId");
                    int ID = Convert.ToInt32(onDutyId.Text);
                    SqlCommand cmd = new SqlCommand("[USP_Delete_TODOLIst]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DailyReport_ID", ID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show(this, "Data Deleted Suucessfully");
                    BindToDoList_All();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message.ToString());
                }
            }
        }
        #endregion
    }

    protected void btnListUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            SM.DailyReport objdr = new SM.DailyReport();
            foreach (GridViewRow gvrow in gvList.Rows)
            {
                DropDownList d1 = gvrow.FindControl("ddlStatus") as DropDownList;
                if (gvrow.RowType == DataControlRowType.DataRow)
                {
                    objdr.ID = gvrow.Cells[8].Text;
                    objdr.Status = d1.SelectedItem.Text;
                    objdr.ToDO_List_Status_Update();
                }
            }
            MessageBox.Show(this, "Data Saved Suucessfully");
            BindToDoList_All();
        }
        catch (Exception ex)
        {

        }
    }
    protected void Chk_CheckedChanged(object sender, EventArgs e)
    {
        btnListDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to remove this Item from Items list?');");
        btnListDelete.Visible = true;
        btnListUpdate.Visible = true;
    }
    protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvList.PageIndex = e.NewPageIndex;
        BindToDoList_All();
    }
    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[1].Visible = false;

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HiddenField hf = (HiddenField)e.Row.FindControl("cthf1");
            DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");

            ddlStatus.SelectedValue = hf.Value;
        }

    }
    protected void btnRefresh1_Click(object sender, EventArgs e)
    {
        HR.ClearControls(this);
    }
}