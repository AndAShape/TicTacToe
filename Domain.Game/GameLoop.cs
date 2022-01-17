using System;
using Domain;
using Domain.Abstract;
using Domain.Game.Abstract;

namespace Domain.Game
{
    public class GameLoop : IGameLoop
    {
        readonly IGameStep gameStep;
        readonly IInputOutput inputOutput;

        EnumCellType type = EnumCellType.Cross;

        public GameLoop(IGameStep gameStep, IInputOutput inputOutput)
        {
            this.gameStep = gameStep;
            this.inputOutput = inputOutput;
        }

        public void Do(IBoard board)
        {
            while (true)
            {
                UpdatePlayer();

                var status = gameStep.Step(board, type);

                if (IsGameOver(status))
                {
                    return;
                }
            }
        }

        void UpdatePlayer() => type = type == EnumCellType.Cross ?
            EnumCellType.Naught : EnumCellType.Cross;

        bool IsGameOver((EnumBoardStatus, EnumCellType?) status)
        {
            void OutputStatus(string text) => inputOutput.Output($"{Environment.NewLine}{text}");

            if (status.Item1 == EnumBoardStatus.Win)
            {
                OutputStatus($"Win for {(status.Item2 == EnumCellType.Cross ? "X" : "O")}");

                return true;
            }
            else if (status.Item1 == EnumBoardStatus.Draw)
            {
                OutputStatus("Draw");

                return true;
            }

            return false;
        }
    }
}
