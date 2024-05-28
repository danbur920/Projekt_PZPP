using Task.Models;

namespace Task.Services.Interfaces
{
    public interface ITaskService
    {
        Task<_Task> CreateTaskAsync(_Task task);
        System.Threading.Tasks.Task DeleteTaskAsync(int id);
        Task<IEnumerable<_Task>> GetAllTasksAsync();
        Task<_Task> GetTaskByIdAsync(int id);
        Task<_Task> UpdateTaskAsync(_Task task);
    }
}
