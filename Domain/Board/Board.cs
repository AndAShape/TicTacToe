using Domain.Abstract;

namespace Domain
{
    public class Board : IBoard
    {
        public EnumCellType?[,] Entries { get; }
            = new EnumCellType?[3,3];

        public Board() => Clear();

        public void Clear(EnumCellType? boardEntryType = null)
        {
            for (var i = 0; i < Entries.GetLength(0); i++)
            {
                for (var j = 0; j < Entries.GetLength(1); j++)
                {
                    Entries[i, j] = boardEntryType;
                }
            }
        }

        public void Set(int row, int column, EnumCellType boardEntryType) =>
            Entries[row, column] = boardEntryType;
    }
}
