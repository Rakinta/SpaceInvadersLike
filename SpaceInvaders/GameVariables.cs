using SpaceInvaders.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders
{
    /// <summary>
    /// Variables du jeu (constantes et valeurs par défaut).
    /// </summary>
    public static class GameVariables
    {
        public static Font defaultFont = new Font("Times New Roman", 20, FontStyle.Regular, GraphicsUnit.Pixel);
        public static Font pauseFont = new Font("Arial Black", 30, FontStyle.Bold, GraphicsUnit.Pixel);

        /// <summary>
        /// A shared black brush
        /// </summary>
        public static Brush whiteBrush = new SolidBrush(Color.White);


        /// <summary>
        /// State of the keyboard
        /// </summary>
        public static HashSet<Keys> keyPressed = new HashSet<Keys>();

        public static Vecteur2D offsetX = new Vecteur2D(40, 0);
        public static Vecteur2D offsetY = new Vecteur2D(0, 30);
        public static double ennemySpeed = 5;
        public static float defaultShootSpeed = 500;

        public static double SpeedFactor = 1.2;

        public static bool DisplayHitbox = false;
        //public static EnnemyBlock defaultEnnemyBlock = new EnnemyBlock();

    }
}
