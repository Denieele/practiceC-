namespace Lb3;
class Program
{
    static void Main()
    {
        Projectile bullet = new Bullet(30);

        IDamageable enemy = new Enemy();
        IDamageable wall = new BreakableWall();

        bullet.HitTarget(enemy);
        bullet.HitTarget(wall);
    }
}