using CursoAspNet.Core.Domain.Mailing;
using System;

namespace CursoAspNet.Core.Domain.OpportunityManagement
{
    public class Opportunity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public DateTime CallDate { get; set; }
        public decimal Amount { get; set; }
        public string State { get; set; }


        public int LeadEmployeeId { get; set; }
        public Employee LeadEmployee { get; set; }

        public bool Aprobe(IMailService mailService)
        {
            State = "aprobbed";

            mailService.Send(new Mail()
            {
                From = "",
                To=LeadEmployee?.Email,
                Body=$"Se ha aprobado la oportunidad {Id}",
                Subject="Oportunidad aprobada"
            });

            //estoy metiendo una dependencia de otra clase
            //no tengo que poder cambiar y si mañana uso mailchimp tendria que cambiar
            //en mi clase de dominio no tengo que saber nada de como enviarun mail
            //var mailServive = new SmtpMailService();

            //mailServive.SendMail(LeadEmployee.Email);

            return true;
        }

    }
}
