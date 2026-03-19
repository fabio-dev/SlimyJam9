public class GameData : Singleton<GameData>
{
    public GameContext Context { get; private set; }

    protected override void AwakeInternal()
    {
        Context = new GameContext();
    }
}
