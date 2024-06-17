namespace EnemyNamespace
{
    internal class Enemy
    {
        public int X;
        public int Y;

        public Enemy(int Start_X, int Start_Y)
        {
            X = Start_X;
            Y = Start_Y;
        }

        public void MoveForward()
        {
            Y++;
        }
    }
}