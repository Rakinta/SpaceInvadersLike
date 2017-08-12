using PvZ.Entities;
using PvZ.Entities.Others;
using PvZ.Entities.Plants;
using PvZ.Entities.Zombies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PvZ
{
    class MainLoop
    {
        public static void DoIt(double deltaTime)
        {
            Global.LE.RemoveAll(x => x.HP <= 0);

            for (int i = 0; i < Global.LE.ToArray().Length; i++)
            {
                Global.LE[i].DoIt(deltaTime);
            }
        }

        public static void Affichage()
        {
            for (int i = 0; i < Global.LE.ToArray().Length; i++)
            {
                Global.LE[i].Affichage();
                if (Global.DisplayHP)
                {
                    if ((Global.LE[i] is ZombieBase) || (Global.LE[i] is PlantBase))
                    {
                        Global.Ecran.FillRectangle(Brushes.Black, Global.LE[i].posX - 8, Global.LE[i].CorrectedY - 20, 100, 10);
                        Global.Ecran.FillRectangle(Brushes.Blue, Global.LE[i].posX - 8, Global.LE[i].CorrectedY - 20, (((float)Global.LE[i].HP / (float)Global.LE[i].InitialHP) * 100), 10);

                    }
                }
            }

        }
    }
}
