using List.Models;
using List.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace List.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly ApplicationDbContext _context;

        public ListRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<_List>> GetListsByBoardIdAsync(int boardId)
        {
            return await _context.Lists.Where(l => l.BoardId == boardId).ToListAsync();
        }

        public async Task<IEnumerable<_List>> GetAllListsAsync()
        {
            return await _context.Lists.ToListAsync();
        }

        public async Task<_List> GetListByIdAsync(int id)
        {
            return await _context.Lists.FindAsync(id);
        }

        public async Task<_List> CreateListAsync(_List list)
        {
            await _context.Lists.AddAsync(list);
            await _context.SaveChangesAsync();
            return list;
        }

        public async Task<_List> UpdateListAsync(_List list)
        {
            var existingList = await GetListByIdAsync(list.Id);
            
            if (existingList == null)
            {
                throw new ArgumentException("List not found");
            }

            existingList.Name = list.Name;
            existingList.Description = list.Description;
            existingList.UpdatedAt = DateTime.Now;

            _context.Lists.Update(existingList);
            await _context.SaveChangesAsync();
            return existingList;
        }

        public async Task DeleteListAsync(int id)
        {
            var list = await GetListByIdAsync(id);
            if (list != null)
            {
                _context.Lists.Remove(list);
                await _context.SaveChangesAsync();
            }
        }
    }
}
