using System;
using UnityEngine;

public class ExplorationSelectionUI : MonoBehaviour
{
    [SerializeField] private DestinationUI _destination1;
    [SerializeField] private DestinationUI _destination2;

    public event Action<DestinationUI> OnDestinationSelected;
    public event Action<DestinationUI> OnDestinationHovered;
    public event Action<DestinationUI> OnDestinationUnhovered;

    public void Bind(Destination destination1, Destination destination2)
    {
        _destination1.Bind(destination1);
        _destination2.Bind(destination2);

        RegisterEvents();
    }

    private void RegisterEvents()
    {
        _destination1.OnSelected += DestinationSelected;
        _destination1.OnHovered += DestinationHovered;
        _destination1.OnUnhovered += DestinationUnhovered;
        _destination2.OnSelected += DestinationSelected;
        _destination2.OnHovered += DestinationHovered;
        _destination2.OnUnhovered += DestinationUnhovered;
    }

    private void DestinationHovered(DestinationUI destination)
    {
        OnDestinationHovered?.Invoke(destination);
    }

    private void DestinationUnhovered(DestinationUI destination)
    {
        OnDestinationUnhovered?.Invoke(destination);
    }

    private void DestinationSelected(DestinationUI destination)
    {
        OnDestinationSelected?.Invoke(destination);
        UnregisterEvents();
    }

    private void UnregisterEvents()
    {
        _destination1.OnSelected -= DestinationSelected;
        _destination1.OnHovered -= DestinationHovered;
        _destination1.OnUnhovered -= DestinationHovered;
        _destination2.OnSelected -= DestinationSelected;
        _destination2.OnHovered -= DestinationHovered;
        _destination2.OnUnhovered -= DestinationHovered;
    }
}
