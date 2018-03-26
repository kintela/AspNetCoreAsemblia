using System;
using System.Collections.Generic;
using System.Text;

namespace CursoAspNet.Core.Domain.Mailing
{
    public interface IMailService
    {
        void Send(Mail mail);
    }
}
