namespace Lb3;

public class Bullet : Projectile
{
    public Bullet(int damage) : base(damage) {}

    public override void HitTarget(IDamageable target)
    {
        target.TakeDamage(damage);
    }
}