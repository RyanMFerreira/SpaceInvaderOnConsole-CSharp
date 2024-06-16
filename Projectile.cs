using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaderOnConsole_CSharp
{
    internal class Projectile
    {
        public int X;
        public int Y;
        private int Speed;

        public Projectile(int startX, int startY, int Speed)
        {
            X = startX;
            Y = startY;
        }

        public void UpdatePosition()
        {
            Y -= Speed;
        }
    }
}