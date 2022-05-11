using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkani.BLL.Concrete.SendMailServiceBLL
{
    class SendMailService
    {
        public static bool SendMail(string userName, string userMailAddress, Guid activationCode)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(userMailAddress);
            msg.Subject = "Plak Dükkani Activasyon Maili";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<!DOCTYPE html> <html> <head> <meta charset='utf-8'/> <title></title> </head> <body> <h1> Aktivasyon Maili </h1> <p> Merhaba {0} </p> <p> Sitemize Kayıt Olduğunuz İçin Teşekkür Ederiz </p> <br /> <p> Kayıtınızı aktifleştirmek için <a href='http://localhost:33077/User/ActivedUser/{1}'>linke</a> tıklayınız. </p> </body> </html>", userName, activationCode);

            msg.From = new MailAddress("cinemasystem@sinemamekani.com");

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.radorehosting.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("bilgeadam@sinemamekani.com", "Asd*123456");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
           

            try
            {
                smtp.Send(msg);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }          
      
     
        }
    }
}
