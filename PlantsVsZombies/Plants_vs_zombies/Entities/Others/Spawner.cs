using PvZ.Entities.Zombies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Others
{
    class Spawner : EntityBase
    {
        public Spawner()
        {
            HP = 9999;
        }
        public override void DoIt(double deltaTime)
        {
            if(Global.Round % 80 == 0)
            {
                Global.LE.Add(new Sun(Global.Random(200, 1000), Coord.GetYBordHautEcran(), Global.Random(100, 800)));
            }
            if (Global.Round % 40 == 0)
            {
                switch (Global.Random(0, 2))
                {
                    case 0:
                        Global.LE.Add(new BasicZombie(Global.Random(0, 4)));
                        break;
                    case 1:
                        Global.LE.Add(new ConeheadZombie(Global.Random(0, 4)));
                        break;
                    case 2:
                        Global.LE.Add(new BucketheadZombie(Global.Random(0, 4)));
                        break;
                }
            }
        }
        public override void Affichage() { }

    }
}
