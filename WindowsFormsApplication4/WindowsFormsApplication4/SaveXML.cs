using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApplication4
{
    public class SaveXML
    {
        public static void SaveData(object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, obj);
            writer.Close();
        }
    }

    public class arr {
        public int[] data;
        public int num;
    }

    public class email
    {
        public static void mail()
        {
            string fromAddress = ("d.fake@outlook.com");
            string toAddress = ("dominic.faryna2@gmail.com");
            const string fromPassword = "mario2008";
            const string subject = "Your Music is ready";
            const string body = "Done";

            var smtp = new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress, fromPassword),
                //Timeout = 20000
            };
            MailMessage message = new MailMessage(fromAddress, toAddress, subject, body);
            {
                smtp.Send(message);
            }
        }
    }
}

