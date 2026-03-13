using UnityEngine;

public class SpacecraftGO : MonoBehaviour
{
    [SerializeField] private ShootController _shootController;

    private Spacecraft _spacecraft;

    public void Bind(Spacecraft spacecraft)
    {
        _spacecraft = spacecraft;
        _shootController.Bind(spacecraft);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var asteroid = collision.gameObject.GetComponent<AsteroidGO>();

        if (asteroid == null)
        {
            return;
        }

        _spacecraft.Damage(asteroid.Damage);
        asteroid.Destroy();
    }
}
