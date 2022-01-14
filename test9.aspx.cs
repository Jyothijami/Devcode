using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using phani.MessageBox;
using Phani.Modules;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using phani.Classes;
public partial class test9 : System.Web.UI.Page
{

    DataTable dt = new DataTable();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindData();



            //SM.CustomerMaster.CustomerMaster_Select(Books);
            //Books.Multiple = true;


        }
    }


    private void BindData()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString()))
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT CUST_NAME,CUST_ID FROM Customer_Master";
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                // BIND THE SELECT DROP-DOWN LIST WITH A DATABASE TABLE.
                Books.DataSource = dt;
                Books.DataTextField = "CUST_NAME";
                Books.DataValueField = "CUST_ID";

                Books.DataBind();

                // FOR MULTIPLE SELECTION. SET THE VALUE AS FALSE, AND SEE WHAT HAPPENS.
                Books.Multiple = true;
            }
        }


        // SM.CustomerMaster.CustomerMaster_Select(Books);


    }





    //protected void Button1_Click(object sender, EventArgs e)
    //{


    //    // int y = 0;
    //    lblItem.Text = "";
    //    foreach (ListItem item in Books.Items)
    //    {
    //        if (item.Selected)
    //        {
    //            //y++;
    //            //lblItem.Text += y.ToString() + "<hr/>" + item.Text.ToString() + " Id : " + item.Value.ToString() + "<br/><br/>";



    //            lblItem.Text += item.Text.ToString() + item.Value.ToString();


    //        }
    //    }

    //}










    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string filename = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath(filename));
            ExportToGrid(Server.MapPath(filename));
            //GridView1.DataBind();
            // BindEmpAttendanceGrid();
        }
        else
        {
            MessageBox.Show(this, "Please Select A Location & File To Upload");
        }
    }
    void ExportToGrid(String path)
    {
        OleDbConnection MyConnection = null;
        DataSet DtSet = null;
        OleDbDataAdapter MyCommand = null;
        MyConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties=Excel 12.0;");


        MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet8$]", MyConnection);
        DtSet = new DataSet();
        MyCommand.Fill(DtSet, "[Sheet8$]");
        dt = DtSet.Tables[0];
        MyConnection.Close();
        General obj = new General();
        if (dt.Rows.Count > 0)
        {

            foreach (DataRow dr in dt.Rows)
            {
                string sql;
                if (dr.ItemArray[0].ToString() != "")
                {
                    //                    sql = @"insert into YANTRA_ITEM_MAST (ITEM_CODE,ITEM_NAME,ITEM_SPEC,ITEM_MATERIAL_TYPE,IT_TYPE_ID,UOM_ID,ITEM_PRINCIPAL_NAME,ITEM_SERIES,ITEM_PURCHASE_SPEC,ITEM_MODEL_NO,IC_ID,BRAND_ID,ITEM_BARCODE,ITEM_MRP,ITEM_RSP)  values 
                    //                        ('" + dr.ItemArray[0].ToString() + "','" + dr.ItemArray[1].ToString() + "','" + dr.ItemArray[2].ToString() + "','" + dr.ItemArray[3].ToString() + "','" + dr.ItemArray[4].ToString() + "','" + dr.ItemArray[5].ToString() + "','" + dr.ItemArray[6].ToString() + "','" + dr.ItemArray[7].ToString() + "','" + dr.ItemArray[8].ToString() + "','" + dr.ItemArray[9].ToString() + "','" + dr.ItemArray[10].ToString() + "','" + dr.ItemArray[11].ToString() + "','" + dr.ItemArray[12].ToString() + "','" + dr.ItemArray[13].ToString() + "','" + dr.ItemArray[14].ToString() + "' ) ";

//                    sql = @"insert into Material_Master(Material_Id,Material_Code,Category_Id,Box_Size,Bar_Length,UOM_Id,Description,Weight,Plant_Id,Storage_Location_Id,Item_Group,SellingPrice,Series,Cp_Id,BuyingPrice,BuyingCurrency,Brand_Id,SellingCurrency,Status)  values 
//                        ('" + dr.ItemArray[0].ToString() + "','" + dr.ItemArray[1].ToString() + "','" + dr.ItemArray[2].ToString() + "','" + dr.ItemArray[3].ToString() + "','" + dr.ItemArray[4].ToString() + "','" + dr.ItemArray[5].ToString() + "','" + dr.ItemArray[6].ToString() + "','" + dr.ItemArray[7].ToString() + "','" + dr.ItemArray[8].ToString() + "','" + dr.ItemArray[9].ToString() + "','" + dr.ItemArray[10].ToString() + "','" + dr.ItemArray[11].ToString() + "','" + dr.ItemArray[12].ToString() + "','" + dr.ItemArray[13].ToString() + "','" + dr.ItemArray[14].ToString() + "','" + dr.ItemArray[15].ToString() + "','" + dr.ItemArray[16].ToString() + "','" + dr.ItemArray[17].ToString() + "','" + dr.ItemArray[18].ToString() + "') ";



                    sql = @"insert into InventoryMasters(ItemId,ColorId,Length,InventoryDate,InventoryType,SOID,Qty)  values 
                        ('" + dr.ItemArray[0].ToString() + "','" + dr.ItemArray[1].ToString() + "','" + dr.ItemArray[2].ToString() + "',  ' getdate()' ,'" + dr.ItemArray[3].ToString() + "','" + dr.ItemArray[4].ToString() + "','" + dr.ItemArray[5].ToString() + "') ";





                    obj.ReturnExecuteNoneQuery(sql);
                    MessageBox.Show(this, "Data Inserted Successfully");

                }

            }

        }

    }





    protected void btnblock_Click(object sender, EventArgs e)
    {
        try
        {
            string pagenavigationstr = "../Modules/Reports/SMReportViewer.aspx?type=Dummy";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
}