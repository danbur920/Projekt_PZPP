using Board.Models;

namespace Board.Repositories.Interfaces
{
    public interface IBoardRepository
    {
        Task<_Board> GetBoardByIdAsync(int id);
        Task<IEnumerable<_Board>> GetAllBoardsAsync();
        Task AddBoardAsync(_Board board);
        Task UpdateBoardAsync(_Board board);
        Task DeleteBoardAsync(int id);
    }
}
