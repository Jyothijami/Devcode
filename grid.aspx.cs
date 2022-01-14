using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using phaniDAL;
using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using System.Net; 
using System.Net.Mail;
using System.IO;


public partial class grid : System.Web.UI.Page
{
    private DataTable dt = new DataTable();
    private static DBManager dbManager = new DBManager(DataProvider.SqlServer, DBConString.ConnectionString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.AddRange(new System.Data.DataColumn[3] { new System.Data.DataColumn("Id", typeof(int)),
                    new System.Data.DataColumn("Name", typeof(string)),
                    new System.Data.DataColumn("Country",typeof(string)) });
            dt.Rows.Add(1, "John Hammond", "United States");
            dt.Rows.Add(2, "Mudassar Khan", "India");
            dt.Rows.Add(3, "Suzanne Mathews", "France");
            dt.Rows.Add(4, "Robert Schidner", "Russia");
            GridView1.DataSource = dt;
            GridView1.DataBind();

            //GridView2.DataBind();

            SM.SalesQuotation.SalesQuotation_Select(DDLPO);

            cblfill();
        }
    }

    private void cblfill()
    {
        cblpo.ClearSelection();
        General obj = new General();
        DataTable dt = new DataTable();
        dt = obj.ReturnDataTable("select * from Quotation_Master");
        cblpo.DataSource = dt;
        cblpo.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string query = "SELECT * FROM Sales_QuotationDetails";

        string condition = string.Empty;
        foreach (ListItem item in cblpo.Items)
        {
            condition += item.Selected ? string.Format("'{0}',", item.Value) : string.Empty;
        }

        if (!string.IsNullOrEmpty(condition))
        {
            condition = string.Format("WHERE Quotation_Id IN ({0})", condition.Substring(0, condition.Length - 1));
        }

        General.GridBindwithCommand(GridView3, " " + query + " " + condition + "");

        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    using (SqlCommand cmd = new SqlCommand(query + condition))
        //    {
        //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //        {
        //            cmd.Connection = con;
        //            using (DataTable dt = new DataTable())
        //            {
        //                sda.Fill(dt);
        //                GridView1.DataSource = dt;
        //                GridView1.DataBind();
        //            }
        //        }
        //    }
        //}
    }

    protected void btnfileUpload_Click(object sender, EventArgs e)
    {
        General obj = new General();
        if (FileUpload1.HasFile)
        {
            string filename = FileUpload1.FileName;
            ExportToGrid(Server.MapPath(filename));
        }
        else
        {
            MessageBox.Show(this, "File name Already Exist");
        }
    }



    /// <summary>
    ///  Only Profiles Stock Update 
    /// </summary>
    /// <param name="path"></param>
    /// 




    private void ExportToGrid(string path)
    {
        OleDbConnection MyConnection = null;
        DataSet DtSet = null;
        OleDbDataAdapter MyCommand = null;
        MyConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties=Excel 12.0;");

        MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
        DtSet = new System.Data.DataSet();
        MyCommand.Fill(DtSet, "[Sheet1$]");
        dt = DtSet.Tables[0];
        MyConnection.Close();

        General obj = new General();

        if (dt.Rows.Count > 0)
        {
            // bool found = false;

            foreach (DataRow dr in dt.Rows)
            {
                // Getting ItemCoder
                //string sql = @"select Material_Id  from  Material_Master where Material_Code = '" + Convert.ToString(dr.ItemArray[0]).Trim().ToString() + "'  ";
                //DataTable dttemp = obj.ReturnDataTable(sql);
                //if (dttemp.Rows.Count > 0)
                //{
                //    string ItemCode = "0";
                //    ItemCode = dttemp.Rows[0]["Material_Id"].ToString();
                //    //gETTING cOLOR iD

                //    string sql1 = @"select Color_Id  from  Color_Master where Color_Name = '" + Convert.ToString(dr.ItemArray[1]).Trim().ToString() + "'  ";
                //    DataTable dttemp1 = obj.ReturnDataTable(sql1);
                //    string ColorCode = "0";
                //    ColorCode = dttemp1.Rows[0]["Color_Id"].ToString();

                //    //Getting Length from Stock
                //    //string sql2 = @"select Length  from  Stock where Length = '" + Convert.ToString(dr.ItemArray[5]).Trim().ToString() + "'  ";
                //    //DataTable dttemp2 = obj.ReturnDataTable(sql2);
                //    string Length = "0";
                //    Length = Convert.ToString(dr.ItemArray[5]).Trim().ToString();


                    string sql3 = @"select * from Stock where MatId='" + Convert.ToString(dr.ItemArray[0]).Trim().ToString() + "' and ColorId='" + Convert.ToString(dr.ItemArray[1]).Trim().ToString() + "' and Length='" + Convert.ToString(dr.ItemArray[3]).Trim().ToString() + "' ";
                    DataTable dttemp3 = obj.ReturnDataTable(sql3);

                    if (dttemp3.Rows.Count > 0)
                    {

                        //sql = @"update Stock set Quantity=CONVERT(BIGINT,Quantity)+'" + dr.ItemArray[2].ToString() + "' where MatId='" + ItemCode + "' and ColorId='" + ColorCode + "' and Length='" + Length + "' ";
                        //obj.ReturnExecuteNoneQuery(sql);

                        string sql = @"update Stock set Quantity=CONVERT(BIGINT,Quantity)-'" + dr.ItemArray[2].ToString() + "' where MatId='" + Convert.ToString(dr.ItemArray[0]).Trim().ToString() + "' and ColorId='" + Convert.ToString(dr.ItemArray[1]).Trim().ToString() + "' and Length='" + Convert.ToString(dr.ItemArray[3]).Trim().ToString() + "' ";
                        obj.ReturnExecuteNoneQuery(sql);




                        // string sql = @"update Stock set Quantity='" + dr.ItemArray[2].ToString() + "' where MatId='" + ItemCode + "' and ColorId='" + ColorCode + "' and Length='" + Length + "' ";
                        //obj.ReturnExecuteNoneQuery(sql);



                    }
//                    else
//                    {
//                        sql = @"insert into Stock(MatId,ColorId,Quantity, PlantId,	StoragelocId,Length)
//                                values('" + ItemCode + "', '" + ColorCode + "','" + dr.ItemArray[2].ToString() + "','" + dr.ItemArray[3].ToString() + "','" + dr.ItemArray[4].ToString() + "','" + dr.ItemArray[5].ToString() + "') ";
//                        obj.ReturnExecuteNoneQuery(sql);
//                    }


                }
                //else
                //{
                //    string Code = Convert.ToString(dr.ItemArray[0]).Trim().ToString();
                //    MessageBox.Show(this, "Item Code Missing " + Code + "");

                //    break;
                //}

            }
        }
   











