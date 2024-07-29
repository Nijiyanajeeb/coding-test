using System;
using MinefieldGame.GameModels;
using MinefieldGame.GameControl;

namespace MinefieldGame.GameInterface
{
    public class MinefieldGameInterface
    {
        private readonly MinefieldGameLogic _game;

        public MinefieldGameInterface(MinefieldGameLogic game)
        {
            _game = game;
        }
        
        public void StartGame()
        {
            while(!_game.IsGameOver() && !_game.IsGameWin())
            {
                Console.WriteLine($"Current Position: {_game.PlayerPosition.X}, {_game.PlayerPosition.Y}");
                Console.WriteLine($"Lives: {_game.Lives}, Moves: {_game.Moves}");

                Console.WriteLine($"Enter move direction (up, down, left, right)");
                var input = Console.ReadLine();

                MoveDirection direction;
                if(Enum.TryParse(input, true, out direction))
                {
                    _game.MovePlayer(direction);
                }
                else
                {
                    Console.WriteLine($"Invalid Direction");
                }
            }

            if(_game.IsGameOver())
            {
                Console.WriteLine($"Game Over");
            }
            else
            {
                Console.WriteLine($"Hurray! You win");
            }

            Console.WriteLine($"Final Position: {_game.PlayerPosition.X}, {_game.PlayerPosition.Y}");
            Console.WriteLine($"Lives: {_game.Lives}, Moves: {_game.Moves}");
            Console.WriteLine($"Final Score: {_game.Moves}");
        }

    }
}