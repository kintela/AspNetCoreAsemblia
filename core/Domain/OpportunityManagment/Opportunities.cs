using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoAspNet.Core.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CursoAspNet.Core.Infrastructure.Mailing;

namespace CursoAspNet.Core.Domain.OpportunityManagement
{
    public class Opportunities
    {
        private readonly DbSet<Opportunity> opportunities;
        public Opportunities(DbSet<Opportunity>opportunities)
        {
            this.opportunities = opportunities;
        }
        public IEnumerable<Opportunity> GetAll()
        {
            return opportunities.ToList();
        }

        public Opportunity GetById(int id)
        {
            return opportunities
                .Include(o=>o.LeadEmployee)
                .SingleOrDefault(o => o.Id == id);
        }

        public void Create(Opportunity opportunity)
        {
            opportunities.Add(opportunity);

            ////devuelve el rowcount de lo que se ha hecho
            //int changes = opportunities.SaveChanges();

            //return changes > 0;
        }

        public void Update(Opportunity opportunity)
        {
            opportunities.Update(opportunity);
        }
    }
}
