using System;
using MinefieldGame.GameModels;

namespace MinefieldGame.GameControl
{
    public class MinefieldGameLogic
    {
        private const int BoardSize = 8;
        private bool[,] _minefield;
        private BoardPosition _playerPosition;
        private int _lives;
        private int _moves;
        public int newX;
        public int newY;


        public MinefieldGameLogic(bool[,] minefield, int lives = 3)
        {
            _minefield = minefield;
            _playerPosition = new BoardPosition(0,0);
            _lives = lives;
            _moves = 0;
        }

        public int Lives => _lives;
        public int Moves => _moves;
        public BoardPosition PlayerPosition => _playerPosition;

        public void MovePlayer(MoveDirection direction)
        {
            _playerPosition.Move(direction);
           
            newX = _playerPosition.X;
            newY = _playerPosition.Y;

            IsOutBoundMove();
            _moves++;           


            if(IsMine(_playerPosition))
            {
                _lives--;
            }                                 
        }

        private bool IsMine(BoardPosition position)
        {
            return _minefield[position.X, position.Y];
        }

        public bool IsGameOver()
        {
            if(_lives <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void IsOutBoundMove()
        {
            if (newX < 0 || newX >= BoardSize || newY < 0 || newY >= BoardSize)
            {
                Console.WriteLine("Move is out of bounds!");
                return;     
            }
        }

        public bool IsGameWin()
        {
            if (newX == BoardSize - 1 )
            {               
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}