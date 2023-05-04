namespace Minesweeper.Interfaces
{
    public interface IPlayer
    {
        int Lives { get; }
        int Moves { get; }
        int X { get; }
        int Y { get; }

        void LoseLife();
        void Move(int x, int y);
    }
}