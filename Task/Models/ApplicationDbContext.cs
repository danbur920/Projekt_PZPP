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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<_Task>().HasData(
                new _Task { Id = 1, ListId = 1, Title = "Task 1", Description = "Description 1", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 2, ListId = 1, Title = "Task 2", Description = "Description 2", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 3, ListId = 1, Title = "Task 3", Description = "Description 3", Deadline = System.DateTime.Now, State = "To Do" }
            );
        }
    }
}
