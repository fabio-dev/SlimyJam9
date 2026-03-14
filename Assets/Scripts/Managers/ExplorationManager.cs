using UnityEngine;

public class ExplorationManager : MonoBehaviour
{
    [SerializeField] private ExplorationSelectionUI _explorationSelectionUI;

    private void Start()
    {
        var destination1 = new Destination("Terre", DestinationType.SolarSystem);
        var destination2 = new Destination("Mars", DestinationType.DarkHole);

        _explorationSelectionUI.Bind(destination1, destination2);
    }
}