using Microsoft.EntityFrameworkCore;

namespace E_Primary_School.Models
{
    public class ApplicationDbContext:DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Students> Students { get; set; }
    }
}
