using Board.Models;
using Board.Repositories;
using Board.Repositories.Interfaces;
using Board.Services.Interfaces;

namespace Board.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;

        public BoardService(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<_Board> GetBoardById(int id)
        {
            return await _boardRepository.GetBoardByIdAsync(id);
        }

        public async Task<IEnumerable<_Board>> GetAllBoards()
        {
            return await _boardRepository.GetAllBoardsAsync();
        }

        public async Task AddBoard(_Board board)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            await _boardRepository.AddBoardAsync(board);
        }

        public async Task UpdateBoard(_Board board)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            await _boardRepository.UpdateBoardAsync(board);
        }

        public async Task DeleteBoard(int id)
        {
            await _boardRepository.DeleteBoardAsync(id);
        }
    }
}
