using UnityEngine;

public class AsteroidsSceneManager : MonoBehaviour
{
    [SerializeField] private AsteroidGO _asteroidPrefab;
    [SerializeField] private SpacecraftGO _spacecraft;
    [SerializeField] private SpacecraftHealthUI _healthUI;
    [SerializeField] private ProjectileRemainingUI _projectileUI;
    [SerializeField] private AsteroidsSpawner _asteroidsSpawner;

    private GameContext _gameContext;

    private void Start()
    {
        _gameContext = new GameContext();
        Setup();
    }

    public void Setup()
    {
        _spacecraft.Bind(_gameContext.Spacecraft);
        _healthUI.Bind(_gameContext.Spacecraft);
        _projectileUI.Bind(_gameContext.Spacecraft);

        _gameContext.Spacecraft.OnDamaged += PlayDamagedSound;
        _asteroidsSpawner.StartSpawning();
    }

    private void PlayDamagedSound()
    {
        SoundEffectsPlayer.Instance.PlaySpacecraftDamaged();
    }
}
