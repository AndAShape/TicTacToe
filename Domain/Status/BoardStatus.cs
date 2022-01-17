using System.Collections.Generic;
using Domain.Abstract;

namespace Domain
{
    public class BoardStatus : IBoardStatus
    {
        public IList<(int, int)[]> WinningLines = new List<(int, int)[] >
        {
            { new [] { (0, 0), (0, 1), (0, 2) } },
            { new [] { (1, 0), (1, 1), (1, 2) } },
            { new [] { (2, 0), (2, 1), (2, 2) } },

            { new [] { (0, 0), (1, 0), (2, 0) } },
            { new [] { (0, 1), (1, 1), (2, 1) } },
            { new [] { (0, 2), (1, 2), (2, 2) } },

            { new [] { (0, 0), (1, 1), (2, 2) } },
            { new [] { (0, 2), (1, 1), (2, 0) } },
        };

        public (EnumBoardStatus, EnumCellType?) Status(IBoard board)
        {
            var result = CheckWinningLines(board);

            if (result != null)
            {
                return ((EnumBoardStatus, EnumCellType?)) result;
            }

            if (IsDraw(board))
            {
                return (EnumBoardStatus.Draw, null);
            }

            return (EnumBoardStatus.InProgress, null);
        }

        bool IsDraw(IBoard board)
        {
            var entries = board.Entries;

            for (int i = 0; i < entries.GetLength(0); i++)
            {
                for (int j = 0; j < entries.GetLength(1); j++)
                {
                   if (entries[i, j] == null)
                   {
                        return false;
                   }
                }
            }

            return true;
        }

        (EnumBoardStatus, EnumCellType?)? CheckWinningLines(IBoard board)
        {
            foreach (var line in WinningLines)
            {
                if (CheckWinningLine(EnumCellType.Cross, line, board.Entries))
                {
                    return (EnumBoardStatus.Win, EnumCellType.Cross);
                }
                else if (CheckWinningLine(EnumCellType.Naught, line, board.Entries))
                {
                    return (EnumBoardStatus.Win, EnumCellType.Naught);
                }
            }

            return null;
        }

        bool CheckWinningLine(EnumCellType type,
            (int, int)[] line, EnumCellType?[,] entries) =>
                CheckCell(type, entries, line[0]) &&
                CheckCell(type, entries, line[1]) &&
                CheckCell(type, entries, line[2]);


        bool CheckCell(EnumCellType type, EnumCellType?[,] entries,
            (int, int) winningCell) =>
                entries[winningCell.Item1, winningCell.Item2] == type;
    }
}
