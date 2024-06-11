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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<_Board>().HasData(
                new _Board { Id = 1, Name = "Board 1", Description = "Description 1", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new _Board { Id = 2, Name = "Board 2", Description = "Description 2", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new _Board { Id = 3, Name = "Board 3", Description = "Description 3", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );
        }
    }
}