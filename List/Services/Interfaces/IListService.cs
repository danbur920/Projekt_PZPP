using List.Models;

namespace List.Services.Interfaces
{
    public interface IListService
    {
        Task<IEnumerable<_List>> GetAllListsAsync();
        Task<_List> GetListByIdAsync(int id);
        Task<_List> CreateListAsync(_List list);
        Task<_List> UpdateListAsync(_List list);
        Task DeleteListAsync(int id);
    }
}
