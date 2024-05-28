using List.Models;
using List.Repositories.Interfaces;
using List.Services.Interfaces;

namespace List.Services
{
    public class ListService : IListService
    {
        private readonly IListRepository _listRepository;

        public ListService(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public async Task<IEnumerable<_List>> GetAllListsAsync()
        {
            return await _listRepository.GetAllListsAsync();
        }

        public async Task<_List> GetListByIdAsync(int id)
        {
            return await _listRepository.GetListByIdAsync(id);
        }

        public async Task<_List> CreateListAsync(_List list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            return await _listRepository.CreateListAsync(list);
        }

        public async Task<_List> UpdateListAsync(_List list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            return await _listRepository.UpdateListAsync(list);
        }

        public async Task DeleteListAsync(int id)
        {
            await _listRepository.DeleteListAsync(id);
        }
    }
}
