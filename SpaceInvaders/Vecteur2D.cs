using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    /// <summary>
    /// Classe représentant un vecteur.
    /// </summary>
    public class Vecteur2D
    {
        public double x;
        public double y;
        private double norme;

        public double Norme
        {
            get
            {
                return Math.Sqrt((x*x)+(y+y));
            }
        }

        #region Opérateurs
        /// <summary>
        /// Addition vectorielle
        /// </summary>
        /// <param name="v1">Vecteur 1</param>
        /// <param name="v2">Vecteur 2</param>
        /// <returns></returns>
        public static Vecteur2D operator +(Vecteur2D v1, Vecteur2D v2)
        {
            Vecteur2D result = new Vecteur2D();

            result.x = v1.x + v2.x;
            result.y = v1.y + v2.y;

            return result;
        }

        /// <summary>
        /// Soustraction vectorielle
        /// </summary>
        /// <param name="v1">Vecteur 1</param>
        /// <param name="v2">Vecteur 2</param>
        /// <returns></returns>
        public static Vecteur2D operator -(Vecteur2D v1, Vecteur2D v2)
        {
            Vecteur2D result = new Vecteur2D();

            result.x = v1.x - v2.x;
            result.y = v1.y - v2.y;

            return result;
        }

        /// <summary>
        /// Soustraction unitaire
        /// </summary>
        /// <returns></returns>
        public static Vecteur2D operator --(Vecteur2D v1)
        {
            v1.x--;
            v1.y--;

            return v1;
        }

        public static Vecteur2D operator *(Vecteur2D v1, double d)
        {
            v1.x *= d;
            v1.y *= d;
            return v1;
        }
        public static Vecteur2D operator *(double d, Vecteur2D v1)
        {
            v1.x *= d;
            v1.y *= d;
            return v1;
        }

        public static Vecteur2D operator /(Vecteur2D v1, double d)
        {
            v1.x /= d;
            v1.y /= d;
            return v1;
        }
        #endregion

        public override string  ToString()
        {
            return string.Format("X: {0} Y: {1}", x, y);
        }
        #region Constructors
        public Vecteur2D()
        {
            this.x = 0;
            this.y = 0;
        }
        public Vecteur2D(Vecteur2D v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="Vecteur2D"/>.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Vecteur2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion
    }
}
