using Board.Models;
using Board.Repositories.Interfaces;
using Board.Services;
using Moq;

namespace Tests
{
    public class BoardServiceTests
    {
        private readonly Mock<IBoardRepository> _boardRepositoryMock;
        private readonly BoardService _boardService;

        public BoardServiceTests()
        {
            _boardRepositoryMock = new Mock<IBoardRepository>();
            _boardService = new BoardService(_boardRepositoryMock.Object);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetBoardById_Test()
        {
            var boardId = 1;
            var board = new _Board { Id = boardId };
            _boardRepositoryMock.Setup(repo => repo.GetBoardByIdAsync(boardId)).ReturnsAsync(board);

            var result = await _boardService.GetBoardById(boardId);

            Assert.NotNull(result);
            Assert.Equal(boardId, result.Id);
        }


        [Fact]
        public async System.Threading.Tasks.Task GetAllBoards_Test()
        {
            var boards = new List<_Board> { new _Board { Id = 1 }, new _Board { Id = 2 } };
            _boardRepositoryMock.Setup(repo => repo.GetAllBoardsAsync()).ReturnsAsync(boards);

            var result = await _boardService.GetAllBoards();

            Assert.Equal(boards.Count, result.Count());
        }

        [Fact]
        public async System.Threading.Tasks.Task AddBoard_Test()
        {
            var board = new _Board { Id = 1 };

            await _boardService.AddBoard(board);

            _boardRepositoryMock.Verify(repo => repo.AddBoardAsync(board), Times.Once);
        }
    }
}