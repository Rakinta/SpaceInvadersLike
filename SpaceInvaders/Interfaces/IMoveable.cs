using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Interfaces
{
    /// <summary>
    /// Interface implémentant l'Update d'une entité.
    /// </summary>
    public interface IMoveable
    {

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// Position.
        /// </value>
        Vecteur2D Position { get; set; }
        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>
        /// Vitesse.
        /// </value>
        double Speed { get; set; }
        void Update(double deltaT);
    }
}
