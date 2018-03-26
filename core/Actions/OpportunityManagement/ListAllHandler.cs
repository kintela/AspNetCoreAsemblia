using CursoAspNet.Core.Domain.Infrastructure;
using CursoAspNet.Core.Domain.OpportunityManagement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CursoAspNet.Core.Actions.OpportunityManagement
{
    public class ListAllHandler : IRequestHandler<ListAll, IEnumerable<Opportunity>>
    {
        private readonly FysegContext context;
        public ListAllHandler(FysegContext context)
        {
            this.context = context;
        }
        public Task<IEnumerable<Opportunity>> Handle(ListAll request, CancellationToken cancellationToken)
        {
            var opportunities = new Opportunities(context.Opportunities);

            return opportunities.GetAll();
        }

    }
}