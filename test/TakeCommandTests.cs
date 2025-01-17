using Sork.Commands;
using Sork.World;

namespace Sork.Tests;

[TestClass]
public sealed class TakeCommandTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        // Arrange
        var command = new TakeCommand(new UserInputOutput());

        // Act
        var result = command.Handles("TAKE sword");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldOutputError_WhenNoParametersAreProvided()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new TakeCommand(io);
        var gameState = GameState.Create(io);

        // Act
        var result = command.Execute("TAKE", gameState);

        // Assert
        Assert.AreEqual(1, io.Outputs.Count);
        Assert.AreEqual("You must specify an item to take.", io.Outputs[0]);
        Assert.IsFalse(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
    }
}
