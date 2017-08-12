using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvZ.Entities.Others;

namespace PvZ.Entities.Plants
{
    class Nut : PlantBase
    {
        public Nut(int row, int col) : base(row, col, 2000)
        {
            HitBox.Width = 46;
            HitBox.Height = 54;
            Sprites = new List<string> { "noix_1", "noix_2", "noix_3" };
        }

        public override void Affichage()
        {
            if(HP <=  668)
            {
                Global.Sprites.Get(Sprites[2]).DrawToScreen((posX + offsetX), (posY + offsetY));
            }
            else if(HP <= 1333)
            {
                Global.Sprites.Get(Sprites[1]).DrawToScreen((posX + offsetX), (posY + offsetY));
            }
            else
            {
                Global.Sprites.Get(Sprites[0]).DrawToScreen((posX + offsetX), (posY + offsetY));
            }
        }
    }
}
