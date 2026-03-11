using UnityEngine;

public class ExplorationSelectionUI : MonoBehaviour
{
    [SerializeField] private DestinationUI _destination1;
    [SerializeField] private DestinationUI _destination2;

    public void Bind(Destination destination1, Destination destination2)
    {
        _destination1.Bind(destination1);
        _destination2.Bind(destination2);
    }
}
