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
    public class Player : GameEntity
    {
        /// <summary>
        /// State of the keyboard
        /// </summary>

        private Bullet b;

        #region Constructors

        public Player(Vecteur2D p, Double s, int hp) : base(p, s, hp) {
            sprite = GameSprites.PlayerSprite;
        }
        #endregion

        public override void Update(double deltaT, HashSet<Keys> keys)
        {
            // Keyboard events
            InputControls(deltaT, keys);
        }
        public void InputControls(double deltaT, HashSet<Keys> keyPressed)
        {
            if (IsAlive)
            {
                if (keyPressed.Contains(Keys.Left))
                {
                    PlayerMove(-1, deltaT);
                }
                else if (keyPressed.Contains(Keys.Right))
                {
                    PlayerMove(1, deltaT);
                }
                if (keyPressed.Contains(Keys.Space))
                {
                    Shoot();
                }
            }
            if (keyPressed.Contains(Keys.R))
            {
                Console.WriteLine("Reseting player.");
            }
            if (keyPressed.Contains(Keys.I))
            {
                Console.WriteLine(String.Format("Taille fenetre :\n X:{0} Y:{1}", Game.game.gameSize.Width, Game.game.gameSize.Height));
            }
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            // Infos debug
            g.DrawString(String.Format("Degug Infos:\nPlayer:\n X:{0} Y:{1}", position.x, position.y),
                GameVariables.defaultFont, GameVariables.blackBrush, 10, 10);

            // Infos vie
            g.DrawString(String.Format("Vie :{0}", this.hp), GameVariables.defaultFont, GameVariables.blackBrush,
                 60, 558);

            if (!IsAlive)
            {
                g.DrawString("Appuyez sur espace !", GameVariables.defaultFont, GameVariables.blackBrush, 30, 30);
            }
        }

        public void PlayerMove(int direction, double deltaT)
        {
            if (direction > 0)
            {
                if (position.x < Game.game.gameSize.Width - sprite.Size.Width)
                    position.x += deltaT * speed;
            }
            else
            {
                if (position.x > 0)
                    position.x -= deltaT * speed;
            }
        }

        public void Shoot()
        {
            if (!b.IsAlive)
            {
                Console.WriteLine("TIR");
                b = new Bullet(new Vecteur2D(this.position.x + 9, position.y), 250, 1);
                Game.game.AddGameEntity(b);
            }
        }
    }
}
