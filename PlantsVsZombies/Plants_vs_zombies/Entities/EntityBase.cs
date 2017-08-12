using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PvZ.Entities
{
    abstract class EntityBase
    {
        public int HP; // Points de vie.
        public int InitialHP;
        public float posX, posY, offsetX, offsetY;     // position
        public Size HitBox;      // HitBox
        protected int num_aff;        // Gère l'animation.
        protected List<String> Sprites; // Liste des sprites.
        public float CorrectedY
        {
            get { return (Global.Height - posY - HitBox.Height) - offsetY; }
        }

        public virtual void DoIt(double deltaTime)
        {
            num_aff++;
        }

        public virtual void Affichage()
        {
            // change de sprite tous les 20 affichages
            int cycle = (num_aff / 10) % Sprites.Count;

            Global.Sprites.Get(Sprites[cycle]).DrawToScreen((posX + offsetX), (posY + offsetY));


            if (Global.DrawHitBox) 
                Global.Ecran.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), 
                    posX + offsetX,
                    CorrectedY,
                    HitBox.Width, HitBox.Height);

        }

        public void Die() { HP = 0; }

        //public void Deplacement()
        //{

        //}
    }
}
