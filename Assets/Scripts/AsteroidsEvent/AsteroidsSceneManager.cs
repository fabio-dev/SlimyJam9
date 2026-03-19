using DG.Tweening;
using System.Collections;
using UnityEngine;

public class AsteroidsSceneManager : MonoBehaviour
{
    [SerializeField] private AsteroidGO _asteroidPrefab;
    [SerializeField] private SpacecraftGO _spacecraft;
    [SerializeField] private SpacecraftHealthUI _healthUI;
    [SerializeField] private ProjectileRemainingUI _projectileUI;
    [SerializeField] private AsteroidsSpawner _asteroidsSpawner;
    [SerializeField] private SpriteRenderer _destinationArriving;

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        _spacecraft.Bind(GameData.Instance.Context.Spacecraft);
        _healthUI.Bind(GameData.Instance.Context.Spacecraft);
        _projectileUI.Bind(GameData.Instance.Context.Spacecraft);

        GameData.Instance.Context.Spacecraft.OnDamaged += PlayDamagedSound;
        _asteroidsSpawner.StartSpawning();
        _asteroidsSpawner.OnSpawnFinished += Arriving;
    }

    private void Arriving()
    {
        StartCoroutine(DestinationPlanetArrives());
    }

    private IEnumerator DestinationPlanetArrives()
    {
        yield return new WaitForSeconds(6);
        var move = _destinationArriving.transform.DOMoveX(5f, 5f);
        yield return new WaitForSeconds(5);
        move.Kill();
        _asteroidsSpawner.KillAllAsteroids();

        SceneNavigator.Instance.GoToExplorationMap();
    }

    private void PlayDamagedSound()
    {
        SoundEffectsPlayer.Instance.PlaySpacecraftDamaged();
    }
}
