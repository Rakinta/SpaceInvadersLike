using PvZ.Entities.Others;
using PvZ.Entities.Zombies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Plants
{
    class DoublePeaShooter : PlantBase
    {
        public DoublePeaShooter(int row, int col) : base(row, col, 100)
        {
            HitBox.Width = 56;
            HitBox.Height = 55;
            ShootSpeed = 300;
            ShootDamage = 15;
            Sprites = new List<string> { "plante_pois_double" };
        }
        public void Shoot(float posX, float posY)
        {
            StandardPea sp = new StandardPea(posX + 48, posY + 51, ShootSpeed, ShootDamage);
            Global.LE.Add(sp);
        }

        public override void DoIt(double deltaTime)
        {
            base.DoIt(deltaTime);

            if (Global.LE.Find(x => Coord.YtoRow((int)x.CorrectedY) == Coord.YtoRow((int)this.CorrectedY) && x is ZombieBase) != null)
            {
                if (Global.Round % 20 == 0)
                {
                    Shoot(posX, posY);
                }
                if (Global.Round % 20 == 3)
                {
                    Shoot(posX, posY);
                }
            }

        }

    }
}
