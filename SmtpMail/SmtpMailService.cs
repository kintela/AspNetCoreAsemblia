using CursoAspNet.Core.Domain.Mailing;
using System.Net.Mail;

namespace SmtpMail
{
    public class SmtpMailService:IMailService
    {
        public SmtpMailService()
        {

        }
        public void Send(Mail mail)
        {
            var smtp = new SmtpClient("mail.fulcrum.es", 21);

        }

    }
}
