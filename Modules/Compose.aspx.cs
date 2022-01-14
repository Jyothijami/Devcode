using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using phani.MessageBox;
using phani.Classes;
using Phani.Modules; 
public partial class Modules_Compose : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            HR.EmployeeMaster.EmployeeMaster_Select(ddlTo);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        if(ddlTo.SelectedItem.Value != "0")
        {

            SCM.MailBox mail = new SCM.MailBox();

            mail.Message = HttpUtility.HtmlEncode(txtDescription.Text);
            mail.SenderId = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            mail.ReceiverId = ddlTo.SelectedItem.Value;
            mail.Subject = txtSubject.Text;


            //DateTime myDateTime = DateTime.Now;

            //mail.SentDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            mail.Isdelete = "False";
            if (mail.MailBox_Save() == "Data Saved Successfully")
            {
                if (FileUpload1.HasFiles)
                {
                    string Attachment = "";
                    foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                    {
                        //uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"), uploadedFile.FileName));
                        //listofuploadedfiles.Text += String.Format("{0}<br />", uploadedFile.FileName);

                        Random rand = new Random();
                        string randNumber = Convert.ToString(rand.Next(0, 10000));
                        string path = Server.MapPath("~/Content/MailBox/");
                        string fileName = System.IO.Path.GetFileName(uploadedFile.FileName);

                        Attachment = randNumber + "_" + fileName;
                        uploadedFile.SaveAs(path + randNumber + "_" + fileName);
                        mail.Attachments = Attachment;
                        mail.MailBox_Details_Save();
                    }
                }
            }
        }
        else
        {
            MessageBox.Show(this, "Please Select Receiver");
        }




    }





}