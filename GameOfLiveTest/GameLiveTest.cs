using GameOfLiveKata;

namespace GameOfLiveTest;

public class GameLiveTest
{
    [TestCase(2, 2)]
    [TestCase(2, 3)]
    [TestCase(3, 3)]
    public void Field_Return_FieldSize(int column, int row)
    {
        // Arrange
        GameOfLive game = new();
        
        // Act
        var field = game.GetField(new (column * row));
        
        // Assert
        field.fieds
            .Should()
            .NotContainNulls()
            .And
            .HaveCount(column * row);
    } 
}