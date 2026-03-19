using UnityEngine;
using UnityEngine.UI;

public class SpacecraftHealthUI : MonoBehaviour
{
    [SerializeField] private Image _front;

    private Spacecraft _spacecraft;

    public void Bind(Spacecraft spacecraft)
    {
        _spacecraft = spacecraft;
        _spacecraft.OnDamaged += Refresh;
        Refresh();
    }

    private void Refresh()
    {
        if (_spacecraft == null)
        {
            return;
        }
        _front.fillAmount = (float)_spacecraft.Health / _spacecraft.MaxHealth;
    }
}
