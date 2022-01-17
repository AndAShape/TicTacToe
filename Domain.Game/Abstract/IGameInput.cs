namespace Domain.Abstract
{
    public interface IGameInput
    {
        (int, int) Get(IBoard board, EnumCellType boardEntryType);
    }
}