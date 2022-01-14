using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.MasterPage
{

    string result;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
          Alumil.Authentication.Session_Check(this);
          string userid = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

        lblUserid.Text = userid;
       //Repeater1.DataBind();

        this.Bindmenu(userid);

       // string eMPiD = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
        image1.ImageUrl = imag2.ImageUrl = imag3.ImageUrl = string.Format("~/Modules/HR/Handler.ashx?id={0}", lblUserid.Text);
         //string.Format("~/Modules/HR/Handler.ashx?id={0}", lblUserid.Text);
         //string.Format("~/Modules/HR/Handler.ashx?id={0}", lblUserid.Text);


        lblUserName.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpName);
        lblEmpIdHidden.Text = lblUserid.Text;
        lblCpIdHidden.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.CpId);
        //image1.ImageUrl = "~/Modules/HR/Handler.ashx?id=" + Convert.ToInt16(Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId));
        //imag2.ImageUrl = "~/Modules/HR/Handler.ashx?id=" + Convert.ToInt16(Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId));
        lblDesgination.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.Designation);

        lblName.Text = lblUserName.Text;
        lblname3.Text = lblName.Text;
        lbldepart.Text = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.Department);

      //  imag3.ImageUrl = "~/Modules/HR/Handler.ashx?id=" + Convert.ToInt16(Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId));

        


        }
    }

    private void Bindmenu(string userid)
    {

        this.Repeater1.DataSource = GetData("Select * from User_Permissions, Users_Menu WHERE User_Permissions.Permissions = Users_Menu.SLNO and User_Permissions.UserId = '" + userid + "'  ORDER BY slno asc");

        this.Repeater1.DataBind();



       // this.Repeater2.DataSource = GetData(" SELECT top 5 [dbo].[GetDateFormat](NotificationTime,GETDATE()) as Ago ,NotificationDetails,EMP_FIRST_NAME+' '+EMP_LAST_NAME as empname from Notifications,Employee_Master where Notifications.NotificationBy = Employee_Master.EMP_ID order by Notification_Id desc ");

        //this.Repeater2.DataSource = GetData("  SELECT top 5  NotificationDetails+' by '+EMP_FIRST_NAME+' '+EMP_LAST_NAME as empname, [dbo].[GetDateFormat](NotificationTime,GETDATE()) as ago from Notifications,Employee_Master where Notifications.NotificationBy = Employee_Master.EMP_ID order by Notification_Id desc");


        this.Repeater2.DataSource = GetData("  SELECT top 5  NotificationDetails+' by '+EMP_FIRST_NAME+' '+EMP_LAST_NAME+' - '+[dbo].[GetDateFormat](NotificationTime,GETDATE()) as ago from Notifications,Employee_Master where Notifications.NotificationBy = Employee_Master.EMP_ID order by Notification_Id desc");



        this.Repeater2.DataBind();



   




    }



  
    private DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }
    //protected void lbtnlogout_Click(object sender, EventArgs e)
    //{
    //    Alumil.Authentication.ClearSession(this);
    //}
    //protected void lbtnmasters_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Modules/Masters/MastersHome.aspx");
    //}
    //protected void lbtnSales_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Modules/Sales/SalesHome.aspx");
    //}
    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Modules/HR/HrHome.aspx");
    //}



    protected void Privilege_Click(object sender, EventArgs e)
    {

        LinkButton lbtnPrivilege;
        lbtnPrivilege = (LinkButton)sender;
        Repeater gvRow = (Repeater)lbtnPrivilege.Parent.Parent;
        result = lbtnPrivilege.Text;
        PrivilegesNavigation();

    }

    private void PrivilegesNavigation()
    {



        switch (result)
        {


            case "Masters":
                Response.Redirect("~/Modules/Masters/MastersHome.aspx",false);
                break;

            case "Sales":
                Response.Redirect("~/Modules/Sales/SalesHome.aspx",false);
                break;

            case "Purchases":
                Response.Redirect("~/Modules/Purchases/PurchaseHome.aspx",false);
                break;

            case "Manufacture":
                Response.Redirect("~/Modules/Stock/ManufacturingHome.aspx",false);
                break;

            case "Stock":
                Response.Redirect("~/Modules/Stock/StockHome.aspx",false);
                break;
            case "HR":
                Response.Redirect("~/Modules/HR/HrHome.aspx", false);
                break;
            case "Finance":
              
                break;
          
            case "Help":
                Response.Redirect("~/Modules/Reports/CustomerProjectReportNew.aspx", false);
                break;
            default:
                Console.WriteLine("Please select correct choice...");
                break;
        }

    }


















    protected void lbtnmail_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Modules/MailBox.aspx");
    }
}
