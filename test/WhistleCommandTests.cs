using Sork.Commands;
using Sork.World;

namespace Sork.Tests;

[TestClass]
public sealed class WhistleCommandTests
{
    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        // Arrange
        var io = new TestInputOutput();
        var gameState = GameState.Create();
        var player = new Player { Name = "Test", Location = gameState.RootRoom, IO = io };
        var command = new WhistleCommand(io);

        // Act
            command.Execute("whistle", player);

        // Assert
        Assert.AreEqual("You", io.Outputs[0]);
        Assert.AreEqual(" whistle!", io.Outputs.Last());
        Assert.AreEqual("Test", io.SpeakOutputs[gameState.RootRoom][0]);
        Assert.AreEqual(" whistles!", io.SpeakOutputs[gameState.RootRoom][1]);
    }

    [TestMethod]
    public void Handles_ShouldReturnTrue_WhenCapitalizedInputIsProvided()
    {
        // Arrange
        var command = new WhistleCommand(new TestInputOutput());

        // Act
        var result = command.Handles("WHISTLE");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Handles_ShouldReturnTrue_WhenLowercaseInputIsProvided()
    {
        // Arrange
        var command = new WhistleCommand(new TestInputOutput());

        // Act
        var result = command.Handles("whistle");

        // Assert
        Assert.IsTrue(result);
    }
}
