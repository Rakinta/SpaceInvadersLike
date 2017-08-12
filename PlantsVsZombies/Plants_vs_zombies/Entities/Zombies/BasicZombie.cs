using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Zombies
{
    class BasicZombie : ZombieBase
    {
        public BasicZombie(int row) : base(row, 100)
        {
            Sprites = new List<string> { "zombie_1", "zombie_2", "zombie_3", "zombie_2" };
        }
    }
}
