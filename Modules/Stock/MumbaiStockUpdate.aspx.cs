using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using phaniDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_MumbaiStockUpdate : System.Web.UI.Page
{


    DataTable dt = new DataTable();
    static DBManager dbManager = new DBManager(DataProvider.SqlServer, DBConString.ConnectionString());
    private static int _returnIntValue;


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnfileUpload_Click(object sender, EventArgs e)
    {
        General obj = new General();
        if (FileUpload1.HasFile)
        {
            string sql = @"select FileName  from  Mumbai_FileName where FileName = '" + FileUpload1.FileName + "' ";
            DataTable dttemp3 = obj.ReturnDataTable(sql);

            if (dttemp3.Rows.Count >= 0)
            {
                string Sqls = @"insert into Mumbai_FileName(FileName) values('" + FileUpload1.FileName + "')";
                string strreturn1 = obj.ReturnExecuteNoneQuery(Sqls);

                string filename = FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath(filename));


             

                SM.SalesOrder smobjj = new SM.SalesOrder();
                smobjj.MumbaiStockDetails_Delete();

                smobjj.PREPAREDBY = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
                smobjj.MumbaiStockDetails_Update();
                ExportToGrid(Server.MapPath(filename));
                //GVBind();
            }
            else
            {
                MessageBox.Show(this, "File name Already Exist");
            }
        }
    }

    private void ExportToGrid(string path)
    {
        OleDbConnection MyConnection = null;
        DataSet DtSet = null;
        OleDbDataAdapter MyCommand = null;
        MyConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties='Excel 12.0;IMEX=1'");


        MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
        DtSet = new System.Data.DataSet();
        MyCommand.Fill(DtSet, "[Sheet1$]");
        dt = DtSet.Tables[0];
        MyConnection.Close();

        General obj = new General();

        if (dt.Rows.Count > 0)
        {
            bool found = false;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.ItemArray[0].ToString() == "")
                {
                    found = true;
                    MessageBox.Show(this, "Please Check Excel Having Correct Values");
                    break;
                }

                else
                {

                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    if (!found)
                    //    {

                    string ItemCode = "0";
                    string ColorId = "0";

                    string Barlength, Color;

                    if (dr.ItemArray[3].ToString() == "")
                    {
                        Barlength = "0";
                    }
                    else
                    {
                        Barlength = dr.ItemArray[3].ToString();
                    }
                    if (dr.ItemArray[1].ToString() == "")
                    {
                        Color = "NA";
                    }
                    else
                    {
                        Color = dr.ItemArray[1].ToString();
                    }
                    // Getting ItemCode
                    string sql = @"select Material_Id  from  Material_Master where Material_Code = '" + Convert.ToString(dr.ItemArray[0]).Trim().ToString() + "' ";
                    DataTable dttemp = obj.ReturnDataTable(sql);
                    if (dttemp.Rows.Count > 0)
                    {
                        ItemCode = dttemp.Rows[0]["Material_Id"].ToString();
                        //gETTING cOLOR iD

                        string sql1 = @"select Color_Id  from  Color_Master where Color_Name = '" + Convert.ToString(dr.ItemArray[1]).Trim().ToString() + "' ";
                        DataTable dttemp1 = obj.ReturnDataTable(sql1);
                        if (dttemp1.Rows.Count > 0)
                        {
                            ColorId = dttemp1.Rows[0]["Color_Id"].ToString();
                        }
                        else
                        {
                            ColorId = "0";
                        }

                        sql = @"insert into MumbaiStock(MatId,	ColorId,Quantity, PlantId,	StoragelocId,Length)
                                values('" + ItemCode + "','" + ColorId + "', '" + dr.ItemArray[2].ToString() + "', '" + "0" + "','" + "0" + "','" + Barlength + "') ";
                        obj.ReturnExecuteNoneQuery(sql);

                    }
                    else
                    {
                        string Code = Convert.ToString(dr.ItemArray[0]).Trim().ToString();
                        SM.SalesOrder smobjj = new SM.SalesOrder();
                        smobjj.MumbaiStockDetails_Delete();

                        //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Item Code Missing "+Code+"')", true);


                        MessageBox.Show(this, "Item Code Missing " + Code + "");



                        break;
                    }

                    //    }

                    //}



                }





            }









            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }




}