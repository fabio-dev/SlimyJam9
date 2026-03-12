using UnityEngine;

public class AsteroidGO : MonoBehaviour
{
    private Asteroid _asteroid;
    private bool _isLaunched;

    public int Damage => _asteroid.Damage;

    void Update()
    {
        if (!_isLaunched)
        {
            return;
        }

        transform.Translate(Vector2.left * _asteroid.Speed * Time.deltaTime);
    }

    public void Bind(Asteroid asteroid)
    {
        _asteroid = asteroid;
    }

    public void Launch()
    {
        _isLaunched = true;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
