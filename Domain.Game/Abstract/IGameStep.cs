using Domain;
using Domain.Abstract;

namespace Domain.Game.Abstract
{
    public interface IGameStep
    {
        (EnumBoardStatus, EnumCellType?) Step(IBoard board, EnumCellType type);
    }
}
