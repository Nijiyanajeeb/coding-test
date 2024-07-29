namespace MinefieldGame.GameModels
{
    public class BoardPosition
    {
        public int X {get; set;}
        public int Y {get; set;}

        public BoardPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    X--;
                    break;
                case MoveDirection.Down:
                    X++;
                    break;
                case MoveDirection.Left:
                    Y--;
                    break;
                case MoveDirection.Right:
                    Y++;
                    break;
               
            }
        }
    }
}