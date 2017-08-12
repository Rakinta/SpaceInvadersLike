using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using SpaceInvaders.Properties;

namespace SpaceInvaders
{
    public static class GameSounds
    {
        // Player
        public static SoundPlayer playerShooting = new SoundPlayer(Resources.playerShoot);
        public static SoundPlayer playerDeath = new SoundPlayer(Resources.playerDeath);

        // Ennemy
        public static SoundPlayer ennemyShooting = new SoundPlayer(Resources.ennemyShoot);
        public static SoundPlayer ennemyHurt = new SoundPlayer(Resources.ennemyHurt);
        public static SoundPlayer specialShipHurt = new SoundPlayer(Resources.specialShipHurt);

        // Other
        public static SoundPlayer bonus = new SoundPlayer(Resources.bonus_get);
        public static SoundPlayer bunkerHurt = new SoundPlayer(Resources.bunkerHurt);

    }
}
