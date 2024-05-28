using Microsoft.EntityFrameworkCore;

namespace Board.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<_Board> Boards { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=Burazzo\\SQLEXPRESS;Database=BoardDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
            }
        }
    }
}
