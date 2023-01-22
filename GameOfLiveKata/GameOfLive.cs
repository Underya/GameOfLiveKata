namespace GameOfLiveKata;

public class GameOfLive
{
    public Field GetField(Size size)
    {
        var objects = new object[size.size];

        for (int i = 0; i < size.size; i++)
            objects[i] = 0;
                
        return new Field(objects);
    }

    public record Field(IEnumerable<object> fieds);
    
    public record Size(int size);
}