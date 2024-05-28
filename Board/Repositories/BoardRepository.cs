using Board.Models;
using Board.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Board.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly ApplicationDbContext _context;

        public BoardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<_Board> GetBoardByIdAsync(int id)
        {
            return await _context.Boards.FindAsync(id);
        }

        public async Task<IEnumerable<_Board>> GetAllBoardsAsync()
        {
            return await _context.Boards.ToListAsync();
        }

        public async Task AddBoardAsync(_Board board)
        {
            await _context.Boards.AddAsync(board);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBoardAsync(_Board board)
        {
            _context.Boards.Update(board);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBoardAsync(int id)
        {
            var board = await _context.Boards.FindAsync(id);
            if (board != null)
            {
                _context.Boards.Remove(board);
                await _context.SaveChangesAsync();
            }
        }
    }
}
