using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_DailyReportDocs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            if (Qid != "")
            {
                lbldailyreportId.Text = Request.QueryString["Cid"].ToString();

                if(lbldailyreportId.Text != "0")
                {
                    SM.DailyReport obj = new SM.DailyReport();

                    if(obj.DailyReport_Select(lbldailyreportId.Text) > 0)
                    {
                        txtQuatationDate.Text = obj.DRDate;
                        lblPurpose.Text = Server.HtmlDecode(obj.Purpose);
                        General.GridBindwithCommand(gvElevationDrawings, "select * from Daily_Report_Docs where DA_Doc_Id= '" + lbldailyreportId.Text + "'");
                    }
                }
            }
        }
    }


 


    protected void btnsubmitElevationdrawing_Click(object sender, EventArgs e)
    {
        try
        {
            SM.DailyReport objSM = new SM.DailyReport();

            objSM.PODocdate = General.toMMDDYYYY(txtReceiveddate.Text);
            objSM.PODocRemarks = txtremarks.Text;
            objSM.DRId = lbldailyreportId.Text;

            if (FileUpload1.HasFiles)
            {
                #region ElevationDocuments
                string Attachment = "";
                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Content/DailyReports"))
                {

                    foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                    {
                        Random rand = new Random();
                        string randNumber = Convert.ToString(rand.Next(0, 10000));
                        string path = Server.MapPath("~/Content/DailyReports/");
                        string fileName = System.IO.Path.GetFileName(uploadedFile.FileName);

                        Attachment = randNumber + "_" + fileName;
                        uploadedFile.SaveAs(path + randNumber + "_" + fileName);
                        objSM.PODocuments = Attachment;
                    }


                }

                #endregion
            }
            else
            {
                objSM.PODocuments = "";
            }

            MessageBox.Show(this, objSM.PODocuments_Details_Save());

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            gvElevationDrawings.DataBind();
            General.GridBindwithCommand(gvElevationDrawings, "select * from Daily_Report_Docs where DA_Doc_Id= '" + lbldailyreportId.Text + "'");

        }
    }


    protected void lbtnElevationDelete_Click(object sender, EventArgs e)
    {
        LinkButton lbtnRegionalMaster;
        lbtnRegionalMaster = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnRegionalMaster.Parent.Parent;
        gvElevationDrawings.SelectedIndex = gvRow.RowIndex;

        if (gvElevationDrawings.SelectedIndex > -1)
        {
            try
            {
                SM.DailyReport objSM = new SM.DailyReport();
                MessageBox.Show(this, objSM.PODocumentsDetails_Delete(gvElevationDrawings.SelectedRow.Cells[0].Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                gvElevationDrawings.DataBind();
                General.GridBindwithCommand(gvElevationDrawings, "select * from Daily_Report_Docs where DA_Doc_Id= '" + lbldailyreportId.Text + "'");

            }
        }
        else
        {
            MessageBox.Notify(this, "Please select atleast a Record");
        }
    }


}