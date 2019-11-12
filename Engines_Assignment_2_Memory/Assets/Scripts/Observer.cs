using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public abstract class Observer//class for the observer to allow notify to be accessed by all namespace observer pattern classes
    {
        public abstract void OnNotify();
        public abstract void OnNotifyHealth();
    }

    public class EnemyCube : Observer//class for the enemies to allow for the subject to know it has been destroyed
    {
        GameObject enemy;
        enemyEvents ev;


        public EnemyCube(GameObject enemy, enemyEvents ev)
        {
            this.enemy = enemy;
            this.ev = ev;
        }

        public override void OnNotify()
        {
            scoreUpdate(ev.getScore());
        }

        public override void OnNotifyHealth()
        {
            healthUpdate(ev.getHealth());
        }

        void scoreUpdate(int score)
        {
            enemy = GameObject.Find("MainCamera");
            enemy.GetComponent<Control>().score += 1;
        }

        void healthUpdate(int health)
        {
            enemy = GameObject.Find("MainCamera");
            enemy.GetComponent<Control>().health -= 1;
        }
    }
}