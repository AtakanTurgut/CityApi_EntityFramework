using CityApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CityApi.Infrastructures.Extensions
{
	public static class ServiceExtension
	{
		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<DataContext>(options =>
			{
				options.UseMySql(configuration.GetConnectionString("mysqlConnection"),                  
					ServerVersion.AutoDetect(configuration.GetConnectionString("mysqlConnection")),     // .UseSqlServer() - "mssqlConnection" => mssql db
					b => b.MigrationsAssembly("CityApi"));                                             // .UseMySql()     - "mysqlConnection" => mysql db

				options.EnableSensitiveDataLogging(true);
			});
		}
	}
}
