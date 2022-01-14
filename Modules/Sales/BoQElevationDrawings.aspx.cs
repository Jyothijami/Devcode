using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_BoQElevationDrawings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            //UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
            //UpdatePanelControlTrigger trigger = new PostBackTrigger();
            //trigger.ControlID = btnsubmitElevationdrawing.UniqueID;
            //updatePanel.Triggers.Add(trigger);
            SM.SalesEnquiry.SalesEnquiry_Select(ddlEnquiryNo);
            txtElevationreceiveddate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            EnquiryFill();
           

            General.GridBindwithCommand(gvElevationDrawings, "select * from Enquiry_ElevationDetails where ENQ_ID= '" + ddlEnquiryNo.SelectedItem.Value + "'");
        }
    }



    private void EnquiryFill()
    {
        SM.SalesEnquiry obj = new SM.SalesEnquiry();

        if (obj.SalesEnquiry_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            ddlEnquiryNo.SelectedValue = obj.Enqid;
            txtenquirydate.Text = obj.EnqDate;

        }


    }
   protected void ddlEnquiryNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesEnquiry obj = new SM.SalesEnquiry();
        if (obj.SalesEnquiry_Select(ddlEnquiryNo.SelectedItem.Value) > 0)
        {
            txtenquirydate.Text = obj.EnqDate;
        }

    }
    protected void btnsubmitElevationdrawing_Click(object sender, EventArgs e)
    {
        try
        {

            SM.SalesEnquiry objSM = new SM.SalesEnquiry();
            foreach (HttpPostedFile uploadfile in FileUpload1.PostedFiles)
            {
                string Attachment = "";
                objSM.ElevationReceiveddate = General.toMMDDYYYY(txtElevationreceiveddate.Text);
                objSM.Elevationremarks = txtElevationremarks.Text;
                objSM.Enqid = ddlEnquiryNo.SelectedItem.Value;

                Random rand = new Random();
                string randNumber = Convert.ToString(rand.Next(0, 10000));
                string path = Server.MapPath("~/Content/ElevationDrawings/");
                string fileName = System.IO.Path.GetFileName(uploadfile.FileName);

                Attachment = randNumber + "_" + fileName;
                uploadfile.SaveAs(path + randNumber + "_" + fileName);
                objSM.elevationDocuments = Attachment;
                objSM.SalesEnquiry_ElevationDetails_Save();
            }












            //SM.SalesEnquiry objSM = new SM.SalesEnquiry();

            //objSM.ElevationReceiveddate = General.toMMDDYYYY(txtElevationreceiveddate.Text);
            //objSM.Elevationremarks = txtElevationremarks.Text;
            //objSM.Enqid = ddlEnquiryNo.SelectedItem.Value;

            //if (FileUpload1.HasFiles)
            //{
            //    #region ElevationDocuments
            //    string Attachment = "";
            //    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Content/ElevationDrawings"))
            //    {

            //        foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
            //        {
            //            Random rand = new Random();
            //            string randNumber = Convert.ToString(rand.Next(0, 10000));
            //            string path = Server.MapPath("~/Content/ElevationDrawings/");
            //            string fileName = System.IO.Path.GetFileName(uploadedFile.FileName);

            //            Attachment = randNumber + "_" + fileName;
            //            uploadedFile.SaveAs(path + randNumber + "_" + fileName);
            //            objSM.elevationDocuments = Attachment;
            //        }


            //    }

            //    #endregion
            //}
            //else
            //{
            //    objSM.elevationDocuments = "";
            //}

            //MessageBox.Show(this, objSM.SalesEnquiry_ElevationDetails_Save());
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            txtElevationremarks.Text = "";
            gvElevationDrawings.DataBind();
            General.GridBindwithCommand(gvElevationDrawings, "select * from Enquiry_ElevationDetails where ENQ_ID= '" + Request.QueryString["Cid"].ToString() + "'");
          

            SM.Dispose();
           // Response.Redirect("~/Modules/Sales/SalesEnquiry.aspx");
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
                SM.SalesEnquiry objSM = new SM.SalesEnquiry();
                MessageBox.Notify(this, objSM.ElevationDetails_Delete(gvElevationDrawings.SelectedRow.Cells[0].Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                gvElevationDrawings.DataBind();
                General.GridBindwithCommand(gvElevationDrawings, "select * from Enquiry_ElevationDetails where ENQ_ID= '" + ddlEnquiryNo.SelectedItem.Value + "'");

            }
        }
        else
        {
            MessageBox.Notify(this, "Please select atleast a Record");
        }
    }
   






}