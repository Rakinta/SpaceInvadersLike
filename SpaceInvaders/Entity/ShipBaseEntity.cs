using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entity
{
    /// <summary>
    /// Classe de base des vaisseaux (vaisseau du joueur et vaisseau ennemis).
    /// </summary>
    /// <seealso cref="SpaceInvaders.Entity.GameEntity" />
    public class ShipBaseEntity : GameEntity
    {
        #region Fields
        /// <summary>
        /// Plusieurs missiles à la fois ?
        /// </summary>
        public bool multipleBullet;

        /// <summary>
        /// Gets or sets the bullet.
        /// </summary>
        /// <value>
        /// Missile du vaisseau.
        /// </value>
        public List<Bullet> Bullets { get; set; }

        /// <summary>
        /// Gets or sets the shooting speed.
        /// </summary>
        /// <value>
        /// Vitesse du missile.
        /// </value>
        public float ShootingSpeed { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipBaseEntity" /> class.
        /// </summary>
        /// <param name="position">Position</param>
        /// <param name="speed">Vitesse</param>
        /// <param name="hp">Points de vie</param>
        /// <param name="sprite">Sprite</param>
        /// <param name="shootSpeed">Vitesse de tir des missiles</param>
        public ShipBaseEntity(Vecteur2D p, double s, int hp, Bitmap sprite, float shootSpeed) 
            : base(p, s, hp, sprite)
        {
            Bullets = new List<Bullet>();
            ShootingSpeed = shootSpeed;
        }

        public override void Update(double deltaT)
        {
            base.Update(deltaT);
        }


    }
}
