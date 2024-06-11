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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<_List>().HasData(
                new _List { Id = 1, BoardId = 1, Name = "List 1", Description = "Description 1", CreatedAt = System.DateTime.Now, UpdatedAt = System.DateTime.Now },
                new _List { Id = 2, BoardId = 1, Name = "List 2", Description = "Description 2", CreatedAt = System.DateTime.Now, UpdatedAt = System.DateTime.Now },
                new _List { Id = 3, BoardId = 1, Name = "List 3", Description = "Description 3", CreatedAt = System.DateTime.Now, UpdatedAt = System.DateTime.Now }
            );
        }
    }
}
