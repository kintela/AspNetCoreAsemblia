using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CursoAspNet.Core.Infrastructure.Actions
{
    public class ActionLoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        //En startup.cs al meter mvc ya tenemos el loggerfactory y aqui lo pedimos
        private ILogger<ActionLoggingBehaviour<TRequest, TResponse>> logger;
        public ActionLoggingBehaviour(ILogger<ActionLoggingBehaviour<TRequest,TResponse>>logger)
        {
            this.logger = logger;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            logger.LogInformation("Action starting:{name}",typeof(TRequest).Name);

            var response= next();

            logger.LogInformation("Action completed. Response:{response}", response);

            return response;
        }
    }
}
