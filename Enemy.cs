namespace EnemyNamespace
{
    internal class Enemy
    {
        public int X;
        public int Y;

        public Enemy(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }

        public void MoveForward()
        {
            Y++;
        }
    }
}