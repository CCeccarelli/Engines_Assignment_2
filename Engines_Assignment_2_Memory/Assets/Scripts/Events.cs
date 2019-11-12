using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public abstract class enemyEvents
    {
        public abstract int getScore();
        public abstract int getHealth();
    }

    public class returnScore : enemyEvents
    {
        public override int getScore()
        {
            return 0;
        }
        public override int getHealth()
        {
            return 0;
        }
    }
}
