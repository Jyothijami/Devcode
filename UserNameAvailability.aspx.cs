using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _UserNameAvailability : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["q"] != null)
        {
            GetNames();
        }
    }

    private void GetNames()
    {
        string result = null;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;

        SqlCommand cmd = new SqlCommand("SELECT Count(*) Cnt from Customer_Master WHERE CUST_NAME = LOWER('" + Request.QueryString["q"] + "')", con);

        con.Open();

        SqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            result = rdr["Cnt"].ToString();
        }

        if (result == "0")
        {
            result = "Available";
        }
        else
        {
            result = "Already Exist!";
        }

        Response.Write(result);
    }


}