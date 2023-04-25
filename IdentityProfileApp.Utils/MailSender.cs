using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Utils
{
    public class MailSender
    {
        public void EmailSender(string to, string subject, string emailBody)
        {
            var from = "fatihemreyasar641@gmail.com";
            var message = new MailMessage();
            message.To.Add(new MailAddress(to));  // replace with valid value 
            message.From = new MailAddress(from);  // replace with valid value
            message.Subject = subject;
            message.Body = emailBody;
            message.IsBodyHtml = true;


            using (var smtp = new System.Net.Mail.SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = from, 
                    Password = "Ocak1997.", 
                };
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Port = 587;
                smtp.Timeout = 50000;
                smtp.EnableSsl = true;
                smtp.Send(message);

            }
        }
    }
}
