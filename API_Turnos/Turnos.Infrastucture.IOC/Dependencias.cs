using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Turnos.Domain.Business.Services;
using Turnos.Domain.Business.Services.Contracts;
using Turnos.Infrastucture.Data.DBContext;
using Turnos.Infrastucture.Data.Repository;
using Turnos.Infrastucture.Data.Repository.Contracts;
using Turnos.Utility.Utils;

namespace Turnos.Infrastucture.IOC
{
    public static class Dependencias
    {
        public static void InyectarDependencias(this IServiceCollection service, IConfiguration configuration)

        {
            service.AddDbContext<DataBaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("StringSql"));
            });

            #region Repository
            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IComercioRepository, ComercioRepository>();
            service.AddScoped<IServicioRepository, ServicioRepository>();
            service.AddScoped<ITurnoRepository, TurnoRepository>();
            #endregion Repository

            #region Mapper
            service.AddAutoMapper(typeof(AutoMapperProfile));
            #endregion Mapper

            #region Services
            service.AddScoped<IComercioService, ComercioService>();
            service.AddScoped<IServicioService, ServicioService>();
            service.AddScoped<ITurnosService, TurnosService>();
            #endregion Services

        }
    }
}
