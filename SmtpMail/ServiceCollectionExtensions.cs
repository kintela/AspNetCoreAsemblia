using CursoAspNet.Core.Domain.Mailing;
using SmtpMail;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSmtp(this IServiceCollection services)
        {
            services.AddScoped<IMailService, SmtpMailService>();

            return services;
        }
    }
}
