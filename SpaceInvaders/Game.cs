using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using SpaceInvaders.Entity;

namespace SpaceInvaders
{
    /// <summary>
    /// Controller of the game.
    /// It receives events from the Vue (Form1.cs), manages the meta-logic of the game and dispatches the work to the different elements of the game (Models).
    /// </summary>
    class Game
    {

        #region fields and properties

        #region GameEntities

        /// <summary>
        /// Liste des gameEntity qui seront ajoutés au prochain update
        /// </summary>
        private List<GameEntity> AddObjectsList = new List<GameEntity>();
            
        /// <summary>
        /// Liste des gameEntity qui seront supprimés au prochain update
        /// </summary>
        private List<GameEntity> RemoveObjectsList = new List<GameEntity>();

        /// <summary>
        /// Liste des game entity qui seront rendus au prochain update/draw
        /// </summary>
        public List<GameEntity> GameEntities;

        #endregion

        #region game technical elements
        /// <summary>
        /// Size of the game area
        /// </summary>
        public Size gameSize;

        /// <summary>
        /// Status du jeu.
        /// </summary>
        private GameStatus gameStatus;

        /// <summary>
        /// Instance du joueur
        /// </summary>
        public PlayerShip p1;

        /// <summary>
        /// Le score
        /// </summary>
        public int Score;
        
        /// <summary>
        /// State of the keyboard
        /// </summary>
        public HashSet<Keys> keyPressed = new HashSet<Keys>();

        private Timer t = new Timer();
        #endregion

        #region static fields (helpers)

        /// <summary>
        /// Singleton for easy access
        /// </summary>
        public static Game game { get; private set; }

        public EnnemyBlock eb { get; private set; }

        /// <summary>
        /// Random numbers
        /// </summary>
        public static Random random;
        public List<EnnemyShip> EnnemyShips
        {
            get
            {
                List<EnnemyShip> result = new List<EnnemyShip>();
                foreach (EnnemyShip item in game.GameEntities.OfType<EnnemyShip>())
                {
                    result.Add(item);
                }

                return result;
            }
        }

        #endregion

        #endregion

        #region constructors
        /// <summary>
        /// Singleton constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        /// <returns>The singleton instance of the game</returns>
        public static Game CreateGame(Size gameSize)
        {
            random = new Random();
            if (game == null)
                game = new Game(gameSize);

            Game.game.GameEntities = Game.game.InitializeEntities();
            Game.game.eb = new EnnemyBlock();
            Game.game.gameStatus = GameStatus.Playing;

            Game.game.t.Tick += new EventHandler(Game.game.CreateSpecialShip);
            Game.game.t.Interval = 15000;
            Console.WriteLine(game.GameEntities.Count);
            Game.game.t.Start();
            return game;

        }

        /// <summary>
        /// Private constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        private Game(Size gameSize)
        {
            //Console.Title = "DEBUG : Space Invaders";
            this.gameSize = gameSize;
        }

        public List<GameEntity> InitializeEntities()
        {
            Score = 0;

            //Ajout du joueur
            p1 = null;
            p1 = new PlayerShip(new Vecteur2D(gameSize.Width / 2, 550), 150, 2, GameSprites.Player, GameVariables.defaultShootSpeed);

            List <GameEntity> ge = new List<GameEntity>();

            ge.Add(p1);

            Bunker b1 = new Bunker(new Vecteur2D(gameSize.Width * 0.7, 500), 0, 3, GameSprites.Bunker);
            Bunker b2 = new Bunker(new Vecteur2D(gameSize.Width * 0.4, 500), 0, 3, GameSprites.Bunker);
            Bunker b3 = new Bunker(new Vecteur2D(gameSize.Width * 0.1, 500), 0, 3, GameSprites.Bunker);

            ge.Add(b1);
            ge.Add(b2);
            ge.Add(b3);
            return ge;
        }
        #endregion

        #region methods

        /// <summary>
        /// Draw the whole game
        /// </summary>
        /// <param name="g">Graphics to draw in</param>
        public void Draw(Graphics g)
        {
            g.DrawImage(GameSprites.Background, 0, 0, gameSize.Width, gameSize.Height);

            foreach (GameEntity entity in game.GameEntities)
            {
                entity.Draw(g);
            }
            HUD(g);

        }

        /// <summary>
        /// Update game
        /// </summary>
        /// <param name="deltaT">Ellapsed time in seconds since last update.</param>
        public void Update(double deltaT)
        {
            #region Ajout et suppression avant Update
            if (AddObjectsList.Count != 0)
            {
                for (int i = 0; i < AddObjectsList.Count; i++)
                {
                    game.GameEntities.Add(AddObjectsList[i]);
                }
                AddObjectsList.Clear();
            }
            if (RemoveObjectsList.Count != 0)
            {
                for (int i = 0; i < RemoveObjectsList.Count; i++)
                {
                    game.GameEntities.Remove(RemoveObjectsList[i]);
                }
                RemoveObjectsList.Clear();
            }
            #endregion

            GlobalInputs();
            StatusManager();
            if (gameStatus == GameStatus.Playing)
            {
                eb.Update(deltaT);
                foreach (GameEntity entity in game.GameEntities)
                {
                    if (entity.IsAlive)
                    {
                        if (entity.GetType() == typeof(PlayerShip))
                        {
                            entity.Update(deltaT, keyPressed);
                        }
                        else
                        {
                            entity.Update(deltaT);
                        }
                    }
                    else
                    {
                        RemoveGameEntity(entity);
                    }
                }
            }
        }
        public void AddGameEntity(GameEntity ge)
        {
            AddObjectsList.Add(ge);
        }
        private void RemoveGameEntity(GameEntity ge)
        {
            RemoveObjectsList.Add(ge);
        }

