using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entity
{
    /// <summary>
    /// Bonus
    /// </summary>
    /// <seealso cref="SpaceInvaders.Entity.GameEntity" />
    public class Bonus : GameEntity
    {
        public enum BonusType {
        MoreLife, 
        SpeedUp, 
        MultipleBullet
        }

        public BonusType bonusType;
        /// <summary>
        ///Initialise une nouvelle instance de la class <see cref="Bonus"/>.
        /// </summary>
        /// <param name="position">Position</param>
        /// <param name="speed">Vitesse</param>
        public Bonus(Vecteur2D position, double speed, int hp, BonusType bonus) : base(position, speed, hp, GameSprites.None)
        {
            this.bonusType = bonus;
            Sprite = GetSpriteByTypde(bonus);
            Console.WriteLine(String.Format("Apparition d'un bonus en {0} Type. : {1}", position, bonus.ToString()));
        }
        /// <summary>
        /// Récupere le sprite correspondants au type de bonus.
        /// </summary>
        /// <param name="bonus">The bonus.</param>
        /// <returns>Bimap</returns>
        public Bitmap GetSpriteByTypde(BonusType bonus)
        {
            switch (bonus)
            {
                case BonusType.MoreLife:
                    return GameSprites.bonusLife;
                case BonusType.SpeedUp:
                    return GameSprites.bonusSpeed;
                case BonusType.MultipleBullet:
                    return GameSprites.bonusBullets;
            }
            return GameSprites.bonusLife;
        }

        public override void Update(double deltaT)
        {
            if (CheckIfOffScreen())
                this.Die();

            Position.y += deltaT * Speed;

            foreach (GameEntity entity in Game.game.GameEntities)
            {
                if (entity is PlayerShip && CheckCollision(entity))
                {
                    GameSounds.bonus.Play();
                    Console.WriteLine("Bonus récupéré !");
                    RunEffects();
                    Game.game.Score += 50;
                    this.Die();
                }
            }
        }
        /// <summary>
        /// Vérifie si le missile est hors de l'écran.
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
        private void RunEffects()
        {
            switch (bonusType)
            {
                case BonusType.MoreLife:
                    Game.game.p1.hp++;
                    break;
                case BonusType.SpeedUp:
                    Game.game.p1.Speed*=1.5;
                    break;
                case BonusType.MultipleBullet:
                    Game.game.p1.multipleBullet = true;
                    break;
                default:
                    break;
            }
        }
    }
}
