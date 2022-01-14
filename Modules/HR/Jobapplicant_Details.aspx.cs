using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_Jobapplicant_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

       

        if (!IsPostBack)
        {
            Jobopneing_Fill();
            if (Qid != "Add")
            {

                CategoryFill();

            }
        }
    }

    private void Jobopneing_Fill()
    {
        HR.JobOpenings.JobOpenings_Select(ddljobopening);
    }

    private void CategoryFill()
    {
        HR.JobApplicant objmaster = new HR.JobApplicant();
        if (objmaster.JobApplicant_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtapplicantname.Text = objmaster.ApplicantName;
            txtCoverletter.Text = objmaster.CoverLetter;
            ddlstatus.SelectedValue = objmaster.Status;
            txtEmailAddress.Text = objmaster.ApplicantEmail;
            ddljobopening.SelectedValue = objmaster.JobOpeningId;
            link.Visible = true;
            link.Text = objmaster.Attachment;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                HR.JobApplicant objMaster = new HR.JobApplicant();
                objMaster.ApplicantName = txtapplicantname.Text;
                objMaster.JobOpeningId = ddljobopening.SelectedItem.Value;
                objMaster.ApplicantEmail = txtEmailAddress.Text;
                objMaster.Status = ddlstatus.SelectedItem.Value;
                objMaster.CoverLetter = txtCoverletter.Text;

                if (FileUpload1.HasFile)
                {
                    #region Mem Image
                    string Attachment = "";
                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/JobApplicants"))
                    {

                        foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                        {
                            Random rand = new Random();
                            string randNumber = Convert.ToString(rand.Next(0, 10000));
                            string path = Server.MapPath("~/JobApplicants/");
                            string fileName = System.IO.Path.GetFileName(uploadedFile.FileName);

                            Attachment = randNumber + "_" + fileName;
                            uploadedFile.SaveAs(path + randNumber + "_" + fileName);
                            objMaster.Attachment = Attachment;
                        }
                    }
                    
                    #endregion
                }
                else
                {
                    objMaster.Attachment = "";
                }
                MessageBox.Notify(this, objMaster.JobApplicant_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
                Response.Redirect("~/Modules/HR/JobApplicant.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                HR.JobApplicant objMaster = new HR.JobApplicant();
                objMaster.JAId = Request.QueryString["Cid"].ToString();
                objMaster.ApplicantName = txtapplicantname.Text;
                objMaster.JobOpeningId = ddljobopening.SelectedItem.Value;
                objMaster.ApplicantEmail = txtEmailAddress.Text;
                objMaster.Status = ddlstatus.SelectedItem.Value;
                objMaster.CoverLetter = txtCoverletter.Text;

                if (FileUpload1.HasFiles)
                {
                    #region Mem Image
                    string Attachment = "";
                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/JobApplicants"))
                    {

                        foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                        {
                            Random rand = new Random();
                            string randNumber = Convert.ToString(rand.Next(0, 10000));
                            string path = Server.MapPath("~/JobApplicants/");
                            string fileName = System.IO.Path.GetFileName(uploadedFile.FileName);

                            Attachment = randNumber + "_" + fileName;
                            uploadedFile.SaveAs(path + randNumber + "_" + fileName);
                            objMaster.Attachment = Attachment;
                            objMaster.JobApplicantResume_Update();
                        }
                    }

                    #endregion
                }
                else
                {
                    //objMaster.Attachment = "";
                }
                MessageBox.Notify(this, objMaster.JobApplicant_Update());


            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
                Response.Redirect("~/Modules/HR/JobApplicant.aspx");
            }
        }

    }

}