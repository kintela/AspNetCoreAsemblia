using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Core.Domain.OpportunityManagement;
using Core.Domain.Infrastructure;
using Core.Domain.Mail;

namespace web.Controllers
{
    [Route("opportunity")]
    public class OpportunityController : Controller
    {
        private readonly FysegContext context;
        private readonly IMailService mailService;

        public OpportunityController(FysegContext context, IMailService mailService)
        {
            //    context = new FysegContext();
            //    mailService = new SmtpMailService();

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