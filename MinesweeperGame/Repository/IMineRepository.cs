using Minesweeper.Model;

namespace Minesweeper.Repository
{
    public interface IMineRepository
    {
        List<Mine> GetMines();
    }
}