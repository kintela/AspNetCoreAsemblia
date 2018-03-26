using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CursoAspNet.Core.Domain.OpportunityManagement;
using CursoAspNet.Core.Domain.Infrastructure;
using CursoAspNet.Core.Domain.Mailing;
using CursoAspNet.Core.Infrastructure.Mailing;
using CursoAspNet.Core.Actions.OpportunityManagement;
using MediatR;
using System.Threading.Tasks;

namespace CursoAspNet.Api.Controllers
{
    [Route("opportunity")]
    public class OpportunityController : Controller
    {
        private readonly IMediator mediator;
        public OpportunityController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("{id}/approbe")]
        public async Task<IActionResult> Approbe(int id)
        {
            var approbeRequest = new Approbe(id);

            var approbeResult=await mediator.Send(approbeRequest);

            if (!approbeResult)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var getAllResponse=await mediator.Send(new ListAll());

            return Ok(getAllResponse);
        }

        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult Get(int id)
        //{

        //    var opportunity = viewById.Run(id);

        //    if (opportunity==null)
        //    {
        //        return NoContent();
        //    }

        //    return Ok(opportunity);
        //}



        //[HttpPost]
        //[Route("")]
        //public IActionResult Add([FromBody] Opportunity opportunity)
        //{
        //    var opportunities = new Opportunities(context.Opportunities);

        //    opportunities.Create(opportunity);

        //    bool created = context.SaveChanges() > 0;

        //    if (!created)
        //        return BadRequest();

        //    return Ok(opportunity.Id);
        //}




    }
}