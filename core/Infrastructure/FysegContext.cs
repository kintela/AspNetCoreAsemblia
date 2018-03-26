using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoAspNet.Core.Domain.OpportunityManagement;

namespace CursoAspNet.Core.Domain.Infrastructure
{
    public class FysegContext : DbContext
    {
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Tender> Tenders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FysegDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseLoggerFactory(new LoggerFactory(new List<ILoggerProvider>() { new ConsoleLoggerProvider((s,l)=>true,true)}));

            }
    }
}
