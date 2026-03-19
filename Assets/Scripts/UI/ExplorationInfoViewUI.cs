using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExplorationInfoViewUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Image _image;

    public void Bind(Destination destination)
    {
        _image.sprite = ResourcesHelper.GetExploSprite(destination.Type);
        _title.SetText(destination.Name);
        _description.SetText(destination.Description);
    }
}
