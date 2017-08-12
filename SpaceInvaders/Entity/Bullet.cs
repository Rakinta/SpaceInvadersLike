using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Entity
{
    /// <summary>
    /// Missile
    /// </summary>
    /// <seealso cref="SpaceInvaders.Entity.GameEntity" />
    public class Bullet : GameEntity
    {
        /// <summary>
        /// Direction du missile (Haut ou Bas).
        /// </summary>
        public Direction direction;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bullet" /> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="speed">The speed.</param>
        /// <param name="hp">The hp.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="sprite">The sprite.</param>
        public Bullet(Vecteur2D position, double speed, int hp, Direction direction, Bitmap sprite) : base(position, speed, hp, sprite)
        {
            this.direction = direction;
            Console.WriteLine(String.Format("Création d'un missile en {0} Dir. : {1}", position, direction));
        }

        /// <summary>
        /// Initialise une nouvelle instance de la class <see cref="Bullet"/>.
        /// </summary>
        public Bullet() : base()
        {
            hp = 0;
            //Console.WriteLine("Destruction du missile en x : {0} y : {1}", Position.x, Position.y);
        }

        public override void Update(double deltaT)
        {
            if (CheckIfOffScreen())
                this.Die();

            if (direction == Direction.Up)
                Position.y -= deltaT * Speed;
            else if(direction == Direction.Down)
                Position.y += deltaT * Speed;

            foreach (GameEntity entity in Game.game.GameEntities)
            {

                if (direction == Direction.Up && entity is EnnemyShip && CheckCollision(entity))
                {
                    Console.WriteLine("Collision avec un vaisseau ennemie");
                    GameSounds.ennemyHurt.Play();
                    int ennemyHP = entity.hp;
                    entity.hp -= hp;
                    hp -= ennemyHP;
                    Game.game.Score += 10;

                    if (Game.random.Next(100) < 5)
                    {
                        // Créer un item bonus parmis la liste des BonusType
                        Array values = Enum.GetValues(typeof(Bonus.BonusType));
                        Bonus b = new Bonus(new Vecteur2D(entity.Position), 202, 1, (Bonus.BonusType)values.GetValue(Game.random.Next(values.Length)));
                        Game.game.AddGameEntity(b);
                    }
                }
                if (direction == Direction.Down && entity is PlayerShip && CheckCollision(entity))
                {
                    Console.WriteLine("Collision avec le joueur");
                    GameSounds.bunkerHurt.Play();
                    int playerHp = entity.hp;
                    entity.hp -= hp;
                    this.Die();
                }
                if (entity is Bunker && CheckCollision(entity, true))
                {
                    Console.WriteLine("Collision avec un bunker");
                }
                if (entity is SpecialEnnemyShip && CheckCollision(entity))
                {
                    Game.game.Score += 50;
                    Console.WriteLine("Collision avec un vaisseau special !");
                    GameSounds.specialShipHurt.Play();
                    int playerHp = entity.hp;
                    entity.hp -= hp;
                    this.Die();
                }
            }
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
        }
    }
}
