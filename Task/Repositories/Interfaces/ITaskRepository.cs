using Task.Models;

namespace Task.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<_Task>> GetAllTasksAsync();
        Task<_Task> GetTaskByIdAsync(int id);
        Task<_Task> CreateTaskAsync(_Task task);
        Task<_Task> UpdateTaskAsync(_Task task);
        System.Threading.Tasks.Task DeleteTaskAsync(int id);
        Task<IEnumerable<_Task>> GetTasksByListIdAsync(int listId);
    }
}
