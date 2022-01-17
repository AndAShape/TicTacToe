using Domain.Abstract;

namespace Domain.Game.Abstract
{
    public interface IGameLoop
    {
        void Do(IBoard board);
    }
}
