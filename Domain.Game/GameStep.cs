using Domain;
using Domain.Abstract;
using Domain.Game.Abstract;

namespace Domain.Game
{
    public class GameStep : IGameStep
    {
        private readonly IGameRenderer gameRenderer;
        private readonly IBoardStatus boardStatus;
        private readonly IGameInput input;

        bool firstTime = true;

        public GameStep(IGameRenderer gameRenderer, IBoardStatus boardStatus, IGameInput input)
        {
            this.gameRenderer = gameRenderer;
            this.boardStatus = boardStatus;
            this.input = input;
        }

        public (EnumBoardStatus, EnumCellType?) Step(IBoard board, EnumCellType type)
        {
            if (firstTime)
            {
                gameRenderer.Render(board);

                firstTime = false;
            }

            var cell = input.Get(board, type);

            board.Set(cell.Item1, cell.Item2, type);

            gameRenderer.Render(board);

            var status = boardStatus.Status(board);

            return status;
        }
    }
}