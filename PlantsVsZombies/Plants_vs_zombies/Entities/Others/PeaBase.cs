using PvZ.Entities.Zombies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Others
{
    class PeaBase : EntityBase
    {
        public int ShootSpeed { get; set; } // Vitesse de tir.
        public int ShootDamage { get; set; }
        public bool isOutBound
        {
            get
            {
                return posX > Coord.GetXBordDroitEcran() ? true : false;
            }
        }
        public PeaBase(float posX, float posY, int ShootSpeed, int shootDamage)
        {
            this.posX = posX;
            this.posY = posY;
            this.ShootSpeed = ShootSpeed;
            this.ShootDamage = shootDamage;
            HP = 1;
            HitBox.Width = 20;
            HitBox.Height = 20;
        }

        public override void DoIt(double deltaTime)
        {
            CheckCollisions();
            // déplacement
            posX += (float)(ShootSpeed * deltaTime);

            // gestion de l'animation
            num_aff++;
        }
        public void CheckCollisions()
        {
            foreach (ZombieBase zombie in Global.LE.FindAll(x=>x is ZombieBase))
            {
                if (posX <= zombie.posX + zombie.HitBox.Width && posX + HitBox.Width >= zombie.posX)
                {
                    if (CorrectedY <= zombie.CorrectedY + zombie.HitBox.Height && CorrectedY >= zombie.CorrectedY)
                    {
                        this.Die();
                        if (this is SnowPea)
                        {
                            zombie.speedX = -1/4;
                        }
                        zombie.Hit(ShootDamage);
                        break;
                    }
                }
            }

        }
    }
}
