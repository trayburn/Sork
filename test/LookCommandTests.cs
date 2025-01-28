using Sork.Commands;
using Sork.World;

namespace Sork.Tests;

[TestClass]
public sealed class LookCommandTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        // Arrange
        var gameState = GameState.Create(); 
        var command = new LookCommand(new UserInputOutput(), gameState);

        // Act
        var result = command.Handles("LOOK");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldDisplayRoomInfo()
    {
        // Arrange
        var io = new TestInputOutput();
        var gameState = GameState.Create();
        var command = new LookCommand(io, gameState);
        var player = new Player { Name = "Test", Location = gameState.RootRoom };

        // Act
        var result = command.Execute("LOOK", player);

        // Assert
        var tavernInventoryCount = player.Location.Inventory.Count;
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(8 + tavernInventoryCount, io.Outputs.Count); // Name, blank, desc, blank, "Exits:", exit, blank, "Inventory:", inventory
        Assert.AreEqual("Tavern", io.Outputs[0]);
        Assert.AreEqual("", io.Outputs[1]);
        Assert.AreEqual("You are in the Tavern.", io.Outputs[2]);
        Assert.AreEqual("", io.Outputs[3]);
        Assert.AreEqual("Exits:", io.Outputs[4]);
        Assert.AreEqual("down - You are in the dungeon.", io.Outputs[5]);
        Assert.AreEqual("", io.Outputs[6]);
        Assert.AreEqual("Inventory:", io.Outputs[7]);      
        Assert.IsTrue(io.Outputs.Skip(7).Any(o => o == "Sword - A sword."));
    }
}
