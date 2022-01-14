using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_SoGlassAnalaysis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();



        if (!IsPostBack)
        {
            UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnUploadExcel.UniqueID;
            updatePanel.Triggers.Add(trigger);
            SM.SalesOrder.SalesOrder_Select(ddlEnquiryNo);
            EnquiryFill();
            gvitems.DataBind();
        }
    }

    private void EnquiryFill()
    {
        SM.SalesOrder obj = new SM.SalesOrder();

        if (obj.SalesOrder_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            ddlEnquiryNo.SelectedValue = obj.SOID;
            txtenquirydate.Text = obj.SODATE;

            obj.SoGlassEnquriy_Select(ddlEnquiryNo.SelectedItem.Value, gvitems);
        }
    }

   
    protected void ddlEnquiryNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesOrder obj = new SM.SalesOrder();
        if (obj.SalesOrder_Select(ddlEnquiryNo.SelectedItem.Value) > 0)
        {
            txtenquirydate.Text = obj.SODATE;
        }
    }

    protected void btnDoorSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SM.SalesOrder objSM = new SM.SalesOrder();
            objSM.SalesGlassEnquiryDetails_Delete(ddlEnquiryNo.SelectedItem.Value);
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                objSM.SOID = ddlEnquiryNo.SelectedItem.Value;

                objSM.GlassWindowcode = gvrow.Cells[2].Text;
                objSM.GlassThickness = gvrow.Cells[3].Text;
                objSM.GlassDescription = gvrow.Cells[4].Text;
                objSM.GlassWidth = gvrow.Cells[5].Text;
                objSM.Glassheight = gvrow.Cells[6].Text;
                objSM.GlassQuantity = gvrow.Cells[7].Text;
                objSM.GlassUnit = gvrow.Cells[8].Text;
                objSM.GlassArea = gvrow.Cells[9].Text;
                objSM.GlassWeight = gvrow.Cells[10].Text;

                MessageBox.Show(this, objSM.SalesGlassEnquiryDetails_Save());
            }
            objSM.SoGlassEnquriy_Select(ddlEnquiryNo.SelectedItem.Value, gvitems);
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



    protected void gvitems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvitems.Rows[e.RowIndex].Cells[1].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("WindowCode");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Thickness");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Width");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Height");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Quantity");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Unit");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Area");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Weight");
        SalesOrderItems.Columns.Add(col);
     
        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["WindowCode"] = gvrow.Cells[2].Text;
                    dr["Thickness"] = gvrow.Cells[3].Text;
                    dr["Description"] = gvrow.Cells[4].Text;
                    dr["Width"] = gvrow.Cells[5].Text;
                    dr["Height"] = gvrow.Cells[6].Text;
                    dr["Quantity"] = gvrow.Cells[7].Text;
                    dr["Unit"] = gvrow.Cells[8].Text;
                    dr["Area"] = gvrow.Cells[9].Text;
                    dr["Weight"] = gvrow.Cells[10].Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
    }

    
    
    
    
    
    
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
                        "Data Source=" + Server.MapPath(".") + "\\" + "UploadDocs" + "\\" + FileUpload.FileName +
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
                    dtTemp.Columns.Add("WindowCode");
                    dtTemp.Columns.Add("Thickness");
                    dtTemp.Columns.Add("Description");
                    dtTemp.Columns.Add("Width");
                    dtTemp.Columns.Add("Height");
                    dtTemp.Columns.Add("Quantity");
                    dtTemp.Columns.Add("Unit");
                    dtTemp.Columns.Add("Area");
                    dtTemp.Columns.Add("Weight");
                  

                    //DataRow drAddItem;
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    drAddItem = dtTemp.NewRow();
                    //    drAddItem[0] = dt.Rows[i]["Window Codes"].ToString();
                    //    drAddItem[1] = dt.Rows[i]["System"].ToString();
                    //    drAddItem[2] = dt.Rows[i]["Description"].ToString();
                    //    drAddItem[3] = dt.Rows[i]["Glass"].ToString();
                    //    drAddItem[4] = dt.Rows[i]["Location"].ToString();
                    //    drAddItem[5] = dt.Rows[i]["Mesh"].ToString();
                    //    drAddItem[6] = dt.Rows[i]["Width"].ToString();
                    //    drAddItem[7] = dt.Rows[i]["height"].ToString();
                    //    drAddItem[8] = dt.Rows[i]["SillHeight"].ToString();
                    //    drAddItem[9] = dt.Rows[i]["Qty"].ToString();
                    //    drAddItem[10] = dt.Rows[i]["Total Area"].ToString();
                    //    drAddItem[11] = dt.Rows[i]["Total Amount"].ToString();
                    //    drAddItem[12] = dt.Rows[i]["ProfileFinish"].ToString();
                    //    dtTemp.Rows.Add(drAddItem);
                    //}


                    DataRow drAddItem;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        drAddItem = dtTemp.NewRow();
                        drAddItem[0] = dt.Rows[i]["Window Code"].ToString();
                        drAddItem[1] = dt.Rows[i]["Thickness (mm)"].ToString();
                        drAddItem[2] = dt.Rows[i]["Description"].ToString();
                        drAddItem[3] = dt.Rows[i]["Width (mm)"].ToString();
                        drAddItem[4] = dt.Rows[i]["Height (mm)"].ToString();
                        drAddItem[5] = dt.Rows[i]["Quantity"].ToString();
                        drAddItem[6] = dt.Rows[i]["Unit"].ToString();
                        drAddItem[7] = dt.Rows[i]["Area (m²)"].ToString();
                        drAddItem[8] = dt.Rows[i]["Weight (kg)"].ToString();
                       
                        
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