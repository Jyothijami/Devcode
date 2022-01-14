using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_BOQInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
        if (Qid != "")
        {

           // Masters.MaterialMaster.MaterialMaster_Select(ddlItemSeries);
            SM.SalesEnquiry.SalesEnquiry_Select(ddlEnquiryNo);
            EnquiryFill();
            gvitems.DataBind();

            finishFill();
            glassfill();

            General.GridBindwithCommand(gvElevationDrawings, "select * from Enquiry_ElevationDetails where ENQ_ID= '" + ddlEnquiryNo.SelectedItem.Value + "'");
            General.GridBindwithCommand(gvFloorPlan, "select * from Enquiry_FloorPlanDetails where ENQ_ID= '" + ddlEnquiryNo.SelectedItem.Value + "'");


        }

        
           // gvitems.DataBind();
          //  SM.SalesEnquiry.SalesEnquiry_Select(ddlEnquiryNo);
        }
    }

    private void glassfill()
    {
        SM.SalesEnquiry obj = new SM.SalesEnquiry();
        if (obj.GlassDetails_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            txtglassspecification.Text = HttpUtility.HtmlDecode(obj.GlassSpecification);
            txtglassreceiveddate.Text = obj.GlassReceiveddate;
            txtglassthick.Text = obj.Glassthick;
            txtGlassremarks.Text = HttpUtility.HtmlDecode(obj.GlassRemarks);

            btnGlassdetailsSubmit.Text = "Update";
        }
        else
        {
            btnGlassdetailsSubmit.Text = "Submit";
        }
    }

    private void finishFill()
    {
        SM.SalesEnquiry obj = new SM.SalesEnquiry();
        if (obj.FinishDetails_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            txtfinishcolor.Text = obj.FinishColor;
            txtfinsihedReceiveddate.Text = obj.FinishReceiveddate;
            txtfinishprofile.Text = obj.FinishProfile;
            txtfinishremarks.Text = obj.FinishRemarks;

            btnfinishSubmit.Text = "Update";
        }
        else
        {
            btnfinishSubmit.Text = "Submit";
        }
    }

    private void EnquiryFill()
    {
        SM.SalesEnquiry obj = new SM.SalesEnquiry();

        if(obj.SalesEnquiry_Select(Request.QueryString["Cid"].ToString())>0)
        {
            ddlEnquiryNo.SelectedValue= obj.Enqid;
            txtenquirydate.Text = obj.EnqDate;

            obj.SalesEnquiry_Select(ddlEnquiryNo.SelectedItem.Value, gvitems);





        }
        

    }
    protected void btnAddItems_Click(object sender, EventArgs e)
    {
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("CodeNo");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Width");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("height");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SillHeight");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Glass");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("FlyScreen");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ProfileFinish");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);

        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvitems.SelectedIndex > -1)
                {
                    if (gvrow.RowIndex == gvitems.SelectedRow.RowIndex)
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["CodeNo"] = txtCode.Text;
                        dr["Width"] = txtwidth.Text; ;
                        dr["height"] = txtheight.Text;
                        dr["SillHeight"] = txtsillHeight.Text;
                        dr["Series"] = txtQuantity.Text;
                        dr["Qty"] = txtQuantity.Text;
                        dr["Glass"] = txtGlass.Text;
                        dr["FlyScreen"] = txtflyscreen.Text;
                        dr["ProfileFinish"] = txtprofilefinish.Text;
                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["CodeNo"] = gvrow.Cells[2].Text;
                        dr["Width"] = gvrow.Cells[3].Text;
                        dr["height"] = gvrow.Cells[4].Text;
                        dr["SillHeight"] = gvrow.Cells[5].Text;
                        dr["Series"] = gvrow.Cells[6].Text;
                        dr["Qty"] = gvrow.Cells[7].Text;
                        dr["Glass"] = gvrow.Cells[8].Text;
                        dr["FlyScreen"] = gvrow.Cells[9].Text;
                        dr["ProfileFinish"] = gvrow.Cells[10].Text;
                       
                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["CodeNo"] = gvrow.Cells[2].Text;
                    dr["Width"] = gvrow.Cells[3].Text;
                    dr["height"] = gvrow.Cells[4].Text;
                    dr["SillHeight"] = gvrow.Cells[5].Text;
                    dr["Series"] = gvrow.Cells[6].Text;
                    dr["Qty"] = gvrow.Cells[7].Text;
                    dr["Glass"] = gvrow.Cells[8].Text;
                    dr["FlyScreen"] = gvrow.Cells[9].Text;
                    dr["ProfileFinish"] = gvrow.Cells[10].Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }


        if (gvitems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["CodeNo"] = txtCode.Text;
            drnew["Width"] = txtwidth.Text; ;
            drnew["height"] = txtheight.Text;
            drnew["SillHeight"] = txtsillHeight.Text;
            drnew["Series"] = txtseries.Text;
            drnew["Qty"] = txtQuantity.Text;
            drnew["Glass"] = txtGlass.Text;
            drnew["FlyScreen"] = txtflyscreen.Text;
            drnew["ProfileFinish"] = txtprofilefinish.Text;
            SalesOrderItems.Rows.Add(drnew);
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
        gvitems.SelectedIndex = -1;
        btnReset_Click(sender, e);
    }
    protected void ddlEnquiryNo_SelectedIndexChanged(object sender, EventArgs e)
    {
            SM.SalesEnquiry obj = new SM.SalesEnquiry();
            if(obj.SalesEnquiry_Select(ddlEnquiryNo.SelectedItem.Value) > 0)
            {
                txtenquirydate.Text = obj.EnqDate;
            }
                
    }
    protected void btnDoorSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SM.SalesEnquiry objSM = new SM.SalesEnquiry();
            objSM.SalesEnquiryDetails_Delete(ddlEnquiryNo.SelectedItem.Value);
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                objSM.Enqid = ddlEnquiryNo.SelectedItem.Value;
                objSM.Codes = gvrow.Cells[2].Text;
                objSM.Width = gvrow.Cells[3].Text;
                objSM.Height = gvrow.Cells[4].Text;
                objSM.SillHeight = gvrow.Cells[5].Text;
                objSM.Series = gvrow.Cells[6].Text;
                objSM.Qty = gvrow.Cells[7].Text;
                objSM.Glass = gvrow.Cells[8].Text;
                objSM.Flyscreen = gvrow.Cells[9].Text;
                objSM.ProfileFinish = gvrow.Cells[10].Text;
                 MessageBox.Show(this,objSM.SalesEnquiryDetails_Save());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            gvitems.DataBind();


        }
    }
    protected void btnsubmitElevationdrawing_Click(object sender, EventArgs e)
    {
        try
        {
            SM.SalesEnquiry objSM = new SM.SalesEnquiry();

            objSM.ElevationReceiveddate = General.toMMDDYYYY(txtElevationreceiveddate.Text);
            objSM.Elevationremarks = txtElevationremarks.Text;
            objSM.Enqid = ddlEnquiryNo.SelectedItem.Value;

            if (FileUpload1.HasFiles)
            {
                #region ElevationDocuments
                string Attachment = "";
                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Content/ElevationDrawings"))
                {

                    foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                    {
                        Random rand = new Random();
                        string randNumber = Convert.ToString(rand.Next(0, 10000));
                        string path = Server.MapPath("~/Content/ElevationDrawings/");
                        string fileName = System.IO.Path.GetFileName(uploadedFile.FileName);

                        Attachment = randNumber + "_" + fileName;
                        uploadedFile.SaveAs(path + randNumber + "_" + fileName);
                        objSM.elevationDocuments = Attachment;
                    }


                }

                #endregion
            }
            else
            {
                objSM.elevationDocuments = "";
            }

            MessageBox.Show(this, objSM.SalesEnquiry_ElevationDetails_Save());

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            gvElevationDrawings.DataBind();
        }
    }
    protected void btnfloorplansubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SM.SalesEnquiry objSM = new SM.SalesEnquiry();

            objSM.floorplanreceiveddate = General.toMMDDYYYY(txtfloorplanreceiveddate.Text);
            objSM.floorplanremarks = txtfloorplanremarks.Text;
            objSM.Enqid = ddlEnquiryNo.SelectedItem.Value;

            if (FileUpload2.HasFiles)
            {
                #region FloorplanDocuments
                string Attachment = "";
                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Content/FloorPlanDrawings"))
                {

                    foreach (HttpPostedFile uploadedFile in FileUpload2.PostedFiles)
                    {
                        Random rand = new Random();
                        string randNumber = Convert.ToString(rand.Next(0, 10000));
                        string path = Server.MapPath("~/Content/FloorPlanDrawings/");
                        string fileName = System.IO.Path.GetFileName(uploadedFile.FileName);

                        Attachment = randNumber + "_" + fileName;
                        uploadedFile.SaveAs(path + randNumber + "_" + fileName);
                        objSM.floorplandocuments = Attachment;
                    }


                }

                #endregion
            }
            else
            {
                objSM.floorplandocuments = "";
            }

            MessageBox.Show(this, objSM.SalesEnquiry_FloorDetails_Save());

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            gvFloorPlan.DataBind();
        }
    }






    protected void btnGlassdetailsSubmit_Click(object sender, EventArgs e)
    {
        if(btnGlassdetailsSubmit.Text == "Submit")
        {
            try
            {
                SM.SalesEnquiry objSM = new SM.SalesEnquiry();

                objSM.GlassReceiveddate = General.toMMDDYYYY(txtglassreceiveddate.Text);
                objSM.Glassthick = HttpUtility.HtmlEncode(txtglassthick.Text);
                objSM.GlassRemarks = HttpUtility.HtmlEncode(txtGlassremarks.Text);
                objSM.Enqid = ddlEnquiryNo.SelectedItem.Value;

                MessageBox.Show(this, objSM.SalesEnquiry_GlassDetails_Save());

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString());
            }
            finally
            { }
        }
        else
        {
            try
            {
                SM.SalesEnquiry objSM = new SM.SalesEnquiry();

                objSM.GlassReceiveddate = General.toMMDDYYYY(txtglassreceiveddate.Text);
                objSM.Glassthick = txtglassthick.Text;
                objSM.GlassRemarks = HttpUtility.HtmlEncode(txtGlassremarks.Text);
                objSM.GlassSpecification = HttpUtility.HtmlEncode(txtglassspecification.Text);
                objSM.Enqid = ddlEnquiryNo.SelectedItem.Value;

                MessageBox.Show(this, objSM.GlassDetails_Update());

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString());
            }
            finally
            { }
        }

        
    }
    protected void btnfinishSubmit_Click(object sender, EventArgs e)
    {

        if(btnfinishSubmit.Text == "Submit")
        {
            try
            {
                SM.SalesEnquiry objSM = new SM.SalesEnquiry();

                objSM.FinishReceiveddate = General.toMMDDYYYY(txtfinsihedReceiveddate.Text);
                objSM.FinishColor = txtfinishcolor.Text;
                objSM.FinishRemarks = txtfinishremarks.Text;
                objSM.FinishProfile = txtfinishprofile.Text;
                objSM.Enqid = ddlEnquiryNo.SelectedItem.Value;

                MessageBox.Show(this, objSM.SalesEnquiry_FinishDetails_Save());

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString());
            }
            finally
            { }
        }
        else
        {
            try
            {
                SM.SalesEnquiry objSM = new SM.SalesEnquiry();

                objSM.FinishReceiveddate = General.toMMDDYYYY(txtfinsihedReceiveddate.Text);
                objSM.FinishColor = txtfinishcolor.Text;
                objSM.FinishRemarks = txtfinishremarks.Text;
                objSM.FinishProfile = txtfinishprofile.Text;
                objSM.Enqid = ddlEnquiryNo.SelectedItem.Value;

                MessageBox.Show(this, objSM.FinishDetails_Update());

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString());
            }
            finally
            { }
        }



       
    }
    protected void gvitems_RowDataBound(object sender, GridViewRowEventArgs e)
    {

         // gvitems.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
           
           e.Row.Cells[0].Visible = false;
           
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        
        txtCode.Text = "";
        txtwidth.Text = "";
        txtheight.Text = "";
        txtsillHeight.Text = "";

        txtQuantity.Text = "";
        txtGlass.Text = "";
        txtflyscreen.Text = "";

    }
    protected void gvitems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvitems.Rows[e.RowIndex].Cells[1].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("CodeNo");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Width");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("height");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("SillHeight");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Series");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Glass");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("FlyScreen");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ProfileFinish");
        SalesOrderItems.Columns.Add(col);
        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                   DataRow dr = SalesOrderItems.NewRow();
                   dr["CodeNo"] = gvrow.Cells[2].Text;
                   dr["Width"] = gvrow.Cells[3].Text;
                   dr["height"] = gvrow.Cells[4].Text;
                   dr["SillHeight"] = gvrow.Cells[5].Text;
                   dr["Series"] = gvrow.Cells[6].Text;
                   dr["Qty"] = gvrow.Cells[7].Text;
                   dr["Glass"] = gvrow.Cells[8].Text;

                   dr["FlyScreen"] = gvrow.Cells[9].Text;
                   dr["ProfileFinish"] = gvrow.Cells[10].Text;
                        SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
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
    protected void lbtnFloorDetails_Click(object sender, EventArgs e)
    {
        LinkButton lbtnRegionalMaster;
        lbtnRegionalMaster = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnRegionalMaster.Parent.Parent;
        gvFloorPlan.SelectedIndex = gvRow.RowIndex;

        if (gvElevationDrawings.SelectedIndex > -1)
        {
            try
            {
                SM.SalesEnquiry objSM = new SM.SalesEnquiry();
                MessageBox.Notify(this, objSM.FloorPlanDetails_Delete(gvFloorPlan.SelectedRow.Cells[0].Text));
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