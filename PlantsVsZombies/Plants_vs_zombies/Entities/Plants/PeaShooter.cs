using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvZ.Entities.Others;
using PvZ.Entities.Zombies;

namespace PvZ.Entities.Plants
{
    class PeaShooter : PlantBase
    {
        public PeaShooter(int row, int col) : base(row, col, 100)
        {
            HitBox.Width = 56;
            HitBox.Height = 55;
            SunCost = 100;
            ShootSpeed = 300;
            ShootDamage = 15;
            Sprites = new List<string> { "plante_pois" };
        }

        public void Shoot(float posX, float posY)
        {
            StandardPea sp = new StandardPea(posX + 48, posY  + 51, ShootSpeed, ShootDamage);
            Global.LE.Add(sp);
        }
        public override void DoIt(double deltaTime)
        {
            base.DoIt(deltaTime);
            if(Global.LE.Find(x => Coord.YtoRow((int)x.CorrectedY) == Coord.YtoRow((int)this.CorrectedY) && x is ZombieBase) != null)
            {
                if (num_aff % 20 == 0)
                {
                    Shoot(posX, posY);
                }
            }
        }
    }
}
