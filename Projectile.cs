namespace ProjectileNamespace
{
    internal class Projectile
    {
        public int X;
        public int Y;

        public Projectile(int StartX, int startY)
        {
            X = StartX;
            Y = startY;
        }

        public void UpdatePosition()
        {
            Y --;
        }
    }
}