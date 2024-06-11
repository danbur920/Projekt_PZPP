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
                new _List { Id = 3, BoardId = 1, Name = "List 3", Description = "Description 3", CreatedAt = System.DateTime.Now, UpdatedAt = System.DateTime.Now },
                new _List { Id = 4, BoardId = 2, Name = "List 4", Description = "Description 4", CreatedAt = System.DateTime.Now, UpdatedAt = System.DateTime.Now },
                new _List { Id = 5, BoardId = 2, Name = "List 5", Description = "Description 5", CreatedAt = System.DateTime.Now, UpdatedAt = System.DateTime.Now },
                new _List { Id = 6, BoardId = 2, Name = "List 6", Description = "Description 6", CreatedAt = System.DateTime.Now, UpdatedAt = System.DateTime.Now },
                new _List { Id = 7, BoardId = 3, Name = "List 7", Description = "Description 7", CreatedAt = System.DateTime.Now, UpdatedAt = System.DateTime.Now },
                new _List { Id = 8, BoardId = 3, Name = "List 8", Description = "Description 8", CreatedAt = System.DateTime.Now, UpdatedAt = System.DateTime.Now },
                new _List { Id = 9, BoardId = 3, Name = "List 9", Description = "Description 9", CreatedAt = System.DateTime.Now, UpdatedAt = System.DateTime.Now }
            );
        }
    }
}
