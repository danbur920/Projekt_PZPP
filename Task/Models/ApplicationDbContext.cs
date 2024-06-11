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
                new _Task { Id = 3, ListId = 1, Title = "Task 3", Description = "Description 3", Deadline = System.DateTime.Now, State = "To Do" }, 
                new _Task { Id = 4, ListId = 2, Title = "Task 4", Description = "Description 4", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 5, ListId = 2, Title = "Task 5", Description = "Description 5", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 6, ListId = 2, Title = "Task 6", Description = "Description 6", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 7, ListId = 3, Title = "Task 7", Description = "Description 7", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 8, ListId = 3, Title = "Task 8", Description = "Description 8", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 9, ListId = 3, Title = "Task 9", Description = "Description 9", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 10, ListId = 4, Title = "Task 10", Description = "Description 10", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 11, ListId = 4, Title = "Task 11", Description = "Description 11", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 12, ListId = 4, Title = "Task 12", Description = "Description 12", Deadline = System.DateTime.Now, State = "To Do" }, 
                new _Task { Id = 13, ListId = 5, Title = "Task 13", Description = "Description 13", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 14, ListId = 5, Title = "Task 14", Description = "Description 14", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 15, ListId = 5, Title = "Task 15", Description = "Description 15", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 16, ListId = 6, Title = "Task 16", Description = "Description 16", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 17, ListId = 6, Title = "Task 17", Description = "Description 17", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 18, ListId = 6, Title = "Task 18", Description = "Description 18", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 19, ListId = 7, Title = "Task 19", Description = "Description 19", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 20, ListId = 7, Title = "Task 20", Description = "Description 20", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 21, ListId = 7, Title = "Task 21", Description = "Description 21", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 22, ListId = 8, Title = "Task 22", Description = "Description 22", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 23, ListId = 8, Title = "Task 23", Description = "Description 23", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 24, ListId = 8, Title = "Task 24", Description = "Description 24", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 25, ListId = 9, Title = "Task 25", Description = "Description 25", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 26, ListId = 9, Title = "Task 26", Description = "Description 26", Deadline = System.DateTime.Now, State = "To Do" },
                new _Task { Id = 27, ListId = 9, Title = "Task 27", Description = "Description 27", Deadline = System.DateTime.Now, State = "To Do" }
            );
        }
    }
}
