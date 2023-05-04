namespace Minesweeper.Interfaces
{
    public interface IGame
    {
        void ApplyMove(int dx, int dy);
        void Start();
    }
}