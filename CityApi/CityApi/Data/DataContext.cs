using CityApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityApi.Data
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
	}
}
