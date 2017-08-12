using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using SpaceInvaders.Interfaces;

namespace SpaceInvaders.Entity
{
    /// <summary>
    /// Représente le bloc ennemie.
    /// </summary>
    /// <seealso cref="SpaceInvaders.Interfaces.IMoveable" />
    public class EnnemyBlock : IMoveable
    {
        #region Fields
        public List<EnnemyLine> ennemyLines = new List<EnnemyLine>();
        public static Direction Direction { get; private set; }
        public Vecteur2D Position { get; set; }

        public double Speed { get; set; }

        private double IncreasedSpeed;
        #endregion

        // Create a timer
        public Timer chrono = new Timer();


        // Implement a call with the right signature for events going off
        private void myEvent(object source, ElapsedEventArgs e) { }

        /// <summary>
        /// Création du bloc par défaut. (5 lignes 55 ennemies)
        /// </summary>
        public EnnemyBlock()
        {
            ennemyLines.Add(new EnnemyLine(new Vecteur2D(100, 60 + GameVariables.offsetY.y * 0), GameSprites.Ship8));
            ennemyLines.Add(new EnnemyLine(new Vecteur2D(100, 60 + GameVariables.offsetY.y * 1), GameSprites.Ship8));
            ennemyLines.Add(new EnnemyLine(new Vecteur2D(100, 60 + GameVariables.offsetY.y * 2), GameSprites.Ship6));
            ennemyLines.Add(new EnnemyLine(new Vecteur2D(100, 60 + GameVariables.offsetY.y * 3), GameSprites.Ship6));
            ennemyLines.Add(new EnnemyLine(new Vecteur2D(100, 60 + GameVariables.offsetY.y * 4), GameSprites.Ship2));
            ennemyLines.Add(new EnnemyLine(new Vecteur2D(100, 60 + GameVariables.offsetY.y * 5), GameSprites.Ship2));

            chrono.Elapsed += new ElapsedEventHandler(RandomShoot);
            // Règle le chrono à 4 secondes
            chrono.Interval = 4000;
            // And start it        
            chrono.Enabled = true;

            Speed = 1;
            Direction = Direction.Right;
            IncreasedSpeed = 1;
        }

        public EnnemyBlock(params EnnemyLine[] els)
        {
            this.ennemyLines = els.ToList<EnnemyLine>();
        }

        #region Methods

        public void Update()
        {

        }

        public void Update(double deltaT)
        {
            foreach (GameEntity ship in Game.game.EnnemyShips)
            {
                EnnemyShip shipCast = (EnnemyShip)ship;
                if ((shipCast.Move(deltaT * IncreasedSpeed)))
                {
                    if (Direction == Direction.Right)
                        ChangeDirection(Direction.Left);
                    else
                        ChangeDirection(Direction.Right);

                    IncreasedSpeed += GameVariables.SpeedFactor;
                    // Accelère la vitesse des tirs
                    chrono.Interval -= 100;
                    Console.WriteLine(String.Format("Changement de direction du bloc ennemis ({0})", Direction));
                }
            }
        }

        public void ChangeDirection(Direction dir)
        {
            Console.WriteLine(Game.game.EnnemyShips.Count);

            foreach (EnnemyShip ship in Game.game.EnnemyShips)
            {
                EnnemyShip shipCast = (EnnemyShip)ship;
                shipCast.MoveDown();
            }
            Direction = dir;
        }

        public void RandomShoot(Object o, ElapsedEventArgs e)
        {
            if (Game.game.EnnemyShips.Count > 0)
            {
                //Console.WriteLine("prochain tir dans {0} secondes.", delay.Second);
                int r = Game.random.Next(Game.game.EnnemyShips.Count);
                Game.game.EnnemyShips[r].Shoot();

            }
        }
    }
    #endregion
}