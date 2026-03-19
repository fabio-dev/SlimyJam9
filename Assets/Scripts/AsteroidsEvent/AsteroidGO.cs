using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidGO : MonoBehaviour
{
    [SerializeField] private float _minRotationDuration = .5f;
    [SerializeField] private float _maxRotationDuration = 1.5f;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Asteroid _asteroid;
    private bool _isLaunched;
    private Tween _rotationTween;

    public int Damage => _asteroid.Damage;

    void Update()
    {
        if (!_isLaunched)
        {
            return;
        }

        transform.Translate(Vector2.left * _asteroid.Speed * Time.deltaTime);
    }

    public void Bind(Asteroid asteroid)
    {
        _asteroid = asteroid;
    }

    public void Launch()
    {
        _isLaunched = true;

        if (_rotationTween != null)
        {
            _rotationTween.Kill();
        }

        var randomDuration = Random.Range(_minRotationDuration, _maxRotationDuration);
        _rotationTween = _spriteRenderer.transform
             .DORotate(new Vector3(0, 0, 360), randomDuration, RotateMode.FastBeyond360)
             .SetEase(Ease.Linear)
             .SetLoops(-1, LoopType.Incremental);
    }

    public void Destroy()
    {
        if (!gameObject.IsDestroyed())
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (_rotationTween != null)
        {
            _rotationTween.Kill();
        }
    }
}
