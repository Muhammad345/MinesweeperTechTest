using Minesweeper.Interfaces;
using Moq;

namespace Minesweeper.Tests
{
    public class GameTests
    {
        [Fact]
        public void ApplyMove_ValidMove_UpdatesPlayerPosition()
        {
            // Arrange
            var mockBoard = new Mock<IBoard>();
            mockBoard.Setup(b => b.Width).Returns(8);
            mockBoard.Setup(b => b.Height).Returns(8);
            mockBoard.Setup(b => b.IsValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            mockBoard.Setup(b => b.IsMineAt(It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            var mockPlayer = new Mock<IPlayer>();
            mockPlayer.Setup(p => p.X).Returns(0);
            mockPlayer.Setup(p => p.Y).Returns(0);

            var game = new Game(mockBoard.Object, mockPlayer.Object);

            // Act
            game.ApplyMove(1, 0);

            // Assert
            mockPlayer.Verify(p => p.Move(1, 0), Times.Once());
        }

        [Fact]
        public void ApplyMove_InvalidMove_DoesNotUpdatePlayerPosition()
        {
            // Arrange
            var mockBoard = new Mock<IBoard>();
            mockBoard.Setup(b => b.Width).Returns(8);
            mockBoard.Setup(b => b.Height).Returns(8);
            mockBoard.Setup(b => b.IsValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            var mockPlayer = new Mock<IPlayer>();
            mockPlayer.Setup(p => p.X).Returns(0);
            mockPlayer.Setup(p => p.Y).Returns(0);

            var game = new Game(mockBoard.Object, mockPlayer.Object);

            // Act
            game.ApplyMove(1, 0);

            // Assert
            mockPlayer.Verify(p => p.Move(It.IsAny<int>(), It.IsAny<int>()), Times.Never());
        }

        [Fact]
        public void ApplyMove_MoveOntoMine_PlayerLosesLife()
        {
            // Arrange
            var mockBoard = new Mock<IBoard>();
            mockBoard.Setup(b => b.Width).Returns(8);
            mockBoard.Setup(b => b.Height).Returns(8);
            mockBoard.Setup(b => b.IsValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            mockBoard.Setup(b => b.IsMineAt(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            var mockPlayer = new Mock<IPlayer>();
            mockPlayer.Setup(p => p.X).Returns(0);
            mockPlayer.Setup(p => p.Y).Returns(0);
            mockPlayer.Setup(p => p.Lives).Returns(3);

            var game = new Game(mockBoard.Object, mockPlayer.Object);

            // Act
            game.ApplyMove(1, 0);

            // Assert
            mockPlayer.Verify(p => p.LoseLife(), Times.Once());
        }
    }
}
