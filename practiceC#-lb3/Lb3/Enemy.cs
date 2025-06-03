namespace Lb3;

public class Enemy : IDamageable
{
    private int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Console.WriteLine($"Enemy received {amount} damage. Health is now {health}.");
        if (health <= 0)
            Console.WriteLine("Enemy destroyed!");
    }
}
