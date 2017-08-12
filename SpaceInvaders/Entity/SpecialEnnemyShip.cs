using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entity
{
    public class SpecialEnnemyShip : GameEntity
    {
        Direction direction;
        public SpecialEnnemyShip(Vecteur2D p, Double s, int hp, Bitmap spr, Direction d) 
            : base(p,s,hp, spr)
        {
            direction = d;
        }
        public override void Update(double deltaT)
        {
            if (CheckIfOffScreen())
                this.Die();
         
            if (direction == Direction.Right)
                Position.x += deltaT * Speed;
            else
                Position.x -= deltaT * Speed;
        }

    }
}
