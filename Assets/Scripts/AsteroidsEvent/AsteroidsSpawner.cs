using System.Collections;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] private AsteroidGO _asteroidPrefab;
    [SerializeField] private float _xSpawnPosition = 10f;
    [SerializeField] private float _yRangeSpawnPosition = 5f;
    [SerializeField] private int _numberOfAsteroidsToSpawn = 12;
    [SerializeField] private float _minSpawnIntervalInSeconds = .2f;
    [SerializeField] private float _maxSpawnIntervalInSeconds = 1.5f;
    [SerializeField] private float _minAsteroidSpeed = 1f;
    [SerializeField] private float _maxAsteroidSpeed = 2f;

    private bool _isSpawning = false;

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

            var msToNextSpawn = Random.Range(_minSpawnIntervalInSeconds, _maxSpawnIntervalInSeconds);
            yield return new WaitForSeconds(msToNextSpawn);
        }
    }

    private void SpawnAsteroid()
    {
        var randomSpeed = Random.Range(_minAsteroidSpeed, _maxAsteroidSpeed);
        var asteroid = new Asteroid(1, randomSpeed);

        var randomY = Random.Range(-_yRangeSpawnPosition, _yRangeSpawnPosition);
        var asteroidGO = Instantiate(_asteroidPrefab);
        asteroidGO.transform.position = new Vector2(_xSpawnPosition, randomY);
        asteroidGO.Bind(asteroid);
        asteroidGO.Launch();
    }
}
