using PvZ.Entities.Plants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Zombies
{
    class ZombieBase : EntityBase
    {
        public int previousSpeed;
        public int speedX; // vitesse de déplacement (pixel/tour)
        protected bool haveAccessory = false;
        protected string AccessoryPath;
        public ZombieBase(int row, int HP)
        {
            this.HP = HP;
            InitialHP = HP;

            posX = Coord.GetXBordDroitEcran();
            posY = Coord.RowToY(row);
            HitBox.Width = 50;
            HitBox.Height = 94;

            speedX = -1; // avance sur la gauche a une vitesse de 25 pix/sec
            previousSpeed = speedX;
        }

        public override void DoIt(double deltaTime)
        {
            // déplacement
            posX += speedX;
            
            // gestion de l'animation
            num_aff++;

            PlantBase foundPlant = Global.LE.FindAll(x => x is PlantBase).Find(plant => posX <= plant.posX + plant.HitBox.Width &&
            posX + HitBox.Width >= plant.posX && CorrectedY <= plant.CorrectedY + plant.HitBox.Height &&
            CorrectedY + HitBox.Height >= plant.CorrectedY) as PlantBase;

            if (foundPlant != null)
            {
                previousSpeed = speedX;
                speedX = 0;
                foundPlant.HP -= 2;
            }
            else
            {
                speedX = previousSpeed;
            }
        }
        public override void Affichage()
        {
            base.Affichage();

            if (haveAccessory)
                Global.Sprites.Get(AccessoryPath).DrawToScreen((posX + 7), (posY + 83));
        }

        internal void Hit(int shootDamage)
        {
            this.HP -= shootDamage;

            int cycle = (num_aff / 10) % Sprites.Count;

            Global.Sprites.Get(Sprites[cycle] + "_touche").DrawToScreen((posX + offsetX), (posY + offsetY));

        }
    }
}
