using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SM.Business.DataServices;
using SM.Business.Interfaces;
using SM.Data;
using SM.Data.Interfaces;

namespace SM.DependencyInjection
{
    public static class AppInfrastructure
    {
        public static void AppDISetup(this IServiceCollection services , IConfiguration configuration)
        {
            //Configure Entity Framework
            services.AddDbContext<StoreManagementDbContext>(
                options => options
            .UseSqlServer(configuration.GetConnectionString("connString")));

            //Repositories configuration
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Services configuration
            services.AddScoped<IProductService, ProductService>();

        }
    }
}