        /// <summary>
        /// Raccourcis généraux.
        /// </summary>
        public void GlobalInputs()
        {
            // Mise en pause
            if (keyPressed.Contains(Keys.P))
            {
                if (gameStatus == GameStatus.Paused)
                {
                    Console.WriteLine("Reprise du jeu.");
                    gameStatus = GameStatus.Playing;
                    t.Start();
                    eb.chrono.Start();
                    keyPressed.Remove(Keys.P);
                }
                else
                {
                    Console.WriteLine("Mise en pause...");
                    gameStatus = GameStatus.Paused;
                    t.Stop();
                    eb.chrono.Stop();
                    keyPressed.Remove(Keys.P);
                }
            }
            //Infos debug
            if (keyPressed.Contains(Keys.I))
            {
                Console.WriteLine(String.Format("Taille fenetre :\n X:{0} Y:{1}", gameSize.Width, gameSize.Height));
                Console.WriteLine("Il y a {0} ennemis", Game.game.GameEntities.Count(t => t is EnnemyShip && t.IsAlive));
                keyPressed.Remove(Keys.I);
            }
            // Reset
            if (keyPressed.Contains(Keys.R))
            {
                Reset();
                keyPressed.Remove(Keys.R);
            }

            if (keyPressed.Contains(Keys.K))
            {
                game.GameEntities[0].Die();
            }
            // Debug Afficher HitBox
            if (keyPressed.Contains(Keys.H))
            {
                GameVariables.DisplayHitbox = !GameVariables.DisplayHitbox;
                keyPressed.Remove(Keys.H);
            }
            // Console clear
            if (keyPressed.Contains(Keys.C))
            {
                Console.Clear();
            }
        }


        private void CreateSpecialShip(object sender, EventArgs e)
        {
            game.AddGameEntity(new SpecialEnnemyShip(new Vecteur2D(gameSize.Width, 35), 100, 1, GameSprites.Ship4, Direction.Left));
            game.t.Interval = 20000;

        }

        /// <summary>
        /// Dessine l'interface.
        /// </summary>
        /// <param name="g">Graphics.</param>
        public void HUD(Graphics g)
        {
            // Infos debugs
            //g.DrawString(String.Format("Degug Infos:\nPlayer:\n X:{0} Y:{1}\nGameStatus : {2}", p1.Position.x, p1.Position.y, gameStatus),
            //    GameVariables.defaultFont, GameVariables.whiteBrush, 10, gameSize.Height / 2);

            // Barre supérieur
            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, gameSize.Width, 30);

            g.DrawString(String.Format("VIES : {0}", p1.hp),GameVariables.defaultFont,
                        GameVariables.whiteBrush, 400, 5);

            // Score
            g.DrawString(String.Format("SCORE: {0:000000}", Score), GameVariables.defaultFont,
                        GameVariables.whiteBrush, 60, 5);

            // Indicateur de pause
            if (gameStatus == GameStatus.Paused)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(100, 0,0,0)), 0, 0, gameSize.Width, gameSize.Height);
                g.DrawString("<PAUSE>", GameVariables.pauseFont, GameVariables.whiteBrush, 220, 120);
            }

            // GameOver
            if (gameStatus == GameStatus.Death)
            {
                g.DrawString("GAME OVER !", GameVariables.pauseFont, GameVariables.whiteBrush, 180, 120);
                g.DrawString("Appuier sur (R) pour recommencer.", GameVariables.defaultFont, GameVariables.whiteBrush, 160, 160);
            }

            // Gagné
            if (gameStatus == GameStatus.Win)
            {
                g.DrawString("Gagné !", GameVariables.pauseFont, GameVariables.whiteBrush, 210, 120);
                g.DrawString("Appuier sur (R) pour recommencer.", GameVariables.defaultFont, GameVariables.whiteBrush, 160, 160);
            }

        }

        /// <summary>
        /// Gestion du status du jeu.
        /// </summary>
        public void StatusManager()
        {
            // Si le joueur est mort
            if (!p1.IsAlive && gameStatus != GameStatus.Death)
            {
                Console.WriteLine("GAME OVER");
                GameSounds.playerDeath.Play();
                gameStatus = GameStatus.Death;
            }
            // Si le joueur a gagné
            else if (EnnemyShips.Count == 0)
            {
                gameStatus = GameStatus.Win;
            }
        }
        /// <summary>
        /// Réinitialise le niveau.
        /// </summary>
        public void Reset()
        {
            game.GameEntities.Clear();
            Console.WriteLine("Relancement du niveau...");
            game = Game.CreateGame(gameSize);
            //p1 = new Player(new Vecteur2D(gameSize.Width / 2, 500), 150, 2, GameSprites.PlayerSprite, GameVariables.defaultShootSpeed);
            Console.WriteLine("Niveau relancé !");
         }
        #endregion
    }
}
