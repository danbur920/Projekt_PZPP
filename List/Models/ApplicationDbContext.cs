using Microsoft.EntityFrameworkCore;

namespace List.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<_List> Lists { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=Burazzo\\SQLEXPRESS;Database=ListDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
            }
        }
    }
}
