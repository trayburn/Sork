using Sork.Commands;
using Sork.World;

namespace Sork.Tests;

[TestClass]
public sealed class ExitCommandTests
{
    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new ExitCommand(io);
        var gameState = GameState.Create();
        var player = new Player { Name = "Test", Location = gameState.RootRoom, IO = io };

        // Act
        command.Execute("exit", player);

        // Assert
        Assert.AreEqual(0, io.Outputs.Count);
    }

    [TestMethod]
    public void Handles_ShouldReturnTrue_WhenCapitalizedInputIsProvided()
    {
        // Arrange
        var command = new ExitCommand(new TestInputOutput());

        // Act
        var result = command.Handles("EXIT");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Handles_ShouldReturnTrue_WhenLowercaseInputIsProvided()
    {
        // Arrange
        var command = new ExitCommand(new TestInputOutput());

        // Act
        var result = command.Handles("exit");

        // Assert
        Assert.IsTrue(result);
    }
}
