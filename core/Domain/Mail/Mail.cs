using System;
using System.Collections.Generic;
using System.Text;

namespace CursoAspNet.Core.Domain.Mailing
{
    public class Mail
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
