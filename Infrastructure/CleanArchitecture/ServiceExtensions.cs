using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistenceApp(this IServiceCollection services,
        IConfiguration configuration)
        {
            var connectionString = "server=localhost;user=root;password=root;database=MacorattiCleanArchitecture;";
        //    var connectionString = configuration.GetConnectionString("mysql");
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, serverVersion));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

        }
}
