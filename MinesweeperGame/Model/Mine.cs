using Minesweeper.Interfaces;

namespace Minesweeper.Model
{
    public class Mine : IMine
    {
        public int X { get; }
        public int Y { get; }

        public Mine(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}