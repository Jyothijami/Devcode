using phani.MessageBox;
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

public partial class Modules_HR_AddEmpImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if(!IsPostBack)
        { 
        UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
        UpdatePanelControlTrigger trigger = new PostBackTrigger();
        trigger.ControlID = btnUpload.UniqueID;
        updatePanel.Triggers.Add(trigger);


        if (Qid != "")
        {

            HR.EmployeeMaster obj = new HR.EmployeeMaster();
             
            if(obj.EmployeeMaster_Select(Request.QueryString["Cid"].ToString()) > 0 )
            {
                txtempid.Text = obj.EmpID;
                txtempname.Text = obj.EmpFirstName;
                Image.ImageUrl = "~/Modules/HR/Handler.ashx?id=" + Convert.ToInt16(obj.EmpID);
            }
          

        }




        }
    }







    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile == true)
        {
            //string filename = FileUpload1.PostedFile.FileName;
            string ID = txtempid.Text;

            Stream fs = FileUpload1.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

            string connect = ConfigurationManager.ConnectionStrings["DBCon"].ToString();
            SqlConnection conn = new SqlConnection(connect);

            conn.Open();
            String strQuery = "update Employee_Master set EMP_PHOTO=@image  WHERE EMP_ID =" + ID + "";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            cmd.Parameters.Add("@image", SqlDbType.Binary).Value = bytes;
            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show(this, "Image Uploaded Successfully");
                Response.Redirect("~/Modules/HR/EmployeeMaster.aspx");
              
            }
            else
            {
                MessageBox.Show(this, "Image Uploading Failed..!");
            }

        }
        else
        {
            MessageBox.Show(this, "Please Upload Image File");
        }
    }
}