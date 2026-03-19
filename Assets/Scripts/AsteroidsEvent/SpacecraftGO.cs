using DG.Tweening;
using UnityEngine;

public class SpacecraftGO : MonoBehaviour
{
    [SerializeField] private ShootController _shootController;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _sprites;

    private Spacecraft _spacecraft;
    private Sequence _animation;
    private int _currentSpriteIndex;

    public void Bind(Spacecraft spacecraft)
    {
        _spacecraft = spacecraft;
        _shootController.Bind(spacecraft);

        _animation = DOTween.Sequence();
        _animation.SetLoops(-1);

        foreach (var sprite in _sprites)
        {
            _animation.AppendCallback(SetNextSprite);
            _animation.AppendInterval(.1f);
        }

        _animation.Play();
    }

    private void SetNextSprite()
    {
        _currentSpriteIndex++;

        if (_currentSpriteIndex >= _sprites.Length)
        {
            _currentSpriteIndex = 0;
        }

        _spriteRenderer.sprite = _sprites[_currentSpriteIndex];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var asteroid = collision.gameObject.GetComponent<AsteroidGO>();

        if (asteroid == null)
        {
            return;
        }

        _spacecraft.Damage(asteroid.Damage);
        asteroid.Destroy();
    }

    private void OnDestroy()
    {
        _animation.Kill();
    }
}
