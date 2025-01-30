using Sork.Commands;
using Sork.World;

namespace Sork.Tests;

[TestClass]
public sealed class LaughCommandTests
{
    [TestMethod]
    public void Handles_ShouldReturnTrue_WhenCapitalizedInputIsProvided()
    {
        // Arrange
        var command = new LaughCommand(new TestInputOutput());

        // Act
        var result = command.Handles("LOL");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new LaughCommand(io);
        var gameState = GameState.Create();
        var player = new Player { Name = "Test", Location = gameState.RootRoom, IO = io };

        // Act
        command.Execute("LOL", player);

        // Assert
        Assert.AreEqual("You", io.Outputs[0]);
        Assert.AreEqual(" laugh out loud!", io.Outputs.Last());
        Assert.AreEqual("Test", io.SpeakOutputs[gameState.RootRoom][0]);
        Assert.AreEqual(" laughs out loud!", io.SpeakOutputs[gameState.RootRoom][1]);
    }

    [TestMethod]
    public void Handles_ShouldReturnTrue_WhenLowercaseInputIsProvided()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new LaughCommand(io);
        var gameState = GameState.Create();
        var player = new Player { Name = "Test", Location = gameState.RootRoom, IO = io };

        // Act
        var result = command.Handles("lol");

        // Assert
        Assert.IsTrue(result);
    }
}
