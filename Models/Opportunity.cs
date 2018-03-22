using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class Opportunity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Country { get; set; }
        public DateTime CallDate { get; set; }
        public decimal Amount { get; set; }


        public int LeadEmployeeId { get; set; }
        public Employee LeadEmployee { get; set; }

    }
}
