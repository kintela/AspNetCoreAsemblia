using CursoAspNet.Core.Domain.Infrastructure;
using CursoAspNet.Core.Domain.Mailing;
using CursoAspNet.Core.Domain.OpportunityManagement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CursoAspNet.Core.Actions.OpportunityManagement
{
    public class ApprobeHandler : IRequestHandler<Approbe, bool>
    {

        private readonly FysegContext context;
        private readonly IMailService mailService;

        public ApprobeHandler(FysegContext context, IMailService mailService)
        {
            this.context = context;
            this.mailService = mailService;
        }

        public async Task<bool> Handle(Approbe request, CancellationToken cancellationToken)
        {
            var opportunities = new Opportunities(context.Opportunities);

            var opportunity = opportunities.GetById(request.Id);

            opportunity.Aprobe(mailService);

            opportunities.Update(opportunity);

            var result =await context.SaveChangesAsync();

            return result > 0;
        }
    }
}
