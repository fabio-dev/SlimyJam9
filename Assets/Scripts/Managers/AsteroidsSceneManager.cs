using System.Collections;
using UnityEngine;

public class AsteroidsSceneManager : MonoBehaviour
{
    [SerializeField] private AsteroidGO _asteroidPrefab;
    [SerializeField] private SpacecraftGO _spacecraft;
    [SerializeField] private SpacecraftHealthUI _healthUI;

    private int _numberOfAsteroidsToSpawn;
    private float _spawnIntervalInSeconds;
    private bool _isSpawning = false;
    private GameContext _gameContext;

    private const float X_SPAWN_POSITION = 10f;

    private void Start()
    {
        _gameContext = new GameContext();
        Setup(12, .3f);
        StartSpawning();
    }

    public void Setup(int numberOfAsteroidsToSpawn, float spawnIntervalInMs)
    {
        _numberOfAsteroidsToSpawn = numberOfAsteroidsToSpawn;
        _spawnIntervalInSeconds = spawnIntervalInMs;
        _spacecraft.Bind(_gameContext.Spacecraft);
        _healthUI.Bind(_gameContext.Spacecraft);
    }

    public void StartSpawning()
    {
        if (_isSpawning)
        {
            return;
        }

        _isSpawning = true;
        StartCoroutine(SpawnAsteroids());
    }

    private IEnumerator SpawnAsteroids()
    {
        for (int i = 0; i < _numberOfAsteroidsToSpawn; i++)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(_spawnIntervalInSeconds);
        }
    }

    private void SpawnAsteroid()
    {
        var asteroid = new Asteroid(1, 1f);
        var randomY = Random.Range(-5f, 5f);

        var asteroidGO = Instantiate(_asteroidPrefab);
        asteroidGO.transform.position = new Vector2(X_SPAWN_POSITION, randomY);
        asteroidGO.Bind(asteroid);
        asteroidGO.Launch();
    }
}
