using Board.Models;

namespace Board.Services.Interfaces
{
    public interface IBoardService
    {
        Task<_Board> GetBoardById(int id);
        Task<IEnumerable<_Board>> GetAllBoards();
        Task AddBoard(_Board board);
        Task UpdateBoard(_Board board);
        Task DeleteBoard(int id);
    }
}
