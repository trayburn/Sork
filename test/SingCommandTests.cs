
using Sork.Commands;
using Sork.World;

namespace Sork.Tests;

[TestClass]
public sealed class SingCommandTests
{
    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new SingCommand(io);
        var gameState = GameState.Create();
        var player = new Player { Name = "Test", Location = gameState.RootRoom, IO = io };

        // Act
        command.Execute("sing", player);

        // Assert
        Assert.AreEqual("You", io.Outputs[0]);
        Assert.AreEqual(" sing!", io.Outputs.Last());
        Assert.AreEqual("Test", io.SpeakOutputs[gameState.RootRoom][0]);
        Assert.AreEqual(" sings!", io.SpeakOutputs[gameState.RootRoom][1]);
    }

    [TestMethod]
    public void Handles_ShouldReturnTrue_WhenCapitalizedInputIsProvided()
    {
        // Arrange
        var command = new SingCommand(new TestInputOutput());

        // Act
        var result = command.Handles("SING");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Handles_ShouldReturnTrue_WhenLowercaseInputIsProvided()
    {
        // Arrange
        var command = new SingCommand(new TestInputOutput());

        // Act
        var result = command.Handles("sing");

        // Assert
        Assert.IsTrue(result);
    }
}
