namespace Domain.Abstract
{
    public interface IBoardStatus
    {
        (EnumBoardStatus, EnumCellType?) Status(IBoard board);
    }
}
