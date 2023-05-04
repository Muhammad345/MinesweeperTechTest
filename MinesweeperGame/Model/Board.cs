using Minesweeper.Interfaces;

namespace Minesweeper.Model
{
    public class Board : IBoard
    {
        public int Width { get; }
        public int Height { get; }
        public List<Mine> Mines { get; }

        public Board(int width, int height, List<Mine> mines)
        {
            Width = width;
            Height = height;
            Mines = mines;
        }

        public bool IsMineAt(int x, int y)
        {
            return Mines.Any(mine => mine.X == x && mine.Y == y);
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }
}