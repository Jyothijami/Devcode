using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_Enquiry_Details : System.Web.UI.Page
{
    //private const int _firstEditCellIndex = 2;
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

       
        if (!IsPostBack)
        {
         
            SM.CustomerMaster.CustomerMaster_Select(ddlClinet);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlnextContactBy);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlsalesincharge);
            HR.EmployeeMaster.EmployeeMaster_Select(ddldesignincharge);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            Masters.ArchitectMaster.ArchitectMaster_Select(ddlArchitectName);
            //HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);

            txtCustNo.Text = SM.CustomerMaster.CustomerMaster_AutoGenCode();
            if (Qid == "Add")
            {

                btnSave.Text = "Save";
                btnRevise.Visible = false;
                btnPrint.Visible = false;
                btnApprove.Visible = false;

                txtEnquiryno.Text = SM.SalesEnquiry.SalesEnquiry_AutoGenCode();
                txtEnquirydate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtNextContactDate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtstatus.Text = "New";

                ddlsalesincharge.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

                ddlpreparedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

                //Label lbempid = (Label)Master.FindControl("lblUserid");
                //ddlpreparedby.SelectedValue = lbempid.Text;


            }
            else
            {
                btnSave.Text = "Update";
                btnRevise.Visible = true;
                btnPrint.Visible = false;
                btnApprove.Visible = false;
                Enquiry_Fill();

            }

          
        }
        
    }

    private void Enquiry_Fill()
    {
        SM.SalesEnquiry obj = new SM.SalesEnquiry();

        if(obj.SalesEnquiry_Select(Request.QueryString["Cid"].ToString())>0)
        {
            txtEnquiryno.Text = obj.EnqNo;
            txtEnquirydate.Text = obj.EnqDate;
            ddlClinet.SelectedValue = obj.CustId;
            ddlClinet_SelectedIndexChanged(new object(), new System.EventArgs());
            ddlClinetSite.SelectedValue = obj.UnitId;
            ddlClinetSite_SelectedIndexChanged(new object(), new System.EventArgs());
            ddlsalesincharge.SelectedValue = obj.salesinchargeid;
            ddldesignincharge.SelectedValue = obj.designincargeid;
            ddlpreparedby.SelectedValue = obj.preparedby;
            //ddlapprovedby.SelectedValue = "0";
            txtstatus.Text = obj.status;
            ddlnextContactBy.SelectedValue = obj.NextContactById;
            txtNextContactDate.Text = obj.NextContactDate;
            txttodiscuss.Text = obj.ToDiscuss;
            ddlArchitectName.SelectedValue = obj.Archid;
            ddlArchitectName_SelectedIndexChanged(new object(), new System.EventArgs());
            txtproductRequired.Text = obj.productrequried;
            txtglassspecifications.Text = obj.glassspecifications;
            txtglasssthickness.Text = obj.glassthickness;
            txtglasscolorcode.Text = obj.glasscolorcode;

            txtenquirySource.Text = obj.Source;
            ddlMarketSegment.SelectedItem.Text = obj.Segment;


            if(obj.powercoating == "Yes")
            {
                rbtpowercoating.Checked = true;
            }
            else
            {
                rbtpowercoating.Checked = false;
            }

            if (obj.anodizing == "Yes")
            {
                rbtanodizing.Checked = true;
            }
            else
            {
                rbtanodizing.Checked = false;
            }

            if (obj.woodeffect == "Yes")
            {
                rbtwoodeffect.Checked = true;
            }
            else
            {
                rbtwoodeffect.Checked = false;
            }

            if (obj.archidrawingsattach == "Yes")
            {
                rbtardrawattachedyes.Checked = true;
            }
            else
            {
                rbtardrawattachedNo.Checked = true;
            }

            if (obj.sitephotoattached == "Yes")
            {
                rbtsitephotyes.Checked = true;
            }
            else
            {
                rbtsitephotno.Checked = true;
            }



        }
    }


    protected void ddlClinet_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.CustomerMaster.CustomerUnit_Select(ddlClinetSite, ddlClinet.SelectedItem.Value);

        SM.CustomerMaster obj = new SM.CustomerMaster();
        if(obj.CustomerMaster_Select(ddlClinet.SelectedItem.Value)>0)
        {
          //  lblCustomerName.Text = obj.CustName;
          ////  lbladdress.Text = obj.custaddress;
          //  lblCustomerMobile.Text = obj.CustMobile;

            txtClientMobilenO.Text = obj.CustMobile;
            txtClientAddress.Text = obj.custaddress;
            txtClientContactPerson.Text = obj.CustName;
         

        }

    }
    //protected void ddlsalesincharge_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    HR.EmployeeMaster objmaster = new HR.EmployeeMaster();

    //    if (objmaster.EmployeeMaster_Select(ddlsalesincharge.SelectedItem.Value) > 0)
    //    {
    //       // txtsalesinchargecontact.Text = objmaster.EmpMobile;
    //    }
        
    //}
    //protected void ddldesignincharge_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    HR.EmployeeMaster objmaster = new HR.EmployeeMaster();

    //    if (objmaster.EmployeeMaster_Select(ddldesignincharge.SelectedItem.Value) > 0)
    //    {
    //        //txtdesigncontact.Text = objmaster.EmpMobile;
    //    }
    //}
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            SalesEnquirySave();
        }
        else if (btnSave.Text == "Update")
        {
            SalesEnquiryUpdate();
        }
    }

    private void SalesEnquiryUpdate()
    {
        try
        {
            SM.SalesEnquiry objSM = new SM.SalesEnquiry();
            objSM.Enqid = Request.QueryString["Cid"].ToString();
            objSM.EnqNo = txtEnquiryno.Text;
            objSM.EnqDate = General.toMMDDYYYY(txtEnquirydate.Text);
            objSM.CustId = ddlClinet.SelectedItem.Value;
            objSM.UnitId = ddlClinetSite.SelectedItem.Value;
            objSM.salesinchargeid = ddlsalesincharge.SelectedItem.Value;

            objSM.designincargeid = ddldesignincharge.SelectedItem.Value;
            objSM.preparedby = ddlpreparedby.SelectedItem.Value;
            objSM.approvedby = "0";
            //objSM.revisedkey = "";
            //objSM.status = txtstatus.Text;
            objSM.productrequried = txtproductRequired.Text;
            objSM.glassspecifications = txtglassspecifications.Text;
            objSM.glassthickness = txtglasssthickness.Text;
            objSM.glasscolorcode = txtglasscolorcode.Text;

            objSM.NextContactById = ddlnextContactBy.SelectedItem.Value;
            objSM.NextContactDate = General.toMMDDYYYY(txtNextContactDate.Text);
            objSM.ToDiscuss = txttodiscuss.Text;
            objSM.Archid = ddlArchitectName.SelectedItem.Value;
            objSM.Source = txtenquirySource.Text;
            objSM.Priority = "";
            objSM.Segment = ddlMarketSegment.SelectedItem.Text;
            if (rbtpowercoating.Checked == true)
            {
                objSM.powercoating = "Yes";
            }
            else
            {
                objSM.powercoating = "No";
            }


            if (rbtanodizing.Checked == true)
            {
                objSM.anodizing = "Yes";
            }
            else
            {
                objSM.anodizing = "No";
            }

            if (rbtwoodeffect.Checked == true)
            {
                objSM.woodeffect = "Yes";
            }
            else
            {
                objSM.woodeffect = "No";
            }

            if (rbtardrawattachedyes.Checked == true)
            {
                objSM.archidrawingsattach = "Yes";
            }
            else
            {
                objSM.archidrawingsattach = "No";
            }

            if (rbtsitephotyes.Checked == true)
            {
                objSM.sitephotoattached = "Yes";
            }
            else
            {
                objSM.sitephotoattached = "No";
            }

           


            MessageBox.Show(this, objSM.SalesEnquiry_Update());


            
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            SM.Dispose();
            //Response.Redirect("~/Modules/Sales/SalesEnquiry.aspx");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
        }
    }

    private void SalesEnquirySave()
    {
        try
        {
            SM.SalesEnquiry objSM = new SM.SalesEnquiry();
            objSM.EnqNo = txtEnquiryno.Text;
            objSM.EnqDate = General.toMMDDYYYY(txtEnquirydate.Text);
            objSM.CustId = ddlClinet.SelectedItem.Value;
            objSM.UnitId = ddlClinetSite.SelectedItem.Value;
            objSM.salesinchargeid = ddlsalesincharge.SelectedItem.Value;
          
            objSM.designincargeid = "0";
            objSM.preparedby = ddlpreparedby.SelectedItem.Value;
            objSM.approvedby = "0";
            objSM.revisedkey = "";
            objSM.status = txtstatus.Text;

            objSM.NextContactById = ddlnextContactBy.SelectedItem.Value;
            objSM.NextContactDate = General.toMMDDYYYY(txtNextContactDate.Text);
            objSM.ToDiscuss = txttodiscuss.Text;
           // if (objSM.SalesEnquiry_Save() == "Data Saved Successfully")


            objSM.Archid = ddlArchitectName.SelectedItem.Value;
            objSM.productrequried = txtproductRequired.Text;
            objSM.glassspecifications = txtglassspecifications.Text;
            objSM.glassthickness = txtglasssthickness.Text;
            objSM.glasscolorcode = txtglasscolorcode.Text;


            objSM.Designstatus = "NotStarted";
            objSM.estimationinchargeid = "0";
            objSM.estimationStatus = "NotStarted";

            objSM.Source = txtenquirySource.Text;
            objSM.Priority = "";
            objSM.Segment = ddlMarketSegment.SelectedItem.Text;

            if(rbtpowercoating.Checked == true)
            {
                objSM.powercoating = "Yes";
            }
            else
            {
                objSM.powercoating = "No";
            }


            if (rbtanodizing.Checked == true)
            {
                objSM.anodizing = "Yes";
            }
            else
            {
                objSM.anodizing = "No";
            }

            if (rbtwoodeffect.Checked == true)
            {
                objSM.woodeffect = "Yes";
            }
            else
            {
                objSM.woodeffect = "No";
            }

            if (rbtardrawattachedyes.Checked == true)
            {
                objSM.archidrawingsattach = "Yes";
            }
            else
            {
                objSM.archidrawingsattach = "No";
            }

            if (rbtsitephotyes.Checked == true)
            {
                objSM.sitephotoattached = "Yes";
            }
            else
            {
                objSM.sitephotoattached = "No";
            }



            MessageBox.Show(this, objSM.SalesEnquiry_Save());

            Thread email = new Thread(delegate()
            {
                SendMail();
            });
            email.IsBackground = true;
            email.Start();

            
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            SM.Dispose();
           // Response.Redirect("~/Modules/Sales/SalesEnquiry.aspx");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
        }
    }
    protected void ddlClinetSite_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.CustomerMaster obj = new SM.CustomerMaster();
        if (obj.CustomerUnitMaster_Select(ddlClinetSite.SelectedItem.Value) > 0)
        {
            //lblUnitName.Text = obj.UnitName;
            //lblUnitAddress.Text = obj.UnitAddress;
            //lblNoofFloors.Text = obj.NoofFloors;
            //lblwinload.Text = obj.Winload;

            txtClientSiteAdress.Text = obj.UnitAddress;
            txtClientSiteContactPerson.Text = obj.UnitContactPerson;
            txtClientSiteMobile.Text = obj.UnitMobileNo;
           // ddlArchitectName.SelectedItem.Value = obj.Arcname;
            //ddlArchitectName.SelectedValue = obj.Arcname;
            //ddlArchitectName_SelectedIndexChanged(sender, e);
        }
    }

    protected void ddlArchitectName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.ArchitectMaster obj = new Masters.ArchitectMaster();

        if(obj.ArchitectMaster_Select(ddlArchitectName.SelectedItem.Value) > 0)
        {
            txtarchemail.Text = obj.Email;
            txtarchitectaddress.Text = obj.Address;
            txtarchitectmobile.Text = obj.Mobile;
            

        }



    }
    //protected void btnAddnew_Click(object sender, EventArgs e)
    //{
    //    string N = "Add";
    //    Response.Redirect("~/Modules/Sales/CustomerDetails.aspx?Cid=" + N);
    //}
    protected void btnCustSave_Click(object sender, EventArgs e)
    {
        try
        {
            SM.CustomerMaster objmaster = new SM.CustomerMaster();
            objmaster.custdear = "1";
            objmaster.CustCode = txtCustNo.Text;
            objmaster.CustName = txtCustomerName.Text;
            objmaster.CompanyName = txtCustomerName.Text;
            objmaster.CustContactPerson = "1";
            objmaster.custPhone = txtcustmobile.Text;
            objmaster.CustMobile = txtcustmobile.Text;
            objmaster.Custfax = "0";
            objmaster.CustEmail = "a";
            objmaster.CustPan = "1";
            objmaster.Custgst = "1";
            objmaster.custdesgid = "1";
            objmaster.custaddress = txtCustaddress.Text;
            objmaster.corpcontactperson = "1";
            objmaster.corpphone = "1";
            objmaster.corpmobile = "1";
            objmaster.corpemail = "1";
            objmaster.corpaddress = "1";
            objmaster.corpdesgid = "1";
            objmaster.corpfax = "1";
            objmaster.custdesgid = "1";
            objmaster.custstatus = "1";
            objmaster.regid = "1";

            objmaster.refbyname = "";
            objmaster.refbycontact = "";
            objmaster.refbyaddress = "";

            objmaster.archiaddress = "1";
            objmaster.archicontact = "1";
            objmaster.architectname = "1";

            objmaster.siteinchargeaddress = "1";
            objmaster.siteinchargename = "1";
            objmaster.siteinchargecontact = "1";
           // objmaster.EnqCustomerMaster_Save();
            MessageBox.Show(this, objmaster.EnqCustomerMaster_Save());
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#myModal').hide();", true);
          //  dropload();
        }
        catch (Exception ex)
        {
            MessageBox.Notify(this, ex.Message);
        }
        finally
        {
            dropload();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
        }
    }

    private void dropload()
    {
        SM.CustomerMaster.CustomerMaster_Select(ddlClinet);
    }

    protected void btnarchsave_Click(object sender, EventArgs e)
    {
         try
        {
        Masters.ArchitectMaster objMaster = new Masters.ArchitectMaster();
        objMaster.Name = txtnewarchitectname.Text;
        objMaster.Mobile = txtnewarchitectmobile.Text;
        objMaster.Email = txtnewarchitectemail.Text;
        objMaster.Address = txtnewarchitectaddress.Text;
        MessageBox.Show(this, objMaster.ArchitectMaster_Save());
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#myModal1", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#myModal1').hide();", true);
        }
         catch (Exception ex)
         {
             MessageBox.Notify(this, ex.Message);
         }
         finally
         {
             arfill();
             
             ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myModal1", "$('#myModal1').modal('hide');", true);
         }
    }

    private void arfill()
    {
        Masters.ArchitectMaster.ArchitectMaster_Select(ddlArchitectName);
    }
    protected void btnRevise_Click(object sender, EventArgs e)
    {
        try
        {
            SM.SalesEnquiry objSM = new SM.SalesEnquiry();
            objSM.Enqid = Request.QueryString["Cid"].ToString();
            objSM.EnqNo = txtEnquiryno.Text;
            objSM.EnqDate = General.toMMDDYYYY(txtEnquirydate.Text);
            objSM.CustId = ddlClinet.SelectedItem.Value;
            objSM.UnitId = ddlClinetSite.SelectedItem.Value;
            objSM.salesinchargeid = ddlsalesincharge.SelectedItem.Value;

            objSM.designincargeid = "0";
            objSM.preparedby = ddlpreparedby.SelectedItem.Value;
            objSM.approvedby = "0";
            objSM.revisedkey = "";
            objSM.status = txtstatus.Text;

            objSM.NextContactById = ddlnextContactBy.SelectedItem.Value;
            objSM.NextContactDate = General.toMMDDYYYY(txtNextContactDate.Text);
            objSM.ToDiscuss = txttodiscuss.Text;
            // if (objSM.SalesEnquiry_Save() == "Data Saved Successfully")
            objSM.Archid = ddlArchitectName.SelectedItem.Value;


            objSM.productrequried = txtproductRequired.Text;
            objSM.glassspecifications = txtglassspecifications.Text;
            objSM.glassthickness = txtglasssthickness.Text;
            objSM.glasscolorcode = txtglasscolorcode.Text;


            objSM.Designstatus = "NotStarted";
            objSM.estimationinchargeid = "0";
            objSM.estimationStatus = "NotStarted";

            objSM.Source = txtenquirySource.Text;
            objSM.Priority = "";
            objSM.Segment = ddlMarketSegment.SelectedItem.Text;



            if (rbtpowercoating.Checked == true)
            {
                objSM.powercoating = "Yes";
            }
            else
            {
                objSM.powercoating = "No";
            }


            if (rbtanodizing.Checked == true)
            {
                objSM.anodizing = "Yes";
            }
            else
            {
                objSM.anodizing = "No";
            }

            if (rbtwoodeffect.Checked == true)
            {
                objSM.woodeffect = "Yes";
            }
            else
            {
                objSM.woodeffect = "No";
            }

            if (rbtardrawattachedyes.Checked == true)
            {
                objSM.archidrawingsattach = "Yes";
            }
            else
            {
                objSM.archidrawingsattach = "No";
            }

            if (rbtsitephotyes.Checked == true)
            {
                objSM.sitephotoattached = "Yes";
            }
            else
            {
                objSM.sitephotoattached = "No";
            }



            MessageBox.Show(this, objSM.SalesEnquiryRevise_Save());

            SendMail();

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            SM.Dispose();
            // Response.Redirect("~/Modules/Sales/SalesEnquiry.aspx");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
        }
    }



    protected void SendMail()
    {
        try
        {
            string sendmail = "office@alumil.in";
            
                //if (((CheckBox)gvr.FindControl("Chk")).Checked)
                //{


                StreamReader reader = new StreamReader(Server.MapPath("~/regular/mailbakery-iota-regular.html"));
                string readFile = reader.ReadToEnd();
                string myString = "";
                string Subject1 = "";
                
                //if (Subject.Text == "-")
                //{
                //    Subject1 = "Regarding Service Closed Mail.";
                //}
                //else { Subject1 = Subject.Text; }
                Subject1 = "New Sales Enquiry."; 

              
                
               
                myString = readFile;
                myString = myString.Replace("{UserName}", ddlClinet.SelectedItem.Text);
                myString = myString.Replace("{EnqDate}", txtEnquirydate.Text);
                myString = myString.Replace("{ClientName}", ddlClinetSite.SelectedItem.Text);
                myString = myString.Replace("{EnqNo}", txtEnquiryno.Text);
                //myString = myString.Replace("$$CorrectiveActionTaken$$", txtactionTaken.Text);
                myString = myString.Replace("{MobileNo}",txtcustmobile.Text);

                myString = myString.Replace("{ArchitectName}", ddlArchitectName.SelectedItem.Text);
                myString = myString.Replace("{ArchitectMobile}", txtarchitectmobile.Text);

                myString = myString.Replace("{EnquirySource}", txtenquirySource.Text);
                myString = myString.Replace("{Segmanet}", ddlMarketSegment.SelectedItem.Text);


                myString = myString.Replace("{productrequired}", txtproductRequired.Text);
                myString = myString.Replace("{glassspecifications}", txtglassspecifications.Text);

                myString = myString.Replace("{SalesPerson}", ddlsalesincharge.SelectedItem.Text);


                System.Net.Mail.MailMessage mymailmessage = new System.Net.Mail.MailMessage();

                mymailmessage.Subject = Subject1.ToString();
                mymailmessage.Body = myString.ToString();
                mymailmessage.IsBodyHtml = true;
                mymailmessage.From = new MailAddress("it@alumil.in");
                mymailmessage.To.Add(sendmail);
                System.Net.NetworkCredential mymailauthentications = new System.Net.NetworkCredential("it@alumil.in", "Password@123");

                System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);

                mailclient.EnableSsl = true;
                mailclient.UseDefaultCredentials = true;
                mailclient.Credentials = mymailauthentications;
                mymailmessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                mymailmessage.Headers.Add("Disposition-Notification-To", sendmail);
                mailclient.Send(mymailmessage);
                reader.Dispose();
                //}
           


        }
        catch (Exception ex) { }
    }
}