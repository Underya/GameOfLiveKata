using GameOfLiveKata;

namespace GameOfLiveTest;

public class GameOfLiveTest
{
    [TestCase(2, 2)]
    [TestCase(2, 3)]
    [TestCase(3, 3)]
    public void Field_Return_FieldSize(int column, int row)
    {
        // Arrange
        GameOfLive game = new(new (column ,row));
        
        // Act
        var field = game.GetField;
        
        // Assert
        field.Fields
            .Should()
            .NotContainNulls()
            .And
            .HaveCount(column * row);
    }

    [TestCase(1, 1, CellState.Live)]
    [TestCase(2, 2, CellState.Dead)]
    [TestCase(3, 3, CellState.Dead)]
    public void SetState_GetState_Equal(int row, int column, CellState cellState)
    {
        GameOfLive game = new(new (3, 3));
        
        // Act
        game.SetState(new(row, column), cellState);
        var state = game.GetState(new(row, column));
        
        // Assert
        state.Should()
            .Be(cellState);
    }

    [Test]
    public void LessTwoNeighbors_Field_CellIsDead()
    {
        // Arrange
        var game = new GameOfLive(new(3, 3)); 
        game.SetState(new( 2, 2), CellState.Live);
        
        // Act 
        game.Life();
        var cellState = game.GetState(new(2, 2));
        
        // Assert
        cellState.Should()
            .Be(CellState.Dead);
    }

    [Test]
    public void ExactlyThreeNeighbours_LiveCell_IsLive()
    {
        var game = new GameOfLive(new(3, 3)); 
        game.SetState( new(2, 2), CellState.Live);

        game.SetState(new(2, 1), CellState.Live);
        game.SetState(new(2, 3), CellState.Live);
        game.SetState(new(2, 3), CellState.Live);
        
        // Act 
        game.Life();
        var cellState = game.GetState(new(2, 2));
        
        // Assert
        cellState.Should()
            .Be(CellState.Live);
    }
}