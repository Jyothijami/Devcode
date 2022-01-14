using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_JobOpening_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

       

        if (!IsPostBack)
        {
            if (Qid != "Add")
            {



            }
        }
    }

    private void CategoryFill()
    {
        HR.JobOpenings objmaster = new HR.JobOpenings();
        if (objmaster.JobOpenings_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtJobTitle.Text = objmaster.JobTitle;
            txtDescription.Text = objmaster.Description;
            ddlstatus.SelectedItem.Value = objmaster.Status;




        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                HR.JobOpenings objMaster = new HR.JobOpenings();
                objMaster.JobTitle = txtJobTitle.Text;
                objMaster.Description = txtDescription.Text;
                objMaster.Status = ddlstatus.SelectedItem.Value;

                string cr = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff", CultureInfo.InvariantCulture);
                objMaster.Createdon = cr;


                MessageBox.Notify(this, objMaster.JobOpenings_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
                Response.Redirect("~/Modules/HR/JobOpening.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                HR.JobOpenings objMaster = new HR.JobOpenings();
                objMaster.JOId = Request.QueryString["Cid"].ToString();
                objMaster.JobTitle = txtJobTitle.Text;
                objMaster.Description = txtDescription.Text;
                objMaster.Status = ddlstatus.SelectedItem.Value;

                string cr = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff",CultureInfo.InvariantCulture);
                objMaster.Createdon = cr;
                MessageBox.Notify(this, objMaster.JobOpenings_Update());


            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
                Response.Redirect("~/Modules/HR/JobOpening.aspx");
            }
        }

    }

}