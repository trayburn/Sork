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
        var command = new WhistleCommand(io);
        var gameState = GameState.Create(io);

        // Act
        command.Execute("whistle", gameState);

        // Assert
        Assert.AreEqual("You", io.Outputs[0]);
        Assert.AreEqual(" whistle!", io.Outputs.Last());
    }

    [TestMethod]
    public void Handles_ShouldReturnTrue_WhenCapitalizedInputIsProvided()
    {
        // Arrange
        var command = new WhistleCommand(new UserInputOutput());

        // Act
        var result = command.Handles("WHISTLE");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Handles_ShouldReturnTrue_WhenLowercaseInputIsProvided()
    {
        // Arrange
        var command = new WhistleCommand(new UserInputOutput());

        // Act
        var result = command.Handles("whistle");

        // Assert
        Assert.IsTrue(result);
    }
}
