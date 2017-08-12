using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Interfaces;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceInvaders.Entity
{
    /// <summary>
    /// Bunker
    /// </summary>
    /// <seealso cref="SpaceInvaders.Entity.GameEntity" />
    public class Bunker : GameEntity
    {

        #region Constructors

        public Bunker(Vecteur2D p, Double s, int hp, Bitmap sprite) : base(p, s, hp, sprite)
        {
        }
        #endregion

        public override void Update(double deltaT, HashSet<Keys> keys)
        {

        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
        }
    }
}
