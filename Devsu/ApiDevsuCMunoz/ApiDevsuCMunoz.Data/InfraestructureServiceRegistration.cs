using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ApiDevsuCMunoz.Infrestructure.Persistence;
using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Infrastructure.Repositories;

namespace ApiDevsuCMunoz.Infrastructure
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApiDevsuCMunozDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IMovimientoRepository, MovimientoRepository>();
            services.AddScoped<IInformeRepository, InformeRepository>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            return services;
        }
    }
}
