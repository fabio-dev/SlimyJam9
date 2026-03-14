using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DestinationUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _destinationImage;
    [SerializeField] private Image _selectionImage;
    [SerializeField] private Image _traitImage;
    [SerializeField] private Sprite _solarSystemSprite;
    [SerializeField] private Sprite _darkHoleSprite;
    [SerializeField] private Sprite _asteroidsSprite;
    [SerializeField] private Color _highlightTraitColor;

    private Color _defaultColor;

    private void Start()
    {
        _defaultColor = _traitImage.color;
    }

    public void Bind(Destination destination)
    {
        _destinationImage.sprite = GetSpriteFromDestinationType(destination.Type);
    }

    private Sprite GetSpriteFromDestinationType(DestinationType type)
    {
        switch (type)
        {
            case DestinationType.SolarSystem: return _solarSystemSprite;
            case DestinationType.DarkHole: return _darkHoleSprite;
            case DestinationType.Asteroids: return _asteroidsSprite;
        }

        return _solarSystemSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _traitImage.color = _highlightTraitColor;
        _selectionImage.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _traitImage.color = _defaultColor;
        _selectionImage.enabled = false;
    }
}
