using SpaceInvaders.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    /// <summary>
    /// Liste des sprites.
    /// </summary>
    public static class GameSprites
    {
        #region SPRITES

        public static Bitmap Player = new Bitmap(Resources.player);
        public static Bitmap Bunker = new Bitmap(Resources.bunker);

        #region Vaisseaux ennemis
        public static Bitmap Ship1 = new Bitmap(Resources.ship1);
        public static Bitmap Ship2 = new Bitmap(Resources.ship2);
        public static Bitmap Ship4 = new Bitmap(Resources.ship4);
        public static Bitmap Ship5 = new Bitmap(Resources.ship5);
        public static Bitmap Ship6 = new Bitmap(Resources.ship6);
        public static Bitmap Ship7 = new Bitmap(Resources.ship7);
        public static Bitmap Ship8 = new Bitmap(Resources.ship8);
        public static Bitmap Ship9 = new Bitmap(Resources.ship9);

        public static Bitmap Bullet1 = new Bitmap(Resources.shoot1);
        public static Bitmap Bullet2 = new Bitmap(Resources.shoot2);
        public static Bitmap Bullet3 = new Bitmap(Resources.shoot3);
        public static Bitmap Bullet4 = new Bitmap(Resources.shoot4);
        #endregion

        #region Bonus
        public static Bitmap bonusLife = new Bitmap(Resources.bonusLife);
        public static Bitmap bonusBullets = new Bitmap(Resources.bonusBullets);
        public static Bitmap bonusSpeed = new Bitmap(Resources.bonusSpeed);
        #endregion
        #region Divers
        public static Bitmap Background = new Bitmap(Resources.background);
        public static Bitmap None = new Bitmap(Resources.player);
        #endregion

        #endregion
    }
}
