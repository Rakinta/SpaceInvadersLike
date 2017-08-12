using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Zombies
{
    class DeadZombie : ZombieBase
    {
        public DeadZombie(int x, int y) : base(Coord.XtoColumn(x), 1)
        {
            Sprites = new List<string> { "zombie_dead" };
        }
    }
}
