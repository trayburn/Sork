using Sork.Commands;
using Sork.World;

namespace Sork.Test;

[TestClass]
public class DropCommandTests
{
    [TestMethod]
    public void Handles_ShouldReturnTrue_WhenInputIsDrop()
    {
        // Arrange
        var command = new DropCommand(new UserInputOutput());

        // Act
        var result = command.Handles("drop sword");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldReturnError_WhenNoItemSpecified()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new DropCommand(io);
        var gameState = GameState.Create(io);

        // Act
        var result = command.Execute("drop", gameState);

        // Assert
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual("Please specify one item to drop.", io.Outputs.Last());
    }

    [TestMethod]
    public void Execute_ShouldReturnError_WhenItemNotInInventory()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new DropCommand(io);
        var gameState = GameState.Create(io);

        // Act
        var result = command.Execute("drop nonexistent", gameState);

        // Assert
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual("You don't have a nonexistent.", io.Outputs.Last());
    }

    [TestMethod]
    public void Execute_ShouldDropItem_WhenItemInInventory()
    {
        // Arrange
        var io = new TestInputOutput();
        var command = new DropCommand(io);
        var gameState = GameState.Create(io);
        var sword = gameState.Player.Location.Inventory.First(i => i.Name == "Sword");
        gameState.Player.Location.Inventory.Remove(sword);
        gameState.Player.Inventory.Add(sword);

        // Act
        var result = command.Execute("drop Sword", gameState);

        // Assert
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual("You dropped the Sword.", io.Outputs.Last());
        Assert.IsFalse(gameState.Player.Inventory.Any(i => i.Name == "Sword"));
        Assert.IsTrue(gameState.Player.Location.Inventory.Any(i => i.Name == "Sword"));
    }
}
