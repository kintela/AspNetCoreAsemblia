using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web.Models;
using web.DataBase;
using web.Services;
using Microsoft.EntityFrameworkCore;

namespace web.Controllers
{
    [Route("opportunity")]
    public class OpportunityController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var context = new FysegContext();
            return Ok(context.Opportunities.ToList());
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var context = new FysegContext();

            var opportunity = context.Opportunities.SingleOrDefault(o => o.Id == id);

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
            var context = new FysegContext();

            if (opportunity == null)
            {
                return NoContent();
            }

            context.Add(opportunity);

            context.SaveChanges();

            return Ok(opportunity);
        }

        [HttpPost]
        [Route("{id}/accept")]
        public IActionResult Accept(int id)
        {
            var context = new FysegContext();

            var opportunity = context.Opportunities.Include(o=>o.LeadEmployee).SingleOrDefault(o => o.Id == id);

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

            var tender = new Tender()
            {
                Title=opportunity.Title                
            };

            context.Tenders.Add(tender);

            //provoca error de referencia circular al devover opportunity que a su vez busca empleados y que a su vez busca oportunidades, etc...
            //nunca devlver en una API el modelo de la bbdd o de dominio sino un view model
            return Ok(opportunity);
        }


        [HttpPost]
        [Route("{id}/accept2")]
        public IActionResult Accept2(int id)
        {
            var context = new FysegContext();

            var opportunity = new Opportunity()
            {
                Id=id,
                State="accepted"
            };

            var entry = context.Attach(opportunity);

            entry.Property(o => o.State).IsModified=true;

            context.SaveChanges();

            return Ok(opportunity);
        }
    }
}