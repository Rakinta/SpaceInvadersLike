using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PvZ.Entities;
using PvZ.Entities.Zombies;
using PvZ.Entities.Plants;
using PvZ.Entities.Others;

namespace PvZ
{
    class Global
    {
    
        static public SpriteManager Sprites;    // gestionnaire de sprites
        static public Graphics Ecran;           // utilisé pour les drawscreen
        static public int Height;               // hauteur de la zone d'affichage
        static public int dollar = 200; // 2000;         // money du joueur
        static public int Round = 1;            // compteur de tour
        static public bool DrawHitBox { get; set; } // Dessiner la hitbox
        public static bool DisplayHP { get; set; }


        /////////////////////////////////////////////////////////////////////

        static public Creature Button;            // indique la creature selectionnée

        public enum Creature  { Zombie, ZombieCone, ZombieSot, Tournesol, PistoPois,
                                Mine, Noix, DoublePistoPois, PistoGel, Cerises, Canon };


        static public Dictionary<Creature, int> SunCosts = new Dictionary<Creature, int>()
        {
            { Creature.PistoPois, 100 },
            { Creature.PistoGel, 175 },
            { Creature.DoublePistoPois, 200 },
            { Creature.Tournesol, 50 },
            { Creature.Noix, 50 },
            { Creature.Mine, 25 },
            { Creature.Cerises, 150 }
        };

        static public List<EntityBase> LE = new List<EntityBase>();

        //static public List<ZombieBase> LZ = new List<ZombieBase>();
        //static public PlantBase[,] LP = new PlantBase[5, 9];
        //static public List<PeaBase> LPS = new List<PeaBase>();

        // retour un nombre aléatoire entre 0 et n-1

        static private Random randNum = new Random();

        public static int Random(int min, int max) { return randNum.Next(min , max + 1); }

    }
}
