
using System;

interface IDamageable
{
    void TakeDamage(int amount);
}

abstract class Projectile
{
    protected int damage;

    public Projectile(int damage)
    {
        this.damage = damage;
    }

    public abstract void HitTarget(IDamageable target);
}

class Bullet : Projectile
{
    public Bullet(int damage) : base(damage) { }

    public override void HitTarget(IDamageable target)
    {
        Console.WriteLine("Куля влучила в ціль!");
        target.TakeDamage(damage);
    }
}

class Enemy : IDamageable
{
    private int health;

    public Enemy(int health)
    {
        this.health = health;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Console.WriteLine($"Ворог отримав {amount} шкоди. Залишилось здоров'я: {health}");

        if (health <= 0)
            Console.WriteLine("Ворог знищений!");
    }
}

class BreakableWall : IDamageable
{
    private int durability;

    public BreakableWall(int durability)
    {
        this.durability = durability;
    }

    public void TakeDamage(int amount)
    {
        durability -= amount;
        Console.WriteLine($"Стіна отримала {amount} шкоди. Залишилось міцності: {durability}");

        if (durability <= 0)
            Console.WriteLine("Стіна зруйнована!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bullet bullet = new Bullet(50);

        Enemy enemy = new Enemy(100);
        BreakableWall wall = new BreakableWall(60);

        bullet.HitTarget(enemy);
        bullet.HitTarget(wall);
    }
}
