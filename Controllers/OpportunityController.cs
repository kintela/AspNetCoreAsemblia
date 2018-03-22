using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web.Models;
using web.DataBase;

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
            //return Ok(new Opportunity() {
            //    Title="Oportunidad1"
            //});
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


            //return Ok(new Opportunity()
            //{
            //    Id=id,
            //    Title = "Oportunidad1"
            //});
        }

    }
}