using EmployeeManagement.Application.Repositories;
using EmployeeManagement.Infrastructure.DBContext.EmployeeDBContext;
using EmployeeManagement.Infrastructure.Repositories.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddTransient<IEmployeeRepo, EmployeeRepo>()
                           .AddDbContext<EmployeeDbContext>(o =>
                           {
                               o.UseSqlServer(configuration.GetConnectionString("Conn"));
                           });
        }
    }
}
