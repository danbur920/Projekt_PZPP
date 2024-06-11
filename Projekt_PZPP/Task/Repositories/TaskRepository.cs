using Microsoft.EntityFrameworkCore;
using Task.Models;
using Task.Repositories.Interfaces;

namespace Task.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<_Task>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<_Task> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<_Task> CreateTaskAsync(_Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<_Task> UpdateTaskAsync(_Task task)
        {
            var existingTask = await _context.Tasks.FindAsync(task.Id);

            if (existingTask == null)
                throw new ArgumentException("Task not found");

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Deadline = task.Deadline;
            existingTask.State = task.State;
            existingTask.ListId = task.ListId;

            _context.Tasks.Update(existingTask);
            await _context.SaveChangesAsync();

            return existingTask;
        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(int id)
        {
            var taskToDelete = await _context.Tasks.FindAsync(id);

            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}

