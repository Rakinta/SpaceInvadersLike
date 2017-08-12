using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entity
{
    /// <summary>
    /// Classe représentant un vaisseau ennemie.
    /// </summary>
    /// <seealso cref="SpaceInvaders.Entity.ShipBaseEntity" />
    public class EnnemyShip : ShipBaseEntity
    {
        public EnnemyShip(Vecteur2D p, Double s, int hp, Bitmap spr, float shotspd) : base(p, s, hp, spr, shotspd)
        {
        }
        public void Shoot()
        {
            Bullet b = (new Bullet(Position + new Vecteur2D(9, 0), GameVariables.defaultShootSpeed, 1, Direction.Down, GameSprites.Bullet2));
            Bullets.Add(b);
            Game.game.AddGameEntity(b);
            GameSounds.ennemyShooting.Play();
        }
        public override void Update(double deltaT)
        {
            // Vérifie si le vaisseau est au même niveau que le joueur.
            if (Position.y + Sprite.Height >= Game.game.p1.Position.y)
            {
                Game.game.p1.Die();
            }

        }
        public bool Move(double deltaT)
        {
            if (EnnemyBlock.Direction == Direction.Right && Position.x < Game.game.gameSize.Width - 30)
            {
                Position.x += deltaT * Speed;
                return false;
            }
            // Gauche
            else if (EnnemyBlock.Direction == Direction.Left && Position.x > 0)
            {
                Position.x -= deltaT * Speed;
                return false;
            }

            /// Changement de direction
            return true;
        }
        public void MoveDown()
        {
            Position.y += 20;
        }
    }
}
