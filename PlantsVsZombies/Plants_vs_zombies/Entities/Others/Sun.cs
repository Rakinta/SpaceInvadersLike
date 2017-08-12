using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvZ.Entities.Others
{
    class Sun : EntityBase
    {
        int startRound;
        protected int speedY;
        protected float endingY;

        public Sun(float posX, float posY, float endingY)
        {
            HitBox.Width = 55;
            HitBox.Height = 54;

            startRound = Global.Round;
            this.posX = posX;
            this.posY = posY;
            this.endingY = endingY;
            speedY = -3;
            HP = 9999;
            Sprites = new List<string> { "soleil" };
        }

        public override void DoIt(double deltaTime)
        {
            if (Global.Round == startRound + 500)
                this.Die();

            if (endingY <= posY)
            {
                posY += speedY;
            }

            base.DoIt(deltaTime);
        }
        public void GetSun()
        {
            Global.dollar += 50;
            this.Die();
        }
    }
}
