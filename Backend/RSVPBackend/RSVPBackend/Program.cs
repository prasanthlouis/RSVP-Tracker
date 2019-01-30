using System;
using System.IO;
using System.Linq;

namespace RSVPBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileStream = new FileStream("Emails.txt", FileMode.Open);
            var filesContents = string.Empty;
            using (var streamReader = new StreamReader(fileStream))
            {
                filesContents = streamReader.ReadToEnd();
            }

            var emails = filesContents.Split(',').ToList();
            var smtp = new SMTPClient();
            foreach(var email in emails)
            {
                smtp.SendEmail(email);
            }
            

        }
    }
}
