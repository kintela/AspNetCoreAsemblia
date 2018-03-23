using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Models;
using web.DataBase;

namespace web.Controllers
{
    [Route("tender")]
    public class TenderController:Controller
    {
        [HttpPost]
        [Route("")]
        public IActionResult Add(Tender tender)
        {
            var context = new FysegContext();

            if (tender == null)
            {
                return NoContent();
            }

            context.Add(tender);

            context.SaveChanges();

            return Ok(tender);
        }
    }
    
}
