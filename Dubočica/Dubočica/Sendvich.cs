using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Dubocica
{
    public class Sendvich
    {
        private int timeToMake;
        private bool doneMaking;

        private static Random rnd = new Random();

        enum TimeForSendvich : int { MinTimeToMake = 1, MaxTimeToMake = 4 }

        // when we make new Sandvich, initialize it in it's constructor
        public Sendvich()
        {
            timeToMake = rnd.Next((int)TimeForSendvich.MinTimeToMake, (int)TimeForSendvich.MaxTimeToMake);
            doneMaking = false;
        }

        public void tickMakingOfSendvich()
        {
            if (doneMaking) return;

            if (timeToMake > 0)
            {
                timeToMake--;   
            }
            else
            {
                doneMaking = true;
                return;
            }
        }

        public bool done
        {
            get { return doneMaking; }
        }
    }
}
