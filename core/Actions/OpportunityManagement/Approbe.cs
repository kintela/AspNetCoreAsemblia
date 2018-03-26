using CursoAspNet.Core.Domain.Infrastructure;
using CursoAspNet.Core.Domain.Mailing;
using CursoAspNet.Core.Domain.OpportunityManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoAspNet.Core.Actions.OpportunityManagement
{
    public class Approbe
    {
        private readonly FysegContext context;
        private readonly IMailService mailService;

        public Approbe(FysegContext context, IMailService mailService)
        {
            this.context = context;
            this.mailService = mailService;
        }

        public bool Run(int id)
        {
            var opportunities = new Opportunities(context.Opportunities);

            var opportunity = opportunities.GetById(id);

            opportunity.Aprobe(mailService);

            opportunities.Update(opportunity);

            return context.SaveChanges() > 0;

        }
    }
}
