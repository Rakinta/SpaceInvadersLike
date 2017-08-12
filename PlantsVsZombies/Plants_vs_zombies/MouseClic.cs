using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PvZ.Entities;
using PvZ.Entities.Zombies;
using PvZ.Entities.Plants;
using System.Dynamic;
using PvZ.Entities.Others;

namespace PvZ
{
    class MouseClic
    {


        ///////////////////////////////////////////////////////////////////////////////////////////

        // fonction d'entrée du clic SOURIS
        // les coordonnées sont cartésiennes

        static public void Event(int x, int y)
        {
            int rangee = Coord.YtoRow(y);
            int col = Coord.XtoColumn(x);

            Sun selectedSun = Global.LE.FindAll(s => s is Sun).Find(s => x <= s.posX + s.HitBox.Width && x >= s.posX  
                                                  && y <= s.posY + s.HitBox.Height && y >= s.posY) as Sun;

            if (selectedSun != null)
            {
                selectedSun.GetSun();
            }
            else if (Global.Button == Global.Creature.Zombie)
            {
                if (rangee >= 0)
                    Global.LE.Add(new ConeheadZombie(rangee));
            }
            else
            {
                if (rangee >= 0 && col >= 0 && rangee < 5 && col < 9)
                {
                    if (Global.SunCosts[Global.Button] <= Global.dollar && 
                        Global.LE.Find(p => Coord.YtoRow((int)p.posY) == rangee && Coord.XtoColumn((int)p.posX) == col) == null)
                    {
                        if (Global.Button == Global.Creature.PistoPois)
                        {
                            Global.LE.Add(new PeaShooter(rangee, col));
                        }
                        else if (Global.Button == Global.Creature.DoublePistoPois)
                        {
                            Global.LE.Add(new DoublePeaShooter(rangee, col));
                        }
                        else if(Global.Button == Global.Creature.PistoGel)
                        {
                            Global.LE.Add(new SnowPeaShooter(rangee, col));
                        }
                        else if (Global.Button == Global.Creature.Noix)
                        {
                            Global.LE.Add(new Nut(rangee, col));
                        }
                        else if (Global.Button == Global.Creature.Tournesol)
                        {
                            Global.LE.Add(new SunFlower(rangee, col));
                        }
                        Global.dollar -= Global.SunCosts[Global.Button];
                    }
                }

            }
        }
    }
}
