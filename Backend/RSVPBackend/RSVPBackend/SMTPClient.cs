using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RSVPBackend
{
    public class SMTPClient
    {
        public void SendEmail(string email)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress("prasanthlouis21@gmail.com", "Prasanth Louis"));
                message.From = new MailAddress("prasanthlouis21@gmail.com", "PMoney$$");
                message.CC.Add(new MailAddress("prasanthlouis21@mailinator.com", "Burner Account"));
                message.Subject = "Are you coming for super bowl weekend";
                message.Body = "Please reply yes or no";
                message.IsBodyHtml = true;        
                var fileStream = new FileStream("Password.txt", FileMode.Open);
                var password = string.Empty;
                using (var streamReader = new StreamReader(fileStream))
                {
                    password = streamReader.ReadToEnd();
                }

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new NetworkCredential("TwitchBurner21", password);
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
        }
    }
}
