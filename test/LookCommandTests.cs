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
        var command = new LookCommand(new UserInputOutput());

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
        var command = new LookCommand(io);
        var gameState = GameState.Create(io);

        // Act
        var result = command.Execute("LOOK", gameState);

        // Assert
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(9, io.Outputs.Count); // Name, blank, desc, blank, "Exits:", exit, blank, "Inventory:", inventory
        Assert.AreEqual("Tavern", io.Outputs[0]);
        Assert.AreEqual("", io.Outputs[1]);
        Assert.AreEqual("You are in the Tavern.", io.Outputs[2]);
        Assert.AreEqual("", io.Outputs[3]);
        Assert.AreEqual("Exits:", io.Outputs[4]);
        Assert.AreEqual("down - You are in the dungeon.", io.Outputs[5]);
        Assert.AreEqual("", io.Outputs[6]);
        Assert.AreEqual("Inventory:", io.Outputs[7]);
        Assert.AreEqual("Sword - A sword.", io.Outputs[8]);
    }
}
