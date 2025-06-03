namespace Lb3;

public class BreakableWall : IDamageable
{
    private int durability = 50;

    public void TakeDamage(int amount)
    {
        durability -= amount;
        Console.WriteLine($"Wall received {amount} damage. Durability is now {durability}.");
        if (durability <= 0)
            Console.WriteLine("Wall has been broken!");
    }
}