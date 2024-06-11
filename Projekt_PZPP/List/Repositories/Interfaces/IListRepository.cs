using List.Models;

namespace List.Repositories.Interfaces
{
    public interface IListRepository
    {
        Task<IEnumerable<_List>> GetAllListsAsync();
        Task<_List> GetListByIdAsync(int id);
        Task<_List> CreateListAsync(_List list);
        Task<_List> UpdateListAsync(_List list);
        Task DeleteListAsync(int id);
        Task<IEnumerable<_List>> GetListsByBoardIdAsync(int boardId);
    }
}
