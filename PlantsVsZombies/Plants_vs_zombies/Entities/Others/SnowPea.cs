using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Others
{
    class SnowPea : PeaBase
    {
        public SnowPea(float posX, float posY, int ShootSpeed, int shootDamage) : base(posX, posY, ShootSpeed, shootDamage)
        {
            this.posX = posX;
            this.posY = posY;
            this.ShootSpeed = ShootSpeed;
            Sprites = new List<string> { "tir_gel"};
        }
    }
}
