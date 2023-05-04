using Minesweeper.Model;

namespace Minesweeper.Interfaces
{
    public interface IBoard
    {
        int Height { get; }
        List<Mine> Mines { get; }
        int Width { get; }

        bool IsMineAt(int x, int y);
        bool IsValidPosition(int x, int y);
    }
}
