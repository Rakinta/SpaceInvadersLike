using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Zombies
{
    class BucketheadZombie : ZombieBase
    {
        public BucketheadZombie(int row) : base(row, 500)
        {
            haveAccessory = true;
            AccessoryPath = "sot_1";
            Sprites = new List<string> { "zombie_1", "zombie_2", "zombie_3", "zombie_2" };
        }
    }
}
