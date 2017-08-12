using PvZ.Entities.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Plants
{
    interface IShootablePlant
    {
        float shootingSpeed { get; set; }

        void Shoot(PeaBase p);
    }
}
