using CursoAspNet.Core.Domain.Mailing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using CursoAspNet.Core.Domain;

namespace CursoAspNet.Core.Infrastructure.Mailing
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
