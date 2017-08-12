using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PvZ
{
    class TimeMeasure
    {
        private Stopwatch Watch;  // chronomètre servant à mesure le temps


        public TimeMeasure()
        {
            Watch = new Stopwatch();
            Watch.Start();
            TimeStampStart = Watch.ElapsedMilliseconds;
        }

        private  long LastTick;      // timestamp
        private long  TimeStampStart;

        private  long secfps;        // seconde actuelle pour le comptage fps
        private  int  last_fps = 0;  // estimation fps 
        private  int countfps =  0;  // compte nb affichage dans la seconde actuelle
        private  float dt;           // delta temps depuis le dernier calcul  
        private long lastTime = 0;

        // calcul des FPS

        public int GetFPS() { return last_fps; }

        public void PaintFinished()
        {
            // calcule les fps
            long T = Watch.ElapsedMilliseconds;

            if ( T / 1000 == secfps )
                countfps++;  // compte les images durant cette seconde
            else
            {
                last_fps = countfps;
                countfps = 1;
                secfps++;
            }
        }

        //  Temps écoulé depuis le début de la partie en seconde

        public String GetStringTime()
        {
            TimeSpan ts = Watch.Elapsed;
            return String.Format("TIME : {0:00}:{1:00}:{2:000}", ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        public float GetTime()
        {
            long T = Watch.ElapsedMilliseconds;
            long Delta = T - TimeStampStart;
            return Delta * 0.001f;
        }
        public double GetDeltaTime()
        {
            // lets do 5 ms update to avoid quantum effects
            int maxDelta = 5;

            // get time with millisecond precision
            long nt = Watch.ElapsedMilliseconds;
            // compute ellapsed time since last call to update
            double deltaT = (nt - lastTime);

            //for (; deltaT >= maxDelta; deltaT -= maxDelta)
            //    game.Update(maxDelta / 1000.0);

            //game.Update(deltaT / 1000.0);

            // remember the time of this update
            lastTime = nt;

            return deltaT;
        }
    }
}
