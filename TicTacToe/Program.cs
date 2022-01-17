using App;
using Domain;
using Domain.Game;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var standardConsole = new StandardConsole();

            var gameStep = new GameStep(
                new GameRenderer(new Renderer(), standardConsole),
                new BoardStatus(),
                new GameInput(standardConsole));

            var gameLoop = new GameLoop(gameStep, standardConsole);

            gameLoop.Do(new Board());
        }
    }
}
