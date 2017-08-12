using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Interfaces
{
    /// <summary>
    /// Interface implémentant le représentation graphique d'une entité.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Gets or sets the sprite.
        /// </summary>
        /// <value>
        /// Sprite de l'entité.
        /// </value>
        
        Bitmap Sprite { get; set; }
        /// <summary>
        /// Draw the entity
        /// </summary>
        /// <param name="g">Graphics to draw in</param>
        void Draw(Graphics g);
    }
}
