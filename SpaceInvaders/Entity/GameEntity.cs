using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SpaceInvaders.Interfaces;
using System.Windows.Forms;

namespace SpaceInvaders.Entity
{
    /// <summary>
    /// Classe représentant une GameEntity.
    /// </summary>
    /// <seealso cref="SpaceInvaders.Interfaces.IRenderable" />
    /// <seealso cref="SpaceInvaders.Interfaces.IMoveable" />
    public abstract class GameEntity : IRenderable, IMoveable
    {
        #region Fields and Parameters
        public Vecteur2D Position { get; set; }
        public double Speed { get; set; }

        /// <summary>
        /// L'entité est-t-elle en vie ?
        /// </summary>
        public bool IsAlive
        {
            get
            {
                if (hp <= 0)
                {
                    hp = 0;
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the sprite.
        /// </summary>
        /// <value>
        /// Sprite de l'entité.
        /// </value>
        public Bitmap Sprite { get; set; }

        /// <summary>
        /// Points de vie
        /// </summary>
        public int hp;
        #endregion

        #region Constructors    
        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="GameEntity"/>.
        /// </summary>
        /// <param name="position">Position</param>
        /// <param name="speed">Vitesse</param>
        /// <param name="hp">Points de vie</param>
        /// <param name="sprite">Sprite</param>
        public GameEntity(Vecteur2D position, double speed, int hp, Bitmap sprite)
        {
            this.Position = position;
            this.Speed = speed;
            this.hp = hp;
            this.Sprite = new Bitmap(sprite);
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="GameEntity"/>.
        /// </summary>
        /// <param name="position">The position.</param>
        public GameEntity(Vecteur2D position)
        {
            this.Position = new Vecteur2D(position.x, position.y);
            this.Speed = 50;
            this.hp = 1;
            this.Sprite = GameSprites.Ship9;
        }
        public GameEntity()
        {
            this.Position = new Vecteur2D(150, 150);
            this.Speed = 50;
            this.hp = 1;
            this.Sprite = GameSprites.Ship9;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Tue l'entité
        /// </summary>
        public void Die()
        {
            this.hp = 0;
        }
        /// <summary>
        /// Draw the entity
        /// </summary>
        /// <param name="g">Graphics to draw in</param>
        public virtual void Draw(Graphics g)
        {
            if (IsAlive && this.Sprite != null)
            {
                g.DrawImage(Sprite, (float)this.Position.x, (float)this.Position.y);
            }
            if (GameVariables.DisplayHitbox)
            {
                g.FillRectangle(new SolidBrush(Color.Red), (float)Position.x, (float)Position.y, Sprite.Width, Sprite.Height);
            }

        }

        /// <summary>
        /// Vérifie si l'entité est hors de l'écran.
        /// </summary>
        /// <returns></returns>
        public bool CheckIfOffScreen()
        {
            if ((this.Position.y > Game.game.gameSize.Height) || (Position.y < 0))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Vérifie si il y a collision entre l'entité actuel et une entité définis.
        /// </summary>
        /// <param name="g">GameEntity</param>
        /// <param name="">Faire une vérification pixel par pixel.</param>
        /// <returns>True si collision avéré False si aucune collision.</returns>
        public virtual bool CheckCollision(GameEntity g, bool isBunker = false)
        {
            if (g.Position.x > Position.x + Sprite.Width || g.Position.y > Position.y + Sprite.Height || Position.x > g.Position.x + g.Sprite.Width || Position.y > g.Position.y + g.Sprite.Height )
            {
                return false;
            }

            for (int j = 0; j < Sprite.Height; j++)
            {
                for (int i = 0; i < Sprite.Width; i++)
                {
                    Color c = new Color();
                    c = Sprite.GetPixel(i, j);

                    if (c.R == 0 && c.G == 0 && c.B == 0)
                    {
                        Vecteur2D pixelPos = new Vecteur2D(this.Position.x + i, this.Position.y + j);

                        //Console.WriteLine("x: {0} y: {1}", pixelPos.x, pixelPos.y);

                        int otherPixelX = (int)pixelPos.x - (int)g.Position.x;
                        int otherPixelY = (int)pixelPos.y - (int)g.Position.y;

                        //Console.WriteLine("x: {0} y: {1}", otherPixelX, otherPixelY);

                        //Console.WriteLine("Size {0};{1}", g.Sprite.Width, g.Sprite.Height);

                        Color targetColor = Color.Red;
                        if ((otherPixelX >= 0 && otherPixelX < g.Sprite.Width) && otherPixelY >= 0 && otherPixelY < g.Sprite.Height)
                        {
                            targetColor = g.Sprite.GetPixel(otherPixelX, otherPixelY);
                        }

                        if (targetColor.R == 0 && targetColor.G == 0 && targetColor.B == 0 && targetColor.A == 255)
                        {

                            if(isBunker)
                            {
                                g.Sprite.SetPixel(otherPixelX, otherPixelY, Color.Transparent);
                                hp -= 1;
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="deltaT">Delta Time</param>
        public virtual void Update(double deltaT) {
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="deltaT">DeltaTime</param>
        /// <param name="keys">Liste des touches appuyés.</param>
        public virtual void Update(double deltaT, HashSet<Keys> keys) {
        }

        /// <summary>
        /// Retourne les coordonnées de l'entité
        /// </summary>
        /// <returns>
        /// Coordonnées de l'entité
        /// </returns>
        /// 
        public override string ToString()
        {
            return String.Format("Position : {0}", Position.ToString());
        }
        #endregion

    }
}