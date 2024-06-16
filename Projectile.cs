namespace ProjectileNamespace
{
    internal class Projectile
    {
        public int X;
        public int Y;

        public Projectile(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }

        public void UpdatePosition()
        {
            Y -= 1;
        }
    }
}
