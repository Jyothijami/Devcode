using phani.MessageBox;
using Phani.Modules;
using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

public partial class Modules_Sales_BOQInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            SM.SalesEnquiry.SalesEnquiry_Select(ddlEnquiryNo);
            EnquiryFill();
            gvitems.DataBind();
        }
    }

    private void EnquiryFill()
    {
        SM.SalesEnquiry obj = new SM.SalesEnquiry();

        if (obj.SalesEnquiry_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            ddlEnquiryNo.SelectedValue = obj.Enqid;
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

        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Location");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("TotalArea");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("TotalAmount");
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

                        dr["Description"] = txtdescription.Text;
                        dr["Location"] = txtLocation.Text;
                        dr["TotalArea"] = txttotalarea.Text;
                        dr["TotalAmount"] = txttotalamount.Text;

                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["CodeNo"] = gvrow.Cells[2].Text;
                        dr["Series"] = gvrow.Cells[3].Text;
                        dr["Description"] = gvrow.Cells[4].Text;
                        dr["Glass"] = gvrow.Cells[5].Text;
                        dr["Location"] = gvrow.Cells[6].Text;
                        dr["FlyScreen"] = gvrow.Cells[7].Text;
                        dr["Width"] = gvrow.Cells[8].Text;
                        dr["height"] = gvrow.Cells[9].Text;
                        dr["SillHeight"] = gvrow.Cells[10].Text;

                        dr["Qty"] = gvrow.Cells[11].Text;
                        dr["TotalArea"] = gvrow.Cells[12].Text;
                        dr["TotalAmount"] = gvrow.Cells[13].Text;

                        dr["ProfileFinish"] = gvrow.Cells[14].Text;

                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["CodeNo"] = gvrow.Cells[2].Text;
                    dr["Series"] = gvrow.Cells[3].Text;
                    dr["Description"] = gvrow.Cells[4].Text;
                    dr["Glass"] = gvrow.Cells[5].Text;
                    dr["Location"] = gvrow.Cells[6].Text;
                    dr["FlyScreen"] = gvrow.Cells[7].Text;
                    dr["Width"] = gvrow.Cells[8].Text;
                    dr["height"] = gvrow.Cells[9].Text;
                    dr["SillHeight"] = gvrow.Cells[10].Text;

                    dr["Qty"] = gvrow.Cells[11].Text;
                    dr["TotalArea"] = gvrow.Cells[12].Text;
                    dr["TotalAmount"] = gvrow.Cells[13].Text;

                    dr["ProfileFinish"] = gvrow.Cells[14].Text;

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
            drnew["Series"] = txtQuantity.Text;
            drnew["Qty"] = txtQuantity.Text;
            drnew["Glass"] = txtGlass.Text;
            drnew["FlyScreen"] = txtflyscreen.Text;
            drnew["ProfileFinish"] = txtprofilefinish.Text;

            drnew["Description"] = txtdescription.Text;
            drnew["Location"] = txtLocation.Text;
            drnew["TotalArea"] = txttotalarea.Text;
            drnew["TotalAmount"] = txttotalamount.Text;
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
        if (obj.SalesEnquiry_Select(ddlEnquiryNo.SelectedItem.Value) > 0)
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
                //objSM.Codes = gvrow.Cells[2].Text;
                //objSM.Width = gvrow.Cells[3].Text;
                //objSM.Height = gvrow.Cells[4].Text;
                //objSM.SillHeight = gvrow.Cells[5].Text;
                //objSM.Series = gvrow.Cells[6].Text;
                //objSM.Qty = gvrow.Cells[7].Text;
                //objSM.Glass = gvrow.Cells[8].Text;
                //objSM.Flyscreen = gvrow.Cells[9].Text;
                //objSM.ProfileFinish = gvrow.Cells[10].Text;

                objSM.Codes = gvrow.Cells[2].Text;
                objSM.Series = gvrow.Cells[3].Text;
                objSM.DetDescription = gvrow.Cells[4].Text;
                objSM.Glass = gvrow.Cells[5].Text;
                objSM.DetLocation = gvrow.Cells[6].Text;
                objSM.Flyscreen = gvrow.Cells[7].Text;
                objSM.Width = gvrow.Cells[8].Text;
                objSM.Height = gvrow.Cells[9].Text;
                objSM.SillHeight = gvrow.Cells[10].Text;

                objSM.Qty = gvrow.Cells[11].Text;
                objSM.DetTotalArea = gvrow.Cells[12].Text;
                objSM.DetTotalAmount = gvrow.Cells[13].Text;

                objSM.ProfileFinish = gvrow.Cells[14].Text;



                objSM.HardwareColor = gvrow.Cells[15].Text;
                objSM.InstallationCharges = gvrow.Cells[16].Text;
                objSM.SystemCost = gvrow.Cells[17].Text;
                objSM.Totalrmt = gvrow.Cells[18].Text;
                objSM.Totalrft = gvrow.Cells[19].Text;
                objSM.ElevationView = gvrow.Cells[20].Text;




                MessageBox.Show(this, objSM.SalesEnquiryDetails_Save());
            }
            objSM.SalesEnquiry_Select(ddlEnquiryNo.SelectedItem.Value, gvitems);
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
        txtseries.Text = "";
        txtprofilefinish.Text = "";
        txtdescription.Text = "";
        txtLocation.Text = "";
        txttotalarea.Text = "";
        txttotalamount.Text = "";
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

    //protected void btnExcelTemplate_Click(object sender, EventArgs e)
    //{
    //    //string strURL = "~/Content/Templates/Enquiry_Template.xlsx";
    //    //WebClient req = new WebClient();
    //    //HttpResponse response = HttpContext.Current.Response;
    //    //response.Clear();
    //    //response.ClearContent();
    //    //response.ClearHeaders();
    //    //response.Buffer = true;
    //    //response.AddHeader("Content-Disposition", "attachment;filename=\"" + Server.MapPath(strURL) + "\"");
    //    //byte[] data = req.DownloadData(Server.MapPath(strURL));
    //    //response.BinaryWrite(data);
    //    //response.End();

    //    //Response.ContentType = "Application/vnd.ms-excel";
    //    //Response.AppendHeader("Content-Disposition", "attachment; filename=" + "Enquiry_Template.xlsx");
    //    //Response.TransmitFile(Server.MapPath("~\\Content\\Templates\\Enquiry_Template.xlsx"));
    //    //Response.End();

    //    //string PathToExcelFile = Server.MapPath("~\\Content\\Templates\\Enquiry_Template.xlsx");

    //    //FileInfo file = new FileInfo(PathToExcelFile);
    //    //if (file.Exists)
    //    //{
    //    //    Response.Clear();
    //    //    Response.ClearHeaders();
    //    //    Response.ClearContent();
    //    //    Response.AddHeader("content-disposition", "attachment; filename=" + PathToExcelFile);
    //    //    Response.AddHeader("Content-Type", "application/Excel");
    //    //    Response.ContentType = "Application/vnd.ms-excel";
    //    //    Response.AddHeader("Content-Length", file.Length.ToString());
    //    //    Response.TransmitFile(file.FullName);
    //    //    Response.End();
    //    //}
    //    //else
    //    //{
    //    //    Response.Write("This file does not exist.");
    //    //}

    //    //Response.ContentType = "application/vnd.ms-excel";

    //    //Response.AppendHeader("Content-Disposition", "attachment; filename=Enquiry_Template.xlsx");

    //    //Response.TransmitFile(Server.MapPath("~/Content/Templates/Enquiry_Template.xlsx"));

    //    //Response.End();
    //}
    protected void btnUploadExcel_Click(object sender, EventArgs e)
    {
        if ((FileUpload.HasFile))
        {
            if (!Convert.IsDBNull(FileUpload.PostedFile) &
                    FileUpload.PostedFile.ContentLength > 0)
            {
                // SAVE THE SELECTED FILE IN THE ROOT DIRECTORY.
                FileUpload.SaveAs(Server.MapPath(".") + "\\" + "UploadDocs" + "\\" + FileUpload.FileName);

                // SET A CONNECTION WITH THE EXCEL FILE.
                OleDbConnection myExcelConn = new OleDbConnection
                    ("Provider=Microsoft.ACE.OLEDB.12.0; " +
                        "Data Source=" + Server.MapPath(".") + "\\" + "UploadDocs" +"\\" + FileUpload.FileName +
                        ";Extended Properties=Excel 12.0;");
                try
                {
                    myExcelConn.Open();

                    // GET DATA FROM EXCEL SHEET.
                    OleDbCommand objOleDB =
                        new OleDbCommand("SELECT *FROM [Sheet1$]", myExcelConn);

                    // READ THE DATA EXTRACTED FROM THE EXCEL FILE.
                    OleDbDataReader objBulkReader = null;
                    objBulkReader = objOleDB.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(objBulkReader);

                    //Create Tempory Table
                    DataTable dtTemp = new DataTable();

                    // Creating Header Row
                    dtTemp.Columns.Add("CodeNo");
                    dtTemp.Columns.Add("Series");
                    dtTemp.Columns.Add("Description");
                    dtTemp.Columns.Add("Glass");
                    dtTemp.Columns.Add("Location");
                    dtTemp.Columns.Add("FlyScreen");
                    dtTemp.Columns.Add("Width");
                    dtTemp.Columns.Add("height");
                    dtTemp.Columns.Add("SillHeight");
                    dtTemp.Columns.Add("Qty");
                    dtTemp.Columns.Add("TotalArea");
                    dtTemp.Columns.Add("TotalAmount");
                    dtTemp.Columns.Add("ProfileFinish");

                    dtTemp.Columns.Add("HardwareColor");
                    dtTemp.Columns.Add("InstallationCharges");
                    dtTemp.Columns.Add("SystemCost");
                    dtTemp.Columns.Add("TotalRmt");
                    dtTemp.Columns.Add("TotalRft");
                    dtTemp.Columns.Add("ElevationView");


















                    DataRow drAddItem;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        drAddItem = dtTemp.NewRow();

                       
                        //(string.IsNullOrEmpty(yourTextBox.Text)) ? yourTextBox.Text : null;
                         drAddItem[0] = dt.Rows[i]["Window Codes"].ToString();
                         drAddItem[1] = dt.Rows[i]["System"].ToString();

                       // drAddItem[1] = (string.IsNullOrEmpty(dt.Rows[i]["System"].ToString())) ? dt.Rows[i]["System"].ToString() : null;
                        drAddItem[2] = dt.Rows[i]["Description"].ToString();
                        drAddItem[3] = dt.Rows[i]["Glass"].ToString();
                        drAddItem[4] = dt.Rows[i]["Location"].ToString();
                        drAddItem[5] = dt.Rows[i]["Mesh"].ToString();
                        drAddItem[6] = dt.Rows[i]["Width"].ToString();
                        drAddItem[7] = dt.Rows[i]["height"].ToString();
                        drAddItem[8] = dt.Rows[i]["SillHeight"].ToString();
                        drAddItem[9] = dt.Rows[i]["Qty"].ToString();
                        drAddItem[10] = dt.Rows[i]["Total Area"].ToString();
                        drAddItem[11] = dt.Rows[i]["Total Amount"].ToString();
                        drAddItem[12] = dt.Rows[i]["ProfileColor"].ToString();

                        drAddItem[13] = dt.Rows[i]["HardwareColor"].ToString();
                        drAddItem[14] = dt.Rows[i]["Installation Charges"].ToString();
                        drAddItem[15] = dt.Rows[i]["System Cost"].ToString();
                        drAddItem[16] = dt.Rows[i]["Total RMT"].ToString();
                        drAddItem[17] = dt.Rows[i]["Total RFT"].ToString();
                        drAddItem[18] = dt.Rows[i]["Elevation View"].ToString();
                       
                        
                        
                        
                        dtTemp.Rows.Add(drAddItem);
                    }

                    // FINALLY, BIND THE EXTRACTED DATA TO THE GRIDVIEW.
                    gvitems.DataSource = dtTemp;
                    gvitems.DataBind();

                    //lblConfirm.Text = "DATA IMPORTED TO THE GRID, SUCCESSFULLY.";
                    //lblConfirm.Attributes.Add("style", "color:green");

                    MessageBox.Show(this, "DATA IMPORTED TO THE GRID, SUCCESSFULLY.");
                }
                catch (Exception ex)
                {
                    // SHOW ERROR MESSAGE, IF ANY.
                    //lblConfirm.Text = ex.Message;
                    //lblConfirm.Attributes.Add("style", "color:red");

                    MessageBox.Show(this, ex.ToString());
                }
                finally
                {
                    // CLEAR.
                    myExcelConn.Close(); myExcelConn = null;
                }
            }
        }
    }
}