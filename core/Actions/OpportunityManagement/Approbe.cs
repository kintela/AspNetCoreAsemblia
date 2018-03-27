using MediatR;

namespace CursoAspNet.Core.Actions.OpportunityManagement
{
    public class Approbe:IRequest<bool>
    {

        public Approbe(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
              
    }
}
