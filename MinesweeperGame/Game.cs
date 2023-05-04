using Minesweeper.Constant;
using Minesweeper.Interfaces;

namespace Minesweeper
{
    public class Game : IGame
    {
        private readonly IBoard _board;
        private readonly IPlayer _player;

        public Game(IBoard board, IPlayer player)
        {
            _board = board;
            _player = player;
        }

        public void Start()
        {
            bool gameInProgress = true;

            while (gameInProgress)
            {
                
                DisplayGameState();
                Console.WriteLine(MineSweeperContant.UserDisplayMessage.StartInfoMessage);
                string input = Console.ReadLine() ?? string.Empty;

                int dx = 0;
                int dy = 0;

                switch (input.ToUpper())
                {
                    case MineSweeperContant.Command.Up:
                        dy = -1;
                        break;
                    case MineSweeperContant.Command.Down:
                        dy = 1;
                        break;
                    case MineSweeperContant.Command.Left:
                        dx = -1;
                        break;
                    case MineSweeperContant.Command.Right:
                        dx = 1;
                        break;
                    default:
                        Console.WriteLine(MineSweeperContant.UserDisplayMessage.InvalidOptionsSelected);
                        continue;
                }

                ApplyMove(dx, dy);

                if (_player.Lives == 0)
                {
                    Console.Clear();
                    Console.WriteLine(MineSweeperContant.UserDisplayMessage.GameOver);
                    gameInProgress = false;
                }
                else if (_player.X == _board.Width - 1 && _player.Y == _board.Height - 1)
                {
                    Console.Clear();
                    Console.WriteLine(MineSweeperContant.UserDisplayMessage.Congratulations(_player.Moves));
                    gameInProgress = false;
                }
            }

            Console.WriteLine(MineSweeperContant.UserDisplayMessage.Exit);
            Console.ReadKey();
        }

        private void DisplayGameState()
        {
            Console.WriteLine($"Position: {_player.X + 1},{_player.Y + 1}");
            Console.WriteLine($"Lives: {_player.Lives}");
            Console.WriteLine($"Moves: {_player.Moves}");
            Console.WriteLine();
        }

        public void ApplyMove(int dx, int dy)
        {
            int newX = _player.X + dx;
            int newY = _player.Y + dy;

            if (_board.IsValidPosition(newX, newY))
            {
                if (_board.IsMineAt(newX, newY))
                {
                    _player.LoseLife();
                }

                _player.Move(newX, newY);
            }
        }
    }
}