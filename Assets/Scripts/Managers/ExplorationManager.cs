using UnityEngine;

public class ExplorationManager : MonoBehaviour
{
    [SerializeField] private ExplorationSelectionUI _explorationSelectionUI;
    [SerializeField] private ExplorationInfoViewUI _infoUi;

    private void Start()
    {
        var destination1 = new Destination("Chemin douteux", "Ce passage est peuplé d'astéroïdes. Prendrez-vous le risque d'y passer ?", DestinationType.Asteroids);
        var destination2 = new Destination("Trou sombre", "Détruit tous les monstres sur le terrain. Ah non, on n'est pas dans Yu-Gi-Oh !", DestinationType.DarkHole);

        _explorationSelectionUI.Bind(destination1, destination2);
        _explorationSelectionUI.OnDestinationSelected += DestinationSelected;
        _explorationSelectionUI.OnDestinationHovered += DestinationHovered;
        _explorationSelectionUI.OnDestinationUnhovered += DestinationUnhovered;
    }

    private void DestinationHovered(DestinationUI destination)
    {
        _infoUi.gameObject.SetActive(true);
        _infoUi.Bind(destination.Destination);
    }

    private void DestinationUnhovered(DestinationUI destination)
    {
        _infoUi.gameObject.SetActive(false);
    }

    private void DestinationSelected(DestinationUI destination)
    {
        if (destination.DestinationType == DestinationType.Asteroids)
        {
            SceneNavigator.Instance.GoToAsteroidsEvent();
        }

        if (destination.DestinationType == DestinationType.DarkHole)
        {
            SceneNavigator.Instance.GoToBattleEvent();
        }
    }
}