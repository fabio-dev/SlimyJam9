public class Destination
{
    public Destination(string name, DestinationType type)
    {
        Name = name;
        Type = type;
    }

    public string Name { get; private set; }
    public DestinationType Type { get; private set; }
}