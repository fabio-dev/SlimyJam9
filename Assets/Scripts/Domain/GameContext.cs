public class GameContext
{
    public GameContext()
    {
        Spacecraft = new Spacecraft(10, 10);
    }

    public Spacecraft Spacecraft { get; private set; }
}