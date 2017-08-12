using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvZ.Entities.Others;
using PvZ.Entities.Zombies;

namespace PvZ.Entities.Plants
{
    class SunFlower : PlantBase
    {
        int startRound;

        public SunFlower(int row, int col) : base(row, col, 100)
        {
            startRound = Global.Round;
            HitBox.Width = 56;
            HitBox.Height = 55;
            Sprites = new List<string> { "plante_soleil" };
        }

        public void Shoot(float posX, float posY)
        {
            StandardPea sp = new StandardPea(posX + 48, posY  + 51, ShootSpeed, ShootDamage);
            Global.LE.Add(sp);
        }
        public override void DoIt(double deltaTime)
        {
            base.DoIt(deltaTime);

            if (((Global.Round - (startRound - 1)) % 80) == 0)
            {
                Global.LE.Add(new Sun(posX, posY, posY));
            }
        }
    }
}
