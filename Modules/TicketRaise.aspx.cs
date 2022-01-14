using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using phani.MessageBox;
using System.Data;
using phani.Classes;

public partial class Modules_Reports_HR_Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());
    string CD = DateTime.Now.ToString("MM/dd/yyyy");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvServiceRequests.DataBind();
            lblTotalTicketsRaised.Text = gvServiceRequests.Rows.Count.ToString();
            txtCreatedFor.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpName);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string tck_ID = "VL-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string status = "Open";

            string Attachment = "";

            Masters.ItemMaster objMaster = new Masters.ItemMaster();
            #region Item Attachment

            if (requestAttachements.HasFiles)
            {
                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Content/ServiceRequest"))
                {

                    foreach (HttpPostedFile uploadedFile in requestAttachements.PostedFiles)
                    {
                        Random rand = new Random();
                        string randNumber = Convert.ToString(rand.Next(0, 10000));
                        string path = Server.MapPath("~/Content/ServiceRequest/");
                        string fileName = System.IO.Path.GetFileName(uploadedFile.FileName);

                        Attachment = randNumber + "_" + fileName;
                        uploadedFile.SaveAs(path + randNumber + "_" + fileName);
                        //objMaster.Itemattachment = Attachment;
                    }

                }
                else
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Content/ServiceRequest");
                    foreach (HttpPostedFile uploadedFile in requestAttachements.PostedFiles)
                    {
                        Random rand = new Random();
                        string randNumber = Convert.ToString(rand.Next(0, 10000));
                        string path = Server.MapPath("~/Content/ServiceRequest/");
                        string fileName = System.IO.Path.GetFileName(uploadedFile.FileName);

                        Attachment = randNumber + "_" + fileName;
                        uploadedFile.SaveAs(path + randNumber + "_" + fileName);
                        //objMaster.Itemattachment = Attachment;
                    }

                }

            }
            #endregion
            DateTime d_Created = Convert.ToDateTime("1900/01/01");
            int i = SaveServiceRequest(tck_ID, DateTime.Now, status, d_Created, d_Created, ddlUserAffctd.SelectedItem.Text, txtCreatedFor.Text, ddlRegion.SelectedItem.Text, txtModule.Text, ddlIncidentType.SelectedItem.Text, txtSummary.Text, txtDescription.Text, Attachment, ddlUrgencyLevel.SelectedItem.Text, "");
            if (i > 0)
            {
                //SendMsgToAdmin();

                btnCancel_Click(sender, e);
            }
        }
        catch (Exception)
        {
            MessageBox.Show(this, "Unable to raise the request, please try again or contact Admin.");
        }
    }

    private int SaveServiceRequest(string id, DateTime date_Created, string status, DateTime date_Worked, DateTime date_Closed, string userAffc, string createdFor, string region, string module, string incident, string summary, string description, string attachment, string UrgencyLevel, string comments)
    {
        SqlCommand cmd = new SqlCommand();
        int i = 0;
        try
        {
            con.Close();
            string instr = "insert into Service_Requests_tbl values( " + "'" + id + "'," + "'" + date_Created + "'," + "'" + status + "'," + "'" + date_Worked + "'," + "'" + date_Closed + "'," + "'" + userAffc + "'," + "'" + createdFor + "'," + "'" + region + "'," + "'" + module + "'," + "'" + incident + "'," + "'" + summary + "'," + "'" + description + "'," + "'" + attachment + "'," + "'" + UrgencyLevel + "'," + "'" + comments + "'" + ")";
            cmd = new SqlCommand(instr, con);
            cmd.CommandType = CommandType.Text;

            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }
        catch (Exception ex)
        {
            i = 0;
        }
        finally
        {
            con.Close();
            gvServiceRequests.DataBind();
            lblTotalTicketsRaised.Text = gvServiceRequests.Rows.Count.ToString();

        }
        return i;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCreatedFor.Text = txtModule.Text = txtSummary.Text = txtDescription.Text = "";
        ddlIncidentType.SelectedIndex = ddlRegion.SelectedIndex = ddlUserAffctd.SelectedIndex = 0;
    }
    protected void ddlIncidentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIncidentType.SelectedItem.Text != "Application")
        {
            MessageBox.Show(this, "You are not authorized to raise this query, please contact admin.");
            ddlIncidentType.SelectedIndex = 0;
        }
    }
    protected void ddlSymbols_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSymbols.SelectedItem.Text == "R")
        {
            txtSearchValueFromDate.Visible = true;
            txtSearchValueToDate.Visible = true;
            txtSearchText.Visible = false;
            lblCurrentFromDate.Visible = true;
            lblCurrentToDate.Visible = true;
            //imgFromDate.Visible = true;
            //ceSearchFrom.Enabled = true;
            //MaskedEditSearchFromDate.Enabled = true;
        }
        else
        {
            txtSearchValueFromDate.Visible = true;
            txtSearchValueToDate.Visible = false;
            lblCurrentFromDate.Visible = false;
            lblCurrentToDate.Visible = false;
            //imgFromDate.Visible = false;
            //ceSearchFrom.Enabled = false;
            //MaskedEditSearchFromDate.Enabled = false;
        }
    }
    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSearchBy.SelectedItem.Text == "Date Created")
        {
            ddlSymbols.Visible = true;
            txtSearchText.Visible = false;
            txtSearchValueToDate.Visible = false;
            txtSearchValueFromDate.Visible = true;
            //imgToDate.Visible = true;
            //ceSearchValueToDate.Enabled = true;
            //MaskedEditSearchToDate.Enabled = true;
        }
        else
        {
            ddlSymbols.Visible = false;
            //imgToDate.Visible = false;
            //ceSearchValueToDate.Enabled = false;
            //MaskedEditSearchToDate.Enabled = false;
            txtSearchValueToDate.Visible = false;
            txtSearchValueFromDate.Visible = false;
            txtSearchText.Visible = true;
            lblCurrentFromDate.Visible = false;
            lblCurrentToDate.Visible = false;
            //imgFromDate.Visible = false;
            //ceSearchFrom.Enabled = false;
            //MaskedEditSearchFromDate.Enabled = false;
            ddlSymbols.SelectedIndex = 0;
        }
        txtSearchText.Text = string.Empty;
        txtSearchValueFromDate.Text = string.Empty;
        txtSearchValueToDate.Text = string.Empty;
    }
    protected void btnSearchGo_Click(object sender, EventArgs e)
    {
        lblSearchItemHidden.Text = ddlSearchBy.SelectedValue;
        lblSearchTypeHidden.Text = ddlSymbols.SelectedValue;
        //if (ceSearchFrom.Enabled == false) { lblSearchValueFromHidden.Text = txtSearchValueFromDate.Text; }
        //else if (ceSearchFrom.Enabled == true) { lblSearchValueFromHidden.Text = Yantra.Classes.General.toMMDDYYYY(txtSearchValueFromDate.Text); }
        //if (ceSearchValueToDate.Enabled == false) { lblSearchValueHidden.Text = txtSearchText.Text; }
        //else if (ceSearchValueToDate.Enabled == true) { lblSearchValueHidden.Text = Yantra.Classes.General.toMMDDYYYY(txtSearchText.Text); }

        if (ddlSearchBy.SelectedItem.Text == "Date Created")
        {
            if (ddlSymbols.SelectedItem.Text == "R")
            {
                txtSearchValueFromDate.Visible = true;
                lblSearchValueFromHidden.Text = General.toMMDDYYYY(txtSearchValueFromDate.Text);
                txtSearchValueToDate.Visible = true;
                lblSearchValueHidden.Text = General.toMMDDYYYY(txtSearchValueToDate.Text);

            }
            else
            {
                txtSearchText.Visible = false;
                txtSearchValueFromDate.Visible = true;
                txtSearchValueToDate.Visible = false;
                lblSearchValueHidden.Text = General.toMMDDYYYY(txtSearchValueFromDate.Text);
            }
        }
        else
        {
            txtSearchValueFromDate.Visible = false;
            txtSearchValueToDate.Visible = false;
            lblSearchValueHidden.Text = txtSearchText.Text;
        }
        gvServiceRequests.DataBind();
    }
    protected void gvServiceRequests_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[4].Text == "Open")
            {
                e.Row.BackColor = System.Drawing.Color.Bisque;
            }
            if (e.Row.Cells[4].Text == "Closed")
            {
                e.Row.BackColor = System.Drawing.Color.LightGreen;
            }
            if (e.Row.Cells[4].Text == "Working")
            {
                e.Row.BackColor = System.Drawing.Color.LightCyan;
            }

        }
    }
}