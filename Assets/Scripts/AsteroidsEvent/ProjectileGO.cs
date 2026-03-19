using UnityEngine;

public class ProjectileGO : MonoBehaviour
{
    private bool _isShot;
    private float _speed;

    void Update()
    {
        if (!_isShot)
        {
            return;
        }

        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    internal void Shoot(float speed)
    {
        if (_isShot)
        {
            return;
        }

        _speed = speed;
        _isShot = true;

        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var asteroid = collision.gameObject.GetComponent<AsteroidGO>();

        if (asteroid == null)
        {
            return;
        }

        asteroid.Destroy();
        Destroy(gameObject);
    }
}
