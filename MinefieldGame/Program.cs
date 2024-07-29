using MinefieldGame.GameControl;
using MinefieldGame.GameInterface;

namespace MinefieldGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] minefield = new bool[8,8];
            minefield[1, 0] = true;
            minefield[2, 2] = true;
            minefield[3, 4] = true;

            var game = new MinefieldGameLogic(minefield);
            var gameInterface = new MinefieldGameInterface(game);
            gameInterface.StartGame();
        }
    }
}
