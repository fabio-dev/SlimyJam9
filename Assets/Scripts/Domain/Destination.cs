using JetBrains.Annotations;

public class Destination
{
    public Destination(string name, string description, DestinationType type)
    {
        Name = name;
        Description = description;
        Type = type;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public DestinationType Type { get; private set; }
}