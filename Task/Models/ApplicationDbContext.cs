using Microsoft.EntityFrameworkCore;

namespace Task.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<_Task> Tasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=Burazzo\\SQLEXPRESS;Database=TaskDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
            }
        }
    }
}
