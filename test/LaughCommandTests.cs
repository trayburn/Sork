using Sork.Commands;

namespace Sork.Tests;

[TestClass]
public sealed class LaughCommandTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        // Arrange
        var command = new LaughCommand(new UserInputOutput());

        // Act
        var result = command.Handles("LOL");

        // Assert
        Assert.IsTrue(result);
    }
}
