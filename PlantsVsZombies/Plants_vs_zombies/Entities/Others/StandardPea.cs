using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Others
{
    class StandardPea : PeaBase
    {
        public StandardPea(float posX, float posY, int ShootSpeed, int shootDamage): base(posX, posY, ShootSpeed, shootDamage)
        {

            Sprites = new List<String> { "tir_pois"};
        }
    }
}
