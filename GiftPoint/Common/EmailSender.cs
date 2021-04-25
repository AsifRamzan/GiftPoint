using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace GiftPoint.Common
{
    public class EmailSender
    {
        private string SMTP_SERVER_KEY = "mail.scl-pepsi.com";
        private Int32 SMTP_PORT_KEY = 587;
        private Boolean SMTP_SSL_REQUIRED = true;
        private Boolean SMTP_AUTH_REQUIRED = true;
        private string SMTP_USER_NAME_KEY = "it.info";
        //private string SMTP_USER_EMAIL_KEY = "mis.reports@scl-pepsi.com";
        private string SMTP_USER_EMAIL_KEY = "it.info@scl-pepsi.com";
        private string SMTP_USER_PASS_KEY = "test1234";
        //private string SMTP_USER_PASS_KEY = "1234";
        private string SMTP_EMAIL_SUBJECT = "Console Application GiftPoint";
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool Send(string Subject, string Message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                mail.From = new MailAddress(SMTP_USER_EMAIL_KEY, SMTP_EMAIL_SUBJECT);
                //foreach(var o in Addresses())
                //{
                //    mail.To.Add(o);
                //}
                mail.To.Add("imran.sharif@scl-pepsi.com");//imran.sharif@scl-pepsi.com
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Host = "mail.scl-pepsi.com";
                mail.Subject = Subject;
                mail.Body = Message;
                //if (!string.IsNullOrWhiteSpace(this.File))
                //{
                //    mail.Attachments.Add(new Attachment(this.File));
                //}
                if (SMTP_AUTH_REQUIRED)
                {
                    NetworkCredential oCredential = new NetworkCredential(SMTP_USER_NAME_KEY, SMTP_USER_PASS_KEY);
                    client.UseDefaultCredentials = false;
                    client.Credentials = oCredential;
                }
                else
                {
                    client.UseDefaultCredentials = true;
                }
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
                ServicePointManager.ServerCertificateValidationCallback = CertificateValidation;
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static bool CertificateValidation(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        //public List<string> Addresses()
        //{
        //    List<string> list = new List<string>();
        //    list.AddRange(this.Address.Trim().Split(';'));
        //    return list;
        //}

    }
}