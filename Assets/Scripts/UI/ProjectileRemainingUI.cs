using TMPro;
using UnityEngine;

public class ProjectileRemainingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Spacecraft _spacecraft;

    public void Bind(Spacecraft spacecraft)
    {
        _spacecraft = spacecraft;
        _spacecraft.OnAmmoConsumed += RefreshText;
    }

    private void RefreshText()
    {
        _text.SetText(_spacecraft.Ammo.ToString());
    }
}
