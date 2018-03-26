using CursoAspNet.Core.Domain.Infrastructure;
using CursoAspNet.Core.Domain.Mailing;
using CursoAspNet.Core.Infrastructure.Actions;
using CursoAspNet.Core.Infrastructure.Mailing;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection
{
    //clase marcadora
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFysegCore(this IServiceCollection services)
        {
            services.AddDbContext<FysegContext>();
            services.AddScoped<IMailService, SmtpMailService>();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ActionLoggingBehaviour<,>));
            services.AddMediatR(typeof(ServiceCollectionExtensions));

            return services;
        }
    }
}
