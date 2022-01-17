namespace Domain.Abstract
{
    public interface IBoard
    {
        EnumCellType?[,] Entries { get; }

        void Clear(EnumCellType? boardEntryType = null);

        void Set(int row, int column, EnumCellType boardEntryType);
    }
}