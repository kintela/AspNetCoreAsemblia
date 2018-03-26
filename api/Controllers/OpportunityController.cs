using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CursoAspNet.Core.Domain.OpportunityManagement;
using CursoAspNet.Core.Domain.Infrastructure;
using CursoAspNet.Core.Domain.Mailing;
using CursoAspNet.Core.Infrastructure.Mailing;

namespace CursoAspNet.Api.Controllers
{
    [Route("opportunity")]
    public class OpportunityController : Controller
    {
        private readonly FysegContext context;
        private readonly SmtpMailService mailService;

        public OpportunityController(FysegContext context, SmtpMailService mailService)
        {

            this.context = context;
            this.mailService = mailService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var opportunities = new Opportunities(context.Opportunities);

            return Ok(opportunities.GetAll());
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var opportunities = new Opportunities(context.Opportunities);

            var opportunity=opportunities.GetById(id);

            if (opportunity==null)
            {
                return NoContent();
            }

            return Ok(opportunity);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add([FromBody] Opportunity opportunity)
        {
            var opportunities = new Opportunities(context.Opportunities);

            opportunities.Create(opportunity);

            bool created = context.SaveChanges() > 0;

            if (!created)
                return BadRequest();

            return Ok(opportunity.Id);
        }

       

        [HttpPost]
        [Route("{id}/approbe")]
        public IActionResult Approbe(int id)
        {
            var opportunities = new Opportunities(context.Opportunities);

            var opportunity = opportunities.GetById(id);

            opportunity.Aprobe(mailService);

            bool approbed = context.SaveChanges() > 0;

            if (!approbed)
                return BadRequest();

            return Ok();
        }
    }
}