using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_EnquiryAssignment : System.Web.UI.Page
{
    protected string toEmail, EmailSubj, EmailMsg, ccId, bccId;

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);

        if (!IsPostBack)
        {
            hai.DataBind();
            BindData();
           // BindData1();
            BindData2();
        }
    }

    private void BindData()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString()))
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT EMP_EMAIL,EMP_ID FROM EMPLOYEE_MASTER where emp_email not in ('0','-',' ') ";
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



   


    private void BindData2()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString()))
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT EMP_EMAIL,EMP_ID FROM EMPLOYEE_MASTER where emp_email not in ('0','-',' ')";
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                // BIND THE SELECT DROP-DOWN LIST WITH A DATABASE TABLE.
                toccc.DataSource = dt;
                toccc.DataTextField = "EMP_EMAIL";
                toccc.DataValueField = "EMP_EMAIL";

                toccc.DataBind();

                // FOR MULTIPLE SELECTION. SET THE VALUE AS FALSE, AND SEE WHAT HAPPENS.
                toccc.Multiple = true;

            }
        }


        // SM.CustomerMaster.CustomerMaster_Select(Books);


    }

    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
        //}

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");

        //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.hai, "Select$" + e.Row.RowIndex);
        //}


        if (e.Row.Cells[5].Text == "New")
        {
            e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
            e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
        }

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[13].Visible = false;

            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[18].Visible = false;

            e.Row.Cells[9].Visible = false;
            e.Row.Cells[12].Visible = false;

           // e.Row.Cells[16].Visible = false;

          
        }



        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddldesigner = (DropDownList)e.Row.FindControl("ddldesigner");
            HR.EmployeeMaster.EmployeeMasterDesigner_Select(ddldesigner);

            //Select the Desinger in DropDownList
            string Desinger = (e.Row.FindControl("lbldesigner") as Label).Text;
            ddldesigner.Items.FindByValue(Desinger).Selected = true;


            DropDownList ddldesignStatus = (DropDownList)e.Row.FindControl("ddldesignStatus");
            string Desingerstatus = (e.Row.FindControl("lbldesignerstatus") as Label).Text;
            ddldesignStatus.Items.FindByValue(Desingerstatus).Selected = true;


            DropDownList ddlestimation = (DropDownList)e.Row.FindControl("ddlestimation");
            HR.EmployeeMaster.EmployeeMasterDesigner_Select(ddlestimation);


            //Select the estimation in DropDownList
            string estimation = (e.Row.FindControl("lblestimation") as Label).Text;
            ddlestimation.Items.FindByValue(estimation).Selected = true;


            DropDownList ddlestimationStatus = (DropDownList)e.Row.FindControl("ddlestimationStatus");
            string estimationstatus = (e.Row.FindControl("lblestimationstatus") as Label).Text;
            ddlestimationStatus.Items.FindByValue(estimationstatus).Selected = true;

        }
    }






    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        LinkButton lbtnRegionalMaster;
        lbtnRegionalMaster = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnRegionalMaster.Parent.Parent;
        hai.SelectedIndex = gvRow.RowIndex;


        if (hai.SelectedIndex > -1)
        {
            try
            {


                SM.SalesEnquiry obj = new SM.SalesEnquiry();

                obj.Enqid = hai.SelectedRow.Cells[1].Text;

                DropDownList ddlestimationid = (DropDownList)gvRow.FindControl("ddlestimation");
                obj.estimationinchargeid = ddlestimationid.SelectedItem.Value;


                DropDownList ddldesigner = (DropDownList)gvRow.FindControl("ddldesigner");
                obj.designincargeid = ddldesigner.SelectedItem.Value;

                DropDownList ddldesignStatus = (DropDownList)gvRow.FindControl("ddldesignStatus");
                obj.Designstatus = ddldesignStatus.SelectedItem.Value;

                DropDownList ddlestimationStatus = (DropDownList)gvRow.FindControl("ddlestimationStatus");
                obj.estimationStatus = ddlestimationStatus.SelectedItem.Value;


                obj.status = "Open";

                MessageBox.Show(this, obj.AssignSalesEnquiry_Update());




                HR.EmployeeMaster demail = new HR.EmployeeMaster();
                if (demail.EmployeeMasterEmail_Select(obj.designincargeid) > 0)
                {
                    toEmail = demail.EmpEMail;
                    ccId = "it@alumil.in";
                    EmailSubj = "Design Assignment";
                    StreamReader reader = new StreamReader(Server.MapPath("~/regular/index.htm"));
                    string readFile = reader.ReadToEnd();
                    string myString = "";
                    myString = readFile;
                    myString = myString.Replace("{Text}", "Dear '"+ddldesigner.SelectedItem.Text+"' ,you have been assigned desgin,please go through the link below to more details ");
                    EmailMsg = myString;
                    SendEmail.Email_With_CCandBCC(toEmail, ccId, EmailSubj, EmailMsg);
                }

                //if(demail.EmployeeMasterEmail_Select(obj.))



                if(obj.estimationinchargeid != "0")
                { 

                if (demail.EmployeeMasterEmail_Select(obj.estimationinchargeid) > 0)
                {
                    toEmail = demail.EmpEMail;
                    ccId = "it@alumil.in";
                    EmailSubj = "Estimation Assignment";
                    StreamReader reader = new StreamReader(Server.MapPath("~/regular/index.htm"));
                    string readFile = reader.ReadToEnd();
                    string myString = "";
                    myString = readFile;
                    myString = myString.Replace("{Text}", "Dear '" + ddlestimationid.SelectedItem.Text + "' ,you have been assigned Estimation,please go through the link below to more details ");
                    EmailMsg = myString;
                    SendEmail.Email_With_CCandBCC(toEmail, ccId, EmailSubj, EmailMsg);
                }

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                hai.DataBind();

            }

        }
        else
        {
            MessageBox.Notify(this, "Please select atleast a Record");
        }
    }




    //protected void Display(object sender, EventArgs e)
    //{
    //    int rowIndex = Convert.ToInt32(((sender as LinkButton).NamingContainer as GridViewRow).RowIndex);
    //    GridViewRow row = hai.Rows[rowIndex];

    //    //txtenqno.Text = (row.FindControl("lblstudent_Id") as Label).Text;
    //    //lblmonth.Text = (row.FindControl("lblMonth_Name") as Label).Text; ;
    //    //txtAmount.Text = (row.FindControl("lblAmount") as Label).Text;

    //    txtenqno.Text = hai.SelectedRow.Cells[1].Text;
    //    txtenqdate.Text = hai.SelectedRow.Cells[2].Text;

    //    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "myModal1();", true);
    //}


    protected void hai_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // string txnId = GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Values[0].ToString().Trim();
            txtenqno.Text = hai.SelectedRow.Cells[1].Text;
            txtenqdate.Text = hai.SelectedRow.Cells[2].Text;

            txtCustname.Text = hai.SelectedRow.Cells[4].Text;
            txtCustaddress.Text = hai.SelectedRow.Cells[5].Text;

            DropDownList designass = (DropDownList)hai.SelectedRow.FindControl("ddldesigner");

            if (designass.SelectedItem.Text != "Select Employee")
            {
                txtdesignedassigned.Text = designass.SelectedItem.Text;
            }
            else
            {
                txtdesignedassigned.Text = "Not Assigned";
            }

            DropDownList Estinmation = (DropDownList)hai.SelectedRow.FindControl("ddlestimation");

            if (Estinmation.SelectedItem.Text != "Select Employee")
            {
                txtestimationassigned.Text = Estinmation.SelectedItem.Text;
            }
            else
            {
                txtestimationassigned.Text = "Not Assigned";
            }
            
           
            txtSalesperson.Text = hai.SelectedRow.Cells[19].Text;
           // txtCustname.Text = hai.SelectedRow.Cells[2].Text;

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal1').modal();", true);

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.ToString());
        }
        finally
        {

        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[12].Visible = false;

            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;

            e.Row.Cells[8].Visible = false;
            e.Row.Cells[11].Visible = false;

            e.Row.Cells[7].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[13].Visible = false;

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
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
        foreach (ListItem item in toccc.Items)
        {
            tocc += item.Selected ? string.Format("{0},", item.Value) : string.Empty;
        }



        if (!string.IsNullOrEmpty(tocc))
        {
            tocc = string.Format(tocc.Substring(0, tocc.Length - 1));
        }

        //string tobcc = string.Empty;
        //foreach (ListItem item in tobcc.Items)
        //{
        //    tocc += item.Selected ? string.Format("{0},", item.Value) : string.Empty;
        //}

        //if (!string.IsNullOrEmpty(tocc))
        //{
        //    tocc = string.Format(tocc.Substring(0, tocc.Length - 1));
        //}

        EmailSubj = HttpUtility.HtmlDecode(txtsub.Text);
        //EmailMsg = Convert.ToString(txtsub.Text);
        EmailMsg = HttpUtility.HtmlDecode(txtmsg.Text);



        ccId = tocc;
        bccId = Convert.ToString(txtBCC.Text);
        //passing parameter to Email Method

        if(toEmail != "")
        {
            SendEmail.Email_With_CCandBCC(toEmail, ccId, EmailSubj, EmailMsg);
            Label1.Visible = true;
            Label1.Text = "Email Sent Successfully";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal1", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#myModal1').hide();", true);

        }
        else
        {
            MessageBox.Show(this, "Something is Missing Correct It");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal1", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#myModal1').hide();", true);

        }



       
    }


    protected void btnreset_Click(object sender, EventArgs e)
    {
        
        txtsub.Text = "";
        txtsub.Text = "";
        txtBCC.Text = "";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal1", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#myModal1').hide();", true);

    }

    public static class SendEmail
    {
        public static string Pass, FromEmailid, HostAdd;

        public static void Email_With_CCandBCC(String ToEmail, string cc,  String Subj, string Message)
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
            mailMessage.Body = Message; //body or message of Email
            mailMessage.IsBodyHtml = true;

            string[] ToMuliId = ToEmail.Split(',');
            foreach (string ToEMailId in ToMuliId)
            {
                if(ToEMailId != "")
                {
                    mailMessage.To.Add(new MailAddress(ToEMailId)); //adding multiple TO Email Id
                }
              
                
            }

            string[] CCId = cc.Split(',');

            foreach (string CCEmail in CCId)
            {
                if(CCEmail != "")
                {
                    mailMessage.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
                }
            }

            //string[] bccid = bcc.Split(',');

            //foreach (string bccEmailId in bccid)
            //{
            //    mailMessage.Bcc.Add(new MailAddress(bccEmailId)); //Adding Multiple BCC email Id
            //}

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