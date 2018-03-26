using CursoAspNet.Core.Domain.Infrastructure;
using CursoAspNet.Core.Domain.OpportunityManagement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoAspNet.Core.Actions.OpportunityManagement
{
    public class ListAll:IRequest<IEnumerable<Opportunity>>
    {
    }
}
