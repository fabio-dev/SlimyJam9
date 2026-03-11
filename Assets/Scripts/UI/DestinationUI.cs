using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DestinationUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _destinationImage;
    [SerializeField] private Image _traitImage;
    [SerializeField] private Sprite _bluePlanetSprite;
    [SerializeField] private Sprite _redPlanetSprite;
    [SerializeField] private Sprite _greenPlanetSprite;
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
            case DestinationType.Blue: return _bluePlanetSprite;
            case DestinationType.Red: return _redPlanetSprite;
            case DestinationType.Green: return _greenPlanetSprite;
        }

        return _bluePlanetSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _traitImage.color = _highlightTraitColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _traitImage.color = _defaultColor;
    }
}