//    private void ExportToGrid(string path)
//    {
//        OleDbConnection MyConnection = null;
//        DataSet DtSet = null;
//        OleDbDataAdapter MyCommand = null;
//        MyConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties=Excel 12.0;");

//        MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet8$]", MyConnection);
//        DtSet = new System.Data.DataSet();
//        MyCommand.Fill(DtSet, "[Sheet8$]");
//        dt = DtSet.Tables[0];
//        MyConnection.Close();

//        General obj = new General();

//        if (dt.Rows.Count > 0)
//        {
//            // bool found = false;

//            foreach (DataRow dr in dt.Rows)
//            {
//                // Getting ItemCoder
//                string sql = @"select Material_Id  from  Material_Master where Material_Code = '" + Convert.ToString(dr.ItemArray[0]).Trim().ToString() + "'  ";
//                DataTable dttemp = obj.ReturnDataTable(sql);
//                if (dttemp.Rows.Count > 0)
//                {
//                    string ItemCode = "0";
//                    ItemCode = dttemp.Rows[0]["Material_Id"].ToString();
//                    //gETTING cOLOR iD

//                    string sql1 = @"select Color_Id  from  Color_Master where Color_Name = '" + Convert.ToString(dr.ItemArray[1]).Trim().ToString() + "'  ";
//                    DataTable dttemp1 = obj.ReturnDataTable(sql1);
//                    string ColorCode = "0";
//                    ColorCode = dttemp1.Rows[0]["Color_Id"].ToString();

//                   //Getting Length from Stock
//                    //string sql2 = @"select Length  from  Stock where Length = '" + Convert.ToString(dr.ItemArray[5]).Trim().ToString() + "'  ";
//                    //DataTable dttemp2 = obj.ReturnDataTable(sql2);
//                    string Length = "0";
//                    Length = Convert.ToString(dr.ItemArray[5]).Trim().ToString();


//                    string sql3 = @"select * from Stock where MatId='" + ItemCode + "' and ColorId='" + ColorCode + "' and Length='" + Length + "' ";
//                    DataTable dttemp3 = obj.ReturnDataTable(sql3);

//                    if(dttemp3.Rows.Count > 0)
//                    {

//                        //sql = @"update Stock set Quantity=CONVERT(BIGINT,Quantity)+'" + dr.ItemArray[2].ToString() + "' where MatId='" + ItemCode + "' and ColorId='" + ColorCode + "' and Length='" + Length + "' ";
//                        //obj.ReturnExecuteNoneQuery(sql);

//                        //sql = @"update Stock set Quantity=CONVERT(BIGINT,Quantity)+'" + dr.ItemArray[2].ToString() + "' where MatId='" + ItemCode + "' and ColorId='" + ColorCode + "' and Length='" + Length + "' ";
//                        //obj.ReturnExecuteNoneQuery(sql);




