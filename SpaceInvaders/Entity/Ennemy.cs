using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entity
{
    public class Ennemy : GameEntity
    {

        public Ennemy(Vecteur2D p, Double s, int hp, Bitmap spr) : base(p, s, hp)
        {
            position = p;
            speed = s;
            this.hp = hp;
            this.sprite = spr;
        }
        public void Shoot()
        {
            if (b == null)
            {
                Console.WriteLine("TIR");
                b = new Bullet(new Vecteur2D(this.position.x + 9, position.y), 250, 1);
                Game.game.AddGameEntity(b);

            }
            else if (!b.IsAlive)
            {
                Console.WriteLine("TIR");
                b = new Bullet(new Vecteur2D(this.position.x + 9, position.y), 250, 1);
                Game.game.AddGameEntity(b);
            }

        }
    }
}
