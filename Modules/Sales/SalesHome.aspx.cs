using phani.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_SalesHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if(!IsPostBack)
        {


          int i =   General.CountofRecordsWithQuery("select count(ENQ_ID) as cou from SalesEnquiry_Master where STATUS = 'New' ");

          lblSalesEnq.Text = i.ToString();
          lblinquiry.Text = i.ToString();

           General obj = new General();

           lbllastupdatedon.Text = obj.GetColumnVal("select MumbaiStock_Updatedon from MumbaiStocksUpdates", "MumbaiStock_Updatedon");





            string dept = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.Department);

            if(dept == "Sales")
            {
                tblitems.Visible = false;
                tblsetup.Visible = false;
            }
            else
            {
                tblitems.Visible = true;
                tblsetup.Visible = true;
            }



        }

    }
}