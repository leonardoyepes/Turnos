using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IComercioRepository, ComercioRepository>();
            service.AddAutoMapper(typeof(AutoMapperProfile));
            //service.AddScoped<IVentaService, VentaService>();


        }
    }
}
