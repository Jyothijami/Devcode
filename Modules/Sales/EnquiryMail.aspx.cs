using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_EnquiryMail : System.Web.UI.Page
{
    protected string toEmail, EmailSubj, EmailMsg, ccId, bccId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            BindData1();
        }
    }
    private void BindData()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString()))
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT EMP_EMAIL,EMP_ID FROM EMPLOYEE_MASTER";
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                // BIND THE SELECT DROP-DOWN LIST WITH A DATABASE TABLE.
                Books.DataSource = dt;
                Books.DataTextField = "EMP_EMAIL";
                Books.DataValueField = "EMP_EMAIL";

                Books.DataBind();

                // FOR MULTIPLE SELECTION. SET THE VALUE AS FALSE, AND SEE WHAT HAPPENS.
                Books.Multiple = true;
                
            }
        }


        // SM.CustomerMaster.CustomerMaster_Select(Books);


    }



    private void BindData1()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString()))
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT EMP_EMAIL,EMP_ID FROM EMPLOYEE_MASTER";
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                // BIND THE SELECT DROP-DOWN LIST WITH A DATABASE TABLE.
                tobcc.DataSource = dt;
                tobcc.DataTextField = "EMP_EMAIL";
                tobcc.DataValueField = "EMP_EMAIL";

                tobcc.DataBind();

                // FOR MULTIPLE SELECTION. SET THE VALUE AS FALSE, AND SEE WHAT HAPPENS.
                tobcc.Multiple = true;

            }
        }


        // SM.CustomerMaster.CustomerMaster_Select(Books);


    }




    protected void btnsend_Click(object sender, EventArgs e)
    {

        
        //To Mail

        string hai = txtsub.Text;


        string condition = string.Empty;
        foreach (ListItem item in Books.Items)
        {
            condition += item.Selected ? string.Format("{0},", item.Value) : string.Empty;
        }

        if (!string.IsNullOrEmpty(condition))
        {
            condition = string.Format(condition.Substring(0, condition.Length - 1));
        }

        toEmail = condition;


        //To CC


        string tocc = string.Empty;
        foreach (ListItem item in tobcc.Items)
        {
            tocc += item.Selected ? string.Format("{0},", item.Value) : string.Empty;
        }

        if (!string.IsNullOrEmpty(tocc))
        {
            tocc = string.Format(tocc.Substring(0, tocc.Length - 1));
        }



        EmailSubj = HttpUtility.HtmlDecode(txtsub.Text); 
        //EmailMsg = Convert.ToString(txtsub.Text);
        EmailMsg = HttpUtility.HtmlDecode(txtsub.Text);


        
        ccId = tocc;
        bccId = Convert.ToString(txtBCC.Text);
        //passing parameter to Email Method
        SendEmail.Email_With_CCandBCC(toEmail, ccId, bccId, EmailSubj, EmailMsg);
        Label1.Visible = true;
        Label1.Text = "Email Sent Successfully";
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txttomail.Text = "";
        txtsub.Text = "";
        txtsub.Text = "";
        txtBCC.Text = "";
        txtcc.Text = "";
    }

    //public static class SendEmail
    //{
    //    public static string Pass, FromEmailid, HostAdd;

    //    public static void Email_With_CCandBCC(String ToEmail, string cc, string bcc, String Subj, string Message)
    //    {
    //        //Reading sender Email credential from web.config file
    //        HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
    //        FromEmailid = ConfigurationManager.AppSettings["FromMail"].ToString();
    //        Pass = ConfigurationManager.AppSettings["Password"].ToString();

    //        //creating the object of MailMessage
    //        MailMessage mailMessage = new MailMessage();

    //        mailMessage.From = new MailAddress(FromEmailid); //From Email Id
    //        mailMessage.Subject = Subj; //Subject of Email
    //        mailMessage.Body = Message; //body or message of Email
    //        mailMessage.IsBodyHtml = true;

    //        string[] ToMuliId = ToEmail.Split(',');
    //        foreach (string ToEMailId in ToMuliId)
    //        {
    //            mailMessage.To.Add(new MailAddress(ToEMailId)); //adding multiple TO Email Id
    //        }

    //        string[] CCId = cc.Split(',');

    //        foreach (string CCEmail in CCId)
    //        {
    //            mailMessage.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
    //        }

    //        string[] bccid = bcc.Split(',');

    //        foreach (string bccEmailId in bccid)
    //        {
    //            mailMessage.Bcc.Add(new MailAddress(bccEmailId)); //Adding Multiple BCC email Id
    //        }

    //        SmtpClient smtp = new SmtpClient(); // creating object of smptpclient
    //        smtp.Host = HostAdd; //host of emailaddress for example smtp.gmail.com etc

    //        //network and security related credentials

    //        smtp.EnableSsl = true;
    //        NetworkCredential NetworkCred = new NetworkCredential();
    //        NetworkCred.UserName = mailMessage.From.Address;
    //        NetworkCred.Password = Pass;
    //        //smtp.UseDefaultCredentials = true;
    //        smtp.Credentials = NetworkCred;
    //        smtp.Port = 587;
    //        smtp.Send(mailMessage); //sending Email
    //    }
    //}






    public static class SendEmail
    {
        public static string Pass, FromEmailid, HostAdd;

        public static void Email_With_CCandBCC(String ToEmail, string cc, string bcc, String Subj, string Message)
        {
            //Reading sender Email credential from web.config file
            HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
            FromEmailid = ConfigurationManager.AppSettings["FromMail"].ToString();
            Pass = ConfigurationManager.AppSettings["Password"].ToString();

            //creating the object of MailMessage
            MailMessage mailMessage = new MailMessage();
            mailMessage.Headers.Add("Content-Type", "content=text/html; charset=\"UTF-8\"");
            mailMessage.From = new MailAddress(FromEmailid); //From Email Id
            mailMessage.Subject = Subj; //Subject of Email
            mailMessage.Body =  Message; //body or message of Email
            mailMessage.IsBodyHtml = true;

            string[] ToMuliId = ToEmail.Split(',');
            foreach (string ToEMailId in ToMuliId)
            {
                mailMessage.To.Add(new MailAddress(ToEMailId)); //adding multiple TO Email Id
            }

            string[] CCId = cc.Split(',');

            foreach (string CCEmail in CCId)
            {
                mailMessage.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
            }

            string[] bccid = bcc.Split(',');

            foreach (string bccEmailId in bccid)
            {
                mailMessage.Bcc.Add(new MailAddress(bccEmailId)); //Adding Multiple BCC email Id
            }

            SmtpClient smtp = new SmtpClient(); // creating object of smptpclient
            smtp.Host = HostAdd; //host of emailaddress for example smtp.gmail.com etc

            //network and security related credentials

            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = mailMessage.From.Address;
            NetworkCred.Password = Pass;
            //smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mailMessage); //sending Email
        }
    }





}