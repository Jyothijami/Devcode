using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Web.Mail;


namespace Vishnupirya.Classes
{

    /// <summary>
    /// Summary description for Email
    /// </summary>
    public class Email : MailMessage
    {
        public Email()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public Email(string To)
        {
            this.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            this.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
            this.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
            this.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "phani1237@gmail.com");
            this.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "hai1237phani");
            this.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");

            this.From = "ocrmhr@dss-source.com";
            this.To = To;
            //this.Cc = "dsshr@dss-source.com";
        }

        public void Send()
        {
            // open new thread and send the mail using that.
            Thread t = new Thread(new ThreadStart(this.SendEmail));
            t.Start();
        }

        private void SendEmail()
        {
            try
            {
                SmtpMail.Send(this);
            }
            catch (Exception) { } // error
        }
    }

}