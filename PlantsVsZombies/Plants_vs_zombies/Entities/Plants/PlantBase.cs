using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Plants
{
    class PlantBase : EntityBase
    {
        protected int SunCost;        // Cout en soleil.
        protected int ShootSpeed;   // Vitesse de tir.
        protected int ShootDamage;    // Dégats par seconde.
        public PlantBase(int row, int col, int HP)
        {
            this.HP = HP;
            InitialHP = HP;

            posX = Coord.ColToX(col);
            posY = Coord.RowToY(row);

            offsetX = 15;
            offsetY = 25;
        }
    }
}
