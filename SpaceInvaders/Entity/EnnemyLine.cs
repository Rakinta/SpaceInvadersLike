using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entity
{
    /// <summary>
    /// Ligne d'ennemis d'un EnnemyBlock
    /// </summary>
    public class EnnemyLine
    {
        private List<EnnemyShip> ennemyList = new List<EnnemyShip>();
        public List<EnnemyShip> EnnemyList { get; set; }

        public Bitmap SpriteGroup { get; set; }

        // Sprite à appliquer à tout les ennemies de la ligne;
        private Bitmap spriteGroup = GameSprites.Ship6;
        public EnnemyLine(Vecteur2D p, Bitmap b)
        {
            for (int i = 0; i < 11; i++)
            {
                EnnemyShip ennemy = new EnnemyShip(new Vecteur2D((p.x) + GameVariables.offsetX.x * i, p.y), GameVariables.ennemySpeed, 7, b, GameVariables.defaultShootSpeed);
                ennemyList.Add(ennemy);
                Game.game.GameEntities.Add(ennemy);
            }
        }

        public EnnemyLine(Bitmap b)
        {
            SpriteGroup = b;
        }
        public void AddEnnemy(EnnemyShip e)
        {
            if (EnnemyList.Count < 11)
            {
                e.Sprite = SpriteGroup;
                EnnemyList.Add(e);
            }
        }
    }
}
