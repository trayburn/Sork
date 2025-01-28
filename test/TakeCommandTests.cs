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
        var gameState = GameState.Create();
        var player = new Player { Name = "Test", Location = gameState.RootRoom };

        // Act
        var result = command.Execute("TAKE sword", player);

        // Assert
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(1, player.Inventory.Count);
        Assert.AreEqual("Sword", player.Inventory[0].Name);
    }

    [TestMethod]
    public void Execute_ShouldError_WhenItemIsNotInRoom()
    {
        // Arrange
        var io = new TestInputOutput();
        var gameState = GameState.Create();
        var command = new TakeCommand(io);
        var player = new Player { Name = "Test", Location = gameState.RootRoom };

        // Act
        var result = command.Execute("TAKE candle", player);

        // Assert
        Assert.IsFalse(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(0, player.Inventory.Count);
        Assert.AreEqual(1, io.Outputs.Count);
        Assert.AreEqual("You don't see that item here.", io.Outputs[0]);
    }

    [TestMethod]
    public void Execute_ShouldOutputError_WhenNoParametersAreProvided()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new TakeCommand(io);
        var gameState = GameState.Create();
        var player = new Player { Name = "Test", Location = gameState.RootRoom };

        // Act
        var result = command.Execute("TAKE", player);

        // Assert
        Assert.AreEqual(1, io.Outputs.Count);
        Assert.AreEqual("You must specify an item to take.", io.Outputs[0]);
        Assert.IsFalse(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
    }
}
