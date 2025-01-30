using Sork.World;
using Sork.Commands;

namespace Sork.Test;

[TestClass]
public class DanceCommandTests
{
    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new DanceCommand(io);
        var gameState = GameState.Create();
        var player = new Player { Name = "Test", Location = gameState.RootRoom, IO = io };

        // Act
        command.Execute("dance", player);

        // Assert
        Assert.AreEqual("You", io.Outputs[0]);
        Assert.AreEqual(" dance!", io.Outputs.Last());
    }
    [TestMethod]
    public void Handles_ShouldReturnTrue_WhenCapitalizedInputIsProvided()
    {
        // Arrange
        var command = new DanceCommand(new TestInputOutput());

        // Act
        var result = command.Handles("DANCE");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Handles_ShouldReturnTrue_WhenLowercaseInputIsProvided()
    {
        // Arrange
        var command = new DanceCommand(new TestInputOutput());

        // Act
        var result = command.Handles("dance");

        // Assert
        Assert.IsTrue(result);
    }
}