//                        sql = @"update Stock set Quantity='" + dr.ItemArray[2].ToString() + "' where MatId='" + ItemCode + "' and ColorId='" + ColorCode + "' and Length='" + Length + "' ";
//                        obj.ReturnExecuteNoneQuery(sql);


                       
//                    }
//                    else
//                    {
//                        sql = @"insert into Stock(MatId,ColorId,Quantity, PlantId,	StoragelocId,Length)
//                                values('" + ItemCode + "', '" + ColorCode + "','" + dr.ItemArray[2].ToString() + "','" + dr.ItemArray[3].ToString() + "','" + dr.ItemArray[4].ToString() + "','" + dr.ItemArray[5].ToString() + "') ";
//                        obj.ReturnExecuteNoneQuery(sql);
//                    }

                   
//                }
//                else
//                {
//                    string Code = Convert.ToString(dr.ItemArray[0]).Trim().ToString();
//                    MessageBox.Show(this, "Item Code Missing " + Code + "");

//                    break;
//                }

//            }
//        }
//    }

    //    private void ExportToGrid(string path)
    //    {
    //        OleDbConnection MyConnection = null;
    //        DataSet DtSet = null;
    //        OleDbDataAdapter MyCommand = null;
    //        MyConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties=Excel 12.0;");

    //        MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
    //        DtSet = new System.Data.DataSet();
    //        MyCommand.Fill(DtSet, "[Sheet1$]");
    //        dt = DtSet.Tables[0];
    //        MyConnection.Close();

    //        General obj = new General();

    //        if (dt.Rows.Count > 0)
    //        {
    //            // bool found = false;

    //            foreach (DataRow dr in dt.Rows)
    //            {
    //                // Getting ItemCode
    //                string sql = @"select Material_Id  from  Material_Master where Material_Code = '" + Convert.ToString(dr.ItemArray[0]).Trim().ToString() + "'  ";
    //                DataTable dttemp = obj.ReturnDataTable(sql);
    //                if (dttemp.Rows.Count > 0)
    //                {
    //                    string ItemCode = "0";
    //                    ItemCode = dttemp.Rows[0]["Material_Id"].ToString();
    //                    //gETTING cOLOR iD

    //                    string sql1 = @"select Color_Id  from  Color_Master where Color_Name = '" + Convert.ToString(dr.ItemArray[1]).Trim().ToString() + "'  ";
    //                    DataTable dttemp1 = obj.ReturnDataTable(sql1);

    //                    string ColorCode = "0";
    //                    ColorCode = dttemp1.Rows[0]["Color_Id"].ToString();

    //                    sql = @"insert into Stock(MatId,ColorId,Quantity, PlantId,	StoragelocId,Length)
    //                                values('" + ItemCode + "', '" + ColorCode + "','" + dr.ItemArray[2].ToString() + "','" + dr.ItemArray[3].ToString() + "','" + dr.ItemArray[4].ToString() + "','" + dr.ItemArray[5].ToString() + "') ";
    //                    obj.ReturnExecuteNoneQuery(sql);

    //                }
    //                else
    //                {
    //                    string Code = Convert.ToString(dr.ItemArray[0]).Trim().ToString();
    //                    MessageBox.Show(this, "Item Code Missing " + Code + "");

    //                    break;
    //                }

    //                //    }

    //                //}

    //            }

    //        }
    //    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //add the thead and tbody section programatically
            e.Row.TableSection = TableRowSection.TableHeader;
        }
    }

    //protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //}

    //protected void GridView2_PreRender(object sender, EventArgs e)
    //{
    //    if (GridView2.HeaderRow != null)
    //    {
    //        GridView2.UseAccessibleHeader = true;
    //        GridView2.HeaderRow.TableSection = TableRowSection.TableHeader;
    //    }
    //}

    protected void DDLPO_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        MessageBox.Show(this, "PostBack");
    }
    protected void btnsend_Click(object sender, EventArgs e)
    {
        MailMessage msg = new MailMessage();
        msg.From = new MailAddress("phani1237@gmail.com");

        string[] multi = txtto.Text.Split(',');

        foreach(string multiemail in multi)
        {
            msg.To.Add(multiemail);
            msg.Subject = txtsubject.Text;
            msg.Body = txtmessage.Text;
            msg.IsBodyHtml = true;
            //if (FileUpload1.PostedFile != null)
            //{
                
            //    /* Get a reference to PostedFile object */
            //    HttpPostedFile attFile = FileUpload1.PostedFile;
            //    /* Get size of the file */
            //    int attachFileLength = attFile.ContentLength;
            //    /* Make sure the size of the file is > 0  */
            //    if (attachFileLength > 0)
            //    {
            //        /* Get the file name */
            //        string strFileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            //        /* Save the file on the server */
            //        FileUpload1.PostedFile.SaveAs(Server.MapPath(strFileName));
            //        /* Create the email attachment with the uploaded file */
            //        MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
            //        /* Attach the newly created email attachment */
            //        msg.Attachments.Add(attach);
            //        /* Store the attach filename so we can delete it later */
            //       string  attach1 = strFileName;
            //    }
            //}
            SmtpClient smt = new SmtpClient();
            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = "phani1237@gmail.com"; //Your Email ID  
            ntwd.Password = "haiamma@1237"; // Your Password  
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.Send(msg);
            
        }




    
        btnsend.Text = "Email Sent Successfully";
        btnsend.ForeColor = System.Drawing.Color.ForestGreen;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
}