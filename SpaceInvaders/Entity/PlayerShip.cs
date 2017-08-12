using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Interfaces;
using System.Windows.Forms;
using System.Drawing;
using SpaceInvaders.Properties;

namespace SpaceInvaders.Entity
{

    /// <summary>
    /// Classe représentant le vaisseau du joueur.
    /// </summary>
    /// <seealso cref="SpaceInvaders.Entity.ShipBaseEntity" />
    public class PlayerShip : ShipBaseEntity
    {


        #region Constructors    
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerShip" /> class.
        /// </summary>
        /// <param name="position">Position</param>
        /// <param name="speed">Vitesse</param>
        /// <param name="hp">Points de vie</param>
        /// <param name="sprite">Sprite</param>
        /// <param name="shootSpeed">Vitesse de tir des missiles</param>
        public PlayerShip(Vecteur2D p, Double s, int hp, Bitmap sprite, float shotspd) 
            : base(p, s, hp, sprite, shotspd) 
        {

        }
        #endregion

        public override void Update(double deltaT, HashSet<Keys> keys)
        {
            InputControls(deltaT, keys);
        }
        public void InputControls(double deltaT, HashSet<Keys> keyPressed)
        {
            if (keyPressed.Contains(Keys.Left))
            {
                PlayerMove(-1, deltaT);
            }
            else if (keyPressed.Contains(Keys.Right))
            {
                PlayerMove(1, deltaT);
            }
            if (keyPressed.Contains(Keys.B))
            {
                this.multipleBullet = true;
            }
            if (keyPressed.Contains(Keys.Space) && (Bullets.Count(x=>x.IsAlive) <= 0 || (multipleBullet && Bullets.Count(x=>x.IsAlive) < 3)))
            {
                Shoot();
                keyPressed.Remove(Keys.Space);
            }
        }

        public void PlayerMove(int direction, double deltaT)
        {
            // Droite
            if (direction > 0 && Position.x < Game.game.gameSize.Width - Sprite.Size.Width)
            {
                Position.x += deltaT * Speed;
            }
            // Gauche
            else if(Position.x > 0)
            {
                Position.x -= deltaT * Speed;
            }
        }
        /// <summary>
        /// Lance un missile.
        /// </summary>
        public void Shoot()
        {
            //Console.WriteLine("Tir du joueur");
            Bullet b = new Bullet(new Vecteur2D(this.Position.x + 9, Position.y), ShootingSpeed, 7, Direction.Up, GameSprites.Bullet1);
            Bullets.Add(b);
            Game.game.AddGameEntity(b);
            GameSounds.playerShooting.Play();
        }

    }
}
