using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Zombies
{
    class ConeheadZombie : ZombieBase
    {
        public ConeheadZombie(int row) : base(row, 250)
        {
            haveAccessory = true;
            AccessoryPath = "cone_1";
            Sprites = new List<string> { "zombie_1", "zombie_2", "zombie_3", "zombie_2" };

        }

    }
}
