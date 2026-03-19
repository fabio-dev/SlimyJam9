using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleMoveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _cooldownImage;
    [SerializeField] private BattleMove _move;

    public Action<BattleMoveButton> OnClicked;
    private bool _onCooldown;
    private Vector2 _initialPosition;

    public BattleMove Move => _move;

    public bool IsOnCooldown => _onCooldown;

    private void Start()
    {
        _initialPosition = transform.localPosition;
    }

    public void SetCooldown(float cooldownInSeconds)
    {
        if (_onCooldown)
        {
            return;
        }

        _onCooldown = true;
        _cooldownImage.fillAmount = 1f;
        _cooldownImage.DOFillAmount(0f, cooldownInSeconds)
                      .SetEase(Ease.Linear)
                      .OnComplete(() => _onCooldown = false);
    }

    public void OnClick()
    {
        OnClicked?.Invoke(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(_initialPosition.x, _initialPosition.y + 5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localPosition = _initialPosition;
    }
}
