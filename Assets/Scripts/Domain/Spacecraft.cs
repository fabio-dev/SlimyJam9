using System;

public class Spacecraft
{
    public Spacecraft(int health, int fuel)
    {
        Health = health;
        MaxHealth = health;
        Fuel = fuel;
        MaxFuel = fuel;
    }

    public event Action OnFuelConsumed;
    public event Action OnDamaged;

    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    public int Fuel { get; private set; }
    public int MaxFuel { get; private set; }

    public void Damage(int damage)
    {
        if (Health < 0)
        {
            return;
        }

        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }

        OnDamaged?.Invoke();
    }

    public void ConsumeFuel(int fuel)
    {
        if (Fuel < 0)
        {
            return;
        }

        Fuel -= fuel;

        if (Fuel < 0)
        {
            Fuel = 0;
        }

        OnFuelConsumed?.Invoke();
    }
}