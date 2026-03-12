using UnityEngine;

public class SpacecraftGO : MonoBehaviour
{
    private Spacecraft _spacecraft;

    public void Bind(Spacecraft spacecraft)
    {
        _spacecraft = spacecraft;
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
