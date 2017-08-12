using PvZ.Entities.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Plants
{
    class SnowPeaShooter : PlantBase
    {
        public SnowPeaShooter(int row, int col) : base(row, col, 100)
        {
            ShootSpeed = 300;
            ShootDamage = 5;

            Sprites = new List<string> { "plante_gel" };
        }
        public void Shoot(float posX, float posY)
        {
            SnowPea sp = new SnowPea(posX + 42, posY + 62, ShootSpeed, ShootDamage);
            Global.LE.Add(sp);
        }
        public override void DoIt(double deltaTime)
        {
            base.DoIt(deltaTime);
            if (num_aff % 20 == 0)
            {
                Shoot(posX, posY);
            }
        }
    }
}
