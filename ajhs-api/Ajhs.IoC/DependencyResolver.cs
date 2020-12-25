using Microsoft.Extensions.DependencyInjection;
using Ajhs.Domain.Interfaces;
using Ajhs.Infra.Repositories;

namespace Ajhs.IoC
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
