namespace GameOfLiveKata;

public class GameOfLive
{
    private readonly Field _field;

    public GameOfLive(Field.FieldSize size)
    {
        _field = new Field(size);
    }
    
    public Field GetField =>
        _field;

    public void SetState(Field.FieldPosition position, CellState state) =>
        _field.SetState(position, state);

    public object GetState(Field.FieldPosition position) =>
        _field.GetState(position);

    public void Life()
    {
        SetState(new(2, 2), CellState.Dead);
    }
}