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

public partial class Modules_Sales_BoQFloorPlans : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
        //    UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
        //    UpdatePanelControlTrigger trigger = new PostBackTrigger();
        //    trigger.ControlID = btnfloorplansubmit.UniqueID;
        //    updatePanel.Triggers.Add(trigger);

            SM.SalesEnquiry.SalesEnquiry_Select(ddlEnquiryNo);
            txtfloorplanreceiveddate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            EnquiryFill();
            General.GridBindwithCommand(gvFloorPlan, "select * from Enquiry_FloorPlanDetails where ENQ_ID= '" + ddlEnquiryNo.SelectedItem.Value + "' order by ENQ_ID desc");
       
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
    //  protected void ddlEnquiryNo_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SM.SalesEnquiry obj = new SM.SalesEnquiry();
    //    if (obj.SalesEnquiry_Select(ddlEnquiryNo.SelectedItem.Value) > 0)
    //    {
    //        txtenquirydate.Text = obj.EnqDate;
    //    }

    //}
 
    //protected void btnfloorplansubmit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        SM.SalesEnquiry objSM = new SM.SalesEnquiry();

    //        objSM.floorplanreceiveddate = General.toMMDDYYYY(txtfloorplanreceiveddate.Text);
    //        objSM.floorplanremarks = txtfloorplanremarks.Text;
    //        objSM.Enqid = ddlEnquiryNo.SelectedItem.Value;

    //        if (FileUpload2.HasFiles)[
    //        {
    //            #region FloorplanDocuments
    //            string Attachment = "";
    //            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Content/FloorPlanDrawings"))
    //            {

    //                foreach (HttpPostedFile uploadedFile in FileUpload2.PostedFiles)
    //                {
    //                    Random rand = new Random();
    //                    string randNumber = Convert.ToString(rand.Next(0, 10000));
    //                    string path = Server.MapPath("~/Content/FloorPlanDrawings/");
    //                    string fileName = System.IO.Path.GetFileName(uploadedFile.FileName);

    //                    Attachment = randNumber + "_" + fileName;
    //                    uploadedFile.SaveAs(path + randNumber + "_" + fileName);
    //                    objSM.floorplandocuments = Attachment;
    //                }


    //            }

    //            #endregion
    //        }
    //        else
    //        {
    //            objSM.floorplandocuments = "";
    //        }

    //        MessageBox.Show(this, objSM.SalesEnquiry_FloorDetails_Save());
    //       // ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(this, ex.Message.ToString());
    //    }
    //    finally
    //    {
    //        txtfloorplanremarks.Text = "";
    //        gvFloorPlan.DataBind();
    //        General.GridBindwithCommand(gvFloorPlan, "select * from Enquiry_FloorPlanDetails where ENQ_ID= '" + Request.QueryString["Cid"].ToString() + "'");
           
    //      //  SM.Dispose();
    //        //Response.Redirect("~/Modules/Sales/SalesEnquiry.aspx");
    //    }
    //}



      protected void btnfloorplansubmit_Click(object sender, EventArgs e)
      {
          try
          {

              SM.SalesEnquiry objSM = new SM.SalesEnquiry();
             foreach(HttpPostedFile uploadfile in FileUpload2.PostedFiles)
             {
                 string Attachment = "";
                 objSM.floorplanreceiveddate = General.toMMDDYYYY(txtfloorplanreceiveddate.Text);
                 objSM.floorplanremarks = txtfloorplanremarks.Text;
                 objSM.Enqid = ddlEnquiryNo.SelectedItem.Value;

                 Random rand = new Random();
                 string randNumber = Convert.ToString(rand.Next(0, 10000));
                 string path = Server.MapPath("~/Content/FloorPlanDrawings/");
                 string fileName = System.IO.Path.GetFileName(uploadfile.FileName);

                 Attachment = randNumber + "_" + fileName;
                 uploadfile.SaveAs(path + randNumber + "_" + fileName);
                 objSM.floorplandocuments = Attachment;
                 objSM.SalesEnquiry_FloorDetails_Save();
             }

              //objSM.floorplanreceiveddate = General.toMMDDYYYY(txtfloorplanreceiveddate.Text);
              //objSM.floorplanremarks = txtfloorplanremarks.Text;
              //objSM.Enqid = ddlEnquiryNo.SelectedItem.Value;

              //if (FileUpload2.HasFiles)
              //{
              //    #region FloorplanDocuments
              //    string Attachment = "";
              //    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Content/FloorPlanDrawings"))
              //    {

              //        foreach (HttpPostedFile uploadedFile in FileUpload2.PostedFiles)
              //        {
              //            Random rand = new Random();
              //            string randNumber = Convert.ToString(rand.Next(0, 10000));
              //            string path = Server.MapPath("~/Content/FloorPlanDrawings/");
              //            string fileName = System.IO.Path.GetFileName(uploadedFile.FileName);

              //            Attachment = randNumber + "_" + fileName;
              //            uploadedFile.SaveAs(path + randNumber + "_" + fileName);
              //            objSM.floorplandocuments = Attachment;
              //        }


              //    }

              //    #endregion
              //}
              //else
              //{
              //    objSM.floorplandocuments = "";
              //}

              //MessageBox.Show(this, objSM.SalesEnquiry_FloorDetails_Save());
              // ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
          }
          catch (Exception ex)
          {
              MessageBox.Show(this, ex.Message.ToString());
          }
          finally
          {
              txtfloorplanremarks.Text = "";
              gvFloorPlan.DataBind();
              General.GridBindwithCommand(gvFloorPlan, "select * from Enquiry_FloorPlanDetails where ENQ_ID= '" + Request.QueryString["Cid"].ToString() + "'");

              //  SM.Dispose();
              //Response.Redirect("~/Modules/Sales/SalesEnquiry.aspx");
          }
      }




   
    protected void lbtnFloorDetails_Click(object sender, EventArgs e)
    {
        LinkButton lbtnRegionalMaster;
        lbtnRegionalMaster = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnRegionalMaster.Parent.Parent;
        gvFloorPlan.SelectedIndex = gvRow.RowIndex;

        if (gvFloorPlan.SelectedIndex > -1)
        {
            try
            {
                SM.SalesEnquiry objSM = new SM.SalesEnquiry();
                MessageBox.Show(this, objSM.FloorPlanDetails_Delete(gvFloorPlan.SelectedRow.Cells[0].Text));
               // MessageBox.Show(this, "Data Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {

                
                gvFloorPlan.DataBind();
                General.GridBindwithCommand(gvFloorPlan, "select * from Enquiry_FloorPlanDetails where ENQ_ID= '" + ddlEnquiryNo.SelectedItem.Value + "'");

            }
        }
        else
        {
            MessageBox.Notify(this, "Please select atleast a Record");
        }
    }







}