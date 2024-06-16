using System;
using System.Collections.Generic;
using System.Timers;

namespace EnemyNamespace
{
    internal class Enemy
    {
        public int X;
        public int Y;
        public float Speed = 0.5f;

        public Enemy(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }

        public void MoveForward()
        {
            Y += (int)Speed;
        }
    }
}