using System.Collections.Immutable;

namespace GameOfLiveKata;

public class Field
{
    public record FieldSize(int Row, int Column)
    {
        public int Size => Row * Column;
    };

    public record FieldPosition(int Row, int Column);

    public IEnumerable<CellState> Fields =>
        _cellStates.ToImmutableArray();
    
    public void SetState(FieldPosition position, CellState live) =>
        _cellStates[GetIndex(position)] = live;
    
    public object GetState(FieldPosition position) =>
        _cellStates[GetIndex(position)];
    
    public Field(FieldSize fieldSize)
    {
        _fieldSize = fieldSize;
        var objects = new CellState[fieldSize.Size];

        for (int i = 0; i < fieldSize.Size; i++)
            objects[i] = CellState.Dead;

        _cellStates = objects;
    }

    private readonly CellState[] _cellStates;
    private readonly FieldSize _fieldSize;
    
    private int GetIndex(FieldPosition position) =>
        (_fieldSize.Row - 1) * position.Row 
        + position.Column - 1;
}
