using UnityEngine;
using UnityEngine.InputSystem;

public class ShootController : MonoBehaviour
{
    [SerializeField] private ProjectileGO _projectilePrefab;

    private float _nextShootTime;
    private Spacecraft _spacecraft;

    public void Bind(Spacecraft spacecraft)
    {
        _spacecraft = spacecraft;
    }

    void Update()
    {
        if (_spacecraft == null)
        {
            return;
        }

        if (Mouse.current.leftButton.isPressed && Time.time > _nextShootTime)
        {
            Shoot();
            _nextShootTime = Time.time + _spacecraft.FireRate;
        }
    }

    public void Shoot()
    {
        if (_spacecraft.Ammo <= 0)
        {
            return;
        }

        var projectile = Instantiate(_projectilePrefab);
        projectile.transform.position = transform.position;
        projectile.Shoot(_spacecraft.ProjectileSpeed);

        _spacecraft.ConsumeAmmo();
    }
}