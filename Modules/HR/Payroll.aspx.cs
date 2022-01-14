using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_Payroll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindYears();
        }
    }
    private void BindYears()
    {
        int year = DateTime.Now.Year;
        for (int i = year; i >= year - 4; i--)
        {
            ddlYear.Items.Add(i.ToString());
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        tblpRint.Visible = true;
    }
    protected void chkSalaryPaySheet_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            chkESISheet.Checked = false;
            chkPFSheet.Checked = false;
            //chkBankStatement.Checked = false;
            string pagenavigationstr = "../Reports/SMReportViewer.aspx?type=Payshet&e=" + ddlMonth.SelectedValue + " &year=" + ddlYear.SelectedItem.Text + "";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
    protected void chkPFSheet_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            chkESISheet.Checked = false;
            chkSalaryPaySheet.Checked = false;
            //chkBankStatement.Checked = false;
            string pagenavigationstr = "../Reports/SMReportViewer.aspx?type=PFSheet&e=" + ddlMonth.SelectedValue + " &year=" + ddlYear.SelectedItem.Text + "";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
    protected void chkESISheet_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            chkSalaryPaySheet.Checked = false;
            chkPFSheet.Checked = false;
            //chkBankStatement.Checked = false;
            //chkSalaryPaySheet.Checked = false;
            string pagenavigationstr = "../Reports/SMReportViewer.aspx?type=ESISheet&e=" + ddlMonth.SelectedValue + " &year=" + ddlYear.SelectedItem.Text + "";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
}