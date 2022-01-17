using Domain.Abstract;
using Domain.Game.Abstract;

namespace Domain.Game
{
    public class GameRenderer : IGameRenderer
    {
        readonly IInputOutput inputOutput;
        readonly IRenderer renderer;

        public GameRenderer(IRenderer renderer, IInputOutput inputOutput)
        {
            this.inputOutput = inputOutput;
            this.renderer = renderer;
        }

        public void Render(IBoard board)
        {
            var output = renderer.Render(board);

            inputOutput.Output();

            inputOutput.Output(output);
        }
    }
}