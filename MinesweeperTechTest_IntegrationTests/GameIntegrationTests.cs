using Minesweeper.Model;
using Xunit;

namespace Minesweeper.Tests
{
    public class GameIntegrationTests
    {
        [Fact]
        public void ApplyMove_ValidMove_UpdatesPlayerPositionAndMoves()
        {
            // Arrange
            var mines = new List<Mine>
            {
                new Mine(1, 1),
                new Mine(2, 2),
                new Mine(3, 1),
                new Mine(4, 2),
                new Mine(5, 1),
            };
            var board = new Board(8, 8, mines);
            var player = new Player(0, 0, 3);
            var game = new Game(board, player);

            // Act
            game.ApplyMove(1, 0); // Move right

            // Assert
            Assert.Equal(1, player.X);
            Assert.Equal(0, player.Y);
            Assert.Equal(1, player.Moves);
        }

        [Fact]
        public void ApplyMove_MoveOntoMine_PlayerLosesLife()
        {
            // Arrange
            var mines = new List<Mine>
            {
                new Mine(1, 1),
                new Mine(2, 2),
                new Mine(3, 1),
                new Mine(4, 2),
                new Mine(5, 1),
            };
            var board = new Board(8, 8, mines);
            var player = new Player(0, 0, 3);
            var game = new Game(board, player);

            // Act
            game.ApplyMove(1, 1); // Move diagonally to (1,1) where a mine is placed

            // Assert
            Assert.Equal(1, player.X);
            Assert.Equal(1, player.Y);
            Assert.Equal(1, player.Moves);
            Assert.Equal(2, player.Lives);
        }
    }
}
