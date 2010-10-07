using System;
using FutureView.ECom.Services.Util.EMail.Template;
using System.Net.Mail; 

namespace FutureView.ECom.Services.Util.EMail
{
    internal class EMailSender
    {
        public static void SendMail(ITemplate eMailTemplate, string to, params string[] eMailArgs)
        {
            if( eMailTemplate == null ) throw new ArgumentNullException("eMailTemplate");
            MailMessage eMail = new MailMessage("32223@alunos.isel.pt", to);
            eMail.Subject = eMailTemplate.Subject;
            eMail.Body = string.Format(eMailTemplate.Body, eMailArgs);


            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(eMail);
        }
    }
}
