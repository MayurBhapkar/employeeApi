using employeeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace employeeApi.Shared
{
    public class YouDbContext : DbContext
        {
            public YouDbContext(DbContextOptions<YouDbContext> options) : base(options)
            {

            }



        public DbSet<department> departments { get; set; }

        public DbSet<Employee> employees { get; set; }
    }
}

