using CursoAspNet.Core.Domain.Infrastructure;
using CursoAspNet.Core.Domain.OpportunityManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoAspNet.Core.Actions.OpportunityManagement
{
    public class ViewById
    {
        private readonly FysegContext context;

        public ViewById(FysegContext context)
        {
            this.context = context;
        }

        public Opportunity Run(int id)
        {
            var opportunities = new Opportunities(context.Opportunities);

            return opportunities.GetById(id);
        }
    }
}
