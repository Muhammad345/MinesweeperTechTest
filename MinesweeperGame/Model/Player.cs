using Minesweeper.Interfaces;

namespace Minesweeper.Model
{
    public class Player : IPlayer
    {
        public int Lives { get; private set; }
        public int Moves { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Player(int x, int y, int lives)
        {
            X = x;
            Y = y;
            Lives = lives;
            Moves = 0;
        }

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
            Moves++;
        }

        public void LoseLife()
        {
            Lives--;
        }
    }
}