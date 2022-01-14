using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using phani.MessageBox;
public partial class test6 : System.Web.UI.Page
{

   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { 
            
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





    protected void Button1_Click(object sender, EventArgs e)
    {

      
       // int y = 0;
        lblItem.Text = "";
        foreach (ListItem item in Books.Items)
        {
            if (item.Selected)
            {
                //y++;
                //lblItem.Text += y.ToString() + "<hr/>" + item.Text.ToString() + " Id : " + item.Value.ToString() + "<br/><br/>";


              
                lblItem.Text +=  item.Text.ToString() +  item.Value.ToString() ;


            }
        }

    }
}