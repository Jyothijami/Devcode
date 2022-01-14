using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_QuotImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        // this.RegisterPostBackControl();

        if (!IsPostBack)
        {


            if (Qid != "")
            {

                SM.SalesQuotation.SalesQuotation_Select(ddlQuatationno);

                ddlQuatationno.SelectedValue = Request.QueryString["Cid"].ToString();
                ddlQuatationno_SelectedIndexChanged(sender, e);

            }





        }
    }



    protected void ddlQuatationno_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesQuotation obj = new SM.SalesQuotation();
        if (obj.SalesQuotation_Select(ddlQuatationno.SelectedItem.Value) > 0)
        {
            txtQuatationDate.Text = obj.QuotDate;
            General.GridBindwithCommand(gvItems, "select * from Sales_QuotationDetails where Quotation_Id = '" + ddlQuatationno.SelectedItem.Value + "'");


        }
    }
    protected void gvItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("save"))
        {


            SM.SalesQuotation obj = new SM.SalesQuotation();

            //GridView Row Index
            int rowIndex = int.Parse(e.CommandArgument.ToString().Trim());
            TextBox txtelevationview = (TextBox)gvItems.Rows[rowIndex].FindControl("txtelevationview");
            // ID of the Current Row
            String ID = gvItems.DataKeys[rowIndex].Values["QuotationDet_id"].ToString().Trim();

            //File Upload Instance of the Current Row

            FileUpload fileUpload = (FileUpload)gvItems.Rows[rowIndex].FindControl("FileUpload1");


            string filename = fileUpload.PostedFile.FileName;


            Stream fs = fileUpload.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

            string connect = ConfigurationManager.ConnectionStrings["DBCon"].ToString();
            SqlConnection conn = new SqlConnection(connect);

            conn.Open();
            //String strQuery = "update cfamenities_master set aminityimage=@image WHERE amenitiesunkid=" + Amentyid + "";

            String strQuery = "update Sales_QuotationDetails set Item_Image=@image,ElevationView =@elevation  WHERE QuotationDet_id =" + ID + "";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            cmd.Parameters.Add("@image", SqlDbType.Binary).Value = bytes;
            cmd.Parameters.Add("@elevation", SqlDbType.NVarChar).Value = txtelevationview.Text;
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show(this, "Image Uploaded Successfully");
                General.GridBindwithCommand(gvItems, "select * from Sales_QuotationDetails where Quotation_Id = '" + ddlQuatationno.SelectedItem.Value + "'");

            }
            else
            {
                MessageBox.Show(this, "Image  Uploading Failed..!");
            }

        }
    }
    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int count = General.CountofRecordsWithQuery("select count(*) from Sales_QuotationDetails where QuotationDet_id = " + Convert.ToInt16(e.Row.Cells[0].Text) + " and  Item_Image IS NOT NULL");
            if (count > 0)
                (e.Row.FindControl("Image") as Image).ImageUrl = "~/Modules/Sales/Handler.ashx?id=" + Convert.ToInt16(e.Row.Cells[0].Text) + "";

        }
    }
}