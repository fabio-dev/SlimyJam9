using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedImage : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _delayBetweenImages;

    private Sequence _animation;
    private int _currentSpriteIndex;

    private void Start()
    {
        _animation = DOTween.Sequence();
        _animation.SetLoops(-1);

        foreach (var sprite in _sprites)
        {
            _animation.AppendCallback(SetNextSprite);
            _animation.AppendInterval(_delayBetweenImages);
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

        _image.sprite = _sprites[_currentSpriteIndex];
    }

    private void OnDestroy()
    {
        _animation.Kill();
    }
}