using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web.Services;
using Microsoft.EntityFrameworkCore;
using web.Core.Domain.OpportunityManagement;
using Core.Domain.Infrastructure;
using Core.Infrastructure.Mailing;
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
        [Route("{id}/accept")]
        public IActionResult Accept(int id)
        {
            var context = new FysegContext();

            var opportunity = context.Opportunities
                .Include(o=>o.LeadEmployee)
                .SingleOrDefault(o => o.Id == id);

            if (opportunity == null)
            {
                return NoContent();
            }

            opportunity.State = "Accepted";

            //realmente se actualizan todas las propiedades no solo State
            context.Update(opportunity);
            context.SaveChanges();

            var mailServive = new MailService();

            mailServive.SendMail(opportunity.LeadEmployee.Email);

            //var tender = new Tender()
            //{
            //    Title=opportunity.Title                
            //};

            //context.Tenders.Add(tender);

            //provoca error de referencia circular al devover opportunity que a su vez busca empleados y que a su vez busca oportunidades, etc...
            //nunca devlver en una API el modelo de la bbdd o de dominio sino un view model
            return Ok(opportunity);
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