using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoAspNet.Core.Domain.OpportunityManagement
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<Opportunity> Opportunities { get; set; }
    }
}
