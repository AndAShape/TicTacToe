using Domain.Abstract;

namespace Domain.Game.Abstract
{
    public interface IGameRenderer
    {
        void Render(IBoard board);
    }
}
