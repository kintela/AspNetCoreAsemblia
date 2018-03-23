using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web.Models;
using web.DataBase;
using web.Services;

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

        [HttpPut]
        [Route("{id}")]
        public IActionResult Accept(int id)
        {
            var context = new FysegContext();

            var opportunity = context.Opportunities.SingleOrDefault(o => o.Id == id);

            if (opportunity == null)
            {
                return NoContent();
            }

            opportunity.State = "Accepted";

            context.SaveChanges();

            var mailServive = new MailService();

            var leadMail = context.Employees.SingleOrDefault(e => e.Id == opportunity.LeadEmployeeId).Email;

            mailServive.SendMail(leadMail);

            var tender = new Tender()
            {
                Title=opportunity.Title                
            };

            RedirectToActionResult redirectResult = new RedirectToActionResult("Add", "TenderController", tender);

            return Ok(opportunity);
        }
    }
}