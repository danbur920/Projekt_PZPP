using Task.Models;
using Task.Repositories.Interfaces;
using Task.Services.Interfaces;

namespace Task.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<_Task> CreateTaskAsync(_Task task)
        {
            return await _taskRepository.CreateTaskAsync(task);
        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
        }

        public async Task<IEnumerable<_Task>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task<_Task> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetTaskByIdAsync(id);
        }

        public async Task<_Task> UpdateTaskAsync(_Task task)
        {
            return await _taskRepository.UpdateTaskAsync(task);
        }

        public async Task<IEnumerable<_Task>> GetTasksByListIdAsync(int listId)
        {
            return await _taskRepository.GetTasksByListIdAsync(listId);
        }
    }
}
