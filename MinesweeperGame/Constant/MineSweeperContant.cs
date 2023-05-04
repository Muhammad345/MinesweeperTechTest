namespace Minesweeper.Constant
{
    public static class MineSweeperContant
    {
        public static class PlayerLocation
        {
            public const int Default_X = 0;
            public const int Default_Y = 0;

        }

        public static class GameConstants
        {
            public const int BoardWidth = 8;
            public const int BoardHeight = 8;
            public const int PlayerLives = 3;
        }

        public static class Movements
        {
            public const string Up = "Up";
            public const string Down = "Down";
            public const string Left = "Left";
            public const string Right = "Right";
        }

        public static class Command
        {
            public const string Up = "U";
            public const string Down = "D";
            public const string Left = "L";
            public const string Right = "R";
        }

        public static class UserDisplayMessage
        {
            public const string StartInfoMessage = $"Enter move ( {Command.Up} for {Movements.Up}, {Command.Down} for  {Movements.Down},  {Command.Left}: {Movements.Left}, {Command.Right} : {Movements.Right}): ";

            public const string InvalidOptionsSelected = $"Invalid input. Please try again : Allowed Command are ( {Command.Up} for {Movements.Up}, {Command.Down} for  {Movements.Down},  {Command.Left}: {Movements.Left}, {Command.Right} : {Movements.Right}):";

            public const string GameOver = $"Game over! You ran out of lives.";
            public static string Congratulations(int moves) => $"Congratulations! You reached the other side in {moves} moves.";

            public const string Exit = $"Press any key to exit.";
        }

    }
}
