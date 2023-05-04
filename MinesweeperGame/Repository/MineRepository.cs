using Minesweeper.Model;

namespace Minesweeper.Repository
{
    public class MineRepository : IMineRepository
    {
        public List<Mine> GetMines()
        {

            return new List<Mine>
        {
            new Mine(1, 1),
            new Mine(2, 2),
            new Mine(3, 1),
            new Mine(4, 2),
            new Mine(5, 1),
        };
        }
    }
}