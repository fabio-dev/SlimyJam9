using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
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
    public event Action OnSpawnFinished;

    private List<AsteroidGO> _asteroids = new();

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

            var msToNextSpawn = UnityEngine.Random.Range(_minSpawnIntervalInSeconds, _maxSpawnIntervalInSeconds);
            yield return new WaitForSeconds(msToNextSpawn);
        }

        OnSpawnFinished?.Invoke();
    }

    private void SpawnAsteroid()
    {
        var randomSpeed = UnityEngine.Random.Range(_minAsteroidSpeed, _maxAsteroidSpeed);
        var asteroid = new Asteroid(1, randomSpeed);

        var randomY = UnityEngine.Random.Range(-_yRangeSpawnPosition, _yRangeSpawnPosition);
        var asteroidGO = Instantiate(_asteroidPrefab);
        asteroidGO.transform.position = new Vector2(_xSpawnPosition, randomY);
        asteroidGO.Bind(asteroid);
        asteroidGO.Launch();

        _asteroids.Add(asteroidGO);
    }

    internal void KillAllAsteroids()
    {
        foreach (var asteroidGO in _asteroids)
        {
            asteroidGO.Destroy();
        }
    }
}
