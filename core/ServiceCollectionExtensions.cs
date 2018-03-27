using CursoAspNet.Core.Domain.Infrastructure;
using CursoAspNet.Core.Domain.Mailing;
using CursoAspNet.Core.Infrastructure.Actions;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection
{
    //clase marcadora
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFysegCore(this IServiceCollection services)
        {
            services.AddDbContext<FysegContext>();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ActionLoggingBehaviour<,>));
            services.AddMediatR(typeof(ServiceCollectionExtensions));

            return services;
        }
    }
}
