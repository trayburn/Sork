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
    public void Execute_ShouldAddItemToPlayerInventory_WhenItemIsInRoom()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new TakeCommand(io);
        var gameState = GameState.Create(io);

        // Act
        var result = command.Execute("TAKE sword", gameState);

        // Assert
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(1, gameState.Player.Inventory.Count);
        Assert.AreEqual("Sword", gameState.Player.Inventory[0].Name);
    }

    [TestMethod]
    public void Execute_ShouldError_WhenItemIsNotInRoom()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new TakeCommand(io);
        var gameState = GameState.Create(io);

        // Act
        var result = command.Execute("TAKE candle", gameState);

        // Assert
        Assert.IsFalse(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(0, gameState.Player.Inventory.Count);
        Assert.AreEqual(1, io.Outputs.Count);
        Assert.AreEqual("You don't see that item here.", io.Outputs[0]);
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
