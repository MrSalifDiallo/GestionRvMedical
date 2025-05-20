using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Helper
{
    public class GMailer
    {
        public static string GmailUsername { get; set; }

        public static string GmailPassword { get; set; }

        public static string GmailHost { get; set; }

        public static int GmailPort { get; set; }

        public static bool GmailSSL { get; set; }

        public static string ToEmail { get; set; }
        public static string Subject { get; set; }
        public static string Body { get; set; }
        public static bool IsHtml { get; set; }
        static GMailer()
        {
            GmailHost = "smtp.gmail.com";
            GmailPort = 25;
            GmailSSL = true;
        }

        /*public void Send()
        {
            SmtpClient smtp=new SmtpClient();
            smtp.Host = GmailHost;
            smtp.Port = GmailPort;
            smtp.EnableSsl = GmailSSL;
            smtp.DeliveryMethod=SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials=new NetworkCredential(GmailUsername, GmailPassword);
            try
            {
                using (var message=new MailMessage(GmailUsername, ToEmail))
                {
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = IsHtml;
                    smtp.Send(message);
                }
                public static void sendMail(string destinataire, string subject, string body)
                {
                    GMailer.GmailUsername = "svlifcharoo@gmail.com";
                    GmailPassword = "fxyb niyu esrb wcxn";
                    GMailer mailer = new GMailer();
                    mailer.ToEmail = destinataire;
                    mailer.Subject = subject;
                    mailer.Body = body;
                    mailer.isHtml = true;
                    mailer.Send();
                }
            }
            catch(Exception) {
                //Todo
            }

            


        }*/
    }
}